using Xunit;
using System.IO;
using CsharpToColouredHTML.Core;

namespace Tests
{
    public class E2E
    {
        private const string InputDir = $"Input";
        private const string OutputDir = $"Output";

        [Theory]
        [InlineData("0001.txt")]
        public void Test1(string fileName)
        {
            var p1 = Path.Combine(InputDir, fileName);
            var p2 = Path.Combine(OutputDir, fileName);

            var code = File.ReadAllText(p1);
            var goodHTML = File.ReadAllText(p2);

            var resultHTML = new CsharpColourer().ProcessSourceCode(code, new HTMLEmitter());

            Assert.Equal(goodHTML, resultHTML);
        }
    }
}