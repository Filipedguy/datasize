using System;
using System.Linq;
using System.Reflection;

namespace DataSize
{
    public enum SizeType
    {
        [Suffix("B")]
        Bytes,

        [Suffix("KB")]
        KiloBytes,

        [Suffix("MB")]
        MegaBytes,

        [Suffix("GB")]
        GigaBytes,

        [Suffix("TB")]
        TeraBytes,

        [Suffix("PB")]
        PetaBytes,

        [Suffix("EB")]
        ExaBytes,

        [Suffix("ZB")]
        ZettaBytes,

        [Suffix("YB")]
        YottaBytes
    }
}
