// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class KeyBundle
    {
        /// <summary>
        /// The identifier for the key object
        /// </summary>
        public KeyIdentifier KeyIdentifier
        {
            get
            {
                if (Key != null && !string.IsNullOrWhiteSpace(Key.Kid))
                    return new KeyIdentifier(Key.Kid);
                else
                    return null;
            }
        }
    }
}
