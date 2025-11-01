using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        // Cria o construtor da aplicação (equivalente a "app = Flask(__name__)")
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Constrói a aplicação
        WebApplication app = builder.Build();

        // Define a rota principal (equivalente a "@app.route('/')")
        app.MapGet("/", () => "Hello, world! This is the home route.");

        // Executa a aplicação (equivalente a "app.run(debug=True)")
        app.Run();
    }
}