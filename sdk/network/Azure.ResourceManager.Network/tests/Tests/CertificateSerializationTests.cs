// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class CertificateSerializationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string Base64Certificate = "MIIBAgD/";
        private const string PemCertificate = "-----BEGIN CERTIFICATE-----\r\nMIIBAgD/\r\n-----END CERTIFICATE-----\r\n";

        [TestCase("J", Base64Certificate)]
        [TestCase("W", Base64Certificate)]
        [TestCase("J", PemCertificate)]
        [TestCase("W", PemCertificate)]
        [TestCase("J", "")]
        [TestCase("W", "")]
        public void ReadApplicationGatewayCertificatesPreservesJsonStrings(string format, string certificate)
        {
            var options = new ModelReaderWriterOptions(format);
            var gateway = ModelReaderWriter.Read<ApplicationGatewayData>(
                CreateGatewayJson(JsonSerializer.Serialize(certificate)), options, AzureResourceManagerNetworkContext.Default);

            Assert.That(gateway.AuthenticationCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(certificate));
            Assert.That(gateway.TrustedRootCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(certificate));
            Assert.That(gateway.TrustedClientCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(certificate));
            Assert.That(gateway.TrustedClientCertificates[0].ValidatedCertData.ToObjectFromJson<string>(), Is.EqualTo(certificate));
            Assert.That(gateway.SslCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(certificate));
            Assert.That(gateway.SslCertificates[0].PublicCertData.ToObjectFromJson<string>(), Is.EqualTo(certificate));

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(gateway, options, AzureResourceManagerNetworkContext.Default));
            AssertGatewayCertificateData(document.RootElement, certificate);
            var properties = document.RootElement.GetProperty("properties");
            var trustedClient = properties.GetProperty("trustedClientCertificates")[0].GetProperty("properties");
            var ssl = properties.GetProperty("sslCertificates")[0].GetProperty("properties");
            if (format == "J")
            {
                Assert.That(trustedClient.GetProperty("validatedCertData").GetString(), Is.EqualTo(certificate));
                Assert.That(ssl.GetProperty("publicCertData").GetString(), Is.EqualTo(certificate));
                Assert.That(trustedClient.GetProperty("futureProperty").GetProperty("enabled").GetBoolean(), Is.True);
            }
            else
            {
                Assert.That(trustedClient.TryGetProperty("validatedCertData", out _), Is.False);
                Assert.That(ssl.TryGetProperty("publicCertData", out _), Is.False);
                Assert.That(trustedClient.TryGetProperty("futureProperty", out _), Is.False);
            }
        }

        [TestCase("J", Base64Certificate)]
        [TestCase("W", Base64Certificate)]
        [TestCase("J", PemCertificate)]
        [TestCase("W", PemCertificate)]
        [TestCase("J", "")]
        [TestCase("W", "")]
        public void WriteApplicationGatewayCertificatesDoesNotDoubleEncodeJsonStrings(string format, string certificate)
        {
            var gateway = new ApplicationGatewayData();
            gateway.AuthenticationCertificates.Add(new ApplicationGatewayAuthenticationCertificate
            {
                Data = BinaryData.FromObjectAsJson(certificate)
            });
            gateway.TrustedRootCertificates.Add(new ApplicationGatewayTrustedRootCertificate
            {
                Data = BinaryData.FromObjectAsJson(certificate)
            });
            gateway.TrustedClientCertificates.Add(new ApplicationGatewayTrustedClientCertificate
            {
                Data = BinaryData.FromObjectAsJson(certificate)
            });
            gateway.SslCertificates.Add(new ApplicationGatewaySslCertificate
            {
                Data = BinaryData.FromObjectAsJson(certificate),
                Password = "test-password"
            });

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(
                gateway, new ModelReaderWriterOptions(format), AzureResourceManagerNetworkContext.Default));

            AssertGatewayCertificateData(document.RootElement, certificate);
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("sslCertificates")[0]
                .GetProperty("properties").GetProperty("password").GetString(), Is.EqualTo("test-password"));
        }

        [TestCase("J", false)]
        [TestCase("W", false)]
        [TestCase("J", true)]
        [TestCase("W", true)]
        public void OptionalApplicationGatewayCertificateDataHandlesMissingAndNull(string format, bool explicitNull)
        {
            var options = new ModelReaderWriterOptions(format);
            var gateway = ModelReaderWriter.Read<ApplicationGatewayData>(
                CreateGatewayJson(explicitNull ? "null" : null), options, AzureResourceManagerNetworkContext.Default);

            Assert.That(gateway.AuthenticationCertificates[0].Data, Is.Null);
            Assert.That(gateway.TrustedRootCertificates[0].Data, Is.Null);
            Assert.That(gateway.TrustedClientCertificates[0].Data, Is.Null);
            Assert.That(gateway.TrustedClientCertificates[0].ValidatedCertData, Is.Null);
            Assert.That(gateway.SslCertificates[0].Data, Is.Null);
            Assert.That(gateway.SslCertificates[0].PublicCertData, Is.Null);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(gateway, options, AzureResourceManagerNetworkContext.Default));
            foreach (string collection in new[] { "authenticationCertificates", "trustedRootCertificates", "trustedClientCertificates", "sslCertificates" })
            {
                var properties = document.RootElement.GetProperty("properties").GetProperty(collection)[0].GetProperty("properties");
                Assert.That(properties.TryGetProperty("data", out _), Is.False);
                Assert.That(properties.TryGetProperty("validatedCertData", out _), Is.False);
                Assert.That(properties.TryGetProperty("publicCertData", out _), Is.False);
            }
        }

        [TestCase("J", Base64Certificate)]
        [TestCase("W", Base64Certificate)]
        [TestCase("J", PemCertificate)]
        [TestCase("W", PemCertificate)]
        [TestCase("J", "")]
        [TestCase("W", "")]
        public void VpnClientRootCertificatePreservesJsonStrings(string format, string certificate)
        {
            var options = new ModelReaderWriterOptions(format);
            var json = BinaryData.FromString("{\"properties\":{\"publicCertData\":" + JsonSerializer.Serialize(certificate) + "}}");
            var model = ModelReaderWriter.Read<VpnClientRootCertificate>(json, options, AzureResourceManagerNetworkContext.Default);
            Assert.That(model.PublicCertData.ToObjectFromJson<string>(), Is.EqualTo(certificate));

            foreach (var value in new[] { model, new VpnClientRootCertificate(BinaryData.FromObjectAsJson(certificate)) })
            {
                using var document = JsonDocument.Parse(ModelReaderWriter.Write(value, options, AzureResourceManagerNetworkContext.Default));
                Assert.That(document.RootElement.GetProperty("properties").GetProperty("publicCertData").GetString(), Is.EqualTo(certificate));
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void VpnClientRootCertificatePreservesExplicitJsonNull(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<VpnClientRootCertificate>(
                BinaryData.FromString("{\"properties\":{\"publicCertData\":null}}"), options, AzureResourceManagerNetworkContext.Default);

            Assert.That(model.PublicCertData.ToString(), Is.EqualTo("null"));

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("publicCertData").ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void VpnClientRootCertificateWritesMissingDataAsJsonNull(string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var model = ModelReaderWriter.Read<VpnClientRootCertificate>(
                BinaryData.FromString("{\"properties\":{}}"), options, AzureResourceManagerNetworkContext.Default);

            Assert.That(model.PublicCertData, Is.Null);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(model, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("publicCertData").ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        [TestCase("J", false)]
        [TestCase("W", false)]
        [TestCase("J", true)]
        [TestCase("W", true)]
        public void VpnClientRootCertificateWritesCallerNullAsJsonNull(string format, bool setNullAfterConstruction)
        {
            var model = new VpnClientRootCertificate(setNullAfterConstruction ? BinaryData.FromObjectAsJson(Base64Certificate) : null);
            if (setNullAfterConstruction)
            {
                model.PublicCertData = null;
            }

            Assert.That(model.PublicCertData, Is.Null);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(
                model, new ModelReaderWriterOptions(format), AzureResourceManagerNetworkContext.Default));
            Assert.That(document.RootElement.GetProperty("properties").GetProperty("publicCertData").ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        [TestCase("J", "data")]
        [TestCase("W", "data")]
        [TestCase("J", "validatedCertData")]
        [TestCase("W", "validatedCertData")]
        public void ReadTrustedClientCertificateWithOnlyOnePemField(string format, string propertyName)
        {
            var model = ModelReaderWriter.Read<ApplicationGatewayTrustedClientCertificate>(
                BinaryData.FromString("{\"properties\":{\"" + propertyName + "\":" + JsonSerializer.Serialize(PemCertificate) + "}}"),
                new ModelReaderWriterOptions(format), AzureResourceManagerNetworkContext.Default);

            var data = propertyName == "data" ? model.Data : model.ValidatedCertData;
            Assert.That(data.ToObjectFromJson<string>(), Is.EqualTo(PemCertificate));
        }

        [TestCase(nameof(ArmNetworkModelFactory.ApplicationGatewayAuthenticationCertificate))]
        [TestCase(nameof(ArmNetworkModelFactory.ApplicationGatewayTrustedRootCertificate))]
        [TestCase(nameof(ArmNetworkModelFactory.ApplicationGatewayTrustedClientCertificate))]
        [TestCase(nameof(ArmNetworkModelFactory.ApplicationGatewaySslCertificate))]
        [TestCase(nameof(ArmNetworkModelFactory.VpnClientRootCertificate))]
        public void CertificateModelFactoryRemainsBrowsable(string factoryName)
        {
            var method = Array.Find(typeof(ArmNetworkModelFactory).GetMethods(),
                candidate => candidate.Name == factoryName && Array.Exists(candidate.GetParameters(), parameter => parameter.Name == "type"));

            Assert.That(method, Is.Not.Null);
            Assert.That(method.GetCustomAttribute<EditorBrowsableAttribute>()?.State, Is.Not.EqualTo(EditorBrowsableState.Never));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CertificateModelFactoriesPreserveCallerData(string format)
        {
            var data = BinaryData.FromObjectAsJson(Base64Certificate);
            var responseData = BinaryData.FromObjectAsJson(PemCertificate);
            var gateway = new ApplicationGatewayData();
            gateway.AuthenticationCertificates.Add(ArmNetworkModelFactory.ApplicationGatewayAuthenticationCertificate(@type: default, data: data));
            gateway.TrustedRootCertificates.Add(ArmNetworkModelFactory.ApplicationGatewayTrustedRootCertificate(@type: default, data: data));
            gateway.TrustedClientCertificates.Add(ArmNetworkModelFactory.ApplicationGatewayTrustedClientCertificate(
                @type: default, data: data, validatedCertData: responseData));
            gateway.SslCertificates.Add(ArmNetworkModelFactory.ApplicationGatewaySslCertificate(
                @type: default, data: data, publicCertData: responseData));
            var options = new ModelReaderWriterOptions(format);

            using var document = JsonDocument.Parse(ModelReaderWriter.Write(gateway, options, AzureResourceManagerNetworkContext.Default));
            AssertGatewayCertificateData(document.RootElement, Base64Certificate);
            if (format == "J")
            {
                var properties = document.RootElement.GetProperty("properties");
                Assert.That(properties.GetProperty("trustedClientCertificates")[0].GetProperty("properties")
                    .GetProperty("validatedCertData").GetString(), Is.EqualTo(PemCertificate));
                Assert.That(properties.GetProperty("sslCertificates")[0].GetProperty("properties")
                    .GetProperty("publicCertData").GetString(), Is.EqualTo(PemCertificate));
            }

            var vpn = ArmNetworkModelFactory.VpnClientRootCertificate(@type: default, publicCertData: data);
            using var vpnDocument = JsonDocument.Parse(ModelReaderWriter.Write(vpn, options, AzureResourceManagerNetworkContext.Default));
            Assert.That(vpnDocument.RootElement.GetProperty("properties").GetProperty("publicCertData").GetString(), Is.EqualTo(Base64Certificate));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task GetApplicationGatewayWithPemCertificate(bool async)
        {
            var id = ApplicationGatewayResource.CreateResourceIdentifier(SubscriptionId, "test-rg", "test-gateway");
            var transport = new MockTransport(new MockResponse(200).SetContent(CreateGatewayJson(JsonSerializer.Serialize(PemCertificate)).ToString()));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetApplicationGatewayResource(id);

            var response = async ? await resource.GetAsync() : resource.Get();

            Assert.That(response.Value.Data.TrustedClientCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(PemCertificate));
            Assert.That(response.Value.Data.TrustedClientCertificates[0].ValidatedCertData.ToObjectFromJson<string>(), Is.EqualTo(PemCertificate));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ListApplicationGatewaysWithPemCertificateOnNextPage(bool async)
        {
            string nextLink = "https://management.azure.com/subscriptions/" + SubscriptionId
                + "/resourceGroups/test-rg/providers/Microsoft.Network/applicationGateways?next=1";
            string firstPage = "{\"value\":[" + CreateGatewayJson(null) + "],\"nextLink\":" + JsonSerializer.Serialize(nextLink) + "}";
            string secondPage = "{\"value\":[" + CreateGatewayJson(JsonSerializer.Serialize(PemCertificate)) + "]}";
            var transport = new MockTransport(
                new MockResponse(200).SetContent(firstPage),
                new MockResponse(200).SetContent(secondPage));
            var client = new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });
            var collection = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "test-rg"))
                .GetApplicationGateways();
            var gateways = new List<ApplicationGatewayResource>();

            if (async)
            {
                await foreach (var gateway in collection.GetAllAsync())
                {
                    gateways.Add(gateway);
                }
            }
            else
            {
                gateways.AddRange(collection.GetAll());
            }

            Assert.That(gateways, Has.Count.EqualTo(2));
            Assert.That(gateways[0].Data.TrustedClientCertificates[0].Data, Is.Null);
            Assert.That(gateways[1].Data.TrustedClientCertificates[0].Data.ToObjectFromJson<string>(), Is.EqualTo(PemCertificate));
            Assert.That(gateways[1].Data.TrustedClientCertificates[0].ValidatedCertData.ToObjectFromJson<string>(), Is.EqualTo(PemCertificate));
        }

        private static void AssertGatewayCertificateData(JsonElement gateway, string certificate)
        {
            foreach (string collection in new[] { "authenticationCertificates", "trustedRootCertificates", "trustedClientCertificates", "sslCertificates" })
            {
                Assert.That(gateway.GetProperty("properties").GetProperty(collection)[0].GetProperty("properties").GetProperty("data").GetString(),
                    Is.EqualTo(certificate), collection);
            }
        }

        private static BinaryData CreateGatewayJson(string certificateJson)
        {
            string json = """
                {
                  "id": "/subscriptions/SUBSCRIPTION_ID/resourceGroups/test-rg/providers/Microsoft.Network/applicationGateways/test-gateway",
                  "name": "test-gateway",
                  "type": "Microsoft.Network/applicationGateways",
                  "location": "eastus",
                  "properties": {
                    "authenticationCertificates": [
                      {"name": "auth", "properties": {DATA_PROPERTY "provisioningState": "Succeeded"}}
                    ],
                    "trustedRootCertificates": [
                      {"name": "root", "properties": {DATA_PROPERTY "provisioningState": "Succeeded"}}
                    ],
                    "trustedClientCertificates": [
                      {"name": "client", "properties": {DATA_PROPERTY VALIDATED_PROPERTY "futureProperty": {"enabled": true}, "provisioningState": "Succeeded"}}
                    ],
                    "sslCertificates": [
                      {"name": "ssl", "properties": {DATA_PROPERTY PUBLIC_PROPERTY "password": "test-password", "provisioningState": "Succeeded"}}
                    ]
                  }
                }
                """;
            return BinaryData.FromString(json.Replace("SUBSCRIPTION_ID", SubscriptionId)
                .Replace("DATA_PROPERTY", certificateJson == null ? string.Empty : "\"data\":" + certificateJson + ",")
                .Replace("VALIDATED_PROPERTY", certificateJson == null ? string.Empty : "\"validatedCertData\":" + certificateJson + ",")
                .Replace("PUBLIC_PROPERTY", certificateJson == null ? string.Empty : "\"publicCertData\":" + certificateJson + ","));
        }
    }
}
