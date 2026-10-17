// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Mcp.Tests.GenerationTests;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ArmGenerationTests
{
    [Test]
    public async Task StockProvidersBindThreeReadsToShippedSdk()
    {
        var package = FindPackage();
        var root = Path.Combine(package, "temp", "arm-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            StorageGenerationTests.IsolateBuild(root);
            var source = await StorageGenerationTests.CreateConsumer(root, "Example", arm: true,
                sdkPackage: "Azure.ResourceManager.AppNetwork", sdkVersion: "1.0.0-beta.2");
            File.Copy(Path.Combine(package, "generator", "TestProjects", "Local", "AppNetwork", "tsp-location.yaml"),
                Path.Combine(root, "tsp-location.yaml"));
            var cli = Path.GetFullPath(Path.Combine(package, "..", "..", "common", "tsp-client", "node_modules",
                "@azure-tools", "typespec-client-generator-cli", "dist", "index.js"));
            var synced = await Run("node", root, cli, "sync", "--output-dir", root);
            Assert.That(synced.ExitCode, Is.Zero, synced.Output);
            foreach (var name in new[] { "package.json", "package-lock.json" })
            {
                File.Delete(Path.Combine(root, "TempTypeSpecFiles", name));
            }
            var staged = Path.Combine(root, "TempTypeSpecFiles", "AppLink.Management");
            File.Copy(Path.Combine(package, "emitter", "test", "fixtures", "appnetwork.tsp"), Path.Combine(staged, "appnetwork.tsp"));
            File.Move(Path.Combine(staged, "tspconfig.yaml"), Path.Combine(staged, "tspconfig.upstream.yaml"));
            File.WriteAllText(Path.Combine(staged, "tspconfig.yaml"), JsonSerializer.Serialize(new
            {
                extends = "./tspconfig.upstream.yaml",
                imports = new[] { Path.Combine(package, "lib", "main.tsp") },
                emit = new[] { "@azure-typespec/mcp-tools" },
                options = new Dictionary<string, object>
                {
                    ["@azure-typespec/mcp-tools"] = new Dictionary<string, object>
                    {
                        ["emitter-output-dir"] = root, ["package-name"] = "Example", ["namespace"] = "Azure.ResourceManager.AppNetwork",
                        ["new-project"] = false, ["management-plane"] = true
                    }
                }
            }));
            var generated = await Run("node", root, cli, "generate", "--output-dir", root, "--skip-install", "--save-inputs", "--debug");
            Assert.That(generated.ExitCode, Is.Zero, generated.Output);
            var output = Path.Combine(source, "Generated");
            Assert.That(Directory.GetFiles(output, "*.cs"), Has.Length.EqualTo(19));
            Assert.That(Directory.GetFiles(output, "*.cs").Select(Path.GetFileName),
                Has.None.Contains("RestClient").And.None.Contains("AppLinkResource"));
            File.WriteAllText(Path.Combine(source, "Program.cs"), Program
                .Replace("\"sub\"", "\"11111111-1111-1111-1111-111111111111\"", StringComparison.Ordinal)
                .Replace("/subscriptions/sub/", "/subscriptions/11111111-1111-1111-1111-111111111111/", StringComparison.Ordinal));
            var project = Directory.GetFiles(source, "*.csproj").Single();
            File.WriteAllText(project, File.ReadAllText(project).Replace("<OutputType>Library", "<OutputType>Exe", StringComparison.Ordinal));
            var built = await Run("dotnet", source, "build", "--nologo", "--verbosity", "quiet");
            Assert.That(built.ExitCode, Is.Zero, built.Output);
            var executed = await Run("dotnet", source, "run", "--no-build");
            Assert.That(executed.ExitCode, Is.Zero, executed.Output);
            Assert.That(executed.Output, Does.Contain("Real ARM SDK reads and bounded pages executed."));
            VerifyCheckedInOutput(package, output);
            var before = Directory.GetFiles(output, "*.cs").ToDictionary(path => Path.GetFileName(path)!, File.ReadAllBytes);
            var repeated = await Run("node", root, cli, "generate", "--output-dir", root, "--skip-install", "--save-inputs", "--debug");
            Assert.That(repeated.ExitCode, Is.Zero, repeated.Output);
            foreach (var file in Directory.GetFiles(output, "*.cs"))
            {
                Assert.That(File.ReadAllBytes(file), Is.EqualTo(before[Path.GetFileName(file)]));
            }
            var client = Path.Combine(staged, "client.tsp");
            File.AppendAllText(client, "\n@@clientName(Microsoft.AppLink.AppLink, \"MissingSdkResource\", \"csharp\");\n");
            var mismatch = await Run("node", root, cli, "generate", "--output-dir", root, "--skip-install", "--save-inputs", "--debug");
            Assert.That(mismatch.ExitCode, Is.Not.Zero);
            Assert.That(mismatch.Output, Does.Contain("SDK binding mismatch").And.Contain("Expected stock").And.Contain("Referenced candidates"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static void VerifyCheckedInOutput(string package, string output)
    {
        var expected = Path.Combine(package, "generator", "TestProjects", "Local", "AppNetwork", "src", "Generated");
        var files = Directory.GetFiles(output, "*.cs");
        if (Environment.GetEnvironmentVariable("AZURE_MCP_UPDATE_GENERATED") == "1")
        {
            Directory.CreateDirectory(expected);
            foreach (var file in files)
            {
                File.Copy(file, Path.Combine(expected, Path.GetFileName(file)), overwrite: true);
            }
        }
        Assert.That(Directory.Exists(expected), Is.True, "Run npm run generate:arm to create checked-in generated output.");
        Assert.That(Directory.GetFiles(expected, "*.cs").Select(Path.GetFileName),
            Is.EquivalentTo(files.Select(Path.GetFileName)));
        foreach (var file in files)
        {
            Assert.That(File.ReadAllBytes(file), Is.EqualTo(File.ReadAllBytes(Path.Combine(expected, Path.GetFileName(file)))));
        }
    }

        private const string Program = """
            using System.Net;
            using System.Text;
            using Azure.Core;
            using Azure.Core.Pipeline;
            using Azure.ResourceManager;
            using Azure.ResourceManager.Resources;
            using Microsoft.AppLink;

            var transport=new Handler();
            var shipped=System.Reflection.CustomAttributeExtensions.GetCustomAttribute<System.Reflection.AssemblyInformationalVersionAttribute>(
                typeof(Azure.ResourceManager.AppNetwork.AppLinkResource).Assembly)!.InformationalVersion;
            if(!shipped.StartsWith("1.0.0-beta.2")) throw new Exception("Actual shipped AppNetwork assembly required.");
            var client=new ArmClient(new Credential(),"sub",new ArmClientOptions { Transport=new HttpClientTransport(new HttpClient(transport)) });
            var endpoint=ArmEnvironment.AzurePublicCloud.Endpoint;
            Func<string,string?,CancellationToken,Task<SubscriptionResource>> hook=(sub,tenant,ct) => {
                ct.ThrowIfCancellationRequested();
                if((sub!="sub" && sub!="friendly") || tenant!="tenant") throw new Exception("Subscription/tenant not forwarded.");
                return Task.FromResult(client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(sub=="friendly" ? "sub" : sub)));
            };
            var get=await AppLinksGetSdkAdapter.ExecuteAsync(
                new AppLinksGetOptions { Subscription="friendly",Tenant="tenant",ResourceGroup="rg",AppLink="bridge" },hook,endpoint,CancellationToken.None);
            if(get.Data.GetProperty("name").GetString()!="bridge" || transport.Requests.Count!=1) throw new Exception("Real SDK Get/data projection failed.");
            var options=new AppLinksListByResourceGroupOptions { Subscription="sub",Tenant="tenant",ResourceGroup="rg" };
            var first=await AppLinksListByResourceGroupSdkAdapter.ExecuteAsync(options,hook,endpoint,CancellationToken.None);
            if(first.Items.Length!=1 || first.ContinuationToken is null || transport.Requests.Count!=2)
                throw new Exception($"Must return just one page: items={first.Items.Length}, token={first.ContinuationToken}, requests={string.Join(";",transport.Requests)}.");
            options.ContinuationToken=first.ContinuationToken;
            var second=await AppLinksListByResourceGroupSdkAdapter.ExecuteAsync(options,hook,endpoint,CancellationToken.None);
            if(second.Items.Length!=1 || second.ContinuationToken is not null || transport.Requests.Count!=3 ||
                !transport.Requests.Last().Query.Contains("skiptoken=next")) throw new Exception("SDK continuation not forwarded.");
            var subscription=await AppLinksListBySubscriptionSdkAdapter.ExecuteAsync(
                new AppLinksListBySubscriptionOptions { Subscription="sub",Tenant="tenant" },hook,endpoint,CancellationToken.None);
            if(subscription.Items.Length!=1 || transport.Requests.Count!=4) throw new Exception("Subscription list failed.");
            try {
                await AppLinksListBySubscriptionSdkAdapter.ExecuteAsync(
                    new AppLinksListBySubscriptionOptions { Subscription="sub",Tenant="tenant",ContinuationToken=first.ContinuationToken },hook,endpoint,CancellationToken.None);
                throw new Exception("Expected token scope rejection.");
            } catch(ArgumentException) {}
            if(transport.Requests.Count!=4) throw new Exception("Invalid token made a request.");
            try {
                await AppLinksGetSdkAdapter.ExecuteAsync(
                    new AppLinksGetOptions { Subscription="sub",Tenant="tenant",ResourceGroup="rg",AppLink="bad/name" },hook,endpoint,CancellationToken.None);
                throw new Exception("Expected service name constraint failure.");
            } catch(Microsoft.Mcp.Core.Commands.CommandValidationException) {}
            if(transport.Requests.Count!=4) throw new Exception("Invalid name made a request.");
            try {
                await AppLinksGetSdkAdapter.ExecuteAsync(
                    new AppLinksGetOptions { Subscription="sub",Tenant="tenant",ResourceGroup=new string('r',91),AppLink="bridge" },hook,endpoint,CancellationToken.None);
                throw new Exception("Expected resource group max-length failure.");
            } catch(Microsoft.Mcp.Core.Commands.CommandValidationException) {}
            if(transport.Requests.Count!=4) throw new Exception("Invalid resource group length made a request.");
            using var cancellation=new CancellationTokenSource();
            cancellation.Cancel();
            try {
                await AppLinksGetSdkAdapter.ExecuteAsync(new AppLinksGetOptions {Subscription="sub",Tenant="tenant",ResourceGroup="rg",AppLink="bridge"},hook,endpoint,cancellation.Token);
                throw new Exception("Expected cancellation.");
            } catch(OperationCanceledException) {}
            Console.WriteLine("Real ARM SDK reads and bounded pages executed.");

            sealed class Credential : TokenCredential
            {
                public override AccessToken GetToken(TokenRequestContext context,CancellationToken cancellationToken) => new("token",DateTimeOffset.UtcNow.AddHours(1));
                public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext context,CancellationToken cancellationToken) => ValueTask.FromResult(GetToken(context,cancellationToken));
            }
            sealed class Handler : HttpMessageHandler
            {
                public List<Uri> Requests {get;}=[];
                protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Requests.Add(request.RequestUri!);
                    const string resource="{\"id\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.AppLink/appLinks/bridge\",\"name\":\"bridge\",\"type\":\"Microsoft.AppLink/appLinks\",\"location\":\"eastus\",\"properties\":{\"provisioningState\":\"Succeeded\"}}";
                    var json=request.RequestUri!.AbsolutePath.EndsWith("/bridge") ? resource :
                        "{\"value\":["+resource+"]"+(Requests.Count==2 ? ",\"nextLink\":\"https://management.azure.com"+request.RequestUri.AbsolutePath+request.RequestUri.Query+"&skiptoken=next\"" : "")+"}";
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content=new StringContent(json,Encoding.UTF8,"application/json") });
                }
            }
            """;
}
