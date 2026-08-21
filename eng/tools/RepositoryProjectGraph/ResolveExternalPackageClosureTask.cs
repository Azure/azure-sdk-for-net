using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

public sealed class ResolveExternalPackageClosureTask : Microsoft.Build.Utilities.Task, ICancelableTask
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly ConcurrentDictionary<ResolutionKey, Lazy<Task<ResolvedPackage>>> _resolutionCache = new();
    private SourceRepository[] _repositories = Array.Empty<SourceRepository>();
    private string[] _packageFolders = Array.Empty<string>();
    private SourceCacheContext _cacheContext;
    private int _metadataRequests;
    private int _packageCacheHits;
    private int _remoteMetadataRequests;

    [Required]
    public string RecordsPath { get; set; } = string.Empty;

    [Required]
    public string OutputPath { get; set; } = string.Empty;

    [Required]
    public string NuGetConfigPath { get; set; } = string.Empty;

    public int DegreeOfParallelism { get; set; } = 8;

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
            Log.LogError("External package closure resolution was canceled.");
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
        PackageClosureInput input = ReadInput();

        IReadOnlyList<RootResult> results;
        using (_cacheContext = new SourceCacheContext())
        {
            if (input.Roots.Count == 0)
            {
                results = Array.Empty<RootResult>();
            }
            else
            {
                _repositories = CreateRepositories();
                results = await ResolveRootsAsync(input, cancellationToken).ConfigureAwait(false);
            }
        }

        stopwatch.Stop();
        ClosureStatistics statistics = WriteRecords(results, input.Roots.Count, stopwatch.Elapsed);
        Log.LogMessage(
            MessageImportance.High,
            "Repository external package closure: roots={0}, resolved={1}, derivedEdges={2}, unresolved={3}, metadataRequests={4} (packageCache={5}, remote={6}), elapsed={7:F2}s, degreeOfParallelism={8}.",
            statistics.RootCount,
            statistics.ResolvedRootCount,
            statistics.DerivedEdgeCount,
            statistics.UnresolvedRootCount,
            _metadataRequests,
            _packageCacheHits,
            _remoteMetadataRequests,
            stopwatch.Elapsed.TotalSeconds,
            DegreeOfParallelism);

        if (statistics.UnresolvedRootCount > 0)
        {
            Log.LogWarning(
                "External package metadata could not be resolved for {0} package roots. The repository graph artifact will contain the details and be marked incomplete.",
                statistics.UnresolvedRootCount);
        }
    }

    private PackageClosureInput ReadInput()
    {
        string[] lines = File.ReadAllLines(RecordsPath);
        var localPackages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 10 && parts[0] == "Node" &&
                parts[9].Equals("true", StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrEmpty(parts[3]))
            {
                localPackages.Add(parts[3]);
            }
        }

        var roots = new Dictionary<RootKey, RootGroup>();
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length < 8 || parts[0] != "PackageReference" ||
                string.IsNullOrEmpty(parts[3]) || localPackages.Contains(parts[3]) ||
                !IncludesCompileAssets(parts[5], parts[6]))
            {
                continue;
            }

            var key = new RootKey(
                parts[3].ToLowerInvariant(),
                parts[7],
                parts[2].ToLowerInvariant());
            if (!roots.TryGetValue(key, out RootGroup group))
            {
                group = new RootGroup(parts[3], parts[7], parts[2]);
                roots.Add(key, group);
            }
            group.Origins.Add(new Origin(parts[1], parts[2]));
        }

        foreach (RootGroup root in roots.Values)
        {
            root.Origins.Sort((left, right) =>
            {
                int projectComparison = StringComparer.OrdinalIgnoreCase.Compare(left.ProjectPath, right.ProjectPath);
                return projectComparison != 0
                    ? projectComparison
                    : StringComparer.OrdinalIgnoreCase.Compare(left.TargetFramework, right.TargetFramework);
            });
        }

        return new PackageClosureInput(localPackages, roots.Values.ToArray());
    }

    private SourceRepository[] CreateRepositories()
    {
        string configPath = Path.GetFullPath(NuGetConfigPath);
        ISettings settings = Settings.LoadSpecificSettings(
            Path.GetDirectoryName(configPath),
            Path.GetFileName(configPath));
        var sourceProvider = new PackageSourceProvider(settings);
        var provider = new SourceRepositoryProvider(
            sourceProvider,
            NuGet.Protocol.Core.Types.Repository.Provider.GetCoreV3());
        _packageFolders = new[] { SettingsUtility.GetGlobalPackagesFolder(settings) }
            .Concat(SettingsUtility.GetFallbackPackageFolders(settings))
            .Where(path => !string.IsNullOrEmpty(path))
            .Select(Path.GetFullPath)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
        SourceRepository[] repositories = provider.GetRepositories().ToArray();
        if (repositories.Length == 0)
        {
            throw new InvalidOperationException($"No enabled package sources were found in '{configPath}'.");
        }
        return repositories;
    }

    private async Task<IReadOnlyList<RootResult>> ResolveRootsAsync(
        PackageClosureInput input,
        CancellationToken cancellationToken)
    {
        using var gate = new SemaphoreSlim(DegreeOfParallelism);
        Task<RootResult>[] tasks = input.Roots.Select(async root =>
        {
            await gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return await ResolveRootAsync(root, input.LocalPackages, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                gate.Release();
            }
        }).ToArray();
        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    private async Task<RootResult> ResolveRootAsync(
        RootGroup root,
        IReadOnlySet<string> localPackages,
        CancellationToken cancellationToken)
    {
        var reachedPackages = new Dictionary<string, ReachedPackage>(StringComparer.OrdinalIgnoreCase);
        var errors = new HashSet<string>(StringComparer.Ordinal);
        ResolvedPackage rootPackage;
        try
        {
            rootPackage = await ResolvePackageAsync(
                root.PackageId,
                root.VersionSpec,
                root.TargetFramework,
                cancellationToken).ConfigureAwait(false);
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            errors.Add($"{root.PackageId} {root.VersionSpec}: {GetErrorMessage(exception)}");
            return new RootResult(root, string.Empty, reachedPackages.Values.ToArray(), errors.ToArray());
        }

        string rootIdentity = FormatIdentity(rootPackage.Id, rootPackage.Version);
        var queue = new Queue<PackageVisit>();
        queue.Enqueue(new PackageVisit(rootPackage, rootIdentity));
        var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        while (queue.Count > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();
            PackageVisit visit = queue.Dequeue();
            string visitKey = $"{visit.Package.Id}|{visit.Package.Version.ToNormalizedString()}";
            if (!visited.Add(visitKey))
            {
                continue;
            }

            // Registration metadata does not preserve dependency asset filters. Traverse identity and
            // version ranges consistently for cached and remote packages and disclose that limitation.
            foreach (PackageDependency dependency in visit.Package.Dependencies)
            {
                string dependencyPath = $"{visit.Path}>{dependency.Id} {dependency.VersionRange.ToNormalizedString()}";
                if (localPackages.Contains(dependency.Id))
                {
                    reachedPackages.TryAdd(
                        dependency.Id,
                        new ReachedPackage(dependency.Id, dependencyPath));
                    continue;
                }

                try
                {
                    ResolvedPackage package = await ResolvePackageAsync(
                        dependency.Id,
                        dependency.VersionRange.ToNormalizedString(),
                        root.TargetFramework,
                        cancellationToken).ConfigureAwait(false);
                    queue.Enqueue(new PackageVisit(
                        package,
                        $"{visit.Path}>{FormatIdentity(package.Id, package.Version)}"));
                }
                catch (Exception exception) when (exception is not OperationCanceledException)
                {
                    errors.Add($"{dependency.Id} {dependency.VersionRange.ToNormalizedString()}: {GetErrorMessage(exception)}");
                }
            }
        }

        return new RootResult(
            root,
            rootPackage.Version.ToNormalizedString(),
            reachedPackages.Values.OrderBy(package => package.PackageId, StringComparer.OrdinalIgnoreCase).ToArray(),
            errors.OrderBy(error => error, StringComparer.Ordinal).ToArray());
    }

    private Task<ResolvedPackage> ResolvePackageAsync(
        string packageId,
        string versionSpec,
        string targetFramework,
        CancellationToken cancellationToken)
    {
        var key = new ResolutionKey(
            packageId.ToLowerInvariant(),
            versionSpec,
            targetFramework.ToLowerInvariant());
        return _resolutionCache.GetOrAdd(
            key,
            _ => new Lazy<Task<ResolvedPackage>>(
                () => ResolvePackageUncachedAsync(packageId, versionSpec, targetFramework, cancellationToken),
                LazyThreadSafetyMode.ExecutionAndPublication)).Value;
    }

    private async Task<ResolvedPackage> ResolvePackageUncachedAsync(
        string packageId,
        string versionSpec,
        string targetFramework,
        CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _metadataRequests);
        if (string.IsNullOrWhiteSpace(versionSpec) || !VersionRange.TryParse(versionSpec, out VersionRange versionRange))
        {
            throw new InvalidOperationException($"Package '{packageId}' has no valid evaluated version.");
        }

        NuGetFramework framework = string.IsNullOrEmpty(targetFramework)
            ? NuGetFramework.AnyFramework
            : NuGetFramework.ParseFolder(targetFramework);
        bool queriedRemote = false;

        if (!versionRange.IsFloating && versionRange.MinVersion is not null && versionRange.IsMinInclusive)
        {
            var identity = new PackageIdentity(packageId, versionRange.MinVersion);
            ResolvedPackage exact = ResolvePackageFromCache(identity, framework);
            if (exact is not null)
            {
                Interlocked.Increment(ref _packageCacheHits);
                return exact;
            }

            Interlocked.Increment(ref _remoteMetadataRequests);
            queriedRemote = true;
            exact = await ResolveExactPackageAsync(
                identity,
                framework,
                cancellationToken).ConfigureAwait(false);
            if (exact is not null && versionRange.Satisfies(exact.Version))
            {
                return exact;
            }
        }

        if (!queriedRemote)
        {
            Interlocked.Increment(ref _remoteMetadataRequests);
        }
        var candidates = new List<SourcePackageDependencyInfo>();
        foreach (SourceRepository repository in _repositories)
        {
            DependencyInfoResource resource = await repository
                .GetResourceAsync<DependencyInfoResource>(cancellationToken)
                .ConfigureAwait(false);
            IEnumerable<SourcePackageDependencyInfo> packages = await resource.ResolvePackages(
                packageId,
                framework,
                _cacheContext,
                NullLogger.Instance,
                cancellationToken).ConfigureAwait(false);
            if (packages is not null)
            {
                candidates.AddRange(packages.Where(package => versionRange.Satisfies(package.Version)));
            }
        }

        SourcePackageDependencyInfo selected = FindBestMatch(
            versionRange,
            candidates.Where(package => package.Listed))
            ?? FindBestMatch(versionRange, candidates);
        if (selected is null)
        {
            throw new InvalidOperationException(
                $"No version of package '{packageId}' satisfies '{versionSpec}'.");
        }
        return ToResolvedPackage(selected);
    }

    private static SourcePackageDependencyInfo FindBestMatch(
        VersionRange versionRange,
        IEnumerable<SourcePackageDependencyInfo> candidates)
    {
        SourcePackageDependencyInfo[] packages = candidates.ToArray();
        NuGetVersion bestVersion = versionRange.FindBestMatch(packages.Select(package => package.Version));
        return bestVersion is null
            ? null
            : packages.First(package => package.Version == bestVersion);
    }

    private ResolvedPackage ResolvePackageFromCache(
        PackageIdentity identity,
        NuGetFramework framework)
    {
        string packageId = identity.Id.ToLowerInvariant();
        string version = identity.Version.ToNormalizedString().ToLowerInvariant();
        foreach (string packageFolder in _packageFolders)
        {
            string packagePath = Path.Combine(packageFolder, packageId, version);
            if (!Directory.Exists(packagePath))
            {
                continue;
            }

            try
            {
                if (!File.Exists(Path.Combine(packagePath, ".nupkg.metadata")))
                {
                    continue;
                }
                using var reader = new PackageFolderReader(packagePath);
                PackageIdentity cachedIdentity = reader.GetIdentity();
                if (!PackageIdentity.Comparer.Equals(cachedIdentity, identity))
                {
                    continue;
                }
                PackageDependencyGroup[] groups = reader.GetPackageDependencies().ToArray();
                NuGetFramework nearest = new FrameworkReducer().GetNearest(
                    framework,
                    groups.Select(group => group.TargetFramework));
                PackageDependency[] dependencies = nearest is null
                    ? Array.Empty<PackageDependency>()
                    : groups.First(group => group.TargetFramework.Equals(nearest)).Packages.ToArray();
                return new ResolvedPackage(cachedIdentity.Id, cachedIdentity.Version, dependencies);
            }
            catch (Exception exception) when (exception is IOException or System.Xml.XmlException)
            {
                // A partially populated package cache is not authoritative; fall back to the feed.
            }
        }
        return null;
    }

    private static ResolvedPackage ToResolvedPackage(SourcePackageDependencyInfo package) =>
        new(package.Id, package.Version, package.Dependencies.ToArray());

    private async Task<ResolvedPackage> ResolveExactPackageAsync(
        PackageIdentity identity,
        NuGetFramework framework,
        CancellationToken cancellationToken)
    {
        foreach (SourceRepository repository in _repositories)
        {
            DependencyInfoResource resource = await repository
                .GetResourceAsync<DependencyInfoResource>(cancellationToken)
                .ConfigureAwait(false);
            SourcePackageDependencyInfo package = await resource.ResolvePackage(
                identity,
                framework,
                _cacheContext,
                NullLogger.Instance,
                cancellationToken).ConfigureAwait(false);
            if (package is not null)
            {
                return ToResolvedPackage(package);
            }
        }
        return null;
    }

    private ClosureStatistics WriteRecords(
        IReadOnlyList<RootResult> results,
        int rootCount,
        TimeSpan elapsed)
    {
        string fullOutputPath = Path.GetFullPath(OutputPath);
        string outputDirectory = Path.GetDirectoryName(fullOutputPath);
        if (!string.IsNullOrEmpty(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var records = new HashSet<string>(StringComparer.Ordinal);
        int resolvedRoots = 0;
        int unresolvedRoots = 0;
        foreach (RootResult result in results)
        {
            if (result.Errors.Count == 0)
            {
                resolvedRoots++;
            }
            else
            {
                unresolvedRoots++;
            }

            foreach (Origin origin in result.Root.Origins)
            {
                foreach (ReachedPackage package in result.ReachedPackages)
                {
                    records.Add(string.Join(
                        "|",
                        "TransitivePackageReference",
                        origin.ProjectPath,
                        origin.TargetFramework,
                        package.PackageId,
                        result.Root.PackageId,
                        result.SelectedVersion,
                        Sanitize(package.Path)));
                }
                foreach (string error in result.Errors)
                {
                    records.Add(string.Join(
                        "|",
                        "UnresolvedPackageClosure",
                        origin.ProjectPath,
                        origin.TargetFramework,
                        result.Root.PackageId,
                        result.Root.VersionSpec,
                        Sanitize(error)));
                }
            }
        }

        int derivedEdgeCount = records.Count(record => record.StartsWith("TransitivePackageReference|", StringComparison.Ordinal));
        records.Add(string.Join(
            "|",
            "PackageClosureSummary",
            rootCount,
            resolvedRoots,
            derivedEdgeCount,
            unresolvedRoots,
            _metadataRequests,
            _packageCacheHits,
            _remoteMetadataRequests,
            elapsed.TotalSeconds.ToString("F3", System.Globalization.CultureInfo.InvariantCulture),
            "isolated-package-metadata",
            false,
            false));

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

        return new ClosureStatistics(rootCount, resolvedRoots, derivedEdgeCount, unresolvedRoots);
    }

    private static bool IncludesCompileAssets(string include, string exclude)
    {
        string[] includes = SplitAssets(include);
        string[] excludes = SplitAssets(exclude);
        return (includes.Length == 0 || ContainsAsset(includes, "all") || ContainsAsset(includes, "compile")) &&
            !ContainsAsset(excludes, "all") && !ContainsAsset(excludes, "compile");
    }

    private static string[] SplitAssets(string assets) => assets.Split(
        new[] { ',', ';' },
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    private static bool ContainsAsset(IEnumerable<string> assets, string expected) =>
        assets.Contains(expected, StringComparer.OrdinalIgnoreCase);

    private static string FormatIdentity(string packageId, NuGetVersion version) =>
        $"{packageId} {version.ToNormalizedString()}";

    private static string Sanitize(string value) => value
        .Replace('|', '/')
        .Replace('\r', ' ')
        .Replace('\n', ' ');

    private static string GetErrorMessage(Exception exception) =>
        exception.GetBaseException().Message;

    private sealed record PackageClosureInput(
        IReadOnlySet<string> LocalPackages,
        IReadOnlyList<RootGroup> Roots);

    private sealed record RootGroup(
        string PackageId,
        string VersionSpec,
        string TargetFramework)
    {
        public List<Origin> Origins { get; } = new();
    }

    private sealed record RootResult(
        RootGroup Root,
        string SelectedVersion,
        IReadOnlyList<ReachedPackage> ReachedPackages,
        IReadOnlyList<string> Errors);

    private readonly record struct RootKey(
        string PackageId,
        string VersionSpec,
        string TargetFramework);

    private readonly record struct ResolutionKey(
        string PackageId,
        string VersionSpec,
        string TargetFramework);

    private readonly record struct Origin(string ProjectPath, string TargetFramework);
    private readonly record struct ReachedPackage(string PackageId, string Path);
    private sealed record ResolvedPackage(
        string Id,
        NuGetVersion Version,
        IReadOnlyList<PackageDependency> Dependencies);

    private readonly record struct PackageVisit(ResolvedPackage Package, string Path);
    private readonly record struct ClosureStatistics(
        int RootCount,
        int ResolvedRootCount,
        int DerivedEdgeCount,
        int UnresolvedRootCount);
}
