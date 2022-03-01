using System;
using System.IO;
namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            int sair = 1;
            string jogador1 , jogador2 ;
            int fim = 0, vencedor = 3;
            string posicao = "10", posicao1 = "10";
            bool jogar = true;
            int jogadas = 0;

            string Menu()
            {
                Console.Title = "Jogo da Velha";

                Console.WriteLine("\t\t\t\t----------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t--------------------------Jogo da Velha-------------------------");
                Console.WriteLine("\t\t\t\t----------------------------------------------------------------\n");

                Console.WriteLine("\t\t\t\t\t\t 1 - Comecar jogo ");
                Console.WriteLine("\t\t\t\t\t\t 2 - Para Sair\n ");
                Console.Write("\t\t\t\t\t Opcao :");
                string opcao = Console.ReadLine();

                return opcao;
            }

            void Inicio()
            {

                Console.WriteLine("\t\t\t\t----------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t--------------------------  Jogadores  -------------------------");
                Console.WriteLine("\t\t\t\t----------------------------------------------------------------\n");
                Console.Write("\t\t\t\t  Digite o nome que jogador sera  X:  ");
                jogador1 = Console.ReadLine();

                Console.Write("\n\t\t\t\t  Digite o nome que jogador  sera  O:  ");
                jogador2 = Console.ReadLine();


            }

            void Matriz()
            {

                Console.WriteLine("\t\t\t\t----------------------Jogo da velha------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t--------" + jogador1 + " - X -------------" + jogador2 + " - O --------------\n");

                Console.WriteLine($"\t\t\t\t\t\t     |     |      ");
                Console.WriteLine($"\t\t\t\t\t\t  {matriz[0, 0]}  |  {matriz[0, 1]}  |  {matriz[0, 2]}");
                Console.WriteLine("\t\t\t\t\t\t_____|_____|_____ ");
                Console.WriteLine("\t\t\t\t\t\t     |     |      ");
                Console.WriteLine($"\t\t\t\t\t\t  {matriz[1, 0]}  |  {matriz[1, 1]}  |  {matriz[1, 2]}");
                Console.WriteLine("\t\t\t\t\t\t_____|_____|_____ ");
                Console.WriteLine("\t\t\t\t\t\t     |     |      ");
                Console.WriteLine($"\t\t\t\t\t\t  {matriz[2, 0]}  |  {matriz[2, 1]}  |  {matriz[2, 2]}");
                Console.WriteLine("\t\t\t\t\t\t     |     |      ");


                Console.WriteLine("\t\t\t\t-----------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t-----------------------------------------------------------------");


            }

            void Jogo()
            {
                do
                {
                    Console.Clear();
                    Matriz();
                    int anterior = jogadas;

                    if (jogar)
                    {
                        Console.Write("\n\t\t\t\t\t" + jogador1 + " Digite um numero que deseja substituir por X : ");
                        posicao = Console.ReadLine();

                        for (int linha = 0; linha < matriz.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                            {
                                if (posicao.CompareTo(matriz[linha, coluna]) == 0 && posicao.CompareTo("O") != 0 && posicao.CompareTo("X") != 0)
                                {
                                    jogar = false;
                                    jogadas++;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.Write("\n\t\t\t\t\t" + jogador2 + " Digite um numero que deseja substituir por  O : ");
                        posicao1 = Console.ReadLine();
                        for (int linha = 0; linha < matriz.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                            {
                                if (posicao1.CompareTo(matriz[linha, coluna]) == 0 && posicao1.CompareTo("X") != 0 && posicao1.CompareTo("0") != 0)
                                {
                                    jogar = true;
                                    jogadas++;
                                }
                            }
                        }
                    }

                    if (jogadas > anterior)
                    {

                        for (int linha = 0; linha < matriz.GetLength(0); linha++)
                        {
                            for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                            {
                                if (posicao.CompareTo(matriz[linha, coluna]) == 0)
                                {
                                    string suporte = "X";
                                    matriz[linha, coluna] = suporte;
                                }


                                if (posicao1.CompareTo(matriz[linha, coluna]) == 0)
                                {
                                    string suporte = "O";
                                    matriz[linha, coluna] = suporte;

                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    Console.Clear();
                    if (jogadas > 4)
                    {
                        Status();
                        Resultado();
                    }


                } while (fim != 1);

                fim = 0;

            }

            void Status()
            {
                int linha;
                int coluna = 0;
                //Verificação de linha
                for (linha = 0; linha < matriz.GetLength(0); linha++)
                {
                   
                    if (matriz[linha, coluna].CompareTo(matriz[linha, coluna + 1]) == 0 && matriz[linha, coluna + 1].CompareTo(matriz[linha, coluna + 2]) == 0)
                    {
                        if (matriz[linha, coluna] == "X")
                        {
                            vencedor = 1;
                        }
                        else
                        {
                            vencedor = 2;
                        }
                    }
                }

                linha = 0;
                //Verificação  da coluna
                for (coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                   
                    if (matriz[linha, coluna].CompareTo(matriz[linha + 1, coluna]) == 0 && matriz[linha + 1, coluna].CompareTo(matriz[linha + 2, coluna]) == 0)
                    {
                        if (matriz[linha, coluna] == "X")
                        {
                            vencedor = 1;
                        }
                        else
                        {
                            vencedor = 2;
                        }
                    }
                }

                linha = 0;
                coluna = 0;

                // Diagonal principal
                if (matriz[linha, coluna].CompareTo(matriz[linha + 1, coluna + 1]) == 0 && matriz[linha + 1, coluna + 1].CompareTo(matriz[linha + 2, coluna + 2]) == 0)
                {
                    if (matriz[linha, coluna] == "X")
                    {
                        vencedor = 1;
                    }
                    else
                    {
                        vencedor = 2;
                    }
                }
                // Diagonal segundario
                else if (matriz[linha, coluna + 2].CompareTo(matriz[linha + 1, coluna + 1]) == 0 && matriz[linha + 1, coluna + 1].CompareTo(matriz[linha + 2, coluna]) == 0)
                {

                    if (matriz[linha, coluna + 2] == "X")
                    {
                        vencedor = 1;
                    }
                    else
                    {
                        vencedor = 2;
                    }
                }

                else if (jogadas > 8)
                {
                    vencedor = 0;
                }

            }

            void Resultado()
            {
                Matriz();
                if (vencedor == 1)
                {
                    Console.WriteLine("\n\t\t\t\t O jogo acabou o vencedor eh " + jogador1 );

                }
                else if (vencedor == 2)
                {
                    Console.WriteLine("\n\t\t\t\t O jogo acabou o vencedor eh " + jogador2 );

                }
                else if (vencedor == 0)
                {
                    Console.WriteLine("\n\t\t\t\t O jogo acabou Empatado ");

                }

                if (vencedor < 3)
                {
                    Console.Write("\n\t\t\t\tReiniciar a Partida aperte 1 pasa sair qualquer tecla : ");
                    string reiniciar = Console.ReadLine();

                    if (reiniciar == "1")
                    {
                        fim = 0;
                    }
                    else
                    {
                        fim = 1;
                    }

                    Resetar();
                }
            }

            void Resetar()
            {
                matriz[0, 0] = "1";
                matriz[0, 1] = "2";
                matriz[0, 2] = "3";
                matriz[1, 0] = "4";
                matriz[1, 1] = "5";
                matriz[1, 2] = "6";
                matriz[2, 0] = "7";
                matriz[2, 1] = "8";
                matriz[2, 2] = "9";
                vencedor = 3;
                jogadas = 0;
                jogar = true;
                posicao = "50";
                posicao1 = "50";

            }

            do
            {
                switch (Menu())
                {
                    case "1":
                        Console.Clear();
                        Inicio();
                        Jogo();
                        break;
                    case "2":
                        sair = 0;
                        break;
                    default:
                        Console.WriteLine("\t\t\t\t>>>>>>>>>>Ops!! Opcao invalida<<<<<<<<<<<<\n");
                        break;
                }

            } while (sair != 0);
        }
    }
}
