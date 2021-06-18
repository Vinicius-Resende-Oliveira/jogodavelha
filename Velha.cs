using System;
using System.Collections.Generic;
using System.Linq;

namespace jogodavelha
{
  public class Velha
  {

    /// <summary>
    ///
    ///   O método analisa o registro de uma partida de jogo da velha e determina
    ///   quem venceu.
    ///
    /// </summary>
    ///
    /// <param name="partida">
    ///
    ///   A partida é registrada numa sequência de coordenadas separadas por
    ///   espaços:
    ///   
    ///     "x:2,2 o:2,1 x:3,3 o:1,1 x:3,1 o:1,3 x:3,2"
    ///       
    ///   Cada coordenada é formada da seguinte forma:
    ///   
    ///     - O símbolo do jogador seguido de dois pontos: 'x:' ou 'o:'
    ///     - A coordenada da linha e da coluna escolhida pelo jogador.
    ///       Os índices das linhas e das colunas variam entre 1 e 3.
    ///
    /// </param>
    /// 
    /// <returns>
    ///
    ///   O resultado é um inteiro identificando o empate ou o jogador vencedor da
    ///   seguinte forma:
    ///     -1  O jogador 'x' venceu a partida.
    ///      0  Nenhum jogador venceu a partida.
    ///      1  O jogador 'o' venceu a partida. 
    ///
    /// </returns>
    public int QuemVenceu(string partida)
    {
      var jogadas = partida.Split(' ');
      var jogadasX = jogadas.Where(x => x.Contains("x")).Select(jogadasX => jogadasX.Substring(2));
      var jogadasO = jogadas.Where(x => x.Contains("o")).Select(x => x.Substring(2));

      if(ValidarLinhasColunas(jogadasX) || ValidarDiagonais(jogadasX))
        return -1;
      if(ValidarLinhasColunas(jogadasO) || ValidarDiagonais(jogadasO))
        return 1;
      
      return 0;
    }

        private bool ValidarDiagonais(IEnumerable<string> jogadas)
        {
            var jogadasLinhas = jogadas.Select(x => x.Substring(0,1)).ToList();
            var jogadasColunas = jogadas.Select(x => x.Substring(2,1)).ToList();

            var linhaQuantidadeMaiorDeJogadas = jogadasLinhas.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            var colunaQuantidadeMaiorDeJogadas = jogadasColunas.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

            return  (jogadasLinhas.Count(x => x.Contains(linhaQuantidadeMaiorDeJogadas)) == 3 || jogadasColunas.Count(x => x.Contains(colunaQuantidadeMaiorDeJogadas)) == 3);
        }

        private bool ValidarLinhasColunas(IEnumerable<string> jogadas)
        {
            if(jogadas.Contains("2,2"))
              return (jogadas.Contains("1,1") && jogadas.Contains("3,3") || jogadas.Contains("1,3") && jogadas.Contains("3,1"));

            return false;
        }
    }
}
