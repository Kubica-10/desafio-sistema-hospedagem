public class Suite
{
    public Suite() { }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }

    // ✨ CORREÇÃO AQUI: Inicializando a propriedade para resolver os avisos.
    public string TipoSuite { get; set; } = string.Empty;
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }
}