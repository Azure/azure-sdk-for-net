// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class ExtractFailureContentTests : ClientTestBase
    {
        private static string messageValue = "The specified table is being deleted. Try operation later.\nRequestId:a20c0f16-a002-0008-4cba-202e1b000000\nTime:2021-03-24T14:31:38.8327083Z";
        private const string batchMessage = ":The specified entity already exists.\n\nRequestID:6c646e8a-3731-2f10-db82-35d8ee02e977\n";
        private const string failedEntityIndex = "22";
        private static string TableBeingDeleted = "{\"odata.error\":{\"code\":\"TableBeingDeleted\",\"message\":{\"lang\":\"en-US\",\"value\":\"" + messageValue + "\"}}}";
        private static string BatchError = "{\"odata.error\":{\"code\":\"EntityAlreadyExists\",\"message\":{\"lang\":\"en-us\",\"value\":\"" + failedEntityIndex + batchMessage + "\"}}}";

        public ExtractFailureContentTests(bool isAsync) : base(isAsync)
        {
        }

        // Incoming Exception, Expected Exception, Expected TableErrorCode
        public static IEnumerable<object[]> OdataErrorTestInputs()
        {
            yield return new object[] { TableBeingDeleted, messageValue, TableErrorCode.TableBeingDeleted, new Dictionary<string, object>() };
            yield return new object[] { BatchError, batchMessage, TableErrorCode.EntityAlreadyExists, new Dictionary<string, object>() { { TableConstants.ExceptionData.FailedEntityIndex, failedEntityIndex } } };
        }

        [TestCaseSource(nameof(OdataErrorTestInputs))]
        public async Task ParseOdataError(string content, string expectedMessage, TableErrorCode expectedErrorCode, Dictionary<string, object> expectedData)
        {
            var response = new MockResponse(400) { ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(content.Replace("\n", "\\n"))) };
            response.AddHeader(HttpHeader.Common.JsonContentType);

            var transport = new MockTransport(request => response);
            var options = TableClientOptions.DefaultOptions;
            options.Transport = transport;
            var client = InstrumentClient(
                new TableClient(
                    new Uri($"https://example.com"),
                    "tablename",
                    new MockCredential(),
                    options));
            try
            {
                await client.CreateAsync();
            }
            catch (RequestFailedException actualException)
            {
                Assert.That(actualException.Message, Contains.Substring(expectedMessage));
                Assert.That(actualException.Data.Keys, Is.EquivalentTo(expectedData.Keys));
                Assert.That(actualException.Data.Values, Is.EquivalentTo(expectedData.Values));
                Assert.That(actualException.ErrorCode, Is.EqualTo(expectedErrorCode.ToString()));
            }
        }
    }
}
