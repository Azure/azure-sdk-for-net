// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Identity;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SignalRServiceExtension.Tests;
using Xunit;
using static Microsoft.Azure.SignalR.Tests.Common.FakeEndpointUtils;
namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignatureValidationOptionsSetupTests
    {
        private static readonly string AccessKeyConnectionString = GetFakeConnectionString(1).Single();
        private const string AadConnectionString = "Endpoint=http://localhost; AuthType=aad ;Version=1.0;";
        public static IEnumerable<object[]> ConfigureTestData()
        {
            yield return new object[] { AccessKeyConnectionString, null, true, new string[] { FakeAccessKey } };
            yield return new object[] { null, GetFakeEndpoint(2), true, Enumerable.Repeat(FakeAccessKey, 2) };
            yield return new object[] { AccessKeyConnectionString, GetFakeEndpoint(2), true, Enumerable.Repeat(FakeAccessKey, 3) };

            yield return new object[] { AadConnectionString, null, false, null };
            yield return new object[] { AadConnectionString, new ServiceEndpoint[] { new ServiceEndpoint(new Uri("https://endpoint"), new DefaultAzureCredential()), new ServiceEndpoint(AadConnectionString) }, false, null };
        }

        [Theory]
        [MemberData(nameof(ConfigureTestData))]
        public void OptionsConfigureTest(string connectionString, IEnumerable<ServiceEndpoint> serviceEndpoints, bool expectedValidationRequirement, string[] expectedAccessKey)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[Constants.AzureSignalRConnectionStringName] = connectionString;
            var signalROptions = new SignalROptions()
            {
                ServiceTransportType = ServiceTransportType.Persistent
            };
            foreach (var endpoint in serviceEndpoints ?? Array.Empty<ServiceEndpoint>())
            {
                signalROptions.ServiceEndpoints.Add(endpoint);
            }
            var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(signalROptions));
            var hubContextStore = serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName);
            var signatureValidationOptions = hubContextStore.SignatureValidationOptions.CurrentValue;
            Assert.Equal(expectedValidationRequirement, signatureValidationOptions.RequireValidation);
            if (expectedValidationRequirement)
            {
                Assert.True(expectedAccessKey.SequenceEqual(signatureValidationOptions.AccessKeys));
            }
        }

        [Fact]
        public void OptionsHotReloadTest()
        {
            var configuration = new ConfigurationRoot(new List<IConfigurationProvider>() { new MemoryConfigurationProvider(new()) });
            configuration[Constants.AzureSignalRConnectionStringName] = AadConnectionString;
            var serviceManagerStore = new ServiceManagerStore(configuration, NullLoggerFactory.Instance, SingletonAzureComponentFactory.Instance, Options.Create(new SignalROptions()));
            var options = serviceManagerStore.GetOrAddByConnectionStringKey(Constants.AzureSignalRConnectionStringName).SignatureValidationOptions;
            Assert.False(options.CurrentValue.RequireValidation);

            configuration[Constants.AzureSignalRConnectionStringName] = AccessKeyConnectionString;
            configuration.Reload();
            Assert.True(options.CurrentValue.RequireValidation);
            Assert.Equal(FakeAccessKey, options.CurrentValue.AccessKeys.Single());
        }
    }
}
