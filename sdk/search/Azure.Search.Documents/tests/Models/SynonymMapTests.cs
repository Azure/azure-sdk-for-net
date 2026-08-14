// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class SynonymMapTests
    {
        [Test]
        public void StringConstructorTests()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap(null, (string)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (string)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (string)null));
            Assert.AreEqual("synonyms", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap("test", string.Empty));
            Assert.AreEqual("synonyms", ex.ParamName);
        }

        [Test]
        public void TextReaderConstructorTests()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap(null, (TextReader)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new SynonymMap(string.Empty, (TextReader)null));
            Assert.AreEqual("name", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new SynonymMap("test", (TextReader)null));
            Assert.AreEqual("reader", ex.ParamName);
        }

        [Test]
        public void SynonymsFromTextReader()
        {
            using StringReader reader = new StringReader("ms,msft=>Microsoft\naz=>Azure");

            SynonymMap map = new SynonymMap("test", reader);
            Assert.AreEqual("ms,msft=>Microsoft\naz=>Azure", map.Synonyms);
        }

        [Test]
        public void RoundtripSerialization()
        {
            SynonymMap original = new SynonymMap("test-synonyms", "ms,msft=>Microsoft\naz=>Azure");

            // Serialize
            BinaryData data = ModelReaderWriter.Write(original, ModelReaderWriterOptions.Json);

            // Deserialize
            SynonymMap deserialized = ModelReaderWriter.Read<SynonymMap>(data, ModelReaderWriterOptions.Json);

            // Assert
            Assert.IsNotNull(deserialized);
            Assert.AreEqual(original.Name, deserialized.Name);
            Assert.AreEqual(original.Synonyms, deserialized.Synonyms);
            Assert.AreEqual(original.Format, deserialized.Format);
        }

        [Test]
        public void RoundtripSerializationWithEncryptionKey()
        {
            SynonymMap original = new SynonymMap("test-synonyms", "ms,msft=>Microsoft\naz=>Azure")
            {
                EncryptionKey = new SearchResourceEncryptionKey(
                    new Uri("https://test-keyvault.vault.azure.net"),
                    "test-key",
                    "test-version")
            };

            // Serialize
            BinaryData data = ModelReaderWriter.Write(original, ModelReaderWriterOptions.Json);

            // Deserialize
            SynonymMap deserialized = ModelReaderWriter.Read<SynonymMap>(data, ModelReaderWriterOptions.Json);

            // Assert
            Assert.IsNotNull(deserialized);
            Assert.AreEqual(original.Name, deserialized.Name);
            Assert.AreEqual(original.Synonyms, deserialized.Synonyms);
            Assert.IsNotNull(deserialized.EncryptionKey);
            Assert.AreEqual(original.EncryptionKey.KeyName, deserialized.EncryptionKey.KeyName);
            Assert.AreEqual(original.EncryptionKey.KeyVersion, deserialized.EncryptionKey.KeyVersion);
            Assert.AreEqual(original.EncryptionKey.VaultUri, deserialized.EncryptionKey.VaultUri);
        }

        [Test]
        public void DeserializesFromJson()
        {
            const string json = @"{
  ""name"": ""my-synonym-map"",
  ""format"": ""solr"",
  ""synonyms"": [""usa,united states,united states of america=>usa"", ""washington,wa=>wa""],
  ""@odata.etag"": ""0x12345""
}";

            using JsonDocument doc = JsonDocument.Parse(json);
            SynonymMap synonymMap = SynonymMap.DeserializeSynonymMap(doc.RootElement, ModelReaderWriterOptions.Json);

            Assert.AreEqual("my-synonym-map", synonymMap.Name);
            Assert.AreEqual("solr", synonymMap.Format);
            Assert.AreEqual("usa,united states,united states of america=>usa\nwashington,wa=>wa", synonymMap.Synonyms);
            Assert.AreEqual(new ETag("0x12345"), synonymMap.ETag);
        }

        [Test]
        public void DeserializesFromJsonWithEncryptionKey()
        {
            const string json = @"{
  ""name"": ""encrypted-synonym-map"",
  ""format"": ""solr"",
  ""synonyms"": [""test=>example""],
  ""encryptionKey"": {
    ""keyVaultKeyName"": ""my-key"",
    ""keyVaultKeyVersion"": ""v1"",
    ""keyVaultUri"": ""https://my-vault.vault.azure.net""
  },
  ""@odata.etag"": ""0xABCDE""
}";

            using JsonDocument doc = JsonDocument.Parse(json);
            SynonymMap synonymMap = SynonymMap.DeserializeSynonymMap(doc.RootElement, ModelReaderWriterOptions.Json);

            Assert.AreEqual("encrypted-synonym-map", synonymMap.Name);
            Assert.AreEqual("test=>example", synonymMap.Synonyms);
            Assert.IsNotNull(synonymMap.EncryptionKey);
            Assert.AreEqual("my-key", synonymMap.EncryptionKey.KeyName);
            Assert.AreEqual("v1", synonymMap.EncryptionKey.KeyVersion);
            Assert.AreEqual(new Uri("https://my-vault.vault.azure.net"), synonymMap.EncryptionKey.VaultUri);
            Assert.AreEqual(new ETag("0xABCDE"), synonymMap.ETag);
        }

        [Test]
        public void SerializesToJsonWithCorrectStructure()
        {
            SynonymMap synonymMap = new SynonymMap("test-map", "word1,word2=>synonym");

            // Serialize
            BinaryData data = ModelReaderWriter.Write(synonymMap, ModelReaderWriterOptions.Json);
            string jsonString = data.ToString();

            // Parse and verify structure
            using JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement root = doc.RootElement;

            Assert.AreEqual("test-map", root.GetProperty("name").GetString());
            Assert.AreEqual("solr", root.GetProperty("format").GetString());
            Assert.AreEqual(JsonValueKind.String, root.GetProperty("synonyms").ValueKind);

            // Verify synonyms are serialized as an string
            JsonElement synonyms = root.GetProperty("synonyms");
            Assert.AreEqual("word1,word2=>synonym", synonyms.GetString());
        }

        [Test]
        public void SynonymsPropertySplitsAndJoinsCorrectly()
        {
            SynonymMap map = new SynonymMap("test", "line1\nline2\nline3");

            // Verify SynonymsList contains individual lines
            Assert.AreEqual(3, map.SynonymsList.Count);
            Assert.AreEqual("line1", map.SynonymsList[0]);
            Assert.AreEqual("line2", map.SynonymsList[1]);
            Assert.AreEqual("line3", map.SynonymsList[2]);

            // Verify Synonyms property joins them back
            Assert.AreEqual("line1\nline2\nline3", map.Synonyms);
        }

        [TestCase(null, null)]
        [TestCase("*", "*")]
        [TestCase("\"0123abcd\"", "\"0123abcd\"")]
        public void ParsesETag(string value, string expected)
        {
            SynonymMap sut = new SynonymMap(null, null, null, null, value, additionalBinaryDataProperties: null);
            Assert.AreEqual(expected, sut.ETag?.ToString());
        }
    }
}
