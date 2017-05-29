using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesArrayScript : MonoBehaviour {

    public List<Challenge> Challenges = new List<Challenge>();
    private Challenge chal = new Challenge();

    // Use this for initialization
    void Start () {
        PopulateChallengesArray();
	}

    private void PopulateChallengesArray()
    {

        #region Challenge 1 Tutorial
        chal.description = "Utilizando [Pegar Entrada] e [Levar a Saída], leve todos os itens da entrada para a saída.";

        chal.inputVar[0] = "5";
        chal.inputVar[1] = "3";
        chal.inputVar[2] = "12";
        chal.inputVar[3] = "1";
        chal.inputVar[4] = "7";
        
        chal.outputVar[0] = "5";
        chal.outputVar[1] = "3";
        chal.outputVar[2] = "12";
        chal.outputVar[3] = "1";
        chal.outputVar[4] = "7";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 2 Tutorial
        chal.description = "Utilizando [Pegar Entrada], [Levar a Saída] e [Pule Para], leve todos os itens da entrada para a saída.";

        chal.inputVar[0] = "7";
        chal.inputVar[1] = "3";
        chal.inputVar[2] = "8";
        chal.inputVar[3] = "1";
        chal.inputVar[4] = "2";

        chal.outputVar[0] = "7";
        chal.outputVar[1] = "3";
        chal.outputVar[2] = "8";
        chal.outputVar[3] = "1";
        chal.outputVar[4] = "2";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 3 Tutorial
        chal.description = "Utilizando [Pegar Entrada], [Levar a Saída], [Pule Para], [Copia Para] e [Copia de], pegue duas entradas, inverta-as e leve o resultado a saída.";

        chal.inputVar[0] = "3";
        chal.inputVar[1] = "4";
        chal.inputVar[2] = "1";
        chal.inputVar[3] = "2";
        chal.inputVar[4] = "7";
        chal.inputVar[5] = "9";

        chal.outputVar[0] = "4";
        chal.outputVar[1] = "3";
        chal.outputVar[2] = "2";
        chal.outputVar[3] = "1";
        chal.outputVar[4] = "9";
        chal.outputVar[5] = "7";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 4 Tutorial
        chal.description = "Utilizando [Pegar Entrada], [Levar a Saída], [Pule Para], [Copia Para], [Copia de] e [Some com], pegue duas entradas, some-as e leve o resultado a saída.";

        chal.inputVar[0] = "9";
        chal.inputVar[1] = "3";
        chal.inputVar[2] = "1";
        chal.inputVar[3] = "8";
        chal.inputVar[4] = "3";
        chal.inputVar[5] = "3";

        chal.outputVar[0] = "12";
        chal.outputVar[1] = "9";
        chal.outputVar[2] = "6";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion
        
        #region Challenge 5 Tutorial
        chal.description = "Utilizando [Pegar Entrada], [Levar a Saída], [Pule Para] e [Se zero], leve tudo que não for zero para a saída.";

        chal.inputVar[0] = "1";
        chal.inputVar[1] = "4";
        chal.inputVar[2] = "0";
        chal.inputVar[3] = "5";
        chal.inputVar[4] = "0";
        chal.inputVar[5] = "0";
        chal.inputVar[6] = "6";
        chal.inputVar[7] = "0";
        chal.inputVar[8] = "1";

        chal.outputVar[0] = "1";
        chal.outputVar[1] = "4";
        chal.outputVar[2] = "5";
        chal.outputVar[3] = "6";
        chal.outputVar[4] = "1";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 6
        chal.description = "Para cada duas entradas, subtraia a primeira da segunda e leve o resultado para a saída, após, subtraia a segunda da primeira e leve a saída.";

        chal.inputVar[0] = "5";
        chal.inputVar[1] = "3";
        chal.inputVar[2] = "1";
        chal.inputVar[3] = "8";
        chal.inputVar[4] = "3";
        chal.inputVar[5] = "3";

        chal.outputVar[0] = "-2";
        chal.outputVar[1] = "2";
        chal.outputVar[2] = "7";
        chal.outputVar[3] = "-7";
        chal.outputVar[4] = "0";
        chal.outputVar[5] = "0";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 7
        chal.description = "Quando o primeiro programa passou a rodar em um computador na década de 40, ele lia somente ZERO e UM de um cartão perfurado, por favor, leve a saída somente os números ZERO e UM.";

        chal.inputVar[0] = "5";
        chal.inputVar[1] = "0";
        chal.inputVar[2] = "1";
        chal.inputVar[3] = "0";
        chal.inputVar[4] = "3";
        chal.inputVar[5] = "1";

        chal.outputVar[0] = "0";
        chal.outputVar[1] = "1";
        chal.outputVar[2] = "0";
        chal.outputVar[3] = "1";

        chal.arrayValues[0] = "-1";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 8
        chal.description = "O Teste de Turing foi criado para verificar se uma máquina é capaz de exibir comportamento inteligente equivalente a um ser humano. Por favor, leve a saída ZERO se a entrada for UM e UM se a entrada for ZERO.";

        chal.inputVar[0] = "1";
        chal.inputVar[1] = "0";
        chal.inputVar[2] = "1";
        chal.inputVar[3] = "0";
        chal.inputVar[4] = "0";
        chal.inputVar[5] = "1";

        chal.outputVar[0] = "0";
        chal.outputVar[1] = "1";
        chal.outputVar[2] = "0";
        chal.outputVar[3] = "1";
        chal.outputVar[4] = "1";
        chal.outputVar[5] = "0";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "0";
        chal.arrayValues[7] = "1";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion
        
        #region Challenge 9
        chal.description = "Durante a década de 50, a primeira imagem foi escaneada por um computador, por favor, leve três vezes a saída o valor de entrada, representando o padrão RBG.";

        chal.inputVar[0] = "5";
        chal.inputVar[1] = "1";
        chal.inputVar[2] = "3";
        chal.inputVar[3] = "9";
        chal.inputVar[4] = "7";
        chal.inputVar[5] = "5";

        chal.outputVar[0] = "5";
        chal.outputVar[1] = "5";
        chal.outputVar[2] = "5";
        chal.outputVar[3] = "1";
        chal.outputVar[4] = "1";
        chal.outputVar[5] = "1";
        chal.outputVar[6] = "3";
        chal.outputVar[7] = "3";
        chal.outputVar[8] = "3";
        chal.outputVar[9] = "9";
        chal.outputVar[10] = "9";
        chal.outputVar[11] = "9";
        chal.outputVar[12] = "7";
        chal.outputVar[13] = "7";
        chal.outputVar[14] = "7";
        chal.outputVar[15] = "5";
        chal.outputVar[16] = "5";
        chal.outputVar[17] = "5";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 10
        chal.description = "Durante a década de 60 a IBM introduziu a série 1400, computador empresarial para realização de cálculos, por favor, leve a saída o valor da entrada multiplicado por 3.";

        chal.inputVar[0] = "3";
        chal.inputVar[1] = "7";
        chal.inputVar[2] = "5";
        chal.inputVar[3] = "2";
        chal.inputVar[4] = "8";
        chal.inputVar[5] = "6";

        chal.outputVar[0] = "9";
        chal.outputVar[1] = "21";
        chal.outputVar[2] = "15";
        chal.outputVar[3] = "6";
        chal.outputVar[4] = "26";
        chal.outputVar[5] = "18";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 11
        chal.description = "O braço Rancho foi o primeiro braço mecânico a ser controlado por computador, leve a saída somente números que não forem negativos, representando que o braço não acha algo para agarrar.";

        chal.inputVar[0] = "-3";
        chal.inputVar[1] = "2";
        chal.inputVar[2] = "5";
        chal.inputVar[3] = "-5";
        chal.inputVar[4] = "-6";
        chal.inputVar[5] = "6";

        chal.outputVar[0] = "2";
        chal.outputVar[1] = "5";
        chal.outputVar[2] = "6";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 12
        chal.description = "Na década de 70 surgiu o Xerox PARC Alto, primeiro sistema operacional a utilizar janelas com o usuário, além de se comunicar com outros Altos. Para representar os cálculos realizados para a comunicação, por favor, leves a saída o seguinte: O primeiro número será levado diretamente a saída, o segundo será diminuído do primeiro e lavado a saída, repita para o restante.";

        chal.inputVar[0] = "3";
        chal.inputVar[1] = "2";
        chal.inputVar[2] = "5";
        chal.inputVar[3] = "5";
        chal.inputVar[4] = "6";
        chal.inputVar[5] = "8";

        chal.outputVar[0] = "3";
        chal.outputVar[1] = "1";
        chal.outputVar[2] = "5";
        chal.outputVar[3] = "0";
        chal.outputVar[4] = "6";
        chal.outputVar[5] = "-2";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 13
        chal.description = "Na década de 70, o Apple-II começou a ser comercializado, para representar a fila de produção, leve a saída o valor da entrada multiplicado por si mesmo.";

        chal.inputVar[0] = "2";
        chal.inputVar[1] = "5";
        chal.inputVar[2] = "3";
        chal.inputVar[3] = "8";
        chal.inputVar[4] = "4";
        chal.inputVar[5] = "3";

        chal.outputVar[0] = "4";
        chal.outputVar[1] = "25";
        chal.outputVar[2] = "9";
        chal.outputVar[3] = "64";
        chal.outputVar[4] = "16";
        chal.outputVar[5] = "9";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion

        #region Challenge 14
        chal.description = "Na década de 80, a IBM introduziu o PC, que tornou-se imensamente popular, representando a demanda crescente, por favor, leve a saída o valor da entrada multiplicado pelo número de itens da entrada já pegos, ou seja, primeiro item vezes 1, segundo item vezes 2 e assim por diante.";

        chal.inputVar[0] = "2";
        chal.inputVar[1] = "4";
        chal.inputVar[2] = "3";
        chal.inputVar[3] = "5";
        chal.inputVar[4] = "9";
        chal.inputVar[5] = "8";

        chal.outputVar[0] = "2";
        chal.outputVar[1] = "8";
        chal.outputVar[2] = "9";
        chal.outputVar[3] = "20";
        chal.outputVar[4] = "45";
        chal.outputVar[5] = "48";

        chal.arrayValues[0] = "";
        chal.arrayValues[1] = "";
        chal.arrayValues[2] = "";
        chal.arrayValues[3] = "";
        chal.arrayValues[4] = "";
        chal.arrayValues[5] = "";
        chal.arrayValues[6] = "";
        chal.arrayValues[7] = "1";

        Challenges.Add(chal);

        cleanChallenge();
        #endregion
    }

    private void cleanChallenge()
    {
        chal.description = "";

        Array.Clear(chal.inputVar, 0, chal.inputVar.Length);
        Array.Clear(chal.outputVar, 0, chal.inputVar.Length);
        Array.Clear(chal.arrayValues, 0, chal.inputVar.Length);
    }
}
