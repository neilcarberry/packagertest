using System.Diagnostics;
using PackagerTest.Leaderboard;

namespace PackagerTest;

public class PiService(LeaderboardClient leaderboard) : IPiService
{
    public PiResult CalculatePi(int decimalPlaces = 1000)
    {
        var sw = Stopwatch.StartNew();
        string value = PiCalculator.Calculate(decimalPlaces);
        sw.Stop();
        return new PiResult(value, decimalPlaces, sw.Elapsed.TotalMilliseconds);
    }

    public Task<GenerationTime> PostTimeAsync(PostGenerationTimeRequest request, CancellationToken ct = default)
        => leaderboard.PostTimeAsync(request, ct);

    public Task<GenerationTime> PatchTimeAsync(Guid id, PatchGenerationTimeRequest request, CancellationToken ct = default)
        => leaderboard.PatchTimeAsync(id, request, ct);

    public Task<IReadOnlyList<GenerationTime>> GetTopTenAsync(CancellationToken ct = default)
        => leaderboard.GetTopTenAsync(ct);
}
