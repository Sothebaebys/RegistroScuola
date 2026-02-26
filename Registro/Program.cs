class Registro
{
    static Dictionary<string, Dictionary<string, List<int>>> registroVoti = new Dictionary<string, Dictionary<string, List<int>>>()
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
   };


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
            string separatore = "=================================================="; 

            Console.WriteLine($"{separatore}\n============REGISTRO============\n{separatore}");
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
            string separatore = "=================================================="; 

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


    public static void Media()
    {
        
    }

   public static void Main(string[] args)
   {
      VisualizzaRegistro(false);
   }

}