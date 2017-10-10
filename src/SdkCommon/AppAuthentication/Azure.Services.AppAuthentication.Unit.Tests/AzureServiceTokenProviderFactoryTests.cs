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

        /// <summary>
        /// If DevelopmentTool in the connection string is invalid , an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliInvalidDeveloperToolTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.InvalidDeveloperToolConnectionString, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidConnectionString, exception.ToString());           
        }

        /// <summary>
        /// If RunAs in the connection string is invalid , an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliInvalidRunAsTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.InvalidRunAsConnectionString, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidConnectionString, exception.ToString());
        }

        /// <summary>
        /// If a key in the connection string is empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliInvalidConnectionStringTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionStringNoRunAs, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidConnectionString, exception.ToString());

            exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionStringWithEmptyDeveloperTool, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidConnectionString, exception.ToString());
        }

        /// <summary>
        /// If a key in the connection string is repeated, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliRepeatedKeyConnectionStringTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionStringRepeatedRunAs, Constants.AzureAdInstance));

            Assert.Contains(Constants.KeyRepeatedInConnectionString, exception.ToString());
        }

        /// <summary>
        /// If the connection string is not in the correct format, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliIncorrectFormatConnectionStringTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.IncorrectFormatConnectionString, Constants.AzureAdInstance));

            Assert.Contains(Constants.NotInProperFormatError, exception.ToString());
        }

        /// <summary>
        /// If the connection string is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliConnectionStringNullOrEmptyTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(null, Constants.AzureAdInstance));

            Assert.Contains(Constants.ConnectionStringEmpty, exception.ToString());

            exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(string.Empty, Constants.AzureAdInstance));

            Assert.Contains(Constants.ConnectionStringEmpty, exception.ToString());
        }

        /// <summary>
        /// If the connection string is RunAs App and does not have a certificate location or app key, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliConnectionStringNoCertLocationOrAppKeyTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.AppConnStringNoLocationOrAppKey, Constants.AzureAdInstance));

            Assert.Contains(Constants.ConnectionStringNotHaveAtLeastOneRequiredKey, exception.ToString());
        }

        /// <summary>
        /// If the connection string has invalid cert location, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void AzureCliConnectionStringInvalidCertLocationTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => AzureServiceTokenProviderFactory.Create(Constants.CertificateConnStringThumbprintInvalidLocation, Constants.AzureAdInstance));

            Assert.Contains(Constants.InvalidCertLocationError, exception.ToString());
        }

        /// <summary>
        /// If connection string ends with "; ", then the parser should ignore the white space and continue. 
        /// </summary>
        [Fact]
        public void AzureCliConnectionStringEndsWithSpaceTest()
        {
            var provider = AzureServiceTokenProviderFactory.Create(Constants.AzureCliConnectionStringEndingWithSemiColonAndSpace, Constants.AzureAdInstance);

            Assert.NotNull(provider);
            Assert.Equal(Constants.AzureCliConnectionStringEndingWithSemiColonAndSpace, provider.ConnectionString);
            Assert.IsType(typeof(AzureCliAccessTokenProvider), provider);
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
