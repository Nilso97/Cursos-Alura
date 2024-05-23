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

    public void GetFavoriteMusics()
    {
        Console.WriteLine($"Essas são as músicas favoritas do usuário {Name}:");
        foreach (var music in FavoriteMusics)
        {
            Console.WriteLine($"- {music.Name} de {music.Artist}");
        }
    }

    public void GenerateJsonFileWithFavoriteMusics()
    {
        string json = JsonSerializer.Serialize(new
        {
            name = Name,
            MusicPlaylist = FavoriteMusics
        });

        string fileName = $"./musicas-favoritas-{Name!.ToLower()}-{DateTime.Now.ToFileTime()}.json";

        Console.WriteLine($"Gerando o arquivo no diretório {Path.GetFullPath(fileName)}");
        File.WriteAllText(fileName, json);
        Console.WriteLine($"O arquivo {fileName} foi criado com sucesso!");
    }
}