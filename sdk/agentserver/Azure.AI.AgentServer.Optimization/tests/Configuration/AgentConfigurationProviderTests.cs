// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Optimization;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Configuration.Tests;

[TestFixture]
public class AgentConfigurationProviderTests
{
    private readonly Dictionary<string, string?> _savedEnvVars = new();

    private static readonly string[] s_envVars =
    {
        "OPTIMIZATION_CONFIG",
        "OPTIMIZATION_CANDIDATE_ID",
    };

    [SetUp]
    public void SetUp()
    {
        foreach (var v in s_envVars)
        {
            _savedEnvVars[v] = Environment.GetEnvironmentVariable(v);
            Environment.SetEnvironmentVariable(v, null);
        }
    }

    [TearDown]
    public void TearDown()
    {
        foreach (KeyValuePair<string, string?> kv in _savedEnvVars)
        {
            Environment.SetEnvironmentVariable(kv.Key, kv.Value);
        }
    }

    [Test]
    public void SingleAgent_FlattensIntoAgentSection()
    {
        string json = "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7," +
                      "\"skills\":[{\"name\":\"greet\",\"description\":\"Say hi\"}]}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var builder = new ConfigurationBuilder();
        builder.AddOptimizationConfigSource();
        IConfigurationRoot config = builder.Build();

        Assert.That(config["Agent:Instructions"], Is.EqualTo("Be helpful."));
        Assert.That(config["Agent:Model"], Is.EqualTo("gpt-4o"));
        Assert.That(config["Agent:Temperature"], Is.EqualTo("0.7"));
        Assert.That(config["Agent:Skills:0:Name"], Is.EqualTo("greet"));
        Assert.That(config["Agent:Skills:0:Description"], Is.EqualTo("Say hi"));
    }

    [Test]
    public void SingleAgent_GetOptimizationConfig_ReturnsResolvedConfig()
    {
        string json = "{\"instructions\":\"Be helpful.\",\"model\":\"gpt-4o\",\"temperature\":0.7," +
                      "\"skills\":[{\"name\":\"greet\",\"description\":\"Say hi\"}," +
                                  "{\"name\":\"bye\",\"description\":\"Say bye\"}]}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource()
            .Build();

        CandidateDeployConfig? opts = config.GetOptimizationConfig();

        Assert.That(opts, Is.Not.Null);
        Assert.That(opts!.Instructions, Is.EqualTo("Be helpful."));
        Assert.That(opts.Model, Is.EqualTo("gpt-4o"));
        Assert.That(opts.Temperature, Is.EqualTo(0.7f));
        Assert.That(opts.Skills.Count, Is.EqualTo(2));
        Assert.That(opts.Skills[0].Name, Is.EqualTo("greet"));
        Assert.That(opts.Skills[1].Name, Is.EqualTo("bye"));
    }

    [Test]
    public void MultiAgent_TwoAgents_FlattenIntoSeparateSections()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Shared instructions\",\"model\":\"gpt-4o\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource("triage-agent")
            .AddOptimizationConfigSource("booking-agent")
            .Build();

