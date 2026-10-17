// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal sealed record ArmBinding(CommandSelection Selection, ScmMethodProvider Target, MethodProvider Navigation,
    MethodProvider? Identifier, TypeProvider Resource, OptionMapping[] Options, string ScopePath)
{
    internal bool Paging => Target.ServiceMethod is InputPagingServiceMethod;
    internal string Prefix => Selection.Prefix;
    internal CSharpType DataType => Resource.Properties.Single(property => property.Name == "Data").Type;
    internal CSharpType HookType => new(typeof(Func<,,,>), [typeof(string), new CSharpType(typeof(string), true),
        typeof(CancellationToken), new CSharpType(typeof(Task<>), [typeof(SubscriptionResource)])]);

    internal static ArmBinding Create(CommandSelection selection, TypeProvider[] stock, Compilation compilation)
    {
        var methods = stock.Where(provider => provider.BaseType?.Equals(typeof(ArmResource)) == true ||
                provider.BaseType?.Equals(typeof(ArmCollection)) == true)
            .SelectMany(provider => provider.Methods.OfType<ScmMethodProvider>())
            .Where(method => method.ServiceMethod?.CrossLanguageDefinitionId == selection.OperationId &&
                method.Signature.Name.EndsWith("Async", StringComparison.Ordinal)).ToArray();
        var candidates = methods.Where(method =>
            method.Signature.ReturnType is { } result &&
            (IsGeneric(result, "Azure", "AsyncPageable") ||
                IsGeneric(result, "System.Threading.Tasks", "Task") && IsGeneric(result.Arguments[0], "Azure", "Response") &&
                result.Arguments[0].Arguments[0].FullyQualifiedName == method.EnclosingType.Type.FullyQualifiedName)).ToArray();
        McpManifest.Require(candidates.Length == 1,
            $"'{selection.OperationId}' requires one stock read/page method; candidates: {string.Join("; ", methods.Select(Describe))}.");
        var target = candidates[0];
        var input = target.ServiceMethod!;
        McpManifest.Require(input.Operation.HttpMethod.ToString().Equals("GET", StringComparison.OrdinalIgnoreCase) &&
            input is not (InputLongRunningServiceMethod or InputLongRunningPagingServiceMethod),
            $"ARM MCP SDK binding supports read-only GET and paging only, not '{selection.OperationId}'.");
        var safety = selection.Safety.Apply(ToolSafety.FromHttpMethod("GET"));
        McpManifest.Require(safety.ReadOnly && !safety.Destructive && safety.Idempotent,
            $"Read-only ARM operation '{selection.OperationId}' cannot override its safety as a mutation.");
        var resourceType = input is InputPagingServiceMethod
            ? target.Signature.ReturnType!.Arguments.Single() : target.EnclosingType.Type;
        var resource = stock.Single(provider => provider.Type.Equals(resourceType) && provider.BaseType?.Equals(typeof(ArmResource)) == true);
        var extensions = stock.SelectMany(provider => provider.Methods)
            .Where(method => method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Extension)).ToArray();
        MethodProvider navigation;
        MethodProvider? identifier;
        if (input is not InputPagingServiceMethod)
        {
            navigation = extensions.Single(method => method.Signature.ReturnType?.Equals(resource.Type) == true &&
                method.Signature.Parameters.First().Type.Equals(typeof(ArmClient)));
            identifier = resource.Methods.Single(method => method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Static) &&
                method.Signature.ReturnType?.Equals(typeof(ResourceIdentifier)) == true);
        }
        else if (target.EnclosingType.BaseType?.Equals(typeof(ArmCollection)) == true)
        {
            navigation = extensions.Single(method => method.Signature.ReturnType?.Equals(target.EnclosingType.Type) == true &&
                method.Signature.Parameters.First().Type.Equals(typeof(ResourceGroupResource)));
            identifier = null;
        }
        else
        {
            navigation = extensions.Single(method => method.Signature.Name == target.Signature.Name &&
                method.Signature.ReturnType?.Equals(target.Signature.ReturnType) == true &&
                method.Signature.Parameters.First().Type.Equals(typeof(SubscriptionResource)));
            identifier = null;
        }
        var pathParameters = input.Operation.Parameters.OfType<InputPathParameter>()
            .Where(parameter => parameter.Scope != InputParameterScope.Constant).ToArray();
        McpManifest.Require(pathParameters.All(parameter => parameter.Type is InputPrimitiveType { Kind: InputPrimitiveTypeKind.String }),
            $"Unsupported ARM path parameter in '{selection.OperationId}'.");
        var options = pathParameters.Select(parameter =>
            new OptionMapping(OptionName(parameter.Name, selection), "string", parameter.Name != "subscriptionId",
                parameter.Name == "subscriptionId" ? "The subscription ID or name. Defaults to the configured environment or profile."
                    : parameter.Doc ?? parameter.Summary ?? parameter.Name))
            .Append(new OptionMapping("Tenant", "string", false, "The tenant used by the shared Azure subscription service.")).ToList();
        if (input is InputPagingServiceMethod)
        {
            options.Add(new("ContinuationToken", "string", false, "The same-scope continuation token from the previous page."));
        }
        McpManifest.Require(options.Any(option => option.Name == "Subscription") &&
            options.Select(option => option.Name).Distinct(StringComparer.OrdinalIgnoreCase).Count() == options.Count,
            $"Invalid or colliding ARM options for '{selection.OperationId}'.");
        var allowed = pathParameters.Select(parameter => parameter.Name).ToHashSet(StringComparer.Ordinal);
        McpManifest.Require(input.Parameters.All(parameter => allowed.Contains(parameter.Name) || parameter.IsApiVersion ||
                parameter.Scope == InputParameterScope.Constant),
            $"'{selection.OperationId}' has non-path arguments that require an explicit SDK binding override.");
        var binding = new ArmBinding(selection, target, navigation, identifier, resource, options.ToArray(), input.Operation.Path);
        binding.ValidateSymbol(compilation, target.EnclosingType.Type, target.Signature);
        binding.ValidateSymbol(compilation, navigation.EnclosingType.Type, navigation.Signature);
        if (identifier is not null)
        {
            binding.ValidateSymbol(compilation, identifier.EnclosingType.Type, identifier.Signature);
        }
        var data = compilation.GetTypeByMetadataName(binding.DataType.FullyQualifiedName);
        McpManifest.Require(data is not null && data.AllInterfaces.Any(type =>
            type.Name == "IPersistableModel" && type.ContainingNamespace.ToDisplayString() == "System.ClientModel.Primitives" &&
            type.TypeArguments.Length == 1 && type.TypeArguments[0].ToDisplayString() == binding.DataType.FullyQualifiedName),
            $"SDK data '{binding.DataType}' for '{selection.OperationId}' must implement its typed IPersistableModel contract for AOT-safe projection.");
        return binding;
    }

    internal static string OptionName(string parameter, CommandSelection selection) => parameter switch
    {
        "subscriptionId" => "Subscription",
        "resourceGroupName" => "ResourceGroup",
        "resourceName" => CommandSelection.Pascal(selection.Path.Split(' ')[^2]),
        _ when parameter.EndsWith("Name", StringComparison.Ordinal) => CommandSelection.Pascal(parameter[..^4]),
        _ => CommandSelection.Pascal(parameter)
    };

    internal string OptionFor(string parameter) => OptionName(parameter, Selection);

    private void ValidateSymbol(Compilation compilation, CSharpType owner, MethodSignature expected)
    {
        // Mockable operation providers are called through their public extension, not their implementation type.
        if (owner.Name.StartsWith("Mockable", StringComparison.Ordinal))
        {
            return;
        }
        var type = compilation.GetTypeByMetadataName(owner.FullyQualifiedName);
        var candidates = type?.GetMembers(expected.Name).OfType<IMethodSymbol>().ToArray() ?? [];
        var expectedTypes = expected.Parameters.Select(parameter => parameter.Type.ToString().Replace("global::", "", StringComparison.Ordinal)).ToArray();
        var exact = candidates.Where(method => method.DeclaredAccessibility == Accessibility.Public &&
            method.Parameters.Select(parameter => parameter.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
                .Replace("global::", "", StringComparison.Ordinal)).SequenceEqual(expectedTypes)).ToArray();
        McpManifest.Require(exact.Length == 1,
            $"SDK binding mismatch for '{Selection.OperationId}'. Expected stock {owner}.{expected.Name}({string.Join(", ", expectedTypes)}). " +
            $"Referenced candidates: {string.Join("; ", candidates.Select(method => method.ToDisplayString()))}. " +
            "Use the matching SDK input/provider version or an explicit handwritten operation override.");
    }

    internal static string Describe(ScmMethodProvider method) =>
        $"{method.EnclosingType.Type}.{method.Signature.Name}({string.Join(", ", method.Signature.Parameters.Select(parameter => parameter.Type))}) -> {method.Signature.ReturnType}";

    private static bool IsGeneric(CSharpType type, string ns, string name) =>
        type.Namespace == ns && type.Name == name && type.Arguments.Count == 1;
}
