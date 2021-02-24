// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ClientTests : ModelsRepositoryTestBase
    {
        [Test]
        public void CtorOverloads()
        {
            string remoteUriStr = "https://dtmi.com";
            Uri remoteUri = new Uri(remoteUriStr);

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions();

            Assert.AreEqual(ModelsRepositoryClient.DefaultModelsRepository, new ModelsRepositoryClient().RepositoryUri);
            Assert.AreEqual(ModelsRepositoryClient.DefaultModelsRepository, new ModelsRepositoryClient().RepositoryUri);
            Assert.AreEqual(ModelsRepositoryClient.DefaultModelsRepository, new ModelsRepositoryClient(options).RepositoryUri);

            Assert.AreEqual(remoteUri, new ModelsRepositoryClient(remoteUri).RepositoryUri);
            Assert.AreEqual(remoteUri, new ModelsRepositoryClient(remoteUri, options).RepositoryUri);

            string localUriStr = TestLocalModelRepository;
            Uri localUri = new Uri(localUriStr);

            Assert.AreEqual(localUri, new ModelsRepositoryClient(localUri).RepositoryUri);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                localUriStr = localUriStr.Replace("\\", "/");
            }

            Assert.AreEqual(localUriStr, new ModelsRepositoryClient(localUri).RepositoryUri.AbsolutePath);
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
            Assert.AreEqual(expected, ModelsRepositoryClient.IsValidDtmi(dtmi));
        }

        [Test]
        public void EvaluateEventSourceKPIs()
        {
            Type eventSourceType = typeof(ModelsRepositoryEventSource);

            Assert.NotNull(eventSourceType);
            Assert.AreEqual(ModelRepositoryConstants.ModelRepositoryEventSourceName, EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("7678f8d4-81db-5fd2-39fc-23552d86b171"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }
    }
}
