using System;

namespace DataSize
{
    public struct DataSize
    {
        private const int _sizingFactor = 1024;

        public DataSize(double size, SizeType sizeType)
        {
            Bytes = GetSizeInBytes(size, sizeType);
        }

        public static DataSize FromBytes(double bytes) => new DataSize(bytes, SizeType.Bytes);
        public static DataSize FromKiloBytes(double bytes) => new DataSize(bytes, SizeType.KiloBytes);
        public static DataSize FromMegaBytes(double bytes) => new DataSize(bytes, SizeType.MegaBytes);
        public static DataSize FromGigaBytes(double bytes) => new DataSize(bytes, SizeType.GigaBytes);
        public static DataSize FromTeraBytes(double bytes) => new DataSize(bytes, SizeType.TeraBytes);
        public static DataSize FromPetaBytes(double bytes) => new DataSize(bytes, SizeType.PetaBytes);
        public static DataSize FromExaBytes(double bytes) => new DataSize(bytes, SizeType.ExaBytes);
        public static DataSize FromZettaBytes(double bytes) => new DataSize(bytes, SizeType.ZettaBytes);
        public static DataSize FromYottaBytes(double bytes) => new DataSize(bytes, SizeType.YottaBytes);

        public double Bytes { get; private set; }
        public double KiloBytes => SizeFromBytes(SizeType.KiloBytes);
        public double MegaBytes => SizeFromBytes(SizeType.MegaBytes);
        public double GigaBytes => SizeFromBytes(SizeType.GigaBytes);
        public double TeraBytes => SizeFromBytes(SizeType.TeraBytes);
        public double PetaBytes => SizeFromBytes(SizeType.PetaBytes);
        public double ExaBytes => SizeFromBytes(SizeType.ExaBytes);
        public double ZettaBytes => SizeFromBytes(SizeType.ZettaBytes);
        public double YottaBytes => SizeFromBytes(SizeType.YottaBytes);

        public static bool operator ==(DataSize left, DataSize right)
        {
            return left.Bytes == right.Bytes;
        }
        public static bool operator !=(DataSize left, DataSize right)
        {
            return left.Bytes != right.Bytes;
        }
        public static bool operator <(DataSize left, DataSize right)
        {
            return left.Bytes < right.Bytes;
        }
        public static bool operator >(DataSize left, DataSize right)
        {
            return left.Bytes > right.Bytes;
        }
        public static bool operator <=(DataSize left, DataSize right)
        {
            return left.Bytes <= right.Bytes;
        }
        public static bool operator >=(DataSize left, DataSize right)
        {
            return left.Bytes >= right.Bytes;
        }
        public static DataSize operator +(DataSize left, DataSize right)
        {
            return FromBytes(left.Bytes + right.Bytes);
        }
        public static DataSize operator -(DataSize left, DataSize right)
        {
            return FromBytes(left.Bytes - right.Bytes);
        }
        public static DataSize operator *(DataSize left, DataSize right)
        {
            return FromBytes(left.Bytes * right.Bytes);
        }
        public static DataSize operator /(DataSize left, DataSize right)
        {
            return FromBytes(left.Bytes / right.Bytes);
        }

        public string Human => GetHumanString();

        private static double GetSizeInBytes(double size, SizeType fromSize)
        {
            return GetSize(size, fromSize, SizeType.Bytes);
        }

        private double SizeFromBytes(SizeType desiredSize)
        {
            return GetSize(Bytes, SizeType.Bytes, desiredSize);
        }

        private string GetHumanString()
        {
            var allSizes = SizeTypeHelper.GetAll();

            foreach (var size in SizeTypeHelper.GetAll())
            {
                var sizeFromBytes = Math.Round(SizeFromBytes(size), 2);
                if (sizeFromBytes < 1000)
                {
                    return $"{sizeFromBytes} {size.Suffix()}";
                }
            }

            return $"{YottaBytes} {SizeType.YottaBytes.Suffix()}";
        }

        private static double GetSize(double fromSize, SizeType fromType, SizeType toType)
        {
            var timesFactor = GetTimesFactor(fromType, toType);
            var finalSize = fromSize;

            for (var i = 0; i < timesFactor; i++)
            {
                finalSize = ApplyFactor(finalSize, fromType > toType);
            }

            return finalSize;
        }

        private static int GetTimesFactor(SizeType fromSize, SizeType toSize)
        {
            var fromSizeValue = (int)fromSize;
            var toSizeValue = (int)toSize;

            return Math.Abs(fromSizeValue - toSizeValue);
        }

        private static double ApplyFactor(double currentSize, bool isIncreasing)
        {
            if (isIncreasing)
            {
                return currentSize * _sizingFactor;
            }
            else
            {
                return currentSize / _sizingFactor;
            }
        }

        public override string ToString()
        {
            return GetHumanString();
        }

        public override bool Equals(object obj)
        {
            return obj is DataSize size &&
                   Bytes == size.Bytes;
        }

        public override int GetHashCode()
        {
            return -1201175367 + Bytes.GetHashCode();
        }
    }
}
