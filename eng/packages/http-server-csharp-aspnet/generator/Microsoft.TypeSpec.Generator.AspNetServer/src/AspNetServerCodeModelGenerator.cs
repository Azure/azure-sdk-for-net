// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Code generator that emits ASP.NET Core server-side code from a TypeSpec
    /// service definition.
    /// </summary>
    /// <remarks>
    /// This is the initial scaffold and currently produces a single hello-world
    /// C# file. Real outputs (controllers, models, version registry) will be
    /// added incrementally.
    /// </remarks>
    [Export(typeof(CodeModelGenerator))]
    [ExportMetadata(GeneratorMetadataName, nameof(AspNetServerCodeModelGenerator))]
    public class AspNetServerCodeModelGenerator : CodeModelGenerator
    {
        /// <summary>Initializes a new instance of <see cref="AspNetServerCodeModelGenerator"/>.</summary>
        [ImportingConstructor]
        public AspNetServerCodeModelGenerator(GeneratorContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public override AspNetServerOutputLibrary OutputLibrary { get; } = new();

        /// <summary>
        /// The server SDK does not currently emit a configuration schema file.
        /// </summary>
        public override Task WriteAdditionalFiles(string outputPath) => Task.CompletedTask;
    }
}

