// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="OperationWithId"/> class.
    /// Tests the operation ID extraction from Operation-Location header.
    /// </summary>
    [TestFixture]
    public class OperationWithIdTest
    {
        #region GetOperationId Tests

        [Test]
        public void Id_WithValidOperationLocationHeader_ReturnsOperationId()
        {
            // Arrange
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/abc123-def456");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.AreEqual("abc123-def456", operationWithId.Id);
        }

        [Test]
        public void Id_WithTrailingSlash_ReturnsOperationIdWithoutSlash()
        {
            // Arrange
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/operation-id-123/");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.AreEqual("operation-id-123", operationWithId.Id);
        }

        [Test]
        public void Id_WithDeepPath_ReturnsLastSegment()
        {
            // Arrange
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "https://api.example.com/v1/content/analyzers/my-analyzer/operations/final-operation-id");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.AreEqual("final-operation-id", operationWithId.Id);
        }

        [Test]
        public void Id_WithoutOperationLocationHeader_ThrowsInvalidOperationException()
        {
            // Arrange - No Operation-Location header
            var mockResponse = new MockResponse(202);
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _ = operationWithId.Id);
        }

        [Test]
        public void Id_WithInvalidUri_ThrowsInvalidOperationException()
        {
            // Arrange - Malformed URI that cannot be parsed
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "not-a-valid-uri");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _ = operationWithId.Id);
        }

        [Test]
        public void Id_WithEmptyOperationLocationHeader_ThrowsInvalidOperationException()
        {
            // Arrange - Empty header value
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _ = operationWithId.Id);
        }

        [Test]
        public void Id_WithNullResponse_ThrowsInvalidOperationException()
        {
            // Arrange - MockOperation returns null response
            var mockOperation = new MockOperation(null!, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.Throws<InvalidOperationException>(() => _ = operationWithId.Id);
        }

        #endregion

        #region Property Delegation Tests

        [Test]
        public void Value_DelegatesToInternalOperation()
        {
            // Arrange
            var expectedValue = BinaryData.FromString("{\"result\": \"test\"}");
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/123");
            var mockOperation = new MockOperation(mockResponse, expectedValue, hasValue: true, hasCompleted: true);

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.IsTrue(operationWithId.HasValue);
            Assert.AreEqual(expectedValue.ToString(), operationWithId.Value.ToString());
        }

        [Test]
        public void HasCompleted_DelegatesToInternalOperation()
        {
            // Arrange
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/123");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"), hasCompleted: true);

            // Act
            var operationWithId = new OperationWithId(mockOperation);

            // Assert
            Assert.IsTrue(operationWithId.HasCompleted);
        }

        [Test]
        public void GetRawResponse_DelegatesToInternalOperation()
        {
            // Arrange
            var mockResponse = new MockResponse(202);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/123");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);
            var response = operationWithId.GetRawResponse();

            // Assert
            Assert.AreEqual(mockResponse, response);
        }

        [Test]
        public async Task UpdateStatusAsync_DelegatesToInternalOperation()
        {
            // Arrange
            var mockResponse = new MockResponse(200);
            mockResponse.AddHeader("Operation-Location", "https://example.com/operations/123");
            var mockOperation = new MockOperation(mockResponse, BinaryData.FromString("{}"));

            // Act
            var operationWithId = new OperationWithId(mockOperation);
            var response = await operationWithId.UpdateStatusAsync();

            // Assert
            Assert.AreEqual(mockResponse, response);
        }

        #endregion

        #region Mock Operation Helper

        /// <summary>
        /// Mock implementation of Operation{BinaryData} for testing OperationWithId.
        /// </summary>
        private class MockOperation : Operation<BinaryData>
        {
            private readonly Response _response;
            private readonly BinaryData _value;
            private readonly bool _hasValue;
            private readonly bool _hasCompleted;

            public MockOperation(Response response, BinaryData value, bool hasValue = false, bool hasCompleted = false)
            {
                _response = response;
                _value = value;
                _hasValue = hasValue;
                _hasCompleted = hasCompleted;
            }

            public override string Id => "mock-operation-id";
            public override BinaryData Value => _value;
            public override bool HasValue => _hasValue;
            public override bool HasCompleted => _hasCompleted;

            public override Response GetRawResponse() => _response;

            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _response;

            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
                => new ValueTask<Response>(_response);
        }

        #endregion
    }
}
