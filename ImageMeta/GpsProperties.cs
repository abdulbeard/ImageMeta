using System;
using System.Collections.Generic;
using System.Text;
using static ImageMeta.GpsVer;
using static ImageMeta.GpsLatitudeRef;
using static ImageMeta.GpsLongitudeRef;
using static ImageMeta.GpsGpsStatus;
using static ImageMeta.GpsGpsMeasureMode;
using static ImageMeta.GpsSpeedRef;
using static ImageMeta.GpsTrackRef;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageMeta
{

    public class GpsVer : AbsProperty<GpsVerType>
    {
        public GpsVer() : base(0, "GpsVer",
            "Version of the Global Positioning Systems (GPS) IFD, given as 2.0.0.0. This tag is mandatory when the PropertyTagGpsIFD tag is present. When the version is 2.0.0.0, the tag value is 0x02000000",
            new List<PropertyType> { PropertyType.Bytes }, 4)
        {
        }
        protected override GpsVerType Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var value = ReadBytes(pi.Value);
                return new GpsVerType { First = value[0], Second = value[1], Third = value[2], Fourth = value[3] };
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsVerType value, PropertyItem pi)
        {
            if (value != null)
            {
                pi.Value = new byte[] { value.First, value.Second, value.Third, value.Fourth };
            }
        }

        public class GpsVerType
        {
            public byte First { get; set; }
            public byte Second { get; set; }
            public byte Third { get; set; }
            public byte Fourth { get; set; }
        }
    }

    public class GpsLatitudeRef : AbsProperty<GpsLat>
    {
        public GpsLatitudeRef() : base(1, "GpsLatitudeRef",
            "Null-terminated character string that specifies whether the latitude is north or south. N specifies north latitude, and S specifies south latitude", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsLat Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'N' ? GpsLat.North : (ascii[0] == 'S' ? GpsLat.South : GpsLat.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsLat value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsLat.North ? 'N' : (value == GpsLat.South ? 'S' : char.MinValue))}{char.MinValue}");
        }

        public enum GpsLat
        {
            Undefined,
            North,
            South
        }
    }

    public class GpsLatitude : AbsProperty<double>
    {
        public GpsLatitude() : base(2, "GpsLatitude",
            "Latitude. Latitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes, and seconds are expressed, the format is dd/1, mm/1, ss/1. " +
            "When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1, mmmm/100, 0/1",
            new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var coord = GetLongFractionArray(pi.Value, Length);
                return GetLatLngFromDouble(coord);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = LatLngToBytes(value);
        }
    }

    public class GpsLongitudeRef : AbsProperty<GpsLon>
    {
        public GpsLongitudeRef() : base(3, "GpsLongitudeRef",
            "Null-terminated character string that specifies whether the longitude is east or west longitude. E specifies east longitude, and W specifies west longitude",
            new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsLon Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'W' ? GpsLon.West : (ascii[0] == 'E' ? GpsLon.East : GpsLon.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsLon value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsLon.East ? 'E' : (value == GpsLon.West ? 'W' : char.MinValue))}{char.MinValue}");
        }

        public enum GpsLon
        {
            Undefined,
            West,
            East
        }
    }

    public class GpsLongitude : AbsProperty<double>
    {
        public GpsLongitude() : base(4, "GpsLongitude",
            "Longitude. Longitude is expressed as three rational values giving the degrees, minutes, and seconds respectively. When degrees, minutes and seconds are expressed, the format is ddd/1, mm/1, ss/1. " +
            "When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1, mmmm/100, 0/1", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var coord = GetLongFractionArray(pi.Value, Length);
                return GetLatLngFromDouble(coord);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = LatLngToBytes(value);
        }
    }

    public class GpsAltitudeRef : AbsProperty<byte>
    {
        public GpsAltitudeRef() : base(5, "GpsAltitudeRef", "Reference altitude, in meters.", new List<PropertyType> { PropertyType.Bytes }, 1)
        {
        }
        protected override byte Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return ReadSingleByte(pi.Value);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(byte value, PropertyItem pi)
        {
            pi.Value = new byte[] { value };
        }
    }

    public class GpsAltitude : AbsProperty<byte>
    {
        public GpsAltitude() : base(6, "GpsAltitude", "Altitude, in meters, based on the reference altitude specified by GpsAltitudeRef.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override byte Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var bytes = ReadBytes(pi.Value);
                return bytes.Any() ? bytes[0] : new byte();
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(byte value, PropertyItem pi)
        {
            pi.Value = new byte[] { value };
        }
    }

    public class GpsGpsTime : AbsProperty<System.DateTime>
    {
        public GpsGpsTime() : base(7, "GpsGpsTime", "Time as Coordinated Universal Time (UTC). The value is expressed as three rational numbers that give the hour,minute, and second.", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override System.DateTime Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var values = GetLongFractionArray(pi.Value, Length);
                return new System.DateTime(0, 0, 0, (int)values[0], (int)values[1], (int)values[2], DateTimeKind.Utc);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(System.DateTime value, PropertyItem pi)
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(value.Hour));
            bytes.AddRange(BitConverter.GetBytes((int)1));
            bytes.AddRange(BitConverter.GetBytes(value.Minute));
            bytes.AddRange(BitConverter.GetBytes((int)1));
            bytes.AddRange(BitConverter.GetBytes(value.Second));
            bytes.AddRange(BitConverter.GetBytes((int)1));
            pi.Value = bytes.ToArray();
        }
    }

    public class GpsGpsSatellites : AbsProperty<string>
    {
        public GpsGpsSatellites() : base(8, "GpsGpsSatellites",
            "Null-terminated character string that specifies the GPS satellites used for measurements. This tag can be used tospecify the ID number, angle of elevation, azimuth, SNR, and other information about each satellite. " +
            "The format is not specified. If the GPS receiver is incapable of taking measurements, the value of the tag must be set to NULL.", new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
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

    public class GpsGpsStatus : AbsProperty<GpsStatus>
    {
        public GpsGpsStatus() : base(9, "GpsGpsStatus",
            "Null-terminated character string that specifies the status of the GPS receiver when the image is recorded.A means measurement is in progress, and V means the measurement is Interoperability.",
            new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsStatus Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'A' ? GpsStatus.InProgress : (ascii[0] == 'V' ? GpsStatus.Interoperability : GpsStatus.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsStatus value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsStatus.InProgress ? 'A' : (value == GpsStatus.Interoperability ? 'V' : char.MinValue))}{char.MinValue}");
        }
        public enum GpsStatus
        {
            Undefined,
            InProgress,
            Interoperability
        }
    }

    public class GpsGpsMeasureMode : AbsProperty<GpsMeasureMode>
    {
        public GpsGpsMeasureMode() : base(10, "GpsGpsMeasureMode", "Null-terminated character string that specifies the GPS measurement mode. 2 specifies 2-D measurement,and 3 specifies 3-D measurement.", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsMeasureMode Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == '2' ? GpsMeasureMode.TwoDimensional : (ascii[0] == '3' ? GpsMeasureMode.ThreeDimensional : GpsMeasureMode.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsMeasureMode value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsMeasureMode.TwoDimensional ? '2' : (value == GpsMeasureMode.ThreeDimensional ? '3' : char.MinValue))}{char.MinValue}");
        }
        public enum GpsMeasureMode
        {
            Undefined,
            TwoDimensional,
            ThreeDimensional
        }
    }

    public class GpsGpsDop : AbsProperty<byte>
    {
        public GpsGpsDop() : base(11, "GpsGpsDop", "GPS DOP (data degree of precision). An HDOP value is written during 2-D measurement, and a PDOP value is writtenduring 3-D measurement.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override byte Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                return ReadSingleByte(pi.Value);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(byte value, PropertyItem pi)
        {
            pi.Value = new byte[] { value };
        }
    }

    public class GpsSpeedRef : AbsProperty<GpsSpeedTypes>
    {
        public GpsSpeedRef() : base(12, "GpsSpeedRef",
            "Null-terminated character string that specifies the unit used to express the GPS receiver speed of movement.K, M, and N represent kilometers per hour, miles per hour, and knots respectively.",
            new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsSpeedTypes Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'K' ? GpsSpeedTypes.KilometersPerHour : (ascii[0] == 'M' ? GpsSpeedTypes.MilesPerHour : (ascii[0] == 'N' ? GpsSpeedTypes.Knots : GpsSpeedTypes.Undefined));
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsSpeedTypes value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsSpeedTypes.KilometersPerHour ? 'K' : (value == GpsSpeedTypes.MilesPerHour ? 'M' : (value == GpsSpeedTypes.Knots ? 'N' : char.MinValue)))}{char.MinValue}");
        }
        public enum GpsSpeedTypes
        {
            Undefined,
            KilometersPerHour,
            MilesPerHour,
            Knots
        }
    }

    public class GpsSpeed : AbsProperty<double>
    {
        public GpsSpeed() : base(13, "GpsSpeed", "Speed of the GPS receiver movement.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetLongFractionArray(pi.Value, Length);
                return val.Any() ? val[0] : 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes((long)value).Concat(BitConverter.GetBytes((long)1)).ToArray();
        }
    }

    public class GpsTrackRef : AbsProperty<GpsTrackDir>
    {
        public GpsTrackRef() : base(14, "GpsTrackRef",
            "Null-terminated character string that specifies the reference for giving the direction of GPS receiver movement.T specifies true direction, and M specifies magnetic direction.", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsTrackDir Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'T' ? GpsTrackDir.True : (ascii[0] == 'M' ? GpsTrackDir.Magnetic : GpsTrackDir.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsTrackDir value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsTrackDir.True ? 'T' : (value == GpsTrackDir.Magnetic ? 'M' : char.MinValue))}{char.MinValue}");
        }
        public enum GpsTrackDir
        {
            Undefined,
            True,
            Magnetic
        }
    }

    public class GpsTrack : AbsProperty<double>
    {
        public GpsTrack() : base(15, "GpsTrack", "Direction of GPS receiver movement. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var result = GetLongFractionArray(pi.Value, Length);
                return result.Any() ? result[0] : (double)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            if (value < 0.00 || value > 359.99) { throw new ArgumentException("value can't be larger than 359.99 and smaller than 0"); }
            pi.Value = BitConverter.GetBytes((int)value * 100).Concat(BitConverter.GetBytes(100)).ToArray();
        }
    }

    public class GpsImgDirRef : AbsProperty<GpsTrackDir>
    {
        public GpsImgDirRef() : base(16, "GpsImgDirRef",
            "Null-terminated character string that specifies the reference for the direction of the image when it is captured.T specifies true direction, and M specifies magnetic direction.",
            new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsTrackDir Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'T' ? GpsTrackDir.True : (ascii[0] == 'M' ? GpsTrackDir.Magnetic : GpsTrackDir.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsTrackDir value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsTrackDir.True ? 'T' : (value == GpsTrackDir.Magnetic ? 'M' : char.MinValue))}{char.MinValue}");
        }
    }

    public class GpsImgDir : AbsProperty<double>
    {
        public GpsImgDir() : base(17, "GpsImgDir", "Direction of the image when it was captured. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var result = GetLongFractionArray(pi.Value, Length);
                return result.Any() ? result[0] : (double)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            if (value < 0.00 || value > 359.99) { throw new ArgumentException("value can't be larger than 359.99 and smaller than 0"); }
            pi.Value = BitConverter.GetBytes((int)value * 100).Concat(BitConverter.GetBytes(100)).ToArray();
        }
    }

    public class GpsMapDatum : AbsProperty<string>
    {
        public GpsMapDatum() : base(18, "GpsMapDatum",
            "Null-terminated character string that specifies geodetic survey data used by the GPS receiver. If the survey data isrestricted to Japan, the value of this tag is TOKYO or WGS-84.",
            new List<PropertyType> { PropertyType.Ascii }, 0)
        {
        }
        protected override string Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
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
        }
    }

    public class GpsDestLatRef : AbsProperty<GpsLat>
    {
        public GpsDestLatRef() : base(19, "GpsDestLatRef",
            "Null-terminated character string that specifies whether the latitude of the destination point is north or southlatitude. N specifies north latitude, and S specifies south latitude.",
            new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsLat Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'N' ? GpsLat.North : (ascii[0] == 'S' ? GpsLat.South : GpsLat.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsLat value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsLat.North ? 'N' : (value == GpsLat.South ? 'S' : char.MinValue))}{char.MinValue}");
        }
    }

    public class GpsDestLat : AbsProperty<double>
    {
        public GpsDestLat() : base(20, "GpsDestLat", "Latitude of the destination point. The latitude is expressed as three rational values giving the degrees, minutes,and seconds respectively. When degrees, minutes, and seconds are expressed, the format is dd/1, mm/1, ss/1. Whendegrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the formatis dd/1, mmmm/100, 0/1.", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var coord = GetLongFractionArray(pi.Value, Length);
                return GetLatLngFromDouble(coord);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = LatLngToBytes(value);
        }
    }

    public class GpsDestLongRef : AbsProperty<GpsLon>
    {
        public GpsDestLongRef() : base(21, "GpsDestLongRef", "Null-terminated character string that specifies whether the longitude of the destination point is east or westlongitude. E specifies east longitude, and W specifies west longitude.", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsLon Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'W' ? GpsLon.West : (ascii[0] == 'E' ? GpsLon.East : GpsLon.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsLon value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsLon.East ? 'E' : (value == GpsLon.West ? 'W' : char.MinValue))}{char.MinValue}");
        }
    }

    public class GpsDestLong : AbsProperty<double>
    {
        public GpsDestLong() : base(22, "GpsDestLong",
            "Longitude of the destination point. The longitude is expressed as three rational values giving the degrees, minutes,and seconds respectively. When degrees, minutes, and seconds are expressed, the format is ddd/1, mm/1, ss/1. " +
            "Whendegrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the formatis ddd/1, mmmm/100, 0/1.", new List<PropertyType> { PropertyType.LongFractionArray }, 3)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var coord = GetLongFractionArray(pi.Value, Length);
                return GetLatLngFromDouble(coord);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = LatLngToBytes(value);
        }
    }

    public class GpsDestBearRef : AbsProperty<GpsTrackDir>
    {
        public GpsDestBearRef() : base(23, "GpsDestBearRef",
            "Null-terminated character string that specifies the reference used for giving the bearing to the destination point.T specifies true direction, and M specifies magnetic direction.", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsTrackDir Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)) && IsNullTerminated(pi.Value))
            {


                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'T' ? GpsTrackDir.True : (ascii[0] == 'M' ? GpsTrackDir.Magnetic : GpsTrackDir.Undefined);
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsTrackDir value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsTrackDir.True ? 'T' : (value == GpsTrackDir.Magnetic ? 'M' : char.MinValue))}{char.MinValue}");
        }
    }

    public class GpsDestBear : AbsProperty<double>
    {
        public GpsDestBear() : base(24, "GpsDestBear", "Bearing to the destination point. The range of values is from 0.00 to 359.99.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var result = GetLongFractionArray(pi.Value, Length);
                return result.Any() ? result[0] : (double)0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            if (value < 0.00 || value > 359.99) { throw new ArgumentException("value can't be larger than 359.99 and smaller than 0"); }
            pi.Value = BitConverter.GetBytes((int)value * 100).Concat(BitConverter.GetBytes(100)).ToArray();
        }
    }

    public class GpsDestDistRef : AbsProperty<GpsSpeedTypes>
    {
        public GpsDestDistRef() : base(25, "GpsDestDistRef", "Null-terminated character string that specifies the unit used to express the distance to the destination point. " +
            "K, M,and N represent kilometers, miles, and knots respectively.", new List<PropertyType> { PropertyType.Ascii }, 2)
        {
        }
        protected override GpsSpeedTypes Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var ascii = GetAscii(pi.Value, Length);
                return ascii[0] == 'K' ? GpsSpeedTypes.KilometersPerHour : (ascii[0] == 'M' ? GpsSpeedTypes.MilesPerHour : (ascii[0] == 'N' ? GpsSpeedTypes.Knots : GpsSpeedTypes.Undefined));
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(GpsSpeedTypes value, PropertyItem pi)
        {
            pi.Value = Encoding.ASCII.GetBytes($"{(value == GpsSpeedTypes.KilometersPerHour ? 'K' : (value == GpsSpeedTypes.MilesPerHour ? 'M' : (value == GpsSpeedTypes.Knots ? 'N' : char.MinValue)))}{char.MinValue}");
        }
    }

    public class GpsDestDist : AbsProperty<double>
    {
        public GpsDestDist() : base(26, "GpsDestDist", "Distance to the destination point.", new List<PropertyType> { PropertyType.LongFractionArray }, 1)
        {
        }
        protected override double Parse(PropertyItem pi)
        {
            if (Types.Any(x => CheckLength(pi.Value.Length, x, Length)))
            {
                var val = GetLongFractionArray(pi.Value, Length);
                return val.Any() ? val[0] : 0;
            }
            else
            {
                return default;
            }
        }
        public override void SetValue(double value, PropertyItem pi)
        {
            pi.Value = BitConverter.GetBytes((long)value).Concat(BitConverter.GetBytes((long)1)).ToArray();
        }
    }
}

