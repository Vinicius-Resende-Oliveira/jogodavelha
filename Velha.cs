using System;

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
      string[,] vencedor = new string[8,3];
      vencedor[0,0] = "1,1"; 
      vencedor[0,1] = "1,2";
      vencedor[0,2] = "1,3"; 
      vencedor[1,0] = "2,1";
      vencedor[1,1] = "2,2"; 
      vencedor[1,2] = "2,3"; 
      vencedor[2,0] = "3,1";
      vencedor[2,1] = "3,2";
      vencedor[2,2] = "3,3"; 
      vencedor[3,0] = "1,1";
      vencedor[3,1] = "2,1";
      vencedor[3,2] = "3,1"; 
      vencedor[4,0] = "1,2";
      vencedor[4,1] = "2,2";
      vencedor[4,2] = "3,2"; 
      vencedor[5,0] = "1,3";
      vencedor[5,1] = "2,3";
      vencedor[5,2] = "3,3"; 
      vencedor[6,0] = "1,1";
      vencedor[6,1] = "2,2";
      vencedor[6,2] = "3,3"; 
      vencedor[7,0] = "1,3";
      vencedor[7,1] = "2,2";
      vencedor[7,2] = "3,1"; 
      
      string[] jogadas = partida.Split(" ");
      string[] jogadorX = new string[9];
      string[] jogadorO = new string[9];
      int x = 0; 
      int o = 0;
      foreach(string j in jogadas){
        if(j.Substring(0,1) == "x"){
          string[] posicao = j.Split(":");
          jogadorX[x] = posicao[1];
          x++;
        }
        if(j.Substring(0,1) == "o"){
          string[] posicao = j.Split(":");
          jogadorO[o] = posicao[1];
          o++;
        }
      }

      int c = 0;
      string[] array = new string[3];
      bool venceu = false;
      do{
        array[0] = vencedor[c,0];
        array[1] = vencedor[c,1];
        array[2] = vencedor[c,2];
        c++;
        venceu = verificarJogada(array, jogadorX);
        if(venceu){
          return -1;
        }
        if(c == 7){
            break;
        }
      }while(venceu);

      do{
        array[0] = vencedor[c,0];
        array[1] = vencedor[c,1];
        array[2] = vencedor[c,2];
        
        venceu = verificarJogada(array, jogadorO);
        if(venceu){
          return 1;
        }else if(c == 7){
            break;
        }else{
          c++;
        }
      }while(venceu);
      
      return 0;
    }
    private bool verificarJogada(string[] pvencedor, string[] jogada){
      int c = 0;
      for (int i = 0; i < jogada.Length; i++)
      {
          for (int a = 0; a < pvencedor.Length; a++)
          {
              if(jogada[i] == pvencedor[a]){
                c++;
              }
          }
          if(c == 3){
            return true;
          }
      }
      return false;
    }
  }
}
