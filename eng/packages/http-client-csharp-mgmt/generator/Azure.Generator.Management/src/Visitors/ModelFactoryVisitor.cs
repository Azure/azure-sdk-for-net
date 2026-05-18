// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    internal class ModelFactoryVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider modelFactory)
            {
                var updatedMethods = new List<MethodProvider>();
                foreach (var method in modelFactory.Methods)
                {
                    var returnType = method.Signature.ReturnType;
                    if (returnType is not null && ManagementClientGenerator.Instance.OutputLibrary.IsModelFactoryModelType(returnType))
                    {
                        // Fix ArgumentNullException XML documentation for parameters that are nullable
                        // Model factory methods should allow all parameters to be null for mocking purposes
                        FixArgumentNullExceptionXmlDoc(method);

                        // Update parameter names for specific properties
                        UpdateParameterNames(method);

                        updatedMethods.Add(method);
                    }
                    else if (returnType is not null && ShouldPreserveBackwardCompatMethod(method, returnType))
                    {
                        updatedMethods.Add(method);
                    }
                }

                AddBackwardCompatMethodsFromLastContractView(modelFactory, updatedMethods);
                modelFactory.Update(methods: updatedMethods);
                return modelFactory;
            }
            return base.VisitType(type);
        }

        internal static void AddBackwardCompatMethodsFromLastContractView(ModelFactoryProvider modelFactory, IList<MethodProvider> methods)
        {
            var previousMethods = modelFactory.LastContractView?.Methods;
            if (previousMethods is not null && previousMethods.Count > 0)
            {
                foreach (var previousMethod in previousMethods)
                {
                    var returnType = previousMethod.Signature.ReturnType;
                    if (returnType is null
                        || methods.Any(method => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previousMethod.Signature)))
                    {
                        continue;
                    }

                    if (ShouldPreserveBackwardCompatMethod(previousMethod, returnType))
                    {
                        methods.Add(new MethodProvider(previousMethod.Signature, previousMethod.BodyStatements ?? MethodBodyStatement.Empty, modelFactory));
                    }
                    else if (TryBuildReorderedOverload(previousMethod, methods, modelFactory, out var reorderedOverload))
                    {
                        methods.Add(reorderedOverload);
                    }
                }
            }

            AddMethodsFromApiBaseline(modelFactory, methods);
        }

        internal static bool ShouldPreserveBackwardCompatMethod(MethodProvider method, CSharpType returnType)
        {
            // Previous model-factory overloads may target models whose public read-only members are
            // supplied by custom partial classes. The generator cannot see those custom members, but
            // it must still preserve the previous hidden overload while the return type still exists.
            return ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                && ManagementClientGenerator.Instance.OutputLibrary.IsModelType(returnType);
        }

        private static bool TryBuildReorderedOverload(
            MethodProvider previousMethod,
            IList<MethodProvider> currentMethods,
            ModelFactoryProvider modelFactory,
            [NotNullWhen(true)] out MethodProvider? overload)
        {
            overload = null;
            var returnType = previousMethod.Signature.ReturnType;
            if (returnType is null)
            {
                return false;
            }

            var previousParameters = previousMethod.Signature.Parameters;
            var matchingCurrentMethods = currentMethods.Where(method =>
                !ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                && method.Signature.Name == previousMethod.Signature.Name
                && method.Signature.ReturnType is not null
                && method.Signature.ReturnType.AreNamesEqual(returnType)
                && method.Signature.Parameters.Count == previousParameters.Count);

            foreach (var currentMethod in matchingCurrentMethods)
            {
                if (!TryMapPreviousParameters(currentMethod.Signature.Parameters, previousParameters, out var previousParametersByCurrentOrder))
                {
                    continue;
                }

                if (previousParametersByCurrentOrder.SequenceEqual(previousParameters))
                {
                    continue;
                }

                var arguments = previousParametersByCurrentOrder
                    .Zip(currentMethod.Signature.Parameters)
                    .Select(pair => BuildParameterArgument(pair.First, pair.Second.Type))
                    .ToArray();
                var body = Return(new InvokeMethodExpression(null, currentMethod.Signature, arguments));
                overload = new MethodProvider(previousMethod.Signature, body, modelFactory);
                return true;
            }

            return false;
        }

        private static bool TryMapPreviousParameters(
            IReadOnlyList<ParameterProvider> currentParameters,
            IReadOnlyList<ParameterProvider> previousParameters,
            [NotNullWhen(true)] out IReadOnlyList<ParameterProvider>? previousParametersByCurrentOrder)
        {
            var result = new List<ParameterProvider>(currentParameters.Count);
            var used = new HashSet<ParameterProvider>();
            foreach (var currentParameter in currentParameters)
            {
                var matchingPrevious = previousParameters.SingleOrDefault(previousParameter =>
                    !used.Contains(previousParameter)
                    && string.Equals(previousParameter.Name, currentParameter.Name, StringComparison.OrdinalIgnoreCase)
                    && AreCompatibleParameterTypes(previousParameter.Type, currentParameter.Type));

                if (matchingPrevious is null)
                {
                    previousParametersByCurrentOrder = null;
                    return false;
                }

                result.Add(matchingPrevious);
                used.Add(matchingPrevious);
            }

            previousParametersByCurrentOrder = result;
            return true;
        }

        private static bool AreCompatibleParameterTypes(CSharpType previousType, CSharpType currentType)
            => previousType.AreNamesEqual(currentType)
            || previousType.InputType.AreNamesEqual(currentType.InputType)
            || IsResourceIdentifierToString(previousType, currentType);

        private static ValueExpression BuildParameterArgument(ParameterProvider previousParameter, CSharpType currentType)
            => IsResourceIdentifierToString(previousParameter.Type, currentType)
                ? ((ValueExpression)previousParameter).InvokeToString()
                : previousParameter;

        private static bool IsResourceIdentifierToString(CSharpType previousType, CSharpType currentType)
            => previousType.Equals(typeof(Azure.Core.ResourceIdentifier))
            && currentType.IsFrameworkType
            && currentType.FrameworkType == typeof(string);

        private static void AddMethodsFromApiBaseline(ModelFactoryProvider modelFactory, IList<MethodProvider> methods)
        {
            var apiDirectory = Path.Combine(ManagementClientGenerator.Instance.Configuration.OutputDirectory, "api");
            if (!Directory.Exists(apiDirectory))
            {
                return;
            }

            foreach (var apiMethod in ReadModelFactoryApiParameterOrders(apiDirectory))
            {
                foreach (var currentMethod in methods.ToArray())
                {
                    var currentParameters = currentMethod.Signature.Parameters;
                    if (ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(currentMethod)
                        || currentMethod.Signature.Name != apiMethod.MethodName
                        || currentParameters.Count != apiMethod.ParameterNames.Count
                        || !TryOrderParametersByName(currentParameters, apiMethod.ParameterNames, out var apiOrderedParameters)
                        || !TryMapPreviousParameters(currentParameters, apiOrderedParameters, out var previousParametersByCurrentOrder)
                        || previousParametersByCurrentOrder.SequenceEqual(apiOrderedParameters))
                    {
                        continue;
                    }

                    var signature = new MethodSignature(
                        currentMethod.Signature.Name,
                        currentMethod.Signature.Description,
                        currentMethod.Signature.Modifiers,
                        currentMethod.Signature.ReturnType,
                        currentMethod.Signature.ReturnDescription,
                        apiOrderedParameters);
                    if (methods.Any(method => MethodSignature.MethodSignatureComparer.Equals(method.Signature, signature)))
                    {
                        continue;
                    }

                    var arguments = previousParametersByCurrentOrder
                        .Zip(currentMethod.Signature.Parameters)
                        .Select(pair => BuildParameterArgument(pair.First, pair.Second.Type))
                        .ToArray();
                    methods.Add(new MethodProvider(signature, Return(new InvokeMethodExpression(null, currentMethod.Signature, arguments)), modelFactory));
                }

                if (!methods.Any(method => method.Signature.Name == apiMethod.MethodName)
                    && TryBuildConstructorFactoryFromApiBaseline(apiMethod, modelFactory, out var constructorFactoryMethod))
                {
                    methods.Add(constructorFactoryMethod);
                }
            }
        }

        private static bool TryBuildConstructorFactoryFromApiBaseline(
            ApiModelFactoryParameters apiMethod,
            ModelFactoryProvider modelFactory,
            [NotNullWhen(true)] out MethodProvider? method)
        {
            method = null;
            if (apiMethod.MethodName != apiMethod.ReturnTypeName
                || apiMethod.ParameterNames.Count != 5
                || !apiMethod.ParameterNames.SequenceEqual(["id", "name", "resourceType", "systemData", "properties"]))
            {
                return false;
            }

            if (!TryGetTypeProvider(apiMethod.ReturnTypeName, out var returnTypeProvider)
                || !TryResolveApiParameterTypes(apiMethod.ParameterTypeNames, out var parameterTypes))
            {
                return false;
            }

            var parameters = apiMethod.ParameterNames.Zip(parameterTypes)
                .Select(pair => new ParameterProvider(pair.First, $"The {pair.First}.", pair.Second))
                .ToArray();
            var signature = new MethodSignature(
                apiMethod.MethodName,
                $"Creates a {apiMethod.ReturnTypeName}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                returnTypeProvider.Type,
                $"A {apiMethod.ReturnTypeName}.",
                parameters);

            var arguments = parameters
                .Take(4)
                .Select(parameter => (ValueExpression)parameter)
                .Append(Null)
                .Append(parameters[4])
                .ToArray();
            method = new MethodProvider(signature, Return(New.Instance(returnTypeProvider.Type, arguments)), modelFactory);
            return true;
        }

        private static IEnumerable<ApiModelFactoryParameters> ReadModelFactoryApiParameterOrders(string apiDirectory)
        {
            foreach (var apiFile in Directory.EnumerateFiles(apiDirectory, "*.cs"))
            {
                foreach (var line in File.ReadLines(apiFile))
                {
                    var match = ApiModelFactoryMethodRegex.Match(line);
                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameterNames = new List<string>();
                    var parameterTypeNames = new List<string>();
                    foreach (var parameter in SplitParameterList(match.Groups["parameters"].Value))
                    {
                        var parsedParameter = TryGetParameter(parameter);
                        if (parsedParameter is not null)
                        {
                            var (parameterType, parameterName) = parsedParameter.Value;
                            parameterNames.Add(parameterName);
                            parameterTypeNames.Add(parameterType);
                        }
                    }

                    if (parameterNames.Count > 0)
                    {
                        yield return new ApiModelFactoryParameters(
                            match.Groups["method"].Value,
                            GetSimpleTypeName(match.Groups["return"].Value),
                            match.Groups["return"].Value.Trim(),
                            parameterNames,
                            parameterTypeNames);
                    }
                }
            }
        }

        private static readonly Regex ApiModelFactoryMethodRegex = new(
            @"^\s*public static (?<return>[\w\.\<\>,\s]+) (?<method>\w+)\((?<parameters>.*)\) \{",
            RegexOptions.Compiled);

        private static IEnumerable<string> SplitParameterList(string parameters)
        {
            var start = 0;
            var depth = 0;
            for (var i = 0; i < parameters.Length; i++)
            {
                depth += parameters[i] switch
                {
                    '<' or '(' => 1,
                    '>' or ')' => -1,
                    _ => 0
                };

                if (parameters[i] == ',' && depth == 0)
                {
                    yield return parameters[start..i].Trim();
                    start = i + 1;
                }
            }

            if (start < parameters.Length)
            {
                yield return parameters[start..].Trim();
            }
        }

        private static (string TypeName, string ParameterName)? TryGetParameter(string parameter)
        {
            var parameterWithoutDefault = parameter.Split('=')[0].Trim();
            var lastSpace = parameterWithoutDefault.LastIndexOf(' ');
            return lastSpace >= 0 && lastSpace + 1 < parameterWithoutDefault.Length
                ? (parameterWithoutDefault[..lastSpace].Trim(), parameterWithoutDefault[(lastSpace + 1)..])
                : null;
        }

        private static string GetSimpleTypeName(string typeName)
        {
            var trimmed = typeName.Trim();
            var lastDot = trimmed.LastIndexOf('.');
            return lastDot >= 0 ? trimmed[(lastDot + 1)..] : trimmed;
        }

        private static bool TryOrderParametersByName(
            IReadOnlyList<ParameterProvider> parameters,
            IReadOnlyList<string> orderedNames,
            [NotNullWhen(true)] out IReadOnlyList<ParameterProvider>? orderedParameters)
        {
            var result = new List<ParameterProvider>(orderedNames.Count);
            foreach (var name in orderedNames)
            {
                var parameter = parameters.SingleOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
                if (parameter is null)
                {
                    orderedParameters = null;
                    return false;
                }

                result.Add(parameter);
            }

            orderedParameters = result;
            return true;
        }

        private static bool TryResolveApiParameterTypes(
            IReadOnlyList<string> parameterTypeNames,
            [NotNullWhen(true)] out IReadOnlyList<CSharpType>? parameterTypes)
        {
            var result = new List<CSharpType>(parameterTypeNames.Count);
            foreach (var typeName in parameterTypeNames)
            {
                if (TryResolveApiParameterType(typeName, out var parameterType))
                {
                    result.Add(parameterType);
                    continue;
                }

                parameterTypes = null;
                return false;
            }

            parameterTypes = result;
            return true;
        }

        private static bool TryResolveApiParameterType(string typeName, [NotNullWhen(true)] out CSharpType? parameterType)
        {
            parameterType = null;
            var simpleTypeName = GetSimpleTypeName(typeName);
            var frameworkType = simpleTypeName switch
            {
                "ResourceIdentifier" => typeof(Azure.Core.ResourceIdentifier),
                "string" => typeof(string),
                "ResourceType" => typeof(Azure.Core.ResourceType),
                "SystemData" => typeof(Azure.ResourceManager.Models.SystemData),
                _ => null
            };

            if (frameworkType is not null)
            {
                parameterType = frameworkType;
                return true;
            }

            if (TryGetTypeProvider(simpleTypeName, out var typeProvider))
            {
                parameterType = typeProvider.Type;
                return true;
            }

            return false;
        }

        internal static void WriteSuppressedConstructorFactoryCompatibilityFile(string outputDirectory)
        {
            var modelFactory = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().SingleOrDefault();
            if (modelFactory is null)
            {
                return;
            }

            var filePath = Path.Combine(outputDirectory, "src", "Generated", $"{modelFactory.Name}.Compatibility.cs");
            var methods = BuildSuppressedConstructorFactoryCompatibilityMethods(outputDirectory, modelFactory).ToArray();
            if (methods.Length == 0)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return;
            }

            var directory = Path.GetDirectoryName(filePath);
            if (directory is not null)
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(filePath, $$"""
                // Copyright (c) Microsoft Corporation. All rights reserved.
                // Licensed under the MIT License.

                // <auto-generated/>

                #nullable disable

                namespace {{modelFactory.Type.Namespace}}
                {
                    public static partial class {{modelFactory.Name}}
                    {
                {{string.Join($"{Environment.NewLine}{Environment.NewLine}", methods)}}
                    }
                }
                """);
        }

        private static IEnumerable<string> BuildSuppressedConstructorFactoryCompatibilityMethods(string outputDirectory, ModelFactoryProvider modelFactory)
        {
            var apiDirectory = Path.Combine(outputDirectory, "api");
            if (!Directory.Exists(apiDirectory))
            {
                yield break;
            }

            var suppressedMethods = ReadSuppressedModelFactoryMethods(outputDirectory);
            if (suppressedMethods.Count == 0)
            {
                yield break;
            }

            var addedSignatures = new HashSet<string>(StringComparer.Ordinal);
            foreach (var apiMethod in ReadModelFactoryApiParameterOrders(apiDirectory))
            {
                var signatureKey = $"{apiMethod.MethodName}({string.Join(",", apiMethod.ParameterTypeNames)})";
                if (!suppressedMethods.Contains(apiMethod.MethodName)
                    || !addedSignatures.Add(signatureKey)
                    || !CanBuildConstructorFactoryFromApiBaseline(apiMethod))
                {
                    continue;
                }

                yield return BuildConstructorFactoryMethodSource(apiMethod);
            }
        }

        private static HashSet<string> ReadSuppressedModelFactoryMethods(string outputDirectory)
        {
            var result = new HashSet<string>(StringComparer.Ordinal);
            foreach (var customDirectoryName in new[] { "Customize", "Customization" })
            {
                var customDirectory = Path.Combine(outputDirectory, "src", customDirectoryName);
                if (!Directory.Exists(customDirectory))
                {
                    continue;
                }

                foreach (var file in Directory.EnumerateFiles(customDirectory, "*.cs", SearchOption.AllDirectories))
                {
                    foreach (Match match in CodeGenSuppressRegex.Matches(File.ReadAllText(file)))
                    {
                        result.Add(match.Groups["method"].Value);
                    }
                }
            }

            return result;
        }

        private static readonly Regex CodeGenSuppressRegex = new(
            @"CodeGenSuppress\(""(?<method>\w+)""",
            RegexOptions.Compiled);

        private static bool CanBuildConstructorFactoryFromApiBaseline(ApiModelFactoryParameters apiMethod)
            => apiMethod.MethodName == apiMethod.ReturnTypeName
            && apiMethod.ParameterNames.Count == 5
            && apiMethod.ParameterNames.SequenceEqual(["id", "name", "resourceType", "systemData", "properties"])
            && TryResolveApiParameterTypes(apiMethod.ParameterTypeNames, out _)
            && TryGetTypeProvider(apiMethod.ReturnTypeName, out _);

        private static string BuildConstructorFactoryMethodSource(ApiModelFactoryParameters apiMethod)
        {
            var parameters = apiMethod.ParameterTypeNames.Zip(apiMethod.ParameterNames)
                .Select(pair => $"{FormatSourceType(pair.First)} {pair.Second}");
            return $$"""
                        public static {{FormatSourceType(apiMethod.ReturnSourceTypeName)}} {{apiMethod.MethodName}}({{string.Join(", ", parameters)}})
                        {
                            return new {{FormatSourceType(apiMethod.ReturnSourceTypeName)}}(id, name, resourceType, systemData, null, properties);
                        }
                """;
        }

        private static string FormatSourceType(string typeName)
            => typeName == "string" ? "string" : $"global::{typeName}";

        private static bool TryGetTypeProvider(string name, [NotNullWhen(true)] out TypeProvider? typeProvider)
        {
            typeProvider = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.SingleOrDefault(typeProvider => typeProvider.Name == name);
            return typeProvider is not null;
        }

        private sealed record ApiModelFactoryParameters(
            string MethodName,
            string ReturnTypeName,
            string ReturnSourceTypeName,
            IReadOnlyList<string> ParameterNames,
            IReadOnlyList<string> ParameterTypeNames);

        private void FixArgumentNullExceptionXmlDoc(MethodProvider method)
        {
            // Model factory methods are for mocking and should not have ArgumentNullException validation
            // The method implementation uses ternary operators to handle null values gracefully
            // Remove any ArgumentNullException documentation by clearing the exceptions list
            if (method.XmlDocs != null)
            {
                // Clear exceptions to remove ArgumentNullException documentation
                method.XmlDocs.Update(exceptions: Array.Empty<XmlDocExceptionStatement>());
            }
        }

        private void UpdateParameterNames(MethodProvider method)
        {
            if (PreservePreviousParameterNames(method))
            {
                // Update the method signature to refresh documentation after parameter renames.
                method.Update(signature: method.Signature);
            }
        }

        private static bool PreservePreviousParameterNames(MethodProvider method)
        {
            var previousMethods = method.EnclosingType.LastContractView?.Methods;
            if (previousMethods is null || previousMethods.Count == 0)
            {
                return false;
            }

            var previousMethod = previousMethods.FirstOrDefault(previous => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previous.Signature));
            if (previousMethod is null)
            {
                return false;
            }

            var currentParameters = method.Signature.Parameters;
            var previousParameters = previousMethod.Signature.Parameters;
            if (currentParameters.Count != previousParameters.Count)
            {
                return false;
            }

            var updated = false;
            var currentParameterNames = currentParameters.Select(parameter => parameter.Name).ToHashSet(StringComparer.Ordinal);
            for (int i = 0; i < currentParameters.Count; i++)
            {
                var previousName = previousParameters[i].Name;
                var currentParameter = currentParameters[i];
                if (string.IsNullOrEmpty(previousName) || currentParameter.Name == previousName)
                {
                    continue;
                }

                if (currentParameterNames.Contains(previousName))
                {
                    continue;
                }

                currentParameterNames.Remove(currentParameter.Name);
                currentParameter.Update(name: previousName);
                currentParameterNames.Add(previousName);
                updated = true;
            }

            return updated;
        }
    }
}
