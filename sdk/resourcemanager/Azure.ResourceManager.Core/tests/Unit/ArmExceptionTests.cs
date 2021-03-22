// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;
using Moq;
using Moq.Protected;
using NUnit.Framework;

#nullable enable

namespace Azure.ResourceManager.Core.Tests.Unit
{
    public class ArmExceptionTests
    {
        private const string AppJsonPrefix = "application/json";

        private static readonly string TestAssetPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "ArmException");

        private readonly IDictionary<string, string?> HttpHeaders = new Dictionary<string, string?>
        {
            { "Content-Type", AppJsonPrefix },
        };

        [TestCase("ArmExceptionSimpleV1.json")]
        [TestCase("ArmExceptionSimpleV2.json")]
        public void CreateExceptionTests(string jsonAssetFileName)
        {
            //var clientDiagnostics = GetClientDiagnostics();
            var response = GetMockResponse(jsonAssetFileName);

            ArmException exp = GetClientDiagnostics().CreateArmExceptionWithContent(response);

            Assert.IsNotNull(exp);
        }

        private ClientDiagnostics GetClientDiagnostics()
        {
            var options = new Mock<ClientOptions>();

            return new ClientDiagnostics(options.Object);
        }

        private Response GetMockResponse(string jsonAssetFileName)
        {
            var mock = new Mock<Response>();

            // Set up the content stream on the response
            var jsonStream = new FileStream(
                Path.Combine(TestAssetPath, jsonAssetFileName),
                FileMode.Open);
            mock.Setup(res => res.ContentStream).Returns(jsonStream);

            // Set up response header
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            // ReSharper disable once PossibleNullReferenceException
            var responseHeaders = (ResponseHeaders)typeof(ResponseHeaders)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(Response) }, null)
                .Invoke(new object[] { mock.Object });
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            mock.SetupGet(res => res.Headers).Returns(responseHeaders);
            mock.Protected()
                .Setup<bool>("TryGetHeader", ItExpr.IsAny<string>(), ItExpr.Ref<string>.IsAny)
                .Returns(new TryGetHeaderCallback((string name, out string? value) => HttpHeaders.TryGetValue(name, out value)));

            return mock.Object;
        }

        private delegate bool TryGetHeaderCallback(string name, out string? value);
    }
}
