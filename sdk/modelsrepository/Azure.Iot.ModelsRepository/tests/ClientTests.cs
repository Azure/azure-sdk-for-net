// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
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
            Uri defaultRepositoryUri = new Uri(ModelsRepositoryConstants.DefaultModelsRepository);

            new ModelsRepositoryClient().RepositoryUri.Should().Be(defaultRepositoryUri);
            new ModelsRepositoryClient(remoteUri).RepositoryUri.Should().Be(remoteUri);

            string localUriStr = TestLocalModelRepository;

            var localUri = new Uri(localUriStr);
            new ModelsRepositoryClient(localUri).RepositoryUri.Should().Be(localUri);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                localUriStr = localUriStr.Replace("\\", "/");
            }

            new ModelsRepositoryClient(localUri).RepositoryUri.AbsolutePath.Should().Be(localUriStr);
        }

        [Test]
        public void EvaluateEventSourceKPIs()
        {
            Type eventSourceType = typeof(ModelsRepositoryEventSource);

            eventSourceType.Should().NotBeNull();
            EventSource.GetName(eventSourceType).Should().Be(ModelsRepositoryConstants.ModelRepositoryEventSourceName);
            EventSource.GetGuid(eventSourceType).Should().Be(Guid.Parse("7678f8d4-81db-5fd2-39fc-23552d86b171"));
            EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest").Should().NotBeNullOrEmpty();
        }
    }
}
