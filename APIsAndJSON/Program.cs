using System;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            List<string> conversation = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var ronResponse = client.GetStringAsync(swansonURL).Result;
                var ronQuote = JArray.Parse(ronResponse);
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                conversation.Add(kanyeQuote);
                conversation.Add(ronQuote[0].ToString());
            }
            for (int i = 0; i < conversation.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"Kanye: {conversation[i]}\n");
                } else
                {
                    Console.WriteLine($"Ron: {conversation[i]}\n");
                }
            }
            
        }
    }
}
