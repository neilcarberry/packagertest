namespace PackagerTest.Leaderboard;

public record GenerationTime(
    Guid Id,
    string PlayerName,
    int DecimalPlaces,
    double ElapsedMilliseconds,
    DateTime RecordedAt
);

public record PostGenerationTimeRequest(
    string PlayerName,
    int DecimalPlaces,
    double ElapsedMilliseconds
);

public record PatchGenerationTimeRequest(
    string? PlayerName,
    int? DecimalPlaces,
    double? ElapsedMilliseconds
);
