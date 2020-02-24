
using System.Collections.Generic;

namespace HeapStack.Core.CBR.Models {
    public interface IComicBook {
        string Name { set; get; }
        IList<IComicPage> Pages { set; get; }
    }
}
