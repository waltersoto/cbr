namespace HeapStack.Core.CBR.Models {
    public interface IComicPage {

        byte[] Data { set; get; }
        int Number { set; get; }
        string Filename { set; get; }

    }
}
