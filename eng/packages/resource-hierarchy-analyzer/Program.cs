using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
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

// Open PE reader for IL-level analysis (extracting ResourceType values and ResourceId patterns)
using var peStream = File.OpenRead(dllPath);
using var peReader = new PEReader(peStream);
var mdReader = peReader.GetMetadataReader();

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

    // Get ResourceType value by scanning the static constructor IL
    var resourceTypeValue = ExtractResourceTypeFromCctor(peReader, mdReader, resType.FullName!);
    if (resourceTypeValue != null)
    {
        info.ResourceType = resourceTypeValue;
    }

    // Get ResourceId pattern from CreateResourceIdentifier method
    var createIdMethod = resType.GetMethod("CreateResourceIdentifier", BindingFlags.Public | BindingFlags.Static);
    if (createIdMethod != null)
    {
        var paramNames = createIdMethod.GetParameters().Select(p => p.Name!).ToArray();
        var resourceIdPattern = ExtractResourceIdPattern(peReader, mdReader, resType.FullName!, paramNames);
        if (resourceIdPattern != null)
        {
            info.ResourceId = resourceIdPattern;
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
        else if (IsAssignableTo(returnType, armResourceType))
        {
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

// Helper: Extract the ResourceType string value from a type's static constructor IL
static string? ExtractResourceTypeFromCctor(PEReader peReader, MetadataReader mdReader, string typeFullName)
{
    var typeDef = FindTypeDefinition(mdReader, typeFullName);
    if (typeDef == null) return null;

    foreach (var methodHandle in typeDef.Value.GetMethods())
    {
        var methodDef = mdReader.GetMethodDefinition(methodHandle);
        if (mdReader.GetString(methodDef.Name) != ".cctor") continue;

        var strings = ExtractStringsFromIL(peReader, mdReader, methodDef);
        // ResourceType string contains '/' but doesn't start with '/' (e.g., "Microsoft.ContainerInstance/containerGroups")
        return strings.FirstOrDefault(s => s.Contains('/') && !s.StartsWith("/"));
    }
    return null;
}

// Helper: Extract the resource ID pattern from CreateResourceIdentifier method
static string? ExtractResourceIdPattern(PEReader peReader, MetadataReader mdReader, string typeFullName, string[] paramNames)
{
    var typeDef = FindTypeDefinition(mdReader, typeFullName);
    if (typeDef == null) return null;

    foreach (var methodHandle in typeDef.Value.GetMethods())
    {
        var methodDef = mdReader.GetMethodDefinition(methodHandle);
        if (mdReader.GetString(methodDef.Name) != "CreateResourceIdentifier") continue;

        var strings = ExtractStringsFromIL(peReader, mdReader, methodDef);
        if (strings.Count == 0) return null;

        // Interleave literal segments with parameter placeholders
        var sb = new StringBuilder();
        for (int i = 0; i < strings.Count; i++)
        {
            sb.Append(strings[i]);
            if (i < paramNames.Length)
                sb.Append('{').Append(paramNames[i]).Append('}');
        }
        return sb.ToString();
    }
    return null;
}

// Helper: Find a TypeDefinition by full name in the metadata reader
static TypeDefinition? FindTypeDefinition(MetadataReader mdReader, string typeFullName)
{
    foreach (var handle in mdReader.TypeDefinitions)
    {
        var typeDef = mdReader.GetTypeDefinition(handle);
        var ns = typeDef.Namespace.IsNil ? "" : mdReader.GetString(typeDef.Namespace);
        var name = mdReader.GetString(typeDef.Name);
        var fullName = string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
        if (fullName == typeFullName) return typeDef;
    }
    return null;
}

// Helper: Extract all string literals from a method's IL bytecode
static List<string> ExtractStringsFromIL(PEReader peReader, MetadataReader mdReader, MethodDefinition methodDef)
{
    var strings = new List<string>();
    var rva = methodDef.RelativeVirtualAddress;
    if (rva == 0) return strings;

    var body = peReader.GetMethodBody(rva);
    var ilReader = body.GetILReader();
    var il = ilReader.ReadBytes(ilReader.RemainingBytes);

    for (int i = 0; i < il.Length - 4; i++)
    {
        if (il[i] == 0x72) // ldstr opcode
        {
            int token = il[i + 1] | (il[i + 2] << 8) | (il[i + 3] << 16) | (il[i + 4] << 24);
            var handle = MetadataTokens.Handle(token);
            if (handle.Kind == HandleKind.UserString)
            {
                strings.Add(mdReader.GetUserString((UserStringHandle)handle));
            }
            i += 4;
        }
    }

    return strings;
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
