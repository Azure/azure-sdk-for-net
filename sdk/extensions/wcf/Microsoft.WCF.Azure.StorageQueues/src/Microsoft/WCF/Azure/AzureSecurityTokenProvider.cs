// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using Microsoft.WCF.Azure.Tokens;
using Microsoft.WCF.Azure.StorageQueues;
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure
{
    internal class AzureSecurityTokenProvider : SecurityTokenProvider
    {
        private SecurityToken _securityToken;

        public AzureSecurityTokenProvider(AzureClientCredentials azureClientCredentials, SecurityTokenRequirement tokenRequirement)
        {
            InitToken(azureClientCredentials, tokenRequirement);
        }

        private void InitToken(AzureClientCredentials azureClientCredentials, SecurityTokenRequirement tokenRequirement)
        {
            switch (tokenRequirement.TokenType)
            {
                case AzureSecurityTokenTypes.DefaultTokenType:
                    _securityToken = CreateDefaultSecurityToken(azureClientCredentials);
                    break;
                case AzureSecurityTokenTypes.SasTokenType:
                    _securityToken = CreateSasSecurityToken(azureClientCredentials);
                    break;
                case AzureSecurityTokenTypes.StorageSharedKeyTokenType:
                    _securityToken = CreateStorageSharedKeySecurityToken(azureClientCredentials);
                    break;
                case AzureSecurityTokenTypes.TokenTokenType:
                    _securityToken = CreateTokenCredentialSecurityToken(azureClientCredentials);
                    break;
                case AzureSecurityTokenTypes.ConnectionStringTokenType:
                    _securityToken = CreateConnectionStringSecurityToken(azureClientCredentials);
                    break;
                default:
                    _securityToken = null;
                    break;
            }
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return _securityToken;
        }

        protected override Task<SecurityToken> GetTokenCoreAsync(TimeSpan timeout)
        {
            return Task.FromResult(_securityToken);
        }

        private SecurityToken CreateConnectionStringSecurityToken(AzureClientCredentials azureClientCredentials)
        {
            if (azureClientCredentials.ConnectionString == null)
            {
                throw new InvalidOperationException(SR.ConnectionStringNotProvidedOnAzureClientCredentials);
            }

            return new ConnectionStringSecurityToken(azureClientCredentials.ConnectionString);
        }

        private SecurityToken CreateTokenCredentialSecurityToken(AzureClientCredentials azureClientCredentials)
        {
            if (azureClientCredentials.Token == null)
            {
                throw new InvalidOperationException(SR.TokenCredentialNotProvidedOnAzureClientCredentials);
            }

            return new TokenCredentialSecurityToken(azureClientCredentials.Token);
        }

        private SecurityToken CreateStorageSharedKeySecurityToken(AzureClientCredentials azureClientCredentials)
        {
            if (azureClientCredentials.StorageSharedKey == null)
            {
                throw new InvalidOperationException(SR.StorageSharedKeyCredentialNotProvidedOnAzureClientCredentials);
            }

            return new StorageSharedKeySecurityToken(azureClientCredentials.StorageSharedKey);
        }

        private SecurityToken CreateSasSecurityToken(AzureClientCredentials azureClientCredentials)
        {
            if (azureClientCredentials.Sas == null)
            {
                throw new InvalidOperationException(SR.SasCredentialNotProvidedOnAzureClientCredentials);
            }

            return new SasSecurityToken(azureClientCredentials.Sas);
        }

        private SecurityToken CreateDefaultSecurityToken(AzureClientCredentials azureClientCredentials)
        {
            DefaultAzureCredential cred;
            if (azureClientCredentials.DefaultAzureCredentialOptions != null)
            {
                cred = new DefaultAzureCredential(azureClientCredentials.DefaultAzureCredentialOptions);
            }
            else
            {
                cred = new DefaultAzureCredential();
            }

            return new TokenCredentialSecurityToken(cred);
        }
    }
}