// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using System;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for AzureServiceTokenProviderFactory class. AzureServiceTokenProviderFactory is an internal class. 
    /// Test that the right type of provider is returned based on the connection string. 
    /// </summary>
    public class AzureServiceTokenProviderFactoryTests
    {
        [Fact]
        public void AzureCliValidTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionString, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.AzureCliConnectionString, provider.ConnectionString);
            Assert.IsType(typeof(AzureCliAccessTokenProvider), provider);

            provider = AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionStringWithSpaces, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.AzureCliConnectionStringWithSpaces, provider.ConnectionString);
            Assert.IsType(typeof(AzureCliAccessTokenProvider), provider);
        }

        [Fact]
        public void AzureCliInvalidDeveloperToolTest()
        {
            var exception = Assert.Throws<FormatException>(() => AzureServiceTokenProviderFactory.Create(Constants.InvalidAzureCliConnectionString, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidAzureCliConnectionString, exception.ToString());           
        }

        [Fact]
        public void ActiveDirectoryIntegratedValidTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.ActiveDirectoryIntegratedConnectionString, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.ActiveDirectoryIntegratedConnectionString, provider.ConnectionString);
        }


        [Fact]
        public void ManagedServiceIdentityValidTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.ManagedServiceIdentityConnectionString, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.ManagedServiceIdentityConnectionString, provider.ConnectionString);
            Assert.IsType(typeof(MsiAccessTokenProvider), provider);
        }

        [Fact]
        public void CertValidTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.CertificateConnStringThumbprintLocalMachine, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.CertificateConnStringThumbprintLocalMachine, provider.ConnectionString);
            Assert.IsType(typeof(ClientCertificateAzureServiceTokenProvider), provider);

            provider = AzureServiceTokenProviderFactory.Create(Constants.CertificateConnStringThumbprintCurrentUser, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.CertificateConnStringThumbprintCurrentUser, provider.ConnectionString);
            Assert.IsType(typeof(ClientCertificateAzureServiceTokenProvider), provider);

            provider = AzureServiceTokenProviderFactory.Create(Constants.CertificateConnStringSubjectNameCurrentUser, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.CertificateConnStringSubjectNameCurrentUser, provider.ConnectionString);
            Assert.IsType(typeof(ClientCertificateAzureServiceTokenProvider), provider);
        }

        [Fact]
        public void ClientSecretValidTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.ClientSecretConnString, Constants.AzureAdInstance);
            Assert.NotNull(provider);
            Assert.Equal(Constants.ClientSecretConnString, provider.ConnectionString);
            Assert.IsType(typeof(ClientSecretAccessTokenProvider), provider);
        }
    }
}
