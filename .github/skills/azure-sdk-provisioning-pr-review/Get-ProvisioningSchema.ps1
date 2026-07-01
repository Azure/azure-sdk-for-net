[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $PackagePath,

    [string] $OutputPath,

    [ValidateSet('Json', 'Markdown')]
    [string] $Format = 'Json',

    [string] $Framework = 'net10.0'
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

$resolvedPackagePath = (Resolve-Path -LiteralPath $PackagePath).Path
$project = Get-ChildItem -LiteralPath (Join-Path $resolvedPackagePath 'src') -Filter '*.csproj' -File |
    Select-Object -First 1
if ($null -eq $project)
{
    throw "Could not find a src project under $resolvedPackagePath"
}

$tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) "azprov-schema-$([System.Guid]::NewGuid())"
New-Item -ItemType Directory -Path $tempRoot -Force | Out-Null

try
{
    $escapedProjectPath = [System.Security.SecurityElement]::Escape($project.FullName)
    $extractorProject = Join-Path $tempRoot 'SchemaExtractor.csproj'
    $extractorProgram = Join-Path $tempRoot 'Program.cs'

    @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>$Framework</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="$escapedProjectPath" />
  </ItemGroup>
</Project>
"@ | Set-Content -LiteralPath $extractorProject -Encoding utf8

    @'
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

static string GetFriendlyName(Type type)
{
    if (!type.IsGenericType)
    {
        return type.Name;
    }

    string name = type.Name;
    int tick = name.IndexOf('`');
    if (tick >= 0)
    {
        name = name[..tick];
    }

    return $"{name}<{string.Join(", ", type.GetGenericArguments().Select(GetFriendlyName))}>";
}

static string GetResourceTypeString(ResourceType resourceType)
{
    PropertyInfo? namespaceProperty = resourceType.GetType().GetProperty("Namespace");
    PropertyInfo? typeProperty = resourceType.GetType().GetProperty("Type");
    string? resourceNamespace = namespaceProperty?.GetValue(resourceType)?.ToString();
    string? type = typeProperty?.GetValue(resourceType)?.ToString();
    return !string.IsNullOrEmpty(resourceNamespace) && !string.IsNullOrEmpty(type) ?
        $"{resourceNamespace}/{type}" :
        resourceType.ToString();
}

static string GetKind(IBicepValue property)
{
    Type type = property.GetType();
    if (type.IsGenericType)
    {
        Type generic = type.GetGenericTypeDefinition();
        if (generic == typeof(BicepValue<>))
        {
            return "Property";
        }
        if (generic == typeof(BicepList<>))
        {
            return "ListProperty";
        }
        if (generic == typeof(BicepDictionary<>))
        {
            return "DictionaryProperty";
        }
    }

    return property is ProvisionableConstruct ? "ModelProperty" : type.Name;
}

static PropertyInfo? GetVisibleProperty(Type resourceType, string propertyName) =>
    resourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        .Where(p => p.Name == propertyName)
        .OrderByDescending(p => p.DeclaringType == resourceType)
        .ThenBy(p => p.GetMethod is null ? 1 : 0)
        .FirstOrDefault();

string assemblyPath = args[0];
string packagePath = args[1];
Assembly assembly = Assembly.LoadFrom(assemblyPath);
MethodInfo initialize = typeof(ProvisionableConstruct).GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic)
    ?? throw new InvalidOperationException("Could not find ProvisionableConstruct.Initialize.");

