using System;
using FileProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Collections;

namespace WordCount.Tests
{
    [TestClass]
    public class TestWordCount
    {
        IFileContent fc = Mock.Of<FileContent>();
        string fileName = $"{Environment.CurrentDirectory}\\TestFileContext.txt";

        [TestInitialize]
        public void TestInitialize()
        {
            //IFileContent fc = Mock.Of<FileContent>();
            //fc.FileName = fileName;
            fc.FileDelimiters = new char[] { '\r', '\n', ',', ' ' };
            fc.DataContent = "aa,bb,cc,dd\r\naa, bb,cc\r\naa,bb\r\naa";

            
        }

        [TestMethod]
        [TestCategory("GetTopWords")]
        public void TestGetTopWords_FileContentsNotBlankAndContainsValidWords_ValueReturned2Entries()
        {
            //Arrange
            WordCount wc = new WordCount(fc);

            //Act
            var actual = wc.GetTopWords(2);
            var expected = new Dictionary<string, int> { { "aa", 4 }, { "bb", 3 } };

            //Assert
            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);
        }

        [TestMethod]
        [TestCategory("GetTopWords")]
        public void TestGetTopWords_FileContentsBlank_ValueReturnedNull()
        {
            //Arrange
            fc.DataContent = "";
            WordCount wc = new WordCount(fc);

            //Act
            var actual = wc.GetTopWords(2);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        [TestCategory("GetTopWords")]
        public void TestGetTopWords_FileContentsNull_ValueReturnedNull()
        {
            //Arrange
            fc = null;
            WordCount wc = new WordCount(fc);

            //Act
            var actual = wc.GetTopWords(2);

            //Assert
            Assert.IsNull(actual);
        }
    }
}
