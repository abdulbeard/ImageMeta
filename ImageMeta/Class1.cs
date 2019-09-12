using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageMeta
{
    public class Class1
    {
        public void asdf()
        {
            var img = Image.FromFile(@"C:\Users\azaheer\Downloads\IMG_20190517_170000.jpg");
            var props = img.PropertyItems;
            var propsAsc = (new List<PropertyItem>(props)).OrderBy(x => x.Id);

            var gpsver = new GpsVer().GetValue(propsAsc.First(x => x.Id == new GpsVer().Id));
            var gpsLat = new GpsLatitude().GetValue(propsAsc.First(x => x.Id == new GpsLatitude().Id));
        }
    }
}
