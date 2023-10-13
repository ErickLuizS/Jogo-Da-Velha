using System;

class JogoDaVelha
{
    private char[] tabuleiro;
    private char jogadorAtual;
    private bool jogoAtivo;

    public JogoDaVelha()
    {
        tabuleiro = new char[9];
        jogadorAtual = 'X';
        jogoAtivo = true;

        // Inicializa o tabuleiro com espaços em branco
        for (int i = 0; i < 9; i++)
        {
            tabuleiro[i] = ' ';
        }
    }

    public void Jogar()
    {
        while (jogoAtivo)
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.WriteLine($"Vez do jogador {jogadorAtual}. Escolha uma posição (1-9): ");

            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= 9 && tabuleiro[escolha - 1] == ' ')
            {
                tabuleiro[escolha - 1] = jogadorAtual;
                if (VerificarVitoria())
                {
                    Console.Clear();
                    MostrarTabuleiro();
                    Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                    jogoAtivo = false;
                }
                else if (tabuleiro.All(p => p != ' '))
                {
                    Console.Clear();
                    MostrarTabuleiro();
                    Console.WriteLine("Empate!");
                    jogoAtivo = false;
                }
                else
                {
                    jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                }
            }
        }
    }

    private bool VerificarVitoria()
    {
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i] != ' ' && tabuleiro[i] == tabuleiro[i + 3] && tabuleiro[i] == tabuleiro[i + 6])
            {
                return true; // Verificação vertical
            }
        }

        for (int i = 0; i < 9; i += 3)
        {
            if (tabuleiro[i] != ' ' && tabuleiro[i] == tabuleiro[i + 1] && tabuleiro[i] == tabuleiro[i + 2])
            {
                return true; // Verificação horizontal
            }
        }

        if (tabuleiro[0] != ' ' && tabuleiro[0] == tabuleiro[4] && tabuleiro[0] == tabuleiro[8])
        {
            return true; // Verificação diagonal (esquerda para direita)
        }

        if (tabuleiro[2] != ' ' && tabuleiro[2] == tabuleiro[4] && tabuleiro[2] == tabuleiro[6])
        {
            return true; // Verificação diagonal (direita para esquerda)
        }

        return false;
    }

    private void MostrarTabuleiro()
    {
        Console.WriteLine($"{tabuleiro[0]} | {tabuleiro[1]} | {tabuleiro[2]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{tabuleiro[3]} | {tabuleiro[4]} | {tabuleiro[5]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{tabuleiro[6]} | {tabuleiro[7]} | {tabuleiro[8]}");
    }
}

class Program
{
    static void Main()
    {
        JogoDaVelha jogo = new JogoDaVelha();
        jogo.Jogar();
    }
}
