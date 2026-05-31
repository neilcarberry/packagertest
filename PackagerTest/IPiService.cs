using PackagerTest.Leaderboard;

namespace PackagerTest;

public interface IPiService
{
    /// <summary>
    /// Calculates Pi to the specified number of decimal places (1–1000).
    /// Returns the result and the time taken, ready to post to the leaderboard.
    /// </summary>
    PiResult CalculatePi(int decimalPlaces = 1000);

    /// <summary>
    /// Submits a new generation time to the leaderboard.
    /// </summary>
    Task<GenerationTime> PostTimeAsync(PostGenerationTimeRequest request, CancellationToken ct = default);

    /// <summary>
    /// Partially updates an existing leaderboard entry.
    /// </summary>
    Task<GenerationTime> PatchTimeAsync(Guid id, PatchGenerationTimeRequest request, CancellationToken ct = default);

    /// <summary>
    /// Retrieves the top 10 fastest generation times from the leaderboard.
    /// </summary>
    Task<IReadOnlyList<GenerationTime>> GetTopTenAsync(CancellationToken ct = default);
}
