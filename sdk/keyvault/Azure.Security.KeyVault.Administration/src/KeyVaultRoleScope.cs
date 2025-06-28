// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    [CodeGenType("RoleScope")]
    public readonly partial struct KeyVaultRoleScope
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultRoleScope"/> structure.
        /// </summary>
        /// <param name="resourceId">The Resource Id for the given Resource.</param>
        public KeyVaultRoleScope(Uri resourceId)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            // Remove the version segment from a Key Id, if present.
            string[] segments = resourceId.Segments;

            if (resourceId.AbsolutePath.StartsWith("/keys/", StringComparison.Ordinal) && segments.Length == 4)
            {
                _value = resourceId.AbsolutePath.Remove(resourceId.AbsolutePath.Length - segments[3].Length - 1);
            }
            else
            {
                _value = resourceId.AbsolutePath;
            }
        }
     }
}
