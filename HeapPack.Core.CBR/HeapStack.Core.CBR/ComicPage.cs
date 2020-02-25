

using HeapStack.Core.CBR.Models;

namespace HeapStack.Core.CBR {

    public class ComicPage : IComicPage {
        public byte[] Data { set; get; }
        public int Number { set; get; }
        public string Filename { set; get; }
    }

}
