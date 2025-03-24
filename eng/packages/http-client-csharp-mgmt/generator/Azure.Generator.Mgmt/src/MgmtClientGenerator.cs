// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using System;
using System.ComponentModel.Composition;

namespace Azure.Generator.Management
{
    /// <summary>
    /// The Azure management client generator to generate the Azure management client SDK.
    /// </summary>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(MgmtClientGenerator))]
    public class MgmtClientGenerator : AzureClientGenerator
    {
        private static MgmtClientGenerator? _instance;
        internal static MgmtClientGenerator Instance => _instance ?? throw new InvalidOperationException("MgmtClientGenerator is not loaded.");

        /// <summary>
        /// The Azure management client generator to generate the Azure management client SDK.
        /// </summary>
        /// <param name="context"></param>
        [ImportingConstructor]
        public MgmtClientGenerator(GeneratorContext context) : base(context)
        {
            TypeFactory = new MgmtTypeFactory();
            InputLibrary = new MgmtInputLibrary(Configuration.OutputDirectory);
            _instance = this;
        }

        /// <inheritdoc/>
        public override MgmtInputLibrary InputLibrary { get; }

        private MgmtOutputLibrary? _azureOutputLibrary;
        /// <inheritdoc/>
        public override MgmtOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

        /// <inheritdoc/>
        public override MgmtTypeFactory TypeFactory { get; }

        /// <summary>
        /// Customize the generation output for Azure client SDK.
        /// </summary>
        public override void Configure()
        {
            base.Configure();
            // Include Azure.ResourceManager
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(ArmClient).Assembly.Location));
            AddVisitor(new RestClientVisitor());
            AddVisitor(new ResourceVisitor());
        }
    }
}
