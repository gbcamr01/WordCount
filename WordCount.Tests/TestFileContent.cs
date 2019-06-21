using System;
using FileProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Collections;
using System.IO;


namespace WordCount.Tests
{
    [TestClass]
    public class TestFileContent
    {
        string fileName = $"{Environment.CurrentDirectory}\\TestFileContent.txt";

        [TestMethod]
        [TestCategory("GetFileContents")]
        public void TestGetFileContents_FileNameNotBlankAndContainsData_ValueReturnedData()
        {
            //Arrange
            IFileContent fc = new FileContent(fileName);

            //Act
            var actual = fc.DataContent;
            var expected = @"aa,bb,cc,dd
aa,bb,cc
aa,bb
aa";

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("GetFileContents")]
        public void TestGetFileContents_FileNameBlank_ValueReturnedNull()
        {
            //Arrange
            fileName = null;
            IFileContent fc = new FileContent(fileName);

            //Act
            var actual = fc.DataContent;
            

            //Assert
            Assert.IsNull(actual);
        }

        
    }
}
