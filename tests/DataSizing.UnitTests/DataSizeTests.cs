using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Xunit;

namespace DataSizing.UnitTests
{
    public class DataSizeTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 0.1)]
        [InlineData(0.01, 0.01)]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        [InlineData(1000, 1000)]
        [InlineData(1024, 1024)]
        [InlineData(1048576, 1048576)]
        public void GivenBytes_Conversion_Should_Be_Expected_Values(double givenBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromBytes(givenBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 102.4)]
        [InlineData(0.01, 10.24)]
        [InlineData(1, 1024)]
        [InlineData(10, 10240)]
        [InlineData(100, 102400)]
        [InlineData(1000, 1024000)]
        [InlineData(1024, 1048576)]
        [InlineData(1048576, 1073741824)]
        public void GivenKiloBytes_Conversion_Should_Be_Expected_Values(double givenKiloBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromKiloBytes(givenKiloBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 104857.6)]
        [InlineData(0.01, 10485.76)]
        [InlineData(1, 1048576)]
        [InlineData(10, 10485760)]
        [InlineData(100, 104857600)]
        [InlineData(1000, 1048576000)]
        [InlineData(1024, 1073741824)]
        [InlineData(1048576, 1099511627776)]
        public void GivenMegaBytes_Conversion_Should_Be_Expected_Values(double givenMegaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromMegaBytes(givenMegaBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 107374182.4)]
        [InlineData(0.01, 10737418.24)]
        [InlineData(1, 1073741824)]
        [InlineData(10, 10737418240)]
        [InlineData(100, 107374182400)]
        [InlineData(1000, 1073741824000)]
        [InlineData(1024, 1099511627776)]
        [InlineData(1048576, 1125899906842624)]
        public void GivenGigaBytes_Conversion_Should_Be_Expected_Values(double givenGigaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromGigaBytes(givenGigaBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 109951162777.6)]
        [InlineData(0.01, 10995116277.76)]
        [InlineData(1, 1099511627776)]
        [InlineData(10, 10995116277760)]
        [InlineData(100, 109951162777600)]
        [InlineData(1000, 1099511627776000)]
        [InlineData(1024, 1125899906842624)]
        [InlineData(1048576, 1152921504606846976)]
        public void GivenTeraBytes_Conversion_Should_Be_Expected_Values(double givenTeraBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromTeraBytes(givenTeraBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 112589990684262.4)]
        [InlineData(0.01, 11258999068426.24)]
        [InlineData(1, 1125899906842624)]
        [InlineData(10, 11258999068426240)]
        [InlineData(100, 112589990684262400)]
        [InlineData(1000, 1125899906842624000)]
        [InlineData(1024, 1152921504606846976)]
        [InlineData(1048576, 1180591620717411303424d)]
        public void GivenPetaBytes_Conversion_Should_Be_Expected_Values(double givenPetaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromPetaBytes(givenPetaBytes);
            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 115292150460684697.6)]
        [InlineData(0.01, 11529215046068469.76)]
        [InlineData(1, 1152921504606846976)]
        [InlineData(10, 11529215046068469760)]
        [InlineData(100, 115292150460684697600d)]
        [InlineData(1000, 1152921504606846976000d)]
        [InlineData(1024, 1180591620717411303424d)]
        [InlineData(1048576, 1208925819614629174706176d)]
        public void GivenExaBytes_Conversion_Should_Be_Expected_Values(double givenExaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromExaBytes(givenExaBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 118059162071741130342.4)]
        [InlineData(0.01, 11805916207174113034.24)]
        [InlineData(1, 1180591620717411303424d)]
        [InlineData(10, 11805916207174113034240d)]
        [InlineData(100, 118059162071741130342400d)]
        [InlineData(1000, 1180591620717411303424000d)]
        [InlineData(1024, 1208925819614629174706176d)]
        [InlineData(1048576, 1237940039285380274899124224d)]
        public void GivenZettaBytes_Conversion_Should_Be_Expected_Values(double givenZettaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromZettaBytes(givenZettaBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 120892581961462917470617.6)]
        [InlineData(0.01, 12089258196146291747061.76)]
        [InlineData(1, 1208925819614629174706176d)]
        [InlineData(10, 12089258196146291747061760d)]
        [InlineData(100, 120892581961462917470617600d)]
        [InlineData(1000, 1208925819614629174706176000d)]
        [InlineData(1024, 1237940039285380274899124224d)]
        [InlineData(1048576, 1267650600228229401496703205376d)]
        public void GivenYottaBytes_Conversion_Should_Be_Expected_Values(double givenZettaBytes, double expectedBytes)
        {
            var dataSize = DataSize.FromYottaBytes(givenZettaBytes);

            AssertConversion(dataSize, expectedBytes);
        }

        [Theory]
        [InlineData(1, "1 B")]
        [InlineData(1024, "1 KB")]
        [InlineData(1048576, "1 MB")]
        [InlineData(1073741824, "1 GB")]
        [InlineData(1099511627776, "1 TB")]
        [InlineData(1125899906842624, "1 PB")]
        [InlineData(1152921504606846976, "1 EB")]
        [InlineData(1180591620717411303424d, "1 ZB")]
        [InlineData(1208925819614629174706176d, "1 YB")]
        [InlineData(1267650600228229401496703205376d, "1048576 YB")]
        [InlineData(917782921.216, "875.27 MB")]
        public void GivenBytes_Human_Should_Be_Expected_String(double totalBytes, string expectedHumanString)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            DataSize.FromBytes(totalBytes).Human.Should().Be(expectedHumanString);
        }

        [Theory]
        [InlineData(1, "1 B")]
        [InlineData(1024, "1 KB")]
        [InlineData(1048576, "1 MB")]
        [InlineData(1073741824, "1 GB")]
        [InlineData(1099511627776, "1 TB")]
        [InlineData(1125899906842624, "1 PB")]
        [InlineData(1152921504606846976, "1 EB")]
        [InlineData(1180591620717411303424d, "1 ZB")]
        [InlineData(1208925819614629174706176d, "1 YB")]
        [InlineData(1267650600228229401496703205376d, "1048576 YB")]
        [InlineData(917782921.216, "875.27 MB")]
        public void GivenBytes_ToString_Should_Be_Expected_String(double totalBytes, string expectedHumanString)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            DataSize.FromBytes(totalBytes).ToString().Should().Be(expectedHumanString);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeEquality_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft == totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize == rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeInequality_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft != totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize != rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeGreaterThan_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft > totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize > rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeGreaterOrEqual_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft >= totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize >= rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeLessThan_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft < totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize < rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeLessOrEqual_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft <= totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize <= rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeAddition_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft + totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize + rightDataSize).Bytes.Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeSubtraction_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft - totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize - rightDataSize).Bytes.Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeMultiply_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft * totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize * rightDataSize).Bytes.Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeDivision_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft / totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            (leftDataSize / rightDataSize).Bytes.Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeAdditionEqual_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft + totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            leftDataSize += rightDataSize;

            leftDataSize.Bytes.Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeEquals_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft == totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            leftDataSize.Equals(rightDataSize).Should().Be(expectedResponse);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(1024, 1024)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(100, 1)]
        [InlineData(1, 1024)]
        public void GivenBytes_DataSizeGetHashCodeEquality_Should_Be_Expected(double totalBytesLeft, double totalBytesRight)
        {
            var expectedResponse = totalBytesLeft == totalBytesRight;

            var leftDataSize = DataSize.FromBytes(totalBytesLeft);
            var rightDataSize = DataSize.FromBytes(totalBytesRight);

            var leftHashCode = leftDataSize.GetHashCode();
            var rightHashCode = rightDataSize.GetHashCode();

            (leftHashCode == rightHashCode).Should().Be(expectedResponse);
        }

        [Fact]
        public void GivenArray_DataSizeHuman_Performance_Should_Be_Bellow_Expected()
        {
            var watch = new Stopwatch();
            watch.Start();

            var sizingArray = new DataSize[10000];

            foreach (var sizing in sizingArray)
            {
                _ = sizing.Human;
            }

            watch.Stop();

            watch.ElapsedMilliseconds.Should().BeLessThan(20);
        }

        [Fact]
        public void GivenYottaBytesCollection_DataSizeHuman_Performance_Should_Be_Bellow_Expected()
        {
            var watch = new Stopwatch();
            watch.Start();

            var sizingCollection = new List<DataSize>();

            for (var i = 0; i < 10000; i++)
            {
                sizingCollection.Add(DataSize.FromYottaBytes(1000));
            }

            foreach (var sizing in sizingCollection)
            {
                _ = sizing.Human;
            }

            watch.Stop();

            watch.ElapsedMilliseconds.Should().BeLessThan(20);
        }

        private void AssertConversion(DataSize dataSize, double expectedBytes)
        {
            var kbFactor = 1024d;
            var mbFactor = kbFactor * 1024d;
            var gbFactor = mbFactor * 1024d;
            var tbFactor = gbFactor * 1024d;
            var pbFactor = tbFactor * 1024d;
            var ebFactor = pbFactor * 1024d;
            var zbFactor = ebFactor * 1024d;
            var ybFactor = zbFactor * 1024d;

            dataSize.Bytes.Should().Be(expectedBytes);
            dataSize.KiloBytes.Should().Be(expectedBytes / kbFactor);
            dataSize.MegaBytes.Should().Be(expectedBytes / mbFactor);
            dataSize.GigaBytes.Should().Be(expectedBytes / gbFactor);
            dataSize.TeraBytes.Should().Be(expectedBytes / tbFactor);
            dataSize.PetaBytes.Should().Be(expectedBytes / pbFactor);
            dataSize.ExaBytes.Should().Be(expectedBytes / ebFactor);
            dataSize.ZettaBytes.Should().Be(expectedBytes / zbFactor);
            dataSize.YottaBytes.Should().Be(expectedBytes / ybFactor);
        }
    }
}
