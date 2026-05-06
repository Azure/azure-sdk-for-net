// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
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
            RegisterAdditionalMetadataReferences();
        }

        /// <inheritdoc/>
        public override AspNetServerTypeFactory TypeFactory { get; }

        /// <inheritdoc/>
        public override AspNetServerOutputLibrary OutputLibrary { get; } = new();

        /// <summary>
        /// Registers metadata references for assemblies whose types the generator
        /// emits via fully-qualified names (e.g. <c>Microsoft.AspNetCore.Mvc.*</c>).
        /// Without these, Roslyn's <c>Simplifier</c> cannot resolve the symbols
        /// during post-processing and leaves them fully qualified instead of
        /// shortening them under the matching <c>using</c> directive.
        /// </summary>
        private void RegisterAdditionalMetadataReferences()
        {
            // One representative type per ASP.NET Core assembly we reference.
            // The shared framework loads many split assemblies; pick a type per
            // assembly so all of them are made known to the post-processing
            // workspace.
            var seedTypes = new[]
            {
                typeof(ControllerBase),                  // Microsoft.AspNetCore.Mvc.Core
                typeof(ApiControllerAttribute),          // Microsoft.AspNetCore.Mvc.Core
                typeof(FromRouteAttribute),              // Microsoft.AspNetCore.Mvc.Core
                typeof(HttpGetAttribute),                // Microsoft.AspNetCore.Mvc.Core
                typeof(ActionResult<>),                  // Microsoft.AspNetCore.Mvc.Core
                typeof(IActionResult),                   // Microsoft.AspNetCore.Mvc.Abstractions
            };

            var seenAssemblies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var seed in seedTypes)
            {
                AddAssemblyReference(seed.Assembly, seenAssemblies);
            }
        }

        private void AddAssemblyReference(Assembly assembly, HashSet<string> seen)
        {
            var location = assembly.Location;
            if (string.IsNullOrEmpty(location) || !seen.Add(location))
            {
                return;
            }
            AddMetadataReference(MetadataReference.CreateFromFile(location));
        }
    }
}



