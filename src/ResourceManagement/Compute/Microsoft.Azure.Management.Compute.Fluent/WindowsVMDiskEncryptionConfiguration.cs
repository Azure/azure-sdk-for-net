// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;

    /// <summary>
    /// Type representing encryption configuration to be applied to a Windows virtual machine.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuV2luZG93c1ZNRGlza0VuY3J5cHRpb25Db25maWd1cmF0aW9u
    public sealed class WindowsVMDiskEncryptionConfiguration  :
        VirtualMachineEncryptionConfiguration<Microsoft.Azure.Management.Compute.Fluent.WindowsVMDiskEncryptionConfiguration>
    {
        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:5FB785552E5FD74C28F297EA7778027A
        public override OperatingSystemTypes OsType()
        {
            return OperatingSystemTypes.Windows;
        }

        /// <summary>
        /// Creates WindowsVMDiskEncryptionConfiguration.
        /// </summary>
        /// <param name="keyVaultId">The resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        ///GENMHASH:9B03FA69C2FE62BE4DDAFCFB97F1625C:D2C4BE9AEE50F40A54E843F13622A34E
        public  WindowsVMDiskEncryptionConfiguration(string keyVaultId, string aadClientId, string aadSecret) : base(keyVaultId, aadClientId, aadSecret)
        {
        }
    }
}