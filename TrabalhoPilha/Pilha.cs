using System;
using System.Collections.Generic;


public class Pilha : IPilha
{
    // ATRIBUTOS
    public int N { get; set; }
    public int VermelhoT { get; set; }
    public int PretoT { get; set; }
    public object[] PilhaColoridinha { get; set; }

    // CONSTRUTOR
    public Pilha()
    {
        N = 1;            // N = Tamanho Inicial da plha
        VermelhoT = -1;   // Posição inicial fora do array
        PretoT = N;       // Posição inicial fora do array
        PilhaColoridinha = new object[N];   // Por padrão, é preenchido com null
    }

    // MÉTODOS DA PILHA PRETA
    public bool IsEmptyPreto()  // Verifica se a pilha preta esta vazia
    {
        return PretoT == N ? true : false;  // A pilha esta vazia?
    }
    public object TopPreto()   // Retorna o elemento do topo da pilha petra
    {
        if(!IsEmptyPreto())
        {
            return PilhaColoridinha[PretoT];
        }
        else 
        {
            throw new ExcecoesDePilha("A pilha preta esta vazia");
        }
    }
    public object PopPreto()
    {
        if(!IsEmptyPreto())
        {
            object pop = PilhaColoridinha[PretoT];  // Pega o valor do topo
            PilhaColoridinha[PretoT] = null;  // Apaga o valor
            PretoT++;   // Volta o "ponteiro" da Pilha preta (novo topo)
            VerificarReducaoTamanho();
            return pop; // Retorna o valor
        }
        else 
        {
            throw new ExcecoesDePilha("A pilha preta esta vazia");
        }
    }
    public int SizePreto()
    {
        if(!IsEmptyPreto())
        {
            return N - PretoT;
        }
        else 
        {
            return 0;
        }
    }
    public void PushPreto(object o)
    {
        // Verificar se o array esta cheio
        VerificarPilhaCheia();

        // Adiciona o elemento
        PretoT--;
        PilhaColoridinha[PretoT] = o;
    }


    // MÉTODOS DA PILHA VERMELHA
    public bool IsEmptyVermelho()  // Verifica se a pilha vermelha esta vazia
    {
        return VermelhoT == -1 ? true : false;  // A pilha esta vazia?
    }
    public object TopVermelho()   // Retorna o elemento do topo da pilha vermelha
    {
        if(!IsEmptyVermelho())
        {
            return PilhaColoridinha[VermelhoT];
        }
        else 
        {
            throw new ExcecoesDePilha("A pilha vermelha esta vazia");
        }
    }
    public object PopVermelho()
    {
        if(!IsEmptyVermelho())
        {
            object pop = PilhaColoridinha[VermelhoT];  // Pega o valor do topo
            PilhaColoridinha[VermelhoT] = null;  // Apaga o valor
            VermelhoT--;   // Volta o "ponteiro" da Pilha preta (novo topo)
            VerificarReducaoTamanho();
            return pop; // Retorna o valor
        }
        else 
        {
            throw new ExcecoesDePilha("A pilha vermelha esta vazia");
        }
    }
    public int SizeVermelho()
    {
        if(!IsEmptyVermelho())
        {
            return VermelhoT + 1;
        }
        else 
        {
            return 0;
        }
    }
    public void PushVermelho(object o)
    {
        // Verificar se o array esta cheio
        VerificarPilhaCheia();

        // Adiciona o elemento
        VermelhoT++;
        PilhaColoridinha[VermelhoT] = o;
    }

    // MÉTODOS GERIAS
    public void VerificarPilhaCheia()
    {
        if (SizePreto() + SizeVermelho() == N)  // Se a pilha estiver cheia
        {
            int NovoN = N * 2;  // Novo tamanho do array
            object[] ArrayTemporario = new object[NovoN];

            // Copiar elementos da pilha vermelha
            for (int Itemvermelho = 0; Itemvermelho <= VermelhoT; Itemvermelho++)
            {
                ArrayTemporario[Itemvermelho] = PilhaColoridinha[Itemvermelho];
            }

            int TempNovoN = NovoN; // copia do topo do novo array
            for (int ItemPreto = PretoT; ItemPreto < N; ItemPreto++)
            {
                TempNovoN--;
                ArrayTemporario[TempNovoN] = PilhaColoridinha[ItemPreto];
            }

            // Atualiza as variáveis
            PretoT = TempNovoN;  // novo topo da pilha preta
            N = NovoN;
            PilhaColoridinha = ArrayTemporario;
        }
    }
    public void VerificarReducaoTamanho()
    {
        if (N > 1 && SizePreto() + SizeVermelho() <= N/3)  // Se a pilha estiver com um terço de ultilização
        {
            int NovoN = N / 2;  // Novo tamanho do array
            object[] ArrayTemporario = new object[NovoN];

            // Copiar elementos da pilha vermelha
            for (int Itemvermelho = 0; Itemvermelho <= VermelhoT; Itemvermelho++)
            {
                ArrayTemporario[Itemvermelho] = PilhaColoridinha[Itemvermelho];
            }

            int TempNovoN = NovoN; // copia do topo do novo array
            for (int ItemPreto = PretoT; ItemPreto < N; ItemPreto++)
            {
                TempNovoN--;
                ArrayTemporario[TempNovoN] = PilhaColoridinha[ItemPreto];
            }

            // Atualiza as variáveis
            PretoT = TempNovoN;  // novo topo da pilha preta
            N = NovoN;
            PilhaColoridinha = ArrayTemporario;
        }
    }
    public void MostrarPilhaColoridinha()
    {
        Console.WriteLine("=== PILHA COLORIDINHA ===");

        // Índices
        Console.Write("Índice:   ");
        for (int i = 0; i < N; i++)
        {
            Console.Write($"{i,5}");
        }
        Console.WriteLine();

        // Conteúdo
        Console.Write("Conteúdo: ");
        for (int i = 0; i < N; i++)
        {
            if (i <= VermelhoT)
            {
                Console.ForegroundColor = ConsoleColor.Red; // vermelho
            }
            else if (i >= PretoT)
            {
                Console.ForegroundColor = ConsoleColor.Gray; // preto (cinza)
            }
            else
            {
                Console.ResetColor(); // meio
            }

            string conteudo = PilhaColoridinha[i]?.ToString() ?? "-";
            Console.Write($"{conteudo,5}");

            Console.ResetColor(); // volta ao normal após cada elemento
        }
        Console.WriteLine();

        // Topos
        Console.Write("Topo:     ");
        for (int i = 0; i < N; i++)
        {
            if (i == VermelhoT && i == PretoT)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{ "VP",5}");
            }
            else if (i == VermelhoT)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{ "V",5}");
            }
            else if (i == PretoT)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{ "P",5}");
            }
            else
            {
                Console.Write($"{ "",5}");
            }
            Console.ResetColor();
        }

        Console.WriteLine();
        Console.WriteLine("==========================\n");
    }

}