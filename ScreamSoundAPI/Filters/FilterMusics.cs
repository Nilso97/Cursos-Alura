using ScreamSoundAPI.Models;

namespace ScreamSoundAPI.Filters;

internal class FilterMusics
{
    public static void FilterAllMusicGenres(List<Music> musics)
    {
        var allMusicGenres = musics.Select(m => m.Genre).Distinct().ToList();
        foreach (var genre in allMusicGenres)
        {
            Console.WriteLine($"- {genre}");
        }
    }

    public static void OrderMusicByArtist(List<Music> musics, string? orderType = "ASC")
    {
        List<string?> artists;
        if (orderType?.ToUpper() != "DESC")
        {
            artists = musics.OrderBy(m => m.Artist).Select(m => m.Artist).Distinct().ToList();
        }
        else
        {
            artists = musics.OrderByDescending(m => m.Artist).Select(m => m.Artist).Distinct().ToList();
        }

        int count = 1;
        Console.WriteLine($"Lista de artistas ordenados:");
        foreach (var artist in artists)
        {
            Console.WriteLine($"{count} - {artist}");
            count += 1;
        }
    }

    public static void FilterArtistsByMusicGenre(List<Music> musics, string genre)
    {
        var artistsByGenre = musics.Where(m => m.Genre!.Contains(genre)).Select(m => m.Artist).Distinct().ToList();

        Console.WriteLine($"Exibindo artistas por gênero musical >>> {genre}");
        foreach (var artist in artistsByGenre)
        {
            Console.WriteLine($"Artista: {artist}");
        }
    }

    public static void FilterMusicsFromArtist(List<Music> musics, string artist)
    {
        var artistMusics = musics.Where(m => m.Artist!.Equals(artist)).ToList();

        Console.WriteLine(artist);
        foreach (var music in artistMusics)
        {
            Console.WriteLine($"- {music.Name}");
        }
    }
}
