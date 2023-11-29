using Cat_GPT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
        Console.WriteLine("\t\tHello! Welcome to CAT-GPT");
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
                ViewChatsList();
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
        Console.WriteLine("\n\n\t\t\t /\\_/\\  \r\n\t\t\t( o.o ) \r\n\t\t\t > ^ < MEEEEOW! Miw meooow\n");
        Console.WriteLine("I'm CAT-GPT, nice to meet you (in human)");

        string fileName = GetChatFileName("Cat", DateTime.Now);
        HandleCatInteraction(fileName);
    }

    private static string GetChatFileName(string chatName, DateTime now)
    {
        return Path.Combine("ChatHistory", $"{chatName.ToUpper()}_{now:ddd_MMM_yyyy_HH-mm}.txt");
    }

    private static void ViewChatsList()
    {
        CatGPT catChat = new();
        var chatsList = catChat.GetChatList();

        List<string> chatNames = chatsList.Select(chat => Path.GetFileNameWithoutExtension(chat)
                                                               .Replace("_", " ")).ToList();

        Console.WriteLine("\n\nHere is the list of chats and the date of creation:");

        for (int i = 0; i < chatNames.Count; i++)
            Console.WriteLine($"{i + 1}. {chatNames[i]}");

        Console.WriteLine("\n\tStart a new one - 1" +
                          "\n\tContinue in the selected chat - 2" +
                          "\n\tExit - *");

        Console.Write("\tEnter: ");
        var keyInput = Console.ReadKey().KeyChar;

        switch (keyInput)
        {
            case '1':
                StartNewChat();
                break;
            case '2':
                ContinueInSelectedChat(chatsList, catChat);
                break;
            case '*':
                ExitApplication();
                break;
            default:
                Console.WriteLine("Error! Invalid symbol. Try Again");
                break;
        }

        Console.WriteLine("\n");
    }

    private static void ContinueInSelectedChat(List<string> chatsList, CatGPT catChat)
    {
        Console.Write("\nEnter the chat number: ");
        if (int.TryParse(Console.ReadLine(), out int chatNum) && chatNum > 0 && chatNum <= chatsList.Count)
        {
            string chatName = chatsList[chatNum - 1];
            var chatHistory = catChat.LoadChatHistory(chatName);

            foreach (var chat in chatHistory)
                Console.WriteLine(chat);

            HandleCatInteraction(chatName);
        }
        else
        {
            Console.WriteLine("Error! Invalid chat number. Try Again");
        }
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
        Console.WriteLine("\n\n\t\tThank you for using, have a nice day ;)");
        Console.WriteLine("\t-------------------------------------------------------");
        Console.ReadLine();
        Environment.Exit(0);
    }
}
