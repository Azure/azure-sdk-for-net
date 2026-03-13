// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Properties to configure Encryption. </summary>
    public partial class ServiceAccountEncryptionProperties
    {
        /// <summary> Name of the Key from KeyVault. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyName
        {
            get
            {
                if (KeyVaultProperties != null)
                    return KeyVaultProperties.KeyName;
                else
                    return default;
            }
            set
            {
                if (KeyVaultProperties == null)
                    KeyVaultProperties = new CognitiveServicesKeyVaultProperties();
                KeyVaultProperties.KeyName = value;
            }
        }
        /// <summary> Version of the Key from KeyVault. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyVersion
        {
            get
            {
                if (KeyVaultProperties != null)
                    return KeyVaultProperties.KeyVersion;
                else
                    return default;
            }
            set
            {
                if (KeyVaultProperties == null)
                    KeyVaultProperties = new CognitiveServicesKeyVaultProperties();
                KeyVaultProperties.KeyVersion = value;
            }
        }
        /// <summary> Uri of KeyVault. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri KeyVaultUri
        {
            get
            {
                if (KeyVaultProperties != null && Uri.TryCreate(KeyVaultProperties.KeyVaultUri, UriKind.Absolute, out Uri keyVaultUri))
                    return keyVaultUri;
                else
                    return default;
            }
            set
            {
                if (KeyVaultProperties == null)
                    KeyVaultProperties = new CognitiveServicesKeyVaultProperties();
                KeyVaultProperties.KeyVaultUri = value?.AbsoluteUri;
            }
        }
        /// <summary> Gets or sets the identity client id. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? IdentityClientId
        {
            get
            {
                if (KeyVaultProperties != null && Guid.TryParse(KeyVaultProperties.IdentityClientId, out Guid identityClientId))
                    return identityClientId;
                else
                    return default;
            }
            set
            {
                if (KeyVaultProperties == null)
                    KeyVaultProperties = new CognitiveServicesKeyVaultProperties();
                KeyVaultProperties.IdentityClientId = value?.ToString();
            }
        }
    }
}
