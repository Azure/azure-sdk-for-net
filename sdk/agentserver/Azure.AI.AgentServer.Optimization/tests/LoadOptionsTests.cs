// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

[TestFixture]
public class LoadOptionsTests
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
    // Load shape basics
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task LoadAsync_WithOptions_ReturnsNull_WhenNoSourceAvailable()
    {
        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions());

        Assert.That(options, Is.Null);
    }

    [Test]
    public async Task LoadAsync_NullLoadOptions_UsesDefaults()
    {
        // Passing null is equivalent to `new LoadOptions()` — should not throw.
        var options = await OptimizationOptionsLoader.LoadAsync(options: null);

        Assert.That(options, Is.Null);
    }

    [Test]
    public async Task LoadAsync_WithOptions_PopulatesSource_ForInlineJson()
    {
        string json = "{\"instructions\":\"hi\"}";
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", json);

        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions());

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Source, Is.EqualTo("env:OPTIMIZATION_CONFIG"));
    }

    [Test]
    public async Task LoadAsync_WithOptions_PopulatesSource_ForLocalCandidateDir()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), $"opt-test-{Guid.NewGuid():N}");
        string candidateDir = Path.Combine(tempDir, "cand_001");
        Directory.CreateDirectory(candidateDir);
        try
        {
            File.WriteAllText(Path.Combine(candidateDir, "instructions.md"), "from local candidate dir");
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", tempDir);

            var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions());

            Assert.That(options, Is.Not.Null);
            Assert.That(options!.Instructions, Is.EqualTo("from local candidate dir"));
            Assert.That(options.CandidateId, Is.EqualTo("cand_001"));
            Assert.That(options.Source, Does.StartWith("local:"));
            Assert.That(options.Source, Does.Contain("cand_001"));
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

        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "triage-agent" });

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Instructions, Is.EqualTo("triage-specific"));
    }

    [Test]
    public async Task PerAgent_NoSuffixed_NoFallback_ByDefault_ReturnsNull()
    {
        // Only the unsuffixed global is set. Default behavior for a per-agent
        // load is to NOT fall back to unsuffixed (FallbackToUnsuffixedEnvVars=false).
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"global\"}");

        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "triage-agent" });

        Assert.That(options, Is.Null);
    }

    [Test]
    public async Task PerAgent_NoSuffixed_WithFallback_UsesUnsuffixed()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG", "{\"instructions\":\"global\"}");

        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions
        {
            AgentKey = "triage-agent",
            FallbackToUnsuffixedEnvVars = true,
        });

        Assert.That(options, Is.Not.Null);
        Assert.That(options!.Instructions, Is.EqualTo("global"));
    }

    [Test]
    public async Task PerAgent_TwoAgents_AreIsolated()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__TRIAGE_AGENT", "{\"instructions\":\"triage\"}");
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__BOOKING_AGENT", "{\"instructions\":\"booking\"}");

        var triage = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "triage-agent" });
        var booking = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "booking-agent" });

        Assert.That(triage!.Instructions, Is.EqualTo("triage"));
        Assert.That(booking!.Instructions, Is.EqualTo("booking"));
    }

    [Test]
    public async Task PerAgent_KeyWithUnderscore_CanonicalizesSameAsHyphen()
    {
        // Both "triage-agent" and "triage_agent" canonicalize to "TRIAGE_AGENT" → same env var.
        Environment.SetEnvironmentVariable("OPTIMIZATION_CONFIG__TRIAGE_AGENT", "{\"instructions\":\"shared\"}");

        var withHyphen = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "triage-agent" });
        var withUnderscore = await OptimizationOptionsLoader.LoadAsync(new LoadOptions { AgentKey = "triage_agent" });

        Assert.That(withHyphen!.Instructions, Is.EqualTo("shared"));
        Assert.That(withUnderscore!.Instructions, Is.EqualTo("shared"));
    }

    [Test]
    public async Task PerAgent_KeyWithInvalidChars_Throws()
    {
        // AgentKey containing spaces or punctuation is rejected.
        await Task.CompletedTask;
        Assert.Throws<ArgumentException>(
            () => OptimizationOptionsLoader.Load(new LoadOptions { AgentKey = "triage agent!" }));
    }

    // ─────────────────────────────────────────────────────────────────
    // Path traversal validation (Priority 3 — local candidate dir)
    // ─────────────────────────────────────────────────────────────────

    [Test]
    public async Task LocalCandidateDir_InvalidCandidateId_NonStrict_FallsThroughToBaseline()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), $"opt-test-{Guid.NewGuid():N}");
        string baselineDir = Path.Combine(tempDir, "baseline");
        Directory.CreateDirectory(baselineDir);
        try
        {
            File.WriteAllText(Path.Combine(baselineDir, "instructions.md"), "from baseline");
            Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "../escape");
            Environment.SetEnvironmentVariable("OPTIMIZATION_LOCAL_DIR", tempDir);

            var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions());

            Assert.That(options, Is.Not.Null);
            Assert.That(options!.Instructions, Is.EqualTo("from baseline"));
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
                async () => await OptimizationOptionsLoader.LoadAsync(new LoadOptions { StrictMode = true }));
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
    public async Task ResolverFailure_NonStrict_FallsThroughToNull()
    {
        // Set all env vars so Priority 1 (resolver) is selected, then point
        // to a definitely-unreachable endpoint. With non-strict mode the loader
        // should fall through; with no other source we land on null.
        Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
        Environment.SetEnvironmentVariable("OPTIMIZATION_RESOLVE_ENDPOINT", "http://127.0.0.1:1/never-listens");

        var options = await OptimizationOptionsLoader.LoadAsync(new LoadOptions
        {
            ResolverTimeout = TimeSpan.FromMilliseconds(500),
        });

        Assert.That(options, Is.Null);
    }

    [Test]
    public async Task ResolverFailure_StrictMode_Rethrows()
    {
        Environment.SetEnvironmentVariable("OPTIMIZATION_CANDIDATE_ID", "cand_001");
        Environment.SetEnvironmentVariable("OPTIMIZATION_RESOLVE_ENDPOINT", "http://127.0.0.1:1/never-listens");

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await OptimizationOptionsLoader.LoadAsync(new LoadOptions
            {
                StrictMode = true,
                ResolverTimeout = TimeSpan.FromMilliseconds(500),
            }));
        await Task.CompletedTask;
    }
}
