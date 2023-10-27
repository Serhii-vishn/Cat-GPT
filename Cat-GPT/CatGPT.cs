using System.Text;

namespace Cat_GPT
{
    class CatGPT : IAnimalGPT
    {
        private readonly List<string> possibleResponses;
        private readonly List<char> possiblePunctuation;

        private static Random random = new Random();
        public CatGPT()
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

            possiblePunctuation = new List<char>{
                ',',
                '.',
                '!',
                '?',
                '-',
                '\n'
            };
        }

        public string GenerateResponse()
        {
            List<string> randomizedResponses = possibleResponses.OrderBy(x => random.Next()).ToList();
            int numResponses = random.Next(1, 6);

            StringBuilder responseBuilder = new StringBuilder();

            for (int i = 0; i < numResponses; i++)
            {
                responseBuilder.Append(randomizedResponses[i]);

                if (random.Next(2) == 1)
                {
                    int randomPosition = random.Next(possiblePunctuation.Count - 1);

                    responseBuilder.Append(possiblePunctuation[randomPosition]);
                }
                responseBuilder.Append(" ");
            }
           
            return responseBuilder.ToString().Trim();
        }

        public void Speak(string message)
        {
            throw new NotImplementedException();
        }
    }
}
