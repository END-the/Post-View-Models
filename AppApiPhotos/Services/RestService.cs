using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AppApiPhotos.Models;

internal class RestService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions serializerOptions;
    private Post post;
    private ObservableCollection<Post> posts;



    public RestService()
    {
        client = new HttpClient();
        serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };
    }

    public async Task<ObservableCollection<Post>> GetPostsAsync()
    {


        Uri uri = new Uri("https://jsonplaceholder.typicode.com/photos");

        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, serializerOptions); //desrerialize vai pega coisa do json 
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching data: {ex.Message}");
        }

            return posts;
    }
}
