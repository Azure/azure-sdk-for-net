# Sample Structure Guide

This document describes the structure and organization of the Azure AI Content Understanding .NET SDK samples.

## Directory Structure

```
samples/
├── README.md                           # Main samples documentation
├── Sample1_HelloWorld.md               # Documentation-only sample
├── Sample1_HelloWorldAsync.md          # Documentation-only sample
├── SAMPLE_STRUCTURE.md                 # This file
├── appsettings.json                    # Shared configuration (gitignored)
├── appsettings.json.sample             # Shared configuration template
├── .gitignore                          # Git ignore rules
├── Common/                             # Shared code for all samples
│   └── SampleHelper.cs                 # Configuration and utility helpers
└── AnalyzeUrl/                         # Runnable sample: Analyze URL
    ├── Program.cs                      # Main sample code
    ├── AnalyzeUrl.csproj              # Project file
    ├── appsettings.json.sample         # Sample-specific config template
    └── README.md                       # Sample-specific documentation
```

## Types of Samples

### 1. Documentation Samples (Markdown)
- Quick reference snippets showing specific API usage
- Located in the `samples/` root directory
- Format: `SampleN_*.md`
- Example: `Sample1_HelloWorld.md`

### 2. Runnable Console Samples (Subdirectories)
- Complete, executable console applications
- Located in subdirectories under `samples/`
- Each sample is a standalone .NET console app
- Examples: `AnalyzeUrl/`, (more to come)

## Creating a New Runnable Sample

To add a new runnable sample, follow this structure:

### 1. Create Sample Directory

```bash
cd samples/
mkdir YourSampleName
cd YourSampleName
```

### 2. Required Files

#### Program.cs
Main sample code demonstrating the scenario. Should include:
- Clear comments explaining each step
- Error handling
- Console output with emojis for better UX
- Example code that users can copy

#### Shared SampleHelper.cs
Located in `samples/Common/SampleHelper.cs` and used by all samples. Provides:
- Configuration loading using standard .NET configuration system (`Microsoft.Extensions.Configuration`)
- Supports appsettings.json and environment variables (env vars have higher priority)
- Utility functions (SaveJsonToFile, etc.)

**Note**: You don't need to copy this file. Just reference it in your .csproj (see below).

#### YourSampleName.csproj
Project file with references to the SDK:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <RootNamespace>Azure.AI.ContentUnderstanding.Samples</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\src\Azure.AI.ContentUnderstanding.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Azure.Identity" Version="1.13.1" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="8.0.0" />
  </ItemGroup>

  <!-- Include shared SampleHelper.cs from Common directory -->
  <ItemGroup>
    <Compile Include="..\Common\SampleHelper.cs" Link="SampleHelper.cs" />
  </ItemGroup>

  <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
</Project>
```

#### appsettings.json.sample
Configuration template:

```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource-name.services.ai.azure.com/",
    "Key": ""
  }
}
```

Include comments explaining authentication options.

#### README.md
Sample-specific documentation:
- What the sample demonstrates
- Prerequisites
- Configuration instructions
- How to run
- Expected output

#### .gitignore
Prevent committing sensitive files:

```
appsettings.json
output/
bin/
obj/
```

### 3. Update Main README

Add your sample to `samples/README.md` in the "Available Samples" table.

## Configuration Pattern

All runnable samples use the standard .NET configuration system with a hierarchical configuration approach:

### Configuration Loading Order (later sources override earlier ones)

1. **Shared Configuration**: `samples/appsettings.json` (used by all samples)
2. **Sample-Specific Configuration**: `samples/SampleName/appsettings.json` (overrides shared)
3. **Environment Variables** (highest priority, overrides all files)

This allows you to:
- Set credentials once in `samples/appsettings.json` and use across all samples
- Override specific settings per sample if needed
- Use environment variables for CI/CD or security-sensitive scenarios

### Environment Variables
```bash
AZURE_CONTENT_UNDERSTANDING_ENDPOINT  # Required
AZURE_CONTENT_UNDERSTANDING_KEY       # Optional (uses DefaultAzureCredential if empty)
```

### appsettings.json Format
```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource-name.services.ai.azure.com/",
    "Key": ""
  }
}
```

### Implementation in SampleHelper.cs

The configuration loading logic looks for files in this order:

```csharp
var configBuilder = new ConfigurationBuilder();

// 1. Shared configuration from samples/ directory
if (!string.IsNullOrEmpty(samplesDirectory))
{
    var sharedConfigPath = Path.Combine(samplesDirectory, "appsettings.json");
    configBuilder.AddJsonFile(sharedConfigPath, optional: true, reloadOnChange: false);
}

// 2. Sample-specific configuration (overrides shared)
configBuilder
    .SetBasePath(currentDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

// 3. Environment variables (highest priority)
configBuilder.AddEnvironmentVariables();
```

## Sample Naming Conventions

- **Directory names**: PascalCase (e.g., `AnalyzeUrl`, `ClassifyDocument`)
- **Project files**: Match directory name (e.g., `AnalyzeUrl.csproj`)
- **Namespace**: Always `Azure.AI.ContentUnderstanding.Samples`
- **Main class**: Always `Program` with `Main` method

## Authentication Pattern

All samples support both authentication methods:

```csharp
ContentUnderstandingClient client;
if (!string.IsNullOrEmpty(config.Key))
{
    // API Key authentication (for testing)
    client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(config.Key));
}
else
{
    // DefaultAzureCredential (recommended)
    client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());
}
```

## Best Practices

1. **Clear Output**: Use emojis (🔍, 📄, ✅, etc.) to make console output easier to read
2. **Error Messages**: Provide helpful error messages with next steps
3. **Comments**: Explain WHY, not just WHAT
4. **Simplicity**: Keep samples focused on one scenario
5. **Documentation**: Each sample should be self-documented
6. **Security**: Never commit API keys or credentials
7. **Consistency**: Follow the established patterns

## Testing Samples

Before committing a new sample:

```bash
cd samples/YourSampleName
dotnet restore
dotnet build
dotnet run  # Test with your credentials
```

Verify:
- ✅ Sample builds without errors
- ✅ Sample runs successfully
- ✅ Configuration loading works
- ✅ Error handling is appropriate
- ✅ Console output is clear
- ✅ README is accurate

## Questions?

- See existing samples for reference (e.g., `AnalyzeUrl/`)
- Check the main [README.md](README.md)
- Review Azure SDK guidelines: https://azure.github.io/azure-sdk/dotnet_introduction.html

