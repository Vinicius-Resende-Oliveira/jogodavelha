using System;
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
      
      
      
      
      
      return 0;
    }
  }
}
