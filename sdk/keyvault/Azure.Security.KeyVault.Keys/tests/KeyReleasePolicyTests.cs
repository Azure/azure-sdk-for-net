// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyReleasePolicyTests
    {
        [Test]
        public void KeyReleasePolicyValidation()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new KeyReleasePolicy(null));
            Assert.AreEqual("encodedPolicy", ex.ParamName);
        }

        [Test]
        public void Deserializes()
        {
            KeyReleasePolicy policy = new();
            using (JsonStream json = new(@"{""contentType"":""application/json"",""data"":""dGVzdA""}"))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.AreEqual("application/json", policy.ContentType);
            Assert.AreEqual("test", policy.EncodedPolicy.ToString());
        }

        [Test]
        public void Serializes()
        {
            KeyReleasePolicy policy = new(BinaryData.FromString("test"))
            {
                ContentType = "application/json",
            };

            using JsonStream json = new();
            json.WriteObject(policy);

            Assert.AreEqual(@"{""contentType"":""application/json"",""data"":""dGVzdA""}", json.ToString());
        }

        [Test]
        public void DeserializesImmutable([Values] bool immutable)
        {
            KeyReleasePolicy policy = new();
            using (JsonStream json = new(@$"{{""contentType"":""application/json"",""data"":""dGVzdA"",""immutable"":{(immutable ? "true" : "false")}}}"))
            {
                policy.Deserialize(json.AsStream());
            }

            Assert.AreEqual("application/json", policy.ContentType);
            Assert.AreEqual("test", policy.EncodedPolicy.ToString());
            Assert.AreEqual(immutable, policy.Immutable);
        }

        [Test]
        public void SerializesImmutable([Values] bool immutable)
        {
            KeyReleasePolicy policy = new(BinaryData.FromString("test"))
            {
                ContentType = "application/json",
                Immutable = immutable,
            };

            using JsonStream json = new();
            json.WriteObject(policy);

            Assert.AreEqual(@$"{{""contentType"":""application/json"",""data"":""dGVzdA"",""immutable"":{(immutable ? "true" : "false")}}}", json.ToString());
        }

        [Test]
        public void SampleToStream()
        {
            using MemoryStream ms = new();

#if SNIPPET
            KeyVaultKey key = null;
#endif

            #region Snippet:KeyReleasePolicy_ToStream
#if SNIPPET
            KeyReleasePolicy policy = key.Properties.ReleasePolicy;
#else
            KeyReleasePolicy policy = new KeyReleasePolicy(BinaryData.FromString("test"));
#endif
            using (Stream stream = policy.EncodedPolicy.ToStream())
            {
#if SNIPPET
                using FileStream file = File.OpenWrite("policy.dat");
#else
                using Stream file = ms;
#endif
                stream.CopyTo(file);
            }
#endregion

            Assert.AreEqual("test", Encoding.UTF8.GetString(ms.ToArray()));
        }

        [Test]
        public void SampleFromStream()
        {
#region Snippet:KeyReleasePolicy_FromStream
#if SNIPPET
            using FileStream file = File.OpenRead("policy.dat");
#else
            using Stream file = new MemoryStream(Encoding.UTF8.GetBytes("test"));
#endif
            KeyReleasePolicy policy = new KeyReleasePolicy(BinaryData.FromStream(file));
#endregion

            using JsonStream json = new();
            json.WriteObject(policy);

            Assert.AreEqual(@"{""data"":""dGVzdA""}", json.ToString());
        }
    }
}
