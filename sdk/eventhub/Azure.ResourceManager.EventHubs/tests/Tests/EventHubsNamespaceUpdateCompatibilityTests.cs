// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventHubsNamespaceUpdateCompatibilityTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task UpdateWaitsForCompletionAndPreservesResponse(bool isAsync)
        {
            var resource = new Mock<EventHubsNamespaceResource> { CallBase = true };
            var updatedResource = Mock.Of<EventHubsNamespaceResource>();
            var rawResponse = new MockResponse(200);
            var operation = new Mock<ArmOperation<EventHubsNamespaceResource>>();
            operation.SetupGet(value => value.Value).Returns(updatedResource);
            operation.Setup(value => value.GetRawResponse()).Returns(rawResponse);
            var data = new EventHubsNamespaceData(AzureLocation.WestUS);
            using var cancellationSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationSource.Token;

            resource.Setup(value => value.Update(WaitUntil.Completed, data, cancellationToken))
                .Returns(operation.Object);
            resource.Setup(value => value.UpdateAsync(WaitUntil.Completed, data, cancellationToken))
                .ReturnsAsync(operation.Object);

            Response<EventHubsNamespaceResource> response = isAsync
                ? await resource.Object.UpdateAsync(data, cancellationToken)
                : resource.Object.Update(data, cancellationToken);

            Assert.AreSame(updatedResource, response.Value);
            Assert.AreSame(rawResponse, response.GetRawResponse());
            if (isAsync)
            {
                resource.Verify(value => value.UpdateAsync(WaitUntil.Completed, data, cancellationToken), Times.Once);
                resource.Verify(value => value.Update(It.IsAny<WaitUntil>(), It.IsAny<EventHubsNamespaceData>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            else
            {
                resource.Verify(value => value.Update(WaitUntil.Completed, data, cancellationToken), Times.Once);
                resource.Verify(value => value.UpdateAsync(It.IsAny<WaitUntil>(), It.IsAny<EventHubsNamespaceData>(), It.IsAny<CancellationToken>()), Times.Never);
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UpdatePropagatesFailure(bool isAsync)
        {
            var resource = new Mock<EventHubsNamespaceResource> { CallBase = true };
            var data = new EventHubsNamespaceData(AzureLocation.WestUS);
            var failure = new RequestFailedException(400, "Namespace update failed.");
            resource.Setup(value => value.Update(WaitUntil.Completed, data, default))
                .Throws(failure);
            resource.Setup(value => value.UpdateAsync(WaitUntil.Completed, data, default))
                .ThrowsAsync(failure);

            RequestFailedException actual = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (isAsync)
                {
                    await resource.Object.UpdateAsync(data);
                }
                else
                {
                    resource.Object.Update(data);
                }
            });

            Assert.AreSame(failure, actual);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void UpdateRejectsNullData(bool isAsync)
        {
            var resource = new Mock<EventHubsNamespaceResource> { CallBase = true };

            ArgumentNullException exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                if (isAsync)
                {
                    await resource.Object.UpdateAsync(null);
                }
                else
                {
                    resource.Object.Update(null);
                }
            });

            Assert.AreEqual("data", exception.ParamName);
        }
    }
}
