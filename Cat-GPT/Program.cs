using Cat_GPT;
using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\t\tHello! Welcome to Animal-GPT");
            Console.WriteLine("\t-------------------------------------------");

            Console.WriteLine("Select a menu item: "+
                                                    "\n\tNew chat - 1" +
                                                    "\n\tView chat history - 2" +
                                                    "\n\tExit - *");
            Console.Write("\tEnter: ");
            var keyInput = Console.ReadKey().KeyChar;

            switch (keyInput)
            {
                case '1':
                    {
                        Console.WriteLine("\n\nYou can interact with the animals on the list below:" +
                                                                            "\n\tCat - 1" +
                                                                            "\n\tDog - 2" +
                                                                            "\n\tExit - *");
                        Console.Write("\tEnter: ");
                        var kInp = Console.ReadKey().KeyChar;

                        Console.WriteLine("\n");

                        HandleUserInput(kInp);
                        break;
                    }
                case '2':
                    {
                        break;
                    }
                case '*':
                    {
                        ExitApplication();
                        Console.WriteLine("Error! Invalid symbol. Try Again");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error! Invalid symbol. Try Again");
                        break;
                    }                  
            }
            Console.WriteLine("\n");
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

        Console.ReadLine();
    }

    private static void HandleCatInteraction()
    {
        var listResponses = new List <string>();
        CatGPT catChat = new();

        Console.WriteLine("To end the chat, send - *");
        bool chatActive = true;
        while (chatActive)
        {
            Console.Write("\nSend a message: ");
            string userMess = Console.ReadLine();

            if (string.IsNullOrEmpty(userMess) || userMess.Trim() == "*")
            {
                chatActive = false;
            }
            else
            {
                string response = catChat.GenerateResponse(userMess);
                Console.WriteLine("Response: " + response);

                listResponses.Add($"User: {userMess}");
                listResponses.Add($"Cat: {response}");
            }
        }
        catChat.SaveChatHistory("ChatHistory\\test.txt", listResponses);
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