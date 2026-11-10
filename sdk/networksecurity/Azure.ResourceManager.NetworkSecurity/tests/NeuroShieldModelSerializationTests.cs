// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkSecurity.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkSecurity.Tests
{
    public class NeuroShieldModelSerializationTests
    {
        private static readonly Guid PrincipalId = new Guid("11111111-2222-3333-4444-555555555555");
        private static readonly Guid TenantId = new Guid("22222222-3333-4444-5555-666666666666");
        private static readonly Guid ClientId = new Guid("33333333-4444-5555-6666-777777777777");

        [TestCase("\"resource-version\"")]
        [TestCase("W/\"resource-version\"")]
        public void ResourceGuidAndETagPreserveResponseValues(string entityTag)
        {
            string json = $$"""
                {
                  "location": "eastus",
                  "etag": {{JsonSerializer.Serialize(entityTag)}},
                  "properties": {
                    "responseMode": "Auto",
                    "resourceGuid": "{{PrincipalId:D}}"
                  }
                }
                """;
            var data = ModelReaderWriter.Read<NeuroShieldData>(BinaryData.FromString(json));

            Guid? resourceGuid = data.Properties.ResourceGuid;
            ETag? etag = data.ETag;
            Assert.That(resourceGuid, Is.EqualTo(PrincipalId));
            Assert.That(etag, Is.EqualTo(new ETag(entityTag)));
            using var persisted = JsonDocument.Parse(ModelReaderWriter.Write(data));
            Assert.That(persisted.RootElement.GetProperty("etag").GetString(), Is.EqualTo(entityTag));
            Assert.That(persisted.RootElement.GetProperty("properties").GetProperty("resourceGuid").GetGuid(), Is.EqualTo(PrincipalId));
            using var wire = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")));
            Assert.That(wire.RootElement.TryGetProperty("etag", out _), Is.False);
            Assert.That(wire.RootElement.GetProperty("properties").TryGetProperty("resourceGuid", out _), Is.False);
        }

        [Test]
        public void MissingOptionalIdentifiersRemainNull()
        {
            var data = ModelReaderWriter.Read<NeuroShieldData>(
                BinaryData.FromString("""{"location":"eastus","properties":{"responseMode":"Auto"}}"""));
            var identity = ModelReaderWriter.Read<NeuroShieldProtectedResourceIdentity>(
                BinaryData.FromString("""{"type":"None"}"""));
            var userIdentity = new NeuroShieldProtectedResourceUserAssignedIdentity();

            Assert.That(data.ETag, Is.Null);
            Assert.That(data.Properties.ResourceGuid, Is.Null);
            Assert.That(identity.PrincipalId, Is.Null);
            Assert.That(identity.TenantId, Is.Null);
            Assert.That(identity.UserAssignedIdentities, Is.Empty);
            Assert.That(userIdentity.PrincipalId, Is.Null);
            Assert.That(userIdentity.ClientId, Is.Null);
        }

        [Test]
        public void SystemAssignedIdentityRoundTripsGuidFields()
        {
            var identity = new NeuroShieldProtectedResourceIdentity(ManagedServiceIdentityType.SystemAssigned)
            {
                PrincipalId = PrincipalId,
                TenantId = TenantId
            };
            BinaryData json = ModelReaderWriter.Write(identity, new ModelReaderWriterOptions("W"));
            using var document = JsonDocument.Parse(json);
            Assert.That(document.RootElement.GetProperty("principalId").GetGuid(), Is.EqualTo(PrincipalId));
            Assert.That(document.RootElement.GetProperty("tenantId").GetGuid(), Is.EqualTo(TenantId));
            Assert.That(document.RootElement.TryGetProperty("userAssignedIdentities", out _), Is.False);

            var roundTrip = ModelReaderWriter.Read<NeuroShieldProtectedResourceIdentity>(json);
            Assert.That(roundTrip.PrincipalId, Is.EqualTo(PrincipalId));
            Assert.That(roundTrip.TenantId, Is.EqualTo(TenantId));
            Assert.That(roundTrip.Type, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
        }

        [Test]
        public void UserAssignedIdentityRoundTripsTypedDictionary()
        {
            const string identityId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var identity = new NeuroShieldProtectedResourceIdentity(ManagedServiceIdentityType.UserAssigned);
            identity.UserAssignedIdentities.Add(identityId, new NeuroShieldProtectedResourceUserAssignedIdentity
            {
                PrincipalId = PrincipalId,
                ClientId = ClientId
            });

            BinaryData json = ModelReaderWriter.Write(identity, new ModelReaderWriterOptions("W"));
            using var document = JsonDocument.Parse(json);
            var entry = document.RootElement.GetProperty("userAssignedIdentities").GetProperty(identityId);
            Assert.That(entry.GetProperty("principalId").GetGuid(), Is.EqualTo(PrincipalId));
            Assert.That(entry.GetProperty("clientId").GetGuid(), Is.EqualTo(ClientId));

            var roundTrip = ModelReaderWriter.Read<NeuroShieldProtectedResourceIdentity>(json);
            Assert.That(roundTrip.UserAssignedIdentities, Has.Count.EqualTo(1));
            NeuroShieldProtectedResourceUserAssignedIdentity value = roundTrip.UserAssignedIdentities[identityId];
            Assert.That(value.PrincipalId, Is.EqualTo(PrincipalId));
            Assert.That(value.ClientId, Is.EqualTo(ClientId));
        }

        [Test]
        public void InventoryRequestMetadataRoundTripsGuid()
        {
            var requestId = new Guid("12345678-1234-5678-9abc-123456789abc");
            var metadata = ModelReaderWriter.Read<NeuroShieldInventoryUploadRequestMetadata>(
                BinaryData.FromString($$"""{"requestId":"{{requestId:D}}","requestedAt":"2026-11-04T00:00:00Z","expiresAt":"2026-11-05T00:00:00Z"}"""));

            Guid actualRequestId = metadata.RequestId;
            Assert.That(actualRequestId, Is.EqualTo(requestId));
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(metadata));
            Assert.That(document.RootElement.GetProperty("requestId").GetString(), Is.EqualTo(requestId.ToString("D")));

            var factoryModel = ArmNetworkSecurityModelFactory.NeuroShieldInventoryUploadRequestMetadata(
                requestId, metadata.RequestedOn, metadata.ExpiresOn);
            Assert.That(ModelReaderWriter.Read<NeuroShieldInventoryUploadRequestMetadata>(
                ModelReaderWriter.Write(factoryModel)).RequestId, Is.EqualTo(requestId));
        }

        [Test]
        public void InventoryRequestResultRoundTripsGuid()
        {
            var requestId = new Guid("12345678-1234-5678-9abc-123456789abc");
            var result = ModelReaderWriter.Read<NeuroShieldInventoryUploadRequestResult>(
                BinaryData.FromString($$"""{"requestId":"{{requestId:D}}","requestedAt":"2026-11-04T00:00:00Z","expiresAt":"2026-11-05T00:00:00Z","deduplicated":true}"""));

            Guid actualRequestId = result.RequestId;
            Assert.That(actualRequestId, Is.EqualTo(requestId));
            Assert.That(result.Deduplicated, Is.True);
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(result));
            Assert.That(document.RootElement.GetProperty("requestId").GetString(), Is.EqualTo(requestId.ToString("D")));

            var factoryModel = ArmNetworkSecurityModelFactory.NeuroShieldInventoryUploadRequestResult(
                requestId, result.RequestedOn, result.ExpiresOn, result.Deduplicated);
            Assert.That(ModelReaderWriter.Read<NeuroShieldInventoryUploadRequestResult>(
                ModelReaderWriter.Write(factoryModel)).RequestId, Is.EqualTo(requestId));
        }
    }
}
