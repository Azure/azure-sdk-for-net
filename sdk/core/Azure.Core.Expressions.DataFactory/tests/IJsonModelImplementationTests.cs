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
            Assert.That(keyVaultSecret, Is.InstanceOf<IJsonModel<DataFactoryKeyVaultSecret>>());
            Assert.That(keyVaultSecret, Is.InstanceOf<IPersistableModel<DataFactoryKeyVaultSecret>>());

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactoryKeyVaultSecret>)keyVaultSecret).Write(options);
            Assert.That(binaryData, Is.Not.Null);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactoryKeyVaultSecret>(binaryData, options);
            Assert.That(deserializedSecret, Is.Not.Null);
            Assert.That(deserializedSecret.Store.ReferenceName, Is.EqualTo(keyVaultSecret.Store.ReferenceName));
        }

        [Test]
        public void DataFactoryLinkedServiceReference_ImplementsIJsonModel()
        {
            // Arrange
            var linkedServiceRef = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, "testLinkedService");

            // Act & Assert - Test IJsonModel interface
            Assert.That(linkedServiceRef, Is.InstanceOf<IJsonModel<DataFactoryLinkedServiceReference>>());
            Assert.That(linkedServiceRef, Is.InstanceOf<IPersistableModel<DataFactoryLinkedServiceReference>>());

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactoryLinkedServiceReference>)linkedServiceRef).Write(options);
            Assert.That(binaryData, Is.Not.Null);

            // Test deserialization
            var deserializedRef = ModelReaderWriter.Read<DataFactoryLinkedServiceReference>(binaryData, options);
            Assert.That(deserializedRef, Is.Not.Null);
            Assert.That(deserializedRef.ReferenceName, Is.EqualTo(linkedServiceRef.ReferenceName));
            Assert.That(deserializedRef.ReferenceKind, Is.EqualTo(linkedServiceRef.ReferenceKind));
        }

        [Test]
        public void DataFactorySecretString_ImplementsIJsonModel()
        {
            // Arrange
            var secretString = new DataFactorySecretString("testSecret");

            // Act & Assert - Test IJsonModel interface
            Assert.That(secretString, Is.InstanceOf<IJsonModel<DataFactorySecretString>>());
            Assert.That(secretString, Is.InstanceOf<IPersistableModel<DataFactorySecretString>>());

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactorySecretString>)secretString).Write(options);
            Assert.That(binaryData, Is.Not.Null);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactorySecretString>(binaryData, options);
            Assert.That(deserializedSecret, Is.Not.Null);
            Assert.That(deserializedSecret.Value, Is.EqualTo(secretString.Value));
        }

        [Test]
        public void DataFactorySecret_ImplementsIJsonModel()
        {
            // Arrange
            DataFactorySecret secret = new DataFactorySecretString("testSecret");

            // Act & Assert - Test IJsonModel interface
            Assert.That(secret, Is.InstanceOf<IJsonModel<DataFactorySecret>>());
            Assert.That(secret, Is.InstanceOf<IPersistableModel<DataFactorySecret>>());

            // Test serialization
            var options = new ModelReaderWriterOptions("W");
            var binaryData = ((IPersistableModel<DataFactorySecret>)secret).Write(options);
            Assert.That(binaryData, Is.Not.Null);

            // Test deserialization
            var deserializedSecret = ModelReaderWriter.Read<DataFactorySecret>(binaryData, options);
            Assert.That(deserializedSecret, Is.Not.Null);
            Assert.That(deserializedSecret, Is.InstanceOf<DataFactorySecretString>());
            Assert.That(((DataFactorySecretString)deserializedSecret).Value, Is.EqualTo(((DataFactorySecretString)secret).Value));
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

            Assert.That(root.TryGetProperty("value", out var valueProperty), Is.True);
            Assert.That(valueProperty.GetString(), Is.EqualTo("testSecret"));
            Assert.That(root.TryGetProperty("type", out var typeProperty), Is.True);
            Assert.That(typeProperty.GetString(), Is.EqualTo("SecureString"));
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
            Assert.That(secretString, Is.Not.Null);
            Assert.That(secretString.Value, Is.EqualTo("testSecret"));
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
            Assert.That(format, Is.EqualTo("J"));
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
