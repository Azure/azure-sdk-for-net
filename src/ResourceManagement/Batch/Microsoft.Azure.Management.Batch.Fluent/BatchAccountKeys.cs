// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    /// <summary>
    /// This class represents the access keys for the batch account.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLkJhdGNoQWNjb3VudEtleXM=

    public partial class BatchAccountKeys
    {
        private string primary;
        private string secondary;

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="primaryKey">primaryKey primary key value for the batch account</param>
        /// <param name="secondaryKey">secondaryKey secondary key value for the batch account</param>
        ///GENMHASH:BE513982743CDE83CDF5A93879B0D23E:6A8D85C7DA5D85D7D8EBF5D88AF1F421
        public BatchAccountKeys(string primaryKey, string secondaryKey)
        {
            primary = primaryKey;
            secondary = secondaryKey;
        }

        /// <summary>
        /// Get the primary value.
        /// </summary>
        /// <returns>the primary value</returns>

        ///GENMHASH:46645B73135AFEDAC926BE820EB4AFF7:6BCA9549104D8A2A532E7662192A505E
        public string Primary
        {
            get
            {
                return primary;
            }
        }

        /// <summary>
        /// Get the secondary value.
        /// </summary>
        /// <returns>the secondary value</returns>

        ///GENMHASH:BD8D51006FA39E65AA03B613332E3B24:7DDB4238BDF3FFEBCFD1D1526D7C6F64
        public string Secondary
        {
            get
            {
                return secondary;
            }
        }
    }
}
