// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tools for deterministic protection of Generated/ directories.
///
/// Workflow:
///   1. After code regeneration, call <c>snapshot_generated</c> to record file hashes.
///   2. After the build-fix cycle, call <c>verify_generated_unchanged</c> to detect violations.
///   3. <see cref="BuildAndClassifyTool"/> also auto-verifies when a snapshot exists.
///
/// Snapshots are stored in-process (static) so they persist across MCP tool calls
/// within the same server session. Memory is bounded: one snapshot per project path,
/// storing only relative paths and 32-byte SHA-256 hashes.
/// </summary>
[McpServerToolType]
public static class GeneratedSnapshotTool
{
    // Keyed by normalized project path → snapshot of Generated/ files.
    // ConcurrentDictionary for thread safety if tools are called in parallel.
    private static readonly ConcurrentDictionary<string, GeneratedSnapshot> s_snapshots = new(StringComparer.OrdinalIgnoreCase);

    [McpServerTool(Name = "snapshot_generated"), Description(
        "Take a SHA-256 snapshot of all files in the Generated/ directory. " +
        "Call this AFTER code regeneration and BEFORE the build-fix cycle. " +
        "The snapshot is stored in-process and used by verify_generated_unchanged and build_and_classify.")]
    public static string TakeSnapshot(
        [Description("Absolute path to the SDK project directory (e.g., sdk/compute/Azure.ResourceManager.Compute)")] string projectPath)
    {
        try
        {
            var result = TakeSnapshotInProcess(projectPath);
            return JsonSerializer.Serialize(result);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    [McpServerTool(Name = "verify_generated_unchanged"), Description(
        "Verify that no files in Generated/ were modified since the last snapshot. " +
        "Call this AFTER the build-fix cycle. Reports violations and optionally reverts them via git checkout.")]
    public static string Verify(
        [Description("Absolute path to the SDK project directory")] string projectPath,
        [Description("Set to 'true' to auto-revert modified Generated/ files via git checkout")] string? autoRevert = null)
    {
        try
        {
            var revert = string.Equals(autoRevert, "true", StringComparison.OrdinalIgnoreCase);
            var result = VerifyInProcess(projectPath, revert);
            return JsonSerializer.Serialize(result);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// Takes a snapshot of all Generated/ files. Called by the MCP tool and by other tools in-process.
    /// </summary>
    internal static SnapshotResult TakeSnapshotInProcess(string projectPath)
    {
        var normalizedProject = Path.GetFullPath(projectPath);
        var generatedDir = FindGeneratedDirectory(normalizedProject);

        if (generatedDir is null || !Directory.Exists(generatedDir))
        {
            return new SnapshotResult(true, 0, "No Generated/ directory found — nothing to snapshot.");
        }

        var hashes = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

        foreach (var file in Directory.EnumerateFiles(generatedDir, "*", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(normalizedProject, file);
            hashes[relativePath] = HashFile(file);
        }

        var snapshot = new GeneratedSnapshot(generatedDir, hashes);
        s_snapshots[normalizedProject] = snapshot;

        return new SnapshotResult(true, hashes.Count, null);
    }

    /// <summary>
    /// Verifies Generated/ files against the stored snapshot. Returns violation details.
    /// </summary>
    internal static VerifyResult VerifyInProcess(string projectPath, bool autoRevert)
    {
        var normalizedProject = Path.GetFullPath(projectPath);

        if (!s_snapshots.TryGetValue(normalizedProject, out var snapshot))
        {
            return new VerifyResult(true, false, [], "No snapshot found — call snapshot_generated first.");
        }

        var generatedDir = snapshot.GeneratedDirectory;
        var violations = new List<Violation>();

        // Check for modified or deleted files
        foreach (var (relativePath, originalHash) in snapshot.FileHashes)
        {
            var fullPath = Path.Combine(normalizedProject, relativePath);

            if (!File.Exists(fullPath))
            {
                violations.Add(new Violation(relativePath, ViolationType.Deleted));
                continue;
            }

            var currentHash = HashFile(fullPath);
            if (!currentHash.AsSpan().SequenceEqual(originalHash))
            {
                violations.Add(new Violation(relativePath, ViolationType.Modified));
            }
        }

        // Check for newly added files in Generated/
        if (Directory.Exists(generatedDir))
        {
            foreach (var file in Directory.EnumerateFiles(generatedDir, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(normalizedProject, file);
                if (!snapshot.FileHashes.ContainsKey(relativePath))
                {
                    violations.Add(new Violation(relativePath, ViolationType.Added));
                }
            }
        }

        // Auto-revert modified/deleted files via git checkout
        var reverted = 0;
        if (autoRevert && violations.Count > 0)
        {
            reverted = RevertViolations(normalizedProject, violations);
        }

        return new VerifyResult(
            true,
            violations.Count > 0,
            violations,
            violations.Count == 0
                ? "All Generated/ files are unchanged."
                : $"{violations.Count} violation(s) detected.{(reverted > 0 ? $" {reverted} file(s) reverted." : "")}");
    }

    /// <summary>
    /// Returns whether a snapshot exists for the given project path.
    /// Used by <see cref="BuildAndClassifyTool"/> to decide if auto-verification should run.
    /// </summary>
    internal static bool HasSnapshot(string projectPath)
    {
        return s_snapshots.ContainsKey(Path.GetFullPath(projectPath));
    }

    /// <summary>
    /// Removes the snapshot for a project. Useful for cleanup after migration completes.
    /// </summary>
    internal static void ClearSnapshot(string projectPath)
    {
        s_snapshots.TryRemove(Path.GetFullPath(projectPath), out _);
    }

    private static byte[] HashFile(string filePath)
    {
        using var stream = File.OpenRead(filePath);
        return SHA256.HashData(stream);
    }

    private static int RevertViolations(string projectRoot, List<Violation> violations)
    {
        var reverted = 0;
        var filesToRevert = violations
            .Where(v => v.Type is ViolationType.Modified or ViolationType.Deleted)
            .Select(v => v.RelativePath)
            .ToList();

        if (filesToRevert.Count == 0)
        {
            return 0;
        }

        // Revert via git checkout in a single call for efficiency
        var pathArgs = string.Join(' ', filesToRevert.Select(p => $"\"{p.Replace('\\', '/')}\""));
        try
        {
            var task = ProcessRunner.RunAsync("git", $"checkout -- {pathArgs}", projectRoot);
            task.Wait(TimeSpan.FromSeconds(30));
            if (task.IsCompletedSuccessfully && task.Result.ExitCode == 0)
            {
                reverted = filesToRevert.Count;
            }
        }
        catch
        {
            // Revert is best-effort — violations are still reported even if git checkout fails
        }

        // Remove newly added files that shouldn't exist
        foreach (var v in violations.Where(v => v.Type == ViolationType.Added))
        {
            var fullPath = Path.Combine(projectRoot, v.RelativePath);
            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    reverted++;
                }
            }
            catch
            {
                // Best-effort cleanup
            }
        }

        return reverted;
    }

    private static string? FindGeneratedDirectory(string projectPath)
    {
        var dir = File.Exists(projectPath) ? (Path.GetDirectoryName(projectPath) ?? projectPath) : projectPath;

        var candidate = Path.Combine(dir, "src", "Generated");
        if (Directory.Exists(candidate))
        {
            return candidate;
        }

        candidate = Path.Combine(dir, "Generated");
        if (Directory.Exists(candidate))
        {
            return candidate;
        }

        return null;
    }

    // ── Snapshot data structures ──────────────────────────────────────────

    /// <summary>
    /// Immutable snapshot of Generated/ file hashes for a single project.
    /// </summary>
    private sealed class GeneratedSnapshot
    {
        public string GeneratedDirectory { get; }
        public IReadOnlyDictionary<string, byte[]> FileHashes { get; }

        public GeneratedSnapshot(string generatedDirectory, Dictionary<string, byte[]> fileHashes)
        {
            GeneratedDirectory = generatedDirectory;
            FileHashes = fileHashes;
        }
    }

    // ── Result types (serialized to JSON for the MCP response) ───────────

    internal readonly record struct SnapshotResult(bool Success, int FileCount, string? Message);

    internal readonly record struct VerifyResult(bool Success, bool HasViolations, List<Violation> Violations, string? Message);

    internal readonly record struct Violation(string RelativePath, ViolationType Type);

    internal enum ViolationType
    {
        Modified,
        Deleted,
        Added
    }
}
