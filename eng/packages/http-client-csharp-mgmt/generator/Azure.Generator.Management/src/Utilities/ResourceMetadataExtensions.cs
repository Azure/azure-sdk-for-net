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
                        break;
                    case ResourceOperationKind.Get:
                        // both resource and collection should have get method
                        methodsInResource.Add(method);
                        methodsInCollection.Add(method);
                        break;
                    case ResourceOperationKind.Update:
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

            return new(methodsInResource, methodsInCollection, methodsInExtension);
        }
    }
}
