// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using System.ComponentModel.Composition;

namespace Azure.Generator.StubLibrary
{
    /// <summary>
    /// The stub library plugin to generate the stub library.
    /// </summary>
    [Export(typeof(CodeModelPlugin))]
    [ExportMetadata("PluginName", nameof(AzureStubPlugin))]
    public class AzureStubPlugin : AzureClientPlugin
    {
        /// <summary>
        /// The stub library plugin to generate the stub library.
        /// </summary>
        /// <param name="context"> The Generator Context. </param>
        [ImportingConstructor]
        public AzureStubPlugin(GeneratorContext context) : base(context) { }

        /// <summary>
        /// Customize the generation output for stub library.
        /// </summary>
        public override void Configure()
        {
            base.Configure();
            AddVisitor(new AzureStubVisitor());
        }
    }
}
