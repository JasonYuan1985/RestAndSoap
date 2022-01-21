// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;

var url = "https://localhost:7004";

HttpClient client = new HttpClient();
client.BaseAddress = new Uri(url);

var val = "application/json";
var media = new MediaTypeWithQualityHeaderValue(val);

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(media);

// call - get
var action = "WeatherForecast/Test";
var result = await client.GetAsync(action);
if (result != null && result.IsSuccessStatusCode)
{
    var weatherResult = await result.Content.ReadAsStringAsync();
    Console.WriteLine("Rest Demo: " + weatherResult);
}