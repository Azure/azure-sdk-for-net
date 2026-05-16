// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Management.Utilities
{
    internal static class ArmResourceMetadataExtensions
    {
        extension(ArmResourceMetadata resourceMetadata)
        {
            /// <summary>
            /// Creates a dictionary mapping InputClient to RestClientInfo for all distinct clients used by the resource.
            /// </summary>
            /// <param name="clientProvider">The client provider that will own the fields.</param>
            /// <returns>A dictionary mapping InputClient to RestClientInfo.</returns>
            internal Dictionary<InputClient, RestClientInfo> CreateClientInfosMap(TypeProvider clientProvider)
            {
                var clientInfos = new Dictionary<InputClient, RestClientInfo>();

                // Create rest client providers and fields for each unique InputClient
                foreach (var resourceMethod in resourceMetadata.Methods)
                {
                    var inputClient = resourceMethod.InputClient;
                    if (clientInfos.ContainsKey(inputClient))
                    {
                        continue; // Skip if the client is already processed
                    }

                    var restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
                    var restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, restClientProvider.Type, ResourceHelpers.GetRestClientFieldName(restClientProvider.Name), clientProvider);

                    var clientDiagnosticsFieldName = ResourceHelpers.GetClientDiagnosticsFieldName(restClientProvider.Name);
                    var clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), clientDiagnosticsFieldName, clientProvider);

                    clientInfos.Add(inputClient, new RestClientInfo(restClientProvider, restClientField, clientDiagnosticsField));
                }

                return clientInfos;
            }

            /// <summary>
            /// Categorizes the resource methods into resource, collection, and extension method groups.
            /// </summary>
            internal ResourceMethodCategory CategorizeMethods()
            {
                var methodsInResource = new List<ResourceMethod>();
                var methodsInCollection = new List<ResourceMethod>();
                var methodsInExtension = new List<ResourceMethod>();
                bool hasUpdateMethod = false;
                ResourceMethod? createMethod = null;

                // Pre-compute: for resources without a discrete ParentResourceId (extension/
                // scope-based or tenant-rooted), detect when MULTIPLE list ops share the same
                // type-signature tail as the resource. In that case all such ops belong to the
                // collection's aggregated GetAll (PolicyAssignment-like multi-scope dispatch).
                // For single-candidate cases preserve the previous scope.Kind equality behavior
                // so single-scope list ops continue to be emitted as parent-resource Pageable
                // extension methods.
                var multiScopeListOps = ComputeMultiScopeListOpsForCollection(resourceMetadata);

                foreach (var method in resourceMetadata.Methods)
                {
                    var isSingleton = resourceMetadata.SingletonResourceName is not null;
                    switch (method.Kind)
                    {
                        case ResourceOperationKind.Create:
                            // create method will go to the collection, or to resource when it is singleton
                            if (isSingleton)
                            {
                                methodsInResource.Add(method);
                            }
                            else
                            {
                                methodsInCollection.Add(method);
                            }
                            createMethod = method;
                            break;
                        case ResourceOperationKind.Read:
                            // both resource and collection should have read method
                            methodsInResource.Add(method);
                            methodsInCollection.Add(method);
                            break;
                        case ResourceOperationKind.Update:
                            hasUpdateMethod = true;
                            methodsInResource.Add(method);
                            break;
                        case ResourceOperationKind.Delete:
                            // only resource has delete
                            methodsInResource.Add(method);
                            break;
                        case ResourceOperationKind.Action:
                            // actions should all go to the resource
                            methodsInResource.Add(method);
                            break;
                        case ResourceOperationKind.List:
                            // list method goes to resource if the method's resource scope matches the resource's ID pattern
                            // This handles cases like listByParent where we list children of a specific parent instance
                            if (method.Scope.ScopeIdPattern == resourceMetadata.ResourceIdPattern)
                            {
                                methodsInResource.Add(method);
                            }
                            // list methods might go to the collection or the extension
                            // when the resource has a parent
                            else if (resourceMetadata.ParentResourceId is not null)
                            {
                                if (method.Scope.ScopeIdPattern == resourceMetadata.ParentResourceId)
                                {
                                    methodsInCollection.Add(method);
                                }
                                else
                                {
                                    methodsInExtension.Add(method);
                                }
                            }
                            else
                            {
                                // For resources without a discrete ParentResourceId (extension/scope-based
                                // resources, tenant-rooted resources), a list operation belongs to the
                                // collection iff it is one of MULTIPLE list ops whose path tail matches
                                // the resource (multi-scope dispatch). For a single-candidate case we
                                // preserve the original scope.Kind equality behavior so that a lone
                                // single-scope list op continues to be emitted as a Pageable extension
                                // on the parent resource (subscription/RG/MG/tenant).
                                if (multiScopeListOps.Contains(method))
                                {
                                    methodsInCollection.Add(method);
                                }
                                else if (method.Scope.Kind == resourceMetadata.Scope.Kind)
                                {
                                    methodsInCollection.Add(method);
                                }
                                else
                                {
                                    // otherwise, it is an extension method
                                    methodsInExtension.Add(method);
                                }
                            }
                            break;
                        default:
                            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                                "general-warning",
                                $"Unknown resource operation kind '{method.Kind}' for method '{method.OperationPath}' in resource '{resourceMetadata.ResourceIdPattern}'.");
                            break;
                    }
                }

                // For non-singleton resource, if there is no update method, we will add the create method as update to the resource methods.
                if (resourceMetadata.SingletonResourceName is null && !hasUpdateMethod && createMethod is not null)
                {
                    methodsInResource.Add(createMethod);
                }

                return new(methodsInResource, methodsInCollection, methodsInExtension);
            }
        }

        /// <summary>
        /// Returns the set of list operations from <paramref name="resourceMetadata"/> whose path
        /// tail matches the resource's type-signature tail (see <see cref="IsCollectionScopeListOperation"/>),
        /// but only if there are at least 2 such operations AND the resource has no discrete
        /// parent resource id. This signals that aggregated multi-scope dispatch is needed on
        /// the collection's GetAll.
        /// </summary>
        private static HashSet<ResourceMethod> ComputeMultiScopeListOpsForCollection(ArmResourceMetadata resourceMetadata)
        {
            var empty = new HashSet<ResourceMethod>();
            if (resourceMetadata.ParentResourceId is not null)
            {
                return empty;
            }
            // Multi-scope dispatch is only meaningful when the collection accepts ANY ArmResource
            // as its parent (Extension-scoped resources like PolicyAssignment, RoleAssignment).
            // For resources whose collection is bound to a specific parent type (Subscription /
            // ResourceGroup / ManagementGroup / Tenant), the legacy pattern of putting cross-scope
            // list ops on the parent resource as Pageable extension methods is correct - the
            // collection itself is keyed to one scope, so dispatch branches would be unreachable.
            if (resourceMetadata.Scope.Kind != ResourceScope.Extension)
            {
                return empty;
            }

            var matches = new List<ResourceMethod>();
            foreach (var m in resourceMetadata.Methods)
            {
                if (m.Kind != ResourceOperationKind.List)
                {
                    continue;
                }
                if (m.Scope.ScopeIdPattern == resourceMetadata.ResourceIdPattern)
                {
                    continue;
                }
                if (IsCollectionScopeListOperation(m.OperationPath, resourceMetadata.ResourceIdPattern))
                {
                    matches.Add(m);
                }
            }

            if (matches.Count < 2)
            {
                return empty;
            }

            return new HashSet<ResourceMethod>(matches);
        }

        /// <summary>
        /// Returns true when <paramref name="operationPath"/> is a list operation that targets the
        /// same resource collection as <paramref name="resourceIdPattern"/>. The resource path
        /// terminates with "...&lt;type signature&gt;/{name}". The list op's path should end with
        /// the same type signature (the segments from the LAST '/providers/' segment in the
        /// resource path through the segment just before "{name}"). The segments BEFORE that
        /// type-signature tail represent the operation's scope (subscription, RG, MG, or any
        /// parent ARM resource id) and can differ between candidate list ops.
        /// </summary>
        internal static bool IsCollectionScopeListOperation(RequestPathPattern operationPath, RequestPathPattern resourceIdPattern)
        {
            var opPath = operationPath;
            var resPath = resourceIdPattern;
            // The resource pattern must end with a parameter segment ("{name}").
            if (resPath.Count < 2)
            {
                return false;
            }
            // Find the LAST '/providers/' literal segment in the resource path. The segments
            // from there through resPath[^2] (i.e. excluding the trailing {name}) form the
            // resource's type-signature tail (e.g. "providers/<ns>/<type>" or, for nested
            // sub-types, "providers/<ns>/<parentType>/{parentName}/<childType>").
            int providersIdx = -1;
            for (int i = resPath.Count - 2; i >= 0; i--)
            {
                if (resPath[i].IsProvidersSegment)
                {
                    providersIdx = i;
                    break;
                }
            }
            if (providersIdx < 0)
            {
                return false;
            }
            int tailLength = (resPath.Count - 1) - providersIdx; // segments [providersIdx..^2]
            if (opPath.Count < tailLength)
            {
                return false;
            }
            // The op path's tail of equal length must match the resource's type-signature tail.
            int opTailStart = opPath.Count - tailLength;
            // First segment of the op tail must be the same 'providers' literal.
            if (!opPath[opTailStart].IsProvidersSegment)
            {
                return false;
            }
            for (int k = 0; k < tailLength; k++)
            {
                if (!resPath[providersIdx + k].Equals(opPath[opTailStart + k]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
