using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random random = new Random();
        int magicNumber = random.Next(1, 101); 
        int guessNumber = 0;

        while (guessNumber != magicNumber)
        {
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            guessNumber = int.Parse(guessInput);
        
            if (guessNumber == magicNumber) {
                Console.WriteLine("You guessed it!");
            } else if (guessNumber < magicNumber) {
                Console.WriteLine("Higher");
            } else {
                Console.WriteLine("Lower");
            }  
            
        }
        
    }
}