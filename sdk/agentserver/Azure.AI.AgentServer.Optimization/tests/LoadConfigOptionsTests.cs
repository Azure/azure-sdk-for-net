// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class LoadConfigOptionsTests
{
    private readonly Dictionary<string, string?> _savedEnvVars = new();

    private static readonly string[] s_envVars =
    {
        "OPTIMIZATION_CONFIG",
        "OPTIMIZATION_CANDIDATE_ID",
        "OPTIMIZATION_RESOLVE_ENDPOINT",
        "OPTIMIZATION_LOCAL_DIR",
        // Suffixed per-agent variants used by these tests
        "OPTIMIZATION_CONFIG__TRIAGE_AGENT",
        "OPTIMIZATION_CANDIDATE_ID__TRIAGE_AGENT",
        "OPTIMIZATION_RESOLVE_ENDPOINT__TRIAGE_AGENT",
        "OPTIMIZATION_LOCAL_DIR__TRIAGE_AGENT",
        "OPTIMIZATION_CONFIG__BOOKING_AGENT",
        "OPTIMIZATION_CANDIDATE_ID__BOOKING_AGENT",
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

    // ─────────────────────────────────────────────────────────────────
    // LoadConfigResult basics
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task LoadConfigAsync_WithOptions_ReturnsEmpty_WhenNoSourceAvailable()
    {
        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions());

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Config, Is.Null);
        Assert.That(result.SourceUsed, Is.Null);
        Assert.That(result.Warnings, Is.Empty);
    }

    [Test]
    public void LoadConfig_WithOptions_NullOptions_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => OptimizationConfigLoader.LoadConfig((LoadConfigOptions)null!));
    }

    [Test]
    public async Task LoadConfigAsync_WithOptions_NullOptions_Throws()
    {
        Assert.ThrowsAsync<ArgumentNullException>(
            async () => await OptimizationConfigLoader.LoadConfigAsync((LoadConfigOptions)null!));
        await Task.CompletedTask;
    }

    [Test]
    public async Task LoadConfigAsync_WithOptions_PopulatesSourceUsed_ForInlineJson()
    {
        string json = "{\"instructions\":\"hi\"}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions());

        Assert.That(result.Config, Is.Not.Null);
        Assert.That(result.SourceUsed, Is.EqualTo("env:OPTIMIZATION_CONFIG"));
    }

    [Test]
    public async Task LoadConfigAsync_WithOptions_PopulatesSourceUsed_ForLocalCandidateDir()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), $"opt-test-{Guid.NewGuid():N}");
        string candidateDir = Path.Combine(tempDir, "cand_001");
        Directory.CreateDirectory(candidateDir);
        try
        {
            File.WriteAllText(Path.Combine(candidateDir, "instructions.md"), "from local candidate dir");
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", tempDir);

            var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions());

            Assert.That(result.Config, Is.Not.Null);
            Assert.That(result.Config!.Instructions, Is.EqualTo("from local candidate dir"));
            Assert.That(result.Config.CandidateId, Is.EqualTo("cand_001"));
            Assert.That(result.SourceUsed, Does.StartWith("local:"));
            Assert.That(result.SourceUsed, Does.Contain("cand_001"));
        }
        finally
        {
            Directory.Delete(tempDir, recursive: true);
        }
    }

    // ─────────────────────────────────────────────────────────────────
    // Per-agent env var resolution (canonical key suffix)
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task PerAgent_SuffixedEnvVar_TakesPrecedenceOverUnsuffixed()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"global\"}");
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__TRIAGE_AGENT", "{\"instructions\":\"triage-specific\"}");

        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "triage-agent" });

        Assert.That(result.Config, Is.Not.Null);
        Assert.That(result.Config!.Instructions, Is.EqualTo("triage-specific"));
    }

    [Test]
    public async Task PerAgent_NoSuffixed_NoFallback_ByDefault_ReturnsEmpty()
    {
        // Only the unsuffixed global is set. Default behavior for a per-agent
        // load is to NOT fall back to unsuffixed (FallbackToUnsuffixedEnvVars=false).
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"global\"}");

        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "triage-agent" });

        Assert.That(result.Config, Is.Null);
    }

    [Test]
    public async Task PerAgent_NoSuffixed_WithFallback_UsesUnsuffixed()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"global\"}");

        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions
        {
            AgentKey = "triage-agent",
            FallbackToUnsuffixedEnvVars = true,
        });

        Assert.That(result.Config, Is.Not.Null);
        Assert.That(result.Config!.Instructions, Is.EqualTo("global"));
    }

    [Test]
    public async Task PerAgent_TwoAgents_AreIsolated()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__TRIAGE_AGENT", "{\"instructions\":\"triage\"}");
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__BOOKING_AGENT", "{\"instructions\":\"booking\"}");

        var triage = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "triage-agent" });
        var booking = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "booking-agent" });

        Assert.That(triage.Config!.Instructions, Is.EqualTo("triage"));
        Assert.That(booking.Config!.Instructions, Is.EqualTo("booking"));
    }

    [Test]
    public async Task PerAgent_KeyWithUnderscore_CanonicalizesSameAsHyphen()
    {
        // Both "triage-agent" and "triage_agent" canonicalize to "TRIAGE_AGENT" → same env var.
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__TRIAGE_AGENT", "{\"instructions\":\"shared\"}");

        var withHyphen = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "triage-agent" });
        var withUnderscore = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { AgentKey = "triage_agent" });

        Assert.That(withHyphen.Config!.Instructions, Is.EqualTo("shared"));
        Assert.That(withUnderscore.Config!.Instructions, Is.EqualTo("shared"));
    }

    [Test]
    public async Task PerAgent_KeyWithInvalidChars_Throws()
    {
        // AgentKey containing spaces or punctuation is rejected.
        await Task.CompletedTask;
        Assert.Throws<ArgumentException>(
            () => OptimizationConfigLoader.LoadConfig(new LoadConfigOptions { AgentKey = "triage agent!" }));
    }

    // ─────────────────────────────────────────────────────────────────
    // Path traversal validation (Priority 3 — local candidate dir)
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task LocalCandidateDir_InvalidCandidateId_NonStrict_FallsThrough_WithWarning()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), $"opt-test-{Guid.NewGuid():N}");
        string baselineDir = Path.Combine(tempDir, "baseline");
        Directory.CreateDirectory(baselineDir);
        try
        {
            File.WriteAllText(Path.Combine(baselineDir, "instructions.md"), "from baseline");
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "../escape");
            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", tempDir);

            var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions());

            Assert.That(result.Config, Is.Not.Null);
            Assert.That(result.Config!.Instructions, Is.EqualTo("from baseline"));
            Assert.That(result.Warnings, Has.Count.GreaterThan(0));
            Assert.That(result.Warnings[0], Does.Contain("invalid"));
        }
        finally
        {
            Directory.Delete(tempDir, recursive: true);
        }
    }

    [Test]
    public async Task LocalCandidateDir_InvalidCandidateId_StrictMode_Throws()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), $"opt-test-{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempDir);
        try
        {
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "../escape");
            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", tempDir);

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions { StrictMode = true }));
        }
        finally
        {
            Directory.Delete(tempDir, recursive: true);
        }
        await Task.CompletedTask;
    }

    // ─────────────────────────────────────────────────────────────────
    // Strict-mode resolver behavior
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task ResolverFailure_NonStrict_FallsThrough_WithWarning()
    {
        // Set both env vars so Priority 1 (resolver) is selected, then point
        // to a definitely-unreachable endpoint. With non-strict mode the loader
        // should warn and fall through; with no other source we land on null.
        Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
        Environment.SetEnvironmentVariable("OPTIMIZATION_RESOLVE_ENDPOINT", "http://127.0.0.1:1/never-listens");

        var result = await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions
        {
            ResolverTimeout = TimeSpan.FromMilliseconds(500),
        });

        Assert.That(result.Config, Is.Null);
        Assert.That(result.Warnings, Has.Count.GreaterThan(0));
    }

    [Test]
    public async Task ResolverFailure_StrictMode_Rethrows()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
        Environment.SetEnvironmentVariable("OPTIMIZATION_RESOLVE_ENDPOINT", "http://127.0.0.1:1/never-listens");

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await OptimizationConfigLoader.LoadConfigAsync(new LoadConfigOptions
            {
                StrictMode = true,
                ResolverTimeout = TimeSpan.FromMilliseconds(500),
            }));
        await Task.CompletedTask;
    }
}
