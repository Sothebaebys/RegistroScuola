class Registro
{
   static List<string> ricerceRecenti = new List<string>();
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

   public static void Main(string[] args)
   {
      //Media(true);
      //Ricerca(false);
      //VisualizzaRegistro(false);
   }

}