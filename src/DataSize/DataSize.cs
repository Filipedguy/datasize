using System;

namespace DataSize
{
    public struct DataSize
    {
        private const double ChangeTypeFactor = 1024;

        private const double BSizingFactor = 1;
        private const double KBSizingFactor = BSizingFactor * ChangeTypeFactor;
        private const double MBSizingFactor = KBSizingFactor * ChangeTypeFactor;
        private const double GBSizingFactor = MBSizingFactor * ChangeTypeFactor;
        private const double TBSizingFactor = GBSizingFactor * ChangeTypeFactor;
        private const double PBSizingFactor = TBSizingFactor * ChangeTypeFactor;
        private const double EBSizingFactor = PBSizingFactor * ChangeTypeFactor;
        private const double ZBSizingFactor = EBSizingFactor * ChangeTypeFactor;
        private const double YBSizingFactor = ZBSizingFactor * ChangeTypeFactor;

        private const string BSuffix = "B";
        private const string KBSuffix = "KB";
        private const string MBSuffix = "MB";
        private const string GBSuffix = "GB";
        private const string TBSuffix = "TB";
        private const string PBSuffix = "PB";
        private const string EBSuffix = "EB";
        private const string ZBSuffix = "ZB";
        private const string YBSuffix = "YB";

        private DataSize(double size, double sizingFactor)
        {
            Bytes = BytesFromSize(size, sizingFactor);
        }

        public static DataSize FromBytes(double bytes) => new DataSize(bytes, BSizingFactor);
        public static DataSize FromKiloBytes(double bytes) => new DataSize(bytes, KBSizingFactor);
        public static DataSize FromMegaBytes(double bytes) => new DataSize(bytes, MBSizingFactor);
        public static DataSize FromGigaBytes(double bytes) => new DataSize(bytes, GBSizingFactor);
        public static DataSize FromTeraBytes(double bytes) => new DataSize(bytes, TBSizingFactor);
        public static DataSize FromPetaBytes(double bytes) => new DataSize(bytes, PBSizingFactor);
        public static DataSize FromExaBytes(double bytes) => new DataSize(bytes, EBSizingFactor);
        public static DataSize FromZettaBytes(double bytes) => new DataSize(bytes, ZBSizingFactor);
        public static DataSize FromYottaBytes(double bytes) => new DataSize(bytes, YBSizingFactor);

        public double Bytes { get; private set; }
        public double KiloBytes => SizeFromBytes(KBSizingFactor);
        public double MegaBytes => SizeFromBytes(MBSizingFactor);
        public double GigaBytes => SizeFromBytes(GBSizingFactor);
        public double TeraBytes => SizeFromBytes(TBSizingFactor);
        public double PetaBytes => SizeFromBytes(PBSizingFactor);
        public double ExaBytes => SizeFromBytes(EBSizingFactor);
        public double ZettaBytes => SizeFromBytes(ZBSizingFactor);
        public double YottaBytes => SizeFromBytes(YBSizingFactor);

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

        private static double BytesFromSize(double size, double sizingFactor)
        {
            return size * sizingFactor;
        }

        private double SizeFromBytes(double sizingFactor)
        {
            return Bytes / sizingFactor;
        }

        private string GetHumanString()
        {
            if (IsHumanReadableSize(Bytes))
                return GetHumanFormattedSize(Bytes, BSuffix);

            if (IsHumanReadableSize(KiloBytes))
                return GetHumanFormattedSize(KiloBytes, KBSuffix);

            if (IsHumanReadableSize(MegaBytes))
                return GetHumanFormattedSize(MegaBytes, MBSuffix);

            if (IsHumanReadableSize(GigaBytes))
                return GetHumanFormattedSize(GigaBytes, GBSuffix);

            if (IsHumanReadableSize(TeraBytes))
                return GetHumanFormattedSize(TeraBytes, TBSuffix);

            if (IsHumanReadableSize(PetaBytes))
                return GetHumanFormattedSize(PetaBytes, PBSuffix);

            if (IsHumanReadableSize(ExaBytes))
                return GetHumanFormattedSize(ExaBytes, EBSuffix);

            if (IsHumanReadableSize(ZettaBytes))
                return GetHumanFormattedSize(ZettaBytes, ZBSuffix);

            return GetHumanFormattedSize(YottaBytes, YBSuffix);
        }

        private bool IsHumanReadableSize(double size)
        {
            return size < 1000;
        }

        private string GetHumanFormattedSize(double size, string suffix)
        {
            return $"{Math.Round(size, 2)} {suffix}";
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
