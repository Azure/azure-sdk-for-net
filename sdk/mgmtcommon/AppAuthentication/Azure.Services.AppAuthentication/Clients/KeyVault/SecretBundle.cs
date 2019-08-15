// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to hold the deserialized secret bundle from Key Vault. 
    /// </summary>
    [DataContract]
    internal class SecretBundle
    {
        private string _rawJson;

        // These fields are assigned to by JSON deserialization
        [DataMember(Name = "contentType", IsRequired = false)]
        public string ContentType { get; private set; }

        [DataMember(Name = "value", IsRequired = false)]
        public string Value { get; private set; }

        public static SecretBundle Parse(string rawJsonString)
        {
            if (string.IsNullOrEmpty(rawJsonString))
            {
                throw new ArgumentNullException(nameof(rawJsonString));
            }

            try
            {
                var secretBundle = JsonHelper.Deserialize<SecretBundle>(
                    Encoding.UTF8.GetBytes(rawJsonString));

                secretBundle._rawJson = rawJsonString;

                return secretBundle;
            }
            catch (Exception exp)
            {
                throw new Exception($"Unable to parse JSON secret bundle from Key Vault. Exception: {exp.Message}");
            }
        }

        /// <summary>
        /// Return the secret bundle as-is
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _rawJson;
        }
    }
}
