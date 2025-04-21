using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Pilha pilha = new Pilha();
        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("\n===== MENU DA PILHA COLORIDINHA =====");
            Console.WriteLine("1. Inserir na pilha vermelha");
            Console.WriteLine("2. Inserir na pilha preta");
            Console.WriteLine("3. Remover da pilha vermelha");
            Console.WriteLine("4. Remover da pilha preta");
            Console.WriteLine("5. Ver topo da pilha vermelha");
            Console.WriteLine("6. Ver topo da pilha preta");
            Console.WriteLine("7. Verificar se pilhas estão vazias");
            Console.WriteLine("8. Mostrar pilha completa");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o valor para a pilha vermelha: ");
                        object valorVermelho = Console.ReadLine();
                        pilha.PushVermelho(valorVermelho);
                        break;

                    case "2":
                        Console.Write("Digite o valor para a pilha preta: ");
                        object valorPreto = Console.ReadLine();
                        pilha.PushPreto(valorPreto);
                        break;

                    case "3":
                        Console.WriteLine($"Removido da pilha vermelha: {pilha.PopVermelho()}");
                        break;

                    case "4":
                        Console.WriteLine($"Removido da pilha preta: {pilha.PopPreto()}");
                        break;

                    case "5":
                        Console.WriteLine($"Topo da pilha vermelha: {pilha.TopVermelho()}");
                        break;

                    case "6":
                        Console.WriteLine($"Topo da pilha preta: {pilha.TopPreto()}");
                        break;

                    case "7":
                        Console.WriteLine($"Pilha vermelha está vazia? {pilha.IsEmptyVermelho()}");
                        Console.WriteLine($"Pilha preta está vazia? {pilha.IsEmptyPreto()}");
                        break;

                    case "8":
                        pilha.MostrarPilhaColoridinha();
                        break;

                    case "0":
                        rodando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                // Após cada operação, verificar redução
                pilha.VerificarReducaoTamanho();
            }
            catch (ExcecoesDePilha ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        Console.WriteLine("Programa encerrado coleguinha");
    }
}
