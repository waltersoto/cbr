namespace HeapStack.Core.CBR.Models {
    public interface IComicPage {

        byte[] Data { set; get; }
        int Number { set; get; }
        public string Filename { set; get; }

    }
}
