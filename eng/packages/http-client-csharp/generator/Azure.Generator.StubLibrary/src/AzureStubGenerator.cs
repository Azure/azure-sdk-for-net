// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using System.ComponentModel.Composition;

namespace Azure.Generator.StubLibrary
{
    /// <summary>
    /// The stub library plugin to generate the stub library.
    /// </summary>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(AzureStubGenerator))]
    public class AzureStubGenerator : AzureClientGenerator
    {
        /// <summary>
        /// The stub library plugin to generate the stub library.
        /// </summary>
        /// <param name="context"> The Generator Context. </param>
        [ImportingConstructor]
        public AzureStubGenerator(GeneratorContext context) : base(context) { }

        /// <summary>
        /// Customize the generation output for stub library.
        /// </summary>
        protected override void Configure()
        {
            base.Configure();
            AddVisitor(new AzureStubVisitor());
        }
    }
}
