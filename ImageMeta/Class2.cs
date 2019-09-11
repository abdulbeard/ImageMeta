using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMeta
{
    public class TagDesc
    {
        public TagDesc()
        {
            Type = "";
        }
        public string Tag { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }

    public class TagDesc1
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Count { get; set; }
        public List<PType> Type { get; set; }
    }

    public class asdf
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Tag { get; set; }
        public int Count { get; set; }
        public List<PType> Type { get; set; }
    }

    public enum PType
    {
        ASCII,
        Byte,
        Long,
        Rational,
        Short,
        SRational,
        Undefined
    }
}
