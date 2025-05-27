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
        [Test]
        public void CanDeserializeNull()
        {
            Assert.Null(JsonSerializer.Deserialize<ResponseError>("null"));
        }

        [Test]
        public void CanDeserializeSimple()
        {
            var error = JsonSerializer.Deserialize<ResponseError>(
                "{" +
                "\"code\":\"BadError\"," +
                "\"message\":\"Something wasn't awesome\"," +
                "\"target\":\"Error target\"," +
                "\"innererror\":" +
                "{" +
                    "\"code\":\"MoreDetailedBadError\"," +
                    "\"message\":\"Inner message\"" +
                "}}");

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
        public void CanDeserializeComplex()
        {
            var error = JsonSerializer.Deserialize<ResponseError>(
                "{" +
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
                    "}"+
                "}}");

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
        public void CanDeserializeWithModelReaderWriter()
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

            var binaryData = BinaryData.FromString(json);
            var error = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);

            Assert.AreEqual("BadError", error.Code);
            Assert.AreEqual("Something wasn't awesome", error.Message);
            Assert.AreEqual("Error target", error.Target);
            Assert.AreEqual("MoreDetailedBadError", error.InnerError.Code);
            Assert.Null(error.InnerError.InnerError);
        }

        [Test]
        public void ModelReaderWriterAndJsonSerializerProduceIdenticalResults()
        {
            var json = "{" +
                       "\"code\":\"BadError\"," +
                       "\"message\":\"Something wasn't awesome\"," +
                       "\"target\":\"Error target\"," +
                       "\"details\": [" +
                       "{\"code\":\"Code 1\",\"message\":\"Message 1\"}," +
                       "{\"code\":\"Code 2\",\"message\":\"Message 2\"}" +
                       "]," +
                       "\"innererror\":" +
                       "{" +
                       "\"code\":\"MoreDetailedBadError\"," +
                       "\"message\":\"Inner message\"" +
                       "}}";

            var binaryData = BinaryData.FromString(json);

            // Deserialize using ModelReaderWriter
            var errorFromModel = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            // Deserialize using System.Text.Json
            var errorFromJson = JsonSerializer.Deserialize<ResponseError>(json);

            // Verify both deserialization methods produce identical results
            Assert.AreEqual(errorFromJson.Code, errorFromModel.Code);
            Assert.AreEqual(errorFromJson.Message, errorFromModel.Message);
            Assert.AreEqual(errorFromJson.Target, errorFromModel.Target);
            Assert.AreEqual(errorFromJson.InnerError.Code, errorFromModel.InnerError.Code);
            Assert.AreEqual(errorFromJson.Details.Count, errorFromModel.Details.Count);

            for (int i = 0; i < errorFromJson.Details.Count; i++)
            {
                Assert.AreEqual(errorFromJson.Details[i].Code, errorFromModel.Details[i].Code);
                Assert.AreEqual(errorFromJson.Details[i].Message, errorFromModel.Details[i].Message);
            }
        }

        [Test]
        public void ModelReaderWriterCanDeserializeNullResponseError()
        {
            var json = "null";
            var binaryData = BinaryData.FromString(json);

            // Deserialize using ModelReaderWriter should return a new instance instead of null
            var errorFromModel = ModelReaderWriter.Read<ResponseError>(binaryData, ModelReaderWriterOptions.Json);
            Assert.NotNull(errorFromModel);
            Assert.Null(errorFromModel.Code);
            Assert.Null(errorFromModel.Message);
        }

        [Test]
        public void ModelReaderWriterHandlesEdgeCases()
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
        public void WriteMethodsThrowNotSupportedException()
        {
            var error = new ResponseError("TestCode", "Test message");

            // Test all write methods throw NotSupportedException
            var ex1 = Assert.Throws<NotSupportedException>(() =>
              ModelReaderWriter.Write(error, ModelReaderWriterOptions.Json));

            Assert.IsTrue(ex1.Message.Contains("does not support writing to JSON"));

            using var stream = new System.IO.MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            var ex2 = Assert.Throws<NotSupportedException>(() =>
                ((IJsonModel<ResponseError>)error).Write(writer, ModelReaderWriterOptions.Json));

            Assert.IsTrue(ex2.Message.Contains("does not support writing to JSON"));
        }

        [Test]
        public void UnsupportedFormatThrowsFormatException()
        {
            var json = "{}";
            var binaryData = BinaryData.FromString(json);

            // Create invalid format options
            var options = new ModelReaderWriterOptions("X"); // Not "J" for JSON

            // Should throw FormatException
            var ex = Assert.Throws<FormatException>(() =>
                ModelReaderWriter.Read<ResponseError>(binaryData, options));

            Assert.IsTrue(ex.Message.Contains("does not support 'X' format"));
        }
    }
}