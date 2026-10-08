// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    [TestFixture(typeof(PrivateDnsARecordData))]
    [TestFixture(typeof(PrivateDnsAaaaRecordData))]
    [TestFixture(typeof(PrivateDnsCnameRecordData))]
    [TestFixture(typeof(PrivateDnsRecordData))]
    public class PrivateDnsRecordModelTests<T> where T : PrivateDnsBaseRecordData, IJsonModel<T>, new()
    {
        private const string ProfileId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/privateTrafficManagerProfiles/profile";

        [TestCase("J")]
        [TestCase("W")]
        public void ProfileIdUsesSharedStorageAndRoundTrips(string format)
        {
            var data = new T { TtlInSeconds = 300 };
            PrivateDnsBaseRecordData baseData = data;
            data.Metadata.Add("key", "value");
            data.TrafficManagementProfileId = new ResourceIdentifier(ProfileId);
            Assert.AreEqual(ProfileId, baseData.TrafficManagementProfileId.ToString());

            string replacementId = ProfileId + "-replacement";
            baseData.TrafficManagementProfileId = new ResourceIdentifier(replacementId);
            Assert.AreEqual(replacementId, data.TrafficManagementProfileId.ToString());

            var options = new ModelReaderWriterOptions(format);
            BinaryData serialized = ModelReaderWriter.Write<T>(data, options);
            using JsonDocument document = JsonDocument.Parse(serialized);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual(replacementId, properties.GetProperty("trafficManagementProfile").GetProperty("id").GetString());
            Assert.AreEqual(300, properties.GetProperty("ttl").GetInt32());
            Assert.AreEqual("value", properties.GetProperty("metadata").GetProperty("key").GetString());

            T roundTripped = ModelReaderWriter.Read<T>(serialized, options);
            Assert.AreEqual(data.TrafficManagementProfileId, roundTripped.TrafficManagementProfileId);
            Assert.AreEqual(data.TtlInSeconds, roundTripped.TtlInSeconds);
            Assert.AreEqual("value", roundTripped.Metadata["key"]);
            Assert.IsNull(roundTripped.ProvisioningState);
        }

        [TestCase("Succeeded", "J")]
        [TestCase("Succeeded", "W")]
        [TestCase("FutureState", "J")]
        [TestCase("FutureState", "W")]
        public void ResponseFieldsRoundTripWithoutSendingReadOnlyState(string state, string format)
        {
            BinaryData response = BinaryData.FromObjectAsJson(new
            {
                properties = new
                {
                    ttl = 300,
                    metadata = new { key = "value" },
                    trafficManagementProfile = new { id = ProfileId },
                    provisioningState = state
                }
            });
            T data = ModelReaderWriter.Read<T>(response, ModelReaderWriterOptions.Json);
            Assert.AreEqual(new ResourceIdentifier(ProfileId), data.TrafficManagementProfileId);
            Assert.AreEqual(new PrivateDnsProvisioningState(state), data.ProvisioningState);
            Assert.AreEqual(300, data.TtlInSeconds);
            Assert.AreEqual("value", data.Metadata["key"]);

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write<T>(data, new ModelReaderWriterOptions(format)));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual(ProfileId, properties.GetProperty("trafficManagementProfile").GetProperty("id").GetString());
            Assert.AreEqual(format == "J", properties.TryGetProperty("provisioningState", out JsonElement serializedState));
            if (format == "J")
            {
                Assert.AreEqual(state, serializedState.GetString());
            }
        }

        [TestCase("{}")]
        [TestCase("{\"properties\":null}")]
        [TestCase("{\"properties\":{}}")]
        [TestCase("{\"properties\":{\"ttl\":300}}")]
        [TestCase("{\"properties\":{\"trafficManagementProfile\":null,\"provisioningState\":null}}")]
        [TestCase("{\"properties\":{\"trafficManagementProfile\":{}}}")]
        [TestCase("{\"properties\":{\"trafficManagementProfile\":{\"id\":null}}}")]
        public void MissingAndNullResponseFieldsAreOptional(string json)
        {
            T data = ModelReaderWriter.Read<T>(BinaryData.FromString(json), ModelReaderWriterOptions.Json);
            Assert.IsNull(data.TrafficManagementProfileId);
            Assert.IsNull(data.ProvisioningState);
            Assert.DoesNotThrow(() => ModelReaderWriter.Write<T>(data, ModelReaderWriterOptions.Json));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ClearingProfilePreservesOtherProperties(string format)
        {
            var data = new T
            {
                TtlInSeconds = 300,
                TrafficManagementProfileId = new ResourceIdentifier(ProfileId)
            };
            data.Metadata.Add("key", "value");
            data.TrafficManagementProfileId = null;

            Assert.IsNull(data.TrafficManagementProfileId);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write<T>(data, new ModelReaderWriterOptions(format)));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual("{}", properties.GetProperty("trafficManagementProfile").GetRawText());
            Assert.AreEqual(300, properties.GetProperty("ttl").GetInt32());
            Assert.AreEqual("value", properties.GetProperty("metadata").GetProperty("key").GetString());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void SettingNullOnNewModelCreatesEmptyProfileLikePublicDns(string format)
        {
            var data = new T { TrafficManagementProfileId = null };
            Assert.IsNull(data.TrafficManagementProfileId);
            Assert.IsNull(data.ProvisioningState);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write<T>(data, new ModelReaderWriterOptions(format)));
            Assert.AreEqual("{}", document.RootElement.GetProperty("properties").GetProperty("trafficManagementProfile").GetRawText());
        }

        [TestCase(false, "J")]
        [TestCase(false, "W")]
        [TestCase(true, "J")]
        [TestCase(true, "W")]
        public void UpdatingProfileIdRetainsNestedResponseData(bool clear, string format)
        {
            BinaryData response = BinaryData.FromObjectAsJson(new
            {
                properties = new
                {
                    trafficManagementProfile = new { id = ProfileId, futureProperty = "preserved" }
                }
            });
            T data = ModelReaderWriter.Read<T>(response, ModelReaderWriterOptions.Json);
            ResourceIdentifier replacementId = clear ? null : new ResourceIdentifier(ProfileId + "-replacement");
            data.TrafficManagementProfileId = replacementId;

            Assert.AreEqual(replacementId, data.TrafficManagementProfileId);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write<T>(data, new ModelReaderWriterOptions(format)));
            JsonElement profile = document.RootElement.GetProperty("properties").GetProperty("trafficManagementProfile");
            Assert.AreEqual(!clear, profile.TryGetProperty("id", out JsonElement id));
            if (!clear)
            {
                Assert.AreEqual(replacementId.ToString(), id.GetString());
            }
            Assert.AreEqual(format == "J", profile.TryGetProperty("futureProperty", out JsonElement futureProperty));
            if (format == "J")
            {
                Assert.AreEqual("preserved", futureProperty.GetString());
            }
        }

        [Test]
        public void PublicAccessorsAreInheritedAndProvisioningStateIsReadOnly()
        {
            var profile = typeof(T).GetProperty(nameof(PrivateDnsBaseRecordData.TrafficManagementProfileId));
            Assert.AreEqual(typeof(PrivateDnsBaseRecordData), profile.DeclaringType);
            Assert.AreEqual(typeof(ResourceIdentifier), profile.PropertyType);
            Assert.IsTrue(profile.CanWrite);

            var state = typeof(T).GetProperty(nameof(PrivateDnsBaseRecordData.ProvisioningState));
            Assert.AreEqual(typeof(PrivateDnsBaseRecordData), state.DeclaringType);
            Assert.AreEqual(typeof(PrivateDnsProvisioningState?), state.PropertyType);
            Assert.IsFalse(state.CanWrite);
        }

        [Test]
        public void OrdinaryRecordDataStillRoundTrips()
        {
            var data = new T { TtlInSeconds = 300 };
            data.Metadata.Add("key", "value");
            string recordProperty;
            switch (data)
            {
                case PrivateDnsARecordData a:
                    a.PrivateDnsARecords.Add(new PrivateDnsARecordInfo { IPv4Address = IPAddress.Parse("10.0.0.4") });
                    recordProperty = "aRecords";
                    break;
                case PrivateDnsAaaaRecordData aaaa:
                    aaaa.PrivateDnsAaaaRecords.Add(new PrivateDnsAaaaRecordInfo { IPv6Address = IPAddress.Parse("fd00::4") });
                    recordProperty = "aaaaRecords";
                    break;
                case PrivateDnsCnameRecordData cname:
                    cname.Cname = "target.example.com";
                    recordProperty = "cnameRecord";
                    break;
                case PrivateDnsRecordData record:
                    record.ARecords.Add(new PrivateDnsARecordInfo { IPv4Address = IPAddress.Parse("10.0.0.4") });
                    recordProperty = "aRecords";
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported fixture type {typeof(T).Name}.");
            }

            BinaryData serialized = ModelReaderWriter.Write<T>(data, ModelReaderWriterOptions.Json);
            T roundTripped = ModelReaderWriter.Read<T>(serialized, ModelReaderWriterOptions.Json);
            using JsonDocument before = JsonDocument.Parse(serialized);
            using JsonDocument after = JsonDocument.Parse(ModelReaderWriter.Write<T>(roundTripped, ModelReaderWriterOptions.Json));
            JsonElement beforeProperties = before.RootElement.GetProperty("properties");
            JsonElement afterProperties = after.RootElement.GetProperty("properties");
            Assert.AreEqual(beforeProperties.GetProperty(recordProperty).GetRawText(), afterProperties.GetProperty(recordProperty).GetRawText());
            Assert.AreEqual(300, roundTripped.TtlInSeconds);
            Assert.AreEqual("value", roundTripped.Metadata["key"]);
            Assert.IsNull(roundTripped.TrafficManagementProfileId);
            Assert.IsNull(roundTripped.ProvisioningState);
        }
    }
}
