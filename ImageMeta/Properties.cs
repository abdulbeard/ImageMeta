using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Linq;
using static ImageMeta.Orientation;

namespace ImageMeta
{
    public class NewSubfileType : AbsProperty<uint>
    {
        public NewSubfileType() : base(254, "NewSubfileType", "Type of data in a subfile.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override uint Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetLongArray(pi.Value, Length);
                return val.Any() ? val[0] : 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(uint value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class SubfileType : AbsProperty<ushort>
    {
        public SubfileType() : base(255, "SubfileType", "Type of data in a subfile.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class ImageWidth : AbsProperty<int>
    {
        public ImageWidth() : base(256, "ImageWidth", "Number of pixels per row.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override int Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var preferredType = GetPreferredPropertyType(Types.ToList());
                switch (preferredType)
                {
                    case PropertyType.UShortArray:
                        {
                            var val = GetUShortArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                    case PropertyType.LongArray:
                        {
                            var val = GetULongArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                }
                return 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(int value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class ImageHeight : AbsProperty<int>
    {
        public ImageHeight() : base(257, "ImageHeight", "Number of pixel rows.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override int Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var preferredType = GetPreferredPropertyType(Types.ToList());
                switch (preferredType)
                {
                    case PropertyType.UShortArray:
                        {
                            var val = GetUShortArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                    case PropertyType.LongArray:
                        {
                            var val = GetULongArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                }
                return 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(int value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class BitsPerSample : AbsProperty<ushort>
    {
        public BitsPerSample() : base(258, "BitsPerSample", "Number of bits per color component. See also SamplesPerPixel.", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class Compression : AbsProperty<ushort>
    {
        public Compression() : base(259, "Compression", "Compression scheme used for the image data.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class PhotometricInterp : AbsProperty<ushort>
    {
        public PhotometricInterp() : base(262, "PhotometricInterp", "How pixel data will be interpreted.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class ThreshHolding : AbsProperty<ushort>
    {
        public ThreshHolding() : base(263, "ThreshHolding", "Technique used to convert from gray pixels to black and white pixels.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class CellWidth : AbsProperty<ushort>
    {
        public CellWidth() : base(264, "CellWidth", "Width of the dithering or halftoning matrix.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class CellHeight : AbsProperty<ushort>
    {
        public CellHeight() : base(265, "CellHeight", "Height of the dithering or halftoning matrix.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class FillOrder : AbsProperty<ushort>
    {
        public FillOrder() : base(266, "FillOrder", "Logical order of bits in a byte.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override ushort Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                return val.Any() ? val[0] : (ushort)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(ushort value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class DocumentName : AbsProperty<string>
    {
        public DocumentName() : base(269, "DocumentName", "Null-terminated character string that specifies the name of the document from which the image was scanned.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return GetAscii(pi.Value, Length);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(string value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes(value);
        }
    }

    public class ImageDescription : AbsProperty<string>
    {
        public ImageDescription() : base(270, "ImageDescription", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return GetAscii(pi.Value, Length);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(string value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes(value);
        }
    }

    public class EquipMake : AbsProperty<string>
    {
        public EquipMake() : base(271, "EquipMake", "Null-terminated character string that specifies the manufacturer of the equipment used to record the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return GetAscii(pi.Value, Length);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(string value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes(value);
        }
    }

    public class EquipModel : AbsProperty<string>
    {
        public EquipModel() : base(272, "EquipModel", "Null-terminated character string that specifies the model name or model number of the equipment used to record the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return GetAscii(pi.Value, Length);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(string value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes(value);
        }
    }

    public class StripOffsets : AbsProperty<int>
    {
        public StripOffsets() : base(273, "StripOffsets", "For each strip, the byte offset of that strip. See also RowsPerStrip and StripBytesCount", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0)
        {
        }
        protected override int Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var preferredType = GetPreferredPropertyType(Types.ToList());
                switch (preferredType)
                {
                    case PropertyType.UShortArray:
                        {
                            var val = GetUShortArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                    case PropertyType.LongArray:
                        {
                            var val = GetULongArray(pi.Value, Length);
                            return (int)(val.Any() ? val[0] : 0);
                        }
                }
                return 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(int value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes(value);
        }
    }

    public class Orientation : AbsProperty<OrientationMap>
    {
        public Orientation() : base(274, "Orientation", "Image orientation viewed in terms of rows and columns. " +
            "1 - The 0th row is at the top of the visual image, and the 0th column is the visual left side. " +
            "2 - The 0th row is atthe visual top of the image, and the 0th column is the visual right side. " +
            "3 - The 0th row is at the visual bottom ofthe image, and the 0th column is the visual right side. " +
            "4 - The 0th row is at the visual bottom of the image, andthe 0th column is the visual left side. " +
            "5 - The 0th row is the visual left side of the image, and the 0th column isthe visual top. " +
            "6 - The 0th row is the visual right side of the image, and the 0th column is the visual top. " +
            "7 - The0th row is the visual right side of the image, and the 0th column is the visual bottom. " +
            "8 - The 0th row is thevisual left side of the image, and the 0th column is the visual bottom.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override OrientationMap Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetUShortArray(pi.Value, Length);
                if (val.Any())
                {
                    return (OrientationMap) val[0];
                }
                return OrientationMap.Undefined;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(OrientationMap value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes((short)value);
        }

        public enum OrientationMap : ushort
        {
            Undefined,
            /// <summary>
            /// The 0th row is at the top of the visual image, and the 0th column is the visual left side
            /// </summary>
            One,
            /// <summary>
            /// The 0th row is at the visual top of the image, and the 0th column is the visual right side
            /// </summary>
            Two,
            /// <summary>
            /// The 0th row is at the visual bottom ofthe image, and the 0th column is the visual right side
            /// </summary>
            Three,
            /// <summary>
            /// The 0th row is at the visual bottom of the image, andthe 0th column is the visual left side
            /// </summary>
            Four,
            /// <summary>
            /// The 0th row is the visual left side of the image, and the 0th column isthe visual top
            /// </summary>
            Five,
            /// <summary>
            /// The 0th row is the visual right side of the image, and the 0th column is the visual top
            /// </summary>
            Six,
            /// <summary>
            /// The0th row is the visual right side of the image, and the 0th column is the visual bottom
            /// </summary>
            Seven,
            /// <summary>
            /// The 0th row is the visual left side of the image, and the 0th column is the visual bottom
            /// </summary>
            Eight
        }
    }

    public class SamplesPerPixel : AbsProperty<object>
    {
        public SamplesPerPixel() : base(277, "SamplesPerPixel", "Number of color components per pixel.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class RowsPerStrip : AbsProperty<object>
    {
        public RowsPerStrip() : base(278, "RowsPerStrip", "Number of rows per strip. See also StripBytesCount and StripOffsets", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class StripBytesCount : AbsProperty<object>
    {
        public StripBytesCount() : base(279, "StripBytesCount", "For each strip, the total number of bytes in that strip.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class MinSampleValue : AbsProperty<object>
    {
        public MinSampleValue() : base(280, "MinSampleValue", "For each color component, the minimum value assigned to that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class MaxSampleValue : AbsProperty<object>
    {
        public MaxSampleValue() : base(281, "MaxSampleValue", "For each color component, the maximum value assigned to that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class XResolution : AbsProperty<object>
    {
        public XResolution() : base(282, "XResolution", "Number of pixels per unit in the image width (x) direction. The unit is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class YResolution : AbsProperty<object>
    {
        public YResolution() : base(283, "YResolution", "Number of pixels per unit in the image height (y) direction. The unit is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PlanarConfig : AbsProperty<object>
    {
        public PlanarConfig() : base(284, "PlanarConfig", "Whether pixel components are recorded in chunky or planar format.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PageName : AbsProperty<object>
    {
        public PageName() : base(285, "PageName", "Null-terminated character string that specifies the name of the page from which the image was scanned.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class XPosition : AbsProperty<object>
    {
        public XPosition() : base(286, "XPosition", "Offset from the left side of the page to the left side of the image. The unit of measure is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class YPosition : AbsProperty<object>
    {
        public YPosition() : base(287, "YPosition", "Offset from the top of the page to the top of the image. The unit of measure is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class FreeOffset : AbsProperty<object>
    {
        public FreeOffset() : base(288, "FreeOffset", "For each string of contiguous unused bytes, the byte offset of that string.", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class FreeByteCounts : AbsProperty<object>
    {
        public FreeByteCounts() : base(289, "FreeByteCounts", "For each string of contiguous unused bytes, the number of bytes in that string.", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class GrayResponseUnit : AbsProperty<object>
    {
        public GrayResponseUnit() : base(290, "GrayResponseUnit", "Precision of the number specified by PropertyTagGrayResponseCurve. 1 specifies tenths, 2 specifies hundredths, 3specifies thousandths, and so on.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class GrayResponseCurve : AbsProperty<object>
    {
        public GrayResponseCurve() : base(291, "GrayResponseCurve", "For each possible pixel value in a grayscale image, the optical density of that pixel value.", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class T4Option : AbsProperty<object>
    {
        public T4Option() : base(292, "T4Option", "Set of flags that relate to T4 encoding.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class T6Option : AbsProperty<object>
    {
        public T6Option() : base(293, "T6Option", "Set of flags that relate to T6 encoding.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ResolutionUnit : AbsProperty<object>
    {
        public ResolutionUnit() : base(296, "ResolutionUnit", "Unit of measure for the horizontal resolution and the vertical resolution. 2 - inch 3 - centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PageNumber : AbsProperty<object>
    {
        public PageNumber() : base(297, "PageNumber", "Page number of the page from which the image was scanned.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TransferFunction : AbsProperty<object>
    {
        public TransferFunction() : base(301, "TransferFunction", "Tables that specify transfer functions for the image. Total number of 16-bit words required for the tables", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class SoftwareUsed : AbsProperty<object>
    {
        public SoftwareUsed() : base(305, "SoftwareUsed", "Null-terminated character string that specifies the name and version of the software or firmware of the device usedto generate the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class DateTime : AbsProperty<object>
    {
        public DateTime() : base(306, "DateTime", "Date and time the image was created.", new List<PropertyType> { PropertyType.Ascii }, 20)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class Artist : AbsProperty<object>
    {
        public Artist() : base(315, "Artist", "Null-terminated character string that specifies the name of the person who created the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HostComputer : AbsProperty<object>
    {
        public HostComputer() : base(316, "HostComputer", "Null-terminated character string that specifies the computer and/or operating system used to create the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class Predictor : AbsProperty<object>
    {
        public Predictor() : base(317, "Predictor", "Type of prediction scheme that was applied to the image data before the encoding scheme was applied.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class WhitePoint : AbsProperty<object>
    {
        public WhitePoint() : base(318, "WhitePoint", "Chromaticity of the white point of the image.", new List<PropertyType> { PropertyType.LongFractionArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrimaryChromaticities : AbsProperty<object>
    {
        public PrimaryChromaticities() : base(319, "PrimaryChromaticities", "For each of the three primary colors in the image, the chromaticity of that color.", new List<PropertyType> { PropertyType.LongFractionArray }, 6)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ColorMap : AbsProperty<object>
    {
        public ColorMap() : base(320, "ColorMap", "Color palette (lookup table) for a palette-indexed image.", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneHints : AbsProperty<object>
    {
        public HalftoneHints() : base(321, "HalftoneHints", "Information used by the halftone function", new List<PropertyType> { PropertyType.UShortArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TileWidth : AbsProperty<object>
    {
        public TileWidth() : base(322, "TileWidth", "Number of pixel columns in each tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TileLength : AbsProperty<object>
    {
        public TileLength() : base(323, "TileLength", "Number of pixel rows in each tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TileOffset : AbsProperty<object>
    {
        public TileOffset() : base(324, "TileOffset", "For each tile, the byte offset of that tile.", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TileByteCounts : AbsProperty<object>
    {
        public TileByteCounts() : base(325, "TileByteCounts", "For each tile, the number of bytes in that tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class InkSet : AbsProperty<object>
    {
        public InkSet() : base(332, "InkSet", "Set of inks used in a separated image.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class InkNames : AbsProperty<object>
    {
        public InkNames() : base(333, "InkNames", "Sequence of concatenated, null-terminated, character strings that specify the names of the inks used in a separated image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class NumberOfInks : AbsProperty<object>
    {
        public NumberOfInks() : base(334, "NumberOfInks", "Number of inks.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class DotRange : AbsProperty<object>
    {
        public DotRange() : base(336, "DotRange", "Color component values that correspond to a 0 percent dot and a 100 percent dot. 2 or 2 � SamplesPerPixel", new List<PropertyType> { PropertyType.Bytes, PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TargetPrinter : AbsProperty<object>
    {
        public TargetPrinter() : base(337, "TargetPrinter", "Null-terminated character string that describes the intended printing environment.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExtraSamples : AbsProperty<object>
    {
        public ExtraSamples() : base(338, "ExtraSamples", "Number of extra color components. For example, one extra component might hold an alpha value.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class SampleFormat : AbsProperty<object>
    {
        public SampleFormat() : base(339, "SampleFormat", "For each color component, the numerical format (unsigned, signed, floating point) of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class SMinSampleValue : AbsProperty<object>
    {
        public SMinSampleValue() : base(340, "SMinSampleValue", "For each color component, the minimum value of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class SMaxSampleValue : AbsProperty<object>
    {
        public SMaxSampleValue() : base(341, "SMaxSampleValue", "For each color component, the maximum value of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class TransferRange : AbsProperty<object>
    {
        public TransferRange() : base(342, "TransferRange", "Table of values that extends the range of the transfer function.", new List<PropertyType> { PropertyType.UShortArray }, 6)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGProc : AbsProperty<object>
    {
        public JPEGProc() : base(512, "JPEGProc", "JPEG compression process.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGInterFormat : AbsProperty<object>
    {
        public JPEGInterFormat() : base(513, "JPEGInterFormat", "Offset to the start of a JPEG bitstream.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGInterLength : AbsProperty<object>
    {
        public JPEGInterLength() : base(514, "JPEGInterLength", "Length, in bytes, of the JPEG bitstream.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGRestartInterval : AbsProperty<object>
    {
        public JPEGRestartInterval() : base(515, "JPEGRestartInterval", "Length of the restart interval.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGLosslessPredictors : AbsProperty<object>
    {
        public JPEGLosslessPredictors() : base(517, "JPEGLosslessPredictors", "For each color component, a lossless predictor-selection value for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGPointTransforms : AbsProperty<object>
    {
        public JPEGPointTransforms() : base(518, "JPEGPointTransforms", "For each color component, a point transformation value for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGQTables : AbsProperty<object>
    {
        public JPEGQTables() : base(519, "JPEGQTables", "For each color component, the offset to the quantization table for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGDCTables : AbsProperty<object>
    {
        public JPEGDCTables() : base(520, "JPEGDCTables", "For each color component, the offset to the DC Huffman table (or lossless Huffman table) for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGACTables : AbsProperty<object>
    {
        public JPEGACTables() : base(521, "JPEGACTables", "For each color component, the offset to the AC Huffman table for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class YCbCrCoefficients : AbsProperty<object>
    {
        public YCbCrCoefficients() : base(529, "YCbCrCoefficients", "Coefficients for transformation from RGB to YCbCr image data.", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class YCbCrSubsampling : AbsProperty<object>
    {
        public YCbCrSubsampling() : base(530, "YCbCrSubsampling", "Sampling ratio of chrominance components in relation to the luminance component.", new List<PropertyType> { PropertyType.UShortArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class YCbCrPositioning : AbsProperty<object>
    {
        public YCbCrPositioning() : base(531, "YCbCrPositioning", "Position of chrominance components in relation to the luminance component.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class REFBlackWhite : AbsProperty<object>
    {
        public REFBlackWhite() : base(532, "REFBlackWhite", "Reference black point value and reference white point value.", new List<PropertyType> { PropertyType.LongFractionArray }, 6)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class Gamma : AbsProperty<object>
    {
        public Gamma() : base(769, "Gamma", "Gamma value attached to the image. The gamma value is stored as a rational number (pair of long) with a numerator of 100000. For example, a gamma value of 2.2 is stored as the pair (100000, 45455).", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ICCProfileDescriptor : AbsProperty<object>
    {
        public ICCProfileDescriptor() : base(770, "ICCProfileDescriptor", "Null-terminated character string that identifies an ICC profile.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class SRGBRenderingIntent : AbsProperty<object>
    {
        public SRGBRenderingIntent() : base(771, "SRGBRenderingIntent", "How the image should be displayed as defined by the International Color Consortium (ICC). If a GDI+ object is constructed with theuseEmbeddedColorManagement parameter set to TRUE, then GDI+ renders the image according to the specified rendering intent. The intent can be set to perceptual, relative colorimetric, saturation, or absolutecolorimetric. Perceptual intent, which is suitable for photographs,\tgives good adaptation to the display device gamut at theexpense of colorimetric accuracy.Relative colorimetric intent is suitable for images (for example, logos) that require color appearance matchingthat is relative to the display device white point.Saturation intent, which is suitable for charts and graphs, preserves saturation at the expense of hue andlightness.Absolute colorimetric intent is suitable for proofs(previews of images destined for a different display device) that require preservation of absolute colorimetry. Perceptual intent, which is suitable for photographs, gives good adaptation to the display device gamut at theexpense of colorimetric accuracy.Relative colorimetric intent is suitable for images (for example, logos) that require color appearance matchingthat is relative to the display device white point.Saturation intent, which is suitable for charts and graphs, preserves saturation at the expense of hue andlightness.Absolute colorimetric intent is suitable for proofs(previews of images destined for a different display device) that require preservation of absolute colorimetry.", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ImageTitle : AbsProperty<object>
    {
        public ImageTitle() : base(800, "ImageTitle", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ResolutionXUnit : AbsProperty<object>
    {
        public ResolutionXUnit() : base(20481, "ResolutionXUnit", "Units in which to display horizontal resolution. 1 - pixels per inch 2 - pixels per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ResolutionYUnit : AbsProperty<object>
    {
        public ResolutionYUnit() : base(20482, "ResolutionYUnit", "Units in which to display vertical resolution. 1 - pixels per inch 2 - pixels per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ResolutionXLengthUnit : AbsProperty<object>
    {
        public ResolutionXLengthUnit() : base(20483, "ResolutionXLengthUnit", "Units in which to display the image width. 1 - inches 2 - centimeters 3 - points 4 - picas 5 - columns", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ResolutionYLengthUnit : AbsProperty<object>
    {
        public ResolutionYLengthUnit() : base(20484, "ResolutionYLengthUnit", "Units in which to display the image height. 1 - inches 2 - centimeters 3 - points 4 - picas 5 - columns", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrintFlags : AbsProperty<object>
    {
        public PrintFlags() : base(20485, "PrintFlags", "Sequence of one-byte Boolean values that specify printing options.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrintFlagsVersion : AbsProperty<object>
    {
        public PrintFlagsVersion() : base(20486, "PrintFlagsVersion", "Print flags version.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrintFlagsCrop : AbsProperty<object>
    {
        public PrintFlagsCrop() : base(20487, "PrintFlagsCrop", "Print flags center crop marks.", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrintFlagsBleedWidth : AbsProperty<object>
    {
        public PrintFlagsBleedWidth() : base(20488, "PrintFlagsBleedWidth", "Print flags bleed width.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PrintFlagsBleedWidthScale : AbsProperty<object>
    {
        public PrintFlagsBleedWidthScale() : base(20489, "PrintFlagsBleedWidthScale", "Print flags bleed width scale.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneLPI : AbsProperty<object>
    {
        public HalftoneLPI() : base(20490, "HalftoneLPI", "Ink's screen frequency, in lines per inch.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneLPIUnit : AbsProperty<object>
    {
        public HalftoneLPIUnit() : base(20491, "HalftoneLPIUnit", "Units for the screen frequency. 1 - lines per inch 2 - lines per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneDegree : AbsProperty<object>
    {
        public HalftoneDegree() : base(20492, "HalftoneDegree", "Angle for screen.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneShape : AbsProperty<object>
    {
        public HalftoneShape() : base(20493, "HalftoneShape", "Shape of the halftone dots. 0 - round 1 - ellipse 2 - line 3 - square 4 - cross 6 - diamond", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneMisc : AbsProperty<object>
    {
        public HalftoneMisc() : base(20494, "HalftoneMisc", "Miscellaneous halftone information.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class HalftoneScreen : AbsProperty<object>
    {
        public HalftoneScreen() : base(20495, "HalftoneScreen", "Boolean value that specifies whether to use the printer's default screens. 1 - use printer 's default screens 2 - other", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class JPEGQuality : AbsProperty<object>
    {
        public JPEGQuality() : base(20496, "JPEGQuality", "Private tag used by the Adobe Photoshop format. Not for public use.", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class GridSize : AbsProperty<object>
    {
        public GridSize() : base(20497, "GridSize", "Block of information about grids and guides.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailFormat : AbsProperty<object>
    {
        public ThumbnailFormat() : base(20498, "ThumbnailFormat", "Format of the thumbnail image. 0 - raw RGB 1 - JPEG", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailWidth : AbsProperty<object>
    {
        public ThumbnailWidth() : base(20499, "ThumbnailWidth", "Width, in pixels, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailHeight : AbsProperty<object>
    {
        public ThumbnailHeight() : base(20500, "ThumbnailHeight", "Height, in pixels, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailColorDepth : AbsProperty<object>
    {
        public ThumbnailColorDepth() : base(20501, "ThumbnailColorDepth", "bits per pixel (BPP) for the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailPlanes : AbsProperty<object>
    {
        public ThumbnailPlanes() : base(20502, "ThumbnailPlanes", "Number of color planes for the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailRawBytes : AbsProperty<object>
    {
        public ThumbnailRawBytes() : base(20503, "ThumbnailRawBytes", "Byte offset between rows of pixel data.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailSize : AbsProperty<object>
    {
        public ThumbnailSize() : base(20504, "ThumbnailSize", "Total size, in bytes, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailCompressedSize : AbsProperty<object>
    {
        public ThumbnailCompressedSize() : base(20505, "ThumbnailCompressedSize", "Compressed size, in bytes, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ColorTransferFunction : AbsProperty<object>
    {
        public ColorTransferFunction() : base(20506, "ColorTransferFunction", "Table of values that specify color transfer functions.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailData : AbsProperty<object>
    {
        public ThumbnailData() : base(20507, "ThumbnailData", "Raw thumbnail bits in JPEG or RGB format. Depends on PropertyTagThumbnailFormat.", new List<PropertyType> { PropertyType.Bytes }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailImageWidth : AbsProperty<object>
    {
        public ThumbnailImageWidth() : base(20512, "ThumbnailImageWidth", "Number of pixels per row in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailImageHeight : AbsProperty<object>
    {
        public ThumbnailImageHeight() : base(20513, "ThumbnailImageHeight", "Number of pixel rows in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailBitsPerSample : AbsProperty<object>
    {
        public ThumbnailBitsPerSample() : base(20514, "ThumbnailBitsPerSample", "Number of bits per color component in the thumbnail image. See also ThumbnailSamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailCompression : AbsProperty<object>
    {
        public ThumbnailCompression() : base(20515, "ThumbnailCompression", "Compression scheme used for thumbnail image data.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailPhotometricInterp : AbsProperty<object>
    {
        public ThumbnailPhotometricInterp() : base(20516, "ThumbnailPhotometricInterp", "How thumbnail pixel data will be interpreted.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailImageDescription : AbsProperty<object>
    {
        public ThumbnailImageDescription() : base(20517, "ThumbnailImageDescription", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailEquipMake : AbsProperty<object>
    {
        public ThumbnailEquipMake() : base(20518, "ThumbnailEquipMake", "Null-terminated character string that specifies the manufacturer of the equipment used to record the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailEquipModel : AbsProperty<object>
    {
        public ThumbnailEquipModel() : base(20519, "ThumbnailEquipModel", "Null-terminated character string that specifies the model name or model number of the equipment used to record thethumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailStripOffsets : AbsProperty<object>
    {
        public ThumbnailStripOffsets() : base(20520, "ThumbnailStripOffsets", "For each strip in the thumbnail image, the byte offset of that strip. See also ThumbnailRowsPerStrip and PropertyTagThumbnailStripBytesCount", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailOrientation : AbsProperty<object>
    {
        public ThumbnailOrientation() : base(20521, "ThumbnailOrientation", "Thumbnail image orientation in terms of rows and columns. See also Orientation", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailSamplesPerPixel : AbsProperty<object>
    {
        public ThumbnailSamplesPerPixel() : base(20522, "ThumbnailSamplesPerPixel", "Number of color components per pixel in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailRowsPerStrip : AbsProperty<object>
    {
        public ThumbnailRowsPerStrip() : base(20523, "ThumbnailRowsPerStrip", "Number of rows per strip in the thumbnail image. See also ThumbnailStripBytesCount and ThumbnailStripOffsets", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailStripBytesCount : AbsProperty<object>
    {
        public ThumbnailStripBytesCount() : base(20524, "ThumbnailStripBytesCount", "For each thumbnail image strip, the total number of bytes in that strip.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailResolutionX : AbsProperty<object>
    {
        public ThumbnailResolutionX() : base(20525, "ThumbnailResolutionX", "Thumbnail resolution in the width direction. The resolution unit is given in ThumbnailResolutionUnit", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailResolutionY : AbsProperty<object>
    {
        public ThumbnailResolutionY() : base(20526, "ThumbnailResolutionY", "Thumbnail resolution in the height direction. The resolution unit is given in ThumbnailResolutionUnit", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailPlanarConfig : AbsProperty<object>
    {
        public ThumbnailPlanarConfig() : base(20527, "ThumbnailPlanarConfig", "Whether pixel components in the thumbnail image are recorded in chunky or planar format. See also PlanarConfig", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailResolutionUnit : AbsProperty<object>
    {
        public ThumbnailResolutionUnit() : base(20528, "ThumbnailResolutionUnit", "Unit of measure for the horizontal resolution and the vertical resolution of the thumbnail image. See also ResolutionUnit", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailTransferFunction : AbsProperty<object>
    {
        public ThumbnailTransferFunction() : base(20529, "ThumbnailTransferFunction", "Tables that specify transfer functions for the thumbnail image. See also TransferFunction. Total number of 16-bit words required for the tables", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailSoftwareUsed : AbsProperty<object>
    {
        public ThumbnailSoftwareUsed() : base(20530, "ThumbnailSoftwareUsed", "Null-terminated character string that specifies the name and version of the software or firmware of the device usedto generate the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailDateTime : AbsProperty<object>
    {
        public ThumbnailDateTime() : base(20531, "ThumbnailDateTime", "Date and time the thumbnail image was created. See also DateTime", new List<PropertyType> { PropertyType.Ascii }, 20)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailArtist : AbsProperty<object>
    {
        public ThumbnailArtist() : base(20532, "ThumbnailArtist", "Null-terminated character string that specifies the name of the person who created the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailWhitePoint : AbsProperty<object>
    {
        public ThumbnailWhitePoint() : base(20533, "ThumbnailWhitePoint", "Chromaticity of the white point of the thumbnail image. See also WhitePoint", new List<PropertyType> { PropertyType.LongFractionArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailPrimaryChromaticities : AbsProperty<object>
    {
        public ThumbnailPrimaryChromaticities() : base(20534, "ThumbnailPrimaryChromaticities", "For each of the three primary colors in the thumbnail image, the chromaticity of that color. See also PrimaryChromaticities", new List<PropertyType> { PropertyType.LongFractionArray }, 6)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailYCbCrCoefficients : AbsProperty<object>
    {
        public ThumbnailYCbCrCoefficients() : base(20535, "ThumbnailYCbCrCoefficients", "Coefficients for transformation from RGB to YCbCr data for the thumbnail image. See also YCbCrCoefficients", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailYCbCrSubsampling : AbsProperty<object>
    {
        public ThumbnailYCbCrSubsampling() : base(20536, "ThumbnailYCbCrSubsampling", "Sampling ratio of chrominance components in relation to the luminance component for the thumbnail image. See also YCbCrSubsampling", new List<PropertyType> { PropertyType.UShortArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailYCbCrPositioning : AbsProperty<object>
    {
        public ThumbnailYCbCrPositioning() : base(20537, "ThumbnailYCbCrPositioning", "Position of chrominance components in relation to the luminance component for the thumbnail image. See also YCbCrPositioning", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailRefBlackWhite : AbsProperty<object>
    {
        public ThumbnailRefBlackWhite() : base(20538, "ThumbnailRefBlackWhite", "Reference black point value and reference white point value for the thumbnail image. See also REFBlackWhite", new List<PropertyType> { PropertyType.LongFractionArray }, 6)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ThumbnailCopyRight : AbsProperty<object>
    {
        public ThumbnailCopyRight() : base(20539, "ThumbnailCopyRight", "Null-terminated character string that contains copyright information for the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class LuminanceTable : AbsProperty<object>
    {
        public LuminanceTable() : base(20624, "LuminanceTable",
            "Luminance table. The luminance table and the chrominance table are used to control JPEG quality. A valid luminance orchrominance table has 64 entries of type PropertyTagTypeShort. If an image has either a luminance table or achrominance table, then it must have both tables.", new List<PropertyType> { PropertyType.UShortArray }, 64)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ChrominanceTable : AbsProperty<object>
    {
        public ChrominanceTable() : base(20625, "ChrominanceTable", "Chrominance table. The luminance table and the chrominance table are used to control JPEG quality. A valid luminanceor chrominance table has 64 entries of type PropertyTagTypeShort. If an image has either a luminance table or achrominance table, then it must have both tables.", new List<PropertyType> { PropertyType.UShortArray }, 64)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class FrameDelay : AbsProperty<object>
    {
        public FrameDelay() : base(20736, "FrameDelay", "Time delay, in hundredths of a second, between two frames in an animated GIF image.", new List<PropertyType> { PropertyType.LongArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class LoopCount : AbsProperty<object>
    {
        public LoopCount() : base(20737, "LoopCount", "For an animated GIF image, the number of times to display the animation. A value of 0 specifies that the animation ,should be displayed infinitely.", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class GlobalPalette : AbsProperty<object>
    {
        public GlobalPalette() : base(20738, "GlobalPalette", "Color palette for an indexed bitmap in a GIF image. Count is 3x no. of palette entries", new List<PropertyType> { PropertyType.Bytes }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class IndexBackground : AbsProperty<object>
    {
        public IndexBackground() : base(20739, "IndexBackground", "Index of the background color in the palette of a GIF image.", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class IndexTransparent : AbsProperty<object>
    {
        public IndexTransparent() : base(20740, "IndexTransparent", "Index of the transparent color in the palette of a GIF image.", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PixelUnit : AbsProperty<object>
    {
        public PixelUnit() : base(20752, "PixelUnit", "Unit for PropertyTagPixelPerUnitX and PropertyTagPixelPerUnitY. 0 - unknown", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PixelPerUnitX : AbsProperty<object>
    {
        public PixelPerUnitX() : base(20753, "PixelPerUnitX", "Pixels per unit in the x direction.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PixelPerUnitY : AbsProperty<object>
    {
        public PixelPerUnitY() : base(20754, "PixelPerUnitY", "Pixels per unit in the y direction.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class PaletteHistogram : AbsProperty<object>
    {
        public PaletteHistogram() : base(20755, "PaletteHistogram", "Palette histogram. Length of the histogram", new List<PropertyType> { PropertyType.Bytes }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class Copyright : AbsProperty<object>
    {
        public Copyright() : base(33432, "Copyright", "Null-terminated character string that contains copyright information.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifExposureTime : AbsProperty<object>
    {
        public ExifExposureTime() : base(33434, "ExifExposureTime", "Exposure time, measured in seconds.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFNumber : AbsProperty<object>
    {
        public ExifFNumber() : base(33437, "ExifFNumber", "F number.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifIFD : AbsProperty<object>
    {
        public ExifIFD() : base(34665, "ExifIFD", "Private tag used by GDI+. Not for public use. GDI+ uses this tag to locate Exif-specific information.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ICCProfile : AbsProperty<object>
    {
        public ICCProfile() : base(34675, "ICCProfile", "ICC profile embedded in the image.", new List<PropertyType> { PropertyType.Bytes }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifExposureProg : AbsProperty<object>
    {
        public ExifExposureProg() : base(34850, "ExifExposureProg", "Class of the program used by the camera to set exposure when the picture is taken. Default00 - not defined 1 - manual 2 - normal program 3 - aperture priority 4 - shutter priority 5 - creative program(biasedtoward depth of field) 6 - action program(biased toward fast shutter speed) 7 - portrait mode (for close - up photoswith the background out of focus) 8 - landscape mode (for landscape photos with the background in focus) 9 to 255 - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSpectralSense : AbsProperty<object>
    {
        public ExifSpectralSense() : base(34852, "ExifSpectralSense", "Null-terminated character string that specifies the spectral sensitivity of each channel of the camera used. Thestring is compatible with the standard developed by the ASTM Technical Committee.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class GpsIFD : AbsProperty<object>
    {
        public GpsIFD() : base(34853, "GpsIFD", "Offset to a block of GPS property items. Property items whose tags have the prefix PropertyTagGps are stored in theGPS block. The GPS property items are defined in the EXIF specification. GDI+ uses this tag to locate GPSinformation, but GDI+ does not expose this tag for public use.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifISOSpeed : AbsProperty<object>
    {
        public ExifISOSpeed() : base(34855, "ExifISOSpeed", "ISO speed and ISO latitude of the camera or input device as specified in ISO 12232.", new List<PropertyType> { PropertyType.UShortArray }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifOECF : AbsProperty<object>
    {
        public ExifOECF() : base(34856, "ExifOECF", "Optoelectronic conversion function (OECF) specified in ISO 14524. The OECF is the relationship between the cameraoptical input and the image values.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifVer : AbsProperty<object>
    {
        public ExifVer() : base(36864, "ExifVer", "Version of the EXIF standard supported. Nonexistence of this field is taken to mean nonconformance to the standard.Conformance to the standard is indicated by recording 0210 as a 4-byte ASCII string. Because the type isPropertyTagTypeUndefined, there is no NULL terminator. Default 0210", new List<PropertyType> { PropertyType.Undefined }, 4)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifDTOrig : AbsProperty<object>
    {
        public ExifDTOrig() : base(36867, "ExifDTOrig", "Date and time when the original image data was generated. For a DSC, the date and time when the picture was taken.The format is YYYY:MM:DD HH:MM:SS with time shown in 24-hour format and the date and time separated by one blankcharacter (0x2000). The character string length is 20 bytes including the NULL terminator. When the field is empty,it is treated as unknown.", new List<PropertyType> { PropertyType.Ascii }, 20)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifDTDigitized : AbsProperty<object>
    {
        public ExifDTDigitized() : base(36868, "ExifDTDigitized", "Date and time when the image was stored as digital data. If, for example, an image was captured by DSC and at thesame time the file was recorded, then DateTimeOriginal and DateTimeDigitized will have the same contents. The format is YYYY:MM:DD HH:MM:SS with time shown in 24-hour format and the date and time separated by one blankcharacter (0x2000). The character string length is 20 bytes including the NULL terminator. When the field is empty,it is treated as unknown.", new List<PropertyType> { PropertyType.Ascii }, 20)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifCompConfig : AbsProperty<object>
    {
        public ExifCompConfig() : base(37121, "ExifCompConfig", "Information specific to compressed data. The channels of each component are arranged in order from the firstcomponent to the fourth. For uncompressed data, the data arrangement is given in the PropertyTagPhotometricInterptag. However, because PropertyTagPhotometricInterp can only express the order of Y, Cb, and Cr, this tag is provided forcases when compressed data uses components other than Y, Cb, and Cr and to support other sequences. Default4 5 6 0(if RGB uncompressed) 1 2 3 0(other cases) 0 - does not exist 1 - Y 2 - Cb 3 - Cr 4 - R 5 - G 6 - B Other - reserved", new List<PropertyType> { PropertyType.Undefined }, 4)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifCompBPP : AbsProperty<object>
    {
        public ExifCompBPP() : base(37122, "ExifCompBPP", "Information specific to compressed data. The compression mode used for a compressed image is indicated in unit BPP.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifShutterSpeed : AbsProperty<object>
    {
        public ExifShutterSpeed() : base(37377, "ExifShutterSpeed", "Shutter speed. The unit is the Additive System of Photographic Exposure (APEX) value.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifAperture : AbsProperty<object>
    {
        public ExifAperture() : base(37378, "ExifAperture", "Lens aperture. The unit is the APEX value.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifBrightness : AbsProperty<object>
    {
        public ExifBrightness() : base(37379, "ExifBrightness", "Brightness value. The unit is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifExposureBias : AbsProperty<object>
    {
        public ExifExposureBias() : base(37380, "ExifExposureBias", "Exposure bias. The unit is the APEX value. Ordinarily it is given in the range -99.99 to 99.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifMaxAperture : AbsProperty<object>
    {
        public ExifMaxAperture() : base(37381, "ExifMaxAperture", "Smallest F number of the lens. The unit is the APEX value. Ordinarily it is given in the range of 00.00 to 99.99, butit is not limited to this range.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSubjectDist : AbsProperty<object>
    {
        public ExifSubjectDist() : base(37382, "ExifSubjectDist", "Distance to the subject, measured in meters.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifMeteringMode : AbsProperty<object>
    {
        public ExifMeteringMode() : base(37383, "ExifMeteringMode", "Metering mode. Default00 - unknown 1 - Average 2 - CenterWeightedAverage 3 - Spot 4 - MultiSpot 5 - Pattern 6 - Partial 7 to 254 - reserved255 - other", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifLightSource : AbsProperty<object>
    {
        public ExifLightSource() : base(37384, "ExifLightSource", "Type of light source. Default00 - unknown 1 - Daylight 2 - Flourescent 3 - Tungsten 17 - Standard Light A 18 - Standard Light B 19 - Standard LightC 20 - D55 21 - D65 22 - D75 23 to 254 - reserved 255 - other", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFlash : AbsProperty<object>
    {
        public ExifFlash() : base(37385, "ExifFlash", "Flash status. This tag is recorded when an image is taken using a strobe light (flash). Bit 0 indicates the flashfiring status, and bits 1 and 2 indicate the flash return status. Values for bit 0 that indicate whether the flash fired: 0b - flash did not fire 1 b - flash fired. Values for bits 1 and 2 that indicate the status of returned light: 00 b - no strobe\treturn detection function 01 b - reserved 10 b - strobe\treturn light not detected 11 b - strobe\treturn light detectedResulting flash tag values: 0x0000 - flash did not fire 0x0001 - flash fired 0x0005 - strobe return light notdetected ", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFocalLength : AbsProperty<object>
    {
        public ExifFocalLength() : base(37386, "ExifFocalLength", "Actual focal length, in millimeters, of the lens.Conversion is not made to the focal length of a 35 millimeter filmcamera.", new List<PropertyType> { PropertyType.Undefined }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifMakerNote : AbsProperty<object>
    {
        public ExifMakerNote() : base(37500, "ExifMakerNote", "Note tag.A tag used by manufacturers of EXIF writers to record information.The contents are up to the manufacturer.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifUserComment : AbsProperty<object>
    {
        public ExifUserComment() : base(37510, "ExifUserComment", "Comment tag.A tag used by EXIF users to write keywords or comments about the image besides those inPropertyTagImageDescription and without the character - code limitations of the PropertyTagImageDescription tag. The character code used in the PropertyTagExifUserComment tag is identified based on an ID code in a fixed 8 - bytearea at the start of the tag data area.The unused portion of the area is padded with null characters(0).ID codesare assigned by means of registration.Because the type is not ASCII, it is not necessary to use a NULL terminator.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifDTSubsec : AbsProperty<object>
    {
        public ExifDTSubsec() : base(37520, "ExifDTSubsec", "Null - terminated character string that specifies a fraction of a second for the PropertyTagDateTime tag.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifDTOrigSS : AbsProperty<object>
    {
        public ExifDTOrigSS() : base(37521, "ExifDTOrigSS", "Null - terminated character string that specifies a fraction of a second for the PropertyTagExifDTOrig tag.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifDTDigSS : AbsProperty<object>
    {
        public ExifDTDigSS() : base(37522, "ExifDTDigSS", "Null-terminated character string that specifies a fraction of a second for the PropertyTagExifDTDigitized tag.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFPXVer : AbsProperty<object>
    {
        public ExifFPXVer() : base(40960, "ExifFPXVer", "FlashPix format version supported by an FPXR file. If the FPXR function supports FlashPix format version 1.0, this isindicated similarly to PropertyTagExifVer by recording 0100 as a 4-byte ASCII string. Because the type isPropertyTagTypeUndefined, there is no NULL terminator. Default01000100 - FlashPix format version 1.0 Other - reserved", new List<PropertyType> { PropertyType.Undefined }, 4)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifColorSpace : AbsProperty<object>
    {
        public ExifColorSpace() : base(40961, "ExifColorSpace", "Color space specifier. Normally sRGB (=1) is used to define the color space based on the PC monitor conditions andenvironment. If a color space other than sRGB is used, Uncalibrated (=0xFFFF) is set. Image data recorded asUncalibrated can be treated as sRGB when it is converted to FlashPix. 0x1 - sRGB 0xFFFF - uncalibrated Other - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifPixXDim : AbsProperty<object>
    {
        public ExifPixXDim() : base(40962, "ExifPixXDim", "Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful imagemust be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist inan uncompressed file.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifPixYDim : AbsProperty<object>
    {
        public ExifPixYDim() : base(40963, "ExifPixYDim", "Information specific to compressed data. When a compressed file is recorded, the valid height of the meaningful imagemust be recorded in this tag whether or not there is padding data or a restart marker. This tag should not exist inan uncompressed file. Because data padding is unnecessary in the vertical direction, the number of lines recorded inthis valid image height tag will be the same as that recorded in the SOF.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifRelatedWav : AbsProperty<object>
    {
        public ExifRelatedWav() : base(40964, "ExifRelatedWav", "The name of an audio file related to the image data. The only relational information recorded is the EXIF audio filename and extension (an ASCII string that consists of 8 characters plus a period (.), plus 3 characters). The path isnot recorded. When you use this tag, audio files must be recorded in conformance with the EXIF audio format. Writerscan also store audio data within APP2 as FlashPix extension stream data.", new List<PropertyType> { PropertyType.Ascii }, 13)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifInterop : AbsProperty<object>
    {
        public ExifInterop() : base(40965, "ExifInterop", "Offset to a block of property items that contain interoperability information.", new List<PropertyType> { PropertyType.LongArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFlashEnergy : AbsProperty<object>
    {
        public ExifFlashEnergy() : base(41483, "ExifFlashEnergy", "Strobe energy, in Beam Candle Power Seconds (BCPS), at the time the image was captured.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSpatialFR : AbsProperty<object>
    {
        public ExifSpatialFR() : base(41484, "ExifSpatialFR", "Camera or input device spatial frequency table and SFR values in the image width, image height, and diagonaldirection, as specified in ISO 12233.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFocalXRes : AbsProperty<object>
    {
        public ExifFocalXRes() : base(41486, "ExifFocalXRes", "Number of pixels in the image width (x) direction per unit on the camera focal plane. The unit is specified inPropertyTagExifFocalResUnit.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFocalYRes : AbsProperty<object>
    {
        public ExifFocalYRes() : base(41487, "ExifFocalYRes", "Number of pixels in the image height (y) direction per unit on the camera focal plane. The unit is specified inPropertyTagExifFocalResUnit.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFocalResUnit : AbsProperty<object>
    {
        public ExifFocalResUnit() : base(41488, "ExifFocalResUnit", "Unit of measure for PropertyTagExifFocalXRes and PropertyTagExifFocalYRes. 2 - inch 3 - centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSubjectLoc : AbsProperty<object>
    {
        public ExifSubjectLoc() : base(41492, "ExifSubjectLoc", "Location of the main subject in the scene. The value of this tag represents the pixel at the center of the mainsubject relative to the left edge. The first value indicates the column number, and the second value indicates therow number.", new List<PropertyType> { PropertyType.UShortArray }, 2)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifExposureIndex : AbsProperty<object>
    {
        public ExifExposureIndex() : base(41493, "ExifExposureIndex", "Exposure index selected on the camera or input device at the time the image was captured.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSensingMethod : AbsProperty<object>
    {
        public ExifSensingMethod() : base(41495, "ExifSensingMethod", "Image sensor type on the camera or input device. 1 - not defined 2 - one - chip color area sensor 3 - two - chip color area sensor 4 - three - chip color area sensor 5 - color sequential area sensor 7 - trilinear sensor 8 - color sequential linear sensor Other - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifFileSource : AbsProperty<object>
    {
        public ExifFileSource() : base(41728, "ExifFileSource", "The image source. If a DSC recorded the image, the value of this tag is 3.", new List<PropertyType> { PropertyType.Undefined }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifSceneType : AbsProperty<object>
    {
        public ExifSceneType() : base(41729, "ExifSceneType", "The type of scene. If a DSC recorded the image, the value of this tag must be set to 1, indicating that the image was, directly photographed.", new List<PropertyType> { PropertyType.Undefined }, 1)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }

    public class ExifCfaPattern : AbsProperty<object>
    {
        public ExifCfaPattern() : base(41730, "ExifCfaPattern",
            "The color filter array(CFA) geometric pattern of the image sensor when a one - chip color area sensor is used. It doesnot apply to all sensing methods.", new List<PropertyType> { PropertyType.Undefined }, 0)
        {
        }
        protected override object Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return null;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(object value, PropertyItem pi)
        {
        }
    }






















































    //public Property<> GpsVer = new Property<>(0, "GpsVer", "Version of the Global Positioning Systems (GPS) IFD, given as 2.0.0.0. This tag is mandatory when the PropertyTagGpsIFD tag is present. When the version is 2.0.0.0, the tag value is 0x02000000", new List<PropertyType> { PropertyType.Bytes }, 4);
    //public Property<> GpsLatitudeRef = new Property<>(1, "GpsLatitudeRef", "Null-terminated character string that specifies whether the latitude is north or south. N specifies north latitude, and S specifies south latitude", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsLatitude = new Property<>(2, "GpsLatitude", "Latitude. Latitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes, and seconds are expressed, the format is dd/1, mm/1, ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1, mmmm/100, 0/1", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> GpsLongitudeRef = new Property<>(3, "GpsLongitudeRef", "Null-terminated character string that specifies whether the longitude is east or west longitude. E specifies east longitude, and W specifies west longitude", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsLongitude = new Property<>(4, "GpsLongitude", "Longitude. Longitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes and seconds are expressed, the format is ddd/1, mm/1, ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1, mmmm/100, 0/1", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> GpsAltitudeRef = new Property<>(5, "GpsAltitudeRef", "Reference altitude, in meters.", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> GpsAltitude = new Property<>(6, "GpsAltitude", "Altitude, in meters, based on the reference altitude specified by PropertyTagGpsAltitudeRef.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsGpsTime = new Property<>(7, "GpsGpsTime", "Time as Coordinated Universal Time (UTC). The value is expressed as three rational numbers that give the hour,minute, and second.", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> GpsGpsSatellites = new Property<>(8, "GpsGpsSatellites", "Null-terminated character string that specifies the GPS satellites used for measurements. This tag can be used tospecify the ID number, angle of elevation, azimuth, SNR, and other information about each satellite. The format isnot specified. If the GPS receiver is incapable of taking measurements, the value of the tag must be set to NULL.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> GpsGpsStatus = new Property<>(9, "GpsGpsStatus", "Null-terminated character string that specifies the status of the GPS receiver when the image is recorded.A means measurement is in progress, and V means the measurement is Interoperability.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsGpsMeasureMode = new Property<>(10, "GpsGpsMeasureMode", "Null-terminated character string that specifies the GPS measurement mode. 2 specifies 2-D measurement,and 3 specifies 3-D measurement.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsGpsDop = new Property<>(11, "GpsGpsDop", "GPS DOP (data degree of precision). An HDOP value is written during 2-D measurement, and a PDOP value is writtenduring 3-D measurement.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsSpeedRef = new Property<>(12, "GpsSpeedRef", "Null-terminated character string that specifies the unit used to express the GPS receiver speed of movement.K, M, and N represent kilometers per hour, miles per hour, and knots respectively.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsSpeed = new Property<>(13, "GpsSpeed", "Speed of the GPS receiver movement.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsTrackRef = new Property<>(14, "GpsTrackRef", "Null-terminated character string that specifies the reference for giving the direction of GPS receiver movement.T specifies true direction, and M specifies magnetic direction.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsTrack = new Property<>(15, "GpsTrack", "Direction of GPS receiver movement. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsImgDirRef = new Property<>(16, "GpsImgDirRef", "Null-terminated character string that specifies the reference for the direction of the image when it is captured.T specifies true direction, and M specifies magnetic direction.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsImgDir = new Property<>(17, "GpsImgDir", "Direction of the image when it was captured. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsMapDatum = new Property<>(18, "GpsMapDatum", "Null-terminated character string that specifies geodetic survey data used by the GPS receiver. If the survey data isrestricted to Japan, the value of this tag is TOKYO or WGS-84.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> GpsDestLatRef = new Property<>(19, "GpsDestLatRef", "Null-terminated character string that specifies whether the latitude of the destination point is north or southlatitude. N specifies north latitude, and S specifies south latitude.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsDestLat = new Property<>(20, "GpsDestLat", "Latitude of the destination point. The latitude is expressed as three rational values giving the degrees, minutes,and seconds respectively. When degrees, minutes, and seconds are expressed, the format is dd/1, mm/1, ss/1. Whendegrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the formatis dd/1, mmmm/100, 0/1.", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> GpsDestLongRef = new Property<>(21, "GpsDestLongRef", "Null-terminated character string that specifies whether the longitude of the destination point is east or westlongitude. E specifies east longitude, and W specifies west longitude.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsDestLong = new Property<>(22, "GpsDestLong", "Longitude of the destination point. The longitude is expressed as three rational values giving the degrees, minutes,and seconds respectively. When degrees, minutes, and seconds are expressed, the format is ddd/1, mm/1, ss/1. Whendegrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the formatis ddd/1, mmmm/100, 0/1.", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> GpsDestBearRef = new Property<>(23, "GpsDestBearRef", "Null-terminated character string that specifies the reference used for giving the bearing to the destination point.T specifies true direction, and M specifies magnetic direction.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsDestBear = new Property<>(24, "GpsDestBear", "Bearing to the destination point. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> GpsDestDistRef = new Property<>(25, "GpsDestDistRef", "Null-terminated character string that specifies the unit used to express the distance to the destination point. K, M,and N represent kilometers, miles, and knots respectively.", new List<PropertyType> { PropertyType.Ascii }, 2);
    //public Property<> GpsDestDist = new Property<>(26, "GpsDestDist", "Distance to the destination point.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> NewSubfileType = new Property<>(254, "NewSubfileType", "Type of data in a subfile.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> SubfileType = new Property<>(255, "SubfileType", "Type of data in a subfile.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ImageWidth = new Property<>(256, "ImageWidth", "Number of pixels per row.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ImageHeight = new Property<>(257, "ImageHeight", "Number of pixel rows.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> BitsPerSample = new Property<>(258, "BitsPerSample", "Number of bits per color component. See also SamplesPerPixel.", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> Compression = new Property<>(259, "Compression", "Compression scheme used for the image data.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> PhotometricInterp = new Property<>(262, "PhotometricInterp", "How pixel data will be interpreted.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThreshHolding = new Property<>(263, "ThreshHolding", "Technique used to convert from gray pixels to black and white pixels.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> CellWidth = new Property<>(264, "CellWidth", "Width of the dithering or halftoning matrix.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> CellHeight = new Property<>(265, "CellHeight", "Height of the dithering or halftoning matrix.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> FillOrder = new Property<>(266, "FillOrder", "Logical order of bits in a byte.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> DocumentName = new Property<>(269, "DocumentName", "Null-terminated character string that specifies the name of the document from which the image was scanned.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ImageDescription = new Property<>(270, "ImageDescription", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> EquipMake = new Property<>(271, "EquipMake", "Null-terminated character string that specifies the manufacturer of the equipment used to record the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> EquipModel = new Property<>(272, "EquipModel", "Null-terminated character string that specifies the model name or model number of the equipment used to record the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> StripOffsets = new Property<>(273, "StripOffsets", "For each strip, the byte offset of that strip. See also RowsPerStrip and StripBytesCount", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0);
    //public Property<> Orientation = new Property<>(274, "Orientation", "Image orientation viewed in terms of rows and columns. 1 - The 0th row is at the top of the visual image, and the 0th column is the visual left side. 2 - The 0th row is atthe visual top of the image, and the 0th column is the visual right side. 3 - The 0th row is at the visual bottom ofthe image, and the 0th column is the visual right side. 4 - The 0th row is at the visual bottom of the image, andthe 0th column is the visual left side. 5 - The 0th row is the visual left side of the image, and the 0th column isthe visual top. 6 - The 0th row is the visual right side of the image, and the 0th column is the visual top. 7 - The0th row is the visual right side of the image, and the 0th column is the visual bottom. 8 - The 0th row is thevisual left side of the image, and the 0th column is the visual bottom.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> SamplesPerPixel = new Property<>(277, "SamplesPerPixel", "Number of color components per pixel.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> RowsPerStrip = new Property<>(278, "RowsPerStrip", "Number of rows per strip. See also StripBytesCount and StripOffsets", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> StripBytesCount = new Property<>(279, "StripBytesCount", "For each strip, the total number of bytes in that strip.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0);
    //public Property<> MinSampleValue = new Property<>(280, "MinSampleValue", "For each color component, the minimum value assigned to that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> MaxSampleValue = new Property<>(281, "MaxSampleValue", "For each color component, the maximum value assigned to that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> XResolution = new Property<>(282, "XResolution", "Number of pixels per unit in the image width (x) direction. The unit is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> YResolution = new Property<>(283, "YResolution", "Number of pixels per unit in the image height (y) direction. The unit is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> PlanarConfig = new Property<>(284, "PlanarConfig", "Whether pixel components are recorded in chunky or planar format.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> PageName = new Property<>(285, "PageName", "Null-terminated character string that specifies the name of the page from which the image was scanned.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> XPosition = new Property<>(286, "XPosition", "Offset from the left side of the page to the left side of the image. The unit of measure is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> YPosition = new Property<>(287, "YPosition", "Offset from the top of the page to the top of the image. The unit of measure is specified by ResolutionUnit", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> FreeOffset = new Property<>(288, "FreeOffset", "For each string of contiguous unused bytes, the byte offset of that string.", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> FreeByteCounts = new Property<>(289, "FreeByteCounts", "For each string of contiguous unused bytes, the number of bytes in that string.", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> GrayResponseUnit = new Property<>(290, "GrayResponseUnit", "Precision of the number specified by PropertyTagGrayResponseCurve. 1 specifies tenths, 2 specifies hundredths, 3specifies thousandths, and so on.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> GrayResponseCurve = new Property<>(291, "GrayResponseCurve", "For each possible pixel value in a grayscale image, the optical density of that pixel value.", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> T4Option = new Property<>(292, "T4Option", "Set of flags that relate to T4 encoding.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> T6Option = new Property<>(293, "T6Option", "Set of flags that relate to T6 encoding.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ResolutionUnit = new Property<>(296, "ResolutionUnit", "Unit of measure for the horizontal resolution and the vertical resolution. 2 - inch 3 - centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> PageNumber = new Property<>(297, "PageNumber", "Page number of the page from which the image was scanned.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> TransferFunction = new Property<>(301, "TransferFunction", "Tables that specify transfer functions for the image. Total number of 16-bit words required for the tables", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> SoftwareUsed = new Property<>(305, "SoftwareUsed", "Null-terminated character string that specifies the name and version of the software or firmware of the device usedto generate the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> DateTime = new Property<>(306, "DateTime", "Date and time the image was created.", new List<PropertyType> { PropertyType.Ascii }, 20);
    //public Property<> Artist = new Property<>(315, "Artist", "Null-terminated character string that specifies the name of the person who created the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> HostComputer = new Property<>(316, "HostComputer", "Null-terminated character string that specifies the computer and/or operating system used to create the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> Predictor = new Property<>(317, "Predictor", "Type of prediction scheme that was applied to the image data before the encoding scheme was applied.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> WhitePoint = new Property<>(318, "WhitePoint", "Chromaticity of the white point of the image.", new List<PropertyType> { PropertyType.LongFractionArray }, 2);
    //public Property<> PrimaryChromaticities = new Property<>(319, "PrimaryChromaticities", "For each of the three primary colors in the image, the chromaticity of that color.", new List<PropertyType> { PropertyType.LongFractionArray }, 6);
    //public Property<> ColorMap = new Property<>(320, "ColorMap", "Color palette (lookup table) for a palette-indexed image.", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> HalftoneHints = new Property<>(321, "HalftoneHints", "Information used by the halftone function", new List<PropertyType> { PropertyType.UShortArray }, 2);
    //public Property<> TileWidth = new Property<>(322, "TileWidth", "Number of pixel columns in each tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> TileLength = new Property<>(323, "TileLength", "Number of pixel rows in each tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> TileOffset = new Property<>(324, "TileOffset", "For each tile, the byte offset of that tile.", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> TileByteCounts = new Property<>(325, "TileByteCounts", "For each tile, the number of bytes in that tile.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0);
    //public Property<> InkSet = new Property<>(332, "InkSet", "Set of inks used in a separated image.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> InkNames = new Property<>(333, "InkNames", "Sequence of concatenated, null-terminated, character strings that specify the names of the inks used in a separated image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> NumberOfInks = new Property<>(334, "NumberOfInks", "Number of inks.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> DotRange = new Property<>(336, "DotRange", "Color component values that correspond to a 0 percent dot and a 100 percent dot. 2 or 2 � SamplesPerPixel", new List<PropertyType> { PropertyType.Bytes, PropertyType.UShortArray }, 0);
    //public Property<> TargetPrinter = new Property<>(337, "TargetPrinter", "Null-terminated character string that describes the intended printing environment.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ExtraSamples = new Property<>(338, "ExtraSamples", "Number of extra color components. For example, one extra component might hold an alpha value.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> SampleFormat = new Property<>(339, "SampleFormat", "For each color component, the numerical format (unsigned, signed, floating point) of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> SMinSampleValue = new Property<>(340, "SMinSampleValue", "For each color component, the minimum value of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> SMaxSampleValue = new Property<>(341, "SMaxSampleValue", "For each color component, the maximum value of that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> TransferRange = new Property<>(342, "TransferRange", "Table of values that extends the range of the transfer function.", new List<PropertyType> { PropertyType.UShortArray }, 6);
    //public Property<> JPEGProc = new Property<>(512, "JPEGProc", "JPEG compression process.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> JPEGInterFormat = new Property<>(513, "JPEGInterFormat", "Offset to the start of a JPEG bitstream.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> JPEGInterLength = new Property<>(514, "JPEGInterLength", "Length, in bytes, of the JPEG bitstream.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> JPEGRestartInterval = new Property<>(515, "JPEGRestartInterval", "Length of the restart interval.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> JPEGLosslessPredictors = new Property<>(517, "JPEGLosslessPredictors", "For each color component, a lossless predictor-selection value for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> JPEGPointTransforms = new Property<>(518, "JPEGPointTransforms", "For each color component, a point transformation value for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> JPEGQTables = new Property<>(519, "JPEGQTables", "For each color component, the offset to the quantization table for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> JPEGDCTables = new Property<>(520, "JPEGDCTables", "For each color component, the offset to the DC Huffman table (or lossless Huffman table) for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> JPEGACTables = new Property<>(521, "JPEGACTables", "For each color component, the offset to the AC Huffman table for that component. See also SamplesPerPixel", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> YCbCrCoefficients = new Property<>(529, "YCbCrCoefficients", "Coefficients for transformation from RGB to YCbCr image data.", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> YCbCrSubsampling = new Property<>(530, "YCbCrSubsampling", "Sampling ratio of chrominance components in relation to the luminance component.", new List<PropertyType> { PropertyType.UShortArray }, 2);
    //public Property<> YCbCrPositioning = new Property<>(531, "YCbCrPositioning", "Position of chrominance components in relation to the luminance component.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> REFBlackWhite = new Property<>(532, "REFBlackWhite", "Reference black point value and reference white point value.", new List<PropertyType> { PropertyType.LongFractionArray }, 6);
    //public Property<> Gamma = new Property<>(769, "Gamma", "Gamma value attached to the image. The gamma value is stored as a rational number (pair of long) with a numerator of 100000. For example, a gamma value of 2.2 is stored as the pair (100000, 45455).", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ICCProfileDescriptor = new Property<>(770, "ICCProfileDescriptor", "Null-terminated character string that identifies an ICC profile.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> SRGBRenderingIntent = new Property<>(771, "SRGBRenderingIntent", "How the image should be displayed as defined by the International Color Consortium (ICC). If a GDI+ object is constructed with theuseEmbeddedColorManagement parameter set to TRUE, then GDI+ renders the image according to the specified rendering intent. The intent can be set to perceptual, relative colorimetric, saturation, or absolutecolorimetric. Perceptual intent, which is suitable for photographs,\tgives good adaptation to the display device gamut at theexpense of colorimetric accuracy.Relative colorimetric intent is suitable for images (for example, logos) that require color appearance matchingthat is relative to the display device white point.Saturation intent, which is suitable for charts and graphs, preserves saturation at the expense of hue andlightness.Absolute colorimetric intent is suitable for proofs(previews of images destined for a different display device) that require preservation of absolute colorimetry. Perceptual intent, which is suitable for photographs, gives good adaptation to the display device gamut at theexpense of colorimetric accuracy.Relative colorimetric intent is suitable for images (for example, logos) that require color appearance matchingthat is relative to the display device white point.Saturation intent, which is suitable for charts and graphs, preserves saturation at the expense of hue andlightness.Absolute colorimetric intent is suitable for proofs(previews of images destined for a different display device) that require preservation of absolute colorimetry.", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> ImageTitle = new Property<>(800, "ImageTitle", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ResolutionXUnit = new Property<>(20481, "ResolutionXUnit", "Units in which to display horizontal resolution. 1 - pixels per inch 2 - pixels per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ResolutionYUnit = new Property<>(20482, "ResolutionYUnit", "Units in which to display vertical resolution. 1 - pixels per inch 2 - pixels per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ResolutionXLengthUnit = new Property<>(20483, "ResolutionXLengthUnit", "Units in which to display the image width. 1 - inches 2 - centimeters 3 - points 4 - picas 5 - columns", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ResolutionYLengthUnit = new Property<>(20484, "ResolutionYLengthUnit", "Units in which to display the image height. 1 - inches 2 - centimeters 3 - points 4 - picas 5 - columns", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> PrintFlags = new Property<>(20485, "PrintFlags", "Sequence of one-byte Boolean values that specify printing options.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> PrintFlagsVersion = new Property<>(20486, "PrintFlagsVersion", "Print flags version.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> PrintFlagsCrop = new Property<>(20487, "PrintFlagsCrop", "Print flags center crop marks.", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> PrintFlagsBleedWidth = new Property<>(20488, "PrintFlagsBleedWidth", "Print flags bleed width.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> PrintFlagsBleedWidthScale = new Property<>(20489, "PrintFlagsBleedWidthScale", "Print flags bleed width scale.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> HalftoneLPI = new Property<>(20490, "HalftoneLPI", "Ink's screen frequency, in lines per inch.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> HalftoneLPIUnit = new Property<>(20491, "HalftoneLPIUnit", "Units for the screen frequency. 1 - lines per inch 2 - lines per centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> HalftoneDegree = new Property<>(20492, "HalftoneDegree", "Angle for screen.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> HalftoneShape = new Property<>(20493, "HalftoneShape", "Shape of the halftone dots. 0 - round 1 - ellipse 2 - line 3 - square 4 - cross 6 - diamond", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> HalftoneMisc = new Property<>(20494, "HalftoneMisc", "Miscellaneous halftone information.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> HalftoneScreen = new Property<>(20495, "HalftoneScreen", "Boolean value that specifies whether to use the printer's default screens. 1 - use printer 's default screens 2 - other", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> JPEGQuality = new Property<>(20496, "JPEGQuality", "Private tag used by the Adobe Photoshop format. Not for public use.", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> GridSize = new Property<>(20497, "GridSize", "Block of information about grids and guides.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ThumbnailFormat = new Property<>(20498, "ThumbnailFormat", "Format of the thumbnail image. 0 - raw RGB 1 - JPEG", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ThumbnailWidth = new Property<>(20499, "ThumbnailWidth", "Width, in pixels, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ThumbnailHeight = new Property<>(20500, "ThumbnailHeight", "Height, in pixels, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ThumbnailColorDepth = new Property<>(20501, "ThumbnailColorDepth", "bits per pixel (BPP) for the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailPlanes = new Property<>(20502, "ThumbnailPlanes", "Number of color planes for the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailRawBytes = new Property<>(20503, "ThumbnailRawBytes", "Byte offset between rows of pixel data.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ThumbnailSize = new Property<>(20504, "ThumbnailSize", "Total size, in bytes, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ThumbnailCompressedSize = new Property<>(20505, "ThumbnailCompressedSize", "Compressed size, in bytes, of the thumbnail image.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ColorTransferFunction = new Property<>(20506, "ColorTransferFunction", "Table of values that specify color transfer functions.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ThumbnailData = new Property<>(20507, "ThumbnailData", "Raw thumbnail bits in JPEG or RGB format. Depends on PropertyTagThumbnailFormat.", new List<PropertyType> { PropertyType.Bytes }, 0);
    //public Property<> ThumbnailImageWidth = new Property<>(20512, "ThumbnailImageWidth", "Number of pixels per row in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ThumbnailImageHeight = new Property<>(20513, "ThumbnailImageHeight", "Number of pixel rows in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ThumbnailBitsPerSample = new Property<>(20514, "ThumbnailBitsPerSample", "Number of bits per color component in the thumbnail image. See also ThumbnailSamplesPerPixel", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> ThumbnailCompression = new Property<>(20515, "ThumbnailCompression", "Compression scheme used for thumbnail image data.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailPhotometricInterp = new Property<>(20516, "ThumbnailPhotometricInterp", "How thumbnail pixel data will be interpreted.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailImageDescription = new Property<>(20517, "ThumbnailImageDescription", "Null-terminated character string that specifies the title of the image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ThumbnailEquipMake = new Property<>(20518, "ThumbnailEquipMake", "Null-terminated character string that specifies the manufacturer of the equipment used to record the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ThumbnailEquipModel = new Property<>(20519, "ThumbnailEquipModel", "Null-terminated character string that specifies the model name or model number of the equipment used to record thethumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ThumbnailStripOffsets = new Property<>(20520, "ThumbnailStripOffsets", "For each strip in the thumbnail image, the byte offset of that strip. See also ThumbnailRowsPerStrip and PropertyTagThumbnailStripBytesCount", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0);
    //public Property<> ThumbnailOrientation = new Property<>(20521, "ThumbnailOrientation", "Thumbnail image orientation in terms of rows and columns. See also Orientation", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailSamplesPerPixel = new Property<>(20522, "ThumbnailSamplesPerPixel", "Number of color components per pixel in the thumbnail image.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailRowsPerStrip = new Property<>(20523, "ThumbnailRowsPerStrip", "Number of rows per strip in the thumbnail image. See also ThumbnailStripBytesCount and ThumbnailStripOffsets", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ThumbnailStripBytesCount = new Property<>(20524, "ThumbnailStripBytesCount", "For each thumbnail image strip, the total number of bytes in that strip.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 0);
    //public Property<> ThumbnailResolutionX = new Property<>(20525, "ThumbnailResolutionX", "Thumbnail resolution in the width direction. The resolution unit is given in ThumbnailResolutionUnit", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ThumbnailResolutionY = new Property<>(20526, "ThumbnailResolutionY", "Thumbnail resolution in the height direction. The resolution unit is given in ThumbnailResolutionUnit", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ThumbnailPlanarConfig = new Property<>(20527, "ThumbnailPlanarConfig", "Whether pixel components in the thumbnail image are recorded in chunky or planar format. See also PlanarConfig", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailResolutionUnit = new Property<>(20528, "ThumbnailResolutionUnit", "Unit of measure for the horizontal resolution and the vertical resolution of the thumbnail image. See also ResolutionUnit", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailTransferFunction = new Property<>(20529, "ThumbnailTransferFunction", "Tables that specify transfer functions for the thumbnail image. See also TransferFunction. Total number of 16-bit words required for the tables", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> ThumbnailSoftwareUsed = new Property<>(20530, "ThumbnailSoftwareUsed", "Null-terminated character string that specifies the name and version of the software or firmware of the device usedto generate the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ThumbnailDateTime = new Property<>(20531, "ThumbnailDateTime", "Date and time the thumbnail image was created. See also DateTime", new List<PropertyType> { PropertyType.Ascii }, 20);
    //public Property<> ThumbnailArtist = new Property<>(20532, "ThumbnailArtist", "Null-terminated character string that specifies the name of the person who created the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ThumbnailWhitePoint = new Property<>(20533, "ThumbnailWhitePoint", "Chromaticity of the white point of the thumbnail image. See also WhitePoint", new List<PropertyType> { PropertyType.LongFractionArray }, 2);
    //public Property<> ThumbnailPrimaryChromaticities = new Property<>(20534, "ThumbnailPrimaryChromaticities", "For each of the three primary colors in the thumbnail image, the chromaticity of that color. See also PrimaryChromaticities", new List<PropertyType> { PropertyType.LongFractionArray }, 6);
    //public Property<> ThumbnailYCbCrCoefficients = new Property<>(20535, "ThumbnailYCbCrCoefficients", "Coefficients for transformation from RGB to YCbCr data for the thumbnail image. See also YCbCrCoefficients", new List<PropertyType> { PropertyType.LongFractionArray }, 3);
    //public Property<> ThumbnailYCbCrSubsampling = new Property<>(20536, "ThumbnailYCbCrSubsampling", "Sampling ratio of chrominance components in relation to the luminance component for the thumbnail image. See also YCbCrSubsampling", new List<PropertyType> { PropertyType.UShortArray }, 2);
    //public Property<> ThumbnailYCbCrPositioning = new Property<>(20537, "ThumbnailYCbCrPositioning", "Position of chrominance components in relation to the luminance component for the thumbnail image. See also YCbCrPositioning", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ThumbnailRefBlackWhite = new Property<>(20538, "ThumbnailRefBlackWhite", "Reference black point value and reference white point value for the thumbnail image. See also REFBlackWhite", new List<PropertyType> { PropertyType.LongFractionArray }, 6);
    //public Property<> ThumbnailCopyRight = new Property<>(20539, "ThumbnailCopyRight", "Null-terminated character string that contains copyright information for the thumbnail image.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> LuminanceTable = new Property<>(20624, "LuminanceTable", "Luminance table. The luminance table and the chrominance table are used to control JPEG quality. A valid luminance orchrominance table has 64 entries of type PropertyTagTypeShort. If an image has either a luminance table or achrominance table, then it must have both tables.", new List<PropertyType> { PropertyType.UShortArray }, 64);
    //public Property<> ChrominanceTable = new Property<>(20625, "ChrominanceTable", "Chrominance table. The luminance table and the chrominance table are used to control JPEG quality. A valid luminanceor chrominance table has 64 entries of type PropertyTagTypeShort. If an image has either a luminance table or achrominance table, then it must have both tables.", new List<PropertyType> { PropertyType.UShortArray }, 64);
    //public Property<> FrameDelay = new Property<>(20736, "FrameDelay", "Time delay, in hundredths of a second, between two frames in an animated GIF image.", new List<PropertyType> { PropertyType.LongArray }, 0);
    //public Property<> LoopCount = new Property<>(20737, "LoopCount", "For an animated GIF image, the number of times to display the animation. A value of 0 specifies that the animation ,should be displayed infinitely.", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> GlobalPalette = new Property<>(20738, "GlobalPalette", "Color palette for an indexed bitmap in a GIF image. Count is 3x no. of palette entries", new List<PropertyType> { PropertyType.Bytes }, 0);
    //public Property<> IndexBackground = new Property<>(20739, "IndexBackground", "Index of the background color in the palette of a GIF image.", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> IndexTransparent = new Property<>(20740, "IndexTransparent", "Index of the transparent color in the palette of a GIF image.", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> PixelUnit = new Property<>(20752, "PixelUnit", "Unit for PropertyTagPixelPerUnitX and PropertyTagPixelPerUnitY. 0 - unknown", new List<PropertyType> { PropertyType.Bytes }, 1);
    //public Property<> PixelPerUnitX = new Property<>(20753, "PixelPerUnitX", "Pixels per unit in the x direction.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> PixelPerUnitY = new Property<>(20754, "PixelPerUnitY", "Pixels per unit in the y direction.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> PaletteHistogram = new Property<>(20755, "PaletteHistogram", "Palette histogram. Length of the histogram", new List<PropertyType> { PropertyType.Bytes }, 0);
    //public Property<> Copyright = new Property<>(33432, "Copyright", "Null-terminated character string that contains copyright information.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ExifExposureTime = new Property<>(33434, "ExifExposureTime", "Exposure time, measured in seconds.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifFNumber = new Property<>(33437, "ExifFNumber", "F number.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifIFD = new Property<>(34665, "ExifIFD", "Private tag used by GDI+. Not for public use. GDI+ uses this tag to locate Exif-specific information.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ICCProfile = new Property<>(34675, "ICCProfile", "ICC profile embedded in the image.", new List<PropertyType> { PropertyType.Bytes }, 0);
    //public Property<> ExifExposureProg = new Property<>(34850, "ExifExposureProg", "Class of the program used by the camera to set exposure when the picture is taken. Default00 - not defined 1 - manual 2 - normal program 3 - aperture priority 4 - shutter priority 5 - creative program(biasedtoward depth of field) 6 - action program(biased toward fast shutter speed) 7 - portrait mode (for close - up photoswith the background out of focus) 8 - landscape mode (for landscape photos with the background in focus) 9 to 255 - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifSpectralSense = new Property<>(34852, "ExifSpectralSense", "Null-terminated character string that specifies the spectral sensitivity of each channel of the camera used. Thestring is compatible with the standard developed by the ASTM Technical Committee.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> GpsIFD = new Property<>(34853, "GpsIFD", "Offset to a block of GPS property items. Property items whose tags have the prefix PropertyTagGps are stored in theGPS block. The GPS property items are defined in the EXIF specification. GDI+ uses this tag to locate GPSinformation, but GDI+ does not expose this tag for public use.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ExifISOSpeed = new Property<>(34855, "ExifISOSpeed", "ISO speed and ISO latitude of the camera or input device as specified in ISO 12232.", new List<PropertyType> { PropertyType.UShortArray }, 0);
    //public Property<> ExifOECF = new Property<>(34856, "ExifOECF", "Optoelectronic conversion function (OECF) specified in ISO 14524. The OECF is the relationship between the cameraoptical input and the image values.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ExifVer = new Property<>(36864, "ExifVer", "Version of the EXIF standard supported. Nonexistence of this field is taken to mean nonconformance to the standard.Conformance to the standard is indicated by recording 0210 as a 4-byte ASCII string. Because the type isPropertyTagTypeUndefined, there is no NULL terminator. Default 0210", new List<PropertyType> { PropertyType.Undefined }, 4);
    //public Property<> ExifDTOrig = new Property<>(36867, "ExifDTOrig", "Date and time when the original image data was generated. For a DSC, the date and time when the picture was taken.The format is YYYY:MM:DD HH:MM:SS with time shown in 24-hour format and the date and time separated by one blankcharacter (0x2000). The character string length is 20 bytes including the NULL terminator. When the field is empty,it is treated as unknown.", new List<PropertyType> { PropertyType.Ascii }, 20);
    //public Property<> ExifDTDigitized = new Property<>(36868, "ExifDTDigitized", "Date and time when the image was stored as digital data. If, for example, an image was captured by DSC and at thesame time the file was recorded, then DateTimeOriginal and DateTimeDigitized will have the same contents. The format is YYYY:MM:DD HH:MM:SS with time shown in 24-hour format and the date and time separated by one blankcharacter (0x2000). The character string length is 20 bytes including the NULL terminator. When the field is empty,it is treated as unknown.", new List<PropertyType> { PropertyType.Ascii }, 20);
    //public Property<> ExifCompConfig = new Property<>(37121, "ExifCompConfig", "Information specific to compressed data. The channels of each component are arranged in order from the firstcomponent to the fourth. For uncompressed data, the data arrangement is given in the PropertyTagPhotometricInterptag. However, because PropertyTagPhotometricInterp can only express the order of Y, Cb, and Cr, this tag is provided forcases when compressed data uses components other than Y, Cb, and Cr and to support other sequences. Default4 5 6 0(if RGB uncompressed) 1 2 3 0(other cases) 0 - does not exist 1 - Y 2 - Cb 3 - Cr 4 - R 5 - G 6 - B Other - reserved", new List<PropertyType> { PropertyType.Undefined }, 4);
    //public Property<> ExifCompBPP = new Property<>(37122, "ExifCompBPP", "Information specific to compressed data. The compression mode used for a compressed image is indicated in unit BPP.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifShutterSpeed = new Property<>(37377, "ExifShutterSpeed", "Shutter speed. The unit is the Additive System of Photographic Exposure (APEX) value.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifAperture = new Property<>(37378, "ExifAperture", "Lens aperture. The unit is the APEX value.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifBrightness = new Property<>(37379, "ExifBrightness", "Brightness value. The unit is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifExposureBias = new Property<>(37380, "ExifExposureBias", "Exposure bias. The unit is the APEX value. Ordinarily it is given in the range -99.99 to 99.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifMaxAperture = new Property<>(37381, "ExifMaxAperture", "Smallest F number of the lens. The unit is the APEX value. Ordinarily it is given in the range of 00.00 to 99.99, butit is not limited to this range.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifSubjectDist = new Property<>(37382, "ExifSubjectDist", "Distance to the subject, measured in meters.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifMeteringMode = new Property<>(37383, "ExifMeteringMode", "Metering mode. Default00 - unknown 1 - Average 2 - CenterWeightedAverage 3 - Spot 4 - MultiSpot 5 - Pattern 6 - Partial 7 to 254 - reserved255 - other", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifLightSource = new Property<>(37384, "ExifLightSource", "Type of light source. Default00 - unknown 1 - Daylight 2 - Flourescent 3 - Tungsten 17 - Standard Light A 18 - Standard Light B 19 - Standard LightC 20 - D55 21 - D65 22 - D75 23 to 254 - reserved 255 - other", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifFlash = new Property<>(37385, "ExifFlash", "Flash status. This tag is recorded when an image is taken using a strobe light (flash). Bit 0 indicates the flashfiring status, and bits 1 and 2 indicate the flash return status. Values for bit 0 that indicate whether the flash fired: 0b - flash did not fire 1 b - flash fired. Values for bits 1 and 2 that indicate the status of returned light: 00 b - no strobe\treturn detection function 01 b - reserved 10 b - strobe\treturn light not detected 11 b - strobe\treturn light detectedResulting flash tag values: 0x0000 - flash did not fire 0x0001 - flash fired 0x0005 - strobe return light notdetected ", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifFocalLength = new Property<>(37386, "ExifFocalLength", "Actual focal length, in millimeters, of the lens.Conversion is not made to the focal length of a 35 millimeter filmcamera.", new List<PropertyType> { PropertyType.Undefined }, 1);
    //public Property<> ExifMakerNote = new Property<>(37500, "ExifMakerNote", "Note tag.A tag used by manufacturers of EXIF writers to record information.The contents are up to the manufacturer.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ExifUserComment = new Property<>(37510, "ExifUserComment", "Comment tag.A tag used by EXIF users to write keywords or comments about the image besides those inPropertyTagImageDescription and without the character - code limitations of the PropertyTagImageDescription tag. The character code used in the PropertyTagExifUserComment tag is identified based on an ID code in a fixed 8 - bytearea at the start of the tag data area.The unused portion of the area is padded with null characters(0).ID codesare assigned by means of registration.Because the type is not ASCII, it is not necessary to use a NULL terminator.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ExifDTSubsec = new Property<>(37520, "ExifDTSubsec", "Null - terminated character string that specifies a fraction of a second for the PropertyTagDateTime tag.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ExifDTOrigSS = new Property<>(37521, "ExifDTOrigSS", "Null - terminated character string that specifies a fraction of a second for the PropertyTagExifDTOrig tag.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ExifDTDigSS = new Property<>(37522, "ExifDTDigSS", "Null-terminated character string that specifies a fraction of a second for the PropertyTagExifDTDigitized tag.", new List<PropertyType> { PropertyType.Ascii }, 0);
    //public Property<> ExifFPXVer = new Property<>(40960, "ExifFPXVer", "FlashPix format version supported by an FPXR file. If the FPXR function supports FlashPix format version 1.0, this isindicated similarly to PropertyTagExifVer by recording 0100 as a 4-byte ASCII string. Because the type isPropertyTagTypeUndefined, there is no NULL terminator. Default01000100 - FlashPix format version 1.0 Other - reserved", new List<PropertyType> { PropertyType.Undefined }, 4);
    //public Property<> ExifColorSpace = new Property<>(40961, "ExifColorSpace", "Color space specifier. Normally sRGB (=1) is used to define the color space based on the PC monitor conditions andenvironment. If a color space other than sRGB is used, Uncalibrated (=0xFFFF) is set. Image data recorded asUncalibrated can be treated as sRGB when it is converted to FlashPix. 0x1 - sRGB 0xFFFF - uncalibrated Other - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifPixXDim = new Property<>(40962, "ExifPixXDim", "Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful imagemust be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist inan uncompressed file.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ExifPixYDim = new Property<>(40963, "ExifPixYDim", "Information specific to compressed data. When a compressed file is recorded, the valid height of the meaningful imagemust be recorded in this tag whether or not there is padding data or a restart marker. This tag should not exist inan uncompressed file. Because data padding is unnecessary in the vertical direction, the number of lines recorded inthis valid image height tag will be the same as that recorded in the SOF.", new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray }, 1);
    //public Property<> ExifRelatedWav = new Property<>(40964, "ExifRelatedWav", "The name of an audio file related to the image data. The only relational information recorded is the EXIF audio filename and extension (an ASCII string that consists of 8 characters plus a period (.), plus 3 characters). The path isnot recorded. When you use this tag, audio files must be recorded in conformance with the EXIF audio format. Writerscan also store audio data within APP2 as FlashPix extension stream data.", new List<PropertyType> { PropertyType.Ascii }, 13);
    //public Property<> ExifInterop = new Property<>(40965, "ExifInterop", "Offset to a block of property items that contain interoperability information.", new List<PropertyType> { PropertyType.LongArray }, 1);
    //public Property<> ExifFlashEnergy = new Property<>(41483, "ExifFlashEnergy", "Strobe energy, in Beam Candle Power Seconds (BCPS), at the time the image was captured.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifSpatialFR = new Property<>(41484, "ExifSpatialFR", "Camera or input device spatial frequency table and SFR values in the image width, image height, and diagonaldirection, as specified in ISO 12233.", new List<PropertyType> { PropertyType.Undefined }, 0);
    //public Property<> ExifFocalXRes = new Property<>(41486, "ExifFocalXRes", "Number of pixels in the image width (x) direction per unit on the camera focal plane. The unit is specified inPropertyTagExifFocalResUnit.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifFocalYRes = new Property<>(41487, "ExifFocalYRes", "Number of pixels in the image height (y) direction per unit on the camera focal plane. The unit is specified inPropertyTagExifFocalResUnit.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifFocalResUnit = new Property<>(41488, "ExifFocalResUnit", "Unit of measure for PropertyTagExifFocalXRes and PropertyTagExifFocalYRes. 2 - inch 3 - centimeter", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifSubjectLoc = new Property<>(41492, "ExifSubjectLoc", "Location of the main subject in the scene. The value of this tag represents the pixel at the center of the mainsubject relative to the left edge. The first value indicates the column number, and the second value indicates therow number.", new List<PropertyType> { PropertyType.UShortArray }, 2);
    //public Property<> ExifExposureIndex = new Property<>(41493, "ExifExposureIndex", "Exposure index selected on the camera or input device at the time the image was captured.", new List<PropertyType> { PropertyType.LongFractionArray }, 1);
    //public Property<> ExifSensingMethod = new Property<>(41495, "ExifSensingMethod", "Image sensor type on the camera or input device. 1 - not defined 2 - one - chip color area sensor 3 - two - chip color area sensor 4 - three - chip color area sensor 5 - color sequential area sensor 7 - trilinear sensor 8 - color sequential linear sensor Other - reserved", new List<PropertyType> { PropertyType.UShortArray }, 1);
    //public Property<> ExifFileSource = new Property<>(41728, "ExifFileSource", "The image source. If a DSC recorded the image, the value of this tag is 3.", new List<PropertyType> { PropertyType.Undefined }, 1);
    //public Property<> ExifSceneType = new Property<>(41729, "ExifSceneType", "The type of scene. If a DSC recorded the image, the value of this tag must be set to 1, indicating that the image was, directly photographed.", new List<PropertyType> { PropertyType.Undefined }, 1);
    //public Property<> ExifCfaPattern = new Property<>(41730, "ExifCfaPattern", "The color filter array(CFA) geometric pattern of the image sensor when a one - chip color area sensor is used.It doesnot apply to all sensing methods.", new List<PropertyType> { PropertyType.Undefined }, 0);"
}
