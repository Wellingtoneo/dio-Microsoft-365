namespace C_.Models;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome, int NumeroAcompanhantes, int numeroDaSuite)
    {
        Nome = nome;
        Acompanhantes = NumeroAcompanhantes;
        NumeroDaSuite = numeroDaSuite;
    }
    //Construtor não esta sendo usando. 
    public Pessoa(string nome, string sobrenome, int NumeroAcompanhantes, int numeroDaSuite)
    {
        Nome = nome;
        SobreNome = sobrenome;
        Acompanhantes = NumeroAcompanhantes;
        NumeroDaSuite = numeroDaSuite;
    }

    public string  Nome { get; set; }
    public string SobreNome { get; set;}
    public int Acompanhantes {get; set;}
    public int NumeroDaSuite{get; set;}
    public string NomeCompleto => $"{Nome} {SobreNome}".ToUpper();
}
