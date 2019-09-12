using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ImageMeta
{
    public abstract class AbsProperty<T>
    {
        public AbsProperty(int id, string name, string description, IEnumerable<PropertyType> types, int length)
        {
            Id = id;
            Name = name;
            Description = description;
            Types = types;
            Length = length;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<PropertyType> Types { get; }
        public int Length { get; }
        public byte[] GetValueBytes(PropertyItem pi) { return pi.Value; }
        public T GetValue(PropertyItem pi) { return Parse(pi); }
        public abstract void SetValue(T value, PropertyItem pi);

        protected abstract T Parse(PropertyItem pi);

        protected byte[] ReadBytes(byte[] data)
        {
            return data;
        }

        protected string GetAscii(byte[] data, int length)
        {
            return Encoding.ASCII.GetString(data);
        }

        protected List<uint> GetLongArray(byte[] data, int length)
        {
            var res = new List<uint>();
            for (var i = 0; i < length * 4; i += 4)
            {
                res.Add(BitConverter.ToUInt32(data, i));
            }
            return res;
        }

        protected List<uint> GetULongArray(byte[] data, int length)
        {
            var res = new List<uint>();
            for (var i = 0; i < length * 4; i += 4)
            {
                res.Add(Convert.ToUInt32(data.Skip(i).Take(4).ToArray()));
            }
            return res;
        }

        protected List<ushort> GetUShortArray(byte[] data, int length)
        {
            var res = new List<ushort>();
            for (var i = 0; i < length * 2; i += 2)
            {
                res.Add(Convert.ToUInt16(data.Skip(i).Take(2).ToArray()));
            }
            return res;
        }

        protected List<double> GetLongFractionArray(byte[] data, int length)
        {
            var res = new List<double>();
            for (var i = 0; i < length * 8; i += 8)
            {
                var numerator = BitConverter.ToInt32(data, i);
                var denominator = BitConverter.ToInt32(data, i + 4);
                denominator = denominator == 0 ? 1 : denominator;
                res.Add((double)numerator / (double)denominator);
            }
            return res;
        }

        protected List<double> GetULongFractionArray(byte[] data, int length)
        {
            var res = new List<double>();
            for (var i = 0; i < length * 8; i += 8)
            {
                var numerator = BitConverter.ToUInt32(data, i);
                var denominator = BitConverter.ToUInt32(data, i + 4);
                res.Add((double)numerator / (double)denominator);
            }
            return res;
        }

        protected PropertyType GetPreferredPropertyType(List<PropertyType> types)
        {
            if (types.Count == 2 && (types.Except(new List<PropertyType> { PropertyType.Bytes, PropertyType.UShortArray })?.Any() ?? true))
            {
                return PropertyType.UShortArray;
            }
            else if (types.Count == 2 && (types.Except(new List<PropertyType> { PropertyType.UShortArray, PropertyType.LongArray })?.Any() ?? true))
            {
                return PropertyType.LongArray;
            }
            return types?.First() ?? PropertyType.Undefined;
        }

        protected bool IsNullTerminated(byte[] data)
        {
            return data[data.Length - 1] == (byte)char.MinValue;
        }

        protected bool CheckLength(int bytesLength, PropertyType type, int length)
        {
            if (length == 0) return true;
            switch (type)
            {
                case PropertyType.Any:
                case PropertyType.Undefined: { return true; }
                case PropertyType.Ascii: { return length == bytesLength; }
                case PropertyType.Bytes: { return length == bytesLength; }
                case PropertyType.LongArray:
                case PropertyType.ULongArray: { return 4 * length == bytesLength; }
                case PropertyType.UShortArray: { return 2 * 2 * length == bytesLength; }
                case PropertyType.LongFractionArray:
                case PropertyType.ULongFractionArray: { return 2 * 4 * length == bytesLength; }
            }
            return false;
        }

        protected byte ReadSingleByte(byte[] pi)
        {
            var bytes = ReadBytes(pi);
            return bytes.Any() ? bytes[0] : new byte();
        }

        protected double GetLatLngFromDouble(List<double> coord)
        {
            return coord[0] + (coord[1] / 60) + (coord[2] / 3600);
        }

        protected byte[] LatLngToBytes(double value)
        {
            var degrees = Math.Truncate(value);
            var minutes = (value - Math.Truncate(value)) * 60;
            var seconds = (minutes - Math.Truncate(minutes)) * 60;
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes((int)degrees));
            bytes.AddRange(BitConverter.GetBytes((int)1));
            bytes.AddRange(BitConverter.GetBytes((int)minutes));
            bytes.AddRange(BitConverter.GetBytes((int)1));
            bytes.AddRange(BitConverter.GetBytes((int)(seconds * 1000)));
            bytes.AddRange(BitConverter.GetBytes((int)1000));
            return bytes.ToArray();
        }
    }


















































    //"public class GspVer:AbsProperty<object> {public GspVer():base(a, b, c, d, e){} public object Parse(PropertyItem pi){if(Types.Any(x => CheckLength(data.Length, x, Length))){}else{return default(T);}}public override void SetValue(object value){}public override object GetValue(PropertyItem pi){}public override byte[] GetValueBytes(PropertyItem pi){} }"
    //public class Property<T> : AbsProperty<T>
    //{
    //    public Property(int id, string name, string description, IEnumerable<PropertyType> types, int length) : base(id, name, description, types, length)
    //    {           
    //    }

    //    protected byte[] Data { get; }

    //    public override T GetValue(PropertyItem pi)
    //    {
    //            throw new NotImplementedException();
    //    }

    //    public override byte[] GetValueBytes(PropertyItem pi)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void SetValue(T value, PropertyItem pi)
    //    {
    //    }

    //    public T Parse(byte[] data)
    //    {
    //        if (Types.Any(x => CheckLength(data.Length, x, Length)))
    //        {
    //            //foreach(var type in Types)
    //            //{
    //            //    if (CheckLength(data.Length, type, Length))
    //            //    {
    //            //        switch (type)
    //            //        {
    //            //            case PropertyType.Any:
    //            //            case PropertyType.Bytes: {
    //            //                    var value = (byte[]) ReadValue(data, type, Length);

    //            //                }
    //            //            case PropertyType.LongArray:
    //            //            case PropertyType.ULongArray: { return 8 * length == bytesLength; }
    //            //            case PropertyType.UShortArray: { return 2 * 2 * length == bytesLength; }
    //            //            case PropertyType.LongFractionArray:
    //            //            case PropertyType.ULongFractionArray: { return 2 * 8 * length == bytesLength; }
    //            //        }
    //            //        //var value = ReadValue(data, type, Length);
    //            //    }
    //            //}
    //        }
    //        //lengths dont match. Denied
    //        return default(T);
    //    }


    //}


}
