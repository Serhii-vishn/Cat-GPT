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
           List<string> randomizedResponses = ShuffleList(possibleResponses);

            StringBuilder responseBuilder = BuildResponse(randomizedResponses, random.Next(1, 6));

            return responseBuilder.ToString().Trim();
        }

        private List<T> ShuffleList<T>(List<T> list)
        {
            List<T> shuffledList = list.OrderBy(x => random.Next()).ToList();
            return shuffledList;
        }

        private StringBuilder BuildResponse(List<string> shuffledResponses, int numResponses)
        {
            StringBuilder responseBuilder = new StringBuilder();

            for (int i = 0; i < numResponses; i++)
            {
                responseBuilder.Append(shuffledResponses[i]);

                if (random.Next(2) == 1)
                    AddRandomPunctuation(responseBuilder);

                responseBuilder.Append(' ');
            }

            return responseBuilder;
        }

        private void AddRandomPunctuation(StringBuilder responseBuilder)
        {
            int randomPosition = random.Next(possiblePunctuation.Count - 1);
            responseBuilder.Append(possiblePunctuation[randomPosition]);
        }

        public void Speak(string message)
        {
            throw new NotImplementedException();
        }
    }
}
