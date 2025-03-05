﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using Azure.Projects.AppService;
using Azure.Projects.KeyVault;
using Azure.Projects.OpenAI;
using NUnit.Framework;

[assembly: NonParallelizable]

namespace Azure.Projects.Tests;

public class BicepGenerationTests
{
    [Test]
    public void MinimalProject()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
        string expectedBicep = LoadTestFile("minimal.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void AppConfiguration()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddFeature(new AppConfigurationFeature());
        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
        File.WriteAllText("d:\\appConfig.bicep", actualBicep);
        string expectedBicep = LoadTestFile("appConfig.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void OfxProject()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddOfx();
        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
        string expectedBicep = LoadTestFile("ofx.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void AIFoundry()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddFeature(new AIFoundry.AIProjectFeature());
        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
        string expectedBicep = LoadTestFile("Foundry.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void OpenAI()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        infra.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));

        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
        string expectedBicep = LoadTestFile("OpenAI.bicep");
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Test]
    public void AppService()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddFeature(new KeyVaultFeature());
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        infra.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));
        infra.AddFeature(new AppServiceFeature());

        string actualBicep = infra.Build().Compile().FirstOrDefault().Value;
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
