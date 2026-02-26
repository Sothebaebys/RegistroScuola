using System;
using System.Collections.Generic;

class Registro
{
    // 1. DICHIARAZIONE DELLE VARIABILI DI CLASSE (Statiche così tutti i metodi possono usarle)
    static Dictionary<string, Dictionary<string, List<int>>> registroVoti = new Dictionary<string, Dictionary<string, List<int>>>();
    static Dictionary<string, List<string>> noteStudenti = new Dictionary<string, List<string>>();
    static List<string> logOperazioni = new List<string>();
    static List<string> ricercheRecenti = new List<string>();

    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };

    // 2. MAIN: Il punto di partenza
    public static void Main(string[] args)
    {
        InizializzaDati();
        
        string scelta = "";
        while (scelta != "0")
        {
            Console.WriteLine("\n=== MENU REGISTRO ===");
            Console.WriteLine("1. Visualizza Registro");
            Console.WriteLine("2. Inserisci Voto");
            Console.WriteLine("3. Statistiche");
            Console.WriteLine("4. Aggiungi Nota");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": VisualizzaRegistro(); break;
                case "2": InserisciVoto(); break;
                case "3": StampaStatistiche(); break;
                case "4": AggiungiNota(); break;
                case "0": Console.WriteLine("Arrivederci!"); break;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
    }

    // 3. INIZIALIZZAZIONE
    static void InizializzaDati()
    {
        Random rnd = new Random();
        foreach (var studente in studenti)
        {
            registroVoti[studente] = new Dictionary<string, List<int>>();
            noteStudenti[studente] = new List<string>();
            foreach (var materia in materie)
            {
                registroVoti[studente][materia] = new List<int> { rnd.Next(1, 11) };
            }
        }
    }

    static void VisualizzaRegistro()
    {
        Console.WriteLine("\n--- REGISTRO VOTI ---");
        Console.Write("Studente\t");
        foreach (var materia in materie)
        {
            Console.Write($"{materia}\t");
        }
        Console.WriteLine("\n" + new string('-', 60));

        foreach (var studente in studenti)
        {
            Console.Write($"{studente}\t\t");
            foreach (var materia in materie)
            {
                string votiMateria = string.Join(",", registroVoti[studente][materia]);
                Console.Write($"{votiMateria}\t\t");
            }
            Console.WriteLine();
        }
    }

    static void InserisciVoto()
    {
        Console.Write("\nInserisci nome studente: ");
        string nome = Console.ReadLine();
        Console.Write("Inserisci materia: ");
        string mat = Console.ReadLine();

        if (registroVoti.ContainsKey(nome) && registroVoti[nome].ContainsKey(mat))
        {
            Console.Write("Inserisci il nuovo voto: ");
            if (int.TryParse(Console.ReadLine(), out int nuovoVoto))
            {
                registroVoti[nome][mat].Add(nuovoVoto);
                AggiungiLog($"Aggiunto voto {nuovoVoto} a {nome} in {mat}");
                Console.WriteLine("Voto registrato!");
            }
            else { Console.WriteLine("Voto non valido."); }
        }
        else { Console.WriteLine("Errore: Studente o Materia non trovati!"); }
    }

    static void StampaStatistiche()
    {
        Console.WriteLine("\n--- STATISTICHE MEDIE ---");
        foreach (var studente in studenti)
        {
            double sommaStudente = 0;
            int contaVoti = 0;
            foreach (var materia in materie)
            {
                foreach (var voto in registroVoti[studente][materia])
                {
                    sommaStudente += voto;
                    contaVoti++;
                }
            }
            double media = contaVoti > 0 ? sommaStudente / contaVoti : 0;
            Console.WriteLine($"Media {studente}: {media:F2}");
        }
    }

    static void AggiungiNota()
    {
        Console.Write("Per quale studente vuoi inserire una nota?: ");
        string nome = Console.ReadLine();
        if (noteStudenti.ContainsKey(nome))
        {
            Console.Write("Scrivi la nota: ");
            string testo = Console.ReadLine();
            noteStudenti[nome].Add(testo);
            AggiungiLog($"Aggiunta nota per {nome}");
        }
        else { Console.WriteLine("Studente non trovato."); }
    }

    static void AggiungiLog(string azione)
    {
        logOperazioni.Add($"[{DateTime.Now.ToShortTimeString()}] {azione}");
        if (logOperazioni.Count > 10)
        {
            logOperazioni.RemoveAt(0);
        }
    }
}