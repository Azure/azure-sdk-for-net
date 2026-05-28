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
            /// Creates a dictionary mapping InputClient to RestClientInfo for the distinct clients
            /// actually used by the supplied <paramref name="methods"/>.
            /// </summary>
            /// <param name="clientProvider">The client provider that will own the fields.</param>
            /// <param name="methods">The subset of resource methods that will be emitted on the
            /// owning client provider (e.g. only the methods placed on the collection class).
            /// Passing all of <c>resourceMetadata.Methods</c> here causes unused diagnostics/REST
            /// client fields to be emitted for operation groups whose operations are not actually
            /// referenced by the owning class. See https://github.com/Azure/azure-sdk-for-net/issues/59242.</param>
            /// <returns>A dictionary mapping InputClient to RestClientInfo.</returns>
            internal Dictionary<InputClient, RestClientInfo> CreateClientInfosMap(TypeProvider clientProvider, IEnumerable<ResourceMethod> methods)
            {
                var clientInfos = new Dictionary<InputClient, RestClientInfo>();

                // Determine the set of InputClients actually referenced by the supplied methods.
                var referencedClients = new HashSet<InputClient>();
                foreach (var method in methods)
                {
                    referencedClients.Add(method.InputClient);
                }

                // Iterate resourceMetadata.Methods (rather than `methods`) to preserve the original
                // declaration order of REST client fields, which keeps regenerated SDK diffs minimal
                // when this filter is introduced.
                foreach (var resourceMethod in resourceMetadata.Methods)
                {
                    var inputClient = resourceMethod.InputClient;
                    if (!referencedClients.Contains(inputClient))
                    {
                        continue; // Skip clients not referenced by any emitted method on the owning class
                    }
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
                        case ResourceOperationKind.CheckExistence:
                            methodsInResource.Add(method);
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
                        case ResourceOperationKind.CollectionAction:
                            if (isSingleton)
                            {
                                methodsInResource.Add(method);
                            }
                            else
                            {
                                methodsInCollection.Add(method);
                            }
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
                                if (method.Scope.Kind == resourceMetadata.Scope.Kind)
                                {
                                    // if the operation scope is the resource scope, it is a collection method
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
    }
}
