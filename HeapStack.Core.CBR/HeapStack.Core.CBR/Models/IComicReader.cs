using System.IO;

namespace HeapStack.Core.CBR.Models {
    public interface IComicReader {

        IComicBook Read(string filename);

        IComicBook Read(Stream filename);

        IComicBook Read(byte[] filename);

    }
}
