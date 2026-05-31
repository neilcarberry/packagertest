namespace PackagerTest;

public static class OpenApiSpec
{
    private static string LocateYaml()
    {
        // When installed as a NuGet package, content files land relative to the consuming project root.
        // Walk up from the assembly location to find openapi.yaml.
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            var candidate = Path.Combine(dir.FullName, "openapi.yaml");
            if (File.Exists(candidate)) return candidate;
            dir = dir.Parent;
        }
        throw new FileNotFoundException("openapi.yaml could not be found relative to the application base directory.");
    }

    /// <summary>Returns the OpenAPI spec yaml as a string.</summary>
    public static string GetYaml() => File.ReadAllText(LocateYaml());

    /// <summary>Returns the path to the openapi.yaml file.</summary>
    public static string GetYamlPath() => LocateYaml();

    /// <summary>Returns a read stream over the openapi.yaml file. Caller is responsible for disposing.</summary>
    public static Stream GetYamlStream() => File.OpenRead(LocateYaml());
}
