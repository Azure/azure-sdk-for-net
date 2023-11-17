// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("OnYourDataKeyAndKeyIdAuthenticationOptions", typeof(string), typeof(string))]
    public partial class OnYourDataKeyAndKeyIdAuthenticationOptions : OnYourDataAuthenticationOptions
    {
        /// <summary>
        /// Initializes a new instance of OnYourDataKeyAndKeyIdAuthenticationOptions.
        /// </summary>
        public OnYourDataKeyAndKeyIdAuthenticationOptions()
        {
            Type = OnYourDataAuthenticationType.KeyAndKeyId;
        }

        /// <summary>
        /// Sets the key to use with the specified Azure endpoint.
        /// </summary>
        /// <param name="key"> The API key. </param>
        public void SetKey(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Sets the key ID to use with the specified Azure endpoint.
        /// </summary>
        /// <param name="keyId"> The key ID. </param>
        public void SetKeyId(string keyId)
        {
            KeyId = keyId;
        }

        /// <summary> The key to use for authentication. </summary>
        private string Key { get; set; }
        /// <summary> The key ID to use for authentication. </summary>
        private string KeyId { get; set; }
    }
}
