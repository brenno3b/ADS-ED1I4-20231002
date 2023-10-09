using ADS_ED1I4_20231002;

Medicamentos _controller = new();

void addMedicamento()
{
    Console.WriteLine("--- Cadastrar medicamento ---");
    Console.WriteLine();

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o nome: ");
    String nome = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Digite o laboratório: ");
    String laboratorio = Console.ReadLine();
    Console.WriteLine();

    Medicamento medicamento = new(id, nome, laboratorio);

    _controller.Adicionar(medicamento);

    Console.WriteLine("Medicamento adicionado.");

    Console.WriteLine("\n--- Fim do cadastro de medicamento ---\n");
}

void getMedicamentoSintetico()
{
    Console.WriteLine("--- Pesquisar medicamento sintético ---");
    Console.WriteLine();

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Medicamento medicamento = _controller.Pesquisar(new(id));

    if (medicamento.Id == -1)
    {
        Console.WriteLine("Medicamento não encontrado.");

        Console.WriteLine("\n--- Fim da pesquisa de medicamento ---\n");
    }

    Console.WriteLine(medicamento.ToString());

    Console.WriteLine("\n--- Fim da pesquisa de medicamento ---\n");
}

void getMedicamentoAnalitico()
{
    Console.WriteLine("--- Pesquisar medicamento analítico ---");
    Console.WriteLine();

    Console.Write("Digite o ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Medicamento medicamento = _controller.Pesquisar(new(id));

    if (medicamento.Id == -1)
    {
        Console.WriteLine("Medicamento não encontrado.");

        Console.WriteLine("\n--- Fim da pesquisa de medicamento ---\n");
    }

    Console.WriteLine(medicamento.ToString());

    foreach (Lote lote in medicamento.Lotes)
    {
        Console.WriteLine(lote.ToString());
    }

    Console.WriteLine("\n--- Fim da pesquisa de medicamento ---\n");
}

void buyMedicamento()
{
    Console.WriteLine("--- Comprar medicamento ---");
    Console.WriteLine();

    Console.Write("Digite o ID do medicamento: ");
    int idMedicamento = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Medicamento medicamento = _controller.Pesquisar(new(idMedicamento));

    if (medicamento.Id == -1)
    {
        Console.WriteLine("Medicamento não encontrado.");

        Console.WriteLine("\n--- Fim da adição de medicamento ---\n");

        return;
    }

    Console.Write("Digite o ID do lote: ");
    int idLote = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite a quantidade: ");
    int qtde = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o dia de vencimento: ");
    int dia = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o mês de vencimento: ");
    int mes = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o ano de vencimento: ");
    int ano = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    DateTime venc = new(ano, mes, dia);

    Lote lote = new(idLote, qtde, venc);

    medicamento.Comprar(lote);

    Console.WriteLine("Lote cadastrado");

    Console.WriteLine("\n--- Fim da compra de medicamento ---\n");
}

void sellMedicamento()
{
    Console.WriteLine("--- Vender medicamento ---");
    Console.WriteLine();

    Console.Write("Digite o ID do medicamento: ");
    int idMedicamento = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Medicamento medicamento = _controller.Pesquisar(new(idMedicamento));

    if (medicamento.Id == -1)
    {
        Console.WriteLine("Medicamento não encontrado.");

        Console.WriteLine("\n--- Fim da adição de medicamento ---\n");

        return;
    }

    Console.Write("Digite a quantidade: ");
    int qtde = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    while (qtde < 1)
    {
        Console.Write("Quantidade inválida !");
        Console.Write("Digite a quantidade: ");
        qtde = Convert.ToInt32(Console.ReadLine());
    }

    bool isSuccess = medicamento.Vender(qtde);

    Console.WriteLine(isSuccess ? "Medicamento vendido !" : "Não foi possível vender o medicamento !");

    Console.WriteLine("\n--- Fim da venda de medicamento ---\n");
}

void getAllMedicamentos()
{
    Console.WriteLine("--- Vender medicamento ---");
    Console.WriteLine();

    foreach (Medicamento medicamento in _controller.ListaMedicamentos)
    {
        Console.WriteLine(medicamento);
    }

    Console.WriteLine("\n--- Fim da venda de medicamento ---\n");
}

while (true)
{
    Console.WriteLine("0. Finalizar processo");
    Console.WriteLine("1. Cadastrar medicamento");
    Console.WriteLine("2. Consultar medicamento (sintético)");
    Console.WriteLine("3. Consultar medicamento (analítico)");
    Console.WriteLine("4. Comprar medicamento");
    Console.WriteLine("5. Vender medicamento");
    Console.WriteLine("6. Listar medicamento");

    Console.WriteLine();

    int option = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (option == 0) break;
    if (option == 1) addMedicamento();
    if (option == 2) getMedicamentoSintetico();
    if (option == 3) getMedicamentoAnalitico();
    if (option == 4) buyMedicamento();
    if (option == 5) sellMedicamento();
    if (option == 6) getAllMedicamentos();
}