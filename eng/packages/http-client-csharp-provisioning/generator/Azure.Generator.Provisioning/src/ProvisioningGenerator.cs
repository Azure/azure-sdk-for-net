// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using System;
using System.ComponentModel.Composition;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// The Azure provisioning generator to generate Azure.Provisioning.* libraries
    /// that produce ProvisionableResource subclasses with BicepValue&lt;T&gt; properties.
    /// </summary>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(ProvisioningGenerator))]
    public class ProvisioningGenerator : CodeModelGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningGenerator"/> class.
        /// </summary>
        /// <param name="context">The generator context.</param>
        [ImportingConstructor]
        public ProvisioningGenerator(GeneratorContext context) : base(context)
        {
            // TODO: Initialize provisioning-specific type factory and output library
        }

        /// <inheritdoc/>
        protected override void Configure()
        {
            // TODO: Configure provisioning-specific generation settings
        }
    }
}
