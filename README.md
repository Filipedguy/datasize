# Data Size
A library for helping with size conversion and presentation

![Continuous Integration](https://github.com/Filipedguy/datasize/workflows/Continuous%20Integration/badge.svg)

## Creating an data size object

### By Constructor

You can create an DataSize struct using the default constructor:

```csharp
var dataSize = new DataSize(1.5, SizeType.GigaBytes);
```

### Using statis builders

Or you can create it from static methods

```csharp
var dataSize = DataSize.FromBytes(10);
var dataSizeKilo = DataSize.FromKiloBytes(10);
var dataSizeMega = DataSize.FromMegaBytes(10);
var dataSizeGiga = DataSize.FromGigaBytes(10);
var dataSizeTera = DataSize.FromTeraBytes(10);
var dataSizePeta = DataSize.FromPetaBytes(10);
var dataSizeExa = DataSize.FromExaBytes(10);
var dataSizeZetta = DataSize.FromZettaBytes(10);
var dataSizeYotta = DataSize.FromYottaBytes(42);
```

### SizeType enum

The SizeType enum contains all avaiable sizes:

```
Bytes,
KiloBytes,
MegaBytes,
GigaBytes,
TeraBytes,
PetaBytes,
ExaBytes,
ZettaBytes,
YottaBytes,
```

### Human readability

DataSize struct contains overrides and properties to show data as human readable:

```csharp
var dataSize = DataSize.FromBytes(1024);

dataSize.ToString(); // Displays "1 KB"
dataSize.Human; // Displays "1 KB"
```

### Supports for operators

DataSize struct support all basic operators, like:

```csharp
var dataSize1 = DataSize.FromMegaBytes(500);
var dataSize2 = DataSize.FromGigaBytes(1);

var sumDataSize = dataSize1 + dataSize2;

sumDataSize.Human; // Displays "1.5 GB"
```

Avaiable operations:

```csharp
var dataSizeLeft = DataSize.FromMegaBytes(200);
var dataSizeRight = DataSize.FromGigaBytes(1);

dataSizeLeft == dataSizeRight // False
dataSizeLeft != dataSizeRight // True
dataSizeLeft > dataSizeRight; // False
dataSizeLeft >= dataSizeRight // False
dataSizeLeft < dataSizeRight // True
dataSizeLeft <= dataSizeRight // True
dataSizeLeft += dataSizeRight // 1.2 GB
dataSizeLeft -= dataSizeRight // -824 MB
dataSizeLeft /= dataSizeRight // 0.2 B
dataSizeLeft *= dataSizeRight // 200 PB
```