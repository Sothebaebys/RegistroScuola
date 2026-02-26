using System;
using System.Collections.Generic;

class Registro
{
    // 1. DICHIARAZIONE DELLE COLLEZIONI (Variabili di classe)
    static Dictionary<string, Dictionary<string, List<int>>> registroVoti = new Dictionary<string, Dictionary<string, int>>();
    
    static Dictionary<string, List<string>> noteStudenti = new Dictionary<string, List<string>>();

    // Lista per il Log delle operazioni (ultime 10 azioni)
    static List<string> logOperazioni = new List<string>();

    // Vettori di base (Seed suggerito)
    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };

    // 2. FUNZIONE PER INIZIALIZZARE I DATI
    static void InizializzaDati()
    {
        Random rnd = new Random();

        foreach (string studente in studenti)
        {
            // Creiamo un nuovo dizionario voti per ogni studente
            registroVoti[studente] = new Dictionary<string, int>();
            
            // Creiamo una lista vuota per le note di ogni studente
            noteStudenti[studente] = new List<string>();

            foreach (string materia in materie)
            {
                // Generiamo un voto casuale tra 1 e 10
                registroVoti[studente][materia].Add(rnd.Next(1,11));
            }
        }
    }

    public static void Main(string[] args)
    {
        InizializzaDati();
        Console.WriteLine("Dati inizializzati con successo!");
        
        // alle altre funzioni...
    }
}