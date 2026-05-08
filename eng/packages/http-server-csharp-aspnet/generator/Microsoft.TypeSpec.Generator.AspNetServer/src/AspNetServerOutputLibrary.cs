// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Output library for the ASP.NET Core server-side code generator. Emits one
    /// POCO per TypeSpec model, one enum/extensible-enum per TypeSpec enum, and
    /// one abstract controller base per TypeSpec interface (recursively,
    /// including child clients).
    /// </summary>
    public class AspNetServerOutputLibrary : OutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var generator = AspNetServerCodeModelGenerator.Instance;

            // base.BuildTypeProviders() already iterates InputLibrary models /
            // enums through TypeFactory.CreateModel / CreateEnum (which we route
            // to ServerModelProvider via CreateModelCore), and adds the
            // framework helper definitions (ArgumentDefinition, etc.) required
            // by the extensible-enum template. We just need to:
            //   - drop ModelFactoryProvider (our POCOs don't carry the
            //     additionalBinaryDataProperties parameter it expects), and
            //   - append a ControllerProvider per input client.
            var providers = new List<TypeProvider>(
                base.BuildTypeProviders().Where(p => p is not ModelFactoryProvider));

            foreach (var client in generator.InputLibrary.InputNamespace.Clients)
            {
                if (client.Methods.Count == 0)
                {
                    continue;
                }
                providers.Add(new ControllerProvider(client));
            }
            return providers.ToArray();
        }
    }
}


