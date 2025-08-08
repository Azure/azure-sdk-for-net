// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ProviderConstantsProvider : TypeProvider
    {
        protected override string BuildName() => "ProviderConstants";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;

        protected override PropertyProvider[] BuildProperties()
        {
            var defaultProviderNamespaceProperty = new PropertyProvider(
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(string),
                "DefaultProviderNamespace",
                new ExpressionPropertyBody(Static<ClientDiagnostics>().Invoke(nameof(ClientDiagnostics.GetResourceProviderNamespace), [TypeOf(Type)])),
                this);

            return [defaultProviderNamespaceProperty];
        }
    }
}