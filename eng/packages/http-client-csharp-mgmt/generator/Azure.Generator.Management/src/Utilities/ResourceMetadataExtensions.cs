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
            foreach (var (_, _, inputClient) in resourceMetadata.Methods)
            {
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
    }
}
