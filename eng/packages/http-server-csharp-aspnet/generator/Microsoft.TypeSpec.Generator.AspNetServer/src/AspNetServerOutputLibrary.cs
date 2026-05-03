// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Output library for the ASP.NET Core server-side code generator.
    /// Emits one model provider per TypeSpec model. Controller files are
    /// written separately via <see cref="AspNetServerCodeModelGenerator.WriteAdditionalFiles"/>.
    /// </summary>
    public class AspNetServerOutputLibrary : OutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var inputLibrary = CodeModelGenerator.Instance.InputLibrary;
            var typeFactory = CodeModelGenerator.Instance.TypeFactory;

            var providers = new List<TypeProvider>();
            foreach (var model in inputLibrary.InputNamespace.Models)
            {
                if (model.IsPropertyBag)
                {
                    continue;
                }
                var provider = typeFactory.CreateModel(model);
                if (provider is not null)
                {
                    providers.Add(provider);
                }
            }
            return providers.ToArray();
        }
    }
}

