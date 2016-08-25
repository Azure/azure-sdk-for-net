// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class KeyItem
    {
        /// <summary>
        /// Identifier for the key object
        /// </summary>
        public KeyIdentifier Identifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Kid))
                    return new KeyIdentifier(Kid);
                else
                    return null;
            }
        }
    }
}
