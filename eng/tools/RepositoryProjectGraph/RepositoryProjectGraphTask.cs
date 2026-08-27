using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Graph;
using Microsoft.Build.Utilities;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

public sealed class RepositoryProjectGraphTask : Task
{
    private const string GraphConfiguration = "Debug";
    private string _repositoryRoot = string.Empty;

    private static readonly string[] s_inputItemTypes =
    {
        "Compile",
        "None",
        "Content",
        "EmbeddedResource",
        "AdditionalFiles",
        "Analyzer",
        "EditorConfigFiles",
        "GlobalAnalyzerConfigFiles",
        "Protobuf",
        "TypeScriptCompile",
        "ApplicationDefinition",
        "Page",
        "Resource",
        "SplashScreen",
        "NativeReference",
    };

    [Required]
    public ITaskItem[] Projects { get; set; } = Array.Empty<ITaskItem>();

    public ITaskItem[] RootProjects { get; set; } = Array.Empty<ITaskItem>();

    [Required]
    public string RecordsPath { get; set; } = string.Empty;

    [Required]
    public string RepositoryRoot { get; set; } = string.Empty;

    public bool IncludeInputs { get; set; }

    public int DegreeOfParallelism { get; set; } = 1;

    public override bool Execute()
    {
        if (DegreeOfParallelism < 1)
        {
            Log.LogError("DegreeOfParallelism must be at least one.");
            return false;
        }

        try
        {
            ExecuteCore();
            return !Log.HasLoggedErrors;
        }
        catch (Exception exception)
        {
            Log.LogErrorFromException(exception, true);
            return false;
        }
    }

    private void ExecuteCore()
    {
        if (string.IsNullOrWhiteSpace(RepositoryRoot))
        {
            throw new InvalidOperationException("RepositoryRoot is required.");
        }
        _repositoryRoot = Path.GetFullPath(RepositoryRoot)
            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        var globalProperties = GetGlobalProperties();
        if (!IncludeInputs)
        {
            globalProperties["EnableDefaultItems"] = "false";
        }

        // Match the established ProjectDependsOn dependency query: evaluate Debug across every
        // declared TFM. Sparse checkout consumes this same graph rather than adding another build
        // configuration dimension to repository-wide evaluation.
        globalProperties["Configuration"] = GraphConfiguration;
        string[] projectPaths = GetFullPaths(Projects);
        ProjectGraphEntryPoint[] entryPoints = projectPaths
            .Select(path => new ProjectGraphEntryPoint(path, globalProperties))
            .ToArray();

        EvaluateAndWriteRecords(entryPoints, projectPaths, GetFullPaths(RootProjects));
    }

    private void EvaluateAndWriteRecords(
        ProjectGraphEntryPoint[] entryPoints,
        string[] projectPaths,
        string[] rootProjectPaths)
    {
        var options = new ProjectGraphOptions
        {
            EntryPoints = entryPoints,
            DegreeOfParallelism = DegreeOfParallelism,
            ProjectCollection = new ProjectCollection(),
            Mode = ProjectGraphMode.Default,
        };

        using (options.ProjectCollection)
        {
            Process process = Process.GetCurrentProcess();
            process.Refresh();
            long workingSetBefore = process.WorkingSet64;
            var stopwatch = Stopwatch.StartNew();
            var graph = new ProjectGraph(options, CancellationToken.None);
            stopwatch.Stop();
            process.Refresh();

            IReadOnlyCollection<ProjectGraphNode> canonicalNodes = GetCanonicalNodes(graph, out GraphStatistics statistics);
            var recordsStopwatch = Stopwatch.StartNew();
            long recordCount = WriteRecords(projectPaths, rootProjectPaths, canonicalNodes);
            recordsStopwatch.Stop();

            Log.LogMessage(
                MessageImportance.High,
                "Repository ProjectGraph: entries={0}, entryNodes={1}, graphProjects={2}, graphNodes={3}, graphConstruction={4:F2}s, degreeOfParallelism={5}.",
                entryPoints.Length,
                graph.EntryPointNodes.Count,
                statistics.DistinctGraphProjects,
                graph.ProjectNodes.Count,
                stopwatch.Elapsed.TotalSeconds,
                DegreeOfParallelism);
            Log.LogMessage(
                MessageImportance.High,
                "Repository ProjectGraph configurations: emitted={0} (inner={1}, singleTarget={2}), entryOuters={3}, dependencyOnly={4}.",
                canonicalNodes.Count,
                statistics.InnerConfigurations,
                statistics.SingleTargetConfigurations,
                statistics.OuterEntryPoints,
                statistics.DependencyOnlyConfigurations);
            Log.LogMessage(
                MessageImportance.High,
                "Repository ProjectGraph emitted {0} records in {1:F2}s.",
                recordCount,
                recordsStopwatch.Elapsed.TotalSeconds);
            Log.LogMessage(
                MessageImportance.High,
                "Repository ProjectGraph memory: workingSetBefore={0:F1}MiB, workingSetAfter={1:F1}MiB, processPeak={2:F1}MiB.",
                ToMiB(workingSetBefore),
                ToMiB(process.WorkingSet64),
                ToMiB(process.PeakWorkingSet64));
        }
    }

