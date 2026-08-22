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
    private static readonly string[] s_inputItemTypes =
    {
        "Compile",
        "None",
        "Content",
        "EmbeddedResource",
        "AdditionalFiles",
    };

    [Required]
    public ITaskItem[] Projects { get; set; } = Array.Empty<ITaskItem>();

    public ITaskItem[] RootProjects { get; set; } = Array.Empty<ITaskItem>();

    [Required]
    public string RecordsPath { get; set; } = string.Empty;

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
        var globalProperties = GetGlobalProperties();
        globalProperties["IsGraphBuild"] = "false";
        if (!IncludeInputs)
        {
            globalProperties["EnableDefaultItems"] = "false";
        }

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
                foreach (string project in declaredProjects)
                {
                    WriteRecord(writer, ref recordCount, $"DeclaredProject|{project}");
                }
                foreach (string project in rootProjects)
                {
                    WriteRecord(writer, ref recordCount, $"Root|{project}");
                }

                foreach (ProjectGraphNode node in nodes
                    .OrderBy(node => GetProjectPath(node.ProjectInstance), StringComparer.OrdinalIgnoreCase)
                    .ThenBy(node => node.ProjectInstance.GetPropertyValue("TargetFramework"), StringComparer.OrdinalIgnoreCase))
                {
                    AddProjectRecords(writer, ref recordCount, node.ProjectInstance);
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

    private void AddProjectRecords(TextWriter writer, ref long recordCount, ProjectInstance project)
    {
        string projectPath = GetProjectPath(project);
        string targetFramework = project.GetPropertyValue("TargetFramework");
        Dictionary<string, string> packageVersions = project.GetItems("PackageVersion")
            .GroupBy(item => item.EvaluatedInclude, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => group.Last().GetMetadataValue("Version"),
                StringComparer.OrdinalIgnoreCase);
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

        WriteRecord(writer, ref recordCount, string.Join(
            "|",
            "Node",
            projectPath,
            targetFramework,
            packageId,
            project.GetPropertyValue("AssemblyName"),
            packageRoot,
            project.GetPropertyValue("IsClientLibrary"),
            project.GetPropertyValue("IsGeneratorLibrary"),
            project.GetPropertyValue("IsTestProject"),
            project.GetPropertyValue("IsShippingLibrary"),
            project.GetPropertyValue("CentralPackageTransitivePinningEnabled"),
            NormalizeRecordMetadata(project.GetPropertyValue("AssetTargetFallback")),
            NormalizeRecordMetadata(project.GetPropertyValue("PackageTargetFallback")),
            NormalizeRecordMetadata(project.GetPropertyValue("RuntimeIdentifierGraphPath")),
            project.GetPropertyValue("TreatWarningsAsErrors"),
            NormalizeRecordMetadata(project.GetPropertyValue("WarningsAsErrors")),
            NormalizeRecordMetadata(project.GetPropertyValue("NoWarn")),
            NormalizeRecordMetadata(project.GetPropertyValue("WarningsNotAsErrors"))));

        var projectReferenceRecords = new HashSet<string>(StringComparer.Ordinal);
        foreach (ProjectItemInstance reference in project.GetItems("ProjectReference"))
        {
            string record = string.Join(
                "|",
                "ProjectReference",
                projectPath,
                targetFramework,
                GetItemFullPath(project, reference),
                reference.GetMetadataValue("ReferenceOutputAssembly"),
                reference.GetMetadataValue("OutputItemType"),
                NormalizeAssetMetadata(reference.GetMetadataValue("PrivateAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("IncludeAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("ExcludeAssets")));
            if (projectReferenceRecords.Add(record))
            {
                WriteRecord(writer, ref recordCount, record);
            }
        }

        foreach (ProjectItemInstance reference in project.GetItems("PackageReference"))
        {
            WriteRecord(writer, ref recordCount, string.Join(
                "|",
                "PackageReference",
                projectPath,
                targetFramework,
                reference.EvaluatedInclude,
                NormalizeAssetMetadata(reference.GetMetadataValue("PrivateAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("IncludeAssets")),
                NormalizeAssetMetadata(reference.GetMetadataValue("ExcludeAssets")),
                GetPackageVersion(reference, packageVersions)));
        }

        if (IncludeInputs)
        {
            AddInputRecords(writer, ref recordCount, project, projectPath, targetFramework);
        }
    }

    private static void AddInputRecords(
        TextWriter writer,
        ref long recordCount,
        ProjectInstance project,
        string projectPath,
        string targetFramework)
    {
        foreach (string import in project.GetPropertyValue("MSBuildAllProjects")
            .Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            WriteRecord(
                writer,
                ref recordCount,
                $"Input|{projectPath}|{targetFramework}|Import|{Path.GetFullPath(import)}");
        }

        foreach (string itemType in s_inputItemTypes)
        {
            foreach (ProjectItemInstance item in project.GetItems(itemType))
            {
                WriteRecord(
                    writer,
                    ref recordCount,
                    $"Input|{projectPath}|{targetFramework}|{itemType}|{GetItemFullPath(project, item)}");
            }
        }
    }

    private static void WriteRecord(TextWriter writer, ref long recordCount, string record)
    {
        writer.WriteLine(record);
        recordCount++;
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

    private static string NormalizeRecordMetadata(string value) => value
        .Replace('|', '/')
        .Replace('\r', ';')
        .Replace('\n', ';');

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
