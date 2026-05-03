// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.AspNetServer.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Output library for the ASP.NET Core server-side code generator.
    /// </summary>
    public class AspNetServerOutputLibrary : OutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            return [new HelloWorldProvider()];
        }
    }
}
