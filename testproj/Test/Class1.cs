using PackagerTest;

namespace Test;

public class Class1
{
    public string GetOpenApiSpec()
    {
        return OpenApiSpec.GetYaml();
    }
}
