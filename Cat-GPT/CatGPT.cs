using System.Text;

namespace Cat_GPT
{
    class CatGPT : IAnimalGPT, IChatHistory 
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
                '-'
            };
        }

        public string GenerateResponse(string userInput)
        {
           List<string> randomizedResponses = ShuffleList(possibleResponses);

            StringBuilder responseBuilder = BuildResponse(randomizedResponses, CalculateWordCount(userInput));
   
            return responseBuilder.ToString().Trim(); ;
        }

        private List<T> ShuffleList<T>(List<T> list)
        {
            List<T> shuffledList = list.OrderBy(x => random.Next()).ToList();
            return shuffledList;
        }

        private int CalculateWordCount(string request)
        {
            int wordCount = 0;

            if (request.Length <= 10)
                wordCount = random.Next(1, request.Length);
            else if (request.Length >= 10 && request.Length <= 25)
                wordCount = random.Next(4, request.Length / 2);

            return wordCount;
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

        public void SaveChatHistory(string fileName, List<string> chatHistory)
        {
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    foreach (string message in chatHistory)
                        writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving chat history: " + ex.Message);
            }
        }

        public List<string> LoadChatHistory(string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetChatList()
        {
            throw new NotImplementedException();
        }
    }
}
