using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml;

class Registro
{

   static string[] studenti = [];
   static string[] materie = ["Matematica", "Italiano", "Storia"];
   static Dictionary<string, Dictionary<string, List<int>>> registro = new Dictionary<string, Dictionary<string, List<int>>>()
   {
      {
        "Mario Rossi",
        new Dictionary<string, List<int>>
        {
            { "Matematica", new List<int> { 7, 8, 6 } },
            { "Italiano", new List<int> {} },
            { "Storia", new List<int> { 7, 7, 10 } }
        }
      },
      {
         "Luca Bianchi",
         new Dictionary<string, List<int>>
         {
               { "Matematica", new List<int> { 9, 8 } },
               { "Italiano", new List<int> { 6, 7 } },
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

   public static void Main(string[] args)
   {
      // InserisciVoto();
      // AggiornaVoto();
      // StampaVoti();
      Statistiche();

   }

   

}