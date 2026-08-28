using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using NuGet.Commands;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.LibraryModel;
using NuGet.Packaging.Core;
using NuGet.ProjectModel;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

public sealed class ResolveExternalPackageClosureWithNuGetTask : Microsoft.Build.Utilities.Task, ICancelableTask
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    [Required]
    public string RecordsPath { get; set; } = string.Empty;

    [Required]
    public string OutputPath { get; set; } = string.Empty;

    [Required]
    public string NuGetConfigPath { get; set; } = string.Empty;

    [Required]
    public string RestoreOutputPath { get; set; } = string.Empty;

    public int DegreeOfParallelism { get; set; } = 4;

    public override bool Execute()
    {
        if (DegreeOfParallelism < 1)
        {
            Log.LogError("DegreeOfParallelism must be at least one.");
            return false;
        }

        try
        {
            ExecuteAsync(_cancellationTokenSource.Token).GetAwaiter().GetResult();
            return !Log.HasLoggedErrors;
        }
        catch (OperationCanceledException)
        {
            Log.LogError("NuGet repository restore graph resolution was canceled.");
            return false;
        }
        catch (Exception exception)
        {
            Log.LogErrorFromException(exception, true);
            return false;
        }
    }

    public void Cancel() => _cancellationTokenSource.Cancel();

    private async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        RestoreGraphInput input = ReadInput();

        string configPath = Path.GetFullPath(NuGetConfigPath);
        ISettings settings = Settings.LoadSpecificSettings(
            Path.GetDirectoryName(configPath),
            Path.GetFileName(configPath));
#pragma warning disable CS0618
        var sourceProvider = new PackageSourceProvider(settings, enablePackageSourcesChangedEvent: false);
