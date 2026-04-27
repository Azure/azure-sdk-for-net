// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents the context for an Azure resource operation, encapsulating the primary and (optionally) secondary request path patterns
/// and their associated contextual parameters.
/// <para>
/// The <see cref="OperationContext"/> is used during code generation to determine which parameters for an operation
/// can be derived contextually from the resource identifier (Id) of the enclosing resource or resource collection,
/// and which must be supplied by the caller. It analyzes the request path(s) to build a list of <see cref="ContextualParameter"/>s,
/// which describe how to extract parameter values from the Id property.
/// </para>
/// <para>
/// A secondary contextual path is only provided in the case of a resource collection for a "tuple resource".
/// Unlike regular resources, which can be specified from their parent by a single parameter (typically their name),
/// tuple resources require multiple parameters to be specified from their parent—hence the name "tuple resource".
/// In such cases, the resource collection may need to take additional parameters from its constructor,
/// and the secondary contextual path is used to model this scenario and extract those parameters.
/// </para>
/// <para>
/// The <see cref="BuildParameterMapping"/> method enables mapping operation path parameters to their contextual sources,
/// supporting both primary and tuple resource collection scenarios.
/// </para>
/// </summary>
internal class OperationContext
{
    public static OperationContext Create(RequestPathPattern contextualPath, IReadOnlyDictionary<string, string>? constantPathParameters = null)
    {
        return new OperationContext(contextualPath, null, null, constantPathParameters);
    }

    public static OperationContext Create(RequestPathPattern contextualPath, RequestPathPattern secondaryContextualPath, Func<string, FieldProvider> fieldSelector, IReadOnlyDictionary<string, string>? constantPathParameters = null)
    {
        return new OperationContext(contextualPath, secondaryContextualPath, fieldSelector, constantPathParameters);
    }

    public RequestPathPattern ContextualPath { get; }

    public RequestPathPattern? SecondaryContextualPath { get; }

    public IReadOnlyList<ContextualParameter> ContextualPathParameters { get; }

    public IReadOnlyList<ContextualParameter> SecondaryContextualPathParameters { get; }

    /// <summary>
    /// Constant path parameter values for this resource.
    /// When a resource is expanded from a dynamic parent type pattern (e.g., {parentType}),
    /// this maps parameter names to their constant string values.
    /// </summary>
    public IReadOnlyDictionary<string, string>? ConstantPathParameters { get; }

    /// <summary>
    /// Initializes a new instance of the OperationContext class with the specified primary and secondary request
    /// path patterns.
    /// </summary>
    /// <param name="contextualPath">The primary request path pattern that defines the main context for the operation. Cannot be null.</param>
    /// <param name="secondaryContextualPath">An optional secondary request path pattern that provides additional context for the operation. Can be null
    /// if no secondary context is required.</param>
    /// <param name="fieldSelector">The function to get the corresponding field for secondary contextual parameters.</param>
    /// <param name="constantPathParameters">Optional constant path parameter values for resources expanded from dynamic parent types.</param>
    private OperationContext(RequestPathPattern contextualPath, RequestPathPattern? secondaryContextualPath, Func<string, FieldProvider>? fieldSelector, IReadOnlyDictionary<string, string>? constantPathParameters)
    {
        ContextualPath = contextualPath;
        SecondaryContextualPath = secondaryContextualPath;
        ConstantPathParameters = constantPathParameters;
        ContextualPathParameters = BuildContextualParameters(contextualPath);
        SecondaryContextualPathParameters = secondaryContextualPath != null && fieldSelector != null ?
            BuildSecondaryContextualParameters(contextualPath, secondaryContextualPath, fieldSelector) :
            [];
    }

