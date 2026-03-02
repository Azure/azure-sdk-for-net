// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Provisioning.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using System.ComponentModel.Composition;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// The Azure provisioning generator to generate Azure.Provisioning.* libraries
    /// that produce ProvisionableResource subclasses with BicepValue&lt;T&gt; properties.
    /// </summary>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(ProvisioningGenerator))]
    public class ProvisioningGenerator : ManagementClientGenerator
    {
        private ProvisioningOutputLibrary? _outputLibrary;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningGenerator"/> class.
        /// </summary>
        /// <param name="context">The generator context.</param>
        [ImportingConstructor]
        public ProvisioningGenerator(GeneratorContext context) : base(context)
        {
            TypeFactory = new ProvisioningTypeFactory();
        }

        /// <inheritdoc/>
        public override ManagementOutputLibrary OutputLibrary => _outputLibrary ??= new ProvisioningOutputLibrary();

        /// <inheritdoc/>
        public override ManagementTypeFactory TypeFactory { get; }

        /// <inheritdoc/>
        protected override void Configure()
        {
            base.Configure();
            // Add Azure.Provisioning symbols so Roslyn can resolve types without full namespace
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(ProvisionableConstruct).Assembly.Location));
        }
    }
}
