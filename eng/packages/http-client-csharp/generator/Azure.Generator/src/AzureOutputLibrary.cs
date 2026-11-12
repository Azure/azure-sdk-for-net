// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        private readonly Dictionary<(InputLongRunningServiceMethod, ClientProvider), LroOperationProvider[]> _lroOperations = new();
        private readonly List<LroStatusMetadataProvider> _lroMetadata = new();

        internal LroOperationProvider? GetLroOperation(InputServiceMethod method, ClientProvider client, bool protocol)
        {
            if (method is not InputLongRunningServiceMethod lro ||
                (lro.LongRunningServiceMetadata.StatusMetadata.Count == 0 && lro.LongRunningServiceMetadata.OperationId.Count == 0))
            {
                return null;
            }
            if (!_lroOperations.TryGetValue((lro, client), out var operations))
            {
                var name = $"{client.Name}{lro.Name.ToIdentifierName()}";
                var modifiers = (client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) && lro.Accessibility != "internal"
                    ? TypeSignatureModifiers.Public : TypeSignatureModifiers.Internal) | TypeSignatureModifiers.Partial;
                var metadata = lro.LongRunningServiceMetadata.StatusMetadata.Count > 0
                    ? new LroStatusMetadataProvider($"{name}OperationMetadata", client.Type.Namespace, lro.LongRunningServiceMetadata.StatusMetadata, modifiers)
                    : null;
                if (metadata is not null)
                {
                    _lroMetadata.Add(metadata);
                }
                var resultType = lro.Response.Type is null ? null : AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(lro.Response.Type);
                var convenience = new LroOperationProvider(lro, client, $"{name}Operation", resultType, metadata, modifiers);
                operations =
                [
                    convenience,
                    resultType is null ? convenience : new LroOperationProvider(lro, client, $"{name}RawOperation", typeof(BinaryData), metadata, modifiers)
                ];
                _lroOperations.Add((lro, client), operations);
            }
            return operations[protocol ? 1 : 0];
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var types = base.BuildTypeProviders();
            var publicClients = types.OfType<ClientProvider>().Where(
                client => client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)).ToList();
            foreach (var client in types.OfType<ClientProvider>())
            {
                foreach (var method in client.Methods.OfType<ScmMethodProvider>())
                {
                    if (method.ServiceMethod is { } serviceMethod)
                    {
                        GetLroOperation(serviceMethod, client, method.Kind == ScmMethodKind.Protocol);
                    }
                }
            }

            // Only emit ClientBuilderExtensions for libraries that already ship it (backcompat).
            // Newly generated libraries do not get this Microsoft.Extensions.Azure integration type.
            ClientBuilderExtensionsDefinition? clientBuilderExtensions = null;
            if (publicClients.Count > 0)
            {
                var candidate = new ClientBuilderExtensionsDefinition(publicClients);
                if (candidate.LastContractView is not null)
                {
                    clientBuilderExtensions = candidate;
                }
            }

            return
            [
                .. types,
                .. _lroOperations.Values.SelectMany(p => p).Distinct(),
                .. _lroMetadata,
                new RequestContextExtensionsDefinition(),
                AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition,
                AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition,
                .. clientBuilderExtensions is not null ? [clientBuilderExtensions] : Array.Empty<TypeProvider>(),
                .. publicClients.Where(c => c.ClientSettings != null).Select(c => new ClientHostExtensionsDefinition(c))
            ];
        }
    }
}
