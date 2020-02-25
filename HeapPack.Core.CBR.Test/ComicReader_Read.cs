using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HeapStack.Core.CBR.Test {
    [TestClass]
    public class ComicReader_Read {

        private ComicReader reader;
        private string localTestFile;

        [TestInitialize]
        public void TestInitialize() {
            if (reader == null) {
                reader = new ComicReader();
                localTestFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestData\SampleCbr.cbr");
            }
        }

        [TestMethod]
        [DeploymentItem(@"TestData\SampleCbr.cbr", "targetFolder")]
        public void OpenFileTest() {

            var comicBook = reader.Read(localTestFile);

            Assert.IsNotNull(comicBook);
            Assert.AreEqual("SampleCbr", comicBook.Name);
            Assert.IsTrue(comicBook.Pages.Count == 4);
        }


    }
}
