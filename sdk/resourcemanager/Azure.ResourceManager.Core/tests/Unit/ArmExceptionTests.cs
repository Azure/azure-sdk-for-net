// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        [TestCase("ArmExceptionSimpleV1.json", true)]
        [TestCase("ArmExceptionSimpleV1.json", false)]
        [TestCase("ArmExceptionSimpleV2.json", true)]
        [TestCase("ArmExceptionSimpleV2.json", false)]
        public async Task CreateExceptionTests(string jsonAssetFileName, bool isAsync)
        {
            var response = GetMockResponse(jsonAssetFileName);

            ArmException exp;
            if (isAsync)
            {
                exp = await GetClientDiagnostics().CreateArmExceptionAsync(response);
            }
            else
            {
                exp = GetClientDiagnostics().CreateArmException(response);
            }

            VerifyException(exp);
            Assert.IsNotNull(exp);
            Assert.IsNotNull(exp.Details);
            Assert.AreEqual(1, exp.Details?.Length);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            VerifyException(exp.Details[0]);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void VerifyException(ArmException exp)
        {
            Assert.IsNotNull(exp);
            Assert.AreEqual("400", exp.Code);
            Assert.AreEqual("message", exp.Message);
            Assert.IsTrue(exp.Data.Contains("additionalInfo_type1"));
            Assert.AreEqual("additionalInfo_info1", exp.Data["additionalInfo_type1"]);
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
