using System;
using System.Drawing;

namespace ImageMeta
{
    public class Class1
    {
        public void asdf()
        {
            var img = Image.FromFile(@"C:\Users\azaheer\Downloads\IMG_20190517_170000.jpg");
            var props = img.PropertyItems;
        }
    }
}
