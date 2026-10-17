// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Mcp.Tests.GenerationTests;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class StorageGenerationTests
{
    [Test]
    public async Task CheckedInStorageProjectionGeneratesCompilesAndExecutes()
    {
        var package = FindPackage();
        var root = Path.Combine(package, "temp", Guid.NewGuid().ToString("N"));
        var source = Path.Combine(root, "src");
        Directory.CreateDirectory(source);
        try
        {
            File.WriteAllText(Path.Combine(root, "Directory.Build.props"), "<Project />");
            File.WriteAllText(Path.Combine(root, "Directory.Build.targets"), "<Project />");
            File.WriteAllText(Path.Combine(root, "Directory.Packages.props"), "<Project />");
            var metadata = Path.Combine(source, "bin", "Debug", "net10.0");
            await BuildMetadata(root, metadata, "Microsoft.Mcp.Core", McpCoreTypes);
            await BuildMetadata(root, metadata, "Azure.Mcp.Core", AzureCoreTypes);
            File.WriteAllText(Path.Combine(source, "Azure.Mcp.Tools.Storage.csproj"), """
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <OutputType>Exe</OutputType>
                    <TargetFramework>net10.0</TargetFramework>
                    <Nullable>enable</Nullable>
                    <ImplicitUsings>enable</ImplicitUsings>
                  </PropertyGroup>
                  <ItemGroup>
                    <Reference Include="Microsoft.Mcp.Core" HintPath="bin/Debug/net10.0/Microsoft.Mcp.Core.dll" />
                    <Reference Include="Azure.Mcp.Core" HintPath="bin/Debug/net10.0/Azure.Mcp.Core.dll" />
                  </ItemGroup>
                </Project>
                """);
            File.WriteAllText(Path.Combine(source, "ExistingTypes.cs"), ExistingTypes);
            File.WriteAllText(Path.Combine(source, "Program.cs"), ConsumerProgram);
            File.Copy(Path.Combine(package, "emitter", "test", "fixtures", "storage.tsp"), Path.Combine(root, "storage.tsp"));
            File.WriteAllText(Path.Combine(root, "tspconfig.yaml"), JsonSerializer.Serialize(new
            {
                emit = new[] { package },
                options = new Dictionary<string, object>
                {
                    ["@azure-typespec/mcp-tools"] = new Dictionary<string, object>
                    {
                        ["emitter-output-dir"] = root,
                        ["package-name"] = "Azure.Mcp.Tools.Storage",
                        ["new-project"] = false,
                        ["license"] = new { name = "MIT License", company = "Microsoft Corporation" }
                    }
                }
            }));
            var emitted = await Run("node", root,
                Path.Combine(package, "node_modules", "@typespec", "compiler", "cmd", "tsp.js"),
                "compile", "storage.tsp", "--import", Path.Combine(package, "lib", "main.tsp"));
            Assert.That(emitted.ExitCode, Is.Zero, emitted.Output);
            var generated = Path.Combine(source, "Generated");
            Assert.That(Directory.GetFiles(generated, "*.cs").Select(Path.GetFileName), Is.EquivalentTo(new[]
            {
                "ContainerCreateBinding.cs", "ContainerCreateCatalog.cs", "GeneratedContainerCreateOptions.cs",
                "GeneratedContainerCreateResult.cs", "GeneratedStorageJsonContext.cs"
            }));
            var options = File.ReadAllText(Path.Combine(generated, "GeneratedContainerCreateOptions.cs"));
            Assert.That(options, Does.Contain("required string Account").And.Contain("required string Container").And.Contain("string? Tenant"));
            Assert.That(options, Does.Not.Contain("Subscription"));
            Assert.That(File.Exists(Path.Combine(root, "tspMcpCodeModel.json")), Is.False);
            var compiled = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);
            var executed = await Run("dotnet", source, "run", "--no-build");
            Assert.That(executed.ExitCode, Is.Zero, executed.Output);
            Assert.That(executed.Output, Does.Contain("Storage generated scaffolding executed successfully."));
            VerifyCheckedInOutput(package, generated);
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static void VerifyCheckedInOutput(string package, string generated)
    {
        var expected = Path.Combine(package, "generator", "TestProjects", "Local", "Storage", "src", "Generated");
        var files = Directory.GetFiles(generated, "*.cs");
        if (Environment.GetEnvironmentVariable("AZURE_MCP_UPDATE_GENERATED") == "1")
        {
            Directory.CreateDirectory(expected);
            foreach (var stale in Directory.GetFiles(expected, "*.cs").Where(path =>
                !files.Any(file => Path.GetFileName(file) == Path.GetFileName(path))))
            {
                File.Delete(stale);
            }
            foreach (var file in files)
            {
                File.Copy(file, Path.Combine(expected, Path.GetFileName(file)), overwrite: true);
            }
        }
        Assert.That(Directory.Exists(expected), Is.True, "Run npm run generate:storage to create the checked-in output.");
        Assert.That(Directory.GetFiles(expected, "*.cs").Select(Path.GetFileName),
            Is.EquivalentTo(files.Select(Path.GetFileName)), "The checked-in generated file inventory changed.");
        foreach (var file in files)
        {
            Assert.That(File.ReadAllBytes(file),
                Is.EqualTo(File.ReadAllBytes(Path.Combine(expected, Path.GetFileName(file)))),
                $"{Path.GetFileName(file)} differs from the checked-in output. Run npm run generate:storage to update it.");
        }
    }

    private static async Task BuildMetadata(string root, string output, string name, string code)
    {
        var directory = Path.Combine(root, "metadata", name);
        Directory.CreateDirectory(directory);
        File.WriteAllText(Path.Combine(directory, name + ".csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <TargetFramework>net10.0</TargetFramework>
                <Nullable>enable</Nullable>
                <ImplicitUsings>enable</ImplicitUsings>
              </PropertyGroup>
            </Project>
            """);
        File.WriteAllText(Path.Combine(directory, "Types.cs"), code);
        var built = await Run("dotnet", directory, "build", "--output", output, "--nologo", "--verbosity", "quiet");
        Assert.That(built.ExitCode, Is.Zero, built.Output);
    }

    private const string McpCoreTypes = """
        namespace Microsoft.Mcp.Core.Commands
        {
            public class CommandGroup
            {
                public Type? Registered { get; private set; }
                public void AddCommand<T>(IServiceProvider services) => Registered = typeof(T);
            }
        }
        namespace Microsoft.Mcp.Core.Options
        {
            [AttributeUsage(AttributeTargets.Property)]
            public class OptionAttribute : Attribute { public string? Description { get; set; } }
        }
        """;

    private const string AzureCoreTypes = """
        namespace Azure.Mcp.Core.Options;
        public static class OptionDescriptions { public const string Tenant = "The tenant."; }
        """;

    private const string ExistingTypes = """
        namespace Azure.Storage.Blobs
        {
            public class BlobServiceClient
            {
                public string? RequestedContainer { get; private set; }
                public BlobContainerClient Client { get; } = new();
                public BlobContainerClient GetBlobContainerClient(string container)
                {
                    RequestedContainer = container;
                    return Client;
                }
            }
            public class BlobContainerClient
            {
                public Models.PublicAccessType? Access { get; private set; }
                public CancellationToken Token { get; private set; }
                public Task CreateAsync(Models.PublicAccessType access, CancellationToken cancellationToken)
                {
                    Access = access;
                    Token = cancellationToken;
                    return Task.CompletedTask;
                }
            }
        }
        namespace Azure.Storage.Blobs.Models { public enum PublicAccessType { None, Blob, Container } }
        namespace Azure.Mcp.Tools.Storage.Commands.Blob.Container
        {
            public class ContainerCreateCommand { public const string CustomizedDescription = "Reviewed Storage description."; }
        }
        namespace Azure.Mcp.Tools.Storage.Models
        {
            public class ContainerInfo { public string? Name { get; set; } }
        }
        """;

    private const string ConsumerProgram = """
        using Azure.Mcp.Tools.Storage.GeneratedMcp;
        using Azure.Mcp.Tools.Storage.Commands.Blob.Container;
        using Azure.Mcp.Tools.Storage.Models;
        using Azure.Storage.Blobs;
        using Azure.Storage.Blobs.Models;
        using Microsoft.Mcp.Core.Commands;
        using System.Text.Json;
        using System.Text.Json.Serialization;
        using System.Reflection;

        var service = new BlobServiceClient();
        using var cancellation = new CancellationTokenSource();
        var client = await ContainerCreateBinding.CreateAsync(service, "example", cancellation.Token);
        Require(ReferenceEquals(client, service.Client), "The binding must return the SDK container client.");
        Require(service.RequestedContainer == "example", "The container name must reach the SDK.");
        Require(client.Access == PublicAccessType.None, "Containers must be private.");
        Require(client.Token == cancellation.Token, "Cancellation must be forwarded.");
        Require(ContainerCreateCatalog.Path == "storage blob container create", "Command path changed.");
        Require(ContainerCreateCatalog.Id == "f5088334-e630-4df0-a5be-ac87787acad0", "Tool ID changed.");
        Require(ContainerCreateCatalog.Description == ContainerCreateCommand.CustomizedDescription, "Description override was lost.");
        Require(ContainerCreateCatalog.Destructive && !ContainerCreateCatalog.Idempotent &&
            !ContainerCreateCatalog.ReadOnly && !ContainerCreateCatalog.OpenWorld, "Reviewed safety flags changed.");
        Require(ContainerCreateCatalog.GetDefaultError(409, "conflict") ==
            "Storage request failed (HTTP 409): conflict", "Error format changed.");
        var group = new CommandGroup();
        ContainerCreateCatalog.Register(group, new Services());
        Require(group.Registered == typeof(ContainerCreateCommand), "Wrong command registration.");
        var options = new GeneratedContainerCreateOptions { Account = "account", Container = "example" };
        Require(options.Tenant is null, "Ambient tenant must remain optional.");
        Require(typeof(GeneratedContainerCreateOptions).GetProperty("Account")!
            .IsDefined(typeof(System.Runtime.CompilerServices.RequiredMemberAttribute)), "Account must remain required.");
        var json = JsonSerializer.Serialize(new GeneratedContainerCreateResult
        {
            Container = new ContainerInfo { Name = "example" }
        }, GeneratedStorageJsonContext.Default.GeneratedContainerCreateResult);
        Require(json == "{\"container\":{\"name\":\"example\"}}", "JSON contract changed: " + json);
        Require(GeneratedStorageJsonContext.Default.Options.DefaultIgnoreCondition ==
            JsonIgnoreCondition.WhenWritingDefault, "Default JSON values must be omitted.");
        Console.WriteLine("Storage generated scaffolding executed successfully.");
        static void Require(bool condition, string message)
        {
            if (!condition) throw new InvalidOperationException(message);
        }
        sealed class Services : IServiceProvider { public object? GetService(Type type) => null; }
        """;
}
