// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Completeness meta-test (T059 + T080) for the resilience contract coverage matrix.
/// <para>
/// It PARSES <c>CONTRACT_COVERAGE.md</c> — the row×path map of every normative clause of
/// <c>docs/resilience-contract.md</c> to its .NET conformance test — and enforces the coverage-map
/// discipline mirrored from the reference <c>test_contract_completeness</c> harness:
/// </para>
/// <list type="bullet">
/// <item>T059: every clause row is <c>covered</c> — no remaining <c>pending:&lt;task&gt;</c> cell
/// (unless explicitly whitelisted here with a documented reason).</item>
/// <item>T080: every <c>covered</c> row declares a non-empty assertion-depth (the <c>Dimension</c>
/// column) and names a concrete test.</item>
/// </list>
/// This is a HARD gate: it must stay green, and it fails loudly if a future edit reintroduces a
/// pending cell or drops the depth declaration.
/// </summary>
public class ContractCoverageCompletenessTests
{
    /// <summary>
    /// Rows whose <c>Status</c> may legitimately remain <c>pending:&lt;task&gt;</c>. Empty by design:
    /// the reconciliation for User Story 8 verified that every referenced conformance test exists and
    /// passes, so there is no genuinely-pending cell. If a cell is ever intentionally deferred, add
    /// its clause-anchor substring here WITH a documented reason — never lower the gate silently.
    /// </summary>
    private static readonly IReadOnlyList<string> PendingWhitelist = Array.Empty<string>();

    private static string CoverageMapPath([CallerFilePath] string thisFile = "")
        => Path.Combine(Path.GetDirectoryName(thisFile)!, "CONTRACT_COVERAGE.md");

    private sealed record CoverageRow(string Clause, string Test, string Dimension, string Status);

