// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Type representing encryption configuration to be applied to a virtual machine.
    /// </summary>
    /// <typeparam name="">Type presenting Windows or Linux specific settings.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuVmlydHVhbE1hY2hpbmVFbmNyeXB0aW9uQ29uZmlndXJhdGlvbg==
    public abstract partial class VirtualMachineEncryptionConfiguration<T> where T : VirtualMachineEncryptionConfiguration<T>
    {
        protected string keyVaultId;
        protected string aadClientId;
        protected string aadSecret;
        protected DiskVolumeType volumeType = DiskVolumeType.All;
        protected string keyEncryptionKeyURL;
        protected string keyEncryptionKeyVaultId;
        protected string encryptionAlgorithm = "RSA-OAEP";
        protected string passPhrase;
        /// <return>Type of the volume to perform encryption operation.</return>
        ///GENMHASH:814280587F0E53D88D5E5C928D9115ED:19720431EC8B69EF32BD133285B70286
        public DiskVolumeType VolumeType()
        {
            return this.volumeType;
        }

        /// <return>Key vault url to the key (KEK) to protect (encrypt) the disk-encryption key.</return>
        ///GENMHASH:B3EDDD6BD5B871E5A7B34F62711741AD:B82BED9FFA0AB021DEBE0EC1DA60CBDF
        public string KeyEncryptionKeyURL()
        {
            return this.keyEncryptionKeyURL;
        }

        /// <return>Url to the key vault to store the disk encryption key.</return>
        ///GENMHASH:57D7103AE8F2E04D4112FC755D3CAF3C:A8928886C3450601F3C53E067F68A108
        public string KeyVaultUrl()
        {
            string keyVaultName = ResourceUtils.NameFromResourceId(this.keyVaultId);
            return $"https://{keyVaultName.ToLower()}.vault.azure.net/";
        }

        /// <return>Resource id of the key vault holding key encryption key (KEK).</return>
        ///GENMHASH:3DC6B851A28EE538E8C87D6B91F7AF77:EC3E6DD4E774F199EB4BB32A0B0CA9AB
        public string KeyEncryptionKeyVaultId()
        {
            return this.keyEncryptionKeyVaultId;
        }

        /// <summary>
        /// Specifies the key vault url to the key for protecting or wrapping the disk-encryption key.
        /// </summary>
        /// <param name="keyEncryptionKeyURL">The key (KEK) url.</param>
        /// <return>VirtualMachineEncryptionConfiguration.</return>
        ///GENMHASH:E63193F05D44A226A22D402D007A8FBF:80751C88CD71F212983E4F3FD6C5E3E9
        public T WithVolumeEncryptionKeyEncrypted(string keyEncryptionKeyURL)
        {
            return WithVolumeEncryptionKeyEncrypted(keyEncryptionKeyURL, null);
        }

        /// <summary>
        /// Specifies the and key vault Id and a vault url to the key for protecting or wrapping the disk-encryption key.
        /// </summary>
        /// <param name="keyEncryptionKeyURL">The key (KEK) url.</param>
        /// <param name="keyEncryptionKeyKevVaultId">Resource id of the keyVault storing KEK.</param>
        /// <return>VirtualMachineEncryptionConfiguration.</return>
        ///GENMHASH:C5979C4E359A65A1DB0BEDA38D748C7A:7D9BE5B08E6DEC00A9AC78E07AD46D69
        public T WithVolumeEncryptionKeyEncrypted(string keyEncryptionKeyURL, string keyEncryptionKeyKevVaultId)
        {
            this.keyEncryptionKeyURL = keyEncryptionKeyURL;
            this.keyEncryptionKeyVaultId = keyEncryptionKeyKevVaultId;
            return self();
        }

        /// <return>Resource id of the key vault to store the disk encryption key.</return>
        ///GENMHASH:E859445AB65C00AE1D158E5C9BCF53DE:5D87FAAD29063B8622372739D59ACA76
        public string KeyVaultId()
        {
            return this.keyVaultId;
        }

        /// <summary>
        /// Specifies the algorithm used to encrypt the disk-encryption key.
        /// </summary>
        /// <param name="encryptionAlgorithm">The algorithm.</param>
        /// <return>VirtualMachineEncryptionConfiguration.</return>
        ///GENMHASH:5FCA1F52E64E4DAE2F3F0FC56DA251AB:4B13337FBF9B3138D9BF3AD9D2DCF00E
        public T WithVolumeEncryptionKeyEncryptAlgorithm(string encryptionAlgorithm)
        {
            this.encryptionAlgorithm = encryptionAlgorithm;
            return self();
        }

        /// <summary>
        /// Creates VirtualMachineEncryptionConfiguration.
        /// </summary>
        /// <param name="keyVaultId">Resource id of the key vault to store the disk encryption key.</param>
        /// <param name="aadClientId">AAD application client id to access the key vault.</param>
        /// <param name="aadSecret">AAD application client secret to access the key vault.</param>
        ///GENMHASH:16CC6D6D92E86033409CE9320681B7F7:07C7F8E8A1CE0AC6E561967196C06719
        protected  VirtualMachineEncryptionConfiguration(string keyVaultId, string aadClientId, string aadSecret)
        {
            this.keyVaultId = keyVaultId;
            this.aadClientId = aadClientId;
            this.aadSecret = aadSecret;
        }

        /// <return>The operating system type.</return>
        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:27E486AB74A10242FF421C0798DDC450
        public abstract OperatingSystemTypes OsType();

        /// <return>The AAD application client secret to access the key vault.</return>
        ///GENMHASH:EE909AE2618B80F41FB39B40F9155C60:DCE897ED584908351FB34D6395839449
        public string AadSecret()
        {
            return this.aadSecret;
        }

        /// <return>The AAD application client id to access the key vault.</return>
        ///GENMHASH:5806E6100E9B9AD32554CBA95B5A43A2:C5F589FD35375E1E7526575A9C653F53
        public string AadClientId()
        {
            return this.aadClientId;
        }

        /// <return>The algorithm used to encrypt the disk-encryption key.</return>
        ///GENMHASH:0D9DDB731282DF666BB031491A64B868:F08F393AD77ED0ED05E2CCEDDD213798
        public string VolumeEncryptionKeyEncryptAlgorithm()
        {
            return this.encryptionAlgorithm;
        }

        /// <return>The pass phrase to encrypt Linux OS and data disks.</return>
        ///GENMHASH:9EC6CACA8BE7121AFC840C4476C4C52A:AB916A2E4F74B91D0C1C749E2429F215
        public string LinuxPassPhrase()
        {
            return this.passPhrase;
        }

        /// <summary>
        /// Specifies the volume to encrypt.
        /// </summary>
        /// <param name="volumeType">The volume type.</param>
        /// <return>VirtualMachineEncryptionConfiguration.</return>
        ///GENMHASH:501A833E385B5DF04F6014D8C9E9807A:6E251199682F8B60497C7AE7344772AB
        public T WithVolumeType(DiskVolumeType volumeType)
        {
            this.volumeType = volumeType;
            return self();
        }

        private T self() {
            return this as T;
        }
    }
}