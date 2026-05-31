using System.Net.Http.Json;

namespace PackagerTest.Leaderboard;

public class LeaderboardClient(HttpClient http)
{
    /// <summary>GET /leaderboard — top 10 fastest generation times.</summary>
    public async Task<IReadOnlyList<GenerationTime>> GetTopTenAsync(CancellationToken ct = default)
    {
        var results = await http.GetFromJsonAsync<List<GenerationTime>>("/leaderboard", ct);
        return results ?? [];
    }

    /// <summary>POST /times — submit a new generation time.</summary>
    public async Task<GenerationTime> PostTimeAsync(PostGenerationTimeRequest request, CancellationToken ct = default)
    {
        var response = await http.PostAsJsonAsync("/times", request, ct);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<GenerationTime>(ct))!;
    }

    /// <summary>PATCH /times/{id} — partially update an existing generation time.</summary>
    public async Task<GenerationTime> PatchTimeAsync(Guid id, PatchGenerationTimeRequest request, CancellationToken ct = default)
    {
        var response = await http.PatchAsJsonAsync($"/times/{id}", request, ct);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<GenerationTime>(ct))!;
    }
}
