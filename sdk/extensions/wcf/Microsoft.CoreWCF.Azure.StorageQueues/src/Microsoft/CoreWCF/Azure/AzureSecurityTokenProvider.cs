// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using CoreWCF.IdentityModel.Selectors;
using CoreWCF.IdentityModel.Tokens;
using Microsoft.CoreWCF.Azure.StorageQueues;
using Microsoft.CoreWCF.Azure.Tokens;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure
{
    internal class AzureSecurityTokenProvider : SecurityTokenProvider
    {
        private SecurityToken _securityToken;

        public AzureSecurityTokenProvider(AzureServiceCredentials azureServiceCredentials, SecurityTokenRequirement tokenRequirement)
        {
            InitToken(azureServiceCredentials, tokenRequirement);
        }

        private void InitToken(AzureServiceCredentials azureServiceCredentials, SecurityTokenRequirement tokenRequirement)
        {
            switch (tokenRequirement.TokenType)
            {
                case AzureSecurityTokenTypes.DefaultTokenType:
                    _securityToken = CreateDefaultSecurityToken(azureServiceCredentials);
                    break;
                case AzureSecurityTokenTypes.SasTokenType:
                    _securityToken = CreateSasSecurityToken(azureServiceCredentials);
                    break;
                case AzureSecurityTokenTypes.StorageSharedKeyTokenType:
                    _securityToken = CreateStorageSharedKeySecurityToken(azureServiceCredentials);
                    break;
                case AzureSecurityTokenTypes.TokenTokenType:
                    _securityToken = CreateTokenCredentialSecurityToken(azureServiceCredentials);
                    break;
                case AzureSecurityTokenTypes.ConnectionStringTokenType:
                    _securityToken = CreateConnectionStringSecurityToken(azureServiceCredentials);
                    break;
                default:
                    _securityToken = null;
                    break;
            }
        }

        protected override Task<SecurityToken> GetTokenCoreAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_securityToken);
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return _securityToken;
        }

        private SecurityToken CreateConnectionStringSecurityToken(AzureServiceCredentials AzureServiceCredentials)
        {
            if (AzureServiceCredentials.ConnectionString == null)
            {
                throw new InvalidOperationException(SR.ConnectionStringNotProvidedOnAzureServiceCredentials);
            }

            return new ConnectionStringSecurityToken(AzureServiceCredentials.ConnectionString);
        }

        private SecurityToken CreateTokenCredentialSecurityToken(AzureServiceCredentials AzureServiceCredentials)
        {
            if (AzureServiceCredentials.Token == null)
            {
                throw new InvalidOperationException(SR.TokenCredentialNotProvidedOnAzureServiceCredentials);
            }

            return new TokenCredentialSecurityToken(AzureServiceCredentials.Token);
        }

        private SecurityToken CreateStorageSharedKeySecurityToken(AzureServiceCredentials AzureServiceCredentials)
        {
            if (AzureServiceCredentials.StorageSharedKey == null)
            {
                throw new InvalidOperationException(SR.StorageSharedKeyCredentialNotProvidedOnAzureServiceCredentials);
            }

            return new StorageSharedKeySecurityToken(AzureServiceCredentials.StorageSharedKey);
        }

        private SecurityToken CreateSasSecurityToken(AzureServiceCredentials AzureServiceCredentials)
        {
            if (AzureServiceCredentials.Sas == null)
            {
                throw new InvalidOperationException(SR.SasCredentialNotProvidedOnAzureServiceCredentials);
            }

            return new SasSecurityToken(AzureServiceCredentials.Sas);
        }

        private SecurityToken CreateDefaultSecurityToken(AzureServiceCredentials AzureServiceCredentials)
        {
            DefaultAzureCredential cred;
            if (AzureServiceCredentials.DefaultAzureCredentialOptions != null)
            {
                cred = new DefaultAzureCredential(AzureServiceCredentials.DefaultAzureCredentialOptions);
            }
            else
            {
                cred = new DefaultAzureCredential();
            }

            return new TokenCredentialSecurityToken(cred);
        }
    }
}