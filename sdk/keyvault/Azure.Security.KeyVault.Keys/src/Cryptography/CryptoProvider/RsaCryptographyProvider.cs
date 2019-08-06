// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.CryptoProvider
{
    using Azure.Core;
    using Azure.Core.Http;
    using Azure.Core.Pipeline;
    using Azure.Security.KeyVault.Cryptography.Base;
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Defaults;
    using Azure.Security.KeyVault.Cryptography.Models;
    using Azure.Security.KeyVault.Keys;
    using Azure.Security.KeyVault.Keys.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class RsaCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const
        const string RSA_CRYPTO_DEFAULT_NAME = "RSAProviderDefaults";
        #endregion

        #region fields
        CryptoProviderDefaults _cryptoProviderDefaults;
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public override CryptoProviderDefaults Defaults
        {
            // These defaults should match local/server defaults
            // meaning local/server defaults should be exactly the same as these defaults
            get
            {
                if(_cryptoProviderDefaults == null)
                {
                    _cryptoProviderDefaults = new CryptoProviderDefaults(EncryptionAlgorithmKind.RsaOaep, EncryptionAlgorithmKind.RsaOaep, EncryptionAlgorithmKind.Rsa256, RSA_CRYPTO_DEFAULT_NAME);
                }

                return _cryptoProviderDefaults;
            }
        }

        #region private properties
        RsaLocalCryptographyProvider LocalCryptoProvider { get; set; }

        RsaServerCryptographyProvider ServerCryptoProvider { get; set; }
        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public RsaCryptographyProvider() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public RsaCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient)
        {
            if (CryptoClient.CryptoClientOptions.EnableLocalCryptographyOperations)
            {
                LocalCryptoProvider = new RsaLocalCryptographyProvider(CryptoClient);
            }

            if (CryptoClient.CryptoClientOptions.EnableServerCryptographyOperations)
            {
                ServerCryptoProvider = new RsaServerCryptographyProvider(CryptoClient);
            }
        }
        #endregion

        #region Public Functions

        #region ICryptoProvider
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Response<KeyOperationResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            Response<KeyOperationResult> result = null;
            if (ServerCryptoProvider != null)
            {
                result = ServerCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }
            else if (LocalCryptoProvider != null)
            {
                result =  LocalCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }

            return await result.ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Response<KeyOperationResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            return base.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
        }
        #endregion

        #endregion

        #region private functions

        #endregion

    }

    class RsaLocalCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cryptoClient"></param>
        public RsaLocalCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient) { }
        #endregion

        #region Public Functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Task<EncryptResult> EncryptAsync(Stream plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            return base.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
        }

        #region Virtual Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected override bool IsAlgorithmKindSupported(EncryptionAlgorithmKind algorithmKind)
        {
            return base.IsAlgorithmKindSupported(algorithmKind);
        }
        #endregion

        #endregion

        #region private functions

        #endregion

    }

    class RsaServerCryptographyProvider : BaseCryptographyProvider<CryptoProviderDefaults>
    {
        #region const

        #endregion

        #region fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RsaServerCryptographyProvider(CryptographyClient cryptoClient) : base(cryptoClient) { }
        #endregion

        #region Public Functions

        #region ICryptoProvider
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="algorithmKind"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override Response<KeyOperationResult> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            //keys/{key-name}/{key-version}/encrypt
            //List<KeyOperations> keyOperationList = new List<KeyOperations>() { KeyOperations.Encrypt };
            //KeyRequestParameters keyReqParam = new KeyRequestParameters(CryptoClient.KeyVaultKey, keyOperationList);

            KeyOperationsParameters keyOp = new KeyOperationsParameters(algorithmKind, plaintext);
            Request req = CreateEncryptRequest();
            req.Content = HttpPipelineRequestContent.Create(keyOp.Serialize());

            Response response = SendRequest(req, token);

            Response<KeyOperationResult> result = CreateResponse<KeyOperationResult>(response);

            return result;
            //{{"kid":"https://netsdkcryptokvtest.vault.azure.net/keys/1907704304/e7576b04e9b04734998ac46356f4674e","value":"avxsc1BQuDHggfcNR5Va7RYjiyFtmKti1jaj3Jc73SV1w1gBDsqm8s81Jy_jYretDi057N5gaQ_ZqkS-nn9NO4_anzltDm20zadzps7uGeDSK-Ad8ske3EasG_SobCnI71hIWWSBXFXVsqL3kLBGyHS-WnA51vW85_uyN5sYN3EUJ6St9rNfDffwMBX3Y3vBuX6Mih387De9smcb_WdalfSXk1dl-3uk9Vqw5r-qOdHk7XZ3_-9FJm98BtbBuModHJweB9hs-oDp52Ci6qSUNcdrs8WEOL2EsmwoQCOSjDXjUWHAD2SGfu8ie7JJS676R6fhlU_ZO2vUwjs4Vv2k7A"}}
        }

        #endregion

        #region Virtual Overrides
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithmKind"></param>
        /// <returns></returns>
        protected override bool IsAlgorithmKindSupported(EncryptionAlgorithmKind algorithmKind)
        {
            return base.IsAlgorithmKindSupported(algorithmKind);
        }
        #endregion

        #endregion

        #region private functions

        Request CreateEncryptRequest()
        {
            Request commonRequest = CreateEncryptDecryptRequest();
            commonRequest.UriBuilder.AppendPath(@"/encrypt");
            return commonRequest;
        }

        Request CreateDecryptRequest()
        {
            Request commonRequest = CreateEncryptDecryptRequest();
            commonRequest.UriBuilder.AppendPath(@"/decrypt");
            return commonRequest;
        }

        Request CreateEncryptDecryptRequest()
        {
            //{vaultUri}/keys/{key-name}/{key-version}/encrypt

            string keyReqPath = string.Format(CultureInfo.CurrentCulture, "{0}/keys/{1}/{2}", CryptoClient.KeyId.KeyVaultUri, CryptoClient.KeyId.KeyName, CryptoClient.KeyId.KeyVersion);
            Request request = CryptoClient.Pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = RequestMethod.Post;
            request.UriBuilder.Uri = new Uri(keyReqPath);
            //request.UriBuilder.AppendPath(keyReqPath);

            request.UriBuilder.AppendQuery("api-version", CryptoClient.CryptoClientOptions.GetVersionString());

            return request;
        }

        private Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var response = CryptoClient.Pipeline.SendRequest(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw response.CreateRequestFailedException();
            }
        }

        private Response<T> CreateResponse<T>(Response response)
            where T : Model
        {
            T result = default(T);
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }
        #endregion

    }
}
;