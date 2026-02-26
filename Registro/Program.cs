using System;
using System.Collections.Generic;

class Registro
{
    // 1. DICHIARAZIONE: <Studente, <Materia, ListaVoti>>
    static Dictionary<string, Dictionary<string, List<int>>> registroVoti = new Dictionary<string, Dictionary<string, List<int>>>();
    
    static Dictionary<string, List<string>> noteStudenti = new Dictionary<string, List<string>>();
    static List<string> logOperazioni = new List<string>();

    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };

    static void InizializzaDati()
    {
        Random rnd = new Random();

        foreach (string studente in studenti)
        {
            registroVoti[studente] = new Dictionary<string, List<int>>();
            
            noteStudenti[studente] = new List<string>();

            foreach (string materia in materie)
            {
                registroVoti[studente][materia] = new List<int>();
                registroVoti[studente][materia].Add(rnd.Next(1, 11));
            }
        }
    }

    public static void Main(string[] args)
    {
        InizializzaDati();
        Console.WriteLine("Dati inizializzati con successo!");
    }
}