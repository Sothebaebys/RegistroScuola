using System; 

class Registro
{
   //static List<string> ricerceRecenti = new List<string>();
   static string separatore = "==================================================";
   /* static Dictionary<string, Dictionary<string, List<int>>> registroVoti = new Dictionary<string, Dictionary<string, List<int>>>()
   {
      {
        "Mario Rossi",
        new Dictionary<string, List<int>>
        {
            { "Matematica", new List<int> { 7, 8, 6 } },
            { "Italiano", new List<int> { 6, 7 } }
        }
      },
      {
         "Luca Bianchi",
         new Dictionary<string, List<int>>
         {
               { "Matematica", new List<int> { 9, 8 } },
               { "Storia", new List<int> { 7, 7, 8 } }
         }
      }
   };*/


//Funzione per vedere a schermo il registro che può essere singolo o complessivo per tutti gli studenti
//Gestito tramite booleana come argomento, se true bisogna cercare tramite nome utente.
   public static void VisualizzaRegistro(bool isSingola)
   {

      if (isSingola)
      {
         Console.WriteLine($"Inserisci il nome dello studente di cui vuoi vedere il registro:");
         string nome =Console.ReadLine();

         //string nome = registroVoti;
         // Scelta singola o multipla
         if (registroVoti.ContainsKey(nome))
         {
            //string separatore = "=================================================="; 

            Console.WriteLine($"{separatore}\n===========|REGISTRO|===========\n{separatore}");
            Console.WriteLine($"Studente: {nome}\n{separatore}");

            Console.WriteLine($"\nMATERIA      || VOTO    ||\n{separatore}");

            

            foreach (var materia in registroVoti[nome])
            {
                int totaleVoti = registroVoti[nome][materia.Key].Count;
                Console.WriteLine($"\n{separatore}\n ");
                Console.Write($"{materia.Key}: ");  

                for (int i = 0; i<totaleVoti; i++)
                    Console.Write($" {materia.Value[i]}");
                Console.Write($"\n{separatore}\n");

            }
         }

         else
         {
            Console.WriteLine($"Nome non presente nei registri.\nRiprova:");
            VisualizzaRegistro(true);
         }
      
      }  
      else
      {
         foreach (var studente in registroVoti)
         {
            //string separatore = "=================================================="; 

            Console.WriteLine($"{separatore}\n=====================REGISTRO=====================\n{separatore}");
            Console.WriteLine($"Studente: {studente.Key}\n{separatore}");

            Console.WriteLine($"\nMATERIA      || VOTO    ||\n{separatore}");

            foreach (var materia in studente.Value)
            {
                Console.WriteLine($"\n{separatore}\n ");
                Console.Write($"{materia.Key}: ");  

                foreach (var voto in materia.Value)
                {
                    Console.Write($" {voto}");
                }
                Console.WriteLine();

            }
            Console.WriteLine($"\n{separatore}\n ");


         }
      }
   
   }


    public static void Ricerca(bool isSingola)
    {
      //Accesso alla lista ricercaRecenti
      //Inizializzare la stringa formattata per la lista
      //Singola

      //Ricerca tramite input
      //Nome o materia/note

      //Se si vuole accedere ai voti o alle note


      if (isSingola)
      {
         Console.WriteLine($"Inserisci il nominativo dello studente:");
         string nome = Console.ReadLine();
         if (registroVoti.ContainsKey(nome))
         {
            int counterMaterie = 0, sommaMedie=0;
            Console.WriteLine($"{separatore}");
            Console.WriteLine($"Media dei voti {nome}:");
            Console.WriteLine($"{separatore}");

            foreach (var materia in registroVoti[nome])
            {
               int counterVoto = 0, sommaVoti = 0;
               counterMaterie +=1;
               
               Console.Write($"{materia.Key}: ");

               foreach (var voto in materia.Value)
               {
                  counterVoto += 1 ;
                  sommaVoti += voto; 
               }
               sommaMedie += sommaVoti/counterVoto;
               Console.WriteLine($"{sommaVoti/counterVoto}");
            }
            Console.WriteLine($"Media Tot: {sommaMedie/counterMaterie}");
            
            }
         
         else
         {
            Console.WriteLine($"Nominativo non presente, riprova.");
            Ricerca(true);
         }
      }
      else
      {
        foreach (var studente in registroVoti)
        {
            int sommaMedie = 0, counterMaterie=0;
            Console.WriteLine($"{separatore}");
            Console.WriteLine($"Media di {studente.Key}:");
            Console.WriteLine($"{separatore}");
            
            
            foreach (var materia in studente.Value)
            {
               int counter = 0, sommaVoti = 0;
               counterMaterie+=1;
               //int sommaVoti = 0;
               Console.Write($"{materia.Key}: ");

               foreach (var voto in materia.Value)
               {
                  counter += 1 ;
                  sommaVoti += voto; 
                  
               }
               Console.WriteLine($"{sommaVoti/counter}");
               sommaMedie += sommaVoti/counter;
               
            }
            Console.WriteLine($"Media Tot: {sommaMedie/counterMaterie}");
            
        }
      }
    }


