// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    internal static class ClientProviderExtensions
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";

        public static ClientProvider GetClient(this ScmMethodProvider method) => (ClientProvider)method.EnclosingType;

        public static string GetScopeName(this ScmMethodProvider method) => $"{method.EnclosingType.Name}.{method.Signature.Name}";

        public static bool IsLroMethod(this ScmMethodProvider method) =>
            method is { ServiceMethod: InputLongRunningServiceMethod, EnclosingType: ClientProvider };

        public static PropertyProvider GetClientDiagnosticProperty(this ClientProvider client)
        {
            return client.CanonicalView.Properties
                .First(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
        }
    }
}