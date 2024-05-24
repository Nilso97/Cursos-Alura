using System.Text.Json;

namespace ScreamSoundAPI.Models;

internal class MusicPlaylist
{
    public string? Name { get; set; }
    public List<Music> FavoriteMusics { get; }

    public MusicPlaylist(string name)
    {
        Name = name;
        FavoriteMusics = new List<Music>();
    }

    public void AddFavoriteMusics(Music music)
    {
        FavoriteMusics.Add(music);
    }

    public void GetFavoriteMusics(string fileName)
    {
        Console.WriteLine($"Essas são as músicas favoritas do usuário {Name}:");
        string json = File.ReadAllText(fileName);
        var favoriteMusics = JsonSerializer.Deserialize<List<Music>>(json);
        foreach (var music in favoriteMusics!)
        {
            Console.WriteLine($"Música: {music.Name}\nArtista: {music.Artist}\n");
        }
    }

    public string GenerateJsonFileWithFavoriteMusics()
    {
        string json = JsonSerializer.Serialize(FavoriteMusics);

        string fileName = $"./musicas-favoritas-{Name!.ToLower()}-{DateTime.Now.ToFileTime()}.json";

        Console.WriteLine($"Gerando o arquivo no diretório {Path.GetFullPath(fileName)}");
        File.WriteAllText(fileName, json);
        Console.WriteLine($"O arquivo {fileName} foi criado com sucesso!");

        return fileName;
    }
}