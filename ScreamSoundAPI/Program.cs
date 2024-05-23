using System.Text.Json;
using ScreamSoundAPI.Filters;
using ScreamSoundAPI.Models;

using (HttpClient client = new HttpClient())
{
    try
    {
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musics = JsonSerializer.Deserialize<List<Music>>(response)!;
        musics[1].GetMusicDetails();
        FilterMusics.FilterAllMusicGenres(musics);
        FilterMusics.OrderMusicByArtist(musics);
        FilterMusics.FilterArtistsByMusicGenre(musics, "metal");
        FilterMusics.FilterMusicsFromArtist(musics, "Limp Bizkit");
        FilterMusics.FilterMusicsSpecificKey(musics, "C#");

        var playlist = new MusicPlaylist("John");
        for (var i = 0; i <= musics.Count; i++)
        {
            if (i >= 100) break;
            playlist.AddFavoriteMusics(musics[i]);
        }

        playlist.GetFavoriteMusics();

        playlist.GenerateJsonFileWithFavoriteMusics();
    }
    catch (Exception exc)
    {
        Console.WriteLine($"Ocorreu um erro durante a busca por músicas: {exc.Message}");
    }
}