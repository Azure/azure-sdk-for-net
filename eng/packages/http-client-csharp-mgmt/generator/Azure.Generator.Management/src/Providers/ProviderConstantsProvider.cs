// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ProviderConstantsProvider : TypeProvider
    {
        private const string DefaultProviderNamespaceName = "DefaultProviderNamespace";

        public static ValueExpression DefaultProviderNamespace =>  Static(ManagementClientGenerator.Instance.OutputLibrary.ProviderConstants.Type).Property(DefaultProviderNamespaceName);

        protected override string BuildName() => "ProviderConstants";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;

        protected override PropertyProvider[] BuildProperties()
        {
            var defaultProviderNamespaceProperty = new PropertyProvider(
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(string),
                DefaultProviderNamespaceName,
                new AutoPropertyBody(false, MethodSignatureModifiers.None, Static<ClientDiagnostics>().Invoke(nameof(ClientDiagnostics.GetResourceProviderNamespace), [TypeOf(Type).Property(nameof(System.Type.Assembly))])),
                this);

            return [defaultProviderNamespaceProperty];
        }
    }
}