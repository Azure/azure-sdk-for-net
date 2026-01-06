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

            // Act
            var result = (BatchError)mockResponse.Object;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo("ErrorCode"));
                Assert.That(result.Message.Value, Is.EqualTo("Error message"));
            });
        }

        [Test]
        public void ExtractBatchErrorFromExeception_Complex_BatchError()
        {
            // Arrange
            var mockResponse = new Mock<Response>();

            var batchErrorJson = "{\"code\":\"ErrorCode\",\"message\":{\"value\":\"Error message\"},\"values\":[{\"key\": \"key1\",\"value\":\"value1\"},{\"key\": \"key2\",\"value\":\"value2\"}]}";
            var binaryData = new BinaryData(batchErrorJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            // Act
            var result = (BatchError)mockResponse.Object;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo("ErrorCode"));
                Assert.That(result.Message.Value, Is.EqualTo("Error message"));
                Assert.That(result.Values, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Values[0].Key, Is.EqualTo("key1"));
                Assert.That(result.Values[0].Value, Is.EqualTo("value1"));
                Assert.That(result.Values[1].Key, Is.EqualTo("key2"));
                Assert.That(result.Values[1].Value, Is.EqualTo("value2"));
            });
        }

        [Test]
        public void ExtractBatchErrorFromExeception_Empty_Error()
        {
            // Arrange
            var mockResponse = new Mock<Response>();
            var batchErrorJson = "{}";
            var binaryData = new BinaryData(batchErrorJson);
            mockResponse.Setup(response => response.Content).Returns(binaryData);

            // Act
            var result = (BatchError)mockResponse.Object;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.Null);
                Assert.That(result.Message, Is.Null);
                Assert.That(result.Values.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestBatchErrorCode()
        {
            // Testing of BatchErrorCode comparison

            // Act
            var result1 = "TooManyRequests" == BatchErrorCode.TooManyRequests;
            var result2 = "toomanyrequests" == BatchErrorCode.TooManyRequests;
            var result3 = "TooManyRequestsExtraText" == BatchErrorCode.TooManyRequests;
            var result4 = BatchErrorCode.TooManyRequests == "TooManyRequests";
            var result5 = "TooManyRequestsExtraText" != BatchErrorCode.TooManyRequests;

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result1, Is.True); // verify normal match
                Assert.That(result2, Is.True); // verify case insenstive
                Assert.That(result3, Is.False); // verify failure
                Assert.That(result4, Is.True); // verify order doesn't matter
                Assert.That(result5, Is.True); // verify not match
            });
        }
    }
}
