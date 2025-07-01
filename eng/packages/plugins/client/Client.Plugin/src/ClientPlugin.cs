// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Client.Plugin.Visitors;
using Microsoft.TypeSpec.Generator;

namespace Client.Plugin
{
    /// <summary>
    /// ClientPlugin is a generator plugin that applies several visitors to mutate the generated client library.
    /// </summary>
    internal class ClientPlugin : GeneratorPlugin
    {
        /// <inheritdoc />
        public override void Apply(CodeModelGenerator generator)
        {
            // Visitors that do any renaming must be added first so that any visitors relying on custom code view will have the CustomCodeView set.
            generator.AddVisitor(new ModelFactoryRenamerVisitor());

            // Rest of the visitors can be added in any order.
            generator.AddVisitor(new NamespaceVisitor());
        }
    }
}
