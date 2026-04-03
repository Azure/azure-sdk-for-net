using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json;
using System.Text.Json.Serialization;

if (args.Length == 0)
{
    Console.Error.WriteLine("Usage: ResourceHierarchyAnalyzer <path-to-Azure.ResourceManager.*.dll>");
    Console.Error.WriteLine("  Analyzes an Azure SDK management-plane library and outputs the resource hierarchy as JSON (stdout)");
    Console.Error.WriteLine("  and a markdown summary (stderr).");
    Console.Error.WriteLine();
    Console.Error.WriteLine("Example:");
    Console.Error.WriteLine("  dotnet run -- path/to/Azure.ResourceManager.Compute.dll");
    return 1;
}

var dllPath = Path.GetFullPath(args[0]);
if (!File.Exists(dllPath))
{
    Console.Error.WriteLine($"Error: File not found: {dllPath}");
    return 1;
}

// Load the target assembly and resolve its dependencies from the same directory
var dllDir = Path.GetDirectoryName(dllPath)!;
var resolver = new PathAssemblyResolver(Directory.GetFiles(dllDir, "*.dll").Concat(
    Directory.GetFiles(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "*.dll")));
using var mlc = new MetadataLoadContext(resolver, coreAssemblyName: "System.Runtime");

var targetAssembly = mlc.LoadFromAssemblyPath(dllPath);

// Load Azure.ResourceManager from the same directory or NuGet cache
var armDllPath = Path.Combine(dllDir, "Azure.ResourceManager.dll");
if (!File.Exists(armDllPath))
{
    Console.Error.WriteLine($"Error: Azure.ResourceManager.dll not found in {dllDir}");
    Console.Error.WriteLine("The target DLL directory must contain Azure.ResourceManager.dll (e.g., from a build output).");
    return 1;
}
var armAssembly = mlc.LoadFromAssemblyPath(armDllPath);

// Load the target assembly into a separate AssemblyLoadContext for reading runtime values
// (MetadataLoadContext can't read static field values; regular reflection can)
var runtimeContext = new AssemblyLoadContext("analysis", isCollectible: true);
runtimeContext.Resolving += (ctx, name) =>
{
    var path = Path.Combine(dllDir, $"{name.Name}.dll");
    return File.Exists(path) ? ctx.LoadFromAssemblyPath(path) : null;
};
var runtimeAssembly = runtimeContext.LoadFromAssemblyPath(dllPath);

Console.Error.WriteLine($"Loaded: {targetAssembly.GetName().Name} v{targetAssembly.GetName().Version}");
Console.Error.WriteLine($"Loaded: {armAssembly.GetName().Name} v{armAssembly.GetName().Version}");

// Key base types from Azure.ResourceManager
var armResourceType = armAssembly.GetType("Azure.ResourceManager.ArmResource")!;
var armCollectionType = armAssembly.GetType("Azure.ResourceManager.ArmCollection")!;
var resourceDataType = armAssembly.GetType("Azure.ResourceManager.Models.ResourceData")!;
var trackedResourceDataType = armAssembly.GetType("Azure.ResourceManager.Models.TrackedResourceData")!;

// Derive the RP prefix from the assembly name (e.g., "Azure.ResourceManager.Compute" -> "Compute")
var assemblyName = targetAssembly.GetName().Name!;
var rpPrefix = assemblyName.Replace("Azure.ResourceManager.", "");

var allTypes = targetAssembly.GetExportedTypes();

// Find all Resource types (inherit from ArmResource)
var resourceTypes = allTypes
    .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, armResourceType))
    .OrderBy(t => t.Name)
    .ToList();

// Find all Collection types (inherit from ArmCollection)
var collectionTypes = allTypes
    .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, armCollectionType))
    .OrderBy(t => t.Name)
    .ToList();

// Find all Data types (inherit from ResourceData)
var dataTypes = allTypes
    .Where(t => t.IsClass && !t.IsAbstract && IsAssignableTo(t, resourceDataType)
        && t.FullName != resourceDataType.FullName && t.FullName != trackedResourceDataType.FullName)
    .OrderBy(t => t.Name)
    .ToList();

Console.Error.WriteLine($"Found {resourceTypes.Count} resource types, {collectionTypes.Count} collection types, {dataTypes.Count} data types");

var resources = new List<ResourceInfo>();

