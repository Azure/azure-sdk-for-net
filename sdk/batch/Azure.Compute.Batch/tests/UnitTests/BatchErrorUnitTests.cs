// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure;
using Azure.Compute.Batch;
using Moq;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchErrorUnitTests
    {
        [Test]
        public void ExtractBatchErrorFromExeception_Standard_BatchError()
        {
            // Arrange
            var mockResponse = new Mock<Response>();
            var batchErrorJson = "{\"code\":\"ErrorCode\",\"message\":{\"value\":\"Error message\"},\"values\":[]}";
            var binaryData = new BinaryData(batchErrorJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            var requestFailedException = new RequestFailedException(mockResponse.Object);

            // Act
            var result = BatchError.ExtractBatchErrorFromException(requestFailedException);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("ErrorCode", result.Code);
            Assert.AreEqual("Error message", result.Message.Value);
        }

        [Test]
        public void ExtractBatchErrorFromExeception_Complex_BatchError()
        {
            // Arrange
            var mockResponse = new Mock<Response>();

            var batchErrorJson = "{\"code\":\"ErrorCode\",\"message\":{\"value\":\"Error message\"},\"values\":[{\"key\": \"key1\",\"value\":\"value1\"},{\"key\": \"key2\",\"value\":\"value2\"}]}";
            var binaryData = new BinaryData(batchErrorJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            var requestFailedException = new RequestFailedException(mockResponse.Object);

            // Act
            var result = BatchError.ExtractBatchErrorFromException(requestFailedException);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("ErrorCode", result.Code);
            Assert.AreEqual("Error message", result.Message.Value);
            Assert.AreEqual(2, result.Values.Count);
            Assert.AreEqual("key1", result.Values[0].Key);
            Assert.AreEqual("value1", result.Values[0].Value);
            Assert.AreEqual("key2", result.Values[1].Key);
            Assert.AreEqual("value2", result.Values[1].Value);
        }

        [Test]
        public void ExtractBatchErrorFromExeception_Empty_Error()
        {
            // Arrange
            var mockResponse = new Mock<Response>();
            var batchErrorJson = "{}";
            var binaryData = new BinaryData(batchErrorJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            var requestFailedException = new RequestFailedException(mockResponse.Object);

            // Act
            var result = BatchError.ExtractBatchErrorFromException(requestFailedException);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Code);
            Assert.Null(result.Message);
            Assert.AreEqual(0, result.Values.Count);
        }
    }
}
