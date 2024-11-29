// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Input;
using System;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureInputLibrary : InputLibrary
    {
        /// <inheritdoc/>
        public AzureInputLibrary(string codeModelPath) : base(codeModelPath)
        {
        }

        /// <summary>
        /// Identify if the input is generated for Azure ARM.
        /// </summary>
        internal Lazy<bool> IsAzureArm => new Lazy<bool>(() => InputNamespace.Clients.Any(c => c.Decorators.Any(d => d.Name.Equals("Azure.ResourceManager.@armProviderNamespace"))));
    }
}
