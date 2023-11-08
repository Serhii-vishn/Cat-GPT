namespace Cat_GPT
{
    public interface IChatHistory
    {
        void SaveChatHistory(string fileName, List<string> chatHistory);
        List<string> LoadChatHistory(string fileName);
        List<string> GetChatList();
    }
}
