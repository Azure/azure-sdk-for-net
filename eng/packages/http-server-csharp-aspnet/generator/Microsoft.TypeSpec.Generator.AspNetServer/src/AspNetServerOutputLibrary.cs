// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.Input;
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
            var inputLibrary = CodeModelGenerator.Instance.InputLibrary;
            var typeFactory = (AspNetServerTypeFactory)CodeModelGenerator.Instance.TypeFactory;

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
            foreach (var inputEnum in inputLibrary.InputNamespace.Enums)
            {
                // Realize the enum so it gets cached in the type factory; it
                // will also be created on demand via property/parameter type
                // resolution. Either path lands in the same cache.
                typeFactory.CreateCSharpType(inputEnum);
            }
            foreach (var client in EnumerateClients(inputLibrary.InputNamespace.RootClients))
            {
                if (client.Methods.Count == 0)
                {
                    continue;
                }
                providers.Add(new ControllerProvider(client));
            }
            providers.AddRange(typeFactory.GetCachedEnums());
            if (typeFactory.GetCachedEnums().Count > 0)
            {
                // ArgumentDefinition is internal to the generator framework but
                // is required by the extensible-enum template (Argument.AssertNotNull).
                // Instantiate it reflectively so the helper class is emitted.
                var argDefType = typeof(TypeProvider).Assembly.GetType(
                    "Microsoft.TypeSpec.Generator.Providers.ArgumentDefinition", throwOnError: true)!;
                providers.Add((TypeProvider)System.Activator.CreateInstance(argDefType)!);
            }
            return providers.ToArray();
        }

        private static IEnumerable<InputClient> EnumerateClients(IEnumerable<InputClient> roots)
        {
            foreach (var client in roots)
            {
                yield return client;
                foreach (var child in EnumerateClients(client.Children))
                {
                    yield return child;
                }
            }
        }
    }
}


