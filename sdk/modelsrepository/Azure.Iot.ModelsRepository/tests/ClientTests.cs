// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ClientTests
    {
        [Test]
        public void CtorOverloads()
        {
            string remoteUriStr = "https://dtmi.com";
            Uri remoteUri = new Uri(remoteUriStr);

            ResolverClientOptions options = new ResolverClientOptions();

            Assert.AreEqual(new Uri(ResolverClient.DefaultRepository), new ResolverClient().RepositoryUri);
            Assert.AreEqual($"{ResolverClient.DefaultRepository}/", new ResolverClient().RepositoryUri.AbsoluteUri);
            Assert.AreEqual(new Uri(ResolverClient.DefaultRepository), new ResolverClient(options).RepositoryUri);

            Assert.AreEqual(remoteUri, new ResolverClient(remoteUri).RepositoryUri);
            Assert.AreEqual(remoteUri, new ResolverClient(remoteUri, options).RepositoryUri);
            Assert.AreEqual(remoteUri, new ResolverClient(remoteUri, null).RepositoryUri);

            Assert.AreEqual(remoteUri, new ResolverClient(remoteUriStr).RepositoryUri);
            Assert.AreEqual(remoteUri, new ResolverClient(remoteUriStr, options).RepositoryUri);
            Assert.AreEqual(remoteUri, new ResolverClient(remoteUriStr, null).RepositoryUri);

            string localUriStr = TestHelpers.TestLocalModelRepository;
            Uri localUri = new Uri(localUriStr);

            Assert.AreEqual(localUri, new ResolverClient(localUri).RepositoryUri);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                localUriStr = localUriStr.Replace("\\", "/");
            }

            Assert.AreEqual(localUriStr, new ResolverClient(localUri).RepositoryUri.AbsolutePath);
        }

        [TestCase("dtmi:com:example:Thermostat;1", true)]
        [TestCase("dtmi:contoso:scope:entity;2", true)]
        [TestCase("dtmi:com:example:Thermostat:1", false)]
        [TestCase("dtmi:com:example::Thermostat;1", false)]
        [TestCase("com:example:Thermostat;1", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void ClientIsValidDtmi(string dtmi, bool expected)
        {
            Assert.AreEqual(expected, ResolverClient.IsValidDtmi(dtmi));
        }

        [Test]
        public void ClientOptions()
        {
            DependencyResolutionOption defaultResolutionOption = DependencyResolutionOption.Enabled;
            ResolverClientOptions customOptions =
                new ResolverClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);
            int maxRetries = 10;
            customOptions.Retry.MaxRetries = maxRetries;

            string repositoryUriString = "https://localhost/myregistry/";
            Uri repositoryUri = new Uri(repositoryUriString);

            ResolverClient defaultClient = new ResolverClient(repositoryUri);
            Assert.AreEqual(defaultResolutionOption, defaultClient.ClientOptions.DependencyResolution);

            ResolverClient customClient = new ResolverClient(repositoryUriString, customOptions);
            Assert.AreEqual(DependencyResolutionOption.TryFromExpanded, customClient.ClientOptions.DependencyResolution);
            Assert.AreEqual(maxRetries, customClient.ClientOptions.Retry.MaxRetries);
        }

        [Test]
        public void EvaluateEventSourceKPIs()
        {
            Type eventSourceType = typeof(ResolverEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual("Azure-Iot-ModelsRepository", ResolverEventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("7678f8d4-81db-5fd2-39fc-23552d86b171"), ResolverEventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(ResolverEventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }
    }
}
