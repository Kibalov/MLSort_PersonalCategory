using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseWork5
{
    class ImagePaths
    {
        public string[] images { get; protected set; }
        public ImagePaths(string OutputFilder)
        {
            var images1 = Directory.GetFiles(OutputFilder, "*.jpg");
            var images2 = Directory.GetFiles(OutputFilder, "*.png");
            var images3 = Directory.GetFiles(OutputFilder, "*.jpeg");
            var images4 = Directory.GetFiles(OutputFilder, "*.gif");
            images = new string[images1.Length + images2.Length + images3.Length + images4.Length];
            images1.CopyTo(images, 0);
            images2.CopyTo(images, images1.Length);
            images3.CopyTo(images, images2.Length + images1.Length);
            images4.CopyTo(images, images3.Length + images2.Length + images1.Length);

        }
    }
}
