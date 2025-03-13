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

    public DirectoryInfo RepositoryRoot { get; } = FindFirstParentWithSubfolders(".git")
        ?? throw new InvalidOperationException("Could not find your Git repository root folder");

    public DirectoryInfo SourceRoot { get; } = FindFirstParentWithSubfolders("eng", "sdk")
        ?? throw new InvalidOperationException("Could not find your source root folder");

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
                SourceRoot.FullName,
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

    private static DirectoryInfo? FindFirstParentWithSubfolders(params string[] subFolders)
    {
        if (subFolders == null || subFolders.Length == 0)
        {
            return null;
        }

        DirectoryInfo? start = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        for (DirectoryInfo? current = start; current != null; current = current.Parent)
        {
            if (!current.Exists)
            {
                return null;
            }
            else if (subFolders.All(sub => current.EnumerateDirectories(sub).Any()))
            {
                return current;
            }
        }

        return null;
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
