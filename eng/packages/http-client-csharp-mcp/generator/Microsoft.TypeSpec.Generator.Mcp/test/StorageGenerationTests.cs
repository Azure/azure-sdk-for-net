// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Mcp.Tests.GenerationTests;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class StorageGenerationTests
{
    private string _package = null!;
    private string _root = null!;
    private string _cli = null!;

    [OneTimeSetUp]
    public async Task SyncPinnedServiceWithTspClient()
    {
        _package = FindPackage();
        _root = Path.Combine(_package, "temp", "storage-" + Guid.NewGuid().ToString("N"));
        _cli = Path.GetFullPath(Path.Combine(_package, "..", "..", "common", "tsp-client", "node_modules",
            "@azure-tools", "typespec-client-generator-cli", "dist", "index.js"));
        Assert.That(File.Exists(_cli), Is.True, "Run npm ci --prefix eng/common/tsp-client before Storage generation.");
        Directory.CreateDirectory(_root);
        IsolateBuild(_root);
        File.Copy(Path.Combine(_package, "generator", "TestProjects", "Local", "Storage", "tsp-location.yaml"),
            Path.Combine(_root, "tsp-location.yaml"));
        var synced = await Run("node", _root, _cli, "sync", "--output-dir", _root);
        Assert.That(synced.ExitCode, Is.Zero, synced.Output);
        // Use the local emitter's package self-reference and its one pinned dependency graph.
        foreach (var name in new[] { "package.json", "package-lock.json" })
        {
            File.Delete(Path.Combine(_root, "TempTypeSpecFiles", name));
        }
        var staged = Path.Combine(_root, "TempTypeSpecFiles", "BlobStorage");
        File.Copy(Path.Combine(_package, "emitter", "test", "fixtures", "storage.tsp"), Path.Combine(staged, "storage.tsp"));
        WriteConfiguration(staged, _root, "Azure.Mcp.Tools.Storage", import: true);
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        if (_root is not null && Directory.Exists(_root))
        {
            Directory.Delete(_root, recursive: true);
        }
    }

    [Test]
    public void ServiceSourcesAreImportedThroughTheStandardLocation()
    {
        var staged = Path.Combine(_root, "TempTypeSpecFiles", "BlobStorage");
        foreach (var relative in new[] { "main.tsp", "client.tsp", "Common/service.tsp", "Common/routes.tsp", "Common/models.tsp" })
        {
            Assert.That(File.Exists(Path.Combine(staged, relative.Replace('/', Path.DirectorySeparatorChar))), Is.True);
        }
        var vendored = Path.Combine(_package, "emitter", "test", "fixtures", "specification", "storage");
        Assert.That(Directory.Exists(vendored) ? Directory.GetFiles(vendored, "*.tsp", SearchOption.AllDirectories) : [], Is.Empty,
            "Do not vendor upstream TypeSpec when tsp-client owns the source revision.");
    }

    [Test]
    public async Task FirstGenerationEmitsRestServiceBeforeAnyConvenienceCodeExists()
    {
        var source = await CreateConsumer(_root, "Azure.Mcp.Tools.Storage");
        var emitted = await Generate();
        Assert.That(emitted.ExitCode, Is.Zero, emitted.Output);
        var generated = Path.Combine(source, "Generated");
        Assert.That(Directory.GetFiles(generated, "*.cs").Select(Path.GetFileName), Is.EquivalentTo(new[]
        {
            "ContainerCreateCommand.cs", "ContainerCreateCatalog.cs", "ContainerCreateOptions.cs", "ContainerCreateJsonContext.cs",
            "ContainerCreateRequest.cs", "ContainerCreateResponse.cs", "ContainerCreateService.cs"
        }));
        var service = File.ReadAllText(Path.Combine(generated, "ContainerCreateService.cs"));
        Assert.That(service, Does.Contain("public partial Task<ContainerCreateResponse> CreateContainerAsync("));
        Assert.That(service, Does.Not.Contain("NotImplementedException").And.Not.Contain("IStorageService"));
        var request = File.ReadAllText(Path.Combine(generated, "ContainerCreateRequest.cs"));
        Assert.That(request, Does.Contain("required Uri Url").And.Contain("Dictionary<string, string>? Metadata")
            .And.Contain("string? Access").And.Contain("int? Timeout").And.Contain("\"2026-12-06\""));
        Assert.That(File.ReadAllText(Path.Combine(generated, "ContainerCreateResponse.cs")), Does.Not.Contain(" Body "));
        var incomplete = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
        Assert.That(incomplete.ExitCode, Is.Not.Zero);
        Assert.That(incomplete.Output, Does.Contain("CS8795"), "An implementation must be required, not a successful no-op.");

        var partialPath = Path.Combine(source, "ContainerCreateService.cs");
        File.WriteAllText(partialPath, StoragePartial);
        File.WriteAllText(Path.Combine(source, "Program.cs"), StorageProgram);
        EnableExecutable(source);
        var regenerated = await Generate();
        Assert.That(regenerated.ExitCode, Is.Zero, regenerated.Output);
        Assert.That(File.ReadAllText(partialPath), Is.EqualTo(StoragePartial), "Generation must preserve the handwritten partial.");
        var compiled = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
        Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);
        var executed = await Run("dotnet", source, "run", "--no-build");
        Assert.That(executed.ExitCode, Is.Zero, executed.Output);
        Assert.That(executed.Output, Does.Contain("Generated Storage service contract executed."));
        var bytes = Directory.GetFiles(generated, "*.cs").ToDictionary(file => Path.GetFileName(file)!, File.ReadAllBytes);
        var verified = await Generate();
        Assert.That(verified.ExitCode, Is.Zero, verified.Output);
        foreach (var file in Directory.GetFiles(generated, "*.cs"))
        {
            Assert.That(File.ReadAllBytes(file), Is.EqualTo(bytes[Path.GetFileName(file)]), "Regeneration must be byte-stable.");
        }
        VerifyCheckedInOutput(_package, generated);
    }

    [Test]
    public async Task UnrelatedTypedResponseAndRecursiveModelNeedNoSourceHandler()
    {
        var root = Path.Combine(_package, "temp", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            IsolateBuild(root);
            var source = await CreateConsumer(root, "Example");
            File.WriteAllText(Path.Combine(root, "main.tsp"), """
                using TypeSpec.Http;
                using Azure.Mcp;
                @service namespace Example;
                model Item { name: string; child?: Item; }
                interface Resource {
                  @get @route("/resources/{name}")
                  @tool("12b53c92-f2cf-4a1a-880d-c6f44a0d49d6", "example resource get", "Get resource")
                  get(@path name: string, @query limit?: int32): Item;
                }
                """);
            WriteConfiguration(root, root, "Example", import: false);
            var emitted = await Run("node", root, Path.Combine(_package, "node_modules", "@typespec", "compiler", "cmd", "tsp.js"),
                "compile", "main.tsp", "--import", Path.Combine(_package, "lib", "main.tsp"));
            Assert.That(emitted.ExitCode, Is.Zero, emitted.Output);
            Assert.That(Directory.GetFiles(Path.Combine(source, "Generated"), "*.cs"), Has.Length.EqualTo(8));
            Assert.That(File.Exists(Path.Combine(root, "tspMcpCodeModel.json")), Is.False);
            File.WriteAllText(Path.Combine(source, "Service.cs"), """
                namespace Example;
                public partial class ResourceGetService
                {
                    public partial Task<ResourceGetResponse> GetResourceAsync(ResourceGetRequest request,CancellationToken cancellationToken)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        return Task.FromResult(new ResourceGetResponse {
                            Status=200, Body=new Item { Name=request.Name+request.Limit,Child=new Item { Name="child" } }
                        });
                    }
                }
                """);
            File.WriteAllText(Path.Combine(source, "Program.cs"), """
                using Example;
                using Microsoft.Extensions.Logging;
                using Microsoft.Mcp.Core.Models.Command;
                using System.Text.Json;
                const string json="{\"endpoint\":\"https://example.test\",\"name\":\"item\",\"limit\":3}";
                var request=JsonSerializer.Deserialize(json,ResourceGetJsonContext.Default.ResourceGetRequest)!;
                if(request.Name!="item" || request.Limit!=3) throw new Exception("Typed request deserialization changed.");
                var response=await new ResourceGetCommand(new Logger(),new ResourceGetService()).ExecuteAsync(
                    new CommandContext(),new ResourceGetOptions { Request=json },CancellationToken.None);
                if(response.Results?.Json!="{\"resource\":{\"status\":200,\"body\":{\"name\":\"item3\",\"child\":{\"name\":\"child\"}}}}")
                    throw new Exception(response.Results?.Json);
                Console.WriteLine("Unrelated typed contract executed.");
                sealed class Logger : ILogger<ResourceGetCommand> { public void Error(Exception exception,string message) => throw new Exception(message,exception); }
                """);
            EnableExecutable(source);
            var compiled = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);
            var executed = await Run("dotnet", source, "run", "--no-build");
            Assert.That(executed.ExitCode, Is.Zero, executed.Output);
            Assert.That(executed.Output, Does.Contain("Unrelated typed contract executed."));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private Task<(int ExitCode, string Output)> Generate() =>
        Run("node", _root, _cli, "generate", "--output-dir", _root, "--skip-install", "--save-inputs", "--debug");

    internal static void IsolateBuild(string root)
    {
        foreach (var name in new[] { "Directory.Build.props", "Directory.Build.targets", "Directory.Packages.props" })
        {
            File.WriteAllText(Path.Combine(root, name), "<Project />");
        }
    }

    internal static async Task<string> CreateConsumer(string root, string name, bool arm = false,
        string sdkPackage = "Azure.ResourceManager.AppNetwork", string sdkVersion = "1.0.0-beta.2")
    {
        var source = Path.Combine(root, "src");
        Directory.CreateDirectory(source);
        var output = Path.Combine(source, "bin", "Debug", "net10.0");
        var metadata = Path.Combine(root, "metadata");
        Directory.CreateDirectory(metadata);
        File.WriteAllText(Path.Combine(metadata, "Microsoft.Mcp.Core.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup><TargetFramework>net10.0</TargetFramework><Nullable>enable</Nullable><ImplicitUsings>enable</ImplicitUsings></PropertyGroup>
            </Project>
            """);
        if (arm)
        {
            var metadataProject = Path.Combine(metadata, "Microsoft.Mcp.Core.csproj");
            File.WriteAllText(metadataProject, File.ReadAllText(metadataProject).Replace("</Project>",
                $"""<ItemGroup><PackageReference Include="{sdkPackage}" Version="{sdkVersion}" /></ItemGroup></Project>""", StringComparison.Ordinal));
        }
        File.WriteAllText(Path.Combine(metadata, "Types.cs"), arm
            ? McpCoreTypes[..McpCoreTypes.IndexOf("namespace Microsoft.Extensions.Logging", StringComparison.Ordinal)]
                + ArmCoreTypes
            : McpCoreTypes);
        var built = await Run("dotnet", metadata, "build", "--output", output, "--nologo", "--verbosity", "quiet");
        Assert.That(built.ExitCode, Is.Zero, built.Output);
        File.WriteAllText(Path.Combine(source, name + ".csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <OutputType>Library</OutputType><TargetFramework>net10.0</TargetFramework>
                <Nullable>enable</Nullable><ImplicitUsings>enable</ImplicitUsings><TreatWarningsAsErrors>true</TreatWarningsAsErrors>
              </PropertyGroup>
              <ItemGroup><Reference Include="Microsoft.Mcp.Core" HintPath="bin/Debug/net10.0/Microsoft.Mcp.Core.dll" /></ItemGroup>
            </Project>
            """);
        if (arm)
        {
            var project = Path.Combine(source, name + ".csproj");
            File.WriteAllText(project, File.ReadAllText(project).Replace("</Project>",
                $"""<PropertyGroup><IsAotCompatible>true</IsAotCompatible></PropertyGroup><ItemGroup><PackageReference Include="{sdkPackage}" Version="{sdkVersion}" /></ItemGroup></Project>""", StringComparison.Ordinal));
            var consumerBuild = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(consumerBuild.ExitCode, Is.Zero, consumerBuild.Output);
        }
        return source;
    }

    private static void EnableExecutable(string source)
    {
        var project = Directory.GetFiles(source, "*.csproj").Single();
        File.WriteAllText(project, File.ReadAllText(project).Replace("<OutputType>Library", "<OutputType>Exe", StringComparison.Ordinal));
    }

    private static void WriteConfiguration(string directory, string output, string packageName, bool import)
    {
        File.WriteAllText(Path.Combine(directory, "tspconfig.yaml"), JsonSerializer.Serialize(new
        {
            imports = import ? new[] { Path.Combine(FindPackage(), "lib", "main.tsp") } : [],
            emit = new[] { "@azure-typespec/mcp-tools" },
            options = new Dictionary<string, object>
            {
                ["@azure-typespec/mcp-tools"] = new Dictionary<string, object>
                {
                    ["emitter-output-dir"] = output, ["package-name"] = packageName, ["new-project"] = false,
                    ["license"] = new { name = "MIT License", company = "Microsoft Corporation" }
                }
            }
        }));
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
        Assert.That(Directory.GetFiles(expected, "*.cs").Select(Path.GetFileName),
            Is.EquivalentTo(files.Select(Path.GetFileName)), "Run npm run generate:storage to update the generated inventory.");
        foreach (var file in files)
        {
            Assert.That(File.ReadAllBytes(file), Is.EqualTo(File.ReadAllBytes(Path.Combine(expected, Path.GetFileName(file)))),
                $"{Path.GetFileName(file)} differs. Run npm run generate:storage.");
        }
    }

    private const string StoragePartial = """
        namespace Storage.Blob;
        public partial class ContainerCreateService
        {
            public ContainerCreateRequest? LastRequest;
            public CancellationToken Token;
            public Exception? Failure;
            public int Calls;
            public partial Task<ContainerCreateResponse> CreateContainerAsync(ContainerCreateRequest request,CancellationToken cancellationToken)
            {
                Calls++;
                LastRequest=request;
                Token=cancellationToken;
                return Failure is null
                    ? Task.FromResult(new ContainerCreateResponse { Status=201, Headers=new() { ["etag"]="tag" } })
                    : Task.FromException<ContainerCreateResponse>(Failure);
            }
        }
        """;

    private const string StorageProgram = """
        using Storage.Blob;
        using Microsoft.Extensions.Logging;
        using Microsoft.Mcp.Core.Commands;
        using Microsoft.Mcp.Core.Models.Command;
        using System.Text.Json;
        var service=new ContainerCreateService();
        var logger=new Logger();
        var command=new ContainerCreateCommand(logger,service);
        using var cancellation=new CancellationTokenSource();
        var options=new ContainerCreateOptions {
            Request="{\"url\":\"https://account.blob.core.windows.net/container\",\"metadata\":{\"owner\":\"secret\"},\"access\":\"container\",\"timeout\":15}"
        };
        var context=new CommandContext();
        var response=await command.ExecuteAsync(context,options,cancellation.Token);
        Require(ReferenceEquals(context.Response,response),"Return actual context response.");
        Require(service.LastRequest!.Url.AbsoluteUri=="https://account.blob.core.windows.net/container" &&
            service.LastRequest.Metadata!["owner"]=="secret" && service.LastRequest.Timeout==15 &&
            service.LastRequest.Access=="container" && service.LastRequest.Version=="2026-12-06" &&
            service.Token==cancellation.Token,"REST fields, defaults, metadata and cancellation must be forwarded.");
        Require(response.Results?.Json=="{\"container\":{\"status\":201,\"headers\":{\"etag\":\"tag\"}}}","Preserve no-body status/headers.");
        var result=JsonSerializer.Deserialize(response.Results!.Json,ContainerCreateJsonContext.Default.ContainerCreateCommandResult)!;
        result.Deconstruct(out var rawResponse);
        Require(rawResponse.Status==201 && (result with { Container=new ContainerCreateResponse { Status=202 } }).Container.Status==202,
            "Preserve positional record, init/deconstruction, and JSON roundtrip.");
        Require(command.ResultTypeInfo is null,"Do not infer a new outputSchema.");
        var calls=service.Calls;
        foreach(var invalid in new[] { "null","{}","{\"url\":null}","{\"url\":\"https://example.com\",\"unknown\":1}","{invalid" })
        {
            response=await command.ExecuteAsync(new(),new ContainerCreateOptions { Request=invalid },cancellation.Token);
            Require(response.Status==400 && service.Calls==calls,"Invalid JSON must fail before invoking the partial service.");
        }
        service.Failure=new JsonException("Internal service failure.");
        response=await command.ExecuteAsync(new(),options,cancellation.Token);
        Require(response.Status==500 && response.Error=="Internal service failure.","Service JSON failures are not input validation failures.");
        service.Failure=new Azure.RequestFailedException(429,"throttled");
        response=await command.ExecuteAsync(new(),options,cancellation.Token);
        Require(response.Status==429 && logger.Errors==7,"Use established exception handling and safe logging.");
        Console.WriteLine("Generated Storage service contract executed.");
        static void Require(bool condition,string message) { if(!condition) throw new Exception(message); }
        sealed class Logger : ILogger<ContainerCreateCommand>
        {
            public int Errors;
            public void Error(Exception exception,string message)
            {
                Errors++;
                if(message.Contains("secret")) throw new Exception("Do not log request values.");
            }
        }
        """;

    private const string McpCoreTypes = """
        namespace Microsoft.Mcp.Core.Commands
        {
            public class CommandGroup { public void AddCommand<T>(IServiceProvider services) {} }
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
            public class CommandValidationException(string message) : Exception(message);
            public abstract class AuthenticatedCommand<TOptions,TResult> where TOptions : class
            {
                public virtual System.Text.Json.Serialization.Metadata.JsonTypeInfo<TResult>? ResultTypeInfo => null;
                public abstract Task<Models.Command.CommandResponse> ExecuteAsync(
                    Models.Command.CommandContext context,TOptions options,CancellationToken cancellationToken);
                protected virtual string GetErrorMessage(Exception exception) => exception.Message;
                protected void HandleException(Models.Command.CommandContext context,Exception exception)
                {
                    context.Response.Error=GetErrorMessage(exception);
                    context.Response.Status=exception is CommandValidationException ? 400 :
                        exception is Azure.RequestFailedException request ? request.Status : 500;
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
            public class CommandContext { public CommandResponse Response { get; }=new(); }
            public class CommandResponse
            {
                public ResponseResult? Results { get; set; }
                public string? Error { get; set; }
                public int Status { get; set; }=200;
            }
            public class ResponseResult
            {
                public required string Json { get; init; }
                public static ResponseResult Create<T>(T value,System.Text.Json.Serialization.Metadata.JsonTypeInfo<T> info) =>
                    new() { Json=System.Text.Json.JsonSerializer.Serialize(value,info) };
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
            public class RequestFailedException(int status,string message) : Exception(message) { public int Status=>status; }
        }
        """;

    private const string ArmCoreTypes = """
        namespace Azure.Mcp.Core.Options { public interface ISubscriptionOption { string? Subscription {get;set;} } }
        namespace Azure.Mcp.Core.Services.Azure.Subscription { public interface ISubscriptionResolver { string? ResolveSubscription(string? subscription); } }
        namespace Azure.Mcp.Core.Commands.Subscription
        {
            public abstract class SubscriptionCommand<TOptions,TResult> : Microsoft.Mcp.Core.Commands.AuthenticatedCommand<TOptions,TResult>
                where TOptions : class, global::Azure.Mcp.Core.Options.ISubscriptionOption
            {
                protected SubscriptionCommand(global::Azure.Mcp.Core.Services.Azure.Subscription.ISubscriptionResolver resolver) {}
            }
        }
        """;
}
