// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Builds the public GetAll method for a resource collection whose backing list operations come
    /// from more than one ARM scope (e.g. PolicyAssignment, RoleAssignment, EventSubscription).
    ///
    /// The generated method has a single signature derived from the intersection of non-path
    /// parameters across candidates. The body is an <c>if (Id.ResourceType == X.ResourceType) { ... }</c>
    /// dispatch that selects the right underlying REST collection result per branch, sourcing all
    /// path arguments from <see cref="ArmResource.Id"/>.
    /// </summary>
    internal sealed class AggregatedPageableOperationMethodProvider
    {
        private readonly TypeProvider _enclosingType;
        private readonly ListOperationSet _set;
        private readonly bool _isAsync;
        private readonly string _methodName;
        private readonly ResourceClientProvider _resource;
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;
        private readonly List<PageableOperationMethodProvider> _candidateProviders;
        private readonly PageableOperationMethodProvider? _fallbackProvider;

        public AggregatedPageableOperationMethodProvider(
            TypeProvider enclosingType,
            ListOperationSet set,
            bool isAsync,
            string methodName,
            ResourceClientProvider resource)
        {
            _enclosingType = enclosingType;
            _set = set;
            _isAsync = isAsync;
            _methodName = methodName;
            _resource = resource;

            _candidateProviders = set.Candidates.Select(BuildCandidateProvider).ToList();
            _fallbackProvider = set.FallbackCandidate is { } fallback ? BuildCandidateProvider(fallback) : null;

            // Build a UNION of non-path parameters across candidates (and fallback) deduped by name.
            // The inner candidate bodies reference parameters by identifier; any parameter present
            // in at least one branch's underlying REST op must be in the outer signature so that
            // code in any branch compiles. Parameters absent from a given branch's body are simply
            // unused inside that branch (silently ignored when dispatching to that scope) — this
            // mirrors the legacy AutoRest pattern's tolerance for divergent backing operations.
            var template = _fallbackProvider?.Signature ?? _candidateProviders[0].Signature;
            _signature = BuildUnionSignature(template, _methodName);
            _bodyStatements = BuildBodyStatements();
        }

        public static implicit operator MethodProvider(AggregatedPageableOperationMethodProvider aggregator)
        {
            var methodProvider = new MethodProvider(
                aggregator._signature,
                aggregator._bodyStatements,
                aggregator._enclosingType);

            // Aggregate XML docs: list every backing operation's Request Path / Operation Id.
            // Use the first candidate as the primary entry; supplement with others.
            var primary = aggregator._candidateProviders[0];
            ResourceHelpers.BuildEnhancedXmlDocs(
                primary.Method,
                primary.ConvenienceMethod.Signature.Description,
                aggregator._enclosingType,
                methodProvider.XmlDocs);

            return methodProvider;
        }

        private PageableOperationMethodProvider BuildCandidateProvider(ListCandidate candidate)
        {
            if (candidate.Method.InputMethod is not InputPagingServiceMethod paging)
            {
                throw new InvalidOperationException(
                    $"Aggregated GetAll only supports paged list operations; got '{candidate.Method.InputMethod.GetType().Name}'.");
            }

            return new PageableOperationMethodProvider(
                _enclosingType,
                candidate.OperationContext,
                candidate.RestClientInfo,
                paging,
                _isAsync,
                methodName: _methodName,
                explicitResourceClient: _resource);
        }

        private MethodBodyStatement[] BuildBodyStatements()
        {
            // Compose:
            //   if (Id.ResourceType == X.ResourceType) { <candidateX-body> }
            //   else if (Id.ResourceType == Y.ResourceType) { <candidateY-body> }
            //   ...
            //   else { <fallback-body OR throw> }
            MethodBodyStatement elseBranch = _fallbackProvider is not null
                ? new MethodBodyStatements(_fallbackProvider.BodyStatements)
                : BuildThrowForUnknownScope();

            // Build chain from the inside out (last branch first).
            for (int i = _candidateProviders.Count - 1; i >= 0; i--)
            {
                var candidate = _set.Candidates[i];
                var provider = _candidateProviders[i];
                var dispatchType = candidate.DispatchResourceType
                    ?? throw new InvalidOperationException(
                        "Non-fallback list candidate must have a DispatchResourceType for runtime dispatch.");

                var condition = This.As<ArmResource>().Id().ResourceType()
                    .Equal(Static(dispatchType).As<ArmResource>().ResourceType());

                elseBranch = new IfElseStatement(
                    condition,
                    new MethodBodyStatements(provider.BodyStatements),
                    elseBranch);
            }

            return [elseBranch];
        }

        private MethodBodyStatement BuildThrowForUnknownScope()
        {
            // throw new InvalidOperationException($"Listing {ResourceName} is not supported for resource type '{Id.ResourceType}'.");
            var resourceTypeExpr = This.As<ArmResource>().Id().ResourceType();
            var message = new FormattableStringExpression(
                $"Listing {_resource.ResourceName} is not supported for resource type '{{0}}'.",
                [resourceTypeExpr]);
            return Throw(New.Instance(typeof(InvalidOperationException), message));
        }

        private MethodSignature BuildUnionSignature(MethodSignature template, string newName)
        {
            // Collect parameters across all per-candidate signatures (candidates + fallback) so the
            // outer aggregated method exposes the union of every backing op's non-path parameters.
            // Each per-candidate PageableOperationMethodProvider already filters out path params
            // (they come from Id via the candidate's OperationContext), so what remains is exactly
            // the user-visible query/cancellation surface.
            var allProviders = new List<PageableOperationMethodProvider>(_candidateProviders);
            if (_fallbackProvider is not null)
            {
                allProviders.Add(_fallbackProvider);
            }

            var byName = new Dictionary<string, Microsoft.TypeSpec.Generator.Providers.ParameterProvider>(StringComparer.Ordinal);
            var ordered = new List<Microsoft.TypeSpec.Generator.Providers.ParameterProvider>();
            Microsoft.TypeSpec.Generator.Providers.ParameterProvider? cancellationToken = null;

            foreach (var p in allProviders)
            {
                foreach (var param in p.Signature.Parameters)
                {
                    // Keep the cancellation token last; all candidates produce equivalent ones.
                    if (param.Type.FrameworkType == typeof(System.Threading.CancellationToken))
                    {
                        cancellationToken ??= param;
                        continue;
                    }

                    if (byName.ContainsKey(param.Name))
                    {
                        continue;
                    }

                    byName[param.Name] = param;
                    ordered.Add(param);
                }
            }

            if (cancellationToken is not null)
            {
                ordered.Add(cancellationToken);
            }

            return new MethodSignature(
                newName,
                template.Description,
                template.Modifiers,
                template.ReturnType,
                template.ReturnDescription,
                ordered,
                template.Attributes,
                template.GenericArguments,
                template.GenericParameterConstraints,
                template.ExplicitInterface,
                template.NonDocumentComment);
        }

        private static MethodSignature RenameSignature(MethodSignature template, string newName)
        {
            return new MethodSignature(
                newName,
                template.Description,
                template.Modifiers,
                template.ReturnType,
                template.ReturnDescription,
                template.Parameters,
                template.Attributes,
                template.GenericArguments,
                template.GenericParameterConstraints,
                template.ExplicitInterface,
                template.NonDocumentComment);
        }
    }
}
