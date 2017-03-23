// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;

    /// <summary>
    /// Type representing encryption settings to be applied to a Linux virtual machine.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuTGludXhWTURpc2tFbmNyeXB0aW9uQ29uZmlndXJhdGlvbg==
    public sealed class LinuxVMDiskEncryptionConfiguration  :
        VirtualMachineEncryptionConfiguration<Microsoft.Azure.Management.Compute.Fluent.LinuxVMDiskEncryptionConfiguration>
    {
        /// <summary>
        /// Creates LinuxVMDiskEncryptionSettings.
        /// </summary>
        /// <param name="keyVaultId">The resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">Client id of an AAD application which has permission to the key vault.</param>
        /// <param name="aadSecret">Client secret corresponding to the aadClientId.</param>
        ///GENMHASH:F60F63D0BCF461F87C8DDE2D7B55825B:D2C4BE9AEE50F40A54E843F13622A34E
        public  LinuxVMDiskEncryptionConfiguration(string keyVaultId, string aadClientId, string aadSecret) : base(keyVaultId, aadClientId, aadSecret)
        {
        }

        /// <summary>
        /// Specifies the pass phrase for encrypting Linux OS or data disks.
        /// </summary>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <return>LinuxVMDiskEncryptionSettings.</return>
        ///GENMHASH:0CC939DDCC0209861A98A7947CE0A981:A5C8AF7F46E66DCB072804CBE659A45F
        public LinuxVMDiskEncryptionConfiguration WithPassPhrase(string passPhrase)
        {
            this.passPhrase = passPhrase;
            return this;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:14DA61D401D0341BDBDB99994BA6DA1F
        public override OperatingSystemTypes OsType()
        {
            return OperatingSystemTypes.Linux;
        }
    }
}