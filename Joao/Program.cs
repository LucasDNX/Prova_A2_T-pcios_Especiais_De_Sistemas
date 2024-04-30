using Joao;
//using Joao.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();


app.MapPost("/api/funcionario/cadastrar/", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext context) =>
{
    context.Funcionarios.Add(funcionario);
    context.SaveChanges();
    return Results.Created("", funcionario);
}
);


app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionarios.Any())
        return Results.Ok(context.Funcionarios.ToList());

    return Results.NotFound("Não existe(m) funcionario(s) na tabela");
});



app.MapPost("/api/folha/cadastrar/", ([FromBody] Folha folha, [FromServices] AppDataContext context) =>
{
    folha.CalculaIRRF();
    folha.CalculaINSS();
    folha.CalculaFGTS();
    folha.CalculaSalarioLiquido();

    Funcionario? funcionario = context.Funcionarios.FirstOrDefault(x => x.FuncionarioId == folha.FuncionarioId);
    if (folha is null)
        return Results.NotFound(string.Format("Funcionario não encontrado para o ID mencionado"));

    folha.SetarFuncionario(funcionario);

    context.Folhas.Add(folha);
    context.SaveChanges();
    return Results.Created("", folha);
}
);


app.MapGet("/api/folha/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Folhas.Any())
        return Results.Ok(context.Folhas.ToList());

    return Results.NotFound("Não existe(m) folhas(s) na tabela");
});


app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, int mes, int ano, [FromServices] AppDataContext context) =>
{
    Folha? folha = context.Folhas.FirstOrDefault(x => x.Funcionario.Cpf == cpf && x.Mes == mes && x.Ano == ano);

    if (folha is null)
        return Results.NotFound(string.Format("Produto não encontrado {0}", cpf));

    return Results.Ok(folha);
});


app.Run();
