// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class SecretItem
    {
        /// <summary>
        /// The identifier for secret object
        /// </summary>
        public SecretIdentifier Identifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new SecretIdentifier(Id);
                else
                    return null;
            }
        }
    }
}
