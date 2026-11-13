// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Mocking;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    public class PrivateDnsResourceReferenceModelTests
    {
        private const string ProfileId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/privateTrafficManagerProfiles/profile";
        private const string RecordId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/privateDnsZones/example.com/A/record";

        [TestCase("J")]
        [TestCase("W")]
        public void ReferenceRequestRoundTripsTypedResourceIds(string format)
        {
            var content = new PrivateDnsResourceReferenceContent();
            content.TargetResources.Add(new PrivateDnsSubResourceInfo { Id = new ResourceIdentifier(ProfileId) });
            var options = new ModelReaderWriterOptions(format);
            BinaryData serialized = ModelReaderWriter.Write(content, options);

            using JsonDocument document = JsonDocument.Parse(serialized);
            JsonElement targets = document.RootElement.GetProperty("properties").GetProperty("targetResources");
            Assert.AreEqual(1, targets.GetArrayLength());
            Assert.AreEqual(ProfileId, targets[0].GetProperty("id").GetString());

            var roundTripped = ModelReaderWriter.Read<PrivateDnsResourceReferenceContent>(serialized, options);
            ResourceIdentifier targetId = roundTripped.TargetResources[0].Id;
            Assert.AreEqual(new ResourceIdentifier(ProfileId), targetId);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ReferenceResponseRoundTripsTypedResourceIds(string format)
        {
            BinaryData response = BinaryData.FromObjectAsJson(new
            {
                properties = new
                {
                    privateDnsResourceReferences = new[]
                    {
                        new
                        {
                            targetResource = new { id = ProfileId },
                            privateDnsResources = new[] { new { id = RecordId } }
                        }
                    }
                }
            });
            var options = new ModelReaderWriterOptions(format);
            var result = ModelReaderWriter.Read<PrivateDnsResourceReferenceResult>(response, options);
            Assert.AreEqual(1, result.PrivateDnsResourceReferences.Count);
            var reference = result.PrivateDnsResourceReferences[0];
            ResourceIdentifier targetId = reference.TargetResourceId;
            ResourceIdentifier recordId = reference.PrivateDnsResources[0].Id;
            Assert.AreEqual(new ResourceIdentifier(ProfileId), targetId);
            Assert.AreEqual(new ResourceIdentifier(RecordId), recordId);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(result, options));
            JsonElement serialized = document.RootElement.GetProperty("properties").GetProperty("privateDnsResourceReferences")[0];
            Assert.AreEqual(ProfileId, serialized.GetProperty("targetResource").GetProperty("id").GetString());
            Assert.AreEqual(RecordId, serialized.GetProperty("privateDnsResources")[0].GetProperty("id").GetString());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ReferenceQueryNamesAreServiceQualifiedOnBothSurfaces(bool async)
        {
            string name = async
                ? nameof(PrivateDnsExtensions.GetPrivateDnsResourceReferencesByTargetResourcesAsync)
                : nameof(PrivateDnsExtensions.GetPrivateDnsResourceReferencesByTargetResources);
            Type expectedReturnType = async
                ? typeof(Task<Response<PrivateDnsResourceReferenceResult>>)
                : typeof(Response<PrivateDnsResourceReferenceResult>);
            var extension = typeof(PrivateDnsExtensions).GetMethod(name,
                new[] { typeof(SubscriptionResource), typeof(PrivateDnsResourceReferenceContent), typeof(CancellationToken) });
            var mockable = typeof(MockablePrivateDnsSubscriptionResource).GetMethod(name,
                new[] { typeof(PrivateDnsResourceReferenceContent), typeof(CancellationToken) });
            Assert.IsNotNull(extension);
            Assert.IsNotNull(mockable);
            Assert.IsTrue(extension.IsStatic);
            Assert.IsTrue(mockable.IsVirtual);
            Assert.AreEqual(expectedReturnType, extension.ReturnType);
            Assert.AreEqual(expectedReturnType, mockable.ReturnType);

            string oldName = async ? "GetByTargetResourcesAsync" : "GetByTargetResources";
            Assert.IsNull(typeof(PrivateDnsExtensions).GetMethod(oldName));
            Assert.IsNull(typeof(MockablePrivateDnsSubscriptionResource).GetMethod(oldName));
        }

        [Test]
        public void SubResourceModelIsServiceQualifiedWithTypedId()
        {
            Assert.AreEqual(typeof(ResourceIdentifier), typeof(PrivateDnsSubResourceInfo).GetProperty(nameof(PrivateDnsSubResourceInfo.Id)).PropertyType);
            Assert.IsNull(typeof(PrivateDnsSubResourceInfo).Assembly.GetType("Azure.ResourceManager.PrivateDns.Models.SubResource"));
        }
    }
}
