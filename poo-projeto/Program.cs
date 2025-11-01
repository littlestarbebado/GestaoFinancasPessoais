using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MiniLojaOnline;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); 

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles(); 


List<Product> produtos = new List<Product>
{
    new Product(1, "Camiseta", 19.99m),
    new Product(2, "Calça Jeans", 49.99m),
    new Product(3, "Tênis Esportivo", 89.99m)
};


app.MapGet("/products", () => produtos);

app.Run();