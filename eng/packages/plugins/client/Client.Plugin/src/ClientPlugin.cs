// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Client.Plugin
{
    /// <summary>
    /// ClientPlugin is a generator plugin that applies several visitors to mutate the generated client library.
    /// </summary>
    internal sealed class ClientPlugin : GeneratorPlugin
    {
        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            // Visitors that do any renaming must be added first so that any visitors relying on custom code view will have the CustomCodeView set.
            generator.AddVisitor(new ModelFactoryRenamerVisitor());

            // Rest of the visitors can be added in any order.
            generator.AddVisitor(new NamespaceVisitor());
            generator.AddVisitor(new DistributedTracingVisitor(
                new CSharpType(typeof(ClientDiagnostics)),
                new CSharpType(typeof(DiagnosticScope)),
                method => method.ServiceMethod is InputPagingServiceMethod));
            generator.AddVisitor(new ClientRequestIdHeaderVisitor(includeXmsClientRequestIdInRequest: true));
            // Note the shared source TaskExtensions must be added manually to the csproj currently as plugins
            // don't support modifying the shared source files currently.
            // https://github.com/Azure/azure-sdk-for-net/issues/55574
            generator.AddVisitor(new MultiPartFormDataVisitor());
        }
    }
}
