// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Type is for evaluation purposes only

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Optimization;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Configuration.Tests;

[TestFixture]
public class AgentConfigurationProviderTests
{
    private const string DefaultSection = "AgentOptimization";
    private readonly Dictionary<string, string?> _savedEnvVars = new();

    private static readonly string[] s_envVars =
    {
        "OPTIMIZATION_CONFIG",
        "OPTIMIZATION_CANDIDATE_ID",
    };

    [SetUp]
    public void SetUp()
    {
        foreach (string variable in s_envVars)
        {
            _savedEnvVars[variable] = Environment.GetEnvironmentVariable(variable);
            Environment.SetEnvironmentVariable(variable, null);
        }
    }

    [TearDown]
    public void TearDown()
    {
        foreach (KeyValuePair<string, string?> pair in _savedEnvVars)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }
    }

    [Test]
    public void DefaultAgentKey_FlattensIntoAgentOptimizationSection()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7,\"skills\":[{\"name\":\"greet\",\"description\":\"Say hi\"}]}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(DefaultSection)
            .Build();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.EqualTo("Be helpful."));
        Assert.That(config[$"{DefaultSection}:Model"], Is.EqualTo("gpt-4o"));
        Assert.That(config[$"{DefaultSection}:Temperature"], Is.EqualTo("0.7"));
        Assert.That(config[$"{DefaultSection}:Skills:0:Name"], Is.EqualTo("greet"));
        Assert.That(config[$"{DefaultSection}:Skills:0:Description"], Is.EqualTo("Say hi"));
    }

    [Test]
    public void DefaultAgentKey_GetOptimizationConfig_ReturnsResolvedConfig()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7,\"skills\":[{\"name\":\"greet\",\"description\":\"Say hi\"},{\"name\":\"bye\",\"description\":\"Say bye\"}]}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(DefaultSection)
            .Build();

        CandidateDeployConfig? options = config.GetOptimizationConfig();

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(options.Model, Is.EqualTo("gpt-4o"));
        Assert.That(options.Temperature, Is.EqualTo(0.7f));
        Assert.That(options.Skills.Count, Is.EqualTo(2));
        Assert.That(options.Skills[0].Name, Is.EqualTo("greet"));
        Assert.That(options.Skills[1].Name, Is.EqualTo("bye"));
    }

    [Test]
    public void MultiAgent_TwoAgents_FlattenIntoSeparateSections()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Shared instructions\",\"model\":\"gpt-4o\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource("triage-agent", "OptimizationSettings")
            .AddOptimizationConfigSource("booking-agent", "OptimizationSettings")
            .Build();

        Assert.That(config["triage-agent:Instructions"], Is.EqualTo("Shared instructions"));
        Assert.That(config["triage-agent:Model"], Is.EqualTo("gpt-4o"));
        Assert.That(config["booking-agent:Instructions"], Is.EqualTo("Shared instructions"));
        Assert.That(config["booking-agent:Model"], Is.EqualTo("gpt-4o"));
    }

    [Test]
    public void MultiAgent_GetOptimizationConfig_ReadsCorrectSection()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Shared instructions\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource("triage-agent", "OptimizationSettings")
            .AddOptimizationConfigSource("booking-agent", "OptimizationSettings")
            .Build();

        Assert.That(config.GetOptimizationConfig("triage-agent")?.Instructions, Is.EqualTo("Shared instructions"));
        Assert.That(config.GetOptimizationConfig("booking-agent")?.Instructions, Is.EqualTo("Shared instructions"));
    }

    [Test]
    public void MultiAgent_KeyCasingPreservedInSection_ButCaseInsensitiveLookup()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"You triage.\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource("Triage-Agent", "OptimizationSettings")
            .Build();

        Assert.That(config["Triage-Agent:Instructions"], Is.EqualTo("You triage."));
        Assert.That(config["triage-agent:instructions"], Is.EqualTo("You triage."));
    }

    [Test]
    public void ProjectionSection_CanDifferFromSettingsSection()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"hi\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["OptimizationSettings:Endpoint"] = "https://example.org"
            })
            .AddOptimizationConfigSource("travel-agent", "OptimizationSettings")
            .Build();

        Assert.That(config["travel-agent:Instructions"], Is.EqualTo("hi"));
        Assert.That(config["OptimizationSettings:Instructions"], Is.Null);
    }

    [Test]
    public void Empty_NoEnvVars_ProducesEmptyTree()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(DefaultSection)
            .Build();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.Null);
        Assert.That(config.GetOptimizationConfig(), Is.Null);
    }

    [Test]
    public void StackedProvider_OptimizationSource_OverridesEarlierInMemoryValues()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"from optimization\"}");

        var initial = new Dictionary<string, string?>
        {
            [$"{DefaultSection}:Instructions"] = "from appsettings",
            [$"{DefaultSection}:Model"] = "from appsettings",
        };

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(initial)
            .AddOptimizationConfigSource(DefaultSection)
            .Build();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.EqualTo("from optimization"));
        Assert.That(config[$"{DefaultSection}:Model"], Is.EqualTo("from appsettings"));
    }

    [Test]
    public void StackedProvider_LaterInMemoryOverridesOptimization()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"from optimization\"}");

        var overrides = new Dictionary<string, string?>
        {
            [$"{DefaultSection}:Instructions"] = "from override",
        };

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(DefaultSection)
            .AddInMemoryCollection(overrides)
            .Build();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.EqualTo("from override"));
    }

    [Test]
    public void Reload_SuccessThenEmpty_ClearsData()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"first\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(DefaultSection)
            .Build();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.EqualTo("first"));

        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", null);
        config.Reload();

        Assert.That(config[$"{DefaultSection}:Instructions"], Is.Null);
    }

    [Test]
    public void Provider_SectionName_ReturnsAgentKey()
    {
        var provider = new AgentConfigurationProvider("triage-agent", new AgentOptimizationClientSettings());

        Assert.That(provider.SectionName, Is.EqualTo("triage-agent"));
    }

    [Test]
    public void GetOptimizationConfig_NoMatchingSection_ReturnsNull()
    {
        IConfigurationRoot config = new ConfigurationBuilder().Build();

        Assert.That(config.GetOptimizationConfig(), Is.Null);
    }

    [Test]
    public void GetOptimizationConfig_NullConfiguration_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => ((IConfiguration)null!).GetOptimizationConfig());
        Assert.Throws<ArgumentNullException>(() => ((IConfiguration)null!).GetOptimizationConfig("triage-agent"));
    }

    [Test]
    public void GetOptimizationConfig_EmptyAgentKey_Throws()
    {
        IConfigurationRoot config = new ConfigurationBuilder().Build();

        Assert.Throws<ArgumentException>(() => config.GetOptimizationConfig(string.Empty));
    }

    [Test]
    public void AddOptimizationConfigSource_NullBuilder_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IConfigurationBuilder)null!).AddOptimizationConfigSource(DefaultSection));
    }

    [Test]
    public void AddOptimizationConfigSource_NullConfigure_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource(DefaultSection, (Action<AgentOptimizationClientSettings>)null!));
    }

    [Test]
    public void AddOptimizationConfigSource_EmptySectionName_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource(string.Empty));
    }

    [Test]
    public void AddOptimizationConfigSource_EmptyAgentKey_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource(string.Empty, "OptimizationSettings"));
    }

    [Test]
    public void AddOptimizationConfigSource_InvalidAgentKeyChars_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource("triage agent!", "OptimizationSettings"));
    }
}
