using BookStoreApiASP.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookStoreContext>();
/*builder.Services.AddDatabaseDeveloperPage();*/
var app = builder.Build();

app.MapGet("/books", GetBooks);
List<Book> GetBooks(BookStoreContext db)
{
    return db.Books.ToList();
}

app.MapGet("/book/{id}", GetBookId);


IResult GetBookId(int id, BookStoreContext bookStoreContext)
{
    var book = bookStoreContext.Books.FirstOrDefault(x => x.Id == id);
    if(book == null)
        return Results.NotFound();
    else
        return Results.Ok(book);
}

app.MapPost("/BookItem", AddNewBook);
IResult AddNewBook(Book book, BookStoreContext db)
{
    try
    {
        db.Books.Add(book);
        db.SaveChanges();
        return Results.Ok();
    }
    catch
    {
        return Results.BadRequest();
    }
}
app.MapPut("book/{id}", EditBook);
IResult EditBook(int id, Book InputBook, BookStoreContext db)
{
    var book = db.Books.Find(id);
    if(book == null)
        return Results.NotFound();
    book.Title = InputBook.Title;
    book.Author = InputBook.Author;
    book.PagesCount = InputBook.PagesCount;
    book.Price = InputBook.Price;
    db.Books.Add(book);
    db.SaveChanges();
    return Results.Ok();
}
app.MapDelete("book/{id}", DeleteBook);
IResult DeleteBook(int id, BookStoreContext db)
{
    var book = db.Books.Find(id);
    if (book == null)
        return Results.NotFound();
    db.Books.Remove(book);
    db.SaveChanges();
    return Results.Ok();
}
/*____________________________________________________________________________________________________*/
app.Run();
