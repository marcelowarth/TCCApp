using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class StaticBehaviours : MonoBehaviour {

#region Variaveis Publicas
    public static List<Game> savedGames = new List<Game>();
    public static List<int> valoresEntrada = new List<int>();
    public static List<int> valoresSaida = new List<int>();

    public static string problema = "";

    //Posições Entrada/Saida
    //public static Vector2() posEntrada = new Vector2();
    //public static Vector2() posSaida = new Vector2();

    //Posições Variáveis
    //public static Vector2() var1 = new Vector2();
    //public static Vector2() var2 = new Vector2();
    //public static Vector2() var3 = new Vector2();
    //public static Vector2() var4 = new Vector2();
    //public static Vector2() var5 = new Vector2();
    //public static Vector2() var6 = new Vector2();
#endregion

#region Variaveis Privadas
    private static int contador = 0;
#endregion

#region Save/Load
    public static void Save()
    {
        StaticBehaviours.savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, StaticBehaviours.savedGames);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            StaticBehaviours.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }
#endregion

#region Comandos
    public static int Soma(int valor1, int valor2)
    {
        return valor1 + valor2;
    }

    public static int Subtrai(int valor1, int valor2)
    {
        return valor1 - valor2;
    }

    public static bool VerificaSaida(int valor)
    {
        if(valor == valoresSaida[contador])
        {
            contador++;
            return true;
        }
        else
        {
            contador = 0;
            return false;
        }
    }

    public static bool Terminou()
    {
        if(contador + 1 >= valoresSaida.Count)
        {
            return true;
        }
        return false;
    }
#endregion
}
