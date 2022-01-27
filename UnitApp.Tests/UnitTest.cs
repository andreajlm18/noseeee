using UnitAppLibrary;
using Xunit;

namespace UnitApp.Tests
{
    public class UnitTest
    {
        private readonly UnitAppLogic _unitAppLogic;

        public UnitTest()
        {
            _unitAppLogic = new UnitAppLogic();
        }
        /// <summary>
        /// Clase centraliza variables con los datos de prueba.
        /// </summary>
        public static class FileNames
        {
            public const string fileIncorrect = @"C:/devs/UnitTestApp/UnitTestApp/hs.json";
            public const string fileIncorrect2 = @"https://pokeapi.co/api/v2";
            public const string fileCorrect = @"Example.json";

        }
        /// <summary>
        /// Theory ejecutan el mismo código pero con diferentes argumentos de entrada.
        /// </summary>
        /// <param name="fileName">Dato de entrada(nombre del archivo json)</param>
        [Theory]
        [InlineData(FileNames.fileCorrect)]
        public void TestWrongFilenameRelativePath(string fileName)
        {
            var result = _unitAppLogic.ReadJSON(fileName);
            Assert.False(result, $"{fileName} this url is not valid");
        }
        [Theory]
        [InlineData(FileNames.fileIncorrect2)]
        public void BadTestExternalApiPath(string fileName)
        {
            var result = _unitAppLogic.ReadJSON(fileName);
            Assert.False(result, $"{fileName} this url is not valid");
        }
        /// <summary>
        /// Fact señala que es una prueba unitaria.
        /// </summary>
        [Fact]
        public void TestCorrectFileName()
        {
            var result = _unitAppLogic.ReadJSON(FileNames.fileCorrect);

            Assert.True(result, "this url is not valid");
        }
    }
}