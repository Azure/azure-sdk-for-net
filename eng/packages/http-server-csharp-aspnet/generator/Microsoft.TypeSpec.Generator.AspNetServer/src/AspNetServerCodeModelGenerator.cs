// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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

        /// <inheritdoc/>
        protected override void Configure()
        {
            base.Configure();

            // Make ASP.NET Core MVC assemblies known to the post-processing
            // Roslyn workspace so the Simplifier can shorten emitted type names
            // (e.g. Microsoft.AspNetCore.Mvc.ControllerBase -> ControllerBase
            // under the matching using directive). Without these, Roslyn cannot
            // resolve the symbols and leaves them fully qualified.
            AddMvcMetadataReferences();
        }

        private void AddMvcMetadataReferences()
        {
            // One representative type per ASP.NET Core MVC assembly we emit
            // types from; the framework split is multiple assemblies, so we
            // dedupe by Assembly.Location.
            var seedTypes = new[]
            {
                typeof(ControllerBase),                  // Microsoft.AspNetCore.Mvc.Core
                typeof(ApiControllerAttribute),          // Microsoft.AspNetCore.Mvc.Core
                typeof(FromRouteAttribute),              // Microsoft.AspNetCore.Mvc.Core
                typeof(HttpGetAttribute),                // Microsoft.AspNetCore.Mvc.Core
                typeof(ActionResult<>),                  // Microsoft.AspNetCore.Mvc.Core
                typeof(IActionResult),                   // Microsoft.AspNetCore.Mvc.Abstractions
            };

            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var seed in seedTypes)
            {
                var location = seed.Assembly.Location;
                if (!string.IsNullOrEmpty(location) && seen.Add(location))
                {
                    AddMetadataReference(MetadataReference.CreateFromFile(location));
                }
            }
        }
    }
}



