// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using Azure.Projects.AppService;
using Azure.Projects.KeyVault;
using Azure.Projects.OpenAI;
using Azure.Projects.Storage;
using NUnit.Framework;

[assembly: NonParallelizable]

namespace Azure.Projects.Tests;

public class BicepGenerationTests
{
    [Test]
    public void MinimalProject()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\minimal.bicep", actualBicep);

        string expectedBicep = LoadTestFile("minimal.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void KeyVault()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new KeyVaultFeature());
        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\kv.bicep", actualBicep);
        string expectedBicep = LoadTestFile("kv.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void Blobs()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("testcontainer", isObservable: false));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\blobs.bicep", actualBicep);
        string expectedBicep = LoadTestFile("blobs.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void TwoContainers()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("container1", isObservable: false));
        infrastructure.AddFeature(new BlobContainerFeature("container2", isObservable: false));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\twoContainers.bicep", actualBicep);
        string expectedBicep = LoadTestFile("twoContainers.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void ObservableContainer()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("default", isObservable: true));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\ofx.bicep", actualBicep);
        string expectedBicep = LoadTestFile("ofx.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void AIFoundry()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new AIFoundry.AIProjectFeature());
        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\Foundry.bicep", actualBicep);

        string expectedBicep = LoadTestFile("Foundry.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void OpenAI()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\OpenAI.bicep", actualBicep);

        string expectedBicep = LoadTestFile("OpenAI.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void AppService()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new KeyVaultFeature());
        infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
        infrastructure.AddFeature(new AppServiceFeature());

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\app.bicep", actualBicep);
        string expectedBicep = LoadTestFile("app.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    private static string LoadTestFile(string filename)
    {
        string contents = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", filename));
        contents = contents.Replace("\r\n", Environment.NewLine);
        while (contents.EndsWith(Environment.NewLine))  {
            contents = contents.Substring(0, contents.Length - Environment.NewLine.Length);
        }
        return contents;
    }
}
