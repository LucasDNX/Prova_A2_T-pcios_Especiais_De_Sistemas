namespace Joao;

public class Folha
{
    public Folha()
    {
        FolhaId = Guid.NewGuid().ToString();
    }

    public Folha(float valor, int quantidade, int mes, int ano, string funcionarioId )
    {
        FolhaId = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        SalarioBruto = Valor * Quantidade;
        FuncionarioId = funcionarioId;
    }

    public string FolhaId { get; set; }
    public float Valor { get; set; }
    public int Quantidade { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
    public float SalarioBruto { get; set; }
    public float ImpostoIRRF { get; set; }
    public float ImpostoINSS { get; set; }
    public float ImpostoFGTS { get; set; }
    public float SalarioLiquido { get; set; }
    public Funcionario Funcionario { get; set; } 
    public string FuncionarioId { get; set; }

    public void CalculaIRRF()
    {
         if(this.SalarioBruto >= 1903.33 && this.SalarioBruto <= 2826.65)
            ImpostoIRRF = (this.SalarioBruto * 1.075f) - this.SalarioBruto;

        if(this.SalarioBruto >= 2826.66 && this.SalarioBruto <= 3751.05)
            ImpostoIRRF = (this.SalarioBruto * 1.15f) - this.SalarioBruto;

        if(this.SalarioBruto >= 3751.06 && this.SalarioBruto <= 4664.68)
            ImpostoIRRF = (this.SalarioBruto * 1.15f) - this.SalarioBruto;

        if(this.SalarioBruto > 4664.68)
            ImpostoIRRF = (this.SalarioBruto * 1.275f) - this.SalarioBruto;

        if(this.SalarioBruto <= 1903.98)
            ImpostoIRRF = 0;
    }

    public void CalculaINSS()
    {
        if(this.SalarioBruto <= 1693.72){}
            this.ImpostoINSS = (this.SalarioBruto * 1.08f) - this.SalarioBruto;

        if(this.SalarioBruto >= 1693.73 && this.SalarioBruto <= 2822.90)
            this.ImpostoINSS = (this.SalarioBruto * 1.09f) - this.SalarioBruto;

        if(this.SalarioBruto >= 2822.91 && this.SalarioBruto <= 5645.80)
            this.ImpostoINSS = (this.SalarioBruto * 1.11f) - this.SalarioBruto;

        if(this.SalarioBruto >5645.81)
            this.ImpostoINSS = 621.03f;
    }

    public void CalculaFGTS()
    {
        ImpostoFGTS = (this.SalarioBruto * 1.08f) - this.SalarioBruto;
    }

    public void CalculaSalarioLiquido()
    {
        this.SalarioLiquido = this.SalarioBruto - this.ImpostoIRRF - this.ImpostoINSS;
    }
}
