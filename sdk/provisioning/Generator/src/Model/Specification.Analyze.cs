// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Generator.Model;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace Azure.Provisioning.Generator.Model;

public abstract partial class Specification
{
    private void Analyze()
    {
        // Cache all existing generated files upfront so version data is preserved
        // even if a previous spec's Build() cleans the shared output directory.
        CacheGenerationDirectory();

        ContextualException.WithContext(
            $"Analyzing resources of specification {Name}",
            () =>
            {
                Dictionary<Type, MethodInfo> resources = FindConstructibleResources();
                Resources = [.. resources.Keys.OrderBy(t => t.Name).Select(t => new Resource(this, t))];
                foreach (Resource resource in Resources)
                {
                    ModelNameMapping[resource.Name] = resource;
                    ModelArmTypeMapping[resource.ArmType!] = resource;

                    ResourceType? resourceType = resource.ArmType!.GetField("ResourceType")?.GetValue(null) as ResourceType?;
                    if (resourceType is not null)
                    {
                        // Only null for GenericResource
                        resource.ResourceType = resourceType.ToString();
                        resource.ResourceNamespace = resourceType.Value.Namespace;
                    }

                    MethodInfo creator = resources[resource.ArmType!];
                    ContextualException.WithContext(
                        $"Analyzing properties of resource {resource.Name}",
                        () =>
                        {
                            // Pull properties off the method
                            resource.Properties = FindProperties(resource, creator, IgnorePropertiesWithoutPath);

                            // Add anything else off the return type
                            Type? data = creator.ReturnType.GetGenericArguments()?[0]?.GetProperty("Data")?.PropertyType;
                            if (data is not null)
                            {
                                FlattenType(resource, resource.Properties, data, IgnorePropertiesWithoutPath, parameters: false);
                            }

                            // Sort all the properties with Name/required values first and output values last
                            resource.Properties = [.. resource.Properties.OrderBy(p => (p.Name == "Name" ? 0 : p.IsReadOnly ? '3' : p.IsRequired ? '1' : '2') + p.Name)];
                        });

                    // Hack in a few special types
                    if (resource.Name == "Generic")
                    {
                        GetOrCreateModelType(typeof(WritableSubResource), resource, IgnorePropertiesWithoutPath);
                    }

                    MethodInfo? getKeys = resource.ArmType.GetMethod("GetKeys") ?? resource.ArmType.GetMethod("GetSharedKeys");
                    Type? keyType = getKeys?.ReturnType.GetGenericArguments()?[0];
                    if (keyType is not null)
                    {
                        resource.GetKeysType = GetOrCreateModelType(keyType, resource, IgnorePropertiesWithoutPath) as SimpleModel;
                        resource.GetKeysIsList = getKeys!.ReturnType.GetGenericTypeDefinition() == typeof(Pageable<>);
                        resource.GetKeysType!.FromExpression = true;
                    }
                }

                // Analyze to find parent relationships
                Dictionary<string, Resource> resourceTypeMapping = [];
                foreach (Resource resource in Resources)
                {
                    if (resource.ResourceType is null) { continue; }
                    resourceTypeMapping[resource.ResourceType] = resource;
                }
                foreach (Resource resource in Resources)
                {
                    if (resource.ResourceType is null) { continue; }
                    string parentType = string.Join('/', resource.ResourceType.Split('/').SkipLast(1));
                    if (resourceTypeMapping.TryGetValue(parentType, out Resource? parent))
                    {
                        resource.ParentResource = parent;
                    }
                }

                /**/
                // Extract api-versions from the CreateOrUpdate method's XML doc comments,
                // falling back to the Get method if CreateOrUpdate has no version
                foreach (Resource resource in Resources)
                {
                    if (resource.ResourceType is null) { continue; }
                    MethodInfo creator = resources[resource.ArmType!];
                    resource.DefaultResourceVersion = ExtractApiVersionFromXmlDoc(creator);

                    if (resource.DefaultResourceVersion is null)
                    {
                        // Try the Get method on the resource type itself
                        MethodInfo? getter = resource.ArmType!.GetMethod("Get", BindingFlags.Public | BindingFlags.Instance, null, [typeof(CancellationToken)], null);
                        if (getter is not null)
                        {
                            resource.DefaultResourceVersion = ExtractApiVersionFromXmlDoc(getter);
                        }
                    }
                }

                // Try to resolve missing versions from related types
                foreach (Resource resource in Resources.Where(r => r.DefaultResourceVersion is null))
                {
                    // First try the base type
                    Resource? parent = resource.BaseType as Resource;
                    resource.DefaultResourceVersion = parent?.DefaultResourceVersion;
                    resource.ResourceVersions = parent?.ResourceVersions;

                    // Otherwise default to our nearest ancestor with a version
                    // (we're walking up to avoid the effort of a topological sort)
                    parent = resource.ParentResource;
                    while (resource.DefaultResourceVersion is null && parent is not null)
                    {
                        resource.DefaultResourceVersion = parent.DefaultResourceVersion;
                        resource.ResourceVersions = parent.ResourceVersions;
                        parent = parent.ParentResource;
                    }
                }
            });
    }

