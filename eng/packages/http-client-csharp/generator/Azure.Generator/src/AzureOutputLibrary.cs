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
        private readonly Dictionary<(InputLongRunningServiceMethod, ClientProvider), LroOperationProvider> _lroOperations = new();
        private HashSet<string>? _reservedLroNames;

        private string ReserveLroName(InputLongRunningServiceMethod method, ClientProvider client)
        {
            if (_reservedLroNames is null)
            {
                var input = AzureClientGenerator.Instance.InputLibrary.InputNamespace;
                _reservedLroNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var existingName in input.Models.Select(m => m.Name).Concat(input.Enums.Select(e => e.Name))
                    .Concat(input.Clients.Select(c => c.Name)))
                {
                    _reservedLroNames.Add(existingName.ToIdentifierName());
                }
            }

            var methodName = method.Name.ToIdentifierName();
            var name = $"{methodName}Operation";
            var suffix = 2;
            while (_reservedLroNames.Contains(name))
            {
                name = suffix == 2 ? $"{client.Name}{methodName}Operation" : $"{client.Name}{methodName}{suffix - 1}Operation";
                suffix++;
            }
            _reservedLroNames.Add(name);
            return name;
        }

        /// <summary>
        /// Gets the internal operation type that exposes the <c>@lroOperationId</c> selection as <see cref="Azure.Operation.Id"/>
        /// for the protocol method of <paramref name="method"/>, or null when the operation has no selected ID.
        /// </summary>
        internal LroOperationProvider? GetLroOperation(InputServiceMethod method, ClientProvider client)
        {
            if (method is not InputLongRunningServiceMethod lro || lro.LongRunningServiceMetadata.OperationId.Count == 0)
            {
                return null;
            }
            if (!_lroOperations.TryGetValue((lro, client), out var operation))
            {
                operation = new LroOperationProvider(lro, client, ReserveLroName(lro, client));
                _lroOperations.Add((lro, client), operation);
            }
            return operation;
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
                    if (method.Kind == ScmMethodKind.Protocol && method.ServiceMethod is { } serviceMethod)
                    {
                        GetLroOperation(serviceMethod, client);
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
