// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class JsonModelTests
    {
        #region Test Models

        // Simple test model for validation
        private class SimpleTestModel : JsonModel<SimpleTestModel>
        {
            public string? Name { get; set; }
            public int Value { get; set; }

            protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                if (Name != null)
                {
                    writer.WritePropertyName("name");
                    writer.WriteStringValue(Name);
                }
                writer.WritePropertyName("value");
                writer.WriteNumberValue(Value);
                writer.WriteEndObject();
            }

            protected override SimpleTestModel CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSimpleTestModel(doc.RootElement);
        }

        private static SimpleTestModel DeserializeSimpleTestModel(JsonElement element)
        {
            var model = new SimpleTestModel();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    model.Name = property.Value.GetString();
                }
                else if (property.NameEquals("value"u8))
                {
                    model.Value = property.Value.GetInt32();
                }
            }

            return model;
        }
        }

        // Test model that throws in WriteCore for validation
        private class ThrowingWriteModel : JsonModel<ThrowingWriteModel>
        {
            protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                throw new InvalidOperationException("Test exception in WriteCore");
            }

            protected override ThrowingWriteModel CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                return new ThrowingWriteModel();
            }
        }

        // Test model that throws in CreateCore for validation
        private class ThrowingCreateModel : JsonModel<ThrowingCreateModel>
        {
            protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }

            protected override ThrowingCreateModel CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                throw new InvalidOperationException("Test exception in CreateCore");
            }
        }

        #endregion

        #region Basic Functionality Tests

        [Test]
        public void JsonModel_IJsonModel_Write_CallsWriteCore()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var options = new ModelReaderWriterOptions("J");

            // Act
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            ((IJsonModel<SimpleTestModel>)model).Write(writer, options);
            writer.Flush();

            // Assert
            string json = System.Text.Encoding.UTF8.GetString(stream.ToArray());
            Assert.That(json, Is.EqualTo("{\"name\":\"Test\",\"value\":42}"));
        }

        [Test]
        public void JsonModel_IJsonModel_Create_CallsCreateCore()
        {
            // Arrange
            var json = "{\"name\":\"Test\",\"value\":42}";
            var reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleTestModel();

            // Act
            reader.Read(); // Move to StartObject
            var result = ((IJsonModel<SimpleTestModel>)model).Create(ref reader, options);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("Test"));
            Assert.That(result.Value, Is.EqualTo(42));
        }

        [Test]
        public void JsonModel_IPersistableModel_Write_ReturnsValidBinaryData()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var options = new ModelReaderWriterOptions("J");

            // Act
            var binaryData = ((IPersistableModel<SimpleTestModel>)model).Write(options);

            // Assert
            Assert.That(binaryData, Is.Not.Null);
            string json = binaryData.ToString();
            Assert.That(json, Is.EqualTo("{\"name\":\"Test\",\"value\":42}"));
        }

        [Test]
        public void JsonModel_IPersistableModel_Create_ReturnsValidModel()
        {
            // Arrange
            var json = "{\"name\":\"Test\",\"value\":42}";
            var binaryData = new BinaryData(json);
            var options = new ModelReaderWriterOptions("J");
            var model = new SimpleTestModel();

            // Act
            var result = ((IPersistableModel<SimpleTestModel>)model).Create(binaryData, options);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("Test"));
            Assert.That(result.Value, Is.EqualTo(42));
        }

        [Test]
        public void JsonModel_IPersistableModel_GetFormatFromOptions_ReturnsJ()
        {
            // Arrange
            var model = new SimpleTestModel();
            var options = new ModelReaderWriterOptions("J");

            // Act
            string format = ((IPersistableModel<SimpleTestModel>)model).GetFormatFromOptions(options);

            // Assert
            Assert.That(format, Is.EqualTo("J"));
        }

        #endregion

        #region ModelReaderWriter Integration Tests

        [Test]
        public void JsonModel_WithModelReaderWriter_Write_WorksCorrectly()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Integration", Value = 123 };
            var options = new ModelReaderWriterOptions("J");

            // Act
            var binaryData = ModelReaderWriter.Write(model, options);

            // Assert
            Assert.That(binaryData, Is.Not.Null);
            string json = binaryData.ToString();
            Assert.That(json, Is.EqualTo("{\"name\":\"Integration\",\"value\":123}"));
        }

        [Test]
        public void JsonModel_WithModelReaderWriter_Read_WorksCorrectly()
        {
            // Arrange
            var json = "{\"name\":\"Integration\",\"value\":123}";
            var binaryData = new BinaryData(json);
            var options = new ModelReaderWriterOptions("J");

            // Act
            var result = ModelReaderWriter.Read<SimpleTestModel>(binaryData, options);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("Integration"));
            Assert.That(result.Value, Is.EqualTo(123));
        }

        [Test]
        public void JsonModel_WithModelReaderWriter_RoundTrip_WorksCorrectly()
        {
            // Arrange
            var originalModel = new SimpleTestModel { Name = "RoundTrip", Value = 456 };
            var options = new ModelReaderWriterOptions("J");

            // Act
            var binaryData = ModelReaderWriter.Write(originalModel, options);
            var roundTripModel = ModelReaderWriter.Read<SimpleTestModel>(binaryData, options);

            // Assert
            Assert.That(roundTripModel, Is.Not.Null);
            Assert.That(roundTripModel!.Name, Is.EqualTo(originalModel.Name));
            Assert.That(roundTripModel.Value, Is.EqualTo(originalModel.Value));
        }

        #endregion

        #region Format Validation Tests

        [Test]
        public void JsonModel_UnsupportedFormat_ThrowsFormatException()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };

            // Test various unsupported formats
            var unsupportedFormats = new[] { "X", "XML", "Binary", "Protobuf", "YAML", "", "Z" };

            foreach (var format in unsupportedFormats)
            {
                var options = new ModelReaderWriterOptions(format);

                // Act & Assert - Write should throw
                var writeEx = Assert.Throws<FormatException>(() =>
                    ModelReaderWriter.Write(model, options));
                Assert.That(writeEx?.Message, Does.Contain(format));

                // Act & Assert - Read should throw
                var json = "{\"name\":\"Test\",\"value\":42}";
                var binaryData = new BinaryData(json);
                var readEx = Assert.Throws<FormatException>(() =>
                    ModelReaderWriter.Read<SimpleTestModel>(binaryData, options));
                Assert.That(readEx?.Message, Does.Contain(format));
            }
        }

        [Test]
        public void JsonModel_WireFormat_WorksCorrectly()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var wireOptions = new ModelReaderWriterOptions("W");

            // Act & Assert - Should not throw for Wire format since JsonModel supports both J and W
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(model, wireOptions));

            var json = "{\"name\":\"Test\",\"value\":42}";
            var binaryData = new BinaryData(json);
            Assert.DoesNotThrow(() => ModelReaderWriter.Read<SimpleTestModel>(binaryData, wireOptions));
        }

        [Test]
        public void JsonModel_JsonFormat_WorksCorrectly()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var jsonOptions = new ModelReaderWriterOptions("J");

            // Act & Assert - Should not throw
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(model, jsonOptions));

            var json = "{\"name\":\"Test\",\"value\":42}";
            var binaryData = new BinaryData(json);
            Assert.DoesNotThrow(() => ModelReaderWriter.Read<SimpleTestModel>(binaryData, jsonOptions));
        }

        [Test]
        public void JsonModel_WireAndJsonFormats_BothSupported()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };

            // Test both J and W formats work
            foreach (var format in new[] { "J", "W" })
            {
                var options = new ModelReaderWriterOptions(format);

                // Act & Assert - Should not throw for either format
                Assert.DoesNotThrow(() => ModelReaderWriter.Write(model, options),
                    $"Format '{format}' should be supported");

                var json = "{\"name\":\"Test\",\"value\":42}";
                var binaryData = new BinaryData(json);
                Assert.DoesNotThrow(() => ModelReaderWriter.Read<SimpleTestModel>(binaryData, options),
                    $"Format '{format}' should be supported for reading");
            }
        }

        [Test]
        public void JsonModel_IJsonModel_UnsupportedFormat_ThrowsFormatException()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var unsupportedFormats = new[] { "X", "XML", "" };

            foreach (var format in unsupportedFormats)
            {
                var options = new ModelReaderWriterOptions(format);

                // Act & Assert - IJsonModel.Write should throw
                using var stream = new MemoryStream();
                using var writer = new Utf8JsonWriter(stream);
                Assert.Throws<FormatException>(() =>
                    ((IJsonModel<SimpleTestModel>)model).Write(writer, options));

                // Test IJsonModel.Create separately to avoid ref local in lambda issue
                TestCreateWithUnsupportedFormat(model, format);
            }
        }

        private static void TestCreateWithUnsupportedFormat(SimpleTestModel model, string format)
        {
            var options = new ModelReaderWriterOptions(format);
            var json = "{\"name\":\"Test\",\"value\":42}";
            var reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
            reader.Read(); // Move to StartObject

            try
            {
                var result = ((IJsonModel<SimpleTestModel>)model).Create(ref reader, options);
                Assert.Fail($"Expected FormatException for format '{format}', but no exception was thrown");
            }
            catch (FormatException)
            {
                // Expected exception
            }
        }

        [Test]
        public void JsonModel_IPersistableModel_UnsupportedFormat_ThrowsFormatException()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Test", Value = 42 };
            var unsupportedFormats = new[] { "X", "XML", "" };

            foreach (var format in unsupportedFormats)
            {
                var options = new ModelReaderWriterOptions(format);

                // Act & Assert - IPersistableModel.Write should throw
                Assert.Throws<FormatException>(() =>
                    ((IPersistableModel<SimpleTestModel>)model).Write(options));

                // Act & Assert - IPersistableModel.Create should throw
                var json = "{\"name\":\"Test\",\"value\":42}";
                var binaryData = new BinaryData(json);
                Assert.Throws<FormatException>(() =>
                    ((IPersistableModel<SimpleTestModel>)model).Create(binaryData, options));
            }
        }

        #endregion

        #region Exception Handling Tests

        [Test]
        public void JsonModel_WriteCore_ExceptionPropagates()
        {
            // Arrange
            var model = new ThrowingWriteModel();
            var options = new ModelReaderWriterOptions("J");

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                ModelReaderWriter.Write(model, options));
            Assert.That(ex?.Message, Is.EqualTo("Test exception in WriteCore"));
        }

        [Test]
        public void JsonModel_CreateCore_ExceptionPropagates()
        {
            // Arrange
            var json = "{}";
            var binaryData = new BinaryData(json);
            var options = new ModelReaderWriterOptions("J");

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                ModelReaderWriter.Read<ThrowingCreateModel>(binaryData, options));
            Assert.That(ex?.Message, Is.EqualTo("Test exception in CreateCore"));
        }

        #endregion

        #region Edge Cases

        [Test]
        public void JsonModel_EmptyJson_CanBeHandled()
        {
            // Arrange
            var json = "{}";
            var binaryData = new BinaryData(json);
            var options = new ModelReaderWriterOptions("J");

            // Act
            var result = ModelReaderWriter.Read<SimpleTestModel>(binaryData, options);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.Null);
            Assert.That(result.Value, Is.EqualTo(0));
        }

        [Test]
        public void JsonModel_NullValues_CanBeHandled()
        {
            // Arrange
            var model = new SimpleTestModel { Name = null, Value = 0 };
            var options = new ModelReaderWriterOptions("J");

            // Act
            var binaryData = ModelReaderWriter.Write(model, options);
            var result = ModelReaderWriter.Read<SimpleTestModel>(binaryData, options);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.Null);
            Assert.That(result.Value, Is.EqualTo(0));
        }

        [Test]
        public void JsonModel_DefaultOptions_UsesJsonFormat()
        {
            // Arrange
            var model = new SimpleTestModel { Name = "Default", Value = 789 };

            // Act & Assert - Should work with default options (which should be JSON)
            Assert.DoesNotThrow(() => ModelReaderWriter.Write(model));

            var json = "{\"name\":\"Default\",\"value\":789}";
            var binaryData = new BinaryData(json);
            Assert.DoesNotThrow(() => ModelReaderWriter.Read<SimpleTestModel>(binaryData));
        }

        #endregion
    }
}