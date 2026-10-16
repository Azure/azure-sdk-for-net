// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
#if NET6_0_OR_GREATER
    /// <summary>
    /// Guards the JSON body produced for policy management certificate add/remove operations.
    /// </summary>
    /// <remarks>
    /// The operations that use this body are <c>LiveOnly</c>, so a serialization regression here is invisible to
    /// playback runs. The body is built with <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions)"/>,
    /// which uses <see cref="System.Text.Json"/> and therefore ignores both the generated
    /// <c>IJsonModel</c> implementation and the model's internal payload property; without an explicit
    /// <c>JsonConverter</c> the body silently serializes to <c>{}</c> and the service receives a signed token
    /// with no certificate in it.
    /// <para>
    /// The behavior under test is framework independent, so the test is restricted to the frameworks that can
    /// build a certificate in process. <c>CertificateRequest</c> and <c>RSA.Create(int)</c> do not exist on
    /// .NET Framework 4.6.2.
    /// </para>
    /// </remarks>
    public class PolicyCertificateModificationSerializationTests
    {
        [Test]
        public void SerializesPolicyCertificateAsJsonWebKey()
        {
            using X509Certificate2 certificate = CreateSelfSignedCertificate();

            string json = SerializeLikeCallSite(certificate, out string expectedX5C);

            using JsonDocument document = JsonDocument.Parse(json);
            Assert.That(
                document.RootElement.TryGetProperty("policyCertificate", out JsonElement policyCertificate),
                Is.True,
                $"Expected a 'policyCertificate' property, but the body serialized as: {json}");

            Assert.That(policyCertificate.GetProperty("kty").GetString(), Is.EqualTo("RSA"));
            Assert.That(policyCertificate.GetProperty("alg").GetString(), Is.EqualTo("RS256"));
            Assert.That(policyCertificate.GetProperty("use").GetString(), Is.EqualTo("sig"));

            string[] x5c = policyCertificate.GetProperty("x5c").EnumerateArray().Select(e => e.GetString()).ToArray();
            Assert.That(x5c, Is.EqualTo(new[] { expectedX5C }));
        }

        private static X509Certificate2 CreateSelfSignedCertificate()
        {
            using RSA rsa = RSA.Create(2048);
            var request = new CertificateRequest(
                "CN=PolicyCertificateModificationSerializationTests",
                rsa,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            return request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));
        }

        /// <summary>
        /// Reproduces the production call site. Reflection is required because the model is internal to the
        /// client library, and the generic type argument must be the model type rather than <see cref="object"/>
        /// so the converter is resolved exactly as it is at runtime.
        /// </summary>
        private static string SerializeLikeCallSite(X509Certificate2 certificate, out string expectedX5C)
        {
            expectedX5C = Convert.ToBase64String(certificate.Export(X509ContentType.Cert));

            Type modelType = typeof(AttestationAdministrationClient).Assembly
                .GetType("Azure.Security.Attestation.PolicyCertificateModification", throwOnError: true);

            ConstructorInfo constructor = modelType.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                binder: null,
                new[] { typeof(X509Certificate2) },
                modifiers: null);

            object model = constructor.Invoke(new object[] { certificate });

            MethodInfo fromObjectAsJson = typeof(BinaryData)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(m => m.Name == nameof(BinaryData.FromObjectAsJson)
                             && m.IsGenericMethodDefinition
                             && m.GetParameters().Length == 2
                             && m.GetParameters()[1].ParameterType == typeof(JsonSerializerOptions));

            var body = (BinaryData)fromObjectAsJson
                .MakeGenericMethod(modelType)
                .Invoke(obj: null, new object[] { model, null });

            return body.ToString();
        }
    }
#endif
}