List<object> resources = [];
foreach (Type type in assembly.GetTypes().Where(t => t is { IsClass: true, IsAbstract: false } && typeof(ProvisionableResource).IsAssignableFrom(t)).OrderBy(t => t.FullName))
{
    ConstructorInfo? constructor = type.GetConstructor([typeof(string), typeof(string)]);
    if (constructor is null)
    {
        continue;
    }

    ProvisionableResource? resource = null;
    string? constructionError = null;
    try
    {
        resource = (ProvisionableResource)constructor.Invoke(["schemaResource", null]);
    }
    catch (TargetInvocationException ex)
    {
        constructionError = ex.InnerException?.Message ?? ex.Message;
    }

    if (resource is null)
    {
        resources.Add(new
        {
            ClassName = type.Name,
            ResourceType = "",
            DefaultApiVersion = "",
            ApiVersions = Array.Empty<string>(),
            Assembly = assemblyPath,
            InitializationError = constructionError,
            Properties = Array.Empty<object>()
        });
        continue;
    }

    string? initializationError = null;
    try
    {
        initialize.Invoke(resource, []);
    }
    catch (TargetInvocationException ex)
    {
        initializationError = ex.InnerException?.Message ?? ex.Message;
    }

    List<object> properties = [];
    if (initializationError is null)
    {
        foreach (KeyValuePair<string, IBicepValue> pair in resource.ProvisionableProperties.OrderBy(p => p.Key))
        {
            PropertyInfo? visibleProperty = GetVisibleProperty(type, pair.Key);
            Type reflectedType = visibleProperty?.PropertyType ?? pair.Value.GetType();
            bool isMetadata = typeof(ProvisionableResource).IsAssignableFrom(reflectedType);

            properties.Add(new
            {
                Name = pair.Key,
                SerializedPath = pair.Value.Self?.BicepPath?.ToArray() ?? [],
                Kind = isMetadata ? "Resource" : GetKind(pair.Value),
                Type = GetFriendlyName(reflectedType),
                IsRequired = pair.Value.IsRequired,
                IsOutput = pair.Value.IsOutput,
                IsMetadata = isMetadata
            });
        }
    }

    Type? resourceVersions = type.GetNestedType("ResourceVersions", BindingFlags.Public | BindingFlags.NonPublic);
    string[] apiVersions = resourceVersions?.GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(f => f.FieldType == typeof(string))
        .Select(f => (string?)f.GetValue(null))
        .Where(v => v is not null)
        .Cast<string>()
        .ToArray() ?? [];

    resources.Add(new
    {
        ClassName = type.Name,
        ResourceType = GetResourceTypeString(resource.ResourceType),
        DefaultApiVersion = resource.ResourceVersion,
        ApiVersions = apiVersions,
        Assembly = assemblyPath,
        InitializationError = initializationError,
        Properties = properties
    });
}

var schema = new
{
    PackagePath = packagePath,
    AssemblyPath = assemblyPath,
    ResourceCount = resources.Count,
    Resources = resources
};

Console.WriteLine(JsonSerializer.Serialize(schema, new JsonSerializerOptions { WriteIndented = true }));
'@ | Set-Content -LiteralPath $extractorProgram -Encoding utf8

    dotnet build $extractorProject --framework $Framework --verbosity quiet | Write-Verbose
    if ($LASTEXITCODE -ne 0)
    {
        throw "dotnet build failed for schema extractor."
    }

    $assemblyPath = dotnet msbuild $project.FullName -getProperty:TargetPath -p:TargetFramework=$Framework
    if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($assemblyPath))
    {
        throw "Could not determine TargetPath for $($project.FullName)"
    }
    $assemblyPath = $assemblyPath.Trim()

    $json = dotnet run --project $extractorProject --framework $Framework --no-build -- $assemblyPath $resolvedPackagePath
    if ($LASTEXITCODE -ne 0)
    {
        throw "Schema extractor failed for $resolvedPackagePath"
    }

    if ($Format -eq 'Json')
    {
        $output = $json -join [Environment]::NewLine
    }
    else
    {
        $schema = ($json -join [Environment]::NewLine) | ConvertFrom-Json
        $lines = [System.Collections.Generic.List[string]]::new()
        $lines.Add("# Provisioning Resource Schema")
        $lines.Add("")
        $lines.Add("Package: ``$($schema.PackagePath)``")
        $lines.Add("Assembly: ``$($schema.AssemblyPath)``")
        $lines.Add("")

        foreach ($resource in $schema.Resources)
        {
            $lines.Add("## $($resource.ClassName)")
            $lines.Add("")
            $lines.Add("- Resource type: ``$($resource.ResourceType)``")
            $lines.Add("- Default API version: ``$($resource.DefaultApiVersion)``")
            if (![string]::IsNullOrWhiteSpace($resource.InitializationError))
            {
                $lines.Add("- Initialization error: ``$($resource.InitializationError)``")
            }
            $lines.Add("")
            $lines.Add("| Property | Path | Kind | Type | Required | Output | Metadata |")
            $lines.Add("| --- | --- | --- | --- | --- | --- | --- |")
            foreach ($property in $resource.Properties)
            {
                $path = if ($property.SerializedPath.Count -gt 0) { $property.SerializedPath -join '.' } else { '' }
                $lines.Add("| ``$($property.Name)`` | ``$path`` | $($property.Kind) | ``$($property.Type)`` | $($property.IsRequired) | $($property.IsOutput) | $($property.IsMetadata) |")
            }
            $lines.Add("")
        }

        $output = $lines -join [Environment]::NewLine
    }

    if (![string]::IsNullOrWhiteSpace($OutputPath))
    {
        $outputDirectory = Split-Path -Parent $OutputPath
        if (![string]::IsNullOrWhiteSpace($outputDirectory))
        {
            New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
        }
        Set-Content -LiteralPath $OutputPath -Value $output -Encoding utf8
    }

    $output
}
finally
{
    Remove-Item -LiteralPath $tempRoot -Recurse -Force -ErrorAction SilentlyContinue
}
