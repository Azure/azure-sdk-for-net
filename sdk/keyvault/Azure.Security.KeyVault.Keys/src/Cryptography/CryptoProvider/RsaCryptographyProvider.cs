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
    using Azure.Security.KeyVault.Keys.Cryptography.ExtensionMethods;

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
        public override async Task<Response<CryptographyOperationResult>> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            Task<Response<CryptographyOperationResult>> result = null;
            if (ServerCryptoProvider != null)
            {
                result = ServerCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }
            else if (LocalCryptoProvider != null)
            {
                //result =  LocalCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }

            return await result.ConfigureAwait(false);
        }

        public override async Task<Response<CryptographyOperationResult>> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            Task<Response<CryptographyOperationResult>> result = null;
            if (ServerCryptoProvider != null)
            {
                result = ServerCryptoProvider.DecryptAsync(ciphertext, iv, authenticationData, authenticationTag, algorithmKind, token);
            }
            else if (LocalCryptoProvider != null)
            {
                //result =  LocalCryptoProvider.EncryptAsync(plaintext, iv, authenticationData, algorithmKind, token);
            }

            return await result.ConfigureAwait(false);
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
        public override async Task<Response<CryptographyOperationResult>> EncryptAsync(byte[] plaintext, byte[] iv, byte[] authenticationData, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            KeyOperationsParameters keyOp = new KeyOperationsParameters(algorithmKind, plaintext);
            //Request req = CreateEncryptRequest();
            Request req = CreateCryptoOperationRequest(CryptoOperationKind.Encrypt);
            req.Content = HttpPipelineRequestContent.Create(keyOp.Serialize());
            Response response = SendRequest(req, token);
            Response<CryptographyOperationResult> result = CreateResponse<CryptographyOperationResult>(response);
            return await Task.FromResult<Response<CryptographyOperationResult>>(result).ConfigureAwait(false);
        }

        public override async Task<Response<CryptographyOperationResult>> DecryptAsync(byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, EncryptionAlgorithmKind algorithmKind, CancellationToken token)
        {
            KeyOperationsParameters keyOp = new KeyOperationsParameters(algorithmKind, ciphertext);
            Request req = CreateCryptoOperationRequest(CryptoOperationKind.Decrypt);
            req.Content = HttpPipelineRequestContent.Create(keyOp.Serialize());
            Response response = SendRequest(req, token);
            Response<CryptographyOperationResult> result = CreateResponse<CryptographyOperationResult>(response);
            return await Task.FromResult<Response<CryptographyOperationResult>>(result).ConfigureAwait(false);
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

        //Request CreateEncryptRequest()
        //{
        //    Request commonRequest = CreateEncryptDecryptRequest();
        //    commonRequest.UriBuilder.AppendPath(@"/encrypt");
        //    return commonRequest;
        //}

        //Request CreateDecryptRequest()
        //{
        //    Request commonRequest = CreateEncryptDecryptRequest();
        //    commonRequest.UriBuilder.AppendPath(@"/decrypt");
        //    return commonRequest;
        //}

        //Request CreateEncryptDecryptRequest()
        //{
        //    //{vaultUri}/keys/{key-name}/{key-version}/encrypt

        //    string keyReqPath = string.Format(CultureInfo.CurrentCulture, "{0}/keys/{1}/{2}", CryptoClient.KeyId.KeyVaultUri, CryptoClient.KeyId.KeyName, CryptoClient.KeyId.KeyVersion);
        //    Request request = CryptoClient.Pipeline.CreateRequest();

        //    request.Headers.Add(HttpHeader.Common.JsonContentType);
        //    request.Headers.Add(HttpHeader.Common.JsonAccept);
        //    request.Method = RequestMethod.Post;
        //    request.UriBuilder.Uri = new Uri(keyReqPath);

        //    request.UriBuilder.AppendQuery("api-version", CryptoClient.CryptoClientOptions.GetVersionString());

        //    return request;
        //}

        Request CreateCryptoOperationRequest(CryptoOperationKind operationKind)
        {
            //{vaultUri}/keys/{key-name}/{key-version}/{CryptoOperationKind}

            string keyReqPath = string.Format(CultureInfo.CurrentCulture, "{0}/keys/{1}/{2}", CryptoClient.KeyId.KeyVaultUri, CryptoClient.KeyId.KeyName, CryptoClient.KeyId.KeyVersion);
            Request request = CryptoClient.Pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = RequestMethod.Post;
            request.UriBuilder.Uri = new Uri(keyReqPath);
            request.UriBuilder.AppendPath(operationKind.GetDescriptionAttributeValue());

            request.UriBuilder.AppendQuery("api-version", CryptoClient.CryptoClientOptions.GetVersionString());

            return request;
        }

        Response SendRequest(Request request, CancellationToken cancellationToken)
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

        Response<T> CreateResponse<T>(Response response)
            where T : Model, new()
        {
            T result = new T();
            result.Deserialize(response.ContentStream);
            return new Response<T>(response, result);
        }
        #endregion

    }
}