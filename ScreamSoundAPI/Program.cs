using System.Text.Json;
using ScreamSoundAPI.Filters;
using ScreamSoundAPI.Models;

using (HttpClient client = new HttpClient())
{
    try
    {
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musics = JsonSerializer.Deserialize<List<Music>>(response)!;
        FilterMusics.FilterAllMusicGenres(musics);
        FilterMusics.OrderMusicByArtist(musics);
        FilterMusics.FilterArtistsByMusicGenre(musics, "metal");
        FilterMusics.FilterMusicsFromArtist(musics, "Limp Bizkit");

        var playlist = new MusicPlaylist("John");
        playlist.AddFavoriteMusics(musics[0]);
        playlist.AddFavoriteMusics(musics[1]);
        playlist.AddFavoriteMusics(musics[2]);
        playlist.AddFavoriteMusics(musics[3]);
        playlist.GetFavoriteMusics();
    }
    catch (Exception exc)
    {
        Console.WriteLine($"Ocorreu um erro durante a busca por músicas: {exc.Message}");
    }
}