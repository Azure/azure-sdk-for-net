using System.Text.Json;
using System.Xml.Linq;

var options = Options.Parse(args);
var findings = FindVersionOverrides(options);

Console.WriteLine($"Found {findings.Count} PackageReference VersionOverride entr{(findings.Count == 1 ? "y" : "ies")}.");
if (findings.Count > 0)
{
    WriteTable(findings);
}

if (options.OutputJsonPath is not null)
{
    var outputPath = Path.IsPathRooted(options.OutputJsonPath)
        ? options.OutputJsonPath
        : Path.GetFullPath(Path.Combine(options.RepoRoot, options.OutputJsonPath));

    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

    var payload = findings.Select(f => new
    {
        project = f.Project,
        packageId = f.PackageId,
        versionOverride = f.VersionOverride,
        referenceKind = f.ReferenceKind,
        condition = f.Condition
    });

    File.WriteAllText(
        outputPath,
        JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true }));

    Console.WriteLine($"Wrote JSON to: {outputPath.Replace('\\', '/')}");
}

return (options.FailOnFindings && findings.Count > 0) ? 1 : 0;

static List<Finding> FindVersionOverrides(Options options)
{
    var results = new List<Finding>();
    var seen = new HashSet<string>(StringComparer.Ordinal);
    var searchRoots = options.SearchPaths
        .Select(p => Path.GetFullPath(Path.Combine(options.RepoRoot, p)))
        .Where(Directory.Exists)
        .ToArray();

    foreach (var root in searchRoots)
    {
        foreach (var file in Directory.EnumerateFiles(root, "*.csproj", SearchOption.AllDirectories))
        {
            var normalized = file.Replace('\\', '/');
            if (normalized.Contains("/bin/", StringComparison.OrdinalIgnoreCase) ||
                normalized.Contains("/obj/", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            XDocument doc;
            try
            {
                doc = XDocument.Load(file, LoadOptions.None);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load XML for '{file}': {ex.Message}", ex);
            }

            var projectRel = GetRelativePath(options.RepoRoot, file);

            foreach (var pr in doc.Descendants().Where(e => e.Name.LocalName == "PackageReference"))
            {
                var voAttr = pr.Attribute("VersionOverride")?.Value;
                var voElem = pr.Elements().FirstOrDefault(e => e.Name.LocalName == "VersionOverride")?.Value;
                var versionOverride = string.IsNullOrWhiteSpace(voAttr) ? voElem : voAttr;
                if (string.IsNullOrWhiteSpace(versionOverride))
                {
                    continue;
                }

                var include = pr.Attribute("Include")?.Value;
                var update = pr.Attribute("Update")?.Value;
                var packageId = !string.IsNullOrWhiteSpace(include) ? include :
                                !string.IsNullOrWhiteSpace(update) ? update :
                                "<unknown>";

                var referenceKind = !string.IsNullOrWhiteSpace(include) ? "Include" :
                                    !string.IsNullOrWhiteSpace(update) ? "Update" :
                                    "<unknown>";

                var condition = pr.Attribute("Condition")?.Value ??
                               (pr.Parent is not null ? pr.Parent.Attribute("Condition")?.Value : null);
                condition = string.IsNullOrWhiteSpace(condition) ? null : condition;

                // Dedupe identical references; SDK-style projects can include repeated entries.
                var key = $"{projectRel}\n{packageId}\n{versionOverride}\n{referenceKind}\n{condition ?? ""}";
                if (seen.Add(key))
                {
                    results.Add(new Finding(
                        Project: projectRel,
                        PackageId: packageId,
                        VersionOverride: versionOverride!,
                        ReferenceKind: referenceKind,
                        Condition: condition));
                }
            }
        }
    }

    return results
        .OrderBy(r => r.Project, StringComparer.Ordinal)
        .ThenBy(r => r.PackageId, StringComparer.Ordinal)
        .ThenBy(r => r.VersionOverride, StringComparer.Ordinal)
        .ThenBy(r => r.ReferenceKind, StringComparer.Ordinal)
        .ThenBy(r => r.Condition ?? string.Empty, StringComparer.Ordinal)
        .ToList();
}

static string GetRelativePath(string repoRoot, string fullPath)
{
    var basePath = Path.GetFullPath(repoRoot)
        .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
    var full = Path.GetFullPath(fullPath);

    if (full.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
    {
        return full.Substring(basePath.Length).Replace('\\', '/');
    }

    return full.Replace('\\', '/');
}

static void WriteTable(IReadOnlyList<Finding> findings)
{
    // Keep output stable and CI-friendly.
    var headers = new[] { "Project", "PackageId", "VersionOverride", "Ref", "Condition" };

    var col1 = Math.Min(100, Math.Max(headers[0].Length, findings.Max(f => f.Project.Length)));
    var col2 = Math.Min(60, Math.Max(headers[1].Length, findings.Max(f => f.PackageId.Length)));
    var col3 = Math.Min(25, Math.Max(headers[2].Length, findings.Max(f => f.VersionOverride.Length)));
    var col4 = Math.Max(headers[3].Length, findings.Max(f => f.ReferenceKind.Length));

    static string TrimTo(string s, int width) => s.Length <= width ? s : s.Substring(0, Math.Max(0, width - 1)) + "…";

    Console.WriteLine(
        $"{headers[0].PadRight(col1)}  {headers[1].PadRight(col2)}  {headers[2].PadRight(col3)}  {headers[3].PadRight(col4)}  {headers[4]}");
    Console.WriteLine(new string('-', col1 + col2 + col3 + col4 + headers[4].Length + 8));

    foreach (var f in findings)
    {
        Console.WriteLine(
            $"{TrimTo(f.Project, col1).PadRight(col1)}  {TrimTo(f.PackageId, col2).PadRight(col2)}  {TrimTo(f.VersionOverride, col3).PadRight(col3)}  {f.ReferenceKind.PadRight(col4)}  {f.Condition ?? ""}");
    }
}

record Finding(string Project, string PackageId, string VersionOverride, string ReferenceKind, string? Condition);

sealed record Options(string RepoRoot, IReadOnlyList<string> SearchPaths, string? OutputJsonPath, bool FailOnFindings)
{
    public static Options Parse(string[] args)
    {
        var repoRoot = Directory.GetCurrentDirectory();
        var searchPaths = new List<string> { "sdk" };
        string? outputJson = null;
        var fail = false;

        for (var i = 0; i < args.Length; i++)
        {
            var a = args[i];
            switch (a)
            {
                case "--repoRoot":
                    repoRoot = RequireValue(args, ref i, "--repoRoot");
                    break;
                case "--searchPath":
                    searchPaths.Add(RequireValue(args, ref i, "--searchPath"));
                    break;
                case "--outputJson":
                    outputJson = RequireValue(args, ref i, "--outputJson");
                    break;
                case "--failOnFindings":
                    fail = true;
                    break;
                case "--help":
                case "-h":
                case "/?":
                    PrintHelp();
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException($"Unknown argument: '{a}'. Use --help.");
            }
        }

        // If user didn't add any extra --searchPath flags, default list already contains "sdk".
        return new Options(
            RepoRoot: Path.GetFullPath(repoRoot),
            SearchPaths: searchPaths,
            OutputJsonPath: outputJson,
            FailOnFindings: fail);
    }

    static string RequireValue(string[] args, ref int i, string name)
    {
        if (i + 1 >= args.Length)
        {
            throw new ArgumentException($"Missing value for {name}.");
        }
        i++;
        return args[i];
    }

    static void PrintHelp()
    {
        Console.WriteLine(
            """
            FindVersionOverrides

            Scans *.csproj files for <PackageReference ... VersionOverride="..."> and prints an inventory.

            Usage:
              dotnet run --project eng/tools/FindVersionOverrides -- [options]

            Options:
              --repoRoot <path>        Repo root (defaults to current directory)
              --searchPath <path>      Relative path to search (repeatable). Default: sdk
              --outputJson <path>      Write JSON output (path relative to repoRoot unless rooted)
              --failOnFindings         Exit with code 1 when findings exist
            """);
    }
}

