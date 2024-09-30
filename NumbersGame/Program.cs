using System.Diagnostics;

namespace NumbersGame;
//Axel Schubert Net24
class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;//Bool för att tillåta användaren köra om programmet med en while-loop
        while (isRunning)
        {
            //här deklarerar jag parametrarna som bestämmer svårigheten
            int guessCount;
            int guessRange;
            Console.WriteLine("Välkommen till gissningsspelet! Du får nu välja svårighetsgrad.\n1.Lätt\n2.Medel\n3.Svårt");
            switch(Console.ReadLine())//Använder switch för att låta användaren välja mellan 3 svårighetsgrader
            {
                case "1":
                    guessCount = 6;
                    guessRange = 10;
                    break;
                case "2":
                    guessCount = 5;
                    guessRange = 25;
                    break;
                case "3":
                    guessCount = 4;
                    guessRange = 50;
                    break;
                default:
                    Console.WriteLine("Ogiltigt alternativ, svårigheten sätts till medel.");
                    guessCount = 5;
                    guessRange = 25;
                    break;
            }
            Random random = new Random();
            int answer = random.Next(1, guessRange + 1);//Här slumpar jag svaret upp till svårighetsgradens max. +1 för att det högsta talet ska inkluderas
            int guess = 1;//Gissningsvariabeln måste vara initierad för att min struktur ska funka
            bool userWon = false;
            bool correctInput;
            for (int i = 0; i < guessCount; i++)//Denna for-loop kör så många gånger som svårighetsgraden tillåter
            {
                Console.WriteLine($"Du har {guessCount - i} gissningar kvar.");
                Console.Write("Skriv in din gissning: ");
                //Har matar användaren in sin gissning vilket jag felhanterar med hjälp av int-TryParse och en while-loop
                correctInput = false;
                while (!correctInput)
                {
                    if (int.TryParse(Console.ReadLine(), out guess) && guess <= guessRange && guess > 0)
                        correctInput = true;
                    else 
                        Console.WriteLine("Ogiltig inmatning, försök igen.");
                    
                }
                if (guess == answer) //Om man användaren gissar rätt så stoppar jag itereringen av for-loopen med break; Lägger detta längst upp så ingen ytterligare kod körs ifall man gissar rätt
                {
                    Console.WriteLine($"{answer} var rätt svar! Grattis du vann!");
                    userWon = true;
                    break;
                }
                if (guess > answer - 6 && guess < answer + 6) //Kollar ifall gissningen är inom 5 från rätt svar och skriver isåfall att det är nära
                    Console.Write("Nu är du riktigt nära! ");
                else if (guess > answer + 10 || guess < answer - 10) //Kollar ifall man är mer än 10 ifrån rätt svar
                    Console.Write("Nu är du långt ifrån! ");
                //Kollar ifall gissningen är mindre eller större än svaret
                if (guess < answer)
                    Console.WriteLine("Din gissning är mindre än svaret!");
                else if (guess > answer)
                    Console.WriteLine("Din gissning är större än svaret!");
            }
            if(!userWon) //Ifall man inte lyckas gissa rätt
                Console.WriteLine($"Tyvärr, du fick slut på gissningar. Rätt svar var {answer}.");
            //Här låter jag användaren välja ifall hen vill spela igen.
            Console.WriteLine("Vill du köra igen? (j/n)");
            char playAgain = Console.ReadKey().KeyChar;
            if (Char.ToLower(playAgain) == 'j')
                Console.WriteLine("\nDå kör vi igen!");
            else if (Char.ToLower(playAgain) == 'n')
            {
                Console.WriteLine("\nTack för att du spelade!");
                Console.ReadKey();
                isRunning = false;
            }
            else
            {
                Console.WriteLine("\nOgiltigt svar, stänger av spelet.");
                Console.ReadKey();                            
                isRunning = false;                             
            }
        }
    }
}