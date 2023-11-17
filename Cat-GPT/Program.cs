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
            Console.Write("\tEnter: ");
            var keyInput = Console.ReadKey().KeyChar;

            Console.WriteLine("\n");

            HandleUserInput(keyInput);
        }
    }

    private static void HandleUserInput(char keyInput)
    {
        switch (keyInput)
        {
            case '1':
                HandleCatInteraction();
                break;
            case '2':
                HandleDogInteraction();
                break;
            case '*':
                ExitApplication();
                break;
            default:
                Console.WriteLine("Error! Invalid symbol. Try Again");
                break;
        }

        Console.ReadLine(); // Це може бути винесено за межі циклу while, якщо ви хочете чекати натискання клавіші тільки після введення користувача.
    }

    private static void HandleCatInteraction()
    {
        Console.WriteLine("To end the chat, send - #");
        bool key = true;
        while (key)
        {
            CatGPT catChat = new();
            Console.Write("\nSend a message: ");
            string userMess = Console.ReadLine();
            if (userMess == "#")
                key = false;
            else
                Console.WriteLine("Response: " + catChat.GenerateResponse(userMess));
        }
    }

    private static void HandleDogInteraction()
    {
        
    }

    private static void ExitApplication()
    {
        Console.WriteLine("\t\tThank you for using, have a nice day ;)");
        Console.WriteLine("\t-------------------------------------------------------");
        Console.ReadLine();
        Environment.Exit(0);
    }

}