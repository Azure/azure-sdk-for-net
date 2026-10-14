// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards that the generated <c>IJsonModel</c> path and the System.Text.Json converter emit the same Base64Url wire form.
    /// </summary>
    public class StoredAttestationPolicySerializationTests
    {
        private const string Policy = "version=1.0; authorizationrules{=> permit();}; issuancerules{ c:[type==\"é\"] => issue(claim=c); };";

        [Test]
        public void ModelReaderWriterMatchesConverter()
        {
            var p = new StoredAttestationPolicy { AttestationPolicy = Policy };
            string viaStj = BinaryData.FromObjectAsJson(p).ToString();
            string viaMrw = ModelReaderWriter.Write(p).ToString();

            Assert.AreEqual(viaStj, viaMrw, "ModelReaderWriter must emit the same Base64Url wire form as the converter");
            StringAssert.DoesNotContain("version=1.0", viaMrw, "policy text must not be written unencoded");
        }

        [Test]
        public void CrossReadRoundTrips()
        {
            var p = new StoredAttestationPolicy { AttestationPolicy = Policy };
            BinaryData viaStj = BinaryData.FromObjectAsJson(p);
            BinaryData viaMrw = ModelReaderWriter.Write(p);

            Assert.AreEqual(Policy, ModelReaderWriter.Read<StoredAttestationPolicy>(viaStj).AttestationPolicy);
            Assert.AreEqual(Policy, viaMrw.ToObjectFromJson<StoredAttestationPolicy>().AttestationPolicy);
            Assert.AreEqual(Policy, ModelReaderWriter.Read<StoredAttestationPolicy>(viaMrw).AttestationPolicy);
        }

        [Test]
        public void TokenBodyRoundTrips()
        {
            var token = new AttestationToken(BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = Policy }));
            Assert.AreEqual(Policy, token.GetBody<StoredAttestationPolicy>().AttestationPolicy);
        }

        [Test]
        public void NullPolicyDoesNotThrowOnModelReaderWriter()
        {
            var p = new StoredAttestationPolicy();
            BinaryData written = ModelReaderWriter.Write(p);
            Assert.IsNull(ModelReaderWriter.Read<StoredAttestationPolicy>(written).AttestationPolicy);
        }
    }
}
