using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_GPT
{
    public interface IAnimalGPT
    {
        string GenerateResponse();
        void Speak(string message);
    }
}
