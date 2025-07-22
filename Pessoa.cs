public class Pessoa
{
    public Pessoa() { }

    // ✨ CORREÇÃO AQUI: O construtor agora aceita os dois parâmetros.
    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    // ✨ CORREÇÃO AQUI: Inicializando as propriedades para resolver os avisos.
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}