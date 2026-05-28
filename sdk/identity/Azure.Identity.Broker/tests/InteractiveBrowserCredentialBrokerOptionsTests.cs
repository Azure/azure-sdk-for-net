// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class InteractiveBrowserCredentialBrokerOptionsTests
    {
        [Test]
        public void RespectsMsaPassthrough(
            [Values(true, false, null)] bool? enableMsaPassthrough)
        {
            IntPtr parentWindowHandle = new(1234);
            IMsalPublicClientInitializerOptions credentialOptions;
            if (enableMsaPassthrough.HasValue)
            {
                credentialOptions = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { IsLegacyMsaPassthroughEnabled = enableMsaPassthrough.Value };
            }
            else
            {
                credentialOptions = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle);
            }
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder
                .Create(Guid.NewGuid().ToString());

            credentialOptions.BeforeBuildClient(builder);

            (BrokerOptions Options, Func<object> Parent) = GetBrokerOptions(builder);
            Assert.AreEqual(enableMsaPassthrough ?? false, Options?.MsaPassthrough);
            Assert.AreEqual(parentWindowHandle, Parent());
        }

        [Test]
        public void RespectsUseOperatingSystemAccount(
            [Values(true, false)] bool enableUseOperatingSystemAccount)
        {
            IntPtr parentWindowHandle = new(1234);
            IMsalPublicClientInitializerOptions credentialOptions;
                credentialOptions = new InteractiveBrowserCredentialBrokerOptions(parentWindowHandle) { UseDefaultBrokerAccount = enableUseOperatingSystemAccount };
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder
                .Create(Guid.NewGuid().ToString());

            var credential = new InteractiveBrowserCredential((InteractiveBrowserCredentialBrokerOptions)credentialOptions);
            Assert.AreEqual(enableUseOperatingSystemAccount, credential.UseOperatingSystemAccount);
        }

        private static (BrokerOptions Options, Func<object> Parent) GetBrokerOptions(PublicClientApplicationBuilder builder)
        {
            var config = builder
                .GetType()
                .BaseType.GetProperty("Config", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(builder);
            Console.WriteLine(config);

            var options = config.GetType().GetProperty("BrokerOptions").GetValue(config);
            Console.WriteLine(options);
            var parent = config.GetType().GetProperty("ParentActivityOrWindowFunc").GetValue(config);

            return (options as BrokerOptions, parent as Func<object>);
        }
    }
}
