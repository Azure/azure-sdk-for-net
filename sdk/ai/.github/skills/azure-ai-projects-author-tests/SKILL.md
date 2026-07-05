---
name: author-test
description: "Generate a test given sample. Parameters: <cs_root> C# SDK repository root; <package_name> Package name: one of Azure.AI.Projects, Azure.AI.Projects.Agents or Azure.AI.Extensions.OpenAI; <sample_name> the sample to use as a starting point for the test."
---

# Basic information.
This skill requires C# repository root (<cs_root>), package name (<package_name>), and sample file name as an input (<sample_name>). The samples are located in the <cs_root>/sdk/ai/<package_name>/tests/Samples directory, the test files are in <cs_root>/sdk/ai/<package_name>/tests. The tests are organized according to scenarios tested. The files, having suffix Base contains the required utility functions needed for testing.

# Task
Look at the sample and generate the test code in the appropriate test file. The test must have the next structure:

```C#
[RecordedTest]
// Test cases if any [TestCase(true)]
public async Task TestFeatureName(){
    var result = await CallFeatureAsync();
    Assert.That(result.Value, Is.Equal.To("Expected feature value"))
}
```

Always use the async methods (with Async suffix) if possible. Keep the test short and representative.
To make sure that the test is running as expected, build the project.

```powershell
cd <cs_root>
dotnet build
```

```bash
cd <cs_root>
dotnet build
```

If the project does not build, iterate on the error.