foreach (var resType in resourceTypes)
{
    var info = new ResourceInfo { Name = resType.Name, FullName = resType.FullName! };

    // Use the runtime-loaded assembly to read static field values
    var runtimeType = runtimeAssembly.GetType(resType.FullName!);
    if (runtimeType != null)
    {
        // Get ResourceType value directly from the static field
        var rtField = runtimeType.GetField("ResourceType", BindingFlags.Public | BindingFlags.Static);
        if (rtField != null)
        {
            info.ResourceType = rtField.GetValue(null)?.ToString();
        }

        // Get ResourceId pattern by calling CreateResourceIdentifier with placeholder args
        var createIdMethod = runtimeType.GetMethod("CreateResourceIdentifier", BindingFlags.Public | BindingFlags.Static);
        if (createIdMethod != null)
        {
            var parameters = createIdMethod.GetParameters();
            var placeholderArgs = parameters.Select(p => (object)$"{{{p.Name}}}").ToArray();
            try
            {
                info.ResourceId = createIdMethod.Invoke(null, placeholderArgs)?.ToString();
            }
            catch
            {
                // Ignore if the method fails with placeholder values
            }
        }
    }

    // Get Data property type
    var dataProp = resType.GetProperty("Data", BindingFlags.Public | BindingFlags.Instance);
    if (dataProp != null)
    {
        info.DataType = dataProp.PropertyType.Name;
        info.IsTrackedResource = IsAssignableTo(dataProp.PropertyType, trackedResourceDataType);
    }

    // Find the matching collection type
    var expectedCollectionName = resType.Name.Replace("Resource", "Collection");
    var collType = collectionTypes.FirstOrDefault(c => c.Name == expectedCollectionName);
    if (collType != null)
    {
        info.CollectionType = collType.Name;
    }

    // Find methods that return child collections or resources (Get* methods)
    var getMethods = resType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
        .Where(m => m.Name.StartsWith("Get") && !m.Name.StartsWith("GetAsync") && m.GetParameters().Length <= 1)
        .ToList();

    foreach (var method in getMethods)
    {
        var returnType = method.ReturnType;
        if (returnType.IsGenericType)
            returnType = returnType.GetGenericArguments()[0];
        if (returnType.IsGenericType)
            returnType = returnType.GetGenericArguments()[0];

        if (IsAssignableTo(returnType, armCollectionType))
        {
            info.ChildCollections.Add(new ChildRef
            {
                MethodName = method.Name,
                ReturnType = returnType.Name,
                ParameterCount = method.GetParameters().Length
            });
        }
        else if (IsAssignableTo(returnType, armResourceType) && returnType.FullName != resType.FullName)
        {
            // Exclude self-referencing Get methods (e.g., AvailabilitySetResource.Get() → AvailabilitySetResource)
            info.ChildResources.Add(new ChildRef
            {
                MethodName = method.Name,
                ReturnType = returnType.Name,
                ParameterCount = method.GetParameters().Length
            });
        }
    }

    // Find parent by checking which other resources return this resource's collection
    if (info.CollectionType != null)
    {
        foreach (var otherRes in resourceTypes)
        {
            if (otherRes == resType) continue;
            var parentMethods = otherRes.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => m.Name.StartsWith("Get"));
            foreach (var pm in parentMethods)
            {
                var rt = pm.ReturnType;
                if (rt.IsGenericType) rt = rt.GetGenericArguments()[0];
                if (rt.IsGenericType) rt = rt.GetGenericArguments()[0];
                if (rt.Name == info.CollectionType)
                {
                    if (!info.ParentResources.Contains(otherRes.Name))
                        info.ParentResources.Add(otherRes.Name);
                }
            }
        }
    }

    // Check Mockable types for subscription/resource-group scoped resources
    var mockableTypes = allTypes.Where(t => t.Name.StartsWith("Mockable")).ToList();
    foreach (var mockType in mockableTypes)
    {
        var mockMethods = mockType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(m => m.Name.StartsWith("Get"));
        foreach (var mm in mockMethods)
        {
            var rt = mm.ReturnType;
            if (rt.IsGenericType) rt = rt.GetGenericArguments()[0];
            if (rt.IsGenericType) rt = rt.GetGenericArguments()[0];
            if (info.CollectionType != null && rt.Name == info.CollectionType)
            {
                var scope = mockType.Name
                    .Replace($"Mockable{rpPrefix}", "")
                    .Replace("Resource", "");
                if (!info.Scopes.Contains(scope))
                    info.Scopes.Add(scope);
            }
        }
    }

    resources.Add(info);
}

// Output as JSON to stdout
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};
var json = JsonSerializer.Serialize(resources, options);
Console.WriteLine(json);

// Output markdown summary to stderr
Console.Error.WriteLine($"\n## {assemblyName} Resource Hierarchy\n");
foreach (var r in resources)
{
    // Skip Mockable types in the summary
    if (r.Name.StartsWith("Mockable")) continue;

    var scopeStr = r.Scopes.Count > 0 ? $" (scopes: {string.Join(", ", r.Scopes)})" : "";
    var parentStr = r.ParentResources.Count > 0 ? $" [parent: {string.Join(", ", r.ParentResources)}]" : " [top-level]";
    Console.Error.WriteLine($"- **{r.Name}**{parentStr}{scopeStr}");
    if (r.DataType != null)
        Console.Error.WriteLine($"  - Data: {r.DataType} (tracked: {r.IsTrackedResource})");
    if (r.ResourceType != null)
        Console.Error.WriteLine($"  - ResourceType: {r.ResourceType}");
    if (r.ResourceId != null)
        Console.Error.WriteLine($"  - ResourceId: {r.ResourceId}");
    if (r.ChildCollections.Count > 0)
    {
        Console.Error.WriteLine($"  - Children:");
        foreach (var c in r.ChildCollections)
            Console.Error.WriteLine($"    - {c.MethodName}() → {c.ReturnType}");
    }
}

return 0;

// Helper: MetadataLoadContext types can't use IsAssignableFrom directly, so walk the base chain
static bool IsAssignableTo(Type type, Type baseType)
{
    var current = type;
    while (current != null)
    {
        if (current.FullName == baseType.FullName)
            return true;
        current = current.BaseType;
    }
    return false;
}

class ResourceInfo
{
    public string Name { get; set; } = "";
    public string FullName { get; set; } = "";
    public string? ResourceType { get; set; }
    public string? ResourceId { get; set; }
    public string? DataType { get; set; }
    public bool IsTrackedResource { get; set; }
    public string? CollectionType { get; set; }
    public List<ChildRef> ChildCollections { get; set; } = [];
    public List<ChildRef> ChildResources { get; set; } = [];
    public List<string> ParentResources { get; set; } = [];
    public List<string> Scopes { get; set; } = [];
}

class ChildRef
{
    public string MethodName { get; set; } = "";
    public string ReturnType { get; set; } = "";
    public int ParameterCount { get; set; }
}
