using GameBoard.Models;

namespace GameBoard.Services;

public class DashboardService
{
    private readonly GameService _gameService;

    public DashboardService(GameService gameService)
    {
        _gameService = gameService;
    }

    public async Task<DashboardStats> GetDashboardStatsAsync(List<Game>? games = null)
    {
        games ??= await _gameService.GetGamesAsync();

        var stats = new DashboardStats
        {
            TotalGames = games.Count,
            AverageRating = games.Count > 0 ? Math.Round(games.Average(g => g.Rating), 2) : 0,
            FavoriteGames = games.Count(g => g.IsFavorite),
            PlatformDistribution = games.GroupBy(g => g.Platform)
                .ToDictionary(g => g.Key, g => g.Count()),
            GenreDistribution = games.GroupBy(g => g.Genre)
                .ToDictionary(g => g.Key, g => g.Count()),
            RecentGames = games.OrderByDescending(g => g.ReleaseDate)
                .Take(5)
                .ToList(),
            TopRatedGames = games.OrderByDescending(g => g.Rating)
                .Take(5)
                .ToList()
        };

        return stats;
    }
}

public class DashboardStats
{
    public int TotalGames { get; set; }
    public double AverageRating { get; set; }
    public int FavoriteGames { get; set; }
    public Dictionary<string, int> PlatformDistribution { get; set; } = new();
    public Dictionary<string, int> GenreDistribution { get; set; } = new();
    public List<Game> RecentGames { get; set; } = new();
    public List<Game> TopRatedGames { get; set; } = new();
}