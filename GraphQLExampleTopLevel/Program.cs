var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<LibraryQuery>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

public record Book(string Title, Author Author);
public record Author(string Name);

public class LibraryQuery
{
    readonly List<Book> _books = new()
    {
        new Book("I love graphql", new Author("Brandom")),
        new Book("The pilars of the world", new Author("Example")),
        new Book("I love the examples of mavericks", new Author("Sergio Triana Escobedo"))
    };

    public List<Book?> GetBooks() => _books;

    public Book? GetBook(string title) => _books.FirstOrDefault(x => x.Title == title);
}