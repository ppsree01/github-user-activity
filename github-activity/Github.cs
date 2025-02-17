using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

internal static class Github {
    public static async Task GetUserActivity(string username) {
        var url = $"https://api.github.com/users/{username}/events";
        using (HttpClient client = new HttpClient() {
            BaseAddress = new Uri(url)
        }) {
            client.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("product", "1")
            );
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GithubActivity[]>(content);
                if (result?.Length > 0) {
                    Message.Print(result);
                }
            } else {
                Console.WriteLine("An error occured. Please debug the issue");
            }
        }
    }
}