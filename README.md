# CBR 0.1
CBR reader library for .NET Standard 2.0

Open and navigate a digital comic book archive in .CBR and .CBZ formats.

Example:

  ```csharp
    var reader = new ComicReader();
    var book = reader.Read(@"[fullpath].cbr");
    
    Console.WriteLine(book.Name);
    
    foreach(var page in book.Pages){
      Console.WriteLine(page.Number);
    }
  ```

