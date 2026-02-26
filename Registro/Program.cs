using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml;

class Registro
{

   static string[] studenti = [];
   static string[] materie = [];
   static Dictionary<string, Dictionary<string, List<int>>> registro = new Dictionary<string, Dictionary<string, List<int>>>()
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
   // mettiamo le funzioni qui
   private static void InserisciVoto()
   {
      Console.Write("Nome studente: ");
      string studente = Console.ReadLine()!;
      Console.Write("Indicare la materia alla quale si vuole aggiungere il voto: ");
      string materia = Console.ReadLine()!;
      Console.Write("Inserire voto: ");
      int voto;

      if(int.TryParse(Console.ReadLine()!, out voto))
         registro[studente][materia].Add(voto);
   }

   private static void AggiornaVoto()
   {
      Console.Write("Nome studente: ");
      string studente = Console.ReadLine()!;
      Console.Write("Indicare la materia che contiene il voto da aggiornare: ");
      string materia = Console.ReadLine()!;
      Console.Write("Indicare il voto che si vuole modificare tramite indice: ");
      int indice = int.Parse(Console.ReadLine()!)-1;
      List<int> listaVoti = registro[studente][materia];
      int votoAttuale = listaVoti[indice];
      Console.Write($"Voto attuale: {votoAttuale}\nInserire nuovo voto: ");
      int nuovoVoto = int.Parse(Console.ReadLine()!);
      listaVoti[indice] = nuovoVoto;

      Console.WriteLine($"Voto aggiornato, nuovo voto: {registro[studente][materia][indice]}");
   }

   private static void StampaVoti()
   {
      foreach(var kv in registro["Mario Rossi"])
      {
         foreach(int voto in kv.Value)
         {
            Console.WriteLine(voto);
         }
      }
   }

   private static void Statistiche()
   {
      
   }

   public static void Main(string[] args)
   {
      // InserisciVoto();
      AggiornaVoto();
      StampaVoti();

   }

   

}