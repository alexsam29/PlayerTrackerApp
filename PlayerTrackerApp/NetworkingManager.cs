﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace PlayerTrackerApp
{
    public class NetworkingManager
    {
        private string url1 = "https://hockey-live-sk-data.p.rapidapi.com/player/";
        private string url2 = "?key=eef76c435dfd9ae1247f16f18e2abde1";
        HttpClient client = new HttpClient();
        public NetworkingManager()
        {

        }

        public async Task<Player>getPlayer(string name, string league)
        {
            string[] names = name.Split(' ');

            if (names.Length < 2)
                return new Player();

            string completeURL = url1 + names[1] + "%20" + names[0] + "/" + league + url2;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(completeURL),
                Headers = {
                            { "name", names[1] + " " + names[0] },
                            { "x-rapidapi-host", "hockey-live-sk-data.p.rapidapi.com" },
                            { "x-rapidapi-key", "58a3a0a6e6mshf21c3118f7d8a69p1deac3jsnc063824923c9" },
                          },
            };
            var response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new Player();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                if (jsonString == "No such player in database")
                    return new Player();
                var finalObject = JsonConvert.DeserializeObject<Player>
                     (jsonString);

                return finalObject;
            }
        }
    }
}
