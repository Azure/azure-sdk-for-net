// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class SharedTokenCacheCredentialBrokerOptionsTests
    {
        [Test]
        public void VerifyTokenCacheOptionsCtorParam()
        {
            // verify passed in TokenCachePersistenceOptions are honored
            var persistenceOptions = new TokenCachePersistenceOptions { Name = "mocktokencachename" };
#pragma warning disable CS0618 // Type or member is obsolete
            var credentialOptions = new SharedTokenCacheCredentialBrokerOptions(persistenceOptions);
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.AreEqual(persistenceOptions, credentialOptions.TokenCachePersistenceOptions);
        }

        [Test]
        public void RespectsMsaPassthrough([Values(true, false, null)] bool? enableMsaPassthrough)
        {
            IMsalPublicClientInitializerOptions credentialOptions;
            if (enableMsaPassthrough.HasValue)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                credentialOptions = new SharedTokenCacheCredentialBrokerOptions { IsLegacyMsaPassthroughEnabled = enableMsaPassthrough.Value };
#pragma warning restore CS0618 // Type or member is obsolete
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                credentialOptions = new SharedTokenCacheCredentialBrokerOptions();
#pragma warning restore CS0618 // Type or member is obsolete
            }
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder
                .Create(Guid.NewGuid().ToString());

            credentialOptions.BeforeBuildClient(builder);

            BrokerOptions options = GetBrokerOptions(builder);
            Assert.AreEqual(enableMsaPassthrough ?? false, options?.MsaPassthrough);
        }

        private BrokerOptions GetBrokerOptions(PublicClientApplicationBuilder builder)
        {
            var config = builder
                .GetType()
                .BaseType.GetProperty("Config", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(builder);
            Console.WriteLine(config);

            var options = config.GetType().GetProperty("BrokerOptions").GetValue(config);
            Console.WriteLine(options);
            return options as BrokerOptions;
        }
    }
}
