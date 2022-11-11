var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<LibraryQuery>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

public record Book(string Title, Author Author);
public record Author(string Name);
