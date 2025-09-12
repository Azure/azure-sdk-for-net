// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Visitors;
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
    [ExportMetadata(GeneratorMetadataName, nameof(ManagementClientGenerator))]
    public class ManagementClientGenerator : AzureClientGenerator
    {
        private static ManagementClientGenerator? _instance;
        internal static new ManagementClientGenerator Instance => _instance ?? throw new InvalidOperationException("ManagementClientGenerator is not loaded.");

        /// <summary>
        /// The Azure management client generator to generate the Azure management client SDK.
        /// </summary>
        /// <param name="context"></param>
        [ImportingConstructor]
        public ManagementClientGenerator(GeneratorContext context) : base(context)
        {
            TypeFactory = new ManagementTypeFactory();
            InputLibrary = new ManagementInputLibrary(Configuration.OutputDirectory);
            _instance = this;
        }

        /// <inheritdoc/>
        public override ManagementInputLibrary InputLibrary { get; }

        private ManagementOutputLibrary? _azureOutputLibrary;
        /// <inheritdoc/>
        public override ManagementOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

        /// <inheritdoc/>
        public override ManagementTypeFactory TypeFactory { get; }

        /// <summary>
        /// Customize the generation output for Azure client SDK.
        /// </summary>
        protected override void Configure()
        {
            base.Configure();
            // Include Azure.ResourceManager
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(ArmClient).Assembly.Location));
            // renaming should come first
            AddVisitor(new NameVisitor());
            AddVisitor(new SerializationVisitor());
            AddVisitor(new FlattenPropertyVisitor());
            AddVisitor(new SafeFlattenVisitor());
            AddVisitor(new RestClientVisitor());
            AddVisitor(new ResourceVisitor());
            AddVisitor(new InheritableSystemObjectModelVisitor());
            AddVisitor(new TypeFilterVisitor());
            AddVisitor(new PaginationVisitor());
            AddVisitor(new ModelFactoryVisitor());
        }
    }
}
