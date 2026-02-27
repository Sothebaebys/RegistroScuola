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

   public static void Main(string[] args)
   {
      // InserisciVoto();
      AggiornaVoto();
      Statistiche();

   }

   

}