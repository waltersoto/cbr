using HeapStack.Core.CBR.Models;
using SharpCompress.Readers.Rar;
using System.IO;

namespace HeapStack.Core.CBR {
    public class ComicReader : IComicReader {


        public IComicBook Read(string filename) {
            if (!File.Exists(filename)) throw new IOException($"{filename} is not accessible.");
            return Read(new FileStream(filename, FileMode.Open));
        }

        public IComicBook Read(Stream stream) {

            var comicBook = new ComicBook();

            using (var reader = RarReader.Open(stream, new SharpCompress.Readers.ReaderOptions())) {
                var pageCount = 0;
                while (reader.MoveToNextEntry()) {
                    using (var ms = new MemoryStream()) {
                        var page = new ComicPage();
                        reader.WriteEntryTo(ms);
                        page.Filename = reader.Entry.Key;
                        page.Number = pageCount++;
                        page.Data = ms.ToArray();
                        comicBook.Pages.Add(page);
                    }

                }
            }
            return comicBook;
        }

        public IComicBook Read(byte[] fileData) => Read(new MemoryStream(fileData));
    }

}
