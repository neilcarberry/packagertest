using System.Reflection;

namespace PackagerTest;

public static class OpenApiSpec
{
    /// <summary>
    /// Returns the OpenAPI spec yaml as a string.
    /// </summary>
    public static string GetYaml()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("PackagerTest.openapi.yaml")!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Returns a stream over the OpenAPI spec yaml. Caller is responsible for disposing.
    /// </summary>
    public static Stream GetYamlStream()
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceStream("PackagerTest.openapi.yaml")!;
    }
}