#pragma warning restore CS0618
        PackageSource[] sources = sourceProvider.LoadPackageSources()
            .Where(source => source.IsEnabled)
            .ToArray();
        if (sources.Length == 0 && input.RestoreProjects.Count > 0)
        {
            throw new InvalidOperationException($"No enabled package sources were found in '{configPath}'.");
        }

        string globalPackagesPath = Path.GetFullPath(SettingsUtility.GetGlobalPackagesFolder(settings));
        string[] fallbackFolders = SettingsUtility.GetFallbackPackageFolders(settings)
            .Select(Path.GetFullPath)
            .ToArray();
        string restoreOutputPath = Path.GetFullPath(RestoreOutputPath);
        Directory.CreateDirectory(restoreOutputPath);

        IReadOnlyList<ProjectResult> results;
        using (var cacheContext = new SourceCacheContext())
        {
            results = input.RestoreProjects.Count == 0
                ? Array.Empty<ProjectResult>()
                : await ResolveProjectsAsync(
                    input,
                    settings,
                    sourceProvider,
                    sources,
                    configPath,
                    globalPackagesPath,
                    fallbackFolders,
                    restoreOutputPath,
                    cacheContext,
                    cancellationToken).ConfigureAwait(false);
        }

        stopwatch.Stop();
        ClosureStatistics statistics = WriteRecords(results, input.ProjectContextCount, stopwatch.Elapsed);
        Log.LogMessage(
            MessageImportance.High,
            "Repository NuGet restore graph: projects={0}, projectContexts={1}, restoreRequests={2}, roots={3}, resolved={4}, derivedEdges={5}, unresolved={6}, selectedPackages={7}, elapsed={8:F2}s, degreeOfParallelism={9}.",
            input.Projects.Count,
            statistics.ProjectContextCount,
            statistics.RestoreRequestCount,
            statistics.RootCount,
            statistics.ResolvedRootCount,
            statistics.DerivedEdgeCount,
            statistics.UnresolvedRootCount,
            statistics.SelectedPackageCount,
            stopwatch.Elapsed.TotalSeconds,
            DegreeOfParallelism);

        if (statistics.UnresolvedRootCount > 0)
        {
            Log.LogWarning(
                "NuGet restore could not resolve {0} external package roots. The repository graph artifact will contain the details and be marked incomplete.",
                statistics.UnresolvedRootCount);
        }
    }

    private RestoreGraphInput ReadInput()
    {
        var records = new List<RepositoryProjectGraphRecord>();
        foreach (string line in File.ReadLines(RecordsPath))
        {
            RepositoryProjectGraphRecord record = RepositoryProjectGraphRecord.ParseRestoreInput(line);
            if (record is not null)
            {
                records.Add(record);
            }
        }

        var projects = new Dictionary<string, ProjectDefinition>(StringComparer.OrdinalIgnoreCase);
        var localPackages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Materialize every project/TFM first so record ordering does not affect reference lookup.
        foreach (RepositoryProjectGraphRecord.Node node in records.OfType<RepositoryProjectGraphRecord.Node>())
        {
            if (string.IsNullOrEmpty(node.ProjectPath) || string.IsNullOrEmpty(node.TargetFramework))
            {
                continue;
            }

            if (node.CentralPackageTransitivePinningEnabled.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"CentralPackageTransitivePinningEnabled is not supported by the NuGet restore graph spike: '{node.ProjectPath}' ({node.TargetFramework}).");
            }
            if (node.IsShippingLibrary.Equals("true", StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrEmpty(node.PackageId))
            {
                localPackages.Add(node.PackageId);
            }

            string projectPath = Path.GetFullPath(node.ProjectPath);
            if (!projects.TryGetValue(projectPath, out ProjectDefinition project))
            {
                project = new ProjectDefinition(projectPath);
                projects.Add(projectPath, project);
            }

            var framework = new FrameworkDefinition(
                projectPath,
                node.TargetFramework,
                node.AssetTargetFallback,
                node.PackageTargetFallback,
                node.RuntimeIdentifierGraphPath,
                node.TreatWarningsAsErrors.Equals("true", StringComparison.OrdinalIgnoreCase),
                node.WarningsAsErrors,
                node.NoWarn,
                node.WarningsNotAsErrors);
            if (project.Frameworks.TryGetValue(framework.TargetFramework, out FrameworkDefinition existingFramework))
            {
                if (!existingFramework.HasSameRestoreProperties(framework))
                {
                    throw new InvalidOperationException(
                        $"Project configuration '{projectPath}' ({framework.TargetFramework}) has conflicting restore properties across build configurations.");
                }
            }
            else
            {
                project.Frameworks.Add(framework.TargetFramework, framework);
            }
        }

        foreach (RepositoryProjectGraphRecord record in records)
        {
            if (record is RepositoryProjectGraphRecord.PackageReference packageRecord &&
                !string.IsNullOrEmpty(packageRecord.ProjectPath) &&
                !string.IsNullOrEmpty(packageRecord.TargetFramework) &&
                !string.IsNullOrEmpty(packageRecord.PackageId))
            {
                FrameworkDefinition framework = GetFramework(
                    projects,
                    packageRecord.ProjectPath,
                    packageRecord.TargetFramework);
                if (string.IsNullOrWhiteSpace(packageRecord.VersionSpec) ||
                    !VersionRange.TryParse(packageRecord.VersionSpec, out _))
                {
                    throw new InvalidOperationException(
                        $"Package '{packageRecord.PackageId}' in '{packageRecord.ProjectPath}' ({packageRecord.TargetFramework}) has no valid evaluated version.");
                }

                var package = new DirectPackage(
                    packageRecord.PackageId,
                    packageRecord.VersionSpec,
                    packageRecord.PrivateAssets,
                    packageRecord.IncludeAssets,
                    packageRecord.ExcludeAssets);
                if (framework.Packages.TryGetValue(package.Id, out DirectPackage existing) && existing != package)
                {
                    throw new InvalidOperationException(
                        $"Package '{package.Id}' has conflicting evaluated references in '{packageRecord.ProjectPath}' ({packageRecord.TargetFramework}).");
                }
                framework.Packages[package.Id] = package;
            }
            else if (record is RepositoryProjectGraphRecord.ProjectReference projectRecord &&
                !string.IsNullOrEmpty(projectRecord.ProjectPath) &&
                !string.IsNullOrEmpty(projectRecord.TargetFramework) &&
                !string.IsNullOrEmpty(projectRecord.ReferencedProjectPath))
            {
                // NuGet's restore targets omit non-assembly project references from ProjectRestoreMetadata.
                // Keep those records in the source graph, but do not let analyzer/tooling projects affect package resolution.
                if (projectRecord.ReferenceOutputAssembly.Equals("false", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                FrameworkDefinition framework = GetFramework(
                    projects,
                    projectRecord.ProjectPath,
                    projectRecord.TargetFramework);
                var reference = new DirectProjectReference(
                    Path.GetFullPath(projectRecord.ReferencedProjectPath),
                    projectRecord.PrivateAssets,
                    projectRecord.IncludeAssets,
                    projectRecord.ExcludeAssets);
                if (framework.ProjectReferences.TryGetValue(reference.ProjectPath, out DirectProjectReference existing) &&
                    existing != reference)
                {
                    throw new InvalidOperationException(
                        $"Project reference '{reference.ProjectPath}' has conflicting metadata in '{projectRecord.ProjectPath}' ({projectRecord.TargetFramework}).");
                }
                framework.ProjectReferences[reference.ProjectPath] = reference;
            }
        }

        foreach (ProjectDefinition project in projects.Values)
        {
            foreach (FrameworkDefinition framework in project.Frameworks.Values)
            {
                foreach (DirectProjectReference reference in framework.ProjectReferences.Values)
                {
                    if (!projects.ContainsKey(reference.ProjectPath))
                    {
                        throw new InvalidOperationException(
                            $"Project restore reference '{reference.ProjectPath}' from '{project.ProjectPath}' ({framework.TargetFramework}) has no evaluated project configuration.");
                    }
                }
            }
        }

        ProjectDefinition[] restoreProjects = projects.Values
            .Where(project => project.Frameworks.Values.Any(framework => framework.HasPackageRoots()))
            .OrderBy(project => project.ProjectPath, StringComparer.OrdinalIgnoreCase)
            .ToArray();
        int projectContextCount = restoreProjects.Sum(project =>
            project.Frameworks.Values.Count(framework => framework.HasPackageRoots()));
        return new RestoreGraphInput(projects, restoreProjects, localPackages, projectContextCount);
    }

    private static FrameworkDefinition GetFramework(
        IReadOnlyDictionary<string, ProjectDefinition> projects,
        string projectPath,
        string targetFramework)
    {
        string fullProjectPath = Path.GetFullPath(projectPath);
        if (!projects.TryGetValue(fullProjectPath, out ProjectDefinition project) ||
            !project.Frameworks.TryGetValue(targetFramework, out FrameworkDefinition framework))
        {
            throw new InvalidOperationException(
                $"Record references unknown project configuration '{fullProjectPath}' ({targetFramework}).");
        }
        return framework;
    }

    private async Task<IReadOnlyList<ProjectResult>> ResolveProjectsAsync(
        RestoreGraphInput input,
        ISettings settings,
        PackageSourceProvider sourceProvider,
        IReadOnlyList<PackageSource> sources,
        string configPath,
        string globalPackagesPath,
        IReadOnlyList<string> fallbackFolders,
        string restoreOutputPath,
        SourceCacheContext cacheContext,
        CancellationToken cancellationToken)
    {
        var dependencyGraph = new DependencyGraphSpec();
        foreach (ProjectDefinition project in input.Projects.Values
            .OrderBy(project => project.ProjectPath, StringComparer.OrdinalIgnoreCase))
        {
            dependencyGraph.AddProject(CreatePackageSpec(
                project,
                sources,
                configPath,
                globalPackagesPath,
                fallbackFolders,
                restoreOutputPath));
        }
        foreach (ProjectDefinition project in input.RestoreProjects)
        {
            dependencyGraph.AddRestore(project.ProjectPath);
        }

        var restoreArgs = new RestoreArgs
        {
            AllowNoOp = false,
            CacheContext = cacheContext,
            CachingSourceProvider = new CachingSourceProvider(sourceProvider),
            ConfigFile = configPath,
            // Project-level concurrency is bounded below. Keep each individual restore walk serial
            // so the combined work cannot oversubscribe the machine.
            DisableParallel = true,
            GlobalPackagesFolder = globalPackagesPath,
            Log = NullLogger.Instance,
            RestoreForceEvaluate = true,
        };
        var requestProvider = new DependencyGraphSpecRequestProvider(
            new RestoreCommandProvidersCache(),
            dependencyGraph,
            settings);
        IReadOnlyList<RestoreSummaryRequest> requests = await requestProvider
            .CreateRequests(restoreArgs)
            .ConfigureAwait(false);

        using var gate = new SemaphoreSlim(DegreeOfParallelism);
        Task<ProjectResult>[] tasks = requests.Select(async request =>
        {
            await gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                string projectPath = Path.GetFullPath(request.InputPath);
                if (!input.Projects.TryGetValue(projectPath, out ProjectDefinition project))
                {
                    throw new InvalidOperationException($"NuGet created an unexpected restore request for '{projectPath}'.");
                }

                try
                {
                    RestoreResult result = await new RestoreCommand(request.Request)
                        .ExecuteAsync(cancellationToken)
                        .ConfigureAwait(false);
                    return CreateProjectResult(project, input.LocalPackages, result);
                }
                catch (Exception exception) when (exception is not OperationCanceledException)
                {
                    return CreateFailedProjectResult(project, input.LocalPackages, GetErrorMessage(exception));
                }
            }
            finally
            {
                gate.Release();
            }
        }).ToArray();

        ProjectResult[] results = await Task.WhenAll(tasks).ConfigureAwait(false);
        if (results.Length != input.RestoreProjects.Count)
        {
            throw new InvalidOperationException(
                $"NuGet created {results.Length} restore results for {input.RestoreProjects.Count} projects.");
        }
        return results;
    }

    private static PackageSpec CreatePackageSpec(
        ProjectDefinition project,
        IReadOnlyList<PackageSource> sources,
        string configPath,
        string globalPackagesPath,
        IReadOnlyList<string> fallbackFolders,
        string restoreOutputPath)
    {
        var targetFrameworks = new List<TargetFrameworkInformation>();
        var restoreFrameworks = new List<ProjectRestoreMetadataFrameworkInfo>();
        foreach (FrameworkDefinition framework in project.Frameworks.Values)
        {
            NuGetFramework nugetFramework = NuGetFramework.ParseFolder(framework.TargetFramework);
            ImmutableArray<LibraryDependency> dependencies = framework.Packages.Values
                .OrderBy(package => package.Id, StringComparer.OrdinalIgnoreCase)
                .Select(package => new LibraryDependency(new LibraryRange(
                    package.Id,
                    VersionRange.Parse(package.VersionSpec),
                    LibraryDependencyTarget.Package))
                {
                    IncludeType = GetIncludeFlags(package.IncludeAssets, package.ExcludeAssets),
                    SuppressParent = LibraryIncludeFlagUtils.GetFlags(
                        package.PrivateAssets,
                        LibraryIncludeFlagUtils.DefaultSuppressParent),
                })
                .ToImmutableArray();
            targetFrameworks.Add(new TargetFrameworkInformation
            {
                AssetTargetFallback = !string.IsNullOrEmpty(framework.AssetTargetFallback),
                Dependencies = dependencies,
                FrameworkName = nugetFramework,
                Imports = ParseFrameworks(framework.AssetTargetFallback, framework.PackageTargetFallback),
                RuntimeIdentifierGraphPath = framework.RuntimeIdentifierGraphPath,
                TargetAlias = framework.TargetFramework,
                Warn = true,
            });

            restoreFrameworks.Add(new ProjectRestoreMetadataFrameworkInfo(nugetFramework)
            {
                ProjectReferences = framework.ProjectReferences.Values
                    .OrderBy(reference => reference.ProjectPath, StringComparer.OrdinalIgnoreCase)
                    .Select(reference => new ProjectRestoreReference
                    {
                        ExcludeAssets = LibraryIncludeFlagUtils.GetFlags(
                            reference.ExcludeAssets,
                            LibraryIncludeFlags.None),
                        IncludeAssets = LibraryIncludeFlagUtils.GetFlags(
                            reference.IncludeAssets,
                            LibraryIncludeFlags.All),
                        PrivateAssets = LibraryIncludeFlagUtils.GetFlags(
                            reference.PrivateAssets,
                            LibraryIncludeFlagUtils.DefaultSuppressParent),
                        ProjectPath = reference.ProjectPath,
                        ProjectUniqueName = reference.ProjectPath,
                    })
                    .ToList(),
                TargetAlias = framework.TargetFramework,
            });
        }

        string projectHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(project.ProjectPath)))
            .Substring(0, 24)
            .ToLowerInvariant();
        string outputPath = Path.Combine(restoreOutputPath, projectHash, "obj");
        Directory.CreateDirectory(outputPath);

        var restoreMetadata = new ProjectRestoreMetadata
        {
            CentralPackageTransitivePinningEnabled = false,
            CentralPackageVersionOverrideDisabled = true,
            CentralPackageVersionsEnabled = false,
            ConfigFilePaths = new List<string> { configPath },
            CrossTargeting = project.Frameworks.Count > 1,
            FallbackFolders = fallbackFolders.ToList(),
            OriginalTargetFrameworks = project.Frameworks.Keys.ToList(),
            OutputPath = outputPath,
            PackagesPath = globalPackagesPath,
            ProjectName = Path.GetFileNameWithoutExtension(project.ProjectPath),
            ProjectPath = project.ProjectPath,
            ProjectStyle = ProjectStyle.PackageReference,
            ProjectUniqueName = project.ProjectPath,
            ProjectWideWarningProperties = CreateWarningProperties(project),
            RestoreDoNotWriteDependencyGraphSpec = true,
            Sources = sources.Select(source => source.Clone()).ToList(),
            TargetFrameworks = restoreFrameworks,
            UsingMicrosoftNETSdk = true,
        };
        return new PackageSpec(targetFrameworks)
        {
            FilePath = project.ProjectPath,
            Name = restoreMetadata.ProjectName,
            RestoreMetadata = restoreMetadata,
        };
    }

    // Preserve evaluated NuGet warning policy even though it does not add graph edges. A restore
    // warning promoted to an error must fail graph generation rather than accept a closure that the
    // corresponding repository restore would reject.
    private static WarningProperties CreateWarningProperties(ProjectDefinition project) => new(
        ParseWarningCodes(project.Frameworks.Values.Select(framework => framework.WarningsAsErrors)),
        ParseWarningCodes(project.Frameworks.Values.Select(framework => framework.NoWarn)),
        project.Frameworks.Values.Any(framework => framework.TreatWarningsAsErrors),
        ParseWarningCodes(project.Frameworks.Values.Select(framework => framework.WarningsNotAsErrors)));

    private static HashSet<NuGetLogCode> ParseWarningCodes(IEnumerable<string> values)
    {
        var result = new HashSet<NuGetLogCode>();
        foreach (string value in values.SelectMany(value =>
            value.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)))
        {
            if (value.StartsWith("NU", StringComparison.OrdinalIgnoreCase) &&
                Enum.TryParse(value, ignoreCase: true, out NuGetLogCode code))
            {
                result.Add(code);
            }
        }
        return result;
    }

    private static ImmutableArray<NuGetFramework> ParseFrameworks(params string[] values) => values
        .SelectMany(value => value.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        .Select(NuGetFramework.ParseFolder)
        .Where(framework => !framework.IsUnsupported)
        .Distinct(NuGetFramework.Comparer)
        .ToImmutableArray();

    private static LibraryIncludeFlags GetIncludeFlags(string include, string exclude)
    {
        LibraryIncludeFlags includeFlags = LibraryIncludeFlagUtils.GetFlags(include, LibraryIncludeFlags.All);
        LibraryIncludeFlags excludeFlags = LibraryIncludeFlagUtils.GetFlags(exclude, LibraryIncludeFlags.None);
        return includeFlags & ~excludeFlags;
    }

    private static ProjectResult CreateProjectResult(
        ProjectDefinition project,
        IReadOnlySet<string> localPackages,
        RestoreResult result)
    {
        if (!result.Success || result.LockFile is null)
        {
            string errors = string.Join(
                "; ",
                result.LogMessages
                    .Where(message => message.Level == LogLevel.Error)
                    .Select(message => message.Message));
            return CreateFailedProjectResult(
                project,
                localPackages,
                string.IsNullOrEmpty(errors) ? "NuGet restore did not produce a lock file." : errors);
        }

        var frameworkResults = new List<FrameworkResult>();
        int selectedPackageCount = 0;
        foreach (FrameworkDefinition framework in project.Frameworks.Values.Where(candidate =>
            candidate.HasPackageRoots()))
        {
            NuGetFramework nugetFramework = NuGetFramework.ParseFolder(framework.TargetFramework);
            LockFileTarget target = result.LockFile.Targets.SingleOrDefault(candidate =>
                string.IsNullOrEmpty(candidate.RuntimeIdentifier) &&
                NuGetFramework.Comparer.Equals(candidate.TargetFramework, nugetFramework));
            if (target is null)
            {
                frameworkResults.Add(CreateFailedFrameworkResult(
                    framework,
                    localPackages,
                    $"NuGet restore did not produce a target for '{framework.TargetFramework}'."));
                continue;
            }

            var libraries = target.Libraries.ToDictionary(
                library => library.Name,
                StringComparer.OrdinalIgnoreCase);
            selectedPackageCount += target.Libraries.Count(library =>
                library.Type.Equals("package", StringComparison.OrdinalIgnoreCase));
            var roots = new List<RootResult>();
            foreach (DirectPackage root in framework.GetPackageRoots())
            {
                if (!libraries.TryGetValue(root.Id, out LockFileTargetLibrary rootLibrary))
                {
                    roots.Add(new RootResult(
                        root,
                        Array.Empty<string>(),
                        new[] { $"NuGet restore did not resolve direct package '{root.Id}' {root.VersionSpec}." }));
                    continue;
                }
                if (rootLibrary.Type.Equals("project", StringComparison.OrdinalIgnoreCase) &&
                    localPackages.Contains(root.Id))
                {
                    roots.Add(new RootResult(
                        root,
                        Array.Empty<string>(),
                        Array.Empty<string>()));
                    continue;
                }
                if (!rootLibrary.Type.Equals("package", StringComparison.OrdinalIgnoreCase))
                {
                    roots.Add(new RootResult(
                        root,
                        Array.Empty<string>(),
                        new[] { $"NuGet resolved direct package '{root.Id}' {root.VersionSpec} as unexpected library type '{rootLibrary.Type}'." }));
                    continue;
                }

                roots.Add(CreateRootResult(root, rootLibrary, libraries, localPackages));
            }
            frameworkResults.Add(new FrameworkResult(framework, roots));
        }

        return new ProjectResult(frameworkResults, selectedPackageCount);
    }

    private static RootResult CreateRootResult(
        DirectPackage root,
        LockFileTargetLibrary rootLibrary,
        IReadOnlyDictionary<string, LockFileTargetLibrary> libraries,
        IReadOnlySet<string> localPackages)
    {
        var reached = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var queue = new Queue<string>();
        queue.Enqueue(rootLibrary.Name);
        while (queue.Count > 0)
        {
            string packageId = queue.Dequeue();
            if (!visited.Add(packageId) || !libraries.TryGetValue(packageId, out LockFileTargetLibrary library))
            {
                continue;
            }

            foreach (PackageDependency dependency in library.Dependencies
                .OrderBy(dependency => dependency.Id, StringComparer.OrdinalIgnoreCase))
            {
                if (!libraries.TryGetValue(dependency.Id, out LockFileTargetLibrary dependencyLibrary))
                {
                    continue;
                }

                if (localPackages.Contains(dependency.Id) && HasCompileAssets(dependencyLibrary))
                {
                    reached.Add(dependency.Id);
                }
                queue.Enqueue(dependency.Id);
            }
        }

        return new RootResult(
            root,
            reached.OrderBy(package => package, StringComparer.OrdinalIgnoreCase).ToArray(),
            Array.Empty<string>());
    }

    private static ProjectResult CreateFailedProjectResult(
        ProjectDefinition project,
        IReadOnlySet<string> localPackages,
        string error) =>
        new(
            project.Frameworks.Values
                .Where(framework => framework.HasPackageRoots())
                .Select(framework => CreateFailedFrameworkResult(framework, localPackages, error))
                .ToArray(),
            0);

    private static FrameworkResult CreateFailedFrameworkResult(
        FrameworkDefinition framework,
        IReadOnlySet<string> localPackages,
        string error) =>
        new(
            framework,
            framework.GetPackageRoots()
                .Select(package => new RootResult(
                    package,
                    Array.Empty<string>(),
                    new[] { error }))
                .ToArray());

    private ClosureStatistics WriteRecords(
        IReadOnlyList<ProjectResult> results,
        int projectContextCount,
        TimeSpan elapsed)
    {
        string fullOutputPath = Path.GetFullPath(OutputPath);
        string outputDirectory = Path.GetDirectoryName(fullOutputPath);
        if (!string.IsNullOrEmpty(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var records = new HashSet<string>(StringComparer.Ordinal);
        int rootCount = 0;
        int resolvedRoots = 0;
        int unresolvedRoots = 0;
        int selectedPackages = 0;
        foreach (ProjectResult result in results)
        {
            selectedPackages += result.SelectedPackageCount;
            foreach (FrameworkResult framework in result.Frameworks)
            {
                foreach (RootResult root in framework.Roots)
                {
                    rootCount++;
                    if (root.Errors.Count == 0)
                    {
                        resolvedRoots++;
                    }
                    else
                    {
                        unresolvedRoots++;
                    }

                    foreach (string packageId in root.ReachedPackageIds)
                    {
                        records.Add(new RepositoryProjectGraphRecord.TransitivePackageReference(
                            framework.Framework.ProjectPath,
                            framework.Framework.TargetFramework,
                            packageId).Serialize());
                    }
                    foreach (string error in root.Errors)
                    {
                        records.Add(RepositoryProjectGraphRecord.Format(
                            RepositoryProjectGraphRecord.UnresolvedPackageClosureKind,
                            framework.Framework.ProjectPath,
                            framework.Framework.TargetFramework,
                            root.Root.Id,
                            root.Root.VersionSpec,
                            Sanitize(error)));
                    }
                }
            }
        }

        int derivedEdgeCount = records.Count(record =>
            record.StartsWith(
                RepositoryProjectGraphRecord.TransitivePackageReferenceKind + "|",
                StringComparison.Ordinal));
        records.Add(RepositoryProjectGraphRecord.Format(
            RepositoryProjectGraphRecord.PackageClosureSummaryKind,
            rootCount.ToString(),
            resolvedRoots.ToString(),
            derivedEdgeCount.ToString(),
            unresolvedRoots.ToString(),
            elapsed.TotalSeconds.ToString("F3", System.Globalization.CultureInfo.InvariantCulture),
            "nuget-restore-graph",
            bool.FalseString,
            bool.TrueString,
            projectContextCount.ToString(),
            results.Count.ToString(),
            selectedPackages.ToString()));

        string temporaryPath = fullOutputPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            File.WriteAllLines(
                temporaryPath,
                records.OrderBy(record => record, StringComparer.Ordinal),
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            File.Move(temporaryPath, fullOutputPath, overwrite: true);
        }
        finally
        {
            File.Delete(temporaryPath);
        }

        return new ClosureStatistics(
            projectContextCount,
            results.Count,
            rootCount,
            resolvedRoots,
            derivedEdgeCount,
            unresolvedRoots,
            selectedPackages);
    }

    private static bool IncludesCompileAssets(string include, string exclude) =>
        (GetIncludeFlags(include, exclude) & LibraryIncludeFlags.Compile) != 0;

    private static bool HasCompileAssets(LockFileTargetLibrary library) =>
        library.CompileTimeAssemblies.Any(asset =>
            !asset.Path.EndsWith("/_._", StringComparison.OrdinalIgnoreCase) &&
            !asset.Path.Equals("_._", StringComparison.OrdinalIgnoreCase));

    private static string Sanitize(string value) => value
        .Replace('|', '/')
        .Replace('\r', ' ')
        .Replace('\n', ' ');

    private static string GetErrorMessage(Exception exception) => exception.GetBaseException().Message;

    private sealed record RestoreGraphInput(
        IReadOnlyDictionary<string, ProjectDefinition> Projects,
        IReadOnlyList<ProjectDefinition> RestoreProjects,
        IReadOnlySet<string> LocalPackages,
        int ProjectContextCount);

    private sealed class ProjectDefinition
    {
        public ProjectDefinition(string projectPath) => ProjectPath = projectPath;

        public string ProjectPath { get; }

        public SortedDictionary<string, FrameworkDefinition> Frameworks { get; } =
            new(StringComparer.OrdinalIgnoreCase);
    }

    private sealed class FrameworkDefinition
    {
        public FrameworkDefinition(
            string projectPath,
            string targetFramework,
            string assetTargetFallback,
            string packageTargetFallback,
            string runtimeIdentifierGraphPath,
            bool treatWarningsAsErrors,
            string warningsAsErrors,
            string noWarn,
            string warningsNotAsErrors)
        {
            ProjectPath = projectPath;
            TargetFramework = targetFramework;
            AssetTargetFallback = assetTargetFallback;
            PackageTargetFallback = packageTargetFallback;
            RuntimeIdentifierGraphPath = runtimeIdentifierGraphPath;
            TreatWarningsAsErrors = treatWarningsAsErrors;
            WarningsAsErrors = warningsAsErrors;
            NoWarn = noWarn;
            WarningsNotAsErrors = warningsNotAsErrors;
        }

        public string ProjectPath { get; }

        public string TargetFramework { get; }

        public string AssetTargetFallback { get; }

        public string PackageTargetFallback { get; }

        public string RuntimeIdentifierGraphPath { get; }

        public bool TreatWarningsAsErrors { get; }

        public string WarningsAsErrors { get; }

        public string NoWarn { get; }

        public string WarningsNotAsErrors { get; }

        public Dictionary<string, DirectPackage> Packages { get; } = new(StringComparer.OrdinalIgnoreCase);

        public Dictionary<string, DirectProjectReference> ProjectReferences { get; } =
            new(StringComparer.OrdinalIgnoreCase);

        public bool HasSameRestoreProperties(FrameworkDefinition other) =>
            StringComparer.OrdinalIgnoreCase.Equals(AssetTargetFallback, other.AssetTargetFallback) &&
            StringComparer.OrdinalIgnoreCase.Equals(PackageTargetFallback, other.PackageTargetFallback) &&
            StringComparer.OrdinalIgnoreCase.Equals(RuntimeIdentifierGraphPath, other.RuntimeIdentifierGraphPath) &&
            TreatWarningsAsErrors == other.TreatWarningsAsErrors &&
            StringComparer.OrdinalIgnoreCase.Equals(WarningsAsErrors, other.WarningsAsErrors) &&
            StringComparer.OrdinalIgnoreCase.Equals(NoWarn, other.NoWarn) &&
            StringComparer.OrdinalIgnoreCase.Equals(WarningsNotAsErrors, other.WarningsNotAsErrors);

        public bool HasPackageRoots() =>
            Packages.Values.Any(package =>
                IncludesCompileAssets(package.IncludeAssets, package.ExcludeAssets));

        public IEnumerable<DirectPackage> GetPackageRoots() =>
            Packages.Values
                .Where(package =>
                    IncludesCompileAssets(package.IncludeAssets, package.ExcludeAssets))
                .OrderBy(package => package.Id, StringComparer.OrdinalIgnoreCase);
    }

    private sealed record DirectPackage(
        string Id,
        string VersionSpec,
        string PrivateAssets,
        string IncludeAssets,
        string ExcludeAssets);

    private sealed record DirectProjectReference(
        string ProjectPath,
        string PrivateAssets,
        string IncludeAssets,
        string ExcludeAssets);

    private sealed record ProjectResult(
        IReadOnlyList<FrameworkResult> Frameworks,
        int SelectedPackageCount);

    private sealed record FrameworkResult(
        FrameworkDefinition Framework,
        IReadOnlyList<RootResult> Roots);

    private sealed record RootResult(
        DirectPackage Root,
        IReadOnlyList<string> ReachedPackageIds,
        IReadOnlyList<string> Errors);

    private readonly record struct ClosureStatistics(
        int ProjectContextCount,
        int RestoreRequestCount,
        int RootCount,
        int ResolvedRootCount,
        int DerivedEdgeCount,
        int UnresolvedRootCount,
        int SelectedPackageCount);
}