        Assert.That(config["Agents:triage-agent:Instructions"], Is.EqualTo("Shared instructions"));
        Assert.That(config["Agents:triage-agent:Model"], Is.EqualTo("gpt-4o"));
        Assert.That(config["Agents:booking-agent:Instructions"], Is.EqualTo("Shared instructions"));
        Assert.That(config["Agents:booking-agent:Model"], Is.EqualTo("gpt-4o"));
    }

    [Test]
    public void MultiAgent_GetOptimizationConfig_ReadsCorrectSection()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG",
            "{\"instructions\":\"Shared instructions\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource("triage-agent")
            .AddOptimizationConfigSource("booking-agent")
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
            .AddOptimizationConfigSource("Triage-Agent")
            .Build();

        // Visual section path uses the raw key as supplied.
        Assert.That(config["Agents:Triage-Agent:Instructions"], Is.EqualTo("You triage."));
        // M.E.Configuration is case-insensitive: lowercased form resolves too.
        Assert.That(config["agents:triage-agent:instructions"], Is.EqualTo("You triage."));
    }

    [Test]
    public void Empty_NoEnvVars_FailOnEmptyFalse_ProducesEmptyTree()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource()
            .Build();

        Assert.That(config["Agent:Instructions"], Is.Null);
        CandidateDeployConfig? opts = config.GetOptimizationConfig();
        Assert.That(opts, Is.Null);
    }

    [Test]
    public void Empty_NoEnvVars_FailOnEmptyTrue_Throws()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            new ConfigurationBuilder()
                .AddOptimizationConfigSource(o => o.FailOnEmpty = true)
                .Build();
        });

        Assert.That(ex!.Message, Does.Contain("could not resolve"));
    }

    [Test]
    public void Empty_NoEnvVars_FailOnEmptyTrue_MultiAgent_IncludesAgentKeyInError()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            new ConfigurationBuilder()
                .AddOptimizationConfigSource("triage-agent", o => o.FailOnEmpty = true)
                .Build();
        });

        Assert.That(ex!.Message, Does.Contain("triage-agent"));
    }

    [Test]
    public void CustomSectionName_OverridesDefault()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"hi\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(o => o.SectionName = "MyAgent:Instance1")
            .Build();

        Assert.That(config["MyAgent:Instance1:Instructions"], Is.EqualTo("hi"));
        Assert.That(config["Agent:Instructions"], Is.Null);
    }

    [Test]
    public void SectionName_LeadingColon_Throws()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"hi\"}");

        Assert.Throws<ArgumentException>(() =>
        {
            new ConfigurationBuilder()
                .AddOptimizationConfigSource(o => o.SectionName = ":bad")
                .Build();
        });
    }

    [Test]
    public void StackedProvider_OptimizationSource_OverridesEarlierInMemoryValues()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"from optimization\"}");

        var initial = new Dictionary<string, string?>
        {
            ["Agent:Instructions"] = "from appsettings",
            ["Agent:Model"] = "from appsettings",
        };

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddInMemoryCollection(initial)
            .AddOptimizationConfigSource()
            .Build();

        Assert.That(config["Agent:Instructions"], Is.EqualTo("from optimization"));
        // Model wasn't set by optimization, so the earlier provider's value remains visible.
        Assert.That(config["Agent:Model"], Is.EqualTo("from appsettings"));
    }

    [Test]
    public void StackedProvider_LaterInMemoryOverridesOptimization()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"from optimization\"}");

        var overrides = new Dictionary<string, string?>
        {
            ["Agent:Instructions"] = "from override",
        };

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource()
            .AddInMemoryCollection(overrides)
            .Build();

        Assert.That(config["Agent:Instructions"], Is.EqualTo("from override"));
    }

    [Test]
    public void Reload_SuccessThenEmpty_ClearsData()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"first\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource()
            .Build();

        Assert.That(config["Agent:Instructions"], Is.EqualTo("first"));

        // Clear the source and reload — provider should drop the value rather than
        // keep the stale "first".
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", null);
        config.Reload();

        Assert.That(config["Agent:Instructions"], Is.Null);
    }

    [Test]
    public void Reload_FailOnEmpty_AfterPreviouslySuccessfulLoad_Throws()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"first\"}");

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddOptimizationConfigSource(o => o.FailOnEmpty = true)
            .Build();

        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", null);

        Assert.Throws<InvalidOperationException>(() => config.Reload());
    }

    [Test]
    public void GetOptimizationConfig_NoMatchingSection_ReturnsNull()
    {
        IConfigurationRoot config = new ConfigurationBuilder().Build();

        CandidateDeployConfig? opts = config.GetOptimizationConfig();

        Assert.That(opts, Is.Null);
    }

    [Test]
    public void GetOptimizationConfig_NullConfiguration_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IConfiguration)null!).GetOptimizationConfig());
        Assert.Throws<ArgumentNullException>(() =>
            ((IConfiguration)null!).GetOptimizationConfig("triage-agent"));
    }

    [Test]
    public void GetOptimizationConfig_EmptyAgentKey_Throws()
    {
        IConfigurationRoot config = new ConfigurationBuilder().Build();
        Assert.Throws<ArgumentException>(() => config.GetOptimizationConfig(""));
    }

    [Test]
    public void AddOptimizationConfigSource_NullBuilder_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IConfigurationBuilder)null!).AddOptimizationConfigSource());
    }

    [Test]
    public void AddOptimizationConfigSource_NullConfigure_Throws()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource((Action<AgentConfigurationOptions>)null!));
    }

    [Test]
    public void AddOptimizationConfigSource_EmptyAgentKey_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            new ConfigurationBuilder().AddOptimizationConfigSource(""));
    }

    [Test]
    public void AddOptimizationConfigSource_InvalidAgentKeyChars_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new ConfigurationBuilder()
                .AddOptimizationConfigSource("triage agent!")
                .Build();
        });
    }
}
