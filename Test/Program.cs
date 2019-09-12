using ImageMeta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var descs = JsonConvert.DeserializeObject<List<TagDesc>>(System.IO.File.ReadAllText("MS_Html.json"));


            ////var descs = JsonConvert.DeserializeObject<List<TagDesc>>(System.IO.File.ReadAllText("jsconfig1.json"));
            //var descs1 = descs.Select(x => new TagDesc1() { Count = x.Count, Desc = x.Desc, Name = x.Name.Trim(), Type = JsonConvert.DeserializeObject<List<PType>>(x.Type) }).ToList();
            //var ids = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText("PropertyToId.json")).ToDictionary(x => x.Value, x => x.Key);
            //var properties = descs1.Select(x => new Property<object>(Convert.ToInt32(ids[x.Name], 16), x.Name, x.Desc, ParseTypes(x.Type), x.Count)).ToList();
            //System.Diagnostics.Debug.WriteLine(
            //    JsonConvert.SerializeObject(properties.Select(
            //        x => $"public class {x.Name}:AbsProperty<object> {{public {x.Name}():base({x.Id}, \"{x.Name}\", \"{x.Description}\",new List<PropertyType>{{{string.Join(',', x.Types.Select(y => $"PropertyType.{y}"))}}},{x.Length}){{}} public object Parse(PropertyItem pi){{if(Types.Any(x => CheckLength(pi.Value.Length, x, Length))){{return null;}}else{{return default(object);}}}}public override void SetValue(object value){{}}public override object GetValue(PropertyItem pi){{return null;}}public override byte[] GetValueBytes(PropertyItem pi){{return null;}} }}")));
            ////x => $"public Property<> {x.Name} = new Property<>({x.Id},\"{x.Name}\", \"{x.Description}\",new List<PropertyType>{{{string.Join(',', x.Types.Select(y => $"PropertyType.{y}"))}}}, {x.Length});")));
            new Class1().asdf();
            Console.WriteLine("Hello World!");
        }

        static List<PropertyType> ParseTypes(List<PType> ptypes)
        {
            var res = new List<PropertyType>();
            ptypes?.ForEach(x => 
            {
                switch (x)
                {
                    case PType.ASCII: { res.Add(PropertyType.Ascii); break; }
                    case PType.Byte: { res.Add(PropertyType.Bytes); break; }
                    case PType.Long: { res.Add(PropertyType.LongArray); break; }
                    case PType.Rational: { res.Add(PropertyType.LongFractionArray); break; }
                    case PType.Short: { res.Add(PropertyType.UShortArray); break; }
                    case PType.SRational: { res.Add(PropertyType.LongFractionArray); break; }
                }
            });
            return res;
        }
    }
}
