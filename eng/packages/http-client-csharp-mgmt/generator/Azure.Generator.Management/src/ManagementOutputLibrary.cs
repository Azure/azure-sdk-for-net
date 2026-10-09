// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementOutputLibrary : AzureOutputLibrary
    {
        private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider ArmOperationOfT => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        private PageableWrapperProvider? _pageableWrapper;
        internal PageableWrapperProvider PageableWrapper => _pageableWrapper ??= new PageableWrapperProvider(false);

        private PageableWrapperProvider? _asyncPageableWrapper;
        internal PageableWrapperProvider AsyncPageableWrapper => _asyncPageableWrapper ??= new PageableWrapperProvider(true);

        private ProviderConstantsProvider? _providerConstants;
        internal ProviderConstantsProvider ProviderConstants => _providerConstants ??= new ProviderConstantsProvider();

        private WirePathAttributeDefinition? _wirePathAttributeProvider;
        internal TypeProvider WirePathAttributeDefinition => _wirePathAttributeProvider ??= new WirePathAttributeDefinition();

        private CodeGenResourceDataAttributeDefinition? _codeGenResourceDataAttributeProvider;
        internal CustomCodeAttributeDefinition CodeGenResourceDataAttributeDefinition => _codeGenResourceDataAttributeProvider ??= new CodeGenResourceDataAttributeDefinition();

        private CodeGenTagPatchHookAttributeDefinition? _codeGenTagPatchHookAttributeProvider;
        internal CustomCodeAttributeDefinition CodeGenTagPatchHookAttributeDefinition => _codeGenTagPatchHookAttributeProvider ??= new CodeGenTagPatchHookAttributeDefinition();

        private CSharpType? _modelReaderWriterContextType;
        internal CSharpType ModelReaderWriterContextType => _modelReaderWriterContextType ??= new ModelReaderWriterContextDefinition().Type;

        private IReadOnlyDictionary<RequestPathPattern, ResourceClientProvider>? _resourcesByIdDict;
        private IReadOnlyList<ResourceClientProvider>? _resources;
        private IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections;
        private IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableResourcesByScopeDict;
        private IReadOnlyList<MockableResourceProvider>? _mockableResources;
        private ExtensionProvider? _extensionProvider;

        private IReadOnlyDictionary<CSharpType, OperationSourceProvider>? _operationSourceDict;
        private readonly HashSet<string> _collectionResultNames = new(StringComparer.Ordinal);
        private readonly Dictionary<(ClientProvider Client, InputOperation Operation, bool HasItemType, bool IsAsync), string> _regularCollectionResultNames = new();
        private readonly Dictionary<TypeProvider, string> _regularCollectionResultProviderNames = new();
        private HashSet<string>? _customReferencedCollectionResults;
        private readonly Dictionary<string, List<(IReadOnlySet<string>? Namespaces, string? OriginalName)>> _preservedCollectionResultNames = new(StringComparer.Ordinal);
        private HashSet<(string Namespace, string Name)>? _originalCollectionResultNames;
        private Dictionary<(TypeProvider EnclosingType, InputServiceMethod Method, bool IsAsync), string>? _originalArrayCollectionResultNames;

        internal IReadOnlyDictionary<CSharpType, OperationSourceProvider> OperationSourceDict => _operationSourceDict ??= BuildOperationSources();

        // Keep collection-result names compact, adding a numeric suffix only when two methods
        // would otherwise produce the same helper type name.
        internal string GetUniqueCollectionResultName(string baseName) =>
            AllocateCollectionResultName(baseName, null, null, "CollectionResultOfT");

        internal string GetArrayCollectionResultName(string baseName, string @namespace, TypeProvider enclosingType, InputServiceMethod method, bool isAsync)
        {
            _ = OriginalCollectionResultNames;
            var originalName = _originalArrayCollectionResultNames!.TryGetValue((enclosingType, method, isAsync), out var name)
                ? name
                : $"{baseName}CollectionResultOfT";
            return AllocateCollectionResultName(baseName, @namespace, _ => originalName, "CollectionResultOfT");
        }

        private string AllocateCollectionResultName(string baseName, string? @namespace, Func<string, string>? originalName, string suffix)
        {
            ReservePreservedCollectionResultNames();
            var candidate = baseName;
            var number = 0;
            while (_collectionResultNames.Contains(candidate) || !CanClaimPreservedName($"{candidate}{suffix}", @namespace, originalName?.Invoke(candidate)))
            {
                candidate = $"{baseName}{number++}";
            }

            _collectionResultNames.Add(candidate);
            return candidate;
        }

        private bool CanClaimPreservedName(string name, string? @namespace, string? originalName)
        {
            // Do not first emit a compact identity owned by another operation. Otherwise adding a
            // reference or partial on the next run transfers that same name to its original owner.
            if (originalName is not null && @namespace is not null && name != originalName &&
                OriginalCollectionResultNames.Contains((@namespace, name)))
            {
                return false;
            }

            if (!_preservedCollectionResultNames.TryGetValue(name, out var owners))
            {
                return true;
            }

            foreach (var owner in owners)
            {
                if (originalName is null || @namespace is null)
                {
                    return false;
                }

                if (owner.Namespaces is not null && !owner.Namespaces.Contains(@namespace))
                {
                    // Ordinary handwritten types are namespace-local. Mapped aliases can become
                    // generated files and still reserve their globally shared output identity.
                    if (owner.OriginalName is not null)
                    {
                        return false;
                    }
                    continue;
                }

                if (owner.OriginalName is not null)
                {
                    if (owner.OriginalName != originalName &&
                        (owner.OriginalName != name || OriginalCollectionResultNames.Any(identity => identity.Name == owner.OriginalName &&
                            (owner.Namespaces is null || owner.Namespaces.Contains(identity.Namespace)))))
                    {
                        // A mapping of an upstream operation name belongs only to that operation.
                        // A mapping of a previously emitted compact identity belongs to the helper
                        // whose next allocation reproduces that identity.
                        return false;
                    }
                }
                else if (name != originalName && OriginalCollectionResultNames.Any(identity => identity.Name == name &&
                    owner.Namespaces!.Contains(identity.Namespace)))
                {
                    // An operation-based identity belongs to that operation, not to another helper
                    // whose compact item-based name happens to match it.
                    return false;
                }
            }

            return true;
        }

        private HashSet<(string Namespace, string Name)> OriginalCollectionResultNames
        {
            get
            {
                if (_originalCollectionResultNames is not null)
                {
                    return _originalCollectionResultNames;
                }

                var names = new HashSet<(string Namespace, string Name)>();
                var clients = new Queue<InputClient>(ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Clients);
                var visited = new HashSet<InputClient>();
                while (clients.TryDequeue(out var inputClient))
                {
                    if (!visited.Add(inputClient))
                    {
                        continue;
                    }
                    foreach (var child in inputClient.Children)
                    {
                        clients.Enqueue(child);
                    }
                    var client = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
                    if (client is null)
                    {
                        continue;
                    }
                    foreach (var method in inputClient.Methods.Where(method => method is InputPagingServiceMethod or InputLongRunningPagingServiceMethod))
                    {
                        foreach (var operationName in new[] { method.Operation.Name, method.Operation.OriginalName }.OfType<string>())
                        {
                            var prefix = $"{client.Name}{operationName.ToIdentifierName()}";
                            foreach (var suffix in new[] { "CollectionResult", "CollectionResultOfT", "AsyncCollectionResult", "AsyncCollectionResultOfT" })
                            {
                                names.Add((client.Type.Namespace, $"{prefix}{suffix}"));
                            }
                        }
                    }
                }
                // Provider shells contain the actual ARM method placements. Resolve only eligible
                // array operations, never ARM method bodies or all methods on a paging REST client.
                var plans = ResourceProviders.SelectMany(provider => provider.ArrayCollectionResultPlans)
                    .Concat(ResourceCollectionProviders.SelectMany(provider => provider.ArrayCollectionResultPlans))
                    .Concat(MockableResourceProviders.SelectMany(provider => provider.ArrayCollectionResultPlans))
                    .ToArray();
                // Replay the old array-only allocator without touching the active helper names.
                // Numbered identities belong to the particular method that originally allocated them.
                var allocatedArrayNames = new HashSet<string>(StringComparer.Ordinal);
                var arrayNames = new Dictionary<(TypeProvider EnclosingType, InputServiceMethod Method, bool IsAsync), string>();
                foreach (var plan in plans)
                {
                    var originalNames = plan.GetOriginalNames().ToArray();
                    // Resource and action methods build async first; collection GetAll builds sync first.
                    foreach (var isAsync in plan.SyncFirst ? new[] { false, true } : new[] { true, false })
                    {
                        var baseName = originalNames[isAsync ? 1 : 0][..^"CollectionResultOfT".Length];
                        var candidate = baseName;
                        var number = 0;
                        while (!allocatedArrayNames.Add(candidate))
                        {
                            candidate = $"{baseName}{number++}";
                        }
                        var name = $"{candidate}CollectionResultOfT";
                        names.Add((ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace, name));
                        arrayNames.Add((plan.EnclosingType, plan.Method, isAsync), name);
                    }
                }
                // Publish only the completed inventory; recursive reads must not see a partial set.
                _originalArrayCollectionResultNames = arrayNames;
                return _originalCollectionResultNames = names;
            }
        }

        internal string GetRegularCollectionResultName(ClientProvider client, InputOperation operation, CSharpType? itemType, bool isAsync, string originalName, string? customizedName = null)
        {
            var key = (client, operation, itemType is not null, isAsync);
            if (!_regularCollectionResultNames.TryGetValue(key, out var name))
            {
                // Item names avoid repeating long REST client and operation names. A helper may be rebuilt
                // for different back-compat providers, so reserve a name once per operation and result shape.
                var suffix = $"CollectionResult{(itemType is null ? "" : "OfT")}";
                if (customizedName is not null)
                {
                    name = customizedName;
                    var preservedSuffix = name.EndsWith("CollectionResultOfT", StringComparison.Ordinal) ? "CollectionResultOfT" : "CollectionResult";
                    if (name.EndsWith(preservedSuffix, StringComparison.Ordinal))
                    {
                        _collectionResultNames.Add(name[..^preservedSuffix.Length]);
                    }
                }
                else
                {
                    var baseName = $"{itemType?.Name ?? nameof(BinaryData)}{(isAsync ? "Async" : "")}";
                    name = $"{AllocateCollectionResultName(baseName, client.Type.Namespace, _ => originalName, suffix)}{suffix}";
                }
                _regularCollectionResultNames.Add(key, name);
            }

            return name;
        }

        internal bool IsCollectionResultReferencedByCustomization(TypeProvider helper)
        {
            // Existing hand-written code may construct a generated helper without declaring a partial
            // customization. Keep those identities too, rather than breaking package customizations.
            ReservePreservedCollectionResultNames();
            return _customReferencedCollectionResults!.Contains(helper.Name) &&
                _preservedCollectionResultNames[helper.Name].Any(owner =>
                    (owner.Namespaces is null || owner.Namespaces.Contains(helper.Type.Namespace)) &&
                    (owner.OriginalName is null || owner.OriginalName == helper.Name));
        }

        private void ReservePreservedCollectionResultNames()
        {
            if (_customReferencedCollectionResults is not null)
            {
                return;
            }

            _customReferencedCollectionResults = new HashSet<string>(StringComparer.Ordinal);
            var customization = ManagementClientGenerator.Instance.SourceInputModel.Customization;
            if (customization is null)
            {
                return;
            }

            // Reserve the whole customization inventory before either regular or array helpers allocate
            // a compact name. Otherwise an earlier operation can claim a later preserved identity and
            // even bind that operation's partial customization when its provider is renamed.
            foreach (var tree in customization.SyntaxTrees)
            {
                var model = customization.GetSemanticModel(tree);
                foreach (var node in tree.GetRoot().DescendantNodes())
                {
                    if (node is TypeDeclarationSyntax declaration && model.GetDeclaredSymbol(declaration) is INamedTypeSymbol type)
                    {
                        var originalName = GetCodeGenTypeOriginalName(type);
                        var @namespace = type.ContainingNamespace.ToDisplayString();
                        // Upstream resolves CodeGenType lookup keys independently of the alias namespace.
                        // A same-name mapping can also move the type to another namespace.
                        ReserveCollectionResultName(type.Name, type.Name == originalName ? null : @namespace, originalName);
                        if (originalName is not null && originalName != type.Name)
                        {
                            ReserveCollectionResultName(originalName, null, originalName);
                        }
                    }
                    else if (node is IdentifierNameSyntax identifier && IsCollectionResultName(identifier.Identifier.ValueText))
                    {
                        var referencedType = model.GetSymbolInfo(identifier).Symbol as INamedTypeSymbol;
                        var originalName = referencedType is { TypeKind: not TypeKind.Error } ? GetCodeGenTypeOriginalName(referencedType) : null;
                        // A reference to a mapped partial shares the declaration's lookup-key ownership.
                        // Its destination namespace must not restrict a same-name namespace move.
                        var namespaces = originalName == identifier.Identifier.ValueText ? null : GetReferenceNamespaces(identifier, model, customization);
                        if (ReserveCollectionResultName(identifier.Identifier.ValueText, null, originalName, namespaces))
                        {
                            _customReferencedCollectionResults.Add(identifier.Identifier.ValueText);
                        }
                    }
                }
            }
        }

        private static bool IsCollectionResultName(string name) =>
            name.EndsWith("CollectionResultOfT", StringComparison.Ordinal) || name.EndsWith("CollectionResult", StringComparison.Ordinal);

        private static string? GetCodeGenTypeOriginalName(INamedTypeSymbol type)
        {
            foreach (var attribute in type.GetAttributes())
            {
                for (var attributeType = attribute.AttributeClass; attributeType is not null; attributeType = attributeType.BaseType)
                {
                    if (attributeType.Name == "CodeGenTypeAttribute" && attribute.ConstructorArguments.Length > 0)
                    {
                        return attribute.ConstructorArguments[0].Value as string;
                    }
                }
            }
            return null;
        }

        private static IReadOnlySet<string> GetReferenceNamespaces(IdentifierNameSyntax identifier, SemanticModel model, Compilation customization)
        {
            var referencedType = model.GetSymbolInfo(identifier).Symbol as INamedTypeSymbol;
            if (referencedType is { TypeKind: not TypeKind.Error })
            {
                return new HashSet<string>(StringComparer.Ordinal) { referencedType.ContainingNamespace.ToDisplayString() };
            }

            SyntaxNode? qualifier = identifier.Parent switch
            {
                QualifiedNameSyntax qualified when qualified.Right == identifier => qualified.Left,
                AliasQualifiedNameSyntax aliased when aliased.Name == identifier => aliased.Alias,
                MemberAccessExpressionSyntax member when member.Name == identifier => member.Expression,
                _ => null
            };
            var parts = qualifier?.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().Select(part => part.Identifier.ValueText).ToArray() ?? [];
            var explicitAlias = identifier.Parent is AliasQualifiedNameSyntax ||
                qualifier?.DescendantNodesAndSelf().OfType<AliasQualifiedNameSyntax>().Any() == true;
            if (qualifier is not null)
            {
                var qualifiedNamespace = model.GetSymbolInfo(qualifier).Symbol as INamespaceSymbol;
                if (qualifiedNamespace is not null)
                {
                    return new HashSet<string>(StringComparer.Ordinal) { qualifiedNamespace.ToDisplayString() };
                }
                if (explicitAlias && parts[0] == "global")
                {
                    return new HashSet<string>(StringComparer.Ordinal) { string.Join(".", parts.Skip(1)) };
                }
            }

            // Missing generated types cannot bind semantically. Keep the legal lexical scopes as
            // alternatives, and resolve each import at its declaration, not at the reference site.
            var namespaces = GetEnclosingNamespaces(identifier, model).ToHashSet(StringComparer.Ordinal);
            IReadOnlySet<string>? aliasTargets = null;
            foreach (var scope in identifier.Ancestors())
            {
                var usings = scope switch
                {
                    BaseNamespaceDeclarationSyntax declaration => declaration.Usings,
                    CompilationUnitSyntax unit => unit.Usings,
                    _ => default
                };
                foreach (var directive in usings)
                {
                    AddImport(directive, model);
                }
            }
            foreach (var tree in customization.SyntaxTrees)
            {
                foreach (var directive in tree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>().Where(directive => directive.GlobalKeyword.RawKind != 0))
                {
                    AddImport(directive, customization.GetSemanticModel(tree));
                }
            }
            if (qualifier is not null)
            {
                if (aliasTargets is not null)
                {
                    var tail = string.Join(".", parts.Skip(1));
                    return aliasTargets.Select(target => tail.Length == 0 ? target : $"{target}.{tail}").ToHashSet(StringComparer.Ordinal);
                }
                if (explicitAlias)
                {
                    // An unbound extern alias is not a namespace in this generated assembly.
                    return new HashSet<string>(StringComparer.Ordinal);
                }
                var qualifiedName = string.Join(".", parts);
                return namespaces.Select(scope => scope.Length == 0 ? qualifiedName : $"{scope}.{qualifiedName}").ToHashSet(StringComparer.Ordinal);
            }
            return namespaces;

            void AddImport(UsingDirectiveSyntax directive, SemanticModel semanticModel)
            {
                if (directive.Name is null || directive.StaticKeyword.RawKind != 0)
                {
                    return;
                }
                var targets = GetImportNamespaces(directive, semanticModel);
                if (directive.Alias is null)
                {
                    namespaces.UnionWith(targets);
                }
                else if (aliasTargets is null && parts.Length > 0 && directive.Alias.Name.Identifier.ValueText == parts[0])
                {
                    aliasTargets = targets;
                }
            }
        }

        private static IEnumerable<string> GetEnclosingNamespaces(SyntaxNode node, SemanticModel model)
        {
            var declaration = node.AncestorsAndSelf().OfType<BaseNamespaceDeclarationSyntax>().FirstOrDefault();
            var symbol = declaration is null ? null : model.GetDeclaredSymbol(declaration) as INamespaceSymbol;
            for (; symbol is not null && !symbol.IsGlobalNamespace; symbol = symbol.ContainingNamespace)
            {
                yield return symbol.ToDisplayString();
            }
            yield return "";
        }

        private static IReadOnlySet<string> GetImportNamespaces(UsingDirectiveSyntax directive, SemanticModel model)
        {
            if (model.GetSymbolInfo(directive.Name!).Symbol is INamespaceSymbol importedNamespace)
            {
                return new HashSet<string>(StringComparer.Ordinal) { importedNamespace.ToDisplayString() };
            }
            var parts = directive.Name!.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().Select(part => part.Identifier.ValueText).ToArray();
            if (directive.Name.DescendantNodesAndSelf().OfType<AliasQualifiedNameSyntax>().Any() && parts[0] == "global")
            {
                return new HashSet<string>(StringComparer.Ordinal) { string.Join(".", parts.Skip(1)) };
            }
            var importName = string.Join(".", parts);
            return GetEnclosingNamespaces(directive, model)
                .Select(scope => scope.Length == 0 ? importName : $"{scope}.{importName}")
                .ToHashSet(StringComparer.Ordinal);
        }

        private bool ReserveCollectionResultName(string name, string? @namespace, string? originalName, IReadOnlySet<string>? referenceNamespaces = null)
        {
            if (!IsCollectionResultName(name))
            {
                return false;
            }

            if (!_preservedCollectionResultNames.TryGetValue(name, out var owners))
            {
                owners = new();
                _preservedCollectionResultNames.Add(name, owners);
            }
            owners.Add((referenceNamespaces ?? (@namespace is null ? null : new HashSet<string>(StringComparer.Ordinal) { @namespace }), originalName));
            return true;
        }

        internal void RegisterRegularCollectionResultName(TypeProvider helper, string name)
        {
            _regularCollectionResultProviderNames.Add(helper, name);
            ApplyRegularCollectionResultName(helper);
        }

        internal void ApplyRegularCollectionResultName(TypeProvider helper)
        {
            if (_regularCollectionResultProviderNames.TryGetValue(helper, out var name))
            {
                // Upstream visitors reset collection-result providers. Restore the allocated identity
                // before the management visitors and reference analysis consume the rebuilt provider.
                var oldName = helper.Name;
                helper.Update(name: name);
                var resolvedName = helper.Name;
                helper.Update(relativeFilePath: Path.Combine("src", "Generated", "CollectionResults", $"{resolvedName}.cs"));
                if (oldName != resolvedName)
                {
                    foreach (var method in helper.Methods)
                    {
                        RenameHelperInDocs(method.XmlDocs.Summary, oldName, resolvedName);
                        RenameHelperInDocs(method.XmlDocs.Returns, oldName, resolvedName);
                    }
                }
            }
        }

        private static void RenameHelperInDocs(XmlDocStatement? docs, string oldName, string name)
        {
            if (docs is null)
            {
                return;
            }

            foreach (var line in docs.Lines)
            {
                var arguments = line.GetArguments();
                for (var i = 0; i < arguments.Length; i++)
                {
                    if (arguments[i] is string text)
                    {
                        arguments[i] = text.Replace(oldName, name, StringComparison.Ordinal);
                    }
                }
            }
        }

        internal OperationSourceProvider GetOperationSource(ResourceClientProvider resource)
        {
            var operationSources = OperationSourceDict;
            if (!operationSources.TryGetValue(resource.Type, out var operationSource))
            {
                operationSource = new OperationSourceProvider(resource);
                if (operationSources is Dictionary<CSharpType, OperationSourceProvider> mutableOperationSources)
                {
                    mutableOperationSources.Add(resource.Type, operationSource);
                }
            }

            return operationSource;
        }

        internal IReadOnlyList<ResourceClientProvider> ResourceProviders => GetValue(ref _resources);
        internal IReadOnlyList<ResourceCollectionClientProvider> ResourceCollectionProviders => GetValue(ref _resourceCollections);
        internal IReadOnlyList<MockableResourceProvider> MockableResourceProviders => GetValue(ref _mockableResources);
        internal ExtensionProvider ExtensionProvider => GetValue(ref _extensionProvider);

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal ResourceClientProvider GetResourceById(RequestPathPattern id) => GetValue(ref _resourcesByIdDict)[id];

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal MockableResourceProvider GetMockableResourceByScope(ResourceScope scope) => GetValue(ref _mockableResourcesByScopeDict)[scope];

        private IReadOnlyDictionary<ModelProvider, HashSet<PropertyProvider>>? _outputFlattenPropertyMap;
        internal IReadOnlyDictionary<ModelProvider, HashSet<PropertyProvider>> OutputFlattenPropertyMap => _outputFlattenPropertyMap ??= BuildOutputFlattenPropertyMap();
        private IReadOnlyDictionary<ModelProvider, HashSet<PropertyProvider>> BuildOutputFlattenPropertyMap()
        {
            Dictionary<ModelProvider, HashSet<PropertyProvider>> result = [];
            foreach (var (inputModel, flattenedProperties) in ManagementClientGenerator.Instance.InputLibrary.FlattenPropertyMap)
            {
                foreach (var model in ResolveFlattenTargetModels(inputModel))
                {
                    result[model] = flattenedProperties
                        .Select(p => ManagementClientGenerator.Instance.TypeFactory.CreateProperty(p, model)!)
                        .ToHashSet();
                }
            }
            return result;
        }

        /// <summary>
        /// Resolves output model providers that should receive flattenProperty customizations for an input model.
        /// </summary>
        /// <param name="inputModel">The input model that owns the decorated flattened properties.</param>
        /// <returns>The output model providers that represent the input model.</returns>
        protected virtual IReadOnlyList<ModelProvider> ResolveFlattenTargetModels(InputModelType inputModel)
        {
            var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
            return model is null ? [] : [model];
        }

        private HashSet<ModelProvider>? _safeFlattenDisabledModels;
        /// <summary>
        /// Set of model providers for which safe-flatten should be disabled, derived from the
        /// <c>@@clientOption(Model, "disable-safe-flatten", true, "csharp")</c> decorator on the input model.
        /// </summary>
        internal HashSet<ModelProvider> SafeFlattenDisabledModels => _safeFlattenDisabledModels ??= BuildSafeFlattenDisabledModels();

        private HashSet<ModelProvider> BuildSafeFlattenDisabledModels()
        {
            var result = new HashSet<ModelProvider>();
            foreach (var inputModel in ManagementClientGenerator.Instance.InputLibrary.SafeFlattenDisabledModels)
            {
                var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model != null)
                {
                    result.Add(model);
                }
            }
            return result;
        }

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResourceClients(
                ref _resourcesByIdDict,
                ref _resources,
                ref _resourceCollections,
                ref _mockableResourcesByScopeDict,
                ref _mockableResources,
                ref _extensionProvider);

            return field!;
        }

        /// <summary>
        /// This method initializes the resource clients, collections, and mockable clients.
        /// We do all of these in the same method to ensure they are initialized together
        /// </summary>
        /// <param name="_resourcesByIdDict">Represent a map from resource id pattern to the <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_resources">The full list of <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_resourceCollections">The full list of <see cref="ResourceCollectionClientProvider"/>. </param>
        /// <param name="_mockableResourcesByScopeDict">Represent a dictionary from scope to the corresponding <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_mockableResources">The full list of <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_extensionProvider">The <see cref="T:ExtensionProvider"/>. </param>
        private static void InitializeResourceClients(
            ref IReadOnlyDictionary<RequestPathPattern, ResourceClientProvider>? _resourcesByIdDict,
            ref IReadOnlyList<ResourceClientProvider>? _resources,
            ref IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections,
            ref IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableResourcesByScopeDict,
            ref IReadOnlyList<MockableResourceProvider>? _mockableResources,
            ref ExtensionProvider? _extensionProvider)
        {
            if (_resourcesByIdDict is not null ||
                _resources is not null ||
                _resourceCollections is not null ||
                _mockableResourcesByScopeDict is not null ||
                _mockableResources is not null ||
                _extensionProvider is not null)
            {
                return; // already initialized
            }

            var resourceMetadatas = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas;
            var resourceMethodCategories = new Dictionary<ArmResourceMetadata, ResourceMethodCategory>(resourceMetadatas.Count);

            // build resource methods per resource metadata
            var resourceDict = new Dictionary<ArmResourceMetadata, ResourceClientProvider>(resourceMetadatas.Count);
            var collections = new List<ResourceCollectionClientProvider>(resourceMetadatas.Count);
            foreach (var resourceMetadata in resourceMetadatas)
            {
                // categorize the resource methods
                var categorizedMethods = resourceMetadata.CategorizeMethods();
                // stores it because later in extensions we need it again
                resourceMethodCategories.Add(resourceMetadata, categorizedMethods);
                var resource = ResourceClientProvider.Create(resourceMetadata, categorizedMethods.MethodsInResource, categorizedMethods.MethodsInCollection);
                resourceDict.Add(resourceMetadata, resource);
                if (resource.ResourceCollection is not null)
                {
                    collections.Add(resource.ResourceCollection);
                }
            }

            // resources and collections are now initialized
            _resourcesByIdDict = resourceDict.ToDictionary(kv => kv.Key.ResourceIdPattern, kv => kv.Value);
            _resources = [.. resourceDict.Values];
            _resourceCollections = collections;

            // build mockable resources
            var resourcesAndMethodsPerScope = BuildResourcesAndNonResourceMethods(
                resourceDict,
                resourceMethodCategories,
                ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods);

            // Extract extension methods for MockableArmClientProvider
            var extensionScope = resourcesAndMethodsPerScope[ResourceScope.Extension];

            var mockableArmClientResource = MockableArmClientProvider.TryCreate(_resources, extensionScope.ResourceMethods, extensionScope.NonResourceMethods);
            var mockableResources = new Dictionary<ResourceScope, MockableResourceProvider>(resourcesAndMethodsPerScope.Count);
            foreach (var (scope, (resourcesInScope, resourceMethods, nonResourceMethods)) in resourcesAndMethodsPerScope)
            {
                if (scope != ResourceScope.Extension)
                {
                    var mockableExtension = MockableResourceProvider.TryCreate(scope, resourcesInScope, resourceMethods, nonResourceMethods);
                    if (mockableExtension != null)
                    {
                        mockableResources.Add(scope, mockableExtension);
                    }
                }
            }

            _mockableResourcesByScopeDict = mockableResources;
            var allMockableResources = new List<MockableResourceProvider>();
            if (mockableArmClientResource != null)
            {
                allMockableResources.Add(mockableArmClientResource);
            }
            allMockableResources.AddRange(mockableResources.Values);
            _mockableResources = allMockableResources;
            _extensionProvider = new ExtensionProvider(_mockableResources);

            static Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope> BuildResourcesAndNonResourceMethods(
                IReadOnlyDictionary<ArmResourceMetadata, ResourceClientProvider> resourceDict,
                IReadOnlyDictionary<ArmResourceMetadata, ResourceMethodCategory> resourceMethods,
                IEnumerable<NonResourceMethod> nonResourceMethods)
            {
                // walk through all resources to figure out their scopes
                var resourcesAndMethodsPerScope = new Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope>
                {
                    [ResourceScope.ResourceGroup] = new([], [], []),
                    [ResourceScope.Subscription] = new([], [], []),
                    [ResourceScope.Tenant] = new([], [], []),
                    [ResourceScope.ManagementGroup] = new([], [], []),
                    [ResourceScope.Extension] = new([], [], [])
                };
                foreach (var (metadata, resourceClient) in resourceDict)
                {
                    if (metadata.ParentResourceId is null)
                    {
                        resourcesAndMethodsPerScope[metadata.Scope.Kind].ResourceClients.Add(resourceClient);
                    }
                }
                foreach (var (metadata, category) in resourceMethods)
                {
                    // find the resource
                    var resource = resourceDict[metadata];
                    // the resource methods
                    foreach (var resourceMethod in category.MethodsInExtension)
                    {
                        var resourcesAndMethodsInThisScope = resourcesAndMethodsPerScope[resourceMethod.Scope.Kind];
                        if (!resourcesAndMethodsInThisScope.ResourceMethods.TryGetValue(resource, out var methods))
                        {
                            methods = new List<ResourceMethod>();
                            resourcesAndMethodsInThisScope.ResourceMethods[resource] = methods;
                        }
                        // add this method into the list
                        ((List<ResourceMethod>)methods).Add(resourceMethod);
                    }
                }
                foreach (var nonResourceMethod in nonResourceMethods)
                {
                    resourcesAndMethodsPerScope[nonResourceMethod.Scope.Kind].NonResourceMethods.Add(nonResourceMethod);
                }
                return resourcesAndMethodsPerScope;
            }
        }

        // TODO: replace this with CSharpType to TypeProvider mapping.
        private HashSet<CSharpType>? _allModelTypes;

        private HashSet<CSharpType> AllModelTypes
        {
            get
            {
                BuildModelTypes();
                return _allModelTypes!;
            }
        }

        private void BuildModelTypes()
        {
            if (_allModelTypes is not null)
            {
                return; // already built
            }

            var allModelTypes = new HashSet<CSharpType>();

            foreach (var inputModel in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models)
            {
                var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null)
                {
                    var eraseNullableType = model.Type.WithNullable(false);
                    allModelTypes.Add(eraseNullableType);
                }
            }

            _allModelTypes = allModelTypes;
        }

        internal bool IsModelType(CSharpType type) => AllModelTypes.Contains(type.WithNullable(false));

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // we need to add the clients (including resources, collections, mockable resources and extension static class)
            // to the types to keep
            // otherwise, they will be trimmed off or internalized by the post processor
            foreach (var resource in ResourceProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
            }
            foreach (var collection in ResourceCollectionProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(collection.Name);
            }
            foreach (var mockableResource in MockableResourceProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(mockableResource.Name);
            }
            ManagementClientGenerator.Instance.AddTypeToKeep(ExtensionProvider.Name);

            // Extract array response collection results from all methods
            var arrayResponseCollectionResults = ExtractArrayResponseCollectionResults();

            return [
                .. base.BuildTypeProviders().Where(t => t is not SystemObjectModelProvider),
                WirePathAttributeDefinition,
                ArmOperation,
                ArmOperationOfT,
                .. OperationSourceDict.Values,
                ProviderConstants,
                .. ResourceProviders,
                .. ResourceCollectionProviders,
                .. MockableResourceProviders,
                ExtensionProvider,
                PageableWrapper,
                AsyncPageableWrapper,
                .. arrayResponseCollectionResults,
                .. ResourceProviders.SelectMany(r => r.SerializationProviders)];
        }

        private List<ArrayResponseCollectionResultDefinition> ExtractArrayResponseCollectionResults()
        {
            var collectionResults = new List<ArrayResponseCollectionResultDefinition>();

            // Check all resource providers
            foreach (var resource in ResourceProviders)
            {
                ExtractCollectionResultsFromMethods(resource.Methods, collectionResults);
            }

            // Check all resource collection providers
            foreach (var collection in ResourceCollectionProviders)
            {
                ExtractCollectionResultsFromMethods(collection.Methods, collectionResults);
            }

            // Check all mockable resource providers
            foreach (var mockableResource in MockableResourceProviders)
            {
                ExtractCollectionResultsFromMethods(mockableResource.Methods, collectionResults);
            }

            return collectionResults;
        }

        private void ExtractCollectionResultsFromMethods(IReadOnlyList<MethodProvider> methods, List<ArrayResponseCollectionResultDefinition> collectionResults)
        {
            foreach (var method in methods)
            {
                // Check if this is an ScmMethodProvider with an ArrayResponseCollectionResultDefinition
                if (method is ScmMethodProvider { CollectionDefinition: ArrayResponseCollectionResultDefinition arrayCollectionResult })
                {
                    collectionResults.Add(arrayCollectionResult);
                }
            }
        }

        private Dictionary<CSharpType, OperationSourceProvider> BuildOperationSources()
        {
            var operationSources = new Dictionary<CSharpType, OperationSourceProvider>();

            // Process resource methods
            foreach (var metadata in ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas)
            {
                foreach (var resourceMethod in metadata.Methods)
                {
                    ProcessLroMethod(resourceMethod.InputMethod, operationSources);
                }
            }

            // Process non-resource methods
            foreach (var nonResourceMethod in ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods)
            {
                ProcessLroMethod(nonResourceMethod.InputMethod, operationSources);
            }

            return operationSources;
        }

        private void ProcessLroMethod(InputServiceMethod inputMethod, Dictionary<CSharpType, OperationSourceProvider> operationSources)
        {
            var lroMetadata = inputMethod switch
            {
                InputLongRunningServiceMethod lroMethod => lroMethod.LongRunningServiceMetadata,
                InputLongRunningPagingServiceMethod lroPagingMethod => lroPagingMethod.LongRunningServiceMetadata,
                _ => null
            };

            var returnType = lroMetadata?.ReturnType;
            if (returnType == null)
            {
                return;
            }

            var returnCSharpType = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(returnType);
            if (returnCSharpType == null)
            {
                return;
            }

            // Find all resource providers that use this data type.
            var resourceProviders = ResourceProviders.Where(r => r.ResourceData.Type.Equals(returnCSharpType)).ToList();
            foreach (var resourceProvider in resourceProviders)
            {
                operationSources.TryAdd(resourceProvider.Type, new OperationSourceProvider(resourceProvider));
            }

            // Always register a concrete return-type source for non-resource/list/primitive/dictionary fallback paths.
            operationSources.TryAdd(
                returnCSharpType,
                new OperationSourceProvider(returnCSharpType, returnType is InputModelType { IsDynamicModel: true }));
        }

        internal bool IsResourceModelType(CSharpType type) => GetResourceDataTypes().ContainsKey(type);

        private IReadOnlyDictionary<CSharpType, List<ResourceClientProvider>>? _resourceDataTypes;
        private IReadOnlyDictionary<CSharpType, List<ResourceClientProvider>> GetResourceDataTypes()
        {
            if (_resourceDataTypes == null)
            {
                var dict = new Dictionary<CSharpType, List<ResourceClientProvider>>();
                foreach (var provider in ResourceProviders)
                {
                    if (!dict.TryGetValue(provider.ResourceData.Type, out var list))
                    {
                        list = new List<ResourceClientProvider>();
                        dict[provider.ResourceData.Type] = list;
                    }
                    list.Add(provider);
                }
                _resourceDataTypes = dict;
            }
            return _resourceDataTypes;
        }

        internal bool TryGetResourceClientProvider(CSharpType resourceDataType, [MaybeNullWhen(false)] out ResourceClientProvider resourceClientProvider)
        {
            resourceClientProvider = null;
            var providers = ResourceProviders.Where(p => p.IsResourceDataType(resourceDataType)).ToList();

            // Only wrap when the data type is exclusively used by one resource.
            // When multiple resources share the same data type, wrapping would pick an arbitrary resource,
            // so we skip wrapping and return the raw data type instead.
            if (providers.Count != 1)
            {
                return false;
            }

            resourceClientProvider = providers[0];
            return true;
        }

        private record ResourcesAndNonResourceMethodsInScope(
            List<ResourceClientProvider> ResourceClients,
            Dictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> ResourceMethods,
            List<NonResourceMethod> NonResourceMethods);
    }
}
