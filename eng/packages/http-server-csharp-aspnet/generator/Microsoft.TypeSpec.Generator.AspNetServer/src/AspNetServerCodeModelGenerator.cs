// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using Microsoft.TypeSpec.Generator;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Code generator that emits ASP.NET Core server-side code from a TypeSpec
    /// service definition.
    /// </summary>
    /// <remarks>
    /// Initial scope: emits one POCO per TypeSpec model under
    /// <c>src/Generated/Models/</c> and one abstract <c>ControllerBase</c>
    /// subclass per TypeSpec interface under <c>src/Generated/Controllers/</c>.
    /// Versioning, polymorphic discriminators, paging helpers, and validation
    /// attributes are intentionally out of scope for this initial cut.
    /// </remarks>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(AspNetServerCodeModelGenerator))]
    public class AspNetServerCodeModelGenerator : CodeModelGenerator
    {
        /// <summary>Initializes a new instance of <see cref="AspNetServerCodeModelGenerator"/>.</summary>
        [ImportingConstructor]
        public AspNetServerCodeModelGenerator(GeneratorContext context) : base(context)
        {
            TypeFactory = new AspNetServerTypeFactory();
        }

        /// <inheritdoc/>
        public override AspNetServerTypeFactory TypeFactory { get; }

        /// <inheritdoc/>
        public override AspNetServerOutputLibrary OutputLibrary { get; } = new();
    }
}



