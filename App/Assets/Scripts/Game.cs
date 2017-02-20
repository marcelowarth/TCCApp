using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game
{
    public static Game current;
    public string nome;
    public Dictionary<int, string> solucoes = new Dictionary<int, string>; 

    public Game()
    {

    }

}