    /// <summary>
    /// Parses the coverage matrix. Recognizes GitHub-flavoured Markdown table rows (lines that start
    /// and end with <c>|</c>) with the four <c>Clause | Test | Dimension | Status</c> columns; skips
    /// the header row, the <c>|---|</c> separator, and any prose. Robust to surrounding whitespace and
    /// to the leading/trailing pipe being present or absent.
    /// </summary>
    private static IReadOnlyList<CoverageRow> ParseCoverageRows()
    {
        var path = CoverageMapPath();
        Assert.That(File.Exists(path), $"CONTRACT_COVERAGE.md not found at '{path}'.");

        var rows = new List<CoverageRow>();
        foreach (var raw in File.ReadAllLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0 || !line.StartsWith("|", StringComparison.Ordinal))
            {
                continue;
            }

            var cells = SplitRow(line);
            if (cells.Count < 4)
            {
                continue;
            }

            // Separator row: cells are all dashes/colons.
            if (cells.All(c => c.Length > 0 && c.All(ch => ch == '-' || ch == ':')))
            {
                continue;
            }

            // Header row.
            if (string.Equals(cells[0], "Clause", StringComparison.OrdinalIgnoreCase)
                && string.Equals(cells[3], "Status", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // A data row must have a status that is either 'covered' or 'pending:...'.
            var status = cells[3];
            if (!IsCovered(status) && !IsPending(status))
            {
                continue;
            }

            rows.Add(new CoverageRow(cells[0], cells[1], cells[2], status));
        }

        return rows;
    }

    private static List<string> SplitRow(string line)
    {
        // Strip the leading and trailing pipe, then split on '|'.
        var trimmed = line;
        if (trimmed.StartsWith("|", StringComparison.Ordinal))
        {
            trimmed = trimmed[1..];
        }

        if (trimmed.EndsWith("|", StringComparison.Ordinal))
        {
            trimmed = trimmed[..^1];
        }

        return trimmed.Split('|').Select(c => c.Trim()).ToList();
    }

    private static bool IsCovered(string status)
        => string.Equals(status, "covered", StringComparison.OrdinalIgnoreCase);

    private static bool IsPending(string status)
        => status.StartsWith("pending:", StringComparison.OrdinalIgnoreCase)
           || string.Equals(status, "pending", StringComparison.OrdinalIgnoreCase);

    private static bool IsWhitelisted(CoverageRow row)
        => PendingWhitelist.Any(fragment =>
            row.Clause.Contains(fragment, StringComparison.OrdinalIgnoreCase));

    [Test]
    public void CoverageMatrix_HasParseableRows()
    {
        var rows = ParseCoverageRows();
        Assert.That(rows, Is.Not.Empty,
            "The coverage matrix parsed to zero rows — the table format changed and the parser can no "
            + "longer read it. Fix the parser or the table so the completeness gate stays meaningful.");
    }

    // ---- T059: row×path completeness — no uncovered cell ----

    [Test]
    public void EveryClauseRow_IsCovered_NoRemainingPendingCell()
    {
        var offenders = ParseCoverageRows()
            .Where(r => IsPending(r.Status) && !IsWhitelisted(r))
            .Select(r => $"'{r.Clause}' → {r.Status} (test: {r.Test})")
            .ToList();

        Assert.That(offenders, Is.Empty,
            "Every resilience-contract clause must map to a covered conformance test. These row×path "
            + "cells are still pending and are not whitelisted:\n  " + string.Join("\n  ", offenders)
            + "\n\nEither implement the test and flip the cell to 'covered', or (only if genuinely "
            + "deferred) add its clause anchor to PendingWhitelist with a documented reason.");
    }

    // ---- T080: per-cell assertion-depth is declared for every covered cell ----

    [Test]
    public void EveryCoveredRow_DeclaresNonEmptyAssertionDepth()
    {
        var offenders = ParseCoverageRows()
            .Where(r => IsCovered(r.Status))
            .Where(r => string.IsNullOrWhiteSpace(r.Dimension))
            .Select(r => $"'{r.Clause}' (test: {r.Test})")
            .ToList();

        Assert.That(offenders, Is.Empty,
            "Every covered cell MUST declare its per-cell assertion depth in the Dimension column "
            + "(status/error, event sequence/content, response.output correctness, etc. — see "
            + "docs/resilience-contract.md §\"Per-cell assertion depth\"). These covered rows declare "
            + "no depth:\n  " + string.Join("\n  ", offenders));
    }

    [Test]
    public void EveryCoveredRow_DeclaresDepthFromKnownVocabulary()
    {
        // The depth tokens that docs/resilience-contract.md defines. A covered row must declare at
        // least one recognized depth so the depth column stays a meaningful, enforced contract rather
        // than free text.
        var knownDepths = new[]
        {
            "response.status", "response.error", "response.output content", "event sequence",
            "seq monotonicity", "event content", "metadata", "chain id", "payload schema",
            "dispatch", "recovery drop", "composition guard", "meta",
        };

        var offenders = new List<string>();
        foreach (var row in ParseCoverageRows().Where(r => IsCovered(r.Status)))
        {
            var declared = row.Dimension
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var hasKnown = declared.Any(d =>
                knownDepths.Any(k => string.Equals(k, d, StringComparison.OrdinalIgnoreCase)));
            if (!hasKnown)
            {
                offenders.Add($"'{row.Clause}' → depth '{row.Dimension}'");
            }
        }

        Assert.That(offenders, Is.Empty,
            "Every covered cell's Dimension must include at least one recognized assertion-depth token "
            + "(see docs/resilience-contract.md §\"Per-cell assertion depth\"). Unrecognized depths:\n  "
            + string.Join("\n  ", offenders));
    }

    // ---- T080: covered cells must name a concrete backing test ----

    [Test]
    public void EveryCoveredRow_NamesABackingTest()
    {
        var offenders = ParseCoverageRows()
            .Where(r => IsCovered(r.Status))
            .Where(r => string.IsNullOrWhiteSpace(r.Test)
                        || r.Test.Contains("TODO", StringComparison.OrdinalIgnoreCase))
            .Select(r => $"'{r.Clause}'")
            .ToList();

        Assert.That(offenders, Is.Empty,
            "Every covered cell must name a concrete backing test (a real passing test must back the "
            + "'covered' status). These covered rows name none:\n  " + string.Join("\n  ", offenders));
    }
}
