using System;

namespace DataSize
{
    internal class SuffixAttribute : Attribute
    {
        public string Name { get; set; }

        public SuffixAttribute(string name)
        {
            Name = name;
        }
    }
}
