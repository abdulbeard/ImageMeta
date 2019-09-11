using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ImageMeta
{
    //"public class GspVer:AbsProperty<object> {public GspVer():base(a, b, c, d, e){} public object Parse(PropertyItem pi){if(Types.Any(x => CheckLength(data.Length, x, Length))){}else{return default(T);}}public override void SetValue(object value){}public override object GetValue(PropertyItem pi){}public override byte[] GetValueBytes(PropertyItem pi){} }"
    public class Property<T> : AbsProperty<T>
    {
        public Property(int id, string name, string description, IEnumerable<PropertyType> types, int length) : base(id, name, description, types, length)
        {           
        }

        protected byte[] Data { get; }

        public override T GetValue(PropertyItem pi)
        {
                throw new NotImplementedException();
        }

        public override byte[] GetValueBytes(PropertyItem pi)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(T value)
        {
        }

        public T Parse(byte[] data)
        {
            if (Types.Any(x => CheckLength(data.Length, x, Length)))
            {
                //foreach(var type in Types)
                //{
                //    if (CheckLength(data.Length, type, Length))
                //    {
                //        switch (type)
                //        {
                //            case PropertyType.Any:
                //            case PropertyType.Bytes: {
                //                    var value = (byte[]) ReadValue(data, type, Length);

                //                }
                //            case PropertyType.LongArray:
                //            case PropertyType.ULongArray: { return 8 * length == bytesLength; }
                //            case PropertyType.UShortArray: { return 2 * 2 * length == bytesLength; }
                //            case PropertyType.LongFractionArray:
                //            case PropertyType.ULongFractionArray: { return 2 * 8 * length == bytesLength; }
                //        }
                //        //var value = ReadValue(data, type, Length);
                //    }
                //}
            }
            //lengths dont match. Denied
            return default(T);
        }

        
    }

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
        public abstract T GetValue(PropertyItem pi);
        public abstract byte[] GetValueBytes(PropertyItem pi);
        public abstract void SetValue(T value);

        protected object ReadValue(byte[] data, PropertyType type, int length)
        {
            switch (type)
            {
                case PropertyType.Any:
                case PropertyType.Bytes:
                    {
                        return data;
                    }
                case PropertyType.Ascii:
                    {
                        return Encoding.ASCII.GetString(data);
                    }
                case PropertyType.LongArray:
                    {
                        var res = new List<long>();
                        for (var i = 0; i < length; i += 8)
                        {
                            res.Add(Convert.ToInt64(data.Skip(i).Take(8)));
                        }
                        return res;
                    }
                case PropertyType.ULongArray:
                    {
                        var res = new List<ulong>();
                        for (var i = 0; i < length; i += 8)
                        {
                            res.Add(Convert.ToUInt64(data.Skip(i).Take(8)));
                        }
                        return res;
                    }
                case PropertyType.UShortArray:
                    {
                        var res = new List<short>();
                        for (var i = 0; i < length; i += 2)
                        {
                            res.Add(Convert.ToInt16(data.Skip(i).Take(2)));
                        }
                        return res;
                    }
                case PropertyType.LongFractionArray:
                    {
                        var res = new List<double>();
                        for (var i = 0; i < length; i += 16)
                        {
                            var numerator = Convert.ToInt64(data.Skip(i).Take(8));
                            var denominator = Convert.ToInt64(data.Skip(i + 8).Take(8));
                            res.Add((double)numerator / (double)denominator);
                        }
                        return res;
                    }
                case PropertyType.ULongFractionArray:
                    {
                        var res = new List<double>();
                        for (var i = 0; i < length; i += 16)
                        {
                            var numerator = Convert.ToUInt64(data.Skip(i).Take(8));
                            var denominator = Convert.ToUInt64(data.Skip(i + 8).Take(8));
                            res.Add((double)numerator / (double)denominator);
                        }
                        return res;
                    }
            }
            return null;
        }

        protected bool CheckLength(int bytesLength, PropertyType type, int length)
        {
            if (length == 0) return true;
            switch (type)
            {
                case PropertyType.Any: { return true; }
                case PropertyType.Ascii: { return length == bytesLength; }
                case PropertyType.Bytes: { return length == bytesLength; }
                case PropertyType.LongArray:
                case PropertyType.ULongArray: { return 8 * length == bytesLength; }
                case PropertyType.UShortArray: { return 2 * 2 * length == bytesLength; }
                case PropertyType.LongFractionArray:
                case PropertyType.ULongFractionArray: { return 2 * 8 * length == bytesLength; }
            }
            return false;
        }
    }
}
