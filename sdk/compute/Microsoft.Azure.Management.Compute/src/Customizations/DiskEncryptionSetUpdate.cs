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
        public DiskEncryptionSetUpdate(string encryptionType = default(string), KeyForDiskEncryptionSet activeKey = default(KeyForDiskEncryptionSet))
        {
            EncryptionType = encryptionType;
            ActiveKey = activeKey;
            CustomInit();
        }

        public DiskEncryptionSetUpdate(string encryptionType = default(string), KeyForDiskEncryptionSet activeKey = default(KeyForDiskEncryptionSet), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            EncryptionType = encryptionType;
            ActiveKey = activeKey;
            Tags = tags;
            CustomInit();
        }
    }
}
