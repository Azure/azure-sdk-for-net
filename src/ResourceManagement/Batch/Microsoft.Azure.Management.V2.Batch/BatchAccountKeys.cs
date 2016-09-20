/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Batch
{


    /// <summary>
    /// This class represents the access keys for the batch account.
    /// </summary>
    public partial class BatchAccountKeys 
    {
        private string primary;
        private string secondary;

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="primaryKey">primaryKey primary key value for the batch account</param>
        /// <param name="secondaryKey">secondaryKey secondary key value for the batch account</param>
        public  BatchAccountKeys (string primaryKey, string secondaryKey)
        {
            primary = primaryKey;
            secondary = secondaryKey;
        }

        /// <summary>
        /// Get the primary value.
        /// </summary>
        /// <returns>the primary value</returns>
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
        public string Secondary
        {
            get
            {
                return secondary;
            }
        }
    }
}