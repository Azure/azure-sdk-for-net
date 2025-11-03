// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core.Pipeline;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class OptOutsClientTest
    {
        [Test]
        public void OptOuts_ThrowsWithNullClientDiagnostics()
        {
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new OptOuts(null, httpPipeline, uri));
        }

        [Test]
        public void OptOuts_ThrowsWithNullPipeline()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new OptOuts(clientDiagnostics, null, uri));
        }

        [Test]
        public void OptOuts_ThrowsWithNullEndpoint()
        {
            var clientDiagnostics = new ClientDiagnostics(new SmsClientOptions());
            var httpPipeline = HttpPipelineBuilder.Build(new SmsClientOptions());

            Assert.Throws<ArgumentNullException>(() => new OptOuts(clientDiagnostics, httpPipeline, null));
        }

        [TestCaseSource(nameof(TestData))]
        public async Task CheckAsyncOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.CheckAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutResponseItem>> actualResponse = await mockClient.Object.CheckAsync(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public void CheckOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Check(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutResponseItem>> actualResponse = mockClient.Object.Check(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public async Task AddAsyncOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutAddResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.AddAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutAddResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutAddResponseItem>> actualResponse = await mockClient.Object.AddAsync(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public void AddOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutAddResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Add(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutAddResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutAddResponseItem>> actualResponse = mockClient.Object.Add(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public async Task RemoveAsyncOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutRemoveResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.RemoveAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .ReturnsAsync((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutRemoveResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutRemoveResponseItem>> actualResponse = await mockClient.Object.RemoveAsync(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData))]
        public void RemoveOverload_PassesToGeneratedOne(string expectedFrom, IEnumerable<string> expectedTo)
        {
            Mock<OptOuts> mockClient = new Mock<OptOuts>() { CallBase = true };
            Response<IReadOnlyList<OptOutRemoveResponseItem>>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.Remove(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()));

            mockClient
                .Setup(callExpression)
                .Returns((string from, IEnumerable<string> to, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedFrom, from);
                    Assert.AreEqual(expectedTo, to);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<IReadOnlyList<OptOutRemoveResponseItem>>>().Object;
                });

            Response<IReadOnlyList<OptOutRemoveResponseItem>> actualResponse = mockClient.Object.Remove(expectedFrom, expectedTo, cancellationToken);

            mockClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object> TestData()
        {
            yield return new TestCaseData("+14255550123", new List<string> { "+14255550234" });
        }

        private static Expression<Func<OptOuts, TResult>> BuildExpression<TResult>(Expression<Func<OptOuts, TResult>> expression)
            => expression;
    }
}
