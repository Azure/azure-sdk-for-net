﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Helpers;
using Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
#if net472
using System.Data;
using System.Data.SqlClient;
#endif

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests
{
    /// <summary>
    /// End to end test cases for AzureServiceTokenProvider class. MSI cases are not covered. 
    /// One must be logged in using Azure CLI to run these tests for Azure CLI cases, and for client secret, and certificate cases. 
    /// AppAuthenticationTestCertUrl must be set to a secret URL For a certificate in Key Vault. 
    /// The Integrated Windows Authentication test can only be run on a domain joined machine, where domain is synced with Azure AD. 
    /// </summary>
    public class EndtoEndPositiveTests : IAsyncLifetime
    {
        private string _tenantId;

        /// <summary>
        /// Set the tenantid based on developer running the test cases. 
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.AzureCliConnectionString);
            await azureServiceTokenProvider.GetAccessTokenAsync(Constants.ArmResourceId).ConfigureAwait(false);
            _tenantId = azureServiceTokenProvider.PrincipalUsed.TenantId;
        }

        public async Task DisposeAsync()
        {
            await Task.Delay(0);
        }

        /// <summary>
        /// Test cases where tokens are fetched using Azure CLI or Visual Studio for local development. 
        /// </summary>
        /// <returns></returns>
        private async Task GetTokenUsingDeveloperTool(bool isAzureCli)
        {
            string connectionString = isAzureCli
                ? Constants.AzureCliConnectionString
                : Constants.VisualStudioConnectionString;

            AzureServiceTokenProvider astp1 = new AzureServiceTokenProvider(connectionString);
            
            List<Task<string>> tasks = new List<Task<string>>();

            for (int i = 0; i < 5; i++)
            {
                tasks.Add(astp1.GetAccessTokenAsync(Constants.SqlAzureResourceId));
            }

            await Task.WhenAll(tasks);
            
            AzureServiceTokenProvider astp = new AzureServiceTokenProvider(connectionString);

            List<string> resourceIdList = new List<string>
            {
                Constants.SqlAzureResourceId,
                Constants.GraphResourceId,
                Constants.ArmResourceId,
                Constants.DataLakeResourceId,
                Constants.KeyVaultResourceId
            };

            for (int i = 0; i < 10; i++)
            {
                foreach (var resourceId in resourceIdList)
                {
                    var authResult =
                        await
                            astp.GetAuthenticationResultAsync(resourceId);

                    Validator.ValidateToken(authResult.AccessToken, astp.PrincipalUsed, Constants.UserType, _tenantId, expiresOn: authResult.ExpiresOn);
                }
                
                var callback = astp.KeyVaultTokenCallback;
                string tokenForKeyVault = await callback($"{Constants.AzureAdInstance}{_tenantId}", Constants.KeyVaultResourceId, string.Empty);

                Validator.ValidateToken(tokenForKeyVault, astp.PrincipalUsed, Constants.UserType, _tenantId);
            }
        }

        
        [Fact]
        public async Task GetTokenUsingAzCliTest()
        {
            await GetTokenUsingDeveloperTool(true);
        }

        [RunOnWindowsFact]
        public async Task GetTokenUsingVisualStudio()
        {
            await GetTokenUsingDeveloperTool(false);
        }

#if FullNetFx
        /// <summary>
        /// Test case where token is fetched using Integrated Windows Authentication. 
        /// Person running the test must be using domain joined machine, where domain is federated with Azure AD. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTokenUsingIntegratedWindowsAuthenticationTest()
        {
            AzureServiceTokenProvider astp = new AzureServiceTokenProvider(Constants.IntegratedAuthConnectionString);
            
            for (int i = 0; i < 100; i++)
            {
                // Get token using active directory integrated authentication
                var authResult =
                    await
                        astp.GetAuthenticationResultAsync(Constants.GraphResourceId);

                // This will not cause IWA. Token for SQL will be used to get token for Graph API (MRRT)
                AzureServiceTokenProvider astp1 = new AzureServiceTokenProvider(Constants.IntegratedAuthConnectionString);
                await astp1.GetAccessTokenAsync(Constants.SqlAzureResourceId);

                Validator.ValidateToken(authResult.AccessToken, astp.PrincipalUsed, Constants.UserType, astp1.PrincipalUsed.TenantId, expiresOn: authResult.ExpiresOn);
            }
        }
