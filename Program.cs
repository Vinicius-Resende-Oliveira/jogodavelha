using System;
using System.Collections.Generic;
using System.Linq;

namespace jogodavelha
{
    class Program
    {
        private static string[,] grafico = new string[3,3];
        static Velha velha = new Velha();
        static void Main(string[] args)
        {
            
            zerarGrafico();
            Console.Clear();
            Console.WriteLine(imprimirGrafico());

            run();
            
            // string partida = null;
            // int vencedor = 0;
            
            // partida = "x:2,2 o:2,1 x:3,3 o:1,1 x:3,1 o:1,3 x:3,2";
            // vencedor = velha.QuemVenceu(partida);
            // Console.WriteLine("x venceu.: " + (vencedor == -1));
            
            // partida = "x:1,1 o:3,3 x:2,2 o:3,1 x:3,2 o:1,2 x:2,1 x:2,3 x:1,3";
            // vencedor = velha.QuemVenceu(partida);
            // Console.WriteLine("deu velha: " + (vencedor == 0));
            
            // partida = "x:1,1 o:2,3 x:3,3 o:2,2 x:3,1 o:2,1";
            // vencedor = velha.QuemVenceu(partida);
            // Console.WriteLine("o venceu.: " + (vencedor == 1));
        }
        public static string imprimirGrafico(){
            string retorno = "";
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if(c == 0){
                        retorno += " " + grafico[l,c] + " ";
                    }else if(c == 1){
                        retorno += "| " + grafico[l,c] + " |";
                    }else{
                        retorno += " " + grafico[l,c] + " \n";
                    }
                    if(c == 2 && l != 2){
                        retorno += "---|---|---\n";
                    }
                }
            }

            return retorno;
        }

        public static void inserirJogada(string jogada, string jogador){
            var j = jogada.Split(",");
            int linha = int.Parse(j[0]) - 1;
            int coluna = int.Parse(j[1]) - 1;
            grafico[linha, coluna] = jogador;

            return;
        }
        public static void zerarGrafico(){
            for (int i = 0; i < 3; i++)
            {
                for (int c = 0; c < 3; c++)
                {
                    grafico[i,c] = " ";
                }
            }
            return;
        }

        public static void run(){
            string jogador = "";
            string jogada;
            string jogadas = "";
            for (int j = 1; j <= 9; j++)
            {
                if(j%2 == 0){
                    jogador = "o";
                }else{
                    jogador = "x";
                }
                Console.WriteLine("Vez do " + jogador.ToUpper());
                jogada = Console.ReadLine();
                jogadas += jogador + ":" + jogada;
                inserirJogada(jogada, jogador);
                Console.Clear();
                Console.WriteLine(imprimirGrafico());
                if(j > 4 && j < 8){
                    if(velha.QuemVenceu(jogadas) == -1){
                        Console.WriteLine("O jogador X venceu a partida");
                    }else if(velha.QuemVenceu(jogadas) == 1){
                        Console.WriteLine("O jogador O venceu a partida");
                    }
                    
                }else if(j >= 8){
                    if(velha.QuemVenceu(jogadas) == -1){
                        Console.WriteLine("O jogador X venceu a partida");
                    }else if(velha.QuemVenceu(jogadas) == 1){
                        Console.WriteLine("O jogador O venceu a partida");
                    }else{
                        Console.WriteLine("Empate");
                    }
                }
            }
        }
    }
}
