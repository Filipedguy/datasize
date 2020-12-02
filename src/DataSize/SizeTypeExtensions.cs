using System.Reflection;

namespace DataSize
{
    public static class SizeTypeExtensions
    {
        public static string Suffix(this SizeType sizeType)
        {
            return sizeType.FieldInfo().SuffixAttribute().Name;
        }

        private static FieldInfo FieldInfo(this SizeType sizeType)
        {
            return typeof(SizeType).GetField(sizeType.ToString());
        }

        private static SuffixAttribute SuffixAttribute(this FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttribute<SuffixAttribute>();
        }
    }
}
