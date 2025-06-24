// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class IJsonModelImplementationTests
    {
        [Test]
        public void DataFactoryKeyVaultSecret_ImplementsIJsonModel()
        {
            // Arrange
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, "testLinkedService");
            var secretName = DataFactoryElement<string>.FromLiteral("testSecret");
            var keyVaultSecret = new DataFactoryKeyVaultSecret(store, secretName);

            // Act & Assert - Test IJsonModel interface
            Assert.IsInstanceOf<IJsonModel<DataFactoryKeyVaultSecret>>(keyVaultSecret);
            Assert.IsInstanceOf<IPersistableModel<DataFactoryKeyVaultSecret>>(keyVaultSecret);

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactoryKeyVaultSecret>)keyVaultSecret).Write(options);
            Assert.IsNotNull(binaryData);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactoryKeyVaultSecret>(binaryData, options);
            Assert.IsNotNull(deserializedSecret);
            Assert.AreEqual(keyVaultSecret.Store.ReferenceName, deserializedSecret.Store.ReferenceName);
        }

        [Test]
        public void DataFactoryLinkedServiceReference_ImplementsIJsonModel()
        {
            // Arrange
            var linkedServiceRef = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, "testLinkedService");

            // Act & Assert - Test IJsonModel interface
            Assert.IsInstanceOf<IJsonModel<DataFactoryLinkedServiceReference>>(linkedServiceRef);
            Assert.IsInstanceOf<IPersistableModel<DataFactoryLinkedServiceReference>>(linkedServiceRef);

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactoryLinkedServiceReference>)linkedServiceRef).Write(options);
            Assert.IsNotNull(binaryData);

            // Test deserialization
            var deserializedRef = ModelReaderWriter.Read<DataFactoryLinkedServiceReference>(binaryData, options);
            Assert.IsNotNull(deserializedRef);
            Assert.AreEqual(linkedServiceRef.ReferenceName, deserializedRef.ReferenceName);
            Assert.AreEqual(linkedServiceRef.ReferenceKind, deserializedRef.ReferenceKind);
        }

        [Test]
        public void DataFactorySecretString_ImplementsIJsonModel()
        {
            // Arrange
            var secretString = new DataFactorySecretString("testSecret");

            // Act & Assert - Test IJsonModel interface
            Assert.IsInstanceOf<IJsonModel<DataFactorySecretString>>(secretString);
            Assert.IsInstanceOf<IPersistableModel<DataFactorySecretString>>(secretString);

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactorySecretString>)secretString).Write(options);
            Assert.IsNotNull(binaryData);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactorySecretString>(binaryData, options);
            Assert.IsNotNull(deserializedSecret);
            Assert.AreEqual(secretString.Value, deserializedSecret.Value);
        }

        [Test]
        public void DataFactorySecret_ImplementsIJsonModel()
        {
            // Arrange
            DataFactorySecret secret = new DataFactorySecretString("testSecret");

            // Act & Assert - Test IJsonModel interface
            Assert.IsInstanceOf<IJsonModel<DataFactorySecret>>(secret);
            Assert.IsInstanceOf<IPersistableModel<DataFactorySecret>>(secret);

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactorySecret>)secret).Write(options);
            Assert.IsNotNull(binaryData);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactorySecret>(binaryData, options);
            Assert.IsNotNull(deserializedSecret);
            Assert.IsInstanceOf<DataFactorySecretString>(deserializedSecret);
            Assert.AreEqual(((DataFactorySecretString)secret).Value, ((DataFactorySecretString)deserializedSecret).Value);
        }

        [Test]
        public void IJsonModel_Write_Method_Works()
        {
            // Arrange
            var secretString = new DataFactorySecretString("testSecret");
            var options = new ModelReaderWriterOptions("W");

            // Act
            using var stream = new System.IO.MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            ((IJsonModel<DataFactorySecretString>)secretString).Write(writer, options);
            writer.Flush();

            // Assert
            stream.Position = 0;
            using var document = JsonDocument.Parse(stream);
            var root = document.RootElement;

            Assert.IsTrue(root.TryGetProperty("value", out var valueProperty));
            Assert.AreEqual("testSecret", valueProperty.GetString());
            Assert.IsTrue(root.TryGetProperty("type", out var typeProperty));
            Assert.AreEqual("SecureString", typeProperty.GetString());
        }

        [Test]
        public void IJsonModel_Create_Method_Works()
        {
            // Arrange
            var json = """{"value":"testSecret","type":"SecureString"}""";
            var options = new ModelReaderWriterOptions("W");

            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(jsonBytes);

            // Act
            var secretString = ((IJsonModel<DataFactorySecretString>)new DataFactorySecretString("dummy")).Create(ref reader, options);

            // Assert
            Assert.IsNotNull(secretString);
            Assert.AreEqual("testSecret", secretString.Value);
        }

        [Test]
        public void GetFormatFromOptions_ReturnsJsonFormat()
        {
            // Arrange
            var secretString = new DataFactorySecretString("testSecret");
            var options = new ModelReaderWriterOptions("W");

            // Act
            var format = ((IPersistableModel<DataFactorySecretString>)secretString).GetFormatFromOptions(options);

            // Assert
            Assert.AreEqual("J", format);
        }

        [Test]
        public void IJsonModel_ThrowsFormatException_ForUnsupportedFormat()
        {
            // Arrange
            var secretString = new DataFactorySecretString("testSecret");
            var options = new ModelReaderWriterOptions("X"); // Unsupported format

            // Act & Assert
            Assert.Throws<FormatException>(() =>
                ((IPersistableModel<DataFactorySecretString>)secretString).Write(options));
        }
    }
}