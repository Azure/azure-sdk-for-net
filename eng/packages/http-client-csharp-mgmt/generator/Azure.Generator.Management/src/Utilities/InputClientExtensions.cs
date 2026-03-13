// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management.Utilities;

internal static class InputClientExtensions
{
    extension(InputClient inputClient)
    {
        /// <summary>
        /// Gets the API version for this client from its <see cref="InputClient.ApiVersions"/>.
        /// </summary>
        public string CurrentApiVersion
            => inputClient.ApiVersions.LastOrDefault()
                ?? throw new InvalidOperationException($"Cannot determine API version for client '{inputClient.Name}'. The client has no API versions defined.");
    }
}
