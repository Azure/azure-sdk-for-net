// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Extensions
{
    internal static class ClientProviderExtensions
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";

        public static ClientProvider GetClient(this ScmMethodProvider method) => (ClientProvider)method.EnclosingType;

        public static string GetScopeName(this ScmMethodProvider method)
        {
            const string asyncSuffix = "Async";
            var methodName = method.Signature.Name;
            if (methodName.EndsWith(asyncSuffix, System.StringComparison.Ordinal))
            {
                methodName = methodName[..^asyncSuffix.Length];
            }

            return $"{method.EnclosingType.Name}.{methodName}";
        }

        public static string GetScopeName(this ClientProvider client, InputOperation operation) => $"{client.Name}.{operation.Name.ToIdentifierName()}";

        public static bool IsLroMethod(this ScmMethodProvider method) =>
            method is { ServiceMethod: InputLongRunningServiceMethod, EnclosingType: ClientProvider };

        public static PropertyProvider GetClientDiagnosticProperty(this ClientProvider client)
        {
            // Match by name/OriginalName rather than by type: the property may be declared or renamed
            // in custom code (via [CodeGenMember]), in which case its parsed CSharpType is a non-framework
            // type that does not equal the framework ClientDiagnostics type.
            return client.CanonicalView.Properties
                .First(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
        }

        public static PropertyProvider GetPipelineProperty(this ClientProvider client)
        {
            return client.CanonicalView.Properties
                .First(p => p.Type.Equals(typeof(HttpPipeline)));
        }
    }
}