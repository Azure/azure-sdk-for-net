// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("OnYourDataApiKeyAuthenticationOptions", typeof(string))]
    public partial class OnYourDataApiKeyAuthenticationOptions : OnYourDataAuthenticationOptions
    {
        /// <summary> Initializes a new instance of OnYourDataApiKeyAuthenticationOptions. </summary>
        public OnYourDataApiKeyAuthenticationOptions()
        {
            Type = OnYourDataAuthenticationType.ApiKey;
        }

        /// <summary>
        /// Sets the API key to use with the specified Azure endpoint.
        /// </summary>
        /// <param name="apiKey"> The API key. </param>
        public void SetKey(string apiKey)
        {
            Key = apiKey;
        }

        /// <summary> The API key to use for authentication. </summary>
        private string Key { get; set; }
    }
}
