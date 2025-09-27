using GameBoard.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace GameBoard.Services;

public class GameService
{
    private readonly HttpClient _httpClient;
    private List<Game> _games = new();
    private List<Game> _filteredGames = new();

    public GameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        if (_games.Count == 0)
        {
            await LoadGamesAsync();
        }
        return _games;
    }

    public async Task<List<Game>> GetFilteredGamesAsync(string? searchTerm = null, string? platform = null, string? genre = null, double? minRating = null)
    {
        if (_games.Count == 0)
        {
            await LoadGamesAsync();
        }

        _filteredGames = _games.Where(game =>
            (string.IsNullOrEmpty(searchTerm) || game.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(platform) || game.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(genre) || game.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) &&
            (!minRating.HasValue || game.Rating >= minRating.Value)
        ).ToList();

        return _filteredGames;
    }

    public List<Game> SortGames(List<Game> games, string sortBy, bool ascending = true)
    {
        return sortBy.ToLower() switch
        {
            "title" => ascending ? games.OrderBy(g => g.Title).ToList() : games.OrderByDescending(g => g.Title).ToList(),
            "date" => ascending ? games.OrderBy(g => g.ReleaseDate).ToList() : games.OrderByDescending(g => g.ReleaseDate).ToList(),
            "rating" => ascending ? games.OrderBy(g => g.Rating).ToList() : games.OrderByDescending(g => g.Rating).ToList(),
            "platform" => ascending ? games.OrderBy(g => g.Platform).ToList() : games.OrderByDescending(g => g.Platform).ToList(),
            "genre" => ascending ? games.OrderBy(g => g.Genre).ToList() : games.OrderByDescending(g => g.Genre).ToList(),
            _ => games
        };
    }

    public async Task<List<string>> GetPlatformsAsync()
    {
        if (_games.Count == 0)
        {
            await LoadGamesAsync();
        }
        return _games.Select(g => g.Platform).Distinct().OrderBy(p => p).ToList();
    }

    public async Task<List<string>> GetGenresAsync()
    {
        if (_games.Count == 0)
        {
            await LoadGamesAsync();
        }
        return _games.Select(g => g.Genre).Distinct().OrderBy(g => g).ToList();
    }

    public Task ToggleFavoriteAsync(int gameId)
    {
        var game = _games.FirstOrDefault(g => g.Id == gameId);
        if (game != null)
        {
            game.IsFavorite = !game.IsFavorite;
        }
        return Task.CompletedTask;
    }

    private async Task LoadGamesAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Game>>("data/games.json");
            _games = response ?? new List<Game>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading games: {ex.Message}");
            _games = new List<Game>();
        }
    }
}