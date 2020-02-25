using HeapStack.Core.CBR.Models;
using SharpCompress.Readers;
using System.IO;

namespace HeapStack.Core.CBR {
    public class ComicReader : IComicReader {


        public IComicBook Read(string fullFilename) {
            var fi = new FileInfo(fullFilename);
            if (!fi.Exists) throw new IOException($"{fullFilename} is not accessible.");
            return Read(new FileStream(fullFilename, FileMode.Open), fi.Name);
        }

        public IComicBook Read(Stream stream, string name) {

            var comicBook = new ComicBook {
                Name = RemoveExtension(name)
            };

            using (var reader = ReaderFactory.Open(stream, new ReaderOptions())) {
                var pageCount = 0;
                while (reader.MoveToNextEntry()) {
                    using (var ms = new MemoryStream()) {
                        var page = new ComicPage();
                        reader.WriteEntryTo(ms);
                        if (reader.Entry.CompressionType == SharpCompress.Common.CompressionType.None) continue;
                        page.Filename = RemoveDirectoryFromFilename(reader.Entry.Key);
                        page.Number = pageCount++;
                        page.Data = ms.ToArray();
                        comicBook.Pages.Add(page);
                    }

                }
            }
            return comicBook;
        }

        public IComicBook Read(byte[] fileData, string filename) => Read(new MemoryStream(fileData), filename);


        private string RemoveDirectoryFromFilename(string name) {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            return name.Remove(0, name.LastIndexOf('/') + 1);
        }

        private string RemoveExtension(string name) {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            return name.Remove(name.LastIndexOf('.'));
        }

    }

}
