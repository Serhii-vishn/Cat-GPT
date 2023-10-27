namespace Cat_GPT
{
    public interface IChatLogger
    {
        void LogData();
        string GetChatHistory(string chatName);
        string SaveChatHistory(string lineChat);
    }
}
