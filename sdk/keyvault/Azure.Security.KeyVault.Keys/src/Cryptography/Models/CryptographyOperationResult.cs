// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Models
{
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using Azure.Security.KeyVault.Keys;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class CryptographyOperationResult : Model
    {

        #region fields

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Kid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] CipherText { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public CryptographyOperationResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kid"></param>
        /// <param name="result"></param>
        public CryptographyOperationResult(string kid, byte[] result)
        {
            Kid = kid;
            CipherText = result;
        }
        #endregion

        #region Public Functions

        #endregion

        #region private functions
        internal override void ReadProperties(JsonElement json)
        {
            if(json.TryGetProperty("kid", out JsonElement keyId))
            {
                Kid = keyId.GetString();
            }

            if (json.TryGetProperty("value", out JsonElement resultValue))
            {
                //string sanitizedStr = SanitizeBase64UrlString(resultValue.GetString());
                //CipherText = Convert.FromBase64String(sanitizedStr);
                CipherText = FromBase64UrlString(resultValue.GetString());
            }
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(JsonEncodedText.Encode(@"kid"), Kid);
            json.WriteString(JsonEncodedText.Encode(@"value"), ToBase64UrlString(CipherText));

            //ReadOnlySpan<byte> rob = new ReadOnlySpan<byte>(CipherText);
            //json.WriteBase64String(JsonEncodedText.Encode(@"value"), rob);
        }

        private static byte[] FromBase64UrlString(string input)
        {
            Check.NotEmptyNotNull(input, nameof(input));
            return Convert.FromBase64String(SanitizeBase64UrlString(input));
        }

        private static string SanitizeBase64UrlString(string input)
        {
            var count = 3 - ((input.Length + 3) % 4);

            if (count == 0)
            {
                return input;
            }

            string paddedString = string.Concat(input, new string('=', count));
            return paddedString.Replace('-', '+').Replace('_', '/');
        }

        private static string ToBase64UrlString(byte[] input)
        {
            Check.NotNull(input, nameof(input));
            return Convert.ToBase64String(input).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }
        #endregion
    }
}
