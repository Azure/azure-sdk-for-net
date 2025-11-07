// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Azure.Generator.Visitors;

namespace Client.Plugin
{
    /// <summary>
    /// ClientPlugin is a generator plugin that applies several visitors to mutate the generated client library.
    /// </summary>
    internal sealed class ClientPlugin : GeneratorPlugin
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
