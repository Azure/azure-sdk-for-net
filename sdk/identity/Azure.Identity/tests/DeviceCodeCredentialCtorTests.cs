// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DeviceCodeCredentialCtorTests
    {
        private Task DummyCallback(DeviceCodeInfo _info, CancellationToken _cancellationToken)
        {
            return Task.CompletedTask;
        }

        [Test]
        public void ValidateDefaultConstructor()
        {
            var credential = new DeviceCodeCredential();

            AssertOptionsHonored(new DeviceCodeCredentialOptions(), credential);
        }

        [Test]
        public void ValidateConstructorOverload1()
        {
            // tests the DeviceCodeCredential constructor overload
            // public DeviceCodeCredential(DeviceCodeCredentialOptions options)

            // null
            var credential = new DeviceCodeCredential(null);

            AssertOptionsHonored(new DeviceCodeCredentialOptions(), credential);

            // with options

            // with options
            var options = new DeviceCodeCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                AuthorityHost = new Uri("https://login.myauthority.com/"),
                DisableAutomaticAuthentication = true,
                TokenCache = new TokenCache(),
                AuthenticationRecord = new AuthenticationRecord(),
                DeviceCodeCallback = DummyCallback,
            };

            credential = new DeviceCodeCredential(options);

            AssertOptionsHonored(options, credential);
        }

        [Test]
        public void ValidateConstructorOverload2()
        {
            // tests the DeviceCodeCredential constructor overload
            // public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string clientId, TokenCredentialOptions options = default)

            var options = new DeviceCodeCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString(),
                DeviceCodeCallback = DummyCallback,
            };

            // deviceCodeCallback null
            Assert.Throws<ArgumentNullException>(() => new DeviceCodeCredential(null, options.ClientId));

            // clientId null
            Assert.Throws<ArgumentNullException>(() => new DeviceCodeCredential(options.DeviceCodeCallback, null));

            // without options
            var credential = new DeviceCodeCredential(options.DeviceCodeCallback, options.ClientId);

            AssertOptionsHonored(options, credential);

            // with options
            options.AuthorityHost = new Uri("https://login.myauthority.com/");

            credential = new DeviceCodeCredential(options.DeviceCodeCallback, options.ClientId, new TokenCredentialOptions { AuthorityHost = options.AuthorityHost });

            AssertOptionsHonored(options, credential);
        }

        [Test]
        public void ValidateConstructorOverload3()
        {
            // tests the DeviceCodeCredential constructor overload
            // public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId, TokenCredentialOptions options = default)

            var options = new DeviceCodeCredentialOptions
            {
                ClientId = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                DeviceCodeCallback = DummyCallback,
            };

            // deviceCodeCallback null
            Assert.Throws<ArgumentNullException>(() => new DeviceCodeCredential(null, options.TenantId, options.ClientId));

            // clientId null
            Assert.Throws<ArgumentNullException>(() => new DeviceCodeCredential(options.DeviceCodeCallback, options.TenantId, (string)null));

            // without options
            var credential = new DeviceCodeCredential(options.DeviceCodeCallback, options.TenantId, options.ClientId);

            AssertOptionsHonored(options, credential);

            // with options
            options.AuthorityHost = new Uri("https://login.myauthority.com/");

            credential = new DeviceCodeCredential(options.DeviceCodeCallback, options.TenantId, options.ClientId, new TokenCredentialOptions { AuthorityHost = options.AuthorityHost });

            AssertOptionsHonored(options, credential);
        }

        public void AssertOptionsHonored(DeviceCodeCredentialOptions options, DeviceCodeCredential credential)
        {
            Assert.AreEqual(options.ClientId, credential.ClientId);
            Assert.AreEqual(options.TenantId, credential.Client.TenantId);
            Assert.AreEqual(options.AuthorityHost, credential.Pipeline.AuthorityHost);
            Assert.AreEqual(options.DisableAutomaticAuthentication, credential.DisableAutomaticAuthentication);
            Assert.AreEqual(options.TokenCache, credential.Client.TokenCache);
            Assert.AreEqual(options.AuthenticationRecord, credential.Record);

            AssertCallbacksEqual(options.DeviceCodeCallback ?? DeviceCodeCredential.DefaultDeviceCodeHandler, credential.DeviceCodeCallback);
        }

        public void AssertCallbacksEqual(Func<DeviceCodeInfo, CancellationToken, Task> expected, Func<DeviceCodeInfo, CancellationToken, Task> actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
