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

            AddReorderedMethodsFromApiBaseline(modelFactory, methods);
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
                    .Select(parameter => (ValueExpression)parameter)
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
            => previousType.AreNamesEqual(currentType) || previousType.InputType.AreNamesEqual(currentType.InputType);

        private static void AddReorderedMethodsFromApiBaseline(ModelFactoryProvider modelFactory, IList<MethodProvider> methods)
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

                    var arguments = previousParametersByCurrentOrder.Select(parameter => (ValueExpression)parameter).ToArray();
                    methods.Add(new MethodProvider(signature, Return(new InvokeMethodExpression(null, currentMethod.Signature, arguments)), modelFactory));
                }
            }
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
                    foreach (var parameter in SplitParameterList(match.Groups["parameters"].Value))
                    {
                        if (TryGetParameterName(parameter) is string parameterName)
                        {
                            parameterNames.Add(parameterName);
                        }
                    }

                    if (parameterNames.Count > 0)
                    {
                        yield return new ApiModelFactoryParameters(match.Groups["method"].Value, parameterNames);
                    }
                }
            }
        }

        private static readonly Regex ApiModelFactoryMethodRegex = new(
            @"^\s*public static [\w\.\<\>,\s]+ (?<method>\w+)\((?<parameters>.*)\) \{",
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

        private static string? TryGetParameterName(string parameter)
        {
            var parameterWithoutDefault = parameter.Split('=')[0].Trim();
            var lastSpace = parameterWithoutDefault.LastIndexOf(' ');
            return lastSpace >= 0 && lastSpace + 1 < parameterWithoutDefault.Length
                ? parameterWithoutDefault[(lastSpace + 1)..]
                : null;
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

        private sealed record ApiModelFactoryParameters(string MethodName, IReadOnlyList<string> ParameterNames);

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
