// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class SecretBundle
    {
        /// <summary>
        /// The identifier for secret object
        /// </summary>
        public SecretIdentifier SecretIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Id))
                    return new SecretIdentifier(Id);
                else
                    return null;
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
