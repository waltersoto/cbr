using HeapStack.Core.CBR.Models;
using System.Collections.Generic;

namespace HeapStack.Core.CBR {
    public class ComicBook : IComicBook {

        public ComicBook() {
            Pages = new List<IComicPage>();
        }

        public string Name { set; get; }
        public IList<IComicPage> Pages { set; get; }

    }
}
