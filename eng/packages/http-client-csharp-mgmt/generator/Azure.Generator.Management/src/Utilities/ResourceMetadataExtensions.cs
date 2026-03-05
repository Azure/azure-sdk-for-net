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
    internal static class ResourceMetadataExtensions
    {
        /// <summary>
        /// Creates a dictionary mapping InputClient to RestClientInfo for all distinct clients used by the resource.
        /// </summary>
        /// <param name="resourceMetadata">The resource metadata containing the method to client mapping.</param>
        /// <param name="clientProvider">The client provider that will own the fields.</param>
        /// <returns>A dictionary mapping InputClient to RestClientInfo.</returns>
        internal static Dictionary<InputClient, RestClientInfo> CreateClientInfosMap(this ResourceMetadata resourceMetadata, TypeProvider clientProvider)
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

        public static ResourceMethodCategory CategorizeMethods(this ResourceMetadata resourceMetadata)
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
                    case ResourceOperationKind.Update:
                        hasUpdateMethod = true;
                        methodsInResource.Add(method);
                        break;
                    case ResourceOperationKind.Delete:
                        // only resource has get
                        methodsInResource.Add(method);
                        break;
                    case ResourceOperationKind.Action:
                        // actions should all go to the resource
                        methodsInResource.Add(method);
                        break;
                    case ResourceOperationKind.List:
                        // list method goes to resource if the method's resource scope matches the resource's ID pattern
                        // This handles cases like listByParent where we list children of a specific parent instance
                        if (method.ResourceScope == resourceMetadata.ResourceIdPattern)
                        {
                            methodsInResource.Add(method);
                        }
                        // list methods might go to the collection or the extension
                        // when the resource has a parent
                        else if (resourceMetadata.ParentResourceId is not null)
                        {
                            if (method.ResourceScope == resourceMetadata.ParentResourceId)
                            {
                                methodsInCollection.Add(method);
                            }
                            // Handle cross-scope parent: when the list operation's scope differs from the
                            // parent's scope (e.g., tenant-scoped list with subscription-scoped parent),
                            // check if the operation path structurally matches "list children of this resource"
                            // by verifying the path equals the resource ID pattern minus the last segment.
                            else if (IsListChildrenPath(method.OperationPath, resourceMetadata.ResourceIdPattern))
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
                            if (method.OperationScope == resourceMetadata.ResourceScope)
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

        /// <summary>
        /// Checks if the operation path is a "list children" path for the given resource,
        /// i.e., the resource ID pattern with the last segment (resource name) removed.
        /// This handles cross-scope scenarios where the list path and resource ID pattern
        /// share the same resource type structure but differ in scope prefix.
        /// </summary>
        private static bool IsListChildrenPath(string operationPath, string resourceIdPattern)
        {
            // Strip the last segment (the resource name parameter) from the resource ID pattern
            // e.g., "/providers/Microsoft.Support/supportTickets/{name}/chatTranscripts/{chatTranscriptName}"
            //     → "/providers/Microsoft.Support/supportTickets/{name}/chatTranscripts"
            var lastSlash = resourceIdPattern.LastIndexOf('/');
            if (lastSlash <= 0)
            {
                return false;
            }

            var parentPath = resourceIdPattern.Substring(0, lastSlash);
            return operationPath == parentPath;
        }
    }
}
