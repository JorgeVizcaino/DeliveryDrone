using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Delivery.Extension;
using Xunit;

namespace Delivery.Test
{
    public class DeviveryTests
    {
        private CommandCalculate _commandCalculate;
        public DeviveryTests()
        {
            _commandCalculate = new CommandCalculate();
        }
        [Theory]
        [InlineData("c:\\temp251")]
        public async Task ShouldGenerate_FileRouteAsync_Success(string path)
        {
            Directory.CreateDirectory(path);
            string[] lines =
            {
                "AAAAIAA", "DDDAIAD", "AAIADAD"
            };

            await File.WriteAllLinesAsync(path + "\\del.txt", lines);
            var result = _commandCalculate.CalculateRoute(path);

            Directory.Delete(path, true);
            Assert.Equal("Process successfully", result);
        }

        [Theory]
        [InlineData("c:\\temp251")]
        public async Task ShouldGenerate_FileRouteAsync_Fails(string path)
        {
            var result = _commandCalculate.CalculateRoute(path);
            Assert.NotEqual("Process successfully", result);
        }


        [Theory]
        [InlineData("c:\\temp253")]
        public async Task ShouldGenerate_RouteAsync_Success(string path)
        {
            Directory.CreateDirectory(path);
            string[] lines =
            {
                "AAAAIAA", "DDDAIAD", "AAIADAD"
            };

            await File.WriteAllLinesAsync(path + "\\del.txt", lines);
            var result = _commandCalculate.CalculateRoute(path);

            using (var streamReader = new StreamReader(path + "\\in01.txt", Encoding.UTF8))
            {
                var line = streamReader.ReadToEnd().Split("\r\n");
                Assert.Equal("-2,4,Oeste", line[0]);
                Assert.Equal("-1,3,Sur", line[1]);
                Assert.Equal("0,0,Oeste", line[2]);
            }
            Directory.Delete(path, true);

        }
    }
}
