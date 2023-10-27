using Cat_GPT;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\t\tHello! Welcome to Animal-GPT");
            Console.WriteLine("\t-------------------------------------------");
            Console.WriteLine("You can interact with the animals on the list below:" +
                                                                    "\n\tCat - 1" +
                                                                    "\n\tDog - 2" +
                                                                    "\n\tExit - *");
            Console.Write("\tEnter: "); var keyInput = Console.ReadKey().KeyChar;

            Console.WriteLine("\n");

            switch (keyInput)
            {
                case '1':
                    {
                        Console.WriteLine("To end the chat, send - #");
                        bool key = true;
                        while(key)
                        {                        
                            CatGPT catChat = new();
                            Console.Write("\nSend a message: "); string userMess = Console.ReadLine();
                            if (userMess == "#")
                                key = false;
                            else
                                Console.WriteLine("Response: " + catChat.GenerateResponse());
                        }
                        break;
                    }
                case '2':
                    {

                        break;
                    }
                case '*':
                    {
                        Console.WriteLine("\t\tThank you for using, have a nice day ;)");
                        Console.WriteLine("\t-------------------------------------------------------");
                        Console.ReadLine();
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Error! Invalid symbol. Try Again");
                        break;
                    }
            }
            Console.ReadLine();
        }
    }
}