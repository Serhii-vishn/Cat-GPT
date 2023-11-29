using Cat_GPT;
using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private const char NewChatOption = '1';
    private const char ViewChatHistoryOption = '2';
    private const char ExitOption = '*';

    private static void Main(string[] args)
    {
        while (true)
        {
            DisplayMainMenu();

            var keyInput = Console.ReadKey().KeyChar;

            ProcessMainMenuInput(keyInput);
        }
    }

    private static void DisplayMainMenu()
    {
        Console.WriteLine("\t\tHello! Welcome to Animal-GPT");
        Console.WriteLine("\t-------------------------------------------");

        Console.WriteLine($"Select a menu item:" +
                          $"\n\tNew chat - {NewChatOption}" +
                          $"\n\tView chat history - {ViewChatHistoryOption}" +
                          $"\n\tExit - {ExitOption}");
        Console.Write("\tEnter: ");
    }

    private static void ProcessMainMenuInput(char keyInput)
    {
        switch (keyInput)
        {
            case NewChatOption:
                StartNewChat();
                break;
            case ViewChatHistoryOption:
                // Add logic for viewing chat history
                break;
            case ExitOption:
                ExitApplication();
                break;
            default:
                Console.WriteLine("Error! Invalid symbol. Try Again");
                break;
        }

        Console.WriteLine("\n");
    }

    private static void StartNewChat()
    {
        Console.WriteLine("\n\nYou can interact with the animals on the list below:" +
                          "\n\tCat - 1" +
                          "\n\tDog - 2" +
                          "\n\tExit - *");
        Console.Write("\tEnter: ");
        var kInp = Console.ReadKey().KeyChar;

        Console.WriteLine("\n");

        DateTime now = DateTime.Now;
        string chatName = (kInp == '1') ? "Cat" : "Dog";
        string fileName = GetChatFileName(chatName, now);
        HandleUserInput(kInp, fileName);
    }

    private static string GetChatFileName(string chatName, DateTime now)
    {
        return Path.Combine("ChatHistory", $"{chatName.ToUpper()}_{now:ddd_MMM_yyyy_HH-mm}.txt");
    }

    private static void HandleUserInput(char keyInput, string fileName)
    {
        switch (keyInput)
        {
            case '1':
                HandleCatInteraction(fileName);
                break;
            case '2':
                // Add logic for handling dog interaction
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

    private static void HandleCatInteraction(string fileName)
    {
        var listResponses = new List<string>();
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
        catChat.SaveChatHistory(fileName, listResponses);
    }

    private static void ExitApplication()
    {
        Console.WriteLine("\t\tThank you for using, have a nice day ;)");
        Console.WriteLine("\t-------------------------------------------------------");
        Console.ReadLine();
        Environment.Exit(0);
    }
}
