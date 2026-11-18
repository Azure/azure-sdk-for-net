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
        private readonly HashSet<ClientProvider> _clientsWithLroMethods = new();
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
            var name = methodName;
            var suffix = 2;
            while (_reservedLroNames.Contains($"{name}Operation") ||
                   _reservedLroNames.Contains($"{name}RawOperation") ||
                   _reservedLroNames.Contains($"{name}OperationMetadata"))
            {
                name = suffix == 2 ? $"{client.Name}{methodName}" : $"{client.Name}{methodName}{suffix - 1}";
                suffix++;
            }
            _reservedLroNames.Add($"{name}Operation");
            _reservedLroNames.Add($"{name}RawOperation");
            _reservedLroNames.Add($"{name}OperationMetadata");
            return name;
        }

        internal LroOperationProvider? GetLroOperation(InputServiceMethod method, ClientProvider client, bool protocol)
        {
            if (method is not InputLongRunningServiceMethod lro ||
                (lro.LongRunningServiceMetadata.StatusMetadata.Count == 0 && lro.LongRunningServiceMetadata.OperationId.Count == 0))
            {
                return null;
            }
            if (!_lroOperations.TryGetValue((lro, client), out var operations))
            {
                var name = ReserveLroName(lro, client);
                var hasMetadata = lro.LongRunningServiceMetadata.StatusMetadata.Count > 0;
                var metadataModifiers = (hasMetadata && client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) && lro.Accessibility != "internal"
                    ? TypeSignatureModifiers.Public : TypeSignatureModifiers.Internal) | TypeSignatureModifiers.Partial;
                var modifiers = lro.GenerateConvenient ? metadataModifiers : TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial;
                var metadata = hasMetadata
                    ? new LroStatusMetadataProvider($"{name}OperationMetadata", client.Type.Namespace, lro.LongRunningServiceMetadata.StatusMetadata, metadataModifiers,
                        lro.LongRunningServiceMetadata.PollingResponseModel)
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
                    new LroOperationProvider(lro, client, $"{name}RawOperation", resultType is null ? null : new CSharpType(typeof(BinaryData)), metadata,
                        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial)
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
                var methods = client.Methods.ToList();
                var processed = new HashSet<InputLongRunningServiceMethod>();
                var addLroMethods = _clientsWithLroMethods.Add(client);
                foreach (var method in methods.OfType<ScmMethodProvider>().ToArray())
                {
                    if (method.ServiceMethod is { } serviceMethod)
                    {
                        GetLroOperation(serviceMethod, client, method.Kind == ScmMethodKind.Protocol);
                    }
                    if (!addLroMethods || method.ServiceMethod is not InputLongRunningServiceMethod lro ||
                        (lro.LongRunningServiceMetadata.StatusMetadata.Count == 0 &&
                         lro.LongRunningServiceMetadata.OperationId.Count == 0) || !processed.Add(lro))
                    {
                        continue;
                    }

                    var visibility = client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) && lro.Accessibility != "internal"
                        ? MethodSignatureModifiers.Public : MethodSignatureModifiers.Internal;
                    var serviceMethods = methods.OfType<ScmMethodProvider>().Where(m => m.ServiceMethod == lro).ToArray();
                    var hasConvenience = serviceMethods.Any(m => m.Kind != ScmMethodKind.Protocol);
                    var hasProtocol = serviceMethods.Any(m => m.Kind == ScmMethodKind.Protocol);
                    var hasMetadata = lro.LongRunningServiceMetadata.StatusMetadata.Count > 0;
                    if (hasConvenience && !hasMetadata)
                    {
                        AddRehydrationMethod(GetLroOperation(lro, client, protocol: false)!);
                    }
                    if (hasProtocol && (hasMetadata || lro.Response.Type is not null || !hasConvenience))
                    {
                        var raw = GetLroOperation(lro, client, protocol: true)!;
                        AddRehydrationMethod(raw);
                        if (hasMetadata)
                        {
                            methods.Add(raw.CreateMetadataAccessor(client, ReserveMethodName($"Get{raw.MetadataName}"), visibility));
                        }
                    }

                    void AddRehydrationMethod(LroOperationProvider operation)
                    {
                        methods.Add(operation.CreateRehydrationMethod(client, ReserveMethodName($"Rehydrate{operation.Name}"), visibility));
                    }

                    string ReserveMethodName(string baseName)
                    {
                        var name = baseName;
                        var suffix = 2;
                        while (name == client.Name ||
                               methods.Any(m => m.Signature.Name == name) ||
                               client.Properties.Any(p => p.Name == name) ||
                               client.Fields.Any(f => f.Name == name) ||
                               (client.CustomCodeView?.Methods.Any(m => m.Signature.Name == name) ?? false) ||
                               (client.CustomCodeView?.Properties.Any(p => p.Name == name) ?? false) ||
                               (client.CustomCodeView?.Fields.Any(f => f.Name == name) ?? false))
                        {
                            name = $"{baseName}{suffix++}";
                        }
                        return name;
                    }
                }
                if (addLroMethods && processed.Count > 0)
                {
                    client.Update(methods: methods.ToArray());
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