   // static string[] studenti = [];
   // static string[] materie = ["Matematica", "Italiano", "Storia"];
   // static Dictionary<string, Dictionary<string, List<int>>> registro = new Dictionary<string, Dictionary<string, List<int>>>()
   // {
   //    {
   //      "Mario Rossi",
   //      new Dictionary<string, List<int>>
   //      {
   //          { "Matematica", new List<int> { 7, 8, 6 } },
   //          { "Italiano", new List<int> {} },
   //          { "Storia", new List<int> { 7, 7, 10 } }
   //      }
   //    },
   //    {
   //       "Luca Bianchi",
   //       new Dictionary<string, List<int>>
   //       {
   //             { "Matematica", new List<int> { 9, 8 } },
   //             { "Italiano", new List<int> { 6, 7 } },
   //             { "Storia", new List<int> { 7, 7, 8 } }
   //       }
   //    }
   // };
   // mettiamo le funzioni qui
   private static void InserisciVoto()
   {
      List<int> voti = CercaVotiStudente();

      Console.Write("Inserire voto da aggiungere: ");
      int voto;
      while(!int.TryParse(Console.ReadLine()!, out voto) || voto <= 0 || voto > 10)
      {
         Console.Write("Voto non valido. Inserire un voto da 1 a 10: ");
      }

      voti.Add(voto);
   }

   private static List<int> CercaVotiStudente()
   {
      Console.Write("Inserire nome studente: ");
      Dictionary<string, List<int>> materieStudente;
      while(!registro.TryGetValue(Console.ReadLine()!, out materieStudente!))
      {
         Console.Write("Studente non presente nel registro. Inserire un nome presente: ");
      }

      Console.Write("Inserire materia: ");
      List<int> voti;
      while(!materieStudente.TryGetValue(Console.ReadLine()!, out voti!))
      {
         Console.Write("Materia non presente nel registro. Inserire materia esistente: ");
      }

      return voti;
   }

   private static void AggiornaVoto()
   {
      List<int> voti = CercaVotiStudente();

      Console.Write("Indicare il voto che si vuole modificare tramite indice: ");
      int indice;
      while(!int.TryParse(Console.ReadLine()!, out indice) || indice <= 0 || indice > voti.Count-1)
      {
         Console.Write($"Indice fuori dall'intervallo disponibile. Inserire un indice nel range tra 0 e {voti.Count-1}: ");
      }

      int votoAttuale = voti[indice];
      Console.Write($"Voto attuale: {votoAttuale}\nInserire nuovo voto: ");
      int nuovoVoto;
      while(!int.TryParse(Console.ReadLine()!, out nuovoVoto) || nuovoVoto <= 0 || nuovoVoto > 10)
      {
         Console.Write("Voto non valido. Inserire un voto da 1 a 10: ");
      }

      voti[indice] = nuovoVoto;

      Console.WriteLine($"Voto aggiornato, nuovo voto: {voti[indice]}");
   }

   private static void Statistiche()
   {
      double votoMax = 0;
      string studenteMax = "";
      string materiaMax = "";
      
      double votoMin = 10;
      string studenteMin = "";
      string materiaMin = "";

      Console.Write("===================MEDIA STUDENTI PER MATERIA===================\n");
      Console.Write("Studente\t");
      foreach(string materia in materie)
      {
         Console.Write($"| {materia}\t");
      }
      Console.WriteLine();
      foreach(var studente in registro)
      {
         Console.Write($"{studente.Key}");
         foreach(var materia in studente.Value)
         {
            double mediaMateria = CalcolaMedia(materia.Value);
            Console.Write($"\t| {mediaMateria:F2}\t");
            if(mediaMateria > votoMax)
            {
               votoMax = mediaMateria;
               studenteMax = studente.Key;
               materiaMax = materia.Key;
            }
            if(mediaMateria < votoMin)
            {
               votoMin = mediaMateria;
               studenteMin = studente.Key;
               materiaMin = materia.Key;
            }
         }
         Console.WriteLine();
      }

      Console.WriteLine($"\nVoto medio minimo globale: {votoMin} dello studente {studenteMin} nella materia {materiaMin}.");
      Console.WriteLine($"Voto medio massimo globale: {votoMax} dello studente {studenteMax} nella materia {materiaMax}.");
   }

   private static double CalcolaMedia(List<int> voti)
   {
      double somma = 0;
      foreach(int voto in voti)
      {
         somma += voto;
      }
      return somma / voti.Count;
   }   


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

    /*static void InserisciVoto()
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
    }*/

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

