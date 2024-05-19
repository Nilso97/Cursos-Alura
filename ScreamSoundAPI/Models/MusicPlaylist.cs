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
}