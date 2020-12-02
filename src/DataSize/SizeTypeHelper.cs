using System;
using System.Linq;

namespace DataSize
{
    internal static class SizeTypeHelper
    {
        public static SizeType[] GetAll()
        {
            return Enum
                    .GetValues(typeof(SizeType))
                    .Cast<SizeType>()
                    .ToArray();
        }
    }
}
