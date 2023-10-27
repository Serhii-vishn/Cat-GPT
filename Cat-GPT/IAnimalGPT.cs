using System.Text;

namespace Cat_GPT
{
    public interface IAnimalGPT
    {
        string GenerateResponse();
        void Speak(string message);
    }
}
