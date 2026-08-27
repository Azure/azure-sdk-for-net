using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

/// <summary>
/// Projects the canonical repository graph into the smaller index distributed to PR test jobs.
/// Exact graph inputs are intentionally absent from <see cref="SourceGraph"/> so the JSON reader
/// validates and materializes only the compact checkout roots computed during graph construction.
/// </summary>
public sealed class CreateSparseCheckoutGraphTask : Task
{
    private const int SourceSchemaVersion = 6;
    private static readonly string[] AlwaysIncludedPaths = ["/*", "!/*/", "/eng", "/.config"];
    private static readonly StringComparer KeyComparer = StringComparer.OrdinalIgnoreCase;
    private static readonly JsonSerializerOptions ReadOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };
    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
    };

    [Required]
    public string PackageInfoDirectory { get; set; } = string.Empty;

    [Required]
    public string RepoRoot { get; set; } = string.Empty;

    [Required]
    public string GraphPath { get; set; } = string.Empty;

    [Required]
    public string OutputPath { get; set; } = string.Empty;

    [Required]
    public string SourceCommit { get; set; } = string.Empty;

    public bool AllowDirtySource { get; set; }

    public override bool Execute()
    {
        try
        {
            CreateProjection();
            return true;
        }
        catch (Exception exception)
        {
            Log.LogErrorFromException(exception, true);
            return false;
        }
    }

    private void CreateProjection()
    {
        var total = Stopwatch.StartNew();
        string repositoryRoot = NormalizeDirectory(RepoRoot);
        string packageInfoRoot = NormalizeDirectory(PackageInfoDirectory);
        string graphFullPath = Path.GetFullPath(GraphPath);
        string outputFullPath = Path.GetFullPath(OutputPath);

        if (!Directory.Exists(repositoryRoot))
        {
            throw new DirectoryNotFoundException($"Repository root does not exist: '{repositoryRoot}'.");
        }
        if (!Directory.Exists(packageInfoRoot))
        {
            throw new DirectoryNotFoundException($"Package information directory does not exist: '{packageInfoRoot}'.");
        }
        if (!File.Exists(graphFullPath))
        {
            throw new FileNotFoundException("Repository project graph does not exist.", graphFullPath);
        }

        string[] packageInfoFiles = Directory.GetFiles(packageInfoRoot, "*.json", SearchOption.AllDirectories);
        Array.Sort(packageInfoFiles, StringComparer.Ordinal);
        if (packageInfoFiles.Length == 0)
        {
            throw new InvalidOperationException($"No package information files were found under '{packageInfoRoot}'.");
        }

        // System.Text.Json streams from the file and skips the large, unknown `inputs` property.
        var phase = Stopwatch.StartNew();
        SourceGraph graph;
        using (FileStream stream = File.OpenRead(graphFullPath))
        {
            graph = JsonSerializer.Deserialize<SourceGraph>(stream, ReadOptions)
                ?? throw new InvalidOperationException("Repository project graph is empty.");
        }
        double readSeconds = phase.Elapsed.TotalSeconds;
        ValidateSourceGraph(graph, graphFullPath);
        string actualCommit = ValidateProvenance(repositoryRoot, graph);

        // Build configuration and package indexes once; test jobs later traverse their batch only.
        phase.Restart();
        var projectPaths = NewSet();
        var configurationsByPackageRoot = NewTable();
        var configurationsByProjectPath = NewTable();
        var configurationsByRepositoryPackage = NewTable();
        var repositoryPackageKeys = new Dictionary<string, string>(KeyComparer);
        var allConfigurations = NewSet();

        foreach (SourceNode node in graph.Nodes)
        {
            string projectPath = NormalizeRelativePath(node.ProjectPath);
            if (string.IsNullOrEmpty(projectPath) || !projectPaths.Add(projectPath))
            {
                throw new InvalidOperationException(
                    $"Repository graph contains an empty or duplicate project path '{projectPath}'.");
            }

            string packageRoot = NormalizeRelativePath(node.PackageRoot);
            if (node.TargetFrameworks is null || node.TargetFrameworks.Length == 0)
            {
                throw new InvalidOperationException($"Project '{projectPath}' has no target-framework configurations.");
            }
            foreach (string targetFramework in node.TargetFrameworks)
            {
                string configuration = GetConfigurationKey(projectPath, targetFramework);
                if (!allConfigurations.Add(configuration))
                {
                    throw new InvalidOperationException($"Repository graph contains duplicate configuration '{configuration}'.");
                }
                AddTableValue(configurationsByProjectPath, projectPath, configuration);
                if (!string.IsNullOrEmpty(packageRoot))
                {
                    AddTableValue(configurationsByPackageRoot, packageRoot, configuration);
                }
            }

            if (node.IsShippingLibrary && !string.IsNullOrWhiteSpace(node.PackageId))
            {
                string package = GetPackageKey(node.PackageId);
                if (!repositoryPackageKeys.TryAdd(package, package))
                {
                    throw new InvalidOperationException(
                        $"Repository graph contains duplicate shipping package identity '{node.PackageId}'.");
                }
                foreach (string targetFramework in node.TargetFrameworks)
                {
                    AddTableValue(
                        configurationsByRepositoryPackage,
                        package,
                        GetConfigurationKey(projectPath, targetFramework));
                }
            }
        }

        // Schema 6 pre-groups file inputs into checkout roots. Require a complete one-to-one
        // configuration index before any result is allowed to narrow a checkout.
        var paths = NewTable();
        foreach ((string configuration, string[] checkoutRoots) in graph.CheckoutRoots)
        {
            if (!allConfigurations.Contains(configuration))
            {
                throw new InvalidOperationException($"Checkout roots reference unknown configuration '{configuration}'.");
            }
            if (checkoutRoots is null || checkoutRoots.Length == 0)
            {
                throw new InvalidOperationException($"Configuration '{configuration}' has no checkout roots.");
            }
            foreach (string checkoutRoot in checkoutRoots)
            {
                if (string.IsNullOrWhiteSpace(checkoutRoot) || !checkoutRoot.StartsWith('/'))
                {
                    throw new InvalidOperationException(
                        $"Configuration '{configuration}' contains invalid checkout root '{checkoutRoot}'.");
                }
                AddTableValue(paths, configuration, checkoutRoot);
            }
        }
        string missingCheckoutRoot = allConfigurations.FirstOrDefault(configuration => !paths.ContainsKey(configuration));
        if (missingCheckoutRoot is not null)
        {
            throw new InvalidOperationException($"Repository graph has no checkout roots for '{missingCheckoutRoot}'.");
        }

        var adjacency = NewTable();
        foreach (SourceEdge edge in graph.ConfigurationEdges)
        {
            string from = GetConfigurationKey(edge.FromProject, edge.FromTargetFramework);
            if (!allConfigurations.Contains(from))
            {
                throw new InvalidOperationException($"Configuration edge references unknown source '{from}'.");
            }

            switch (edge.Kind)
            {
                case "ProjectReference":
                    string to = GetConfigurationKey(edge.To, edge.ToTargetFramework);
                    if (!allConfigurations.Contains(to))
                    {
                        throw new InvalidOperationException($"Project-reference edge references unknown destination '{to}'.");
                    }
                    AddTableValue(adjacency, from, to);
                    break;
                case "PackageReference":
                    if (repositoryPackageKeys.TryGetValue(GetPackageKey(edge.To), out string package))
                    {
                        // Preserve the shipping project's casing for serialized package keys.
                        AddTableValue(adjacency, from, package);
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported configuration edge kind '{edge.Kind}'.");
            }
        }

        // Project-reference test legs convert repository packages back to source projects.
        foreach ((string package, HashSet<string> configurations) in configurationsByRepositoryPackage)
        {
            foreach (string configuration in configurations)
            {
                AddTableValue(adjacency, package, configuration);
            }
        }
        double indexSeconds = phase.Elapsed.TotalSeconds;

        // Package metadata maps matrix artifact names to every project below its package directory.
        phase.Restart();
        var artifacts = new Dictionary<string, ArtifactState>(KeyComparer);
        foreach (string packageInfoFile in packageInfoFiles)
        {
            PackageInfo packageInfo;
            using (FileStream stream = File.OpenRead(packageInfoFile))
            {
                packageInfo = JsonSerializer.Deserialize<PackageInfo>(stream, ReadOptions)
                    ?? throw new InvalidOperationException($"Package info '{packageInfoFile}' is empty.");
            }

            string artifactName = packageInfo.ArtifactName?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(artifactName))
            {
                Log.LogWarning("Package info '{0}' has no ArtifactName and cannot be queried.", packageInfoFile);
                continue;
            }
            if (!artifacts.TryGetValue(artifactName, out ArtifactState artifact))
            {
                artifact = new ArtifactState(artifactName);
                artifacts.Add(artifactName, artifact);
            }

            string directoryPath = NormalizeRelativePath(packageInfo.DirectoryPath);
            if (!IsSupportedPackageDirectory(directoryPath))
            {
                Log.LogWarning(
                    "Artifact '{0}' has unsupported directory '{1}'; it will use a full checkout.",
                    artifactName,
                    directoryPath);
                artifact.MarkUnavailable();
                continue;
            }
            if (!artifact.IsAvailable)
            {
                continue;
            }

            var seeds = NewSet();
            if (configurationsByPackageRoot.TryGetValue(directoryPath, out HashSet<string> exactRootConfigurations))
            {
                seeds.UnionWith(exactRootConfigurations);
            }
            string directoryPrefix = directoryPath + "/";
            foreach ((string projectPath, HashSet<string> configurations) in configurationsByProjectPath)
            {
                if (projectPath.StartsWith(directoryPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    seeds.UnionWith(configurations);
                }
            }
            if (seeds.Count == 0)
            {
                Log.LogWarning(
                    "Artifact '{0}' has no configurations in the repository graph; it will use a full checkout.",
                    artifactName);
                artifact.MarkUnavailable();
                continue;
            }
            artifact.Seeds.UnionWith(seeds);
        }
        double artifactSeconds = phase.Elapsed.TotalSeconds;

        phase.Restart();
        var outputArtifacts = new SortedDictionary<string, string[]>(StringComparer.Ordinal);
        foreach (ArtifactState artifact in artifacts.Values.OrderBy(value => value.Name, StringComparer.Ordinal))
        {
            outputArtifacts.Add(
                artifact.Name,
                artifact.IsAvailable ? artifact.Seeds.OrderBy(value => value, StringComparer.Ordinal).ToArray() : null);
        }

        var projection = new SparseCheckoutProjection
        {
            SourceCommit = actualCommit,
            AlwaysIncludedPaths = AlwaysIncludedPaths,
            Artifacts = outputArtifacts,
            Adjacency = ToSortedTable(adjacency),
            Paths = ToSortedTable(paths),
            Diagnostics = new ProjectionDiagnostics
            {
                SourceGraphSchemaVersion = graph.SchemaVersion,
                ProjectCount = graph.Nodes.Count,
                ConfigurationCount = allConfigurations.Count,
                ConfigurationEdgeCount = graph.ConfigurationEdges.Count,
                InputCount = graph.Diagnostics.InputCount,
                ArtifactCount = artifacts.Count,
                UnavailableArtifactCount = artifacts.Values.Count(value => !value.IsAvailable),
                ReadSeconds = readSeconds,
                IndexSeconds = indexSeconds,
                ArtifactSeconds = artifactSeconds,
            },
        };

        string outputDirectory = Path.GetDirectoryName(outputFullPath)
            ?? throw new InvalidOperationException($"Output path has no directory: '{outputFullPath}'.");
        Directory.CreateDirectory(outputDirectory);
        string temporaryPath = outputFullPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            using (FileStream stream = File.Create(temporaryPath))
            {
                JsonSerializer.Serialize(stream, projection, WriteOptions);
            }
            File.Move(temporaryPath, outputFullPath, true);
        }
        finally
        {
            File.Delete(temporaryPath);
        }

        double writeSeconds = phase.Elapsed.TotalSeconds;
        total.Stop();
        long outputBytes = new FileInfo(outputFullPath).Length;
        using Process currentProcess = Process.GetCurrentProcess();
        long peakWorkingSetMiB = Math.Max(currentProcess.PeakWorkingSet64, currentProcess.WorkingSet64) / (1024 * 1024);
        Log.LogMessage(
            MessageImportance.High,
            "Sparse checkout graph: projects={0}, configurations={1}, edges={2}, inputs={3}, artifacts={4}, unavailable={5}, bytes={6}, read={7:F2}s, index={8:F2}s, artifact={9:F2}s, write={10:F2}s, elapsed={11:F2}s, peakWorkingSet={12}MiB",
            graph.Nodes.Count,
            allConfigurations.Count,
            graph.ConfigurationEdges.Count,
            graph.Diagnostics.InputCount,
            artifacts.Count,
            artifacts.Values.Count(value => !value.IsAvailable),
            outputBytes,
            readSeconds,
            indexSeconds,
            artifactSeconds,
            writeSeconds,
            total.Elapsed.TotalSeconds,
            peakWorkingSetMiB);
    }

    private void ValidateSourceGraph(SourceGraph graph, string graphPath)
    {
        if (graph.SchemaVersion != SourceSchemaVersion)
        {
            throw new InvalidOperationException(
                $"Unsupported repository project graph schema version '{graph.SchemaVersion}'. Expected {SourceSchemaVersion}.");
        }
        if (graph.Diagnostics is null || !graph.Diagnostics.IsComplete)
        {
            throw new InvalidOperationException($"Repository project graph is incomplete. See diagnostics in '{graphPath}'.");
        }
        if (graph.Diagnostics.PackageClosure?.ResolutionMode != "nuget-restore-graph")
        {
            throw new InvalidOperationException(
                $"Sparse checkout requires the NuGet restore graph, but '{graph.Diagnostics.PackageClosure?.ResolutionMode}' was used.");
        }
        if (graph.Diagnostics.Generation is null || !graph.Diagnostics.Generation.IncludesInputs ||
            graph.Diagnostics.Generation.Configuration != "Debug")
        {
            throw new InvalidOperationException("Sparse checkout requires a Debug repository graph with evaluated inputs.");
        }
        if (graph.Diagnostics.CheckoutRoots is null || !graph.Diagnostics.CheckoutRoots.IsComplete ||
            graph.CheckoutRoots is null)
        {
            throw new InvalidOperationException("Sparse checkout requires a complete checkout-root index.");
        }
        if (graph.Nodes is null || graph.ConfigurationEdges is null)
        {
            throw new InvalidOperationException("Repository project graph is missing required node or edge data.");
        }
    }

    private string ValidateProvenance(string repositoryRoot, SourceGraph graph)
    {
        if (!string.Equals(graph.SourceCommit, SourceCommit, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Repository project graph commit '{graph.SourceCommit}' does not match requested sparse-checkout provenance '{SourceCommit}'.");
        }

        string actualCommit = GetHeadCommit(repositoryRoot);
        if (!string.Equals(actualCommit, SourceCommit, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Source commit '{actualCommit}' does not match requested sparse-checkout provenance '{SourceCommit}'.");
        }
        if (!AllowDirtySource)
        {
            (int exitCode, _, string error) = RunGit(repositoryRoot, "diff", "--quiet", "--no-ext-diff", "HEAD", "--");
            if (exitCode != 0)
            {
                throw new InvalidOperationException(
                    $"Repository '{repositoryRoot}' has tracked changes, so its checkout graph cannot be attributed to commit '{actualCommit}'. {error}".Trim());
            }
        }
        return actualCommit;
    }

    private static string GetHeadCommit(string repositoryRoot)
    {
        (int exitCode, string output, string error) = RunGit(repositoryRoot, "rev-parse", "HEAD");
        if (exitCode != 0 || string.IsNullOrWhiteSpace(output))
        {
            throw new InvalidOperationException($"Unable to read the source commit under '{repositoryRoot}'. {error}".Trim());
        }
        return output.Trim();
    }

    private static (int ExitCode, string Output, string Error) RunGit(string repositoryRoot, params string[] arguments)
    {
        var startInfo = new ProcessStartInfo("git")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        startInfo.ArgumentList.Add("-C");
        startInfo.ArgumentList.Add(repositoryRoot);
        foreach (string argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        using Process process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Failed to start Git.");
        System.Threading.Tasks.Task<string> output = process.StandardOutput.ReadToEndAsync();
        System.Threading.Tasks.Task<string> error = process.StandardError.ReadToEndAsync();
        process.WaitForExit();
        System.Threading.Tasks.Task.WaitAll(output, error);
        return (process.ExitCode, output.Result.Trim(), error.Result.Trim());
    }

    private static Dictionary<string, HashSet<string>> NewTable() => new(KeyComparer);

    private static HashSet<string> NewSet() => new(KeyComparer);

    private static void AddTableValue(Dictionary<string, HashSet<string>> table, string key, string value)
    {
        if (!table.TryGetValue(key, out HashSet<string> values))
        {
            values = NewSet();
            table.Add(key, values);
        }
        values.Add(value);
    }

    private static SortedDictionary<string, string[]> ToSortedTable(Dictionary<string, HashSet<string>> table)
    {
        var result = new SortedDictionary<string, string[]>(StringComparer.Ordinal);
        foreach ((string key, HashSet<string> values) in table)
        {
            result.Add(key, values.OrderBy(value => value, StringComparer.Ordinal).ToArray());
        }
        return result;
    }

    private static string GetConfigurationKey(string projectPath, string targetFramework) =>
        $"configuration:{NormalizeRelativePath(projectPath)}|{targetFramework}";

    private static string GetPackageKey(string packageId) => $"package:{packageId}";

    private static string NormalizeDirectory(string path) =>
        Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

    private static string NormalizeRelativePath(string path) =>
        (path ?? string.Empty).Replace('\\', '/').Trim('/');

    private static bool IsSupportedPackageDirectory(string path)
    {
        string[] segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        return segments.Length >= 3 && segments[0].Equals("sdk", StringComparison.OrdinalIgnoreCase);
    }

    private sealed class ArtifactState
    {
        internal ArtifactState(string name)
        {
            Name = name;
        }

        internal string Name { get; }
        internal bool IsAvailable { get; private set; } = true;
        internal HashSet<string> Seeds { get; } = NewSet();

        internal void MarkUnavailable()
        {
            IsAvailable = false;
            Seeds.Clear();
        }
    }

    private sealed class SourceGraph
    {
        public int SchemaVersion { get; set; }
        public string SourceCommit { get; set; }
        public List<SourceNode> Nodes { get; set; }
        public List<SourceEdge> ConfigurationEdges { get; set; }
        public Dictionary<string, string[]> CheckoutRoots { get; set; }
        public SourceDiagnostics Diagnostics { get; set; }
    }

    private sealed class SourceNode
    {
        public string ProjectPath { get; set; }
        public string PackageId { get; set; }
        public string PackageRoot { get; set; }
        public bool IsShippingLibrary { get; set; }
        public string[] TargetFrameworks { get; set; }
    }

    private sealed class SourceEdge
    {
        public string Kind { get; set; }
        public string FromProject { get; set; }
        public string FromTargetFramework { get; set; }
        public string To { get; set; }
        public string ToTargetFramework { get; set; }
    }

    private sealed class SourceDiagnostics
    {
        public bool IsComplete { get; set; }
        public int InputCount { get; set; }
        public SourceGeneration Generation { get; set; }
        public PackageClosure PackageClosure { get; set; }
        public CheckoutRootDiagnostics CheckoutRoots { get; set; }
    }

    private sealed class SourceGeneration
    {
        public string Configuration { get; set; }
        public bool IncludesInputs { get; set; }
    }

    private sealed class PackageClosure
    {
        public string ResolutionMode { get; set; }
    }

    private sealed class CheckoutRootDiagnostics
    {
        public bool IsComplete { get; set; }
    }

    private sealed class PackageInfo
    {
        public string ArtifactName { get; set; }
        public string DirectoryPath { get; set; }
    }

    private sealed class SparseCheckoutProjection
    {
        public int SchemaVersion { get; set; } = 1;
        public string SourceCommit { get; set; }
        public bool IsComplete { get; set; } = true;
        public string FailureReason { get; set; } = string.Empty;
        public string[] AlwaysIncludedPaths { get; set; }
        public SortedDictionary<string, string[]> Artifacts { get; set; }
        public SortedDictionary<string, string[]> Adjacency { get; set; }
        public SortedDictionary<string, string[]> Paths { get; set; }
        public ProjectionDiagnostics Diagnostics { get; set; }
    }

    private sealed class ProjectionDiagnostics
    {
        public int SourceGraphSchemaVersion { get; set; }
        public int ProjectCount { get; set; }
        public int ConfigurationCount { get; set; }
        public int ConfigurationEdgeCount { get; set; }
        public int InputCount { get; set; }
        public int ArtifactCount { get; set; }
        public int UnavailableArtifactCount { get; set; }
        public double ReadSeconds { get; set; }
        public double IndexSeconds { get; set; }
        public double ArtifactSeconds { get; set; }
    }
}
