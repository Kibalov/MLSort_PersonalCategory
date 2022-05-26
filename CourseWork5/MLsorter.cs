using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using System.IO;
using Microsoft.ML.Data;
using System.Windows.Forms;


namespace CourseWork5
{
    class MLsorter
    {
        string _OutputImgFolder;
        string _SortedImagesFolder;
        string _SortedImagesTagsTsv;
        string _OutputTsv;
        string _inceptionTensorFlowModel;
        public MLsorter(string Output, string[] paths)
        {
            _inceptionTensorFlowModel = Path.Combine(Environment.CurrentDirectory, "assets", "tensorflow_inception_graph.pb");

            _OutputImgFolder = Output;

            Directory.CreateDirectory(Path.Combine(_OutputImgFolder, "Эту папку можно удалить -_-"));
            _SortedImagesFolder = Path.Combine(_OutputImgFolder, "Эту папку можно удалить -_-");

            DuplicateImagesWithTsv(paths);
            WriteOnTsv(Output);
            
            _SortedImagesTagsTsv = Path.Combine(_SortedImagesFolder, "imgs.tsv");
            _OutputTsv = Path.Combine(Output, "imgs.tsv");

            MLContext mlContext = new MLContext();
            ITransformer model = GenerateModel(mlContext);

            ConsumeModelAndShowSortResult(model, mlContext);
        }
        private void DuplicateImagesWithTsv(string[] paths)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] imgpaths = Directory.GetFiles(paths[i]);
                string[] imgnames = new string[imgpaths.Length];
                for (int j = 0; j < imgpaths.Length; j++)
                {
                    imgnames[j] = imgpaths[j].Substring(imgpaths[j].LastIndexOf("\\") + 1);
                }
                for (int j = 0; j < imgpaths.Length; j++)
                    try
                    {
                        File.Copy(imgpaths[j], Path.Combine(_SortedImagesFolder, imgnames[j]));
                    }
                    catch{ }
            }

            string[] FolderName = new string[paths.Length];
            for (int i = 0; i < FolderName.Length; i++)
            {
                FolderName[i] = paths[i].Substring(paths[i].LastIndexOf("\\") + 1);
            }
            
            StreamWriter streamWriter = new StreamWriter(File.Create(Path.Combine(_SortedImagesFolder, "imgs.tsv")));
            foreach (string path in paths)
            {
                ImagePaths imagepaths = new ImagePaths(path);
                string[] imgnames = new string[imagepaths.images.Length];
                for (int i = 0; i < imagepaths.images.Length; i++)
                {
                    imgnames[i] = imagepaths.images[i].Substring(imagepaths.images[i].LastIndexOf("\\") + 1);
                    streamWriter.WriteLine(imgnames[i] + "\t" + path);
                }
            }
            streamWriter.Close();

            ImagePaths imagepathsoutput = new ImagePaths(_OutputImgFolder);
            for (int i = 0; i < imagepathsoutput.images.Length; i++)
            {
                string name = imagepathsoutput.images[i].Substring(imagepathsoutput.images[i].LastIndexOf("\\") + 1);
                try
                {
                    File.Copy(imagepathsoutput.images[i], Path.Combine(_SortedImagesFolder, name));
                }
                catch { }
            }
        }

        private void WriteOnTsv(string folder)
        {
            ImagePaths imagepaths = new ImagePaths(folder);
            StreamWriter streamWriter = new StreamWriter(Path.Combine(folder,"imgs.tsv"));
            string filename;
            for (int i = 0; i < imagepaths.images.Length; i++)
            {
                filename = imagepaths.images[i].Substring(imagepaths.images[i].LastIndexOf("\\")+ 1);
                streamWriter.WriteLine(filename);
            }
            streamWriter.Close();
        }
        
        private struct InceptionSettings
        {
            public const int ImageHeight = 224;
            public const int ImageWidth = 224;
            public const float Mean = 117;
            public const float Scale = 1;
            public const bool ChannelsLast = true;
        }

        private ITransformer GenerateModel(MLContext mlContext)
        {
            IEstimator<ITransformer> pipeline = mlContext.Transforms.LoadImages(outputColumnName: "input", imageFolder: _SortedImagesFolder, inputColumnName: nameof(ImageData.ImagePath))
                .Append(mlContext.Transforms.ResizeImages(outputColumnName: "input", imageWidth: InceptionSettings.ImageWidth, imageHeight: InceptionSettings.ImageHeight, inputColumnName: "input"))
                .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "input", interleavePixelColors: InceptionSettings.ChannelsLast, offsetImage: InceptionSettings.Mean))
                .Append(mlContext.Model.LoadTensorFlowModel(_inceptionTensorFlowModel)
                    .ScoreTensorFlowModel(outputColumnNames: new[] { "softmax2_pre_activation" }, inputColumnNames: new[] { "input" }, addBatchDimensionInput: true))
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "LabelKey", inputColumnName: "Label"))
                .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "LabelKey", featureColumnName: "softmax2_pre_activation"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"))
                .AppendCacheCheckpoint(mlContext);

            IDataView trainingData = mlContext.Data.LoadFromTextFile<ImageData>(path: _SortedImagesTagsTsv, hasHeader: false);
            ITransformer model = pipeline.Fit(trainingData);

            return model;
        }

        private void ConsumeModelAndShowSortResult(ITransformer model, MLContext mlContext)
        {
            IDataView testData = mlContext.Data.LoadFromTextFile<ImageData>(path: _OutputTsv, hasHeader: false);
            IDataView predictions = model.Transform(testData);
            IEnumerable<ImagePrediction> imagePredictionData = mlContext.Data.CreateEnumerable<ImagePrediction>(predictions, true);

            ImagesDisplayForm imagesDisplay = new ImagesDisplayForm(imagePredictionData, _OutputImgFolder);
            imagesDisplay.ShowDialog();
        }

        //private void DisplayResults(IEnumerable<ImagePrediction> imagePredictionData)
        //{
        //    foreach (ImagePrediction prediction in imagePredictionData)
        //    {
        //        Console.WriteLine($"Image: {Path.GetFileName(prediction.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score.Max()} ");
        //    }
        //}

        //private IEnumerable<ImageData> ReadFromTsv(string file, string folder)
        //{
        //    return File.ReadAllLines(file)
        //        .Select(line => line.Split('\t'))
        //        .Select(line => new ImageData()
        //        {
        //            ImagePath = Path.Combine(folder, line[0])
        //        });
        //}
    }
}
