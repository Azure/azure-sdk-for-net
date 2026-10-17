// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.RegularExpressions;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Mcp.Tests.GenerationTests;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class StorageGenerationTests
{
    [TestCase("main.tsp", "cc7a896723160ba38bc0c40caf8037ec4e3596292b99bab7b71a1568254549b3")]
    [TestCase("client.tsp", "3adc0558d34920544a1af7191a41498b1e923178b13d7a0cc847c6cb3c74bb9c")]
    [TestCase("Common/service.tsp", "f7cc7c985b8ec48fb70dfafea552318ff34af6497e741db6ba45322329f96874")]
    [TestCase("Common/routes.tsp", "555f4a78dde007eaea133c138bac3ece004bd27d33974b608e248e4dae3b1147")]
    [TestCase("Common/models.tsp", "8037b8bdbc6d628614e4ee8131016c56d458421d7c5eb2ccdbf5c61124646cc5")]
    public void PinnedServiceSourceIsUnchanged(string relativePath, string expectedHash)
    {
        var path = Path.Combine(FindPackage(), "emitter", "test", "fixtures", "specification", "storage",
            "data-plane", "BlobStorage", relativePath.Replace('/', Path.DirectorySeparatorChar));
        var hash = Convert.ToHexStringLower(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(path)));
        Assert.That(hash, Is.EqualTo(expectedHash), "Update service source and its pinned provenance together, not to accommodate the MCP emitter.");
    }

    [Test]
    public async Task UnrelatedServiceCommandsGenerateAndExecuteWithoutStorageMappings()
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
            await BuildMetadata(root, Path.Combine(source, "bin", "Debug", "net10.0"), "Microsoft.Mcp.Core", McpCoreTypes);
            File.WriteAllText(Path.Combine(source, "Example.csproj"), """
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework></PropertyGroup>
                  <ItemGroup><Reference Include="Microsoft.Mcp.Core" HintPath="bin/Debug/net10.0/Microsoft.Mcp.Core.dll" /></ItemGroup>
                </Project>
                """);
            File.WriteAllText(Path.Combine(source, "Handler.cs"), """
                using System.Threading;
                using System.Threading.Tasks;
                namespace Example;
                public sealed class Model { public string Name { get; set; } }
                public interface IService
                {
                    /// <param name="name">Resource name.</param>
                    /// <param name="limit">Optional limit.</param>
                    Task<Model> GetAsync(string name,int? limit,CancellationToken token);
                    /// <param name="name">Resource name.</param>
                    /// <param name="force">Whether to force deletion.</param>
                    Task<Model> DeleteAsync(string name,bool force,CancellationToken token);
                }
                public sealed class Service : IService
                {
                    public Task<Model> GetAsync(string name,int? limit,CancellationToken token) => Task.FromResult(new Model { Name=name+limit });
                    public Task<Model> DeleteAsync(string name,bool force,CancellationToken token) => Task.FromResult(new Model { Name=name+force });
                }
                """);
            File.WriteAllText(Path.Combine(source, "Program.cs"), """
                using System;
                using System.Threading;
                using System.Threading.Tasks;
                using Example;
                using Example.Generated;
                using Microsoft.Extensions.Logging;
                using Microsoft.Mcp.Core.Models.Command;
                var service = new Service();
                var read = await new ResourceGetCommand(new Logger<ResourceGetCommand>(),service)
                    .ExecuteAsync(new CommandContext(),new ResourceGetOptions { Name="secret",Limit=3 },CancellationToken.None);
                var deleted = await new QueueDeleteCommand(new Logger<QueueDeleteCommand>(),service)
                    .ExecuteAsync(new CommandContext(),new QueueDeleteOptions { Name="queue",Force=true },CancellationToken.None);
                if(read.Results?.Json != "{\"resource\":{\"name\":\"secret3\"}}" ||
                    deleted.Results?.Json != "{\"queue\":{\"name\":\"queueTrue\"}}") throw new Exception("Command dispatch/result mismatch.");
                if(!ResourceGetCatalog.ReadOnly || !QueueDeleteCatalog.Destructive) throw new Exception("HTTP safety defaults changed.");
                Console.WriteLine("Unrelated commands executed.");
                sealed class Logger<T> : ILogger<T> { public void Error(Exception exception,string message) => throw new Exception(message,exception); }
                """);
            File.WriteAllText(Path.Combine(root, "main.tsp"), """
                using TypeSpec.Http;
                using Azure.Mcp;
                @service @server("{endpoint}", "Endpoint.", {endpoint: url})
                @mcpService(#{outputNamespace: "Example.Generated", metadataReferences: #["src/bin/Debug/net10.0/Microsoft.Mcp.Core.dll"]})
                namespace Example;
                interface Resources {
                  @get @route("/resources/{name}")
                  @command(#{
                    id: "12b53c92-f2cf-4a1a-880d-c6f44a0d49d6", path: "example resource get", title: "Get resource",
                    commandType: "Example.Generated.ResourceGetCommand", handler: #{type: "Example.IService", member: "GetAsync"},
                    resultName: "Resource", safety: #{}
                  })
                  get(@path name: string,@query limit?: int32): void;
                }
                interface Queues {
                  @delete @route("/queues/{name}")
                  @command(#{
                    id: "b5b72a82-d8fc-43b4-ad65-06fd8388dd19", path: "example queue delete", title: "Delete queue",
                    commandType: "Example.Generated.QueueDeleteCommand", handler: #{type: "Example.IService", member: "DeleteAsync"},
                    resultName: "Queue", safety: #{}
                  })
                  remove(@path name: string,@query force: boolean): void;
                }
                """);
            File.WriteAllText(Path.Combine(root, "tspconfig.yaml"), JsonSerializer.Serialize(new
            {
                emit = new[] { package },
                options = new Dictionary<string, object>
                {
                    ["@azure-typespec/mcp-tools"] = new Dictionary<string, object>
                    {
                        ["emitter-output-dir"] = root, ["package-name"] = "Example", ["new-project"] = false
                    }
                }
            }));
            var emitted = await Run("node", root,
                Path.Combine(package, "node_modules", "@typespec", "compiler", "cmd", "tsp.js"),
                "compile", "main.tsp", "--import", Path.Combine(package, "lib", "main.tsp"));
            Assert.That(emitted.ExitCode, Is.Zero, emitted.Output);
            Assert.That(Directory.GetFiles(Path.Combine(source, "Generated"), "*.cs"), Has.Length.EqualTo(8));
            var compiled = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);
            var executed = await Run("dotnet", source, "run", "--no-build");
            Assert.That(executed.ExitCode, Is.Zero, executed.Output);
            Assert.That(executed.Output, Does.Contain("Unrelated commands executed."));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task LegacySdkBindingGeneratesCompilesAndExecutes()
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
            File.Copy(Path.Combine(package, "emitter", "test", "fixtures", "sdk-binding.tsp"), Path.Combine(root, "storage.tsp"));
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
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    [Test]
    public async Task ExistingServiceWithCompactOverlayGeneratesCompleteCommand()
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
            await BuildMetadata(root, Path.Combine(source, "bin", "Debug", "net10.0"), "Microsoft.Mcp.Core", McpCoreTypes);
            await BuildMetadata(root, Path.Combine(source, "bin", "Debug", "net10.0"), "Azure.Mcp.Core", AzureCoreTypes);
            File.WriteAllText(Path.Combine(source, "Azure.Mcp.Tools.Storage.csproj"), """
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <OutputType>Exe</OutputType>
                    <TargetFramework>net10.0</TargetFramework>
                    <Nullable>enable</Nullable>
                    <ImplicitUsings>enable</ImplicitUsings>
                    <DefineConstants>MCP_GENERATED</DefineConstants>
                  </PropertyGroup>
                  <ItemGroup>
                    <Reference Include="Microsoft.Mcp.Core" HintPath="bin/Debug/net10.0/Microsoft.Mcp.Core.dll" />
                    <Reference Include="Azure.Mcp.Core" HintPath="bin/Debug/net10.0/Azure.Mcp.Core.dll" />
                  </ItemGroup>
                </Project>
                """);
            File.WriteAllText(Path.Combine(source, "ExistingTypes.cs"), ExistingTypes);
            File.WriteAllText(Path.Combine(source, "Handler.cs"), HandlerTypes);
            File.WriteAllText(Path.Combine(source, "Program.cs"), CompleteCommandProgram);
            var fixtures = Path.Combine(package, "emitter", "test", "fixtures");
            foreach (var file in Directory.GetFiles(Path.Combine(fixtures, "specification"), "*.tsp", SearchOption.AllDirectories))
            {
                var target = Path.Combine(root, Path.GetRelativePath(fixtures, file));
                Directory.CreateDirectory(Path.GetDirectoryName(target)!);
                File.Copy(file, target);
            }
            var overlay = File.ReadAllText(Path.Combine(fixtures, "storage.tsp"));
            File.WriteAllText(Path.Combine(root, "storage.tsp"), overlay);
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
                "ContainerCreateCommand.cs", "ContainerCreateCatalog.cs", "ContainerCreateOptions.cs", "ContainerCreateJsonContext.cs"
            }));
            var command = File.ReadAllText(Path.Combine(generated, "ContainerCreateCommand.cs"));
            Assert.That(command, Does.Contain("class ContainerCreateCommand(").And.Contain("record ContainerCreateCommandResult"));
            Assert.That(command, Does.Contain("record ContainerCreateCommandResult(ContainerInfo Container);"));
            Assert.That(command, Does.Contain("handler.CreateContainer(options.Account, options.Container, options.Tenant, cancellationToken)"));
            var generatedCharacters = Directory.GetFiles(generated, "*.cs").Sum(file => Regex.Replace(File.ReadAllText(file), @"\s+", "").Length);
            Assert.That(Regex.Replace(overlay, @"\s+", "").Length, Is.LessThan(generatedCharacters),
                "MCP authoring must be smaller than its complete generated output, independently of formatting.");
            Assert.That(File.Exists(Path.Combine(root, "tspMcpCodeModel.json")), Is.False);
            var compiled = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);
            var executed = await Run("dotnet", source, "run", "--no-build");
            Assert.That(executed.ExitCode, Is.Zero, executed.Output);
            Assert.That(executed.Output, Does.Contain("Complete generated Storage command executed successfully."));
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
            public enum ToolOperationPlane { Data, Control }
            [AttributeUsage(AttributeTargets.Class)]
            public sealed class CommandMetadataAttribute : Attribute
            {
                public required string Id { get; init; }
                public required string Name { get; init; }
                public required string Title { get; init; }
                public required string Description { get; init; }
                public required ToolOperationPlane OperationPlane { get; init; }
                public required bool Destructive { get; init; }
                public required bool Idempotent { get; init; }
                public required bool OpenWorld { get; init; }
                public required bool ReadOnly { get; init; }
                public required bool Secret { get; init; }
                public required bool LocalRequired { get; init; }
            }
            public abstract class AuthenticatedCommand<TOptions,TResult> where TOptions : class
            {
                public virtual System.Text.Json.Serialization.Metadata.JsonTypeInfo<TResult>? ResultTypeInfo => null;
                public abstract Task<Models.Command.CommandResponse> ExecuteAsync(
                    Models.Command.CommandContext context,TOptions options,CancellationToken cancellationToken);
                protected virtual string GetErrorMessage(Exception exception) => exception.Message;
                protected void HandleException(Models.Command.CommandContext context,Exception exception)
                {
                    context.Response.Error = GetErrorMessage(exception);
                    context.Response.Status = exception is Azure.RequestFailedException request ? request.Status : 500;
                }
            }
        }
        namespace Microsoft.Mcp.Core.Options
        {
            [AttributeUsage(AttributeTargets.Property)]
            public class OptionAttribute : Attribute { public string? Description { get; set; } }
        }
        namespace Microsoft.Mcp.Core.Models.Command
        {
            public class CommandContext { public CommandResponse Response { get; } = new(); }
            public class CommandResponse
            {
                public ResponseResult? Results { get; set; }
                public string? Error { get; set; }
                public int Status { get; set; } = 200;
            }
            public class ResponseResult
            {
                public required string Json { get; init; }
                public static ResponseResult Create<T>(T value,System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info) =>
                    new() { Json = System.Text.Json.JsonSerializer.Serialize(value,info) };
            }
        }
        namespace Microsoft.Extensions.Logging
        {
            public interface ILogger<T> { void Error(Exception exception,string message); }
            public static class LoggerExtensions
            {
                public static void LogError<T>(ILogger<T> logger,Exception exception,string message) => logger.Error(exception,message);
            }
        }
        namespace Azure
        {
            public class RequestFailedException(int status,string message) : Exception(message) { public int Status => status; }
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
        #if !MCP_GENERATED
            public class ContainerCreateCommand { public const string CustomizedDescription = "Reviewed Storage description."; }
        #endif
        }
        namespace Azure.Mcp.Tools.Storage.Models
        {
            public class ContainerInfo { public string? Name { get; set; } }
        }
        """;

    private const string HandlerTypes = """
        using System;
        using System.Threading;
        using System.Threading.Tasks;

        namespace Azure.Mcp.Tools.Storage.Services
        {
            public interface IStorageService
            {
                Task<Models.ContainerInfo> CreateContainer(string account,string container,string? tenant=null,CancellationToken cancellationToken=default);
            }
        }
        namespace Azure.Mcp.Tools.Storage.Commands.Blob.Container
        {
            internal static class ContainerCreateCustomization
            {
                internal const string Description = "Reviewed Storage description.";
                internal static string? GetErrorMessage(Exception exception) => exception is InvalidOperationException ? "Reviewed failure." : null;
            }
        }
        """;

    private const string CompleteCommandProgram = """
        using Azure.Mcp.Tools.Storage.GeneratedMcp;
        using Azure.Mcp.Tools.Storage.Commands.Blob.Container;
        using Azure.Mcp.Tools.Storage.Models;
        using Azure.Mcp.Tools.Storage.Services;
        using Microsoft.Mcp.Core.Commands;
        using Microsoft.Mcp.Core.Models.Command;
        using Microsoft.Extensions.Logging;
        using System.Reflection;
        using System.Text.Json;

        var service = new Service();
        var logger = new Logger();
        var command = new ContainerCreateCommand(logger,service);
        using var cancellation = new CancellationTokenSource();
        var options = new ContainerCreateOptions { Account="account",Container="example",Tenant="tenant" };
        var context = new CommandContext();
        var response = await command.ExecuteAsync(context,options,cancellation.Token);
        Require(ReferenceEquals(response,context.Response),"Command must return the actual context response.");
        Require(service.Arguments == ("account","example","tenant",cancellation.Token),"All handler arguments and cancellation must be forwarded.");
        Require(response.Results?.Json == "{\"container\":{\"name\":\"example\"}}","Result must be serialized with its generated context.");
        var roundtrip = JsonSerializer.Deserialize(response.Results!.Json,ContainerCreateJsonContext.Default.ContainerCreateCommandResult)!;
        roundtrip.Deconstruct(out var containerInfo);
        Require(containerInfo.Name == "example","The result must deserialize and retain its positional-record contract.");
        Require((roundtrip with { Container = new ContainerInfo { Name = "copy" } }).Container.Name == "copy",
            "The result must retain its init property/record copy contract.");
        Require(command.ResultTypeInfo is null,"Do not change the existing catalog output schema.");
        var metadata = typeof(ContainerCreateCommand).GetCustomAttribute<CommandMetadataAttribute>()!;
        Require(metadata.Id == ContainerCreateCatalog.Id && metadata.Name == "create" &&
            metadata.Title == "Create Storage Blob Container" && metadata.Description == ContainerCreateCustomization.Description,
            "Command metadata identity changed.");
        Require(metadata.Destructive && !metadata.Idempotent && !metadata.ReadOnly && !metadata.OpenWorld &&
            !metadata.Secret && !metadata.LocalRequired && metadata.OperationPlane == ToolOperationPlane.Data,"Safety metadata changed.");
        Require(ContainerCreateCatalog.OperationId == "Storage.Blob.Container.create","Must select the original service operation.");
        Require(ContainerCreateCatalog.Path == "storage blob container create","Tool path changed.");
        var group = new CommandGroup();
        ContainerCreateCatalog.Register(group,new Services());
        Require(group.Registered == typeof(ContainerCreateCommand),"Catalog must register the generated command.");
        Require(typeof(ContainerCreateOptions).GetProperty("Account")!.IsDefined(typeof(System.Runtime.CompilerServices.RequiredMemberAttribute)) &&
            typeof(ContainerCreateOptions).GetProperty("Container")!.IsDefined(typeof(System.Runtime.CompilerServices.RequiredMemberAttribute)),
            "Infer required properties from the handler.");
        Require(new ContainerCreateOptions { Account="a",Container="c" }.Tenant is null,"Nullable tenant must stay optional.");
        service.Failure = new InvalidOperationException("details");
        response = await command.ExecuteAsync(new(),options,cancellation.Token);
        Require(response.Error == "Reviewed failure." && response.Status == 500 && logger.Errors == 1,"Custom policy/base error handling/logging must run.");
        service.Failure = new Azure.RequestFailedException(429,"throttled");
        response = await command.ExecuteAsync(new(),options,cancellation.Token);
        Require(response.Error == "Storage request failed (HTTP 429): throttled" && response.Status == 429 && logger.Errors == 2,
            "Default request failure format/status changed.");
        service.Failure = new OperationCanceledException("cancelled");
        response = await command.ExecuteAsync(new(),options,cancellation.Token);
        Require(response.Error == "cancelled" && logger.Errors == 3,"Non-HTTP failures must go through the existing base handler.");
        Console.WriteLine("Complete generated Storage command executed successfully.");
        static void Require(bool condition,string message) { if(!condition) throw new InvalidOperationException(message); }
        sealed class Services : IServiceProvider { public object? GetService(Type type) => null; }
        sealed class Logger : ILogger<ContainerCreateCommand>
        {
            public int Errors;
            public void Error(Exception exception,string message)
            {
                Errors++;
                if(message.Contains("tenant")) throw new InvalidOperationException("Do not log option values.");
            }
        }
        sealed class Service : IStorageService
        {
            public (string,string,string?,CancellationToken) Arguments;
            public Exception? Failure;
            public Task<ContainerInfo> CreateContainer(string account,string container,string? tenant=null,CancellationToken cancellationToken=default)
            {
                Arguments=(account,container,tenant,cancellationToken);
                return Failure is null ? Task.FromResult(new ContainerInfo { Name=container }) : Task.FromException<ContainerInfo>(Failure);
            }
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
