// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.EmitterRpc;
using System;
using System.ComponentModel.Composition;

namespace Azure.Generator.Mgmt
{
    /// <summary>
    /// The management-plane client plugin to generate the Azure mgmt client SDK.
    /// </summary>
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(MgmtClientPlugin))]
    public class MgmtClientPlugin : AzureClientPlugin
    {
        private static MgmtClientPlugin? _instance;
        internal static MgmtClientPlugin Instance => _instance ?? throw new InvalidOperationException("MgmtClientPlugin is not loaded.");

        /// <summary>
        /// The Azure client plugin to generate the Azure client SDK.
        /// </summary>
        /// <param name="context"></param>
        [ImportingConstructor]
        public MgmtClientPlugin(GeneratorContext context) : base(context)
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
