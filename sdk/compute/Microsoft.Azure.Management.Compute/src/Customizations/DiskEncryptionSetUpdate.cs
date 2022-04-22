namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// disk encryption set update resource.
    /// </summary>
    public partial class DiskEncryptionSetUpdate
    {
        /// <summary>
        /// Initializes a new instance of the DiskEncryptionSetUpdate class.
        /// </summary>
        /// <param name="encryptionType">Possible values include:
        /// 'EncryptionAtRestWithCustomerKey',
        /// 'EncryptionAtRestWithPlatformAndCustomerKeys'</param>
        /// <param name="activeKey">Active Key of the encryption</param>
        public DiskEncryptionSetUpdate(string encryptionType, KeyForDiskEncryptionSet activeKey)
        {
            EncryptionType = encryptionType;
            ActiveKey = activeKey;
            CustomInit();
        }

        public DiskEncryptionSetUpdate(string encryptionType, KeyForDiskEncryptionSet activeKey, IDictionary<string, string> tags)
        {
            EncryptionType = encryptionType;
            ActiveKey = activeKey;
            Tags = tags;
            CustomInit();
        }
    }
}
