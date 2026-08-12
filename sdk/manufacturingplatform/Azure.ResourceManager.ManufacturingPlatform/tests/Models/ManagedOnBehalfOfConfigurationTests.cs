// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ManufacturingPlatform.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ManufacturingPlatform.Tests.Models
{
    public class ManagedOnBehalfOfConfigurationTests
    {
        [Test]
        public void DeserializeWithoutBrokerResourcesCanSerialize()
        {
            using JsonDocument document = JsonDocument.Parse("{}");
            ManagedOnBehalfOfConfiguration configuration = ManagedOnBehalfOfConfiguration.DeserializeManagedOnBehalfOfConfiguration(document.RootElement, ModelReaderWriterOptions.Json);

            Assert.DoesNotThrow(() => ((IPersistableModel<ManagedOnBehalfOfConfiguration>)configuration).Write(ModelReaderWriterOptions.Json));
        }
    }
}