    private Dictionary<string, string> GetGlobalProperties()
    {
        IReadOnlyDictionary<string, string> currentProperties =
            (BuildEngine as IBuildEngine6)?.GetGlobalProperties();
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        if (currentProperties is not null)
        {
            foreach ((string name, string value) in currentProperties)
            {
                result[name] = value;
            }
        }
        // The repository artifact is the OS-neutral union of each project's declared target frameworks.
        result.Remove("TargetFramework");
        result.Remove("TargetFrameworks");
        result.Remove("RuntimeIdentifier");
        result.Remove("RuntimeIdentifiers");
        result.Remove("ServiceDirectory");
        result.Remove("Project");
        result.Remove("SkipServiceProjectImports");
        return result;
    }

    private static string[] GetFullPaths(IEnumerable<ITaskItem> items) => items
        .Select(item =>
        {
            string path = item.GetMetadata("FullPath");
            return Path.GetFullPath(string.IsNullOrEmpty(path) ? item.ItemSpec : path);
        })
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
        .ToArray();

    private IReadOnlyCollection<ProjectGraphNode> GetCanonicalNodes(
        ProjectGraph graph,
        out GraphStatistics statistics)
    {
        var canonicalNodes = new HashSet<ProjectGraphNode>();
        var expectedNodes = new HashSet<ProjectGraphNode>(graph.EntryPointNodes);
        int outerEntryPoints = 0;
        int innerConfigurations = 0;
        int singleTargetConfigurations = 0;

        foreach (ProjectGraphNode entryNode in graph.EntryPointNodes)
        {
            NodeKind kind = GetNodeKind(entryNode.ProjectInstance);
            if (kind != NodeKind.Outer)
            {
                canonicalNodes.Add(entryNode);
                if (kind == NodeKind.Inner)
                {
                    innerConfigurations++;
                }
                else
                {
                    singleTargetConfigurations++;
                }
                continue;
            }

            outerEntryPoints++;
            string entryPath = GetProjectPath(entryNode.ProjectInstance);
            ProjectGraphNode[] innerNodes = entryNode.ProjectReferences
                .Where(node =>
                    StringComparer.OrdinalIgnoreCase.Equals(
                        GetProjectPath(node.ProjectInstance),
                        entryPath) &&
                    GetNodeKind(node.ProjectInstance) == NodeKind.Inner)
                .ToArray();

            if (innerNodes.Length == 0)
            {
                Log.LogError(
                    "ProjectGraph did not expose inner-build self references for outer entry point '{0}'.",
                    entryPath);
                continue;
            }

            foreach (ProjectGraphNode innerNode in innerNodes)
            {
                expectedNodes.Add(innerNode);
                if (canonicalNodes.Add(innerNode))
                {
                    innerConfigurations++;
                }
            }
        }

        ProjectGraphNode[] dependencyOnlyNodes = graph.ProjectNodes
            .Where(node => !expectedNodes.Contains(node))
            .ToArray();
        if (dependencyOnlyNodes.Length > 0)
        {
            string examples = string.Join(
                ", ",
                dependencyOnlyNodes.Take(5).Select(FormatConfiguration));
            throw new InvalidOperationException(
                $"ProjectGraph contains {dependencyOnlyNodes.Length} dependency-only configurations that schema 6 cannot represent: {examples}. " +
                "Preserve the complete global-property identity before using this graph for dependency selection.");
        }

        statistics = new GraphStatistics(
            graph.ProjectNodes
                .Select(node => GetProjectPath(node.ProjectInstance))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count(),
            outerEntryPoints,
            innerConfigurations,
            singleTargetConfigurations,
            graph.ProjectNodes.Count - expectedNodes.Count);

        return canonicalNodes;
    }

