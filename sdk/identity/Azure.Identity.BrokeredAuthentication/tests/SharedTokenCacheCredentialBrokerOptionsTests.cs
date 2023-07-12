// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.BrokeredAuthentication.Tests
{
    public class SharedTokenCacheCredentialBrokerOptionsTests
    {
        [Test]
        public void VerifyTokenCacheOptionsCtorParam()
        {
            // verify passed in TokenCachePersistenceOptions are honored
            var persistenceOptions = new TokenCachePersistenceOptions { Name = "mocktokencachename" };

            var credentialOptions = new SharedTokenCacheCredentialBrokerOptions(persistenceOptions);

            Assert.AreEqual(persistenceOptions, credentialOptions.TokenCachePersistenceOptions);
        }

        [Test]
        public void RespectsMsaPassthrough([Values(true, false, null)] bool? enableMsaPassthrough)
        {
            IMsalPublicClientInitializerOptions credentialOptions;
            if (enableMsaPassthrough.HasValue)
            {
                credentialOptions = new SharedTokenCacheCredentialBrokerOptions(enableMsaPassthrough: enableMsaPassthrough.Value) as IMsalPublicClientInitializerOptions;
            }
            else
            {
                credentialOptions = new SharedTokenCacheCredentialBrokerOptions() as IMsalPublicClientInitializerOptions;
            }
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder
                .Create(Guid.NewGuid().ToString());

            credentialOptions.BeforeBuildClient(builder);

            WindowsBrokerOptions options = GetWindowsBrokerOptions(builder);
            Assert.AreEqual(enableMsaPassthrough, options?.MsaPassthrough);
        }

        private WindowsBrokerOptions GetWindowsBrokerOptions(PublicClientApplicationBuilder builder)
        {
            var config = builder
                .GetType()
                .BaseType.GetProperty("Config", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(builder);
            Console.WriteLine(config);

            var options = config.GetType().GetProperty("WindowsBrokerOptions").GetValue(config);
            Console.WriteLine(options);
            return options as WindowsBrokerOptions;
        }
    }
}
