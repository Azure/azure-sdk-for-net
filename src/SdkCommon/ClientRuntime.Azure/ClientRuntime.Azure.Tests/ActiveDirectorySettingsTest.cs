// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;
using Microsoft.Rest.Azure.Authentication;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    public class ActiveDirectorySettingsTest
    {

        [Theory]
        [InlineData("https://www.contoso.com")]
        [InlineData("https://www.contoso.com/widgets")]
        [InlineData("http://www.contoso.com/wdgets/moreWidgets")]
        [InlineData("https://www.contoso.com:8080")]
        [InlineData("https://www.contoso.com:8080/widgets")]
       public void AzureEnvironmentAddsSlashToEndpoints(string inputUri)
        {
            var testEnvironment = new ActiveDirectoryServiceSettings
            {
                ValidateAuthority = true,
                TokenAudience = new Uri("https://contoso.com/widgets/"),
                AuthenticationEndpoint = new Uri(inputUri)
            };
            Assert.Equal(inputUri + "/", testEnvironment.AuthenticationEndpoint.ToString());
        }

        [Theory]
        [InlineData("https://www.contoso.com/")]
        [InlineData("https://www.contoso.com/widgets/")]
        [InlineData("http://www.contoso.com/wdgets/moreWidgets/")]
        [InlineData("https://www.contoso.com:8080/")]
        [InlineData("https://www.contoso.com:8080/widgets/")]
       public void AzureEnvironmentDoesNotDuplicateSlash(string inputUri)
        {
            var testEnvironment = new ActiveDirectoryServiceSettings
            {
                ValidateAuthority = true,
                TokenAudience = new Uri("https://contoso.com/widgets/"),
                AuthenticationEndpoint = new Uri(inputUri)
            };
            Assert.Equal(inputUri, testEnvironment.AuthenticationEndpoint.ToString());
        }

        [Theory]
        [InlineData("https://www.contoso.com?widget=blue")]
        [InlineData("https://www.contoso.com/widgets/?widget=blue&color=yellow")]
        public void AzureEnvironmentRejectsInvalidUris(string inputUri)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ActiveDirectoryServiceSettings
            {
                ValidateAuthority = true,
                TokenAudience = new Uri("https://contoso.com/widgets/"),
                AuthenticationEndpoint = new Uri(inputUri)
            });
        }

        [Fact]
        public void AzureEnvironmenThrowsOnQueryInUri()
        {
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => new ActiveDirectoryServiceSettings
            {
                ValidateAuthority = true,
                TokenAudience = new Uri("https://contoso.com/widgets/"),
                AuthenticationEndpoint = new Uri("https://contoso.com/widgets/?api=123"),
            });
            Assert.True(error.Message.StartsWith("The authentication endpoint must not contain a query string.", StringComparison.CurrentCulture));
        }

        [Fact]
        public void AzureEnvironmenThrowsOnNullUri()
        {
            Assert.Throws<ArgumentNullException>(() => new ActiveDirectoryServiceSettings
            {
                ValidateAuthority = true,
                TokenAudience = new Uri("https://contoso.com/widgets/"),
                AuthenticationEndpoint = null
            });
        }

        [Fact]
        public void PromptOnlyClientSettingsWillAlwaysPrompt()
        {
            var clientId = Guid.NewGuid().ToString();
            var clientUri = new Uri("https://www.contoso.com/callbacks/");
            var settings = ActiveDirectoryClientSettings.UsePromptOnly(clientId, clientUri);
            Assert.Equal(clientId, settings.ClientId);
            Assert.Equal(clientUri, settings.ClientRedirectUri);
#if FullNetFx
            Assert.Equal(PromptBehavior.Always, settings.PromptBehavior);
#endif
            Assert.Equal(ActiveDirectoryClientSettings.EnableEbdMagicCookie, settings.AdditionalQueryParameters);
        }

        [Fact]
        public void NoPromptClientSettingsWillNeverPrompt()
        {
            var clientId = Guid.NewGuid().ToString();
            var clientUri = new Uri("https://www.contoso.com/callbacks/");
            var settings = ActiveDirectoryClientSettings.UseCacheOrCookiesOnly(clientId, clientUri);
            Assert.Equal(clientId, settings.ClientId);
            Assert.Equal(clientUri, settings.ClientRedirectUri);
#if FullNetFx
            Assert.Equal(PromptBehavior.Never, settings.PromptBehavior);
#endif
            Assert.Equal(ActiveDirectoryClientSettings.EnableEbdMagicCookie, settings.AdditionalQueryParameters);
        }

        [Fact]
        public void AutoPromptClientSettingsWillPromptIfNecessary()
        {
            var clientId = Guid.NewGuid().ToString();
            var clientUri = new Uri("https://www.contoso.com/callbacks/");
            var settings = ActiveDirectoryClientSettings.UseCacheCookiesOrPrompt(clientId, clientUri);
            Assert.Equal(clientId, settings.ClientId);
            Assert.Equal(clientUri, settings.ClientRedirectUri);
#if FullNetFx
            Assert.Equal(PromptBehavior.Auto, settings.PromptBehavior);
#endif
            Assert.Equal(ActiveDirectoryClientSettings.EnableEbdMagicCookie, settings.AdditionalQueryParameters);
        }

       [Fact]
        public void ClientSettingsDefaultToAutoPrompt()
        {
            var clientId = Guid.NewGuid().ToString();
            var clientUri = new Uri("https://www.contoso.com/callbacks/");
            var settings = new ActiveDirectoryClientSettings(clientId, clientUri);
            Assert.Equal(clientId, settings.ClientId);
            Assert.Equal(clientUri, settings.ClientRedirectUri);
#if FullNetFx
            Assert.Equal(PromptBehavior.Auto, settings.PromptBehavior);
#endif
            Assert.Equal(ActiveDirectoryClientSettings.EnableEbdMagicCookie, settings.AdditionalQueryParameters);
        }
}
}
