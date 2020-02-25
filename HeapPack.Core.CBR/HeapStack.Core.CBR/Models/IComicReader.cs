using System.IO;

namespace HeapStack.Core.CBR.Models {
    public interface IComicReader {

        IComicBook Read(string filename);

        IComicBook Read(Stream fileStream, string filename);

        IComicBook Read(byte[] fileData, string filename);

    }
}
