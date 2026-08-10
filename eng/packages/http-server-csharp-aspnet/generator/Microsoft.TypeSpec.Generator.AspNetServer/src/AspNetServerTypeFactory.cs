// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Type factory for the ASP.NET server generator. Routes model creation to
    /// <see cref="ServerModelProvider"/> (a POCO) instead of the default
    /// client-model provider, which emits serialization machinery the server
    /// side does not need.
    /// </summary>
    public sealed class AspNetServerTypeFactory : TypeFactory
    {
        /// <summary>Initializes a new instance of <see cref="AspNetServerTypeFactory"/>.</summary>
        public AspNetServerTypeFactory()
        {
        }

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            return new ServerModelProvider(model);
        }
    }
}
