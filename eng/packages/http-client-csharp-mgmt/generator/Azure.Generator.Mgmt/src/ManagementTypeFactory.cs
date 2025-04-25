// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.InputTransformation;
using Azure.Generator.Management.Providers.Abstraction;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementTypeFactory : AzureTypeFactory
    {
        /// <inheritdoc/>
        public override IClientPipelineApi ClientPipelineApi => MgmtHttpPipelineProvider.Instance;

        /// <inheritdoc/>
        protected override IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> AzureDependencyPackages =>
            [
                new("Azure.Core"),
                new("Azure.ResourceManager"),
                new("System.ClientModel"),
                new("System.Text.Json")
            ];

        /// <inheritdoc/>
        protected override ClientProvider? CreateClientCore(InputClient inputClient)
        {
            var transformedClient = InputClientTransformer.TransformInputClient(inputClient);
            return transformedClient is null ? null : base.CreateClientCore(transformedClient);
        }
    }
}
