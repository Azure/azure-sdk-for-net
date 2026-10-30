// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class CertificateBinaryDataSerializationTests
    {
        private static IEnumerable<TestCaseData> CertificateProperties()
        {
            yield return new TestCaseData(typeof(ApplicationGatewayAuthenticationCertificate), "Data", "data", false);
            yield return new TestCaseData(typeof(ApplicationGatewaySslCertificate), "Data", "data", false);
            yield return new TestCaseData(typeof(ApplicationGatewaySslCertificate), "PublicCertData", "publicCertData", true);
            yield return new TestCaseData(typeof(ApplicationGatewayTrustedClientCertificate), "Data", "data", false);
            yield return new TestCaseData(typeof(ApplicationGatewayTrustedClientCertificate), "ValidatedCertData", "validatedCertData", true);
            yield return new TestCaseData(typeof(ApplicationGatewayTrustedRootCertificate), "Data", "data", false);
            yield return new TestCaseData(typeof(VpnClientRootCertificate), "PublicCertData", "publicCertData", false);
        }

        [TestCaseSource(nameof(CertificateProperties))]
        public void CertificateJsonStringsPreserveReleasedSerialization(Type modelType, string propertyName, string wireName, bool readOnly)
        {
            foreach (string text in new[]
            {
                "-----BEGIN CERTIFICATE-----\nnot-base64\n-----END CERTIFICATE-----",
                Convert.ToBase64String(new byte[] { 0, 1, 2, 127, 255 }),
                "certificate with \"quotes\" and \\slashes"
            })
            {
                BinaryData value = BinaryData.FromObjectAsJson(text);
                foreach (string format in new[] { "J", "W" })
                {
                    var options = new ModelReaderWriterOptions(format);
                    object model = ModelReaderWriter.Read(
                        BinaryData.FromString($$$"""{"properties":{"{{{wireName}}}":{{{value}}} } }"""), modelType, options);
                    var property = modelType.GetProperty(propertyName);
                    Assert.That(((BinaryData)property.GetValue(model)).ToString(), Is.EqualTo(value.ToString()));

                    using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
                    JsonElement properties = json.RootElement.GetProperty("properties");
                    if (readOnly && format == "W")
                    {
                        Assert.That(properties.TryGetProperty(wireName, out _), Is.False);
                    }
                    else
                    {
                        Assert.That(properties.GetProperty(wireName).ValueKind, Is.EqualTo(JsonValueKind.String));
                        Assert.That(properties.GetProperty(wireName).GetString(), Is.EqualTo(text));
                    }

                    if (!readOnly)
                    {
                        // This is the 1.15.0 caller pattern reported in #60969; do not base64-encode the JSON again.
                        property.SetValue(model, value);
                        using JsonDocument request = JsonDocument.Parse(ModelReaderWriter.Write(model, options));
                        Assert.That(request.RootElement.GetProperty("properties").GetProperty(wireName).GetString(), Is.EqualTo(text));
                    }
                }
            }
        }
    }
}
