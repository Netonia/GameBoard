namespace GameBoard.Models;

public class FilterCriteria
{
    public string SearchTerm { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public double? MinRating { get; set; }
    public string SortBy { get; set; } = "title";
    public bool SortAscending { get; set; } = true;
}