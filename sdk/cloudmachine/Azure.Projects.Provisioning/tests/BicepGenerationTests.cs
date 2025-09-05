// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using Azure.Projects.Ofx;
using NUnit.Framework;
using Azure.Projects.Core;
using Azure.Provisioning.CognitiveServices;

[assembly: NonParallelizable]

namespace Azure.Projects.Tests;

public class BicepGenerationTests
{
    [Test]
    public void MinimalProject()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "minimal.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("minimal.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void MinimalProjectWithDeveloperAppConfig()
    {
        #region Snippet:StoreAppConfigurationSku
        AppConfigConnectionStore connections = new(AppConfigurationFeature.SkuName.Developer);
        ProjectInfrastructure infrastructure = new(connections);
        #endregion

        infrastructure = new(connections, "cm0c420d2f21084cd"); // we don't want cmid in the snippet
        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "developer.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("developer.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void KeyVault()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new KeyVaultFeature());

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "kv.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("kv.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void Blobs()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("testcontainer", isObservable: false));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "blobs.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("blobs.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void BlobsTwoContainers()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("container1", isObservable: false));
        infrastructure.AddFeature(new BlobContainerFeature("container2", isObservable: false));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "blobs2Containers.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("blobs2Containers.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void BlobsObservableContainer()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new BlobContainerFeature("default", isObservable: true));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "blobsObservable.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("blobsObservable.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void OpenAI()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "openai.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("openai.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void MaaS()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new AIModelsFeature("DeepSeek-V3", "1"));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        string path = Path.Combine(Path.GetTempPath(), "maas.bicep");
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(path, actualBicep);

        string expectedBicep = LoadTestFile("maas.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void ServiceBus()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new ServiceBusNamespaceFeature(infrastructure.ProjectId));

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "sb.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("sb.bicep");
        AssertEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void Ofx()
    {
        ProjectInfrastructure infrastructure = new("cm0c420d2f21084cd");
        infrastructure.AddFeature(new OfxFeatures());

        string actualBicep = infrastructure.Build().Compile().FirstOrDefault().Value;
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "cm.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("cm.bicep");
        AssertEqual(expectedBicep, actualBicep);
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
        // Un-comment to debug bicep creation issues
        //File.WriteAllText(Path.Combine(Path.GetTempPath(), "app.bicep"), actualBicep);

        string expectedBicep = LoadTestFile("app.bicep");
        AssertEqual(expectedBicep, actualBicep);
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

    private static void AssertEqual(string expectedBicep, string actualBicep)
    {
        Assert.AreEqual(expectedBicep, actualBicep.Replace("\r\n", "\n"));
    }
}
