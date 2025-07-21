// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

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
            foreach (var inputClient in resourceMetadata.MethodToClientMap.Values.Distinct())
            {
                var restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
                var restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, restClientProvider.Type, ResourceHelpers.GetRestClientFieldName(restClientProvider.Name), clientProvider);

                var clientDiagnosticsFieldName = ResourceHelpers.GetClientDiagnosticFieldName(restClientProvider.Name);
                var clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), clientDiagnosticsFieldName, clientProvider);

                clientInfos[inputClient] = new RestClientInfo(restClientProvider, restClientField, clientDiagnosticsField);
            }

            return clientInfos;
        }

        /// <summary>
        /// Gets the RestClientInfo for a specific service method based on the method-to-client mapping.
        /// </summary>
        /// <param name="resourceMetadata">The resource metadata containing the method to client mapping.</param>
        /// <param name="serviceMethod">The service method to get the rest client info for.</param>
        /// <param name="clientInfos">The dictionary mapping InputClient to RestClientInfo.</param>
        /// <returns>The RestClientInfo for the specified service method.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no client mapping is found for the service method.</exception>
        internal static RestClientInfo GetRestClientForServiceMethod(this ResourceMetadata resourceMetadata, InputServiceMethod serviceMethod, Dictionary<InputClient, RestClientInfo> clientInfos)
        {
            if (!resourceMetadata.MethodToClientMap.TryGetValue(serviceMethod.CrossLanguageDefinitionId, out var inputClient))
            {
                throw new InvalidOperationException($"No client mapping found for resource method {serviceMethod.Name}");
            }

            return clientInfos[inputClient];
        }
    }
}
