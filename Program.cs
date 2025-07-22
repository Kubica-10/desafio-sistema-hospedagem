// --- APLICAÇÃO PRINCIPAL DO HOTEL CÓDIGO-FONTE ---

// Cria uma lista de suítes disponíveis no hotel.
// No mundo real, isso viria de um banco de dados.
List<Suite> suitesDisponiveis = new List<Suite>
{
    new Suite(tipoSuite: "Standard", capacidade: 2, valorDiaria: 150),
    new Suite(tipoSuite: "Luxo", capacidade: 3, valorDiaria: 250),
    new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 400)
};

Console.WriteLine("*********************************");
Console.WriteLine("* BEM-VINDO AO HOTEL CÓDIGO-FONTE *");
Console.WriteLine("*********************************");

// Loop principal do menu
bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("\n--- MENU PRINCIPAL ---");
    Console.WriteLine("1 - Realizar Nova Reserva");
    Console.WriteLine("2 - Sair do Sistema");
    Console.Write("Digite sua opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            // Chama o método que cuida de todo o processo de reserva
            RealizarReserva();
            break;

        case "2":
            // Altera a variável para false, quebrando o laço 'while'
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar...");
    Console.ReadLine();
}

Console.WriteLine("\nObrigado por utilizar o sistema. Volte sempre!");


// --- MÉTODO PARA REALIZAR A RESERVA ---
// Separamos toda a lógica em um método para deixar o menu principal mais limpo.
void RealizarReserva()
{
    Console.Clear();
    Console.WriteLine("--- NOVA RESERVA ---");

    // --- PASSO 1: CADASTRO DOS HÓSPEDES ---
    Console.Write("Quantos hóspedes serão? ");
    int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());

    List<Pessoa> hospedes = new List<Pessoa>();
    for (int i = 1; i <= quantidadeHospedes; i++)
    {
        Console.WriteLine($"\nDados do {i}º hóspede:");
        Console.Write("Nome: ");
        string nomeHospede = Console.ReadLine() ?? string.Empty;
        Console.Write("Sobrenome: ");
        string sobrenomeHospede = Console.ReadLine() ?? string.Empty;
        hospedes.Add(new Pessoa(nome: nomeHospede, sobrenome: sobrenomeHospede));
    }

    // --- PASSO 2: ESCOLHA DA SUÍTE ---
    Console.WriteLine("\n--- Escolha da Suíte ---");
    // Mostra as suítes que comportam o número de hóspedes
    for (int i = 0; i < suitesDisponiveis.Count; i++)
    {
        if (suitesDisponiveis[i].Capacidade >= quantidadeHospedes)
        {
            Console.WriteLine($"{i + 1} - Suíte {suitesDisponiveis[i].TipoSuite} (Capacidade: {suitesDisponiveis[i].Capacidade}, Diária: R$ {suitesDisponiveis[i].ValorDiaria:F2})");
        }
    }
    
    Console.Write("Escolha uma suíte pelo número: ");
    int escolhaSuite = Convert.ToInt32(Console.ReadLine()) - 1; // Subtrai 1 para pegar o índice correto da lista
    Suite suiteEscolhida = suitesDisponiveis[escolhaSuite];


    // --- PASSO 3: DADOS DA RESERVA ---
    Console.WriteLine("\n--- Detalhes da Reserva ---");
    Console.Write("Quantos dias de reserva? ");
    int diasReservados = Convert.ToInt32(Console.ReadLine());

    Reserva reserva = new Reserva(diasReservados: diasReservados);
    reserva.CadastrarSuite(suiteEscolhida);
    reserva.CadastrarHospedes(hospedes);


    // --- PASSO 4: EXIBIÇÃO DO RESUMO ---
    Console.WriteLine("\n=========================");
    Console.WriteLine("    RESERVA CONFIRMADA   ");
    Console.WriteLine("=========================");
    Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
    Console.WriteLine($"Hóspedes: {string.Join(", ", reserva.Hospedes.Select(h => h.NomeCompleto))}");
    Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
    Console.WriteLine("-------------------------");
    Console.WriteLine($"Valor Total: R$ {reserva.CalcularValorDiaria():F2}");
    if (diasReservados >= 10)
    {
        Console.WriteLine("(Desconto de 10% aplicado!)");
    }
    Console.WriteLine("=========================");
}