// Reflects over an Azure.ResourceManager.<RP>.dll and emits the resource
// hierarchy as JSON. Runs on .NET 10 so it can load any current
// Azure.ResourceManager assembly version (which may transitively depend on
// System.Text.Json v10 etc., newer than what PowerShell's host runtime can
// satisfy).
//
// Usage:
//     ResourceHierarchyTool --dll <path>              [--probe-dir <dir>]... [--probe-file <dll>]...
//     ResourceHierarchyTool --dll <path> --probe-from-dir <dir>          (legacy: same as --probe-dir)
//
// The tool resolves dependency assemblies in order:
//     1. Already loaded in the AppDomain (e.g. host runtime).
//     2. Files in --probe-dir folders.
//     3. Files matching name in --probe-file list.
// The directory containing --dll is automatically added as a probe dir.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

internal static class Program
{
    private static readonly List<string> ProbeDirs = new();
    private static readonly Dictionary<string, string> ProbeFiles = new(StringComparer.OrdinalIgnoreCase);

    private static int Main(string[] args)
    {
        string? dllPath = null;
        for (int i = 0; i < args.Length; i++)
        {
            string flag = args[i];
            string? Next()
            {
                if (i + 1 >= args.Length)
                {
                    Console.Error.WriteLine($"Missing value for {flag}.");
                    return null;
                }
                return args[++i];
            }

            switch (flag)
            {
                case "--dll":
                    dllPath = Next();
                    if (dllPath == null) return 64;
                    break;
                case "--probe-dir":
                case "--probe-from-dir":
                    {
                        var v = Next();
                        if (v == null) return 64;
                        ProbeDirs.Add(Path.GetFullPath(v));
                    }
                    break;
                case "--probe-file":
                    {
                        var v = Next();
                        if (v == null) return 64;
                        var f = Path.GetFullPath(v);
                        ProbeFiles[Path.GetFileNameWithoutExtension(f)] = f;
                    }
                    break;
                default:
                    Console.Error.WriteLine($"Unknown argument: {flag}");
                    return 64;
            }
        }
        if (string.IsNullOrEmpty(dllPath))
        {
            Console.Error.WriteLine("Missing required --dll <path>.");
            return 64;
        }
        dllPath = Path.GetFullPath(dllPath);
        if (!File.Exists(dllPath))
        {
            Console.Error.WriteLine($"File not found: {dllPath}");
            return 1;
        }
        ProbeDirs.Insert(0, Path.GetDirectoryName(dllPath)!);

        // Also probe the tool's own directory — Azure.ResourceManager + Azure.Core
        // (and their transitive closure) ship next to the tool via PackageReferences
        // in ResourceHierarchyTool.csproj, so most callers don't need to supply
        // --probe-dir at all.
        var toolDir = AppContext.BaseDirectory;
        if (!string.IsNullOrEmpty(toolDir) && !ProbeDirs.Contains(toolDir))
        {
            ProbeDirs.Add(toolDir);
        }

        AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;

        // Find Azure.ResourceManager via the probe surface. It must be loadable
        // because we need its base types (ArmResource, ArmCollection, ResourceData).
        var armDll = Locate("Azure.ResourceManager");
        if (armDll == null)
        {
            Console.Error.WriteLine("Azure.ResourceManager.dll not found via --probe-dir/--probe-file inputs.");
            return 1;
        }

        var armAssembly    = Assembly.LoadFrom(armDll);
        var targetAssembly = Assembly.LoadFrom(dllPath);
        Console.Error.WriteLine($"Loaded: {targetAssembly.GetName().Name} v{targetAssembly.GetName().Version}");
        Console.Error.WriteLine($"Loaded: {armAssembly.GetName().Name} v{armAssembly.GetName().Version}");
        Console.Error.WriteLine($"Host:   {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");

        var armResourceType         = armAssembly.GetType("Azure.ResourceManager.ArmResource", true)!;
        var armCollectionType       = armAssembly.GetType("Azure.ResourceManager.ArmCollection", true)!;
        var resourceDataType        = armAssembly.GetType("Azure.ResourceManager.Models.ResourceData", true)!;
        var trackedResourceDataType = armAssembly.GetType("Azure.ResourceManager.Models.TrackedResourceData", true)!;

        var assemblyName = targetAssembly.GetName().Name!;
        var rpPrefix     = assemblyName.StartsWith("Azure.ResourceManager.")
            ? assemblyName.Substring("Azure.ResourceManager.".Length)
            : assemblyName;

        var allTypes = targetAssembly.GetExportedTypes();

        bool IsAssignableTo(Type type, Type baseType)
        {
            for (var cur = type; cur != null; cur = cur.BaseType)
            {
                if (cur.FullName == baseType.FullName) return true;
            }
            return false;
        }

        var resourceTypes = allTypes
            .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, armResourceType))
            .OrderBy(t => t.Name).ToArray();
        var collectionTypes = allTypes
            .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, armCollectionType))
            .OrderBy(t => t.Name).ToArray();
        var dataTypes = allTypes
            .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, resourceDataType)
                && t.FullName != resourceDataType.FullName
                && t.FullName != trackedResourceDataType.FullName)
            .OrderBy(t => t.Name).ToArray();

        Console.Error.WriteLine($"Found {resourceTypes.Length} resource types, {collectionTypes.Length} collection types, {dataTypes.Length} data types");

        var mockableTypes = allTypes.Where(t => t.Name.StartsWith("Mockable")).ToArray();

        Type GetInner(Type rt)
        {
            if (rt.IsGenericType)
            {
                var g = rt.GetGenericTypeDefinition().FullName;
                if (g == "System.Threading.Tasks.Task`1" || g == "System.Threading.Tasks.ValueTask`1")
                    rt = rt.GetGenericArguments()[0];
            }
            if (rt.IsGenericType)
            {
                var g = rt.GetGenericTypeDefinition().Name;
                if (g == "Response`1" || g == "NullableResponse`1")
                    rt = rt.GetGenericArguments()[0];
            }
            return rt;
        }

        (bool isObsolete, string? msg, bool ebn) GetDeprecation(MemberInfo m)
        {
            bool obs = false; string? msg = null; bool ebn = false;
            foreach (var a in m.GetCustomAttributesData())
            {
                var n = a.AttributeType.FullName;
                if (n == "System.ObsoleteAttribute")
                {
                    obs = true;
                    if (a.ConstructorArguments.Count >= 1)
                        msg = a.ConstructorArguments[0].Value as string;
                }
                else if (n == "System.ComponentModel.EditorBrowsableAttribute"
                         && a.ConstructorArguments.Count >= 1
                         && (int)(a.ConstructorArguments[0].Value ?? 0) == 1)
                {
                    ebn = true;
                }
            }
            return (obs, msg, ebn);
        }

        const BindingFlags InstanceFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        const BindingFlags StaticFlags   = BindingFlags.Public | BindingFlags.Static;

        var resources = new List<ResourceInfo>();
        foreach (var resType in resourceTypes)
        {
            var info = new ResourceInfo
            {
                Name     = resType.Name,
                FullName = resType.FullName,
            };
            var dep = GetDeprecation(resType);
            info.IsObsolete             = dep.isObsolete;
            info.ObsoleteMessage        = dep.msg;
            info.IsEditorBrowsableNever = dep.ebn;

            var rtField = resType.GetField("ResourceType", StaticFlags);
            if (rtField != null)
            {
                try { info.ResourceType = rtField.GetValue(null)?.ToString(); }
                catch { /* ignore */ }
            }

            // Pick the highest-arity overload to dodge AmbiguousMatchException.
            var idCandidates = resType.GetMethods(StaticFlags)
                .Where(m => m.Name == "CreateResourceIdentifier")
                .OrderByDescending(m => m.GetParameters().Length)
                .ToArray();
            if (idCandidates.Length > 0)
            {
                var idMethod = idCandidates[0];
                try
                {
                    var placeholders = idMethod.GetParameters().Select(p => (object)("{" + p.Name + "}")).ToArray();
                    info.ResourceId = idMethod.Invoke(null, placeholders)?.ToString();
                }
                catch { /* ignore */ }
            }

            var dataProp = resType.GetProperty("Data", BindingFlags.Public | BindingFlags.Instance);
            if (dataProp != null)
            {
                info.DataType = dataProp.PropertyType.Name;
                info.IsTrackedResource = IsAssignableTo(dataProp.PropertyType, trackedResourceDataType);
            }

            var expectedCollName = resType.Name.EndsWith("Resource")
                ? resType.Name.Substring(0, resType.Name.Length - "Resource".Length) + "Collection"
                : resType.Name + "Collection";
            var collType = collectionTypes.FirstOrDefault(c => c.Name == expectedCollName);
            if (collType != null) info.CollectionType = collType.Name;
            else                  info.IsSingleton    = true;

            foreach (var method in resType.GetMethods(InstanceFlags))
            {
                if (!method.Name.StartsWith("Get") || method.Name.StartsWith("GetAsync") || method.GetParameters().Length > 1) continue;
                var rt = GetInner(method.ReturnType);
                if (IsAssignableTo(rt, armCollectionType))
                {
                    info.ChildCollections.Add(new ChildEntry { MethodName = method.Name, ReturnType = rt.Name, ParameterCount = method.GetParameters().Length });
                }
                else if (IsAssignableTo(rt, armResourceType) && rt.FullName != resType.FullName)
                {
                    info.ChildResources.Add(new ChildEntry { MethodName = method.Name, ReturnType = rt.Name, ParameterCount = method.GetParameters().Length });
                }
            }

            foreach (var other in resourceTypes)
            {
                if (other == resType) continue;
                foreach (var pm in other.GetMethods(InstanceFlags).Where(m => m.Name.StartsWith("Get")))
                {
                    var rt = GetInner(pm.ReturnType);
                    var matchesColl = info.CollectionType != null && rt.Name == info.CollectionType;
                    var matchesSing = info.IsSingleton && rt.FullName == resType.FullName && pm.GetParameters().Length == 0;
                    if ((matchesColl || matchesSing) && !info.ParentResources.Contains(other.Name))
                        info.ParentResources.Add(other.Name);
                }
            }

            foreach (var mockType in mockableTypes)
            {
                foreach (var mm in mockType.GetMethods(InstanceFlags).Where(m => m.Name.StartsWith("Get")))
                {
                    var rt = GetInner(mm.ReturnType);
                    var matchesColl = info.CollectionType != null && rt.Name == info.CollectionType;
                    var matchesSing = info.IsSingleton && rt.FullName == resType.FullName && mm.GetParameters().Length == 0;
                    if (matchesColl || matchesSing)
                    {
                        var scope = mockType.Name;
                        if (scope.StartsWith("Mockable" + rpPrefix))
                            scope = scope.Substring(("Mockable" + rpPrefix).Length);
                        if (scope.EndsWith("Resource"))
                            scope = scope.Substring(0, scope.Length - "Resource".Length);
                        if (!info.Scopes.Contains(scope)) info.Scopes.Add(scope);
                    }
                }
            }

            resources.Add(info);
        }

        // Propagate scopes down the parent chain (sub-resources inherit the
        // scope of their root ancestor; without this the comparator would be
        // blind to scope drift on every non-top-level resource).
        var byName = resources.ToDictionary(r => r.Name);
        foreach (var r in resources)
        {
            if (r.Scopes.Count > 0) continue;
            var visited = new HashSet<string>(StringComparer.Ordinal);
            foreach (var s in InheritedScopes(r, byName, visited))
                if (!r.Scopes.Contains(s)) r.Scopes.Add(s);
        }

        var json = JsonSerializer.Serialize(resources, new JsonSerializerOptions
        {
            WriteIndented   = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
        });
        Console.Out.WriteLine(json);
        return 0;
    }

    private static IEnumerable<string> InheritedScopes(ResourceInfo r, Dictionary<string, ResourceInfo> byName, HashSet<string> visited)
    {
        if (!visited.Add(r.Name)) yield break;
        if (r.Scopes.Count > 0)
        {
            foreach (var s in r.Scopes) yield return s;
            yield break;
        }
        foreach (var p in r.ParentResources)
        {
            if (!byName.TryGetValue(p, out var parent)) continue;
            foreach (var s in InheritedScopes(parent, byName, visited)) yield return s;
        }
    }

    private static string? Locate(string assemblyName)
    {
        if (ProbeFiles.TryGetValue(assemblyName, out var explicitMatch) && File.Exists(explicitMatch)) return explicitMatch;
        foreach (var dir in ProbeDirs)
        {
            var c = Path.Combine(dir, assemblyName + ".dll");
            if (File.Exists(c)) return c;
        }
        return null;
    }

    private static Assembly? ResolveAssembly(object? sender, ResolveEventArgs args)
    {
        var requested = new AssemblyName(args.Name).Name!;
        var path = Locate(requested);
        if (path != null)
        {
            try { return Assembly.LoadFrom(path); }
            catch { /* fall through */ }
        }
        return null;
    }

    private sealed class ResourceInfo
    {
        public string  Name { get; set; } = "";
        public string? FullName { get; set; }
        public string? ResourceType { get; set; }
        public string? ResourceId { get; set; }
        public string? DataType { get; set; }
        public bool    IsTrackedResource { get; set; }
        public bool    IsSingleton { get; set; }
        public bool    IsObsolete { get; set; }
        public string? ObsoleteMessage { get; set; }
        public bool    IsEditorBrowsableNever { get; set; }
        public string? CollectionType { get; set; }
        public List<ChildEntry> ChildCollections { get; set; } = new();
        public List<ChildEntry> ChildResources   { get; set; } = new();
        public List<string>     ParentResources  { get; set; } = new();
        public List<string>     Scopes           { get; set; } = new();
    }

    private sealed class ChildEntry
    {
        public string MethodName { get; set; } = "";
        public string ReturnType { get; set; } = "";
        public int    ParameterCount { get; set; }
    }
}
