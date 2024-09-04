// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Reflection;
using NUnit.Framework;
using OpenAI.TestFramework.Mocks;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Tests;

public class MockStringServiceTests : RecordedClientTestBase
{
    private const string c_basePath = "data";

    public MockStringServiceTests(bool isAsync)
        : base(isAsync, null)
    {
        RecordingOptions.SanitizersToRemove.Add("AZSDK3430");  // $..id
    }

    public DirectoryInfo RepositoryRoot { get; } = FindRepoRoot();

    [Test]
    public async Task AddAndGet()
    {
        const string id = "first.one";
        const string expected = "The first value goes here";

        using MockRestService<string> service = new(c_basePath);
        var options = ConfigureClientOptions(new ClientPipelineOptions());
        using var client = WrapClient(new MockRestServiceClient<string>(service.HttpEndpoint, options));

        ClientResult add = await client.AddAsync(id, expected, Token);
        Assert.That(add, Is.Not.Null);
        Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));

        string? retrieved = await client.GetAsync("first.one", Token);
        Assert.That(retrieved, Is.EqualTo(expected));
    }

    [Test]
    public async Task AddAndDelete()
    {
        const string id = "first.one";
        const string expected = "The first value goes here";

        using MockRestService<string> service = new(c_basePath);
        var options = ConfigureClientOptions(new ClientPipelineOptions());
        using var client = WrapClient(new MockRestServiceClient<string>(service.HttpEndpoint, options));

        ClientResult add = await client.AddAsync(id, expected, Token);
        Assert.That(add, Is.Not.Null);
        Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));

        bool deleted = await client.RemoveAsync(id, Token);
        Assert.That(deleted, Is.True);

        string? retrieved = await client.GetAsync("first.one", Token);
        Assert.That(retrieved, Is.Null);
    }

    #region overrides

    protected override ProxyServiceOptions CreateProxyServiceOptions()
        => new()
        {
            DotnetExecutable = AssemblyHelper.GetDotnetExecutable()?.FullName!,
            TestProxyDll = AssemblyHelper.GetAssemblyMetadata<ProxyService>("TestProxyPath")!,
            DevCertFile = Path.Combine(
                RepositoryRoot.FullName,
                "eng",
                "common",
                "testproxy",
                "dotnet-devcert.pfx"),
            DevCertPassword = "password",
            StorageLocationDir = RepositoryRoot.FullName,
        };

    protected override RecordingStartInformation CreateRecordingSessionStartInfo()
        => new()
        {
            RecordingFile = GetRecordingFile(),
            AssetsFile = GetAssetsFile()
        };

    #endregion

    #region helper methods

    private static DirectoryInfo FindRepoRoot()
    {
        /**
         * This code assumes that we are running in the standard Azure .Net SDK repository layout. With this in mind, 
         * we generally assume that we are running our test code from
         * <root>/artifacts/bin/<NameOfProject>/<Configuration>/<TargetFramework>
         * So to find the root we keep navigating up until we find a folder with a .git subfolder
         * 
         * Another alternative would be to call: git rev-parse --show-toplevel
         */

        DirectoryInfo? current = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        while (current != null && !current.EnumerateDirectories(".git").Any())
        {
            current = current.Parent;
        }

        return current
            ?? throw new InvalidOperationException("Could not determine the root folder for this repository");
    }

    private string GetRecordingFile()
    {
        DirectoryInfo sourceDir = AssemblyHelper.GetAssemblySourceDir<MockStringServiceTests>()
            ?? throw new InvalidOperationException("Could not determine the source path for this assembly");
        string relativeDir = PathHelpers.GetRelativePath(RepositoryRoot.FullName, sourceDir.FullName);
        return Path.Combine(
            relativeDir,
            "SessionRecords",
            GetType().Name,
            GetRecordedTestFileName());
    }

    private string? GetAssetsFile()
    {
        DirectoryInfo? sourceDir = AssemblyHelper.GetAssemblySourceDir<MockStringServiceTests>()
            ?? throw new InvalidOperationException("Could not determine the source path for this assembly");

        // walk up the tree until we hit either the repository root, or found a folder with an "assets.json" file
        for (; sourceDir != null && sourceDir?.FullName != RepositoryRoot.FullName; sourceDir = sourceDir.Parent)
        {
            string assetsFile = Path.Combine(sourceDir!.FullName, "assets.json");
            if (File.Exists(assetsFile))
            {
                return assetsFile;
            }
        }

        return null;
    }

    #endregion
}
