class Registro
{
   // mettiamo le funzioni qui

   //Dizionario : { nome : dizionario<materie:listaint> }
   //Accetta come argomento un dizionario che come chiave ha la materia e come valore il voto
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
            Console.WriteLine($"Studente: {registroVoti.Keys()}");

            Console.WriteLine($"\nMATERIA || VOTO ||\n{separatore}");

            int totaleVoti = dizMaterie.Value.Lenght;

            foreach (var materia in dizMaterie)
            {
               Console.WriteLine($"{separatore}\n ");
               Console.Write($"{materia.Key}: ");  

               for (int i = 0; i<totaleVoti; i++)
                  Console.Write($" {materia.Value[i]}");
               Console.Write($"||\n{separatore}");

            }
         }

         else
         {
            Console.WriteLine($"Nome non presente nei registri.");
            
         }
      
      }  
      else
      {
         foreach (var studente in dizMaterie)
         {
            //VisualizzaRegistro(dizMaterie,true);
         }
      }
   
   }

   public static void Main(string[] args)
   {
      VisualizzaRegistro(true);
   }

}