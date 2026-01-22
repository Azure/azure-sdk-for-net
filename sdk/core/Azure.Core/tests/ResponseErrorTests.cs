// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ResponseErrorTests
    {
        #region Read/Deserialize tests

        [Test]
        public void CanDeserializeNullWithSTJ()
        {
            Assert.That(JsonSerializer.Deserialize<ResponseError>("null"), Is.Null);
        }

        [Test]
        public void CanReadNullWithMRW()
        {
            var json = "null";
            var binaryData = BinaryData.FromString(json);

            // Deserialize using ModelReaderWriter should return a new instance instead of null
            var errorFromModel = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);

            // MRW does not allow null to be returned from read
            Assert.That(errorFromModel, Is.Not.Null);
            Assert.That(errorFromModel.Code, Is.Null);
            Assert.That(errorFromModel.Message, Is.Null);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanDeserializeSimple(bool useMRW)
        {
            var json = "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"" +
                "}}";

            ResponseError error;

            if (useMRW)
            {
                var binaryData = BinaryData.FromString(json);
                error = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            }
            else
            {
                error = JsonSerializer.Deserialize<ResponseError>(json);
            }

            Assert.That(error.Code, Is.EqualTo("BadError"));
            Assert.That(error.Message, Is.EqualTo("Something wasn't awesome"));
            Assert.That(error.Target, Is.EqualTo("Error target"));

            Assert.That(error.InnerError.Code, Is.EqualTo("MoreDetailedBadError"));

            Assert.That(error.InnerError.InnerError, Is.Null);
            Assert.That(error.ToString(),
                Is.EqualTo("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\"}}"));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanDeserializeComplex(bool useMRW)
        {
            var json = "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"details\": [" +
                    "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                    "{\"code\":\"Code 2\",\"message\":\"Message 2\"}," +
                    "null" +
                "]," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"," +
                    "\"innererror\":" +
                    "{" +
                        "\"code\":\"InnerMoreDetailedBadError\"," +
                        "\"message\":\"Inner Inner message\"" +
                    "}" +
                "}}";

            ResponseError error;
            if (useMRW)
            {
                var binaryData = BinaryData.FromString(json);
                error = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            }
            else
            {
                error = JsonSerializer.Deserialize<ResponseError>(json);
            }

            Assert.That(error.Code, Is.EqualTo("BadError"));
            Assert.That(error.Message, Is.EqualTo("Something wasn't awesome"));
            Assert.That(error.Target, Is.EqualTo("Error target"));

            Assert.That(error.InnerError.Code, Is.EqualTo("MoreDetailedBadError"));

            Assert.That(error.InnerError.InnerError.Code, Is.EqualTo("InnerMoreDetailedBadError"));

            Assert.That(error.Details[0].Code, Is.EqualTo("Code 1"));
            Assert.That(error.Details[0].Message, Is.EqualTo("Message 1"));

            Assert.That(error.Details[1].Code, Is.EqualTo("Code 2"));
            Assert.That(error.Details[1].Message, Is.EqualTo("Message 2"));

            Assert.That(error.Details.Count, Is.EqualTo(2));

            Assert.That(error.InnerError.InnerError.InnerError, Is.Null);

            Assert.That(error.ToString(), Is.EqualTo("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            "InnerMoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Details:" + Environment.NewLine +
                            "Code 1: Message 1" + Environment.NewLine +
                            "Code 2: Message 2" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"details\": [{\"code\":\"Code 1\",\"message\":\"Message 1\"},{\"code\":\"Code 2\",\"message\":\"Message 2\"},null],\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\",\"innererror\":{\"code\":\"InnerMoreDetailedBadError\",\"message\":\"Inner Inner message\"}}}"));
        }

        [Test]
        public void CanReadWithAzureCoreContext()
        {
            var json = "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"details\": [" +
                    "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                    "{\"code\":\"Code 2\",\"message\":\"Message 2\"}," +
                    "null" +
                "]," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"," +
                    "\"innererror\":" +
                    "{" +
                        "\"code\":\"InnerMoreDetailedBadError\"," +
                        "\"message\":\"Inner Inner message\"" +
                    "}" +
                "}}";

            var binaryData = BinaryData.FromString(json);

            ResponseError error = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json, AzureCoreContext.Default);

            Assert.That(error.Code, Is.EqualTo("BadError"));
            Assert.That(error.Message, Is.EqualTo("Something wasn't awesome"));
            Assert.That(error.Target, Is.EqualTo("Error target"));

            Assert.That(error.InnerError.Code, Is.EqualTo("MoreDetailedBadError"));

            Assert.That(error.InnerError.InnerError.Code, Is.EqualTo("InnerMoreDetailedBadError"));

            Assert.That(error.Details[0].Code, Is.EqualTo("Code 1"));
            Assert.That(error.Details[0].Message, Is.EqualTo("Message 1"));

            Assert.That(error.Details[1].Code, Is.EqualTo("Code 2"));
            Assert.That(error.Details[1].Message, Is.EqualTo("Message 2"));

            Assert.That(error.Details.Count, Is.EqualTo(2));

            Assert.That(error.InnerError.InnerError.InnerError, Is.Null);

            Assert.That(error.ToString(), Is.EqualTo("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            "InnerMoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Details:" + Environment.NewLine +
                            "Code 1: Message 1" + Environment.NewLine +
                            "Code 2: Message 2" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"details\": [{\"code\":\"Code 1\",\"message\":\"Message 1\"},{\"code\":\"Code 2\",\"message\":\"Message 2\"},null],\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\",\"innererror\":{\"code\":\"InnerMoreDetailedBadError\",\"message\":\"Inner Inner message\"}}}"));
        }

        [Test]
        public void ReadingWithMRW()
        {
            var json = "{" +
                      "\"code\":\"\"," + // Empty string
                      "\"message\":null," + // Null value
                      "\"details\": []," + // Empty array
                      "\"innererror\": null" + // Null object
                      "}";
            var binaryData = BinaryData.FromString(json);
            var error = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);

            Assert.That(error.Code, Is.EqualTo(""));
            Assert.That(error.Message, Is.Null);
            Assert.That(error.InnerError, Is.Null);
            Assert.That(error.Details.Count, Is.EqualTo(0));
        }

        [Test]
        public void UnsupportedFormatThrowsFormatException()
        {
            var json = "{}";
            var binaryData = BinaryData.FromString(json);

            // Create unsupported format options
            var options = ModelReaderWriterOptions.Xml;

            // Should throw FormatException
            var ex = Assert.Throws<FormatException>(() =>
                ModelReaderWriter.Read<ResponseError>(binaryData, options));

            Assert.That(ex.Message.Contains("does not support 'X' format"), Is.True);
        }

        #endregion

        #region Write/Serialize tests

        [Test]
        public void WriteMethodsSerializeSimpleResponseError()
        {
            // Create a simple ResponseError instance
            var originalError = new ResponseError("BadError", "Something was not awesome");

            // Write to JSON using the ModelReaderWriter
            var binaryData = ModelReaderWriter.Write(originalError, ModelReaderWriterOptions.Json);
            Assert.That(binaryData, Is.Not.Null);

            // Verify the serialized content
            string jsonString = binaryData.ToString();
            Assert.That(jsonString.Contains("\"code\":\"BadError\""), Is.True);
            Assert.That(jsonString.Contains("\"message\":\"Something was not awesome\""), Is.True);

            // Deserialize back to verify round-trip
            var deserializedError = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            Assert.That(originalError.Code, Is.EqualTo(deserializedError.Code));
            Assert.That(originalError.Message, Is.EqualTo(deserializedError.Message));
        }

        [Test]
        public void WriteMethodsSerializeComplexResponseError()
        {
            // First create a complex error structure by deserializing known JSON
            var complexJson = "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something was not awesome\"," +
                "\"target\":\"Error target\"," +
                "\"details\": [" +
                    "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                    "{\"code\":\"Code 2\",\"message\":\"Message 2\"}" +
                "]," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"innererror\":" +
                    "{" +
                        "\"code\":\"InnerMoreDetailedBadError\"" +
                    "}" +
                "}}";

            var binaryData = BinaryData.FromString(complexJson);
            var originalError = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);

            // Now test the serialization
            var serializedData = ModelReaderWriter.Write(originalError, ModelReaderWriterOptions.Json);
            Assert.That(serializedData, Is.Not.Null);

            // Verify key elements are in the serialized JSON
            string jsonString = serializedData.ToString();
            Assert.That(jsonString.Contains("\"code\":\"BadError\""), Is.True);
            Assert.That(jsonString.Contains("\"message\":\"Something was not awesome\""), Is.True);
            Assert.That(jsonString.Contains("\"target\":\"Error target\""), Is.True);
            Assert.That(jsonString.Contains("\"details\":["), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"Code 1\""), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"Code 2\""), Is.True);
            Assert.That(jsonString.Contains("\"innererror\":"), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"MoreDetailedBadError\""), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"InnerMoreDetailedBadError\""), Is.True);

            // Deserialize back to verify round-trip
            var roundTrippedError = ModelReaderWriter.Read<ResponseError>(serializedData, ModelReaderWriterOptions.Json);
            Assert.That(originalError.Code, Is.EqualTo(roundTrippedError.Code));
            Assert.That(originalError.Message, Is.EqualTo(roundTrippedError.Message));
            Assert.That(originalError.Target, Is.EqualTo(roundTrippedError.Target));
            Assert.That(originalError.Details.Count, Is.EqualTo(roundTrippedError.Details.Count));
            Assert.That(originalError.Details[0].Code, Is.EqualTo(roundTrippedError.Details[0].Code));
            Assert.That(originalError.Details[1].Code, Is.EqualTo(roundTrippedError.Details[1].Code));
            Assert.That(originalError.InnerError?.Code, Is.EqualTo(roundTrippedError.InnerError?.Code));
            Assert.That(originalError.InnerError?.InnerError?.Code, Is.EqualTo(roundTrippedError.InnerError?.InnerError?.Code));
        }

        [Test]
        public void UnsupportedFormatThrowsFormatExceptionWhenWriting()
        {
            var error = new ResponseError("TestCode", "Test message");

            // Create unsupported format options for writing
            var options = ModelReaderWriterOptions.Xml;

            // Should throw FormatException
            var ex = Assert.Throws<FormatException>(() =>
                ModelReaderWriter.Write(error, options));

            Assert.That(ex.Message.Contains("does not support 'X' format"), Is.True);
        }

        [Test]
        public void JsonSerializerCanSerializeSimpleResponseError()
        {
            // Create a simple ResponseError instance
            var originalError = new ResponseError("BadError", "Something was not awesome");

            // Serialize using JsonSerializer.Serialize
            var jsonString = JsonSerializer.Serialize(originalError);
            Assert.That(jsonString, Is.Not.Null);
            Assert.That(jsonString.Contains("\"code\":\"BadError\""), Is.True);
            Assert.That(jsonString.Contains("\"message\":\"Something was not awesome\""), Is.True);

            // Deserialize back to verify round-trip
            var deserializedError = JsonSerializer.Deserialize<ResponseError>(jsonString);
            Assert.That(originalError.Code, Is.EqualTo(deserializedError.Code));
            Assert.That(originalError.Message, Is.EqualTo(deserializedError.Message));
        }

        [Test]
        public void JsonSerializerCanSerializeComplexResponseError()
        {
            // First create a complex error structure by deserializing known JSON
            var complexJson = "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something was not awesome\"," +
                "\"target\":\"Error target\"," +
                "\"details\": [" +
                    "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                    "{\"code\":\"Code 2\",\"message\":\"Message 2\"}" +
                "]," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"innererror\":" +
                    "{" +
                        "\"code\":\"InnerMoreDetailedBadError\"" +
                    "}" +
                "}}";

            var originalError = JsonSerializer.Deserialize<ResponseError>(complexJson);

            // Serialize using JsonSerializer.Serialize
            var jsonString = JsonSerializer.Serialize(originalError);
            Assert.That(jsonString, Is.Not.Null);

            // Verify key elements are in the serialized JSON
            Assert.That(jsonString.Contains("\"code\":\"BadError\""), Is.True);
            Assert.That(jsonString.Contains("\"message\":\"Something was not awesome\""), Is.True);
            Assert.That(jsonString.Contains("\"target\":\"Error target\""), Is.True);
            Assert.That(jsonString.Contains("\"details\":["), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"Code 1\""), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"Code 2\""), Is.True);
            Assert.That(jsonString.Contains("\"innererror\":"), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"MoreDetailedBadError\""), Is.True);
            Assert.That(jsonString.Contains("\"code\":\"InnerMoreDetailedBadError\""), Is.True);

            // Deserialize back to verify round-trip
            var roundTrippedError = JsonSerializer.Deserialize<ResponseError>(jsonString);
            Assert.That(originalError.Code, Is.EqualTo(roundTrippedError.Code));
            Assert.That(originalError.Message, Is.EqualTo(roundTrippedError.Message));
            Assert.That(originalError.Target, Is.EqualTo(roundTrippedError.Target));
            Assert.That(originalError.Details.Count, Is.EqualTo(roundTrippedError.Details.Count));
            Assert.That(originalError.Details[0].Code, Is.EqualTo(roundTrippedError.Details[0].Code));
            Assert.That(originalError.Details[1].Code, Is.EqualTo(roundTrippedError.Details[1].Code));
            Assert.That(originalError.InnerError?.Code, Is.EqualTo(roundTrippedError.InnerError?.Code));
            Assert.That(originalError.InnerError?.InnerError?.Code, Is.EqualTo(roundTrippedError.InnerError?.InnerError?.Code));
        }

        [Test]
        public void JsonSerializerCanSerializeNullResponseError()
        {
            // Serialize null
            ResponseError nullError = null;
            var jsonString = JsonSerializer.Serialize(nullError);
            Assert.That(jsonString, Is.EqualTo("null"));

            // Deserialize back
            var deserializedError = JsonSerializer.Deserialize<ResponseError>(jsonString);
            Assert.That(deserializedError, Is.Null);
        }

        #endregion
    }
}