#endif

        private enum CertIdentifierType
        {
            SubjectName,
            Thumbprint,
            KeyVaultCertificateSecretIdentifier
        }

        /// <summary>
        /// One must be logged in using Azure CLI and set AppAuthenticationTestCertUrl to a secret URL for a certificate in Key Vault before running this test.
        /// The test creates a new Azure AD application and service principal, uses the cert as the credential, and then uses the library to authenticate to it, using the cert. 
        /// After the cert, the Azure AD application is deleted. Cert is removed from current user store on the machine. 
        /// </summary>
        /// <param name="certIdentifierType"></param>
        /// <returns></returns>
        private async Task GetTokenUsingServicePrincipalWithCertTestImpl(CertIdentifierType certIdentifierType)
        {
            string testCertUrl = Environment.GetEnvironmentVariable(Constants.TestCertUrlEnv);

            // Get a certificate from key vault. 
            // For security, this certificate is not hard coded in the test case, since it gets added as app credential in Azure AD, and may not get removed. 
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.AzureCliConnectionString);
            KeyVaultHelper keyVaultHelper = new KeyVaultHelper(new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback)));
            string certAsString = await keyVaultHelper.ExportCertificateAsBlob(testCertUrl).ConfigureAwait(false);

            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(certAsString), string.Empty);
            
            // Create an application
            GraphHelper graphHelper = new GraphHelper(_tenantId);
            Application app = await graphHelper.CreateApplicationAsync(cert).ConfigureAwait(false);

            // Get token using service principal, this will cache the cert
            AppAuthenticationResult authResult = null;
            int count = 5;

            string thumbprint = cert.Thumbprint?.ToLower();

            // Construct connection string using client id and cert info
            string connectionString = null;
            switch (certIdentifierType)
            {
                case CertIdentifierType.SubjectName:
                case CertIdentifierType.Thumbprint:
                    string thumbprintOrSubjectName = (certIdentifierType == CertIdentifierType.Thumbprint) ? $"CertificateThumbprint={thumbprint}" : $"CertificateSubjectName={cert.Subject}";
                    connectionString = $"RunAs=App;AppId={app.AppId};TenantId={_tenantId};{thumbprintOrSubjectName};CertificateStoreLocation={Constants.CurrentUserStore};";
                    break;
                case CertIdentifierType.KeyVaultCertificateSecretIdentifier:
                    connectionString = $"RunAs=App;AppId={app.AppId};TenantId={_tenantId};CertificateKeyVaultCertificateSecretIdentifier={testCertUrl};";
                    break;
            }
            
            AzureServiceTokenProvider astp =
                new AzureServiceTokenProvider(connectionString);

            if (certIdentifierType == CertIdentifierType.SubjectName ||
                certIdentifierType == CertIdentifierType.Thumbprint)
            {
                // Import the certificate
                CertUtil.ImportCertificate(cert);
            }

            while (authResult == null && count > 0)
            {
                try
                {
                    await astp.GetAccessTokenAsync(Constants.KeyVaultResourceId);

                    authResult = await astp.GetAuthenticationResultAsync(Constants.SqlAzureResourceId, _tenantId);
                }
                catch
                {
                    // It takes time for Azure AD to realize a new application has been added. 
                    await Task.Delay(15000);

                    count--;
                }
            }

            if (certIdentifierType == CertIdentifierType.SubjectName ||
               certIdentifierType == CertIdentifierType.Thumbprint)
            {
                // Delete the cert
                CertUtil.DeleteCertificate(cert.Thumbprint);

                var deletedCert = CertUtil.GetCertificate(cert.Thumbprint);
                Assert.Null(deletedCert);
            }

            // Get token again using a cert which is deleted, but in the cache
            await astp.GetAccessTokenAsync(Constants.SqlAzureResourceId, _tenantId);

            // Delete the application and service principal
            await graphHelper.DeleteApplicationAsync(app);

            Validator.ValidateToken(authResult.AccessToken, astp.PrincipalUsed, Constants.AppType, _tenantId,
                app.AppId, cert.Thumbprint, expiresOn: authResult.ExpiresOn);
        }

        [Fact]
        public async Task GetTokenThumbprintTest()
        {
            await GetTokenUsingServicePrincipalWithCertTestImpl(CertIdentifierType.Thumbprint);
        }

        [Fact]
        public async Task GetTokenSubjectNameTest()
        {
            await GetTokenUsingServicePrincipalWithCertTestImpl(CertIdentifierType.SubjectName);
        }

        [Fact]
        public async Task GetTokenKeyVaultIdentifierTest()
        {
            await GetTokenUsingServicePrincipalWithCertTestImpl(CertIdentifierType.KeyVaultCertificateSecretIdentifier);
        }

        [Fact]
        public async Task GetTokenUsingServicePrincipalWithClientSecretTest()
        {
            GraphHelper graphHelper = new GraphHelper(_tenantId);
            string secret = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
            Application app = await graphHelper.CreateApplicationAsync(secret);

            // Get token using service principal
            AppAuthenticationResult authResult = null;
            int count = 5;

            Environment.SetEnvironmentVariable(Constants.ConnectionStringEnvironmentVariableName, $"RunAs=App;TenantId={_tenantId};AppId={app.AppId};AppKey={secret}");
            AzureServiceTokenProvider astp = new AzureServiceTokenProvider();

            while (authResult == null && count > 0)
            {
                try
                {
                    authResult = await astp.GetAuthenticationResultAsync(Constants.SqlAzureResourceId, _tenantId);

                    await astp.GetAccessTokenAsync(Constants.KeyVaultResourceId);

                }
                catch
                {
                    // It takes time for Azure AD to realize a new application has been added. 
                    await Task.Delay(15000);

                    count--;
                }

            }

            // Delete the application
            await graphHelper.DeleteApplicationAsync(app);

            Environment.SetEnvironmentVariable(Constants.ConnectionStringEnvironmentVariableName, null);

            Validator.ValidateToken(authResult.AccessToken, astp.PrincipalUsed, Constants.AppType, _tenantId, app.AppId, expiresOn: authResult.ExpiresOn);
        }

#if net472
        /// <summary>
        /// One must be logged in using Azure CLI and set AppAuthenticationTestSqlDbEndpoint to a SQL Azure database endpoint before running this test.
        /// The test validates that it can open a connection with the SQL database using SqlAzureAuthProvider, which implements the SqlAuthenticationProvider interface.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ConnectToSqlDbWithSqlAppAuthProvider()
        {
            // register SqlAzureAppAuthProvider and create the connection string
            SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, new SqlAppAuthenticationProvider());
            string connectionString = $"server={Environment.GetEnvironmentVariable(Constants.TestSqlDbEndpoint)};Authentication=Active Directory Interactive;UID=";

            // verify the connection can be successfully opened
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            Assert.Equal(ConnectionState.Open, sqlConnection.State);

            // verify connection can be successfully closed
            sqlConnection.Close();
            Assert.Equal(ConnectionState.Closed, sqlConnection.State);
        }
#endif
    }
}
