// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobAccessPointAuthenticationSerializationTests
    {
        [TestCase("NetAppOntap")]
        [TestCase("AzureNetAppFiles")]
        [TestCase("DellOneFs")]
        [TestCase("Qumulo")]
        [TestCase("Commvault")]
        [TestCase("Nasuni")]
        [TestCase("S3Compatible")]
        public void SourceAuthenticationPreservesWireNames(string sourceType)
        {
            BinaryData json = CreateSourceJson(sourceType);
            var source = ModelReaderWriter.Read<BlobAccessPointSourceProperties>(json, ModelReaderWriterOptions.Json);
            PropertyInfo property = source.GetType().GetProperty("Authentication");

            Assert.IsNotNull(property);
            var authentication = (BlobAccessPointAccessKeyAuthenticationProperties)property.GetValue(source);
            Assert.AreEqual("access-key", authentication.AccessKeyId);
            Assert.AreEqual("us-east-1", authentication.SigningRegion);
            AssertWireNames(ModelReaderWriter.Write(source, ModelReaderWriterOptions.Json), sourceType);
        }

        [TestCase("NetAppOntap")]
        [TestCase("AzureNetAppFiles")]
        [TestCase("DellOneFs")]
        [TestCase("Qumulo")]
        [TestCase("Commvault")]
        [TestCase("Nasuni")]
        [TestCase("S3Compatible")]
        public void PatchAuthenticationPreservesWireNames(string sourceType)
        {
            BinaryData json = CreateSourceJson(sourceType);
            var source = ModelReaderWriter.Read<BlobAccessPointSourcePropertiesPatch>(json, ModelReaderWriterOptions.Json);
            PropertyInfo property = source.GetType().GetProperty("Authentication");

            Assert.IsNotNull(property);
            var authentication = (BlobAccessPointAccessKeyAuthenticationPropertiesPatch)property.GetValue(source);
            Assert.AreEqual("access-key", authentication.AccessKeyId);
            Assert.AreEqual("us-east-1", authentication.SigningRegion);
            AssertWireNames(ModelReaderWriter.Write(source, ModelReaderWriterOptions.Json), sourceType);
        }

        [Test]
        public void NewFamilyUsesUnabbreviatedAuthenticationNames()
        {
            Type[] types = typeof(BlobAccessPointRemoteAuthenticationProperties).Assembly.GetExportedTypes()
                .Where(type => type.Name.StartsWith("BlobAccessPoint", StringComparison.Ordinal)).ToArray();

            foreach (Type type in types)
            {
                Assert.IsFalse(Regex.IsMatch(type.Name, "Auth(?!entication|orization)"), type.FullName);
                foreach (PropertyInfo property in type.GetProperties())
                {
                    Assert.AreNotEqual("Auth", property.Name, type.FullName);
                    Assert.AreNotEqual("AuthType", property.Name, type.FullName);
                }

                foreach (ParameterInfo parameter in type.GetConstructors().SelectMany(constructor => constructor.GetParameters()))
                {
                    Assert.AreNotEqual("auth", parameter.Name, type.FullName);
                    Assert.AreNotEqual("authType", parameter.Name, type.FullName);
                }
            }

            foreach (MethodInfo method in typeof(ArmStorageModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name.StartsWith("BlobAccessPoint", StringComparison.Ordinal)))
            {
                Assert.IsFalse(Regex.IsMatch(method.Name, "Auth(?!entication|orization)"), method.Name);
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    Assert.AreNotEqual("auth", parameter.Name, method.Name);
                    Assert.AreNotEqual("authType", parameter.Name, method.Name);
                }
            }
        }

        private static BinaryData CreateSourceJson(string sourceType)
        {
            return BinaryData.FromString(JsonSerializer.Serialize(new
            {
                sourceType,
                connection = new { connectionType = "Endpoint", endpoint = "https://example.com" },
                auth = new
                {
                    authType = "AccessKey",
                    accessKeyId = "access-key",
                    secretAccessKey = "test-secret",
                    signingRegion = "us-east-1"
                }
            }));
        }

        private static void AssertWireNames(BinaryData json, string sourceType)
        {
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;
            Assert.AreEqual(sourceType, root.GetProperty("sourceType").GetString());
            Assert.IsFalse(root.TryGetProperty("authentication", out _));
            JsonElement authentication = root.GetProperty("auth");
            Assert.AreEqual("AccessKey", authentication.GetProperty("authType").GetString());
            Assert.AreEqual("access-key", authentication.GetProperty("accessKeyId").GetString());
            Assert.IsFalse(authentication.TryGetProperty("authenticationType", out _));
        }
    }
}
