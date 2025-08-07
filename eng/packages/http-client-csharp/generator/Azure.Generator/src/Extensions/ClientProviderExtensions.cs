// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    internal static class ClientProviderExtensions
    {
        public static ClientProvider GetClient(this ScmMethodProvider method) => (ClientProvider)method.EnclosingType;

        public static string GetScopeName(this ScmMethodProvider method) => $"{method.EnclosingType.Name}.{method.Signature.Name}";

        public static string GetScopeName(this ClientProvider client, InputOperation operation) => $"{client.Name}.{operation.Name.ToIdentifierName()}";

        public static bool IsLroMethod(this ScmMethodProvider method) =>
            method is { ServiceMethod: InputLongRunningServiceMethod, EnclosingType: ClientProvider };

        public static PropertyProvider GetClientDiagnosticProperty(this ClientProvider client)
        {
            return client.CanonicalView.Properties
                .First(p => p.Type.Equals(typeof(ClientDiagnostics)));
        }

        public static PropertyProvider GetPipelineProperty(this ClientProvider client)
        {
            return client.CanonicalView.Properties
                .First(p => p.Type.Equals(typeof(HttpPipeline)));
        }
    }
}