    private static string FormatConfiguration(ProjectGraphNode node)
    {
        ProjectInstance project = node.ProjectInstance;
        return $"'{GetProjectPath(project)}' " +
            $"(TargetFramework={project.GetPropertyValue("TargetFramework")}, Configuration={project.GetPropertyValue("Configuration")})";
    }

    private long WriteRecords(
        IEnumerable<string> declaredProjects,
        IEnumerable<string> rootProjects,
        IEnumerable<ProjectGraphNode> nodes)
    {
        string fullRecordsPath = Path.GetFullPath(RecordsPath);
        string recordsDirectory = Path.GetDirectoryName(fullRecordsPath);
        if (!string.IsNullOrEmpty(recordsDirectory))
        {
            Directory.CreateDirectory(recordsDirectory);
        }

        string temporaryPath = fullRecordsPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
        long recordCount = 0;
        try
        {
            using (var writer = new StreamWriter(
                temporaryPath,
                append: false,
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
            {
                // A path may appear through multiple evaluated items or imports. Emit it once so the
                // isolated PowerShell artifact builder does not parse duplicate records.
                var emittedRecords = new HashSet<string>(StringComparer.Ordinal);
                WriteRecord(
                    writer,
                    ref recordCount,
                    emittedRecords,
                    RepositoryProjectGraphRecord.Format(
                        RepositoryProjectGraphRecord.GraphGenerationKind,
                        GraphConfiguration,
                        IncludeInputs.ToString()));
                foreach (string project in declaredProjects)
                {
                    WriteRecord(
                        writer,
                        ref recordCount,
                        emittedRecords,
                        RepositoryProjectGraphRecord.Format(
                            RepositoryProjectGraphRecord.DeclaredProjectKind,
                            project));
                }
                foreach (string project in rootProjects)
                {
                    WriteRecord(
                        writer,
                        ref recordCount,
                        emittedRecords,
                        RepositoryProjectGraphRecord.Format(RepositoryProjectGraphRecord.RootKind, project));
                }

                foreach (ProjectGraphNode node in nodes
                    .OrderBy(node => GetProjectPath(node.ProjectInstance), StringComparer.OrdinalIgnoreCase)
                    .ThenBy(node => node.ProjectInstance.GetPropertyValue("TargetFramework"), StringComparer.OrdinalIgnoreCase))
                {
                    AddProjectRecords(writer, ref recordCount, emittedRecords, node);
                }
            }
            File.Move(temporaryPath, fullRecordsPath, overwrite: true);
        }
        finally
        {
            File.Delete(temporaryPath);
        }

        return recordCount;
    }

    private void AddProjectRecords(
        TextWriter writer,
        ref long recordCount,
        HashSet<string> emittedRecords,
        ProjectGraphNode node)
    {
        ProjectInstance project = node.ProjectInstance;
        string projectPath = GetProjectPath(project);
        string targetFramework = project.GetPropertyValue("TargetFramework");
        foreach (RepositoryProjectGraphRecord record in GetDependencyRecords(node))
        {
            WriteRecord(writer, ref recordCount, emittedRecords, record.Serialize());
        }

        string projectCheckoutRoot = GetCheckoutRoot(projectPath);
        if (!string.IsNullOrEmpty(projectCheckoutRoot))
        {
            WriteRecord(
                writer,
                ref recordCount,
                emittedRecords,
                new RepositoryProjectGraphRecord.CheckoutRoot(
                    projectPath,
                    targetFramework,
                    projectCheckoutRoot).Serialize());
        }

        if (IncludeInputs)
        {
            AddInputRecords(writer, ref recordCount, emittedRecords, project, projectPath, targetFramework);
        }
    }

    private static IEnumerable<RepositoryProjectGraphRecord> GetDependencyRecords(ProjectGraphNode node)
    {
        ProjectInstance project = node.ProjectInstance;
        string projectPath = GetProjectPath(project);
        string targetFramework = project.GetPropertyValue("TargetFramework");
        string packageId = project.GetPropertyValue("PackageId");
        if (string.IsNullOrEmpty(packageId))
        {
            packageId = project.GetPropertyValue("AssemblyName");
        }

        string packageRoot = project.GetPropertyValue("PackageRootDirectory");
        if (string.IsNullOrEmpty(packageRoot))
        {
            packageRoot = Path.GetFullPath(Path.Combine(project.Directory, ".."))
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        yield return new RepositoryProjectGraphRecord.Node(
            projectPath,
            targetFramework,
            packageId,
            packageRoot,
            project.GetPropertyValue("IsClientLibrary"),
            project.GetPropertyValue("IsGeneratorLibrary"),
            project.GetPropertyValue("IsShippingLibrary"),
            project.GetPropertyValue("CentralPackageTransitivePinningEnabled"),
            NormalizeSemicolonSeparatedMetadata(project.GetPropertyValue("AssetTargetFallback")),
            NormalizeSemicolonSeparatedMetadata(project.GetPropertyValue("PackageTargetFallback")),
            project.GetPropertyValue("RuntimeIdentifierGraphPath"),
            project.GetPropertyValue("TreatWarningsAsErrors"),
            NormalizeWarningMetadata(project.GetPropertyValue("WarningsAsErrors")),
            NormalizeWarningMetadata(project.GetPropertyValue("NoWarn")),
            NormalizeWarningMetadata(project.GetPropertyValue("WarningsNotAsErrors")));

        var projectReferenceRecords = new HashSet<RepositoryProjectGraphRecord.ProjectReference>();
        foreach (ProjectItemInstance reference in project.GetItems("ProjectReference"))
        {
            string referencePath = GetItemFullPath(project, reference);
            string[] referencedTargetFrameworks = GetReferencedTargetFrameworks(node, referencePath);
            if (referencedTargetFrameworks.Length == 0)
            {
                referencedTargetFrameworks = new[] { string.Empty };
            }

            foreach (string referencedTargetFramework in referencedTargetFrameworks)
            {
                var record = new RepositoryProjectGraphRecord.ProjectReference(
                    projectPath,
                    targetFramework,
                    referencePath,
                    reference.GetMetadataValue("ReferenceOutputAssembly"),
                    NormalizeAssetMetadata(reference.GetMetadataValue("PrivateAssets")),
                    NormalizeAssetMetadata(reference.GetMetadataValue("IncludeAssets")),
                    NormalizeAssetMetadata(reference.GetMetadataValue("ExcludeAssets")),
                    referencedTargetFramework);
                if (projectReferenceRecords.Add(record))
                {
                    yield return record;
                }
            }
        }

        Dictionary<string, string> packageVersions = project.GetItems("PackageVersion")
            .GroupBy(item => item.EvaluatedInclude, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => group.Last().GetMetadataValue("Version"),
                StringComparer.OrdinalIgnoreCase);
        foreach (ProjectItemInstance reference in project.GetItems("PackageReference"))
        {
            yield return new RepositoryProjectGraphRecord.PackageReference(
                projectPath,
                targetFramework,
                reference.EvaluatedInclude,
                NormalizeAssetMetadata(reference.GetMetadataValue("PrivateAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("IncludeAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("ExcludeAssets")),
                GetPackageVersion(reference, packageVersions));
        }
    }

    private static string[] GetReferencedTargetFrameworks(ProjectGraphNode sourceNode, string referencePath)
    {
        var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (ProjectGraphNode referenceNode in sourceNode.ProjectReferences.Where(node =>
            StringComparer.OrdinalIgnoreCase.Equals(GetProjectPath(node.ProjectInstance), referencePath)))
        {
            string targetFramework = referenceNode.ProjectInstance.GetPropertyValue("TargetFramework");
            if (!string.IsNullOrEmpty(targetFramework))
            {
                result.Add(targetFramework);
                continue;
            }

            foreach (ProjectGraphNode innerNode in referenceNode.ProjectReferences.Where(node =>
                StringComparer.OrdinalIgnoreCase.Equals(GetProjectPath(node.ProjectInstance), referencePath)))
            {
                targetFramework = innerNode.ProjectInstance.GetPropertyValue("TargetFramework");
                if (!string.IsNullOrEmpty(targetFramework))
                {
                    result.Add(targetFramework);
                }
            }
        }

        if (result.Count <= 1)
        {
            return result.ToArray();
        }

        // MSBuild connects an outer-build reference to every concrete destination inner build.
        // Preserve all of those configurations: choosing a nearest framework here would recreate
        // restore compatibility policy and could omit a checkout dependency.
        return result.OrderBy(value => value, StringComparer.OrdinalIgnoreCase).ToArray();
    }

    private void AddInputRecords(
        TextWriter writer,
        ref long recordCount,
        HashSet<string> emittedRecords,
        ProjectInstance project,
        string projectPath,
        string targetFramework)
    {
        foreach (string import in project.GetPropertyValue("MSBuildAllProjects")
            .Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            WriteInputRecord(
                writer, ref recordCount, emittedRecords, projectPath, targetFramework, Path.GetFullPath(import));
        }

        foreach (string itemType in s_inputItemTypes)
        {
            foreach (ProjectItemInstance item in project.GetItems(itemType))
            {
                WriteInputRecord(
                    writer, ref recordCount, emittedRecords, projectPath, targetFramework, GetItemFullPath(project, item));
            }
        }

        foreach (ProjectItemInstance reference in project.GetItems("Reference"))
        {
            string hintPath = reference.GetMetadataValue("HintPath");
            if (!string.IsNullOrEmpty(hintPath))
            {
                WriteInputRecord(
                    writer,
                    ref recordCount,
                    emittedRecords,
                    projectPath,
                    targetFramework,
                    Path.GetFullPath(Path.Combine(project.Directory, hintPath)));
            }
        }
    }

    private void WriteInputRecord(
        TextWriter writer,
        ref long recordCount,
        HashSet<string> emittedRecords,
        string projectPath,
        string targetFramework,
        string inputPath)
    {
        if (!WriteRecord(
            writer,
            ref recordCount,
            emittedRecords,
            new RepositoryProjectGraphRecord.Input(projectPath, targetFramework, inputPath).Serialize()))
        {
            return;
        }

        string checkoutRoot = GetCheckoutRoot(inputPath);
        if (!string.IsNullOrEmpty(checkoutRoot))
        {
            WriteRecord(
                writer,
                ref recordCount,
                emittedRecords,
                new RepositoryProjectGraphRecord.CheckoutRoot(
                    projectPath,
                    targetFramework,
                    checkoutRoot).Serialize());
        }
    }

    /// <summary>
    /// Coarsens an absolute project or input path to a repository sparse-checkout root.
    /// Root files, always-included directories, and paths outside the repository return empty.
    /// </summary>
    private string GetCheckoutRoot(string inputPath)
    {
        string path = Path.GetRelativePath(_repositoryRoot, inputPath).Replace('\\', '/').Trim('/');
        if (Path.IsPathRooted(path))
        {
            return string.Empty;
        }

        string[] segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        if (segments.Length < 2 || segments[0] == "..")
        {
            return string.Empty;
        }
        if (segments[0].Equals("sdk", StringComparison.OrdinalIgnoreCase))
        {
            return segments.Length < 3 ? string.Empty : $"/sdk/{segments[1]}/*";
        }
        if (segments[0].Equals("eng", StringComparison.OrdinalIgnoreCase) ||
            segments[0].Equals(".config", StringComparison.OrdinalIgnoreCase))
        {
            return string.Empty;
        }

        string directory = Path.GetDirectoryName(path)?.Replace('\\', '/');
        return string.IsNullOrWhiteSpace(directory) || directory == "."
            ? string.Empty
            : $"/{directory.Trim('/')}/*";
    }

    private static bool WriteRecord(
        TextWriter writer,
        ref long recordCount,
        HashSet<string> emittedRecords,
        string record)
    {
        if (!emittedRecords.Add(record))
        {
            return false;
        }
        writer.WriteLine(record);
        recordCount++;
        return true;
    }

    private static string GetItemFullPath(ProjectInstance project, ProjectItemInstance item)
    {
        string fullPath = item.GetMetadataValue("FullPath");
        return Path.GetFullPath(
            string.IsNullOrEmpty(fullPath)
                ? Path.Combine(project.Directory, item.EvaluatedInclude)
                : fullPath);
    }

    private static string NormalizeAssetMetadata(string value) => value.Replace(';', ',');

    // MSBuild preserves formatting whitespace in multiline list properties. Canonicalize the
    // separators consumed by NuGet while keeping paths and identities under strict validation.
    private static string NormalizeSemicolonSeparatedMetadata(string value) => string.Join(
        ';',
        value.Split(
            new[] { ';', '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

    private static string NormalizeWarningMetadata(string value) => string.Join(
        ';',
        value.Split(
            new[] { ';', ',', '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

    private static string GetPackageVersion(
        ProjectItemInstance reference,
        IReadOnlyDictionary<string, string> packageVersions)
    {
        string version = reference.GetMetadataValue("VersionOverride");
        if (string.IsNullOrEmpty(version))
        {
            version = reference.GetMetadataValue("Version");
        }
        if (string.IsNullOrEmpty(version))
        {
            packageVersions.TryGetValue(reference.EvaluatedInclude, out version);
        }
        return version ?? string.Empty;
    }

    private static string GetProjectPath(ProjectInstance project) => Path.GetFullPath(project.FullPath);

    private static NodeKind GetNodeKind(ProjectInstance project)
    {
        string innerBuildProperty = project.GetPropertyValue("InnerBuildProperty");
        string innerBuildValue = string.IsNullOrEmpty(innerBuildProperty)
            ? string.Empty
            : project.GetPropertyValue(innerBuildProperty);
        if (!string.IsNullOrEmpty(innerBuildValue))
        {
            return NodeKind.Inner;
        }

        string innerBuildPropertyValues = project.GetPropertyValue("InnerBuildPropertyValues");
        string innerBuildValues = string.IsNullOrEmpty(innerBuildPropertyValues)
            ? string.Empty
            : project.GetPropertyValue(innerBuildPropertyValues);
        return string.IsNullOrEmpty(innerBuildValues) ? NodeKind.SingleTarget : NodeKind.Outer;
    }

    private static double ToMiB(long bytes) => bytes / 1024d / 1024d;

    private readonly record struct GraphStatistics(
        int DistinctGraphProjects,
        int OuterEntryPoints,
        int InnerConfigurations,
        int SingleTargetConfigurations,
        int DependencyOnlyConfigurations);

    private enum NodeKind
    {
        SingleTarget,
        Outer,
        Inner,
    }
}