    private protected virtual Dictionary<Type, MethodInfo> FindConstructibleResources()
    {
        // Find constructible resources
        Dictionary<Type, MethodInfo> resources = [];

        // First look to collections
        foreach (Type type in ArmAssembly.GetExportedTypes())
        {
            if (!type.IsClass) { continue; }
            if (type.BaseType != typeof(ArmCollection)) { continue; }
            if (type.Name.StartsWith("Mockable")) { continue; }

            foreach (MethodInfo method in type.GetMethods())
            {
                if (!method.Name.StartsWith("Create")) { continue; }
                if (!method.ReturnType.IsGenericType) { continue; }
                if (method.ReturnType.GetGenericTypeDefinition() != typeof(ArmOperation<>)) { continue; }

                Type resourceType = method.ReturnType.GetGenericArguments()[0];
                if (resourceType.BaseType != typeof(ArmResource)) { continue; }
                if (resourceType.Name.StartsWith("Mockable")) { continue; }
                resources[resourceType] = method;
            }
        }

        // Then look for directly constructible resources
        foreach (Type type in ArmAssembly.GetExportedTypes())
        {
            if (!type.IsClass) { continue; }
            if (type.BaseType != typeof(ArmResource)) { continue; }
            if (type.Name.StartsWith("Mockable")) { continue; }

            foreach (MethodInfo method in type.GetMethods())
            {
                if (!method.Name.StartsWith("Create")) { continue; }
                if (!method.ReturnType.IsGenericType) { continue; }
                if (method.ReturnType.GetGenericTypeDefinition() != typeof(ArmOperation<>)) { continue; }

                Type resourceType = method.ReturnType.GetGenericArguments()[0];
                if (resourceType.BaseType != typeof(ArmResource)) { continue; }
                if (resourceType.Name.StartsWith("Mockable")) { continue; }
                resources[resourceType] = method;
            }
        }

        // Hack in a few output only types
        if (ArmAssembly == typeof(SubscriptionResource).Assembly)
        {
            Func<string, ArmOperation<SubscriptionResource>> func = _ => throw new NotImplementedException();
            MethodInfo method = func.GetType().GetMethod("Invoke")!;
            resources[typeof(SubscriptionResource)] = method;
        }

        if (ArmAssembly == typeof(TenantResource).Assembly)
        {
            Func<string, ArmOperation<TenantResource>> func = _ => throw new NotImplementedException();
            MethodInfo method = func.GetType().GetMethod("Invoke")!;
            resources[typeof(TenantResource)] = method;
        }

        // Verify no derived types
        foreach (Type derived in ArmAssembly.GetExportedTypes())
        {
            if (derived.BaseType is null) { continue; }
            if (resources.ContainsKey(derived.BaseType))
            {
                throw new InvalidOperationException($"Unexpected derived type {derived.FullName} of {derived.BaseType.FullName}.");
            }
        }

        return resources;
    }

