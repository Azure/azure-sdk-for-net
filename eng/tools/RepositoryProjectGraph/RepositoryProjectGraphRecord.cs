using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

/// <summary>
/// Defines the line-oriented handoff between source graph evaluation, synthetic NuGet restore,
/// and the PowerShell artifact builder. Restore-only fields remain here rather than in the public
/// JSON graph, whose schema models only repository reachability.
/// </summary>
internal abstract record RepositoryProjectGraphRecord
{
    internal const string DeclaredProjectKind = "DeclaredProject";
    internal const string CheckoutRootKind = "CheckoutRoot";
    internal const string GraphGenerationKind = "GraphGeneration";
    internal const string InputKind = "Input";
    internal const string NodeKind = "Node";
    internal const string PackageClosureSummaryKind = "PackageClosureSummary";
    internal const string PackageReferenceKind = "PackageReference";
    internal const string ProjectReferenceKind = "ProjectReference";
    internal const string RootKind = "Root";
    internal const string TransitivePackageReferenceKind = "TransitivePackageReference";
    internal const string UnresolvedPackageClosureKind = "UnresolvedPackageClosure";

    internal abstract string Kind { get; }

    protected abstract IEnumerable<string> GetFields();

    internal string Serialize() => Format(Kind, GetFields());

    /// <summary>
    /// Parses records consumed by the synthetic NuGet restore. Other record kinds belong only to
    /// the artifact builder and return <see langword="null"/> without allocating a model object.
    /// </summary>
    internal static RepositoryProjectGraphRecord ParseRestoreInput(string line)
    {
        string[] fields = line.Split('|');
        return fields[0] switch
        {
            NodeKind => Node.Parse(fields),
            PackageReferenceKind => PackageReference.Parse(fields),
            ProjectReferenceKind => ProjectReference.Parse(fields),
            _ => null,
        };
    }

    /// <summary>
    /// Formats one intermediate record. The format deliberately has no escaping; unsupported
    /// delimiters or newlines fail closed instead of silently changing a path or restore property.
    /// </summary>
    internal static string Format(string kind, params string[] fields) => Format(kind, (IEnumerable<string>)fields);

    private static string Format(string kind, IEnumerable<string> fields)
    {
        string[] values = fields.Prepend(kind).ToArray();
        foreach (string value in values)
        {
            if (value is null || value.Contains('|') || value.Contains('\r') || value.Contains('\n'))
            {
                throw new InvalidOperationException(
                    $"Repository graph record '{kind}' contains an unsupported delimiter or newline.");
            }
        }
        return string.Join('|', values);
    }

    private static string GetField(IReadOnlyList<string> fields, int index) =>
        fields.Count > index ? fields[index] : string.Empty;

    internal sealed record Node(
        string ProjectPath,
        string TargetFramework,
        string PackageId,
        string PackageRoot,
        string IsClientLibrary,
        string IsGeneratorLibrary,
        string IsShippingLibrary,
        string CentralPackageTransitivePinningEnabled,
        string AssetTargetFallback,
        string PackageTargetFallback,
        string RuntimeIdentifierGraphPath,
        string TreatWarningsAsErrors,
        string WarningsAsErrors,
        string NoWarn,
        string WarningsNotAsErrors) : RepositoryProjectGraphRecord
    {
        internal override string Kind => NodeKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return PackageId;
            yield return PackageRoot;
            yield return IsClientLibrary;
            yield return IsGeneratorLibrary;
            yield return IsShippingLibrary;
            yield return CentralPackageTransitivePinningEnabled;
            yield return AssetTargetFallback;
            yield return PackageTargetFallback;
            yield return RuntimeIdentifierGraphPath;
            yield return TreatWarningsAsErrors;
            yield return WarningsAsErrors;
            yield return NoWarn;
            yield return WarningsNotAsErrors;
        }

        internal static Node Parse(IReadOnlyList<string> fields)
        {
            if (fields.Count < 8)
            {
                throw new InvalidOperationException("Invalid repository graph node record.");
            }
            return new Node(
                fields[1],
                fields[2],
                fields[3],
                fields[4],
                fields[5],
                fields[6],
                fields[7],
                GetField(fields, 8),
                GetField(fields, 9),
                GetField(fields, 10),
                GetField(fields, 11),
                GetField(fields, 12),
                GetField(fields, 13),
                GetField(fields, 14),
                GetField(fields, 15));
        }
    }

    internal sealed record ProjectReference(
        string ProjectPath,
        string TargetFramework,
        string ReferencedProjectPath,
        string ReferenceOutputAssembly,
        string PrivateAssets,
        string IncludeAssets,
        string ExcludeAssets,
        string ReferencedTargetFramework) : RepositoryProjectGraphRecord
    {
        internal override string Kind => ProjectReferenceKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return ReferencedProjectPath;
            yield return ReferenceOutputAssembly;
            yield return PrivateAssets;
            yield return IncludeAssets;
            yield return ExcludeAssets;
            yield return ReferencedTargetFramework;
        }

        internal static ProjectReference Parse(IReadOnlyList<string> fields)
        {
            if (fields.Count < 5)
            {
                throw new InvalidOperationException("Invalid repository graph project-reference record.");
            }
            return new ProjectReference(
                fields[1],
                fields[2],
                fields[3],
                fields[4],
                GetField(fields, 5),
                GetField(fields, 6),
                GetField(fields, 7),
                GetField(fields, 8));
        }
    }

    internal sealed record PackageReference(
        string ProjectPath,
        string TargetFramework,
        string PackageId,
        string PrivateAssets,
        string IncludeAssets,
        string ExcludeAssets,
        string VersionSpec) : RepositoryProjectGraphRecord
    {
        internal override string Kind => PackageReferenceKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return PackageId;
            yield return PrivateAssets;
            yield return IncludeAssets;
            yield return ExcludeAssets;
            yield return VersionSpec;
        }

        internal static PackageReference Parse(IReadOnlyList<string> fields)
        {
            if (fields.Count < 8)
            {
                throw new InvalidOperationException("Invalid repository graph package-reference record.");
            }
            return new PackageReference(
                fields[1],
                fields[2],
                fields[3],
                fields[4],
                fields[5],
                fields[6],
                fields[7]);
        }
    }

    internal sealed record Input(
        string ProjectPath,
        string TargetFramework,
        string Path) : RepositoryProjectGraphRecord
    {
        internal override string Kind => InputKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return Path;
        }
    }

    internal sealed record CheckoutRoot(
        string ProjectPath,
        string TargetFramework,
        string Path) : RepositoryProjectGraphRecord
    {
        internal override string Kind => CheckoutRootKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return Path;
        }
    }

    internal sealed record TransitivePackageReference(
        string ProjectPath,
        string TargetFramework,
        string PackageId) : RepositoryProjectGraphRecord
    {
        internal override string Kind => TransitivePackageReferenceKind;

        protected override IEnumerable<string> GetFields()
        {
            yield return ProjectPath;
            yield return TargetFramework;
            yield return PackageId;
        }
    }
}
