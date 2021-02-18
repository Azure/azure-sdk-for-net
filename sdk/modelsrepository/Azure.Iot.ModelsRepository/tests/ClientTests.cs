// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ClientTests : ModelsRepoTestBase
    {
        [Test]
        public void CtorOverloads()
        {
            string remoteUriStr = "https://dtmi.com";
            Uri remoteUri = new Uri(remoteUriStr);

            ModelsRepoClientOptions options = new ModelsRepoClientOptions();

            Assert.AreEqual(new Uri(ModelsRepoClient.DefaultModelsRepository), new ModelsRepoClient().RepositoryUri);
            Assert.AreEqual($"{ModelsRepoClient.DefaultModelsRepository}/", new ModelsRepoClient().RepositoryUri.AbsoluteUri);
            Assert.AreEqual(new Uri(ModelsRepoClient.DefaultModelsRepository), new ModelsRepoClient(options).RepositoryUri);

            Assert.AreEqual(remoteUri, new ModelsRepoClient(remoteUri).RepositoryUri);
            Assert.AreEqual(remoteUri, new ModelsRepoClient(remoteUri, options).RepositoryUri);

            Assert.AreEqual(remoteUri, new ModelsRepoClient(remoteUriStr).RepositoryUri);
            Assert.AreEqual(remoteUri, new ModelsRepoClient(remoteUriStr, options).RepositoryUri);

            string localUriStr = TestLocalModelRepository;
            Uri localUri = new Uri(localUriStr);

            Assert.AreEqual(localUri, new ModelsRepoClient(localUri).RepositoryUri);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                localUriStr = localUriStr.Replace("\\", "/");
            }

            Assert.AreEqual(localUriStr, new ModelsRepoClient(localUri).RepositoryUri.AbsolutePath);
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
            Assert.AreEqual(expected, ModelsRepoClient.IsValidDtmi(dtmi));
        }

        [Test]
        public void ClientOptions()
        {
            DependencyResolutionOption defaultResolutionOption = DependencyResolutionOption.Enabled;

            ModelsRepoClientOptions customOptions =
                new ModelsRepoClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);

            int maxRetries = 10;
            customOptions.Retry.MaxRetries = maxRetries;

            string repositoryUriString = "https://localhost/myregistry/";
            Uri repositoryUri = new Uri(repositoryUriString);

            ModelsRepoClient defaultClient = new ModelsRepoClient(repositoryUri);
            Assert.AreEqual(defaultResolutionOption, defaultClient.ClientOptions.DependencyResolution);

            ModelsRepoClient customClient = new ModelsRepoClient(repositoryUriString, customOptions);
            Assert.AreEqual(DependencyResolutionOption.TryFromExpanded, customClient.ClientOptions.DependencyResolution);
            Assert.AreEqual(maxRetries, customClient.ClientOptions.Retry.MaxRetries);
        }

        [Test]
        public void EvaluateEventSourceKPIs()
        {
            Type eventSourceType = typeof(ModelsRepoEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual(ModelRepositoryConstants.ModelRepositoryEventSourceName, EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("7678f8d4-81db-5fd2-39fc-23552d86b171"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }
    }
}
