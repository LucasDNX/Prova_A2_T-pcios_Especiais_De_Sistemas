namespace Joao;

public class Funcionario
{
    public Funcionario(int funcionarioId, string nome, string cpf)
    {
        FuncionarioId = funcionarioId;
        Nome = nome;
        Cpf = cpf;
    }

    //Atributo ou propriedade - nome e descricao
    public int FuncionarioId { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public Folha folha { get; set; }
}
