namespace Joao;

public class Funcionario
{
    public Funcionario()
    {
        FuncionarioId = Guid.NewGuid().ToString();
    }

    public Funcionario(string nome, string cpf)
    {
        FuncionarioId = Guid.NewGuid().ToString();
        Nome = nome;
        Cpf = cpf;
    }

    //Atributo ou propriedade - nome e descricao
    public string FuncionarioId { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public Folha folha { get; set; }
}
