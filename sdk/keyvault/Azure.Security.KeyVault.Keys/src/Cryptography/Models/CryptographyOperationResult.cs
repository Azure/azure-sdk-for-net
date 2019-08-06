// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Models
{
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.Utilities;
    using Azure.Security.KeyVault.Keys;
    using System;
    using System.Text.Json;

    #region Cryptography Operation Result on the wire
    /// <summary>
    /// 
    /// </summary>
    internal class CryptographyOperationWireResult : Model
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
        public byte[] OperationResultValue { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public CryptographyOperationWireResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kid"></param>
        /// <param name="result"></param>
        public CryptographyOperationWireResult(string kid, byte[] result)
        {
            Kid = kid;
            OperationResultValue = result;
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
                OperationResultValue = FromBase64UrlString(resultValue.GetString());
            }
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString(JsonEncodedText.Encode(@"kid"), Kid);
            json.WriteString(JsonEncodedText.Encode(@"value"), ToBase64UrlString(OperationResultValue));

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

    #endregion

    #region EncryptResult Model
    /// <summary>
    /// 
    /// </summary>
    public class EncryptResult
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Uri KeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKind Algorithm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] CipherText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] AuthenticationTag { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="cipherText"></param>
        public EncryptResult(string keyId, byte[] cipherText)
        {
            //Check.NotEmptyNotNull(keyId, nameof(keyId));
            //Check.NotNull(cipherText, nameof(cipherText));

            //if (algorithmKind == EncryptionAlgorithmKind.NotSupported)
            //{
            //    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, "'{0}' not supported", algorithmKind.ToString()));
            //}

            KeyId = new Uri(keyId);
            CipherText = cipherText;
            //Algorithm = algorithmKind;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoResult"></param>
        internal EncryptResult(CryptographyOperationWireResult cryptoResult) : this(cryptoResult.Kid, cryptoResult.OperationResultValue) { }

        #endregion
    }
    #endregion

    #region DecryptResult Model
    /// <summary>
    /// 
    /// </summary>
    public class DecryptResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Byte[] DecryptedData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public DecryptResult(byte[] data)
        {
            DecryptedData = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoResult"></param>
        internal DecryptResult(CryptographyOperationWireResult cryptoResult) : this(cryptoResult.OperationResultValue) { }
    }

    #endregion

    #region WrapKeyResult Model
    /// <summary>
    /// 
    /// </summary>
    public class WrapKeyResult
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Uri KeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EncryptionAlgorithmKind Algorithm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] EncryptedKey { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="encryptedKey"></param>
        public WrapKeyResult(string keyId, byte[] encryptedKey)
        {
            KeyId = new Uri(keyId);
            EncryptedKey = encryptedKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoResult"></param>
        internal WrapKeyResult(CryptographyOperationWireResult cryptoResult) : this(cryptoResult.Kid, cryptoResult.OperationResultValue) { }

        #endregion
    }
    #endregion

    #region UnWrapKeyResult Model

    /// <summary>
    /// 
    /// </summary>
    public class UnWrapKeyResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Byte[] UnWrapedData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public UnWrapKeyResult(byte[] data)
        {
            UnWrapedData = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoResult"></param>
        internal UnWrapKeyResult(CryptographyOperationWireResult cryptoResult) : this(cryptoResult.OperationResultValue) { }
    }
    #endregion
}
