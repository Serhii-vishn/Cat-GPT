using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_GPT
{
    class CatGPT : IAnimalGPT
    {
        private readonly List<string> possibleResponses;
        private readonly List<char> possibleSymbols;

        CatGPT()
        {
            possibleResponses = new List<string>{
                "meow",
                "mew",
                "meeeow",
                "miw",
                "meeow",
                "meoow",
                "meeeoww",
                "meooow",
                "meeeeeow",
                "meeeeow",
                "meooww",
                "meeeeeeow",
                "meeeeoow",
                "meeeooow",
                "meeeeeeoww",
                "meeeeoooow",
                "meoww",
                "meoooww",
                "meeoowww",
                "meeeeooooww"
            };

            possibleSymbols = new List<char>{
                ',',
                '.',
                '!',
                '?',
                '-'
            };
        }

        public string GenerateResponse()
        {
            throw new NotImplementedException();
        }

        public void LogData()
        {
            throw new NotImplementedException();
        }

        public void Speak(string message)
        {
            throw new NotImplementedException();
        }
    }
}
