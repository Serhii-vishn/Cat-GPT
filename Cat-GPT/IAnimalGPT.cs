using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_GPT
{
    interface IAnimalGPT
    {
        string GenerateResponse();
        void Speak(string message);

        void LogData();

        //string GetChatHistory(string chatName); just idea
        //string SaveChatHistory(string lineChat);
    }
}