    /// <summary>
    /// This method accepts a <see cref="RequestPathPattern"/> as a contextual request path pattern
    /// of a certain resource or resource collection class,
    /// and builds a list of <see cref="ContextualParameter"/>s that represent the parameters
    /// provided by this contextual request path pattern.
    /// </summary>
    /// <param name="contextualPath">The contextual request path pattern.</param>
    /// <returns></returns>
    private static IReadOnlyList<ContextualParameter> BuildContextualParameters(RequestPathPattern contextualPath)
    {
        try
        {
            // we use a stack here because we are building the contextual parameters in reverse order.
            var result = new Stack<ContextualParameter>();

            BuildContextualParameterHierarchy(contextualPath, result, 0);

            return [.. result];
        }
        catch (InvalidOperationException ex)
        {
            // Report diagnostic for malformed resource structure
            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                code: "malformed-resource-detected",
                message: $"The request path '{contextualPath}' has a malformed structure: {ex.Message}"
            );
            // Return empty list to allow graceful degradation
            return [];
        }
    }

    private static void BuildContextualParameterHierarchy(RequestPathPattern current, Stack<ContextualParameter> parameterStack, int parentLayerCount)
    {
        // TODO -- handle scope/extension resources
        // we resolved it until to tenant, exit because it no longer contains parameters
        if (current == RequestPathPattern.Tenant)
        {
            return;
        }
        // get the parent path
        var parent = current.GetParent();

        // handle the known special patterns
        if (current == RequestPathPattern.Subscription)
        {
            // using the reference name of the last segment as the parameter name, aka subscriptionId
            parameterStack.Push(new ContextualParameter(current[0].Value, current[1].VariableName, id => id.SubscriptionId()));
        }
        else if (current == RequestPathPattern.ManagementGroup)
        {
            // using the reference name of the last segment as the parameter name, aka managementGroupId
            parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => BuildParentInvocation(parentLayerCount, id).Name()));
        }
        else if (current == RequestPathPattern.ResourceGroup)
        {
            // using the reference name of the last segment as the parameter name, aka resourceGroupName
            parameterStack.Push(new ContextualParameter(current[^2].Value, current[^1].VariableName, id => id.ResourceGroupName()));
        }
        else if (current.Count == 1 && !current[0].IsConstant) // Extension resource case: single variable segment. Here we assume the extension resource's requestPathPattern start with one and only one variable segment
        {
            // Extension resource case: single variable segment.
            // BuildParentInvocation returns a ResourceIdentifier expression. The consumer (PopulateArguments)
            // is responsible for converting to the target REST parameter type (string or ResourceIdentifier).
            parameterStack.Push(new ContextualParameter(current[0].VariableName, current[0].VariableName, id => BuildParentInvocation(parentLayerCount, id), typeof(ResourceIdentifier)));
        }
        else
        {
            // get the diff between the current path and the parent path, we only handle the diff and defer the handling of the parent itself in the next recursion.
            var diffPath = parent.TrimAncestorFrom(current);
            var pairs = ReverselySplitIntoPairs(diffPath);
            var appendParent = false;
            foreach (var (key, value) in pairs)
            {
                // we have a pair of segment, key and value
                // In majority of cases, the key is a constant segment. In some rare scenarios, the key could be a variable.
                // The value could be a constant or a variable segment.
                if (!key.IsConstant)
                {
                    // Handle the case when key is a variable
                    // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                    int currentParentCount = parentLayerCount;
                    // Push value (Name) before key (ResourceType.Type) because the stack is LIFO —
                    // when popped, key (ResourceType.Type) will come out first, matching the positional order in the operation path.
                    if (!value.IsConstant)
                    {
                        parameterStack.Push(new ContextualParameter(value.VariableName, value.VariableName, id => BuildParentInvocation(currentParentCount, id).Name()));
                    }
                    parameterStack.Push(new ContextualParameter(key.VariableName, key.VariableName, id => BuildParentInvocation(currentParentCount, id).ResourceType().Type()));
                    appendParent = true;
                }
                else if (!value.IsConstant)
                {
                    if (key.IsProvidersSegment) // if the key is `providers` and the value is a parameter
                    {
                        if (current.Count <= 4) // path is /providers/{resourceProviderNamespace} or /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
                        {
                            // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                            int currentParentCount = parentLayerCount;
                            parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).Provider()));
                        }
                        else
                        {
                            // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                            int currentParentCount = parentLayerCount;
                            parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).ResourceType().Namespace()));
                        }
                        // do not append a new .Parent to the id
                    }
                    else // for all other normal keys
                    {
                        // we have to reassign the value of parentLayerCount to a local variable to avoid the closure to wrap the parentLayerCount variable which changes during recursion.
                        int currentParentCount = parentLayerCount;
                        parameterStack.Push(new ContextualParameter(key.Value, value.VariableName, id => BuildParentInvocation(currentParentCount, id).Name()));
                        appendParent = true;
                    }
                }
                else // in this branch both key and value are constants
                {
                    if (!key.IsProvidersSegment)
                    {
                        // When the value is a constant (e.g., a singleton resource name) and the key is not providers,
                        // we need to skip this level and increment the parent hierarchy so that parameters from parent segments get the correct .Parent reference
                        appendParent = true;
                    }
                }
            }
            // check if we need to call .Parent on id
            if (appendParent)
            {
                parentLayerCount++;
            }
        }
        // recursively get the parameters of its parent
        BuildContextualParameterHierarchy(parent, parameterStack, parentLayerCount);

        static ScopedApi<ResourceIdentifier> BuildParentInvocation(int parentLayerCount, ScopedApi<ResourceIdentifier> id)
        {
            var result = id;
            for (int i = 0; i < parentLayerCount; i++)
            {
                result = result.Parent();
            }
            return result;
        }

        static IReadOnlyList<KeyValuePair<RequestPathSegment, RequestPathSegment>> ReverselySplitIntoPairs(IReadOnlyList<RequestPathSegment> requestPath)
        {
            // in our current cases, we will always have even segments.
            if (requestPath.Count % 2 != 0)
            {
                throw new InvalidOperationException($"The request path should have an even number of segments for pairing, but got {requestPath.Count} segments.");
            }

            int maxNumberOfPairs = requestPath.Count / 2;
            var pairs = new KeyValuePair<RequestPathSegment, RequestPathSegment>[maxNumberOfPairs];

            for (int i = 0; i < maxNumberOfPairs; i++)
            {
                // each pair is a key-value pair, where the key is the first segment and the value is the second segment.
                // please note that we are filling the pairs in reverse order
                pairs[^(i + 1)] = new KeyValuePair<RequestPathSegment, RequestPathSegment>(
                    requestPath[i * 2],
                    requestPath[i * 2 + 1]);
            }

            return pairs;
        }
    }

    private static IReadOnlyList<ContextualParameter> BuildSecondaryContextualParameters(RequestPathPattern contextualPath, RequestPathPattern secondaryContextualPath, Func<string, FieldProvider> fieldSelector)
    {
        try
        {
            // for secondary contextual path, we first trim off the main contextual path part from it
            var extraContextualPath = contextualPath.TrimAncestorFrom(secondaryContextualPath);
            return BuildSecondaryContextualParametersCore(extraContextualPath, fieldSelector);
        }
        catch (InvalidOperationException ex)
        {
            // Report diagnostic for malformed resource structure
            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                code: "malformed-resource-detected",
                message: $"The secondary request path '{secondaryContextualPath}' has a malformed structure: {ex.Message}"
            );
            // Return empty list to allow graceful degradation
            return [];
        }

        static List<ContextualParameter> BuildSecondaryContextualParametersCore(RequestPathPattern extraPath, Func<string, FieldProvider> fieldSelector)
        {
            var result = new List<ContextualParameter>();
            // iterate the secondary contextual path segments by pairs
            for (int i = 0; i < extraPath.Count - 1; i += 2)
            {
                var key = extraPath[i];
                var value = extraPath[i + 1]; // this would never be out of range.

                if (key.IsConstant && value.IsConstant)
                {
                    continue;
                }
                if (!key.IsConstant)
                {
                    // Handle the case when key is a variable
                    var keyContextualParameter = new ContextualParameter(key.VariableName, key.VariableName, _ => fieldSelector(key.VariableName));
                    result.Add(keyContextualParameter);
                    if (!value.IsConstant)
                    {
                        // in this case we need to build a contextual parameter for the value too
                        var valueContextualParameter = new ContextualParameter(value.VariableName, value.VariableName, _ => fieldSelector(value.VariableName));
                        result.Add(valueContextualParameter);
                    }
                }
                else if (!value.IsConstant)
                {
                    // in this case we need to build a contextual parameter
                    var contextualParameter = new ContextualParameter(key.Value, value.VariableName, _ => fieldSelector(value.VariableName));
                    result.Add(contextualParameter);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Builds a mapping from operation path parameters to contextual parameters.
    /// Parameters are matched based on the position of their variable segments within the shared
    /// prefix between the operation path and the contextual (and secondary contextual) paths.
    /// </summary>
    /// <remarks>
    /// When <see cref="ConstantPathParameters"/> is set (for resources expanded from dynamic parent types),
    /// the operation path is first transformed to substitute constant parameter variables with their literal values.
    /// This allows the segment matching to work correctly even when the operation path uses variable segments
    /// (e.g., {parentType}) where the contextual path has constants (e.g., "topics").
    /// The constant parameters are added as contextual mappings that emit literal string values.
    /// </remarks>
    /// <param name="operationPath">The operation's request path.</param>
    /// <returns>A parameter mapping that maps operation parameter names to contextual parameters.</returns>
    public ParameterContextRegistry BuildParameterMapping(RequestPathPattern operationPath)
    {
        // If there are constant path parameters, substitute them in the operation path
        // so that segment matching works correctly between the contextual and operation paths.
        var (effectiveOperationPath, constantMappings) = ConstantPathParameters is { Count: > 0 }
            ? SubstituteConstantParameters(operationPath, ConstantPathParameters)
            : (operationPath, (IReadOnlyList<ParameterContextMapping>)Array.Empty<ParameterContextMapping>());

        // we need to find the sharing part between contextual path and the incoming path
        var sharedSegmentsCount = RequestPathPattern.GetMaximumSharingSegmentsCount(ContextualPath, effectiveOperationPath);

        // then find the sharing part between secondary contextual path and the incoming path
        int secondarySharedSegmentsCount = 0;
        if (SecondaryContextualPath != null)
        {
            secondarySharedSegmentsCount = RequestPathPattern.GetMaximumSharingSegmentsCount(SecondaryContextualPath, effectiveOperationPath);
        }

        var mappings = BuildParameterMappingCore(ContextualPathParameters, SecondaryContextualPathParameters, effectiveOperationPath, sharedSegmentsCount, secondarySharedSegmentsCount);

        return new ParameterContextRegistry([.. mappings, .. constantMappings]);
    }

    /// <summary>
    /// Substitutes constant path parameters in the operation path, replacing variable segments
    /// with their constant values. Returns the rewritten path along with contextual mappings
    /// for each substituted parameter that emit the literal string value.
    /// </summary>
    private static (RequestPathPattern Path, IReadOnlyList<ParameterContextMapping> Mappings) SubstituteConstantParameters(
        RequestPathPattern operationPath,
        IReadOnlyDictionary<string, string> constantPathParameters)
    {
        var segments = new List<RequestPathSegment>(operationPath.Count);
        var mappings = new List<ParameterContextMapping>();
        bool anySubstituted = false;

        for (int i = 0; i < operationPath.Count; i++)
        {
            var segment = operationPath[i];
            if (!segment.IsConstant && constantPathParameters.TryGetValue(segment.VariableName, out var constantValue))
            {
                segments.Add(new RequestPathSegment(constantValue));
                anySubstituted = true;

                mappings.Add(new ParameterContextMapping(
                    segment.VariableName,
                    new ContextualParameter(constantValue, segment.VariableName, _ => Snippet.Literal(constantValue))));
            }
            else
            {
                segments.Add(segment);
            }
        }

        return (anySubstituted ? new RequestPathPattern(segments) : operationPath, mappings);
    }

    private static IReadOnlyList<ParameterContextMapping> BuildParameterMappingCore(
        IReadOnlyList<ContextualParameter> contextualParameters, IReadOnlyList<ContextualParameter> extraContextualParameters,
        RequestPathPattern operationPath, int sharedSegmentsCount, int secondarySharedSegmentsCount)
    {
        var parameterMappings = new List<ParameterContextMapping>();
        var consumedContextualParameters = 0;
        var consumedSecondaryContextualParameters = 0;
        for (int i = 0; i < operationPath.Count; i++)
        {
            var segment = operationPath[i];
            // skip all the constant segments
            if (segment.IsConstant)
            {
                continue;
            }
            // we can only assign contextual parameters when we are in the shared segments area where this part could be found in the contextual path.
            if (i < sharedSegmentsCount && consumedContextualParameters < contextualParameters.Count)
            {
                // we are in the area of contextual paths
                var mapping = new ParameterContextMapping(segment.VariableName, contextualParameters[consumedContextualParameters]);
                parameterMappings.Add(mapping);
                consumedContextualParameters++;
            }
            else if (i < secondarySharedSegmentsCount && consumedSecondaryContextualParameters < extraContextualParameters.Count)
            {
                // we are in the area of secondary contextual paths
                var mapping = new ParameterContextMapping(segment.VariableName, extraContextualParameters[consumedSecondaryContextualParameters]);
                parameterMappings.Add(mapping);
                consumedSecondaryContextualParameters++;
            }
            else
            {
                var mapping = new ParameterContextMapping(segment.VariableName, null);
                parameterMappings.Add(mapping);
            }
        }
        return parameterMappings;
    }
}
