using System.Text;

namespace Cat_GPT
{
    public interface IAnimalGPT
    {
        string GenerateResponse(string userInput);
        void Speak(string message);
    }
}