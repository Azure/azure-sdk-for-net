// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        private readonly Dictionary<(InputLongRunningServiceMethod, ClientProvider), LroOperationProvider> _lroOperations = new();
        private HashSet<string>? _reservedLroNames;

        /// <summary>
        /// Gets the internal operation type generated for a convenience method of an LRO with selected status metadata.
        /// </summary>
        internal LroOperationProvider? GetLroOperation(InputServiceMethod method, ClientProvider client)
        {
            if (method is not InputLongRunningServiceMethod { GenerateConvenient: true } lro || lro.LongRunningServiceMetadata.StatusMetadata.Count == 0)
            {
                return null;
            }
            if (!_lroOperations.TryGetValue((lro, client), out var operation))
            {
                var resultType = lro.Response.Type is null ? null : AzureClientGenerator.Instance.TypeFactory.CreateCSharpType(lro.Response.Type);
                operation = new LroOperationProvider(lro, client, $"{ReserveLroName(lro, client)}Operation", resultType);
                _lroOperations.Add((lro, client), operation);
            }
            return operation;
        }

        private string ReserveLroName(InputLongRunningServiceMethod method, ClientProvider client)
        {
            if (_reservedLroNames is null)
            {
                var input = AzureClientGenerator.Instance.InputLibrary.InputNamespace;
                _reservedLroNames = new HashSet<string>(
                    input.Models.Select(m => m.Name).Concat(input.Enums.Select(e => e.Name)).Concat(input.Clients.Select(c => c.Name))
                        .Select(n => n.ToIdentifierName()),
                    StringComparer.OrdinalIgnoreCase);
            }

            var methodName = method.Name.ToIdentifierName();
            var name = methodName;
            for (var suffix = 2; _reservedLroNames.Contains($"{name}Operation"); suffix++)
            {
                name = suffix == 2 ? $"{client.Name}{methodName}" : $"{client.Name}{methodName}{suffix - 1}";
            }
            _reservedLroNames.Add($"{name}Operation");
            return name;
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var types = base.BuildTypeProviders();
            foreach (var client in types.OfType<ClientProvider>())
            {
                foreach (var method in client.Methods.OfType<ScmMethodProvider>())
                {
                    if (method.ServiceMethod is { } serviceMethod)
                    {
                        GetLroOperation(serviceMethod, client);
                    }
                }
            }
            var publicClients = types.OfType<ClientProvider>().Where(
                client => client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)).ToList();

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
                .. _lroOperations.Values,
                new RequestContextExtensionsDefinition(),
                AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition,
                AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition,
                .. clientBuilderExtensions is not null ? [clientBuilderExtensions] : Array.Empty<TypeProvider>(),
                .. publicClients.Where(c => c.ClientSettings != null).Select(c => new ClientHostExtensionsDefinition(c))
            ];
        }
    }
}
