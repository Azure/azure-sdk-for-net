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
            Assert.Null(JsonSerializer.Deserialize<ResponseError>("null"));
        }

        [Test]
        public void CanReadNullWithMRW()
        {
            var json = "null";
            var binaryData = BinaryData.FromString(json);

            // Deserialize using ModelReaderWriter should return a new instance instead of null
            var errorFromModel = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);

            // MRW does not allow null to be returned from read
            Assert.NotNull(errorFromModel);
            Assert.Null(errorFromModel.Code);
            Assert.Null(errorFromModel.Message);
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

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);

            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);

            Assert.Null(error.InnerError.InnerError);
            Assert.AreEqual("BadError: Something wasn't awesome" + Environment.NewLine +
                            "Target: Error target" + Environment.NewLine +
                            Environment.NewLine +
                            "Inner Errors:" + Environment.NewLine +
                            "MoreDetailedBadError" + Environment.NewLine +
                            Environment.NewLine +
                            "Raw:" + Environment.NewLine +
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\"}}",
                error.ToString());
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

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);

            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);

            Assert.AreEqual("InnerMoreDetailedBadError", error.InnerError.InnerError.Code);

            Assert.AreEqual("Code 1", error.Details[0].Code);
            Assert.AreEqual("Message 1", error.Details[0].Message);

            Assert.AreEqual("Code 2", error.Details[1].Code);
            Assert.AreEqual("Message 2", error.Details[1].Message);

            Assert.AreEqual(2, error.Details.Count);

            Assert.Null(error.InnerError.InnerError.InnerError);

            Assert.AreEqual("BadError: Something wasn't awesome" + Environment.NewLine +
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
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"details\": [{\"code\":\"Code 1\",\"message\":\"Message 1\"},{\"code\":\"Code 2\",\"message\":\"Message 2\"},null],\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\",\"innererror\":{\"code\":\"InnerMoreDetailedBadError\",\"message\":\"Inner Inner message\"}}}", error.ToString());
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

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);

            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);

            Assert.AreEqual("InnerMoreDetailedBadError", error.InnerError.InnerError.Code);

            Assert.AreEqual("Code 1", error.Details[0].Code);
            Assert.AreEqual("Message 1", error.Details[0].Message);

            Assert.AreEqual("Code 2", error.Details[1].Code);
            Assert.AreEqual("Message 2", error.Details[1].Message);

            Assert.AreEqual(2, error.Details.Count);

            Assert.Null(error.InnerError.InnerError.InnerError);

            Assert.AreEqual("BadError: Something wasn't awesome" + Environment.NewLine +
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
                            "{\"code\":\"BadError\",\"message\":\"Something wasn't awesome\",\"target\":\"Error target\",\"details\": [{\"code\":\"Code 1\",\"message\":\"Message 1\"},{\"code\":\"Code 2\",\"message\":\"Message 2\"},null],\"innererror\":{\"code\":\"MoreDetailedBadError\",\"message\":\"Inner message\",\"innererror\":{\"code\":\"InnerMoreDetailedBadError\",\"message\":\"Inner Inner message\"}}}", error.ToString());
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

            Assert.AreEqual("", error.Code);
            Assert.Null(error.Message);
            Assert.Null(error.InnerError);
            Assert.AreEqual(0, error.Details.Count);
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

            Assert.IsTrue(ex.Message.Contains("does not support 'X' format"));
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
            Assert.NotNull(binaryData);

            // Verify the serialized content
            string jsonString = binaryData.ToString();
            Assert.IsTrue(jsonString.Contains("\"code\":\"BadError\""));
            Assert.IsTrue(jsonString.Contains("\"message\":\"Something was not awesome\""));

            // Deserialize back to verify round-trip
            var deserializedError = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            Assert.AreEqual(originalError.Code, deserializedError.Code);
            Assert.AreEqual(originalError.Message, deserializedError.Message);
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
            Assert.NotNull(serializedData);

            // Verify key elements are in the serialized JSON
            string jsonString = serializedData.ToString();
            Assert.IsTrue(jsonString.Contains("\"code\":\"BadError\""));
            Assert.IsTrue(jsonString.Contains("\"message\":\"Something was not awesome\""));
            Assert.IsTrue(jsonString.Contains("\"target\":\"Error target\""));
            Assert.IsTrue(jsonString.Contains("\"details\":["));
            Assert.IsTrue(jsonString.Contains("\"code\":\"Code 1\""));
            Assert.IsTrue(jsonString.Contains("\"code\":\"Code 2\""));
            Assert.IsTrue(jsonString.Contains("\"innererror\":"));
            Assert.IsTrue(jsonString.Contains("\"code\":\"MoreDetailedBadError\""));
            Assert.IsTrue(jsonString.Contains("\"code\":\"InnerMoreDetailedBadError\""));

            // Deserialize back to verify round-trip
            var roundTrippedError = ModelReaderWriter.Read<ResponseError>(serializedData, ModelReaderWriterOptions.Json);
            Assert.AreEqual(originalError.Code, roundTrippedError.Code);
            Assert.AreEqual(originalError.Message, roundTrippedError.Message);
            Assert.AreEqual(originalError.Target, roundTrippedError.Target);
            Assert.AreEqual(originalError.Details.Count, roundTrippedError.Details.Count);
            Assert.AreEqual(originalError.Details[0].Code, roundTrippedError.Details[0].Code);
            Assert.AreEqual(originalError.Details[1].Code, roundTrippedError.Details[1].Code);
            Assert.AreEqual(originalError.InnerError?.Code, roundTrippedError.InnerError?.Code);
            Assert.AreEqual(originalError.InnerError?.InnerError?.Code, roundTrippedError.InnerError?.InnerError?.Code);
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

            Assert.IsTrue(ex.Message.Contains("does not support 'X' format"));
        }

        #endregion
    }
}
