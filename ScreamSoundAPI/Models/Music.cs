using System.Text.Json.Serialization;

namespace ScreamSoundAPI.Models;
internal class Music
{
    [JsonPropertyName("song")]
    public string? Name { get; set; }

    [JsonPropertyName("artist")]
    public string? Artist { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duration { get; set; }

    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    public void GetMusicDetails()
    {
        Console.WriteLine($"Música: {Name}");
        Console.WriteLine($"Artista: {Artist}");
        Console.WriteLine($"Duração: {Duration / 1000}");
        Console.WriteLine($"Gênero Musical: {Genre}");
    }
}