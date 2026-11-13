// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.WorkloadManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.WorkloadManager.Tests
{
    public class ModelFactoryTests
    {
        [TestCaseSource(nameof(DiscriminatedModels))]
        public void ModelFactoryPreservesDiscriminator(object model, string propertyName, string expectedValue)
        {
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(model));

            Assert.That(document.RootElement.GetProperty(propertyName).GetString(), Is.EqualTo(expectedValue));
        }

        private static object[] DiscriminatedModels =>
        [
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.RuntimeBindingProperties(provisioningMode: "Custom"),
                "provisioningMode",
                "Custom"
            },
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.ExecutionIdentity("Custom"),
                "provisioningMode",
                "Custom"
            },
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.ReferencedExecutionIdentity(),
                "provisioningMode",
                "Referenced"
            },
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.ServiceManagedExecutionIdentity(),
                "provisioningMode",
                "ServiceManaged"
            },
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.ManagedRuntimeBindingProperties(),
                "provisioningMode",
                "Managed"
            },
            new object[]
            {
                ArmComputeWorkloadManagerModelFactory.ReferencedRuntimeBindingProperties(),
                "provisioningMode",
                "Referenced"
            }
        ];
    }
}