    private static List<Property> FindProperties(Resource resource, MethodInfo creator, bool ignorePropertiesWithoutPath)
    {
        List<Property> properties = [];

        foreach (ParameterInfo parameter in creator.GetParameters())
        {
            if (parameter.ParameterType == typeof(WaitUntil)) { continue; }
            if (parameter.ParameterType == typeof(CancellationToken)) { continue; }
            ContextualException.WithContext(
                $"Analyzing parameter {parameter.ParameterType.Name} {parameter.Name} of creation method {creator.DeclaringType?.Name ?? "????"}::{creator.Name}",
                () =>
                {
                    if (parameter.ParameterType.IsSimpleType() ||
                        parameter.ParameterType.IsEnumLike())
                    {
                        Property simple =
                            new(
                                resource,
                                GetOrCreateModelType(parameter.ParameterType, resource, ignorePropertiesWithoutPath),
                                armMember: null,
                                parameter)
                            {
                                // Method params must be provided
                                IsRequired = true
                            };

                        // A number of names are renamed on create methods to things like `AccountName` instead of
                        // `Name` when used as a parameter vs. a property.  They're always the first parameter.
                        if (properties.Count == 0 &&
                            simple.Name.EndsWith("Name", StringComparison.OrdinalIgnoreCase) &&
                            simple.PropertyType?.Name == "String" &&
                            simple.Path is null)
                        {
                            simple.Name = "Name";
                            simple.Path = ["name"];
                        }

                        properties.Add(simple);
                    }
                    else if (parameter.ParameterType.IsResourceData())
                    {
                        FlattenType(resource, properties, parameter.ParameterType, ignorePropertiesWithoutPath);
                    }
                    else if (parameter.ParameterType.IsModelType())
                    {
                        if (parameter.ParameterType.Name.Contains("Create") &&
                            parameter.ParameterType.Name.EndsWith("Content"))
                        {
                            FlattenType(resource, properties, parameter.ParameterType, ignorePropertiesWithoutPath);
                        }
                        else
                        {
                            // Which model types should be left as objects?
                            properties.Add(new(
                                resource,
                                GetOrCreateModelType(parameter.ParameterType, resource, ignorePropertiesWithoutPath),
                                armMember: null,
                                parameter));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected parameter type!");
                    }
                });
        }

        return properties;
    }

    static void FlattenType(Resource resource, IList<Property> properties, Type type, bool ignorePropertiesWithoutPath, bool parameters = true)
    {
        HashSet<string> required = [];
        if (parameters)
        {
            required = new(type.GetConstructors().SelectMany(c => c.GetParameters()).Select(p => p.Name).Where(n => n != null)!, StringComparer.OrdinalIgnoreCase);
        }
        foreach (PropertyInfo property in type.GetProperties())
        {
            if (property.Name == "ResourceType") { continue; }
            Property? prop = GetProperty(resource, resource, required.Contains(property.Name), property, ignorePropertyWithoutPath: ignorePropertiesWithoutPath);
            if (prop is null)
            {
                continue;
            }
            Property? existing = properties.FirstOrDefault(e => prop.Name == e.Name);
            if (existing is null)
            {
                if (!parameters)
                {
                    // Everything that came from the second pass is an output only
                    prop.IsReadOnly = true;
                }
                properties.Add(prop);
            }
            else
            {
                // Otherwise merge the param and property together
                existing.ArmMember ??= property;
                if (existing.Path is null)
                {
                    string? path = property.GetCustomAttributes().Where(a => a.GetType().Name == "WirePathAttribute").FirstOrDefault()?.ToString();
                    if (path is not null)
                    {
                        existing.Path = path.Split('.');
                    }
                }
            }
        }
    }

    private static Property? GetProperty(Resource resource, TypeModel parent, bool required, PropertyInfo property, bool ignorePropertyWithoutPath)
    {
        Property prop = new(
            parent,
            GetOrCreateModelType(property.PropertyType, resource, ignorePropertyWithoutPath),
            property,
            armParameter: null)
        {
            IsReadOnly = !required && !property.CanWrite,
            IsRequired = required,
            Description = resource.Spec!.DocComments.GetSummary(property)
        };

        // Fish out any path attributes
        var attributes = property.GetCustomAttributes();
        string? path = attributes.Where(a => a.GetType().Name == "WirePathAttribute").FirstOrDefault()?.ToString();

        // Patch up the well known id/systemData property paths
        if (path is null)
        {
            path = (prop.Name, prop.PropertyType?.Name) switch
            {
                ("Name", "String") => "name",
                ("Location", "AzureLocation") => "location",
                ("Id", "ResourceIdentifier") => "id",
                ("SystemData", "SystemData") => "systemData",
                ("Tags", "IDictionary<String,String>") => "tags",
                _ => null
            };
        }

        if (path is not null)
        {
            prop.Path = path.Split('.');
        }
        else if (ignorePropertyWithoutPath)
        {
            // ignore those properties without path
            return null;
        }

        // if the property has `EditorBrowsable` attribute, we should add the same attribute to it as well
        var editorBrowsableAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(EditorBrowsableAttribute));
        if (editorBrowsableAttribute is not null)
        {
            prop.HideLevel = PropertyHideLevel.HideProperty | PropertyHideLevel.HideField;
        }

        // Collections always appear readonly so we should look at whether the
        // value is mutable to determine whether we can set it.
        if (prop.PropertyType is ListModel)
        {
            prop.IsReadOnly = property.PropertyType.GetGenericInterface(typeof(IReadOnlyList<>)) is not null;
        }
        else if (prop.PropertyType is DictionaryModel)
        {
            prop.IsReadOnly = property.PropertyType.GetGenericInterface(typeof(IReadOnlyDictionary<,>)) is not null;
        }

        return prop;
    }

    private static ModelBase GetOrCreateModelType(Type armType, Resource resource, bool ignorePropertiesWithoutPath)
    {
        ModelBase? type = TypeRegistry.Get(armType);
        return
            type is not null ? type :
            armType.IsNullableOf(_ => true) ? GetOrCreateModelType(armType.GetGenericArguments()[0], resource, ignorePropertiesWithoutPath) :
            armType == typeof(byte[]) ? TypeRegistry.Get<BinaryData>()! : // do byte[] before IList<T>
            armType.IsListOf(_ => true) ? new ListModel(GetOrCreateModelType(armType.GetGenericArguments()[0], resource, ignorePropertiesWithoutPath)) :
            armType.IsDictionary() ? new DictionaryModel(GetOrCreateModelType(armType.GetGenericArguments()[1], resource, ignorePropertiesWithoutPath)) :
            armType.IsEnumLike() ? CreateEnum(armType) :
            CreateSimpleModel(armType);

        ModelBase CreateEnum(Type armType)
        {
            // Fail if we're trying to generate a type from a different assembly
            // (unless we're crossing boundaries in the combined base package)
            if (armType.Assembly != resource.Spec!.ArmAssembly &&
                armType.Assembly != typeof(ArmClient).Assembly)
            {
                throw new InvalidOperationException($"Could not find enum {armType.FullName} while building {resource.Spec.Namespace}.");
            }

            EnumModel model = new(armType, armType.Name, resource.Namespace, resource.Spec.DocComments.GetSummary(armType))
            {
                Spec = resource.Spec
            };

            resource.Spec!.ModelNameMapping[model.Name] = model;
            resource.Spec!.ModelArmTypeMapping[model.ArmType!] = model;

            ContextualException.WithContext(
                $"Analyzing enum {model.Name}",
                () =>
                {
                    if (armType.IsEnum)
                    {
                        foreach (FieldInfo field in armType.GetFields())
                        {
                            if (field.IsSpecialName) { continue; }
                            string? summary = resource.Spec.DocComments.GetSummary(field);
                            string? value = summary?.TrimEnd('.');
                            model.AddValue(field.Name, value, summary);
                        }
                    }
                    else
                    {
                        // Get the well known members
                        IEnumerable<PropertyInfo> properties =
                            armType
                            .GetProperties()
                            .Where(p => p.CanRead && !p.CanWrite && p.GetMethod!.IsStatic && p.PropertyType == armType);
                        foreach (PropertyInfo property in properties)
                        {
                            string? value = null;
                            try { value = property.GetValue(null)?.ToString(); }
                            catch (Exception) { }
                            model.AddValue(property.Name, value, resource.Spec.DocComments.GetSummary(property));
                        }
                    }
                });
            return model;
        }

        ModelBase CreateSimpleModel(Type armType)
        {
            // Fail if we're trying to generate a type from a different assembly
            // (unless we're crossing boundaries in the combined base package)
            if (armType.Assembly != resource.Spec!.ArmAssembly &&
                armType.Assembly != typeof(ArmClient).Assembly)
            {
                throw new InvalidOperationException($"Could not find model {armType.FullName} while building {resource.Spec.Namespace}.");
            }

            SimpleModel model = new(
                resource.Spec,
                armType,
                armType.Name,
                resource.Namespace,
                resource.Spec.DocComments.GetSummary(armType));
            resource.Spec.ModelNameMapping[model.Name] = model;
            resource.Spec.ModelArmTypeMapping[model.ArmType!] = model;
            ContextualException.WithContext(
                $"Analyzing simple model {armType.Name}",
                () =>
                {
                    foreach (PropertyInfo property in armType.GetProperties())
                    {
                        var prop = GetProperty(resource, model, required: false, property, ignorePropertyWithoutPath: ignorePropertiesWithoutPath);
                        if (prop is not null)
                        {
                            model.Properties.Add(prop);
                        }
                    }
                });

            // Look for derived types
            foreach (Type derived in armType.Assembly.GetExportedTypes())
            {
                if (derived.BaseType != armType) { continue; }
                if (GetOrCreateModelType(derived, resource, ignorePropertiesWithoutPath) is TypeModel typedModel)
                {
                    // Associate the models
                    typedModel.BaseType = model;

                    // Remove any properties already on the base (we're not
                    // flattening in the reflection code because there are a
                    /// lot of things like Name we don't want to special case.)
                    List<Property> copy = [.. typedModel.Properties];
                    foreach (Property p in copy)
                    {
                        if (model.Properties.Any(baseP => baseP.Name == p.Name))
                        {
                            typedModel.Properties.Remove(p);
                        }
                    }

                    // Figure out if there's a discriminator by invoking MRW
                    // (this is obviously a pretty subpar hack, but works as a
                    // stopgap until we can implement a proper generator plugin)
                    try
                    {
                        object? instance = Activator.CreateInstance(derived);
                        if (instance is not null)
                        {
                            string? bicep =
                                ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("bicep"))
                                .ToString()
                                .TrimStart('{').TrimEnd('}')
                                .Trim()
                                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                .FirstOrDefault();
                            string[]? assignment = bicep?.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                            if (assignment?.Length == 2)
                            {
                                typedModel.DiscriminatorName = assignment[0];
                                typedModel.DiscriminatorValue = assignment[1].Trim('\'');
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // We don't care about anything that goes wrong with
                        // Activator.CreateInstance
                    }
                }
            }

            return model;
        }
    }

    /// <summary>
    /// Resolve resource versions by combining existing versions from generated code
    /// with the api-version extracted from the mgmt library.
    /// Must be called after Customize() so resource names match generated file names.
    /// </summary>
    private void ResolveVersions()
    {
        ContextualException.WithContext(
            $"Resolving versions for {Name}",
            () =>
            {
                foreach (Resource resource in Resources)
                {
                    if (resource.ResourceType is null) { continue; }

                    string? mgmtApiVersion = resource.DefaultResourceVersion;

                    // Read existing versions from the generated provisioning code
                    (List<string> existingVersions, List<string> existingHiddenVersions) = ReadExistingResourceVersions(resource);

                    // Add the mgmt library version to the combined set
                    if (mgmtApiVersion is not null &&
                        !existingVersions.Contains(mgmtApiVersion) &&
                        !existingHiddenVersions.Contains(mgmtApiVersion))
                    {
                        existingVersions.Add(mgmtApiVersion);
                    }

                    // Merge versions added by Customize() via IncludeVersions
                    if (resource.ResourceVersions is not null)
                    {
                        foreach (string v in resource.ResourceVersions)
                        {
                            if (!existingVersions.Contains(v))
                            {
                                existingVersions.Add(v);
                            }
                        }
                    }

                    // Sort versions descending and prefer non-preview releases
                    List<string> orderedVersions = [.. existingVersions.OrderDescending()];
                    List<string> nonPreviewVersions =
                        [.. orderedVersions.Where(v => !v.EndsWith("preview", StringComparison.OrdinalIgnoreCase))];

                    // If there are any GA (non-preview) versions, use them; otherwise keep all (preview-only) versions
                    resource.ResourceVersions = nonPreviewVersions.Count > 0 ? nonPreviewVersions : orderedVersions;

                    // Choose default version: use the latest (first after descending sort) available version
                    string? defaultVersion = resource.ResourceVersions.FirstOrDefault();

                    resource.DefaultResourceVersion = defaultVersion;

                    // Merge existing hidden versions with any added by Customize()
                    if (existingHiddenVersions.Count > 0)
                    {
                        if (resource.HiddenResourceVersions is null)
                        {
                            resource.HiddenResourceVersions = existingHiddenVersions;
                        }
                        else
                        {
                            foreach (string v in existingHiddenVersions)
                            {
                                if (!resource.HiddenResourceVersions.Contains(v))
                                {
                                    resource.HiddenResourceVersions.Add(v);
                                }
                            }
                        }
                    }
                }
            });
    }

    /// <summary>
    /// Extract the default api-version from a CreateOrUpdate method's XML doc comment.
    /// The generated mgmt libraries include a "Default Api Version" item in the
    /// method's summary XML doc list, e.g.:
    /// <code>
    ///   &lt;item&gt;
    ///     &lt;term&gt;Default Api Version&lt;/term&gt;
    ///     &lt;description&gt;2025-06-01&lt;/description&gt;
    ///   &lt;/item&gt;
    /// </code>
    /// </summary>
    private string? ExtractApiVersionFromXmlDoc(MethodInfo method)
    {
        // Use the Specification's existing DocComments reader which has
        // already loaded the XML doc file for the mgmt assembly
        string? summary = DocComments.GetSummary(method);
        if (summary is null) { return null; }

        // The summary text contains the flattened content including
        // "Default Api Version" followed by the version string.
        const string marker = "Default Api Version";
        int idx = summary.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
        if (idx < 0) { return null; }

        // Extract the version after the marker - it follows after some whitespace/punctuation
        string rest = summary[(idx + marker.Length)..].Trim().TrimStart('.').Trim();

        // Match YYYY-MM-DD, optionally followed by hyphenated suffix (e.g., "-preview", "-PREVIEW")
        // The suffix must start with a hyphen to avoid greedily matching into subsequent text.
        Match match = Regex.Match(rest, @"(\d{4}-\d{2}-\d{2}(?:-[a-zA-Z][\w.]*)*)");
        return match.Success ? match.Groups[1].Value.TrimEnd('.') : null;
    }

    /// <summary>
    /// Static cache of file contents indexed by file path.
    /// This ensures that when multiple specs share the same output directory,
    /// version data is preserved even after the directory is cleaned by one spec's Build().
    /// </summary>
    private static readonly Dictionary<string, string[]> s_fileContentCache = [];
    private static readonly HashSet<string> s_cachedDirectories = [];

    /// <summary>
    /// Cache all .cs files in the generation path directory.
    /// Called once per directory to ensure shared directories have all files cached
    /// before any spec cleans the directory.
    /// </summary>
    private void CacheGenerationDirectory()
    {
        string? generationPath = GetGenerationPath();
        if (generationPath is null || s_cachedDirectories.Contains(generationPath)) { return; }
        s_cachedDirectories.Add(generationPath);

        if (!Directory.Exists(generationPath)) { return; }
        foreach (string file in Directory.GetFiles(generationPath, "*.cs"))
        {
            if (!s_fileContentCache.ContainsKey(file))
            {
                s_fileContentCache[file] = File.ReadAllLines(file);
            }
        }
    }

    /// <summary>
    /// Read existing api-versions from the generated provisioning resource file.
    /// Returns separate lists for regular and hidden versions.
    /// Uses a static cache to handle shared output directories across specs.
    /// </summary>
    private (List<string> versions, List<string> hiddenVersions) ReadExistingResourceVersions(Resource resource)
    {
        List<string> versions = [];
        List<string> hiddenVersions = [];

        string? generationPath = GetGenerationPath();
        if (generationPath is null) { return (versions, hiddenVersions); }

        string filePath = Path.Combine(generationPath, $"{resource.Name}.cs");

        // Use cached file contents
        if (!s_fileContentCache.TryGetValue(filePath, out string[]? lines))
        {
            return (versions, hiddenVersions);
        }

        // Find the ResourceVersions class block
        bool inResourceVersions = false;
        int braceDepth = 0;
        bool nextVersionIsHidden = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            if (!inResourceVersions)
            {
                if (line.Contains("class ResourceVersions"))
                {
                    inResourceVersions = true;
                    braceDepth = 0;
                }
                continue;
            }

            // Track brace depth
            foreach (char c in line)
            {
                if (c == '{') braceDepth++;
                else if (c == '}') braceDepth--;
            }

            if (braceDepth <= 0 && line.Contains('}'))
            {
                break; // End of ResourceVersions class
            }

            // Check for EditorBrowsable attribute
            if (line.Contains("[EditorBrowsable(EditorBrowsableState.Never)]"))
            {
                nextVersionIsHidden = true;
                continue;
            }

            // Match version field declarations
            Match match = Regex.Match(line, @"public static readonly string \w+ = ""([^""]+)"";");
            if (match.Success)
            {
                string version = match.Groups[1].Value;
                if (nextVersionIsHidden)
                {
                    hiddenVersions.Add(version);
                }
                else
                {
                    versions.Add(version);
                }
                nextVersionIsHidden = false;
            }
            else if (!line.StartsWith("///") && !string.IsNullOrEmpty(line) && !line.StartsWith("{"))
            {
                // Reset hidden flag if we hit a non-comment, non-version line
                nextVersionIsHidden = false;
            }
        }

        return (versions, hiddenVersions);
    }
}