// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Data.Tables.Models;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TablesExceptionParserTests
    {
        private static Exception TableBeingDeleted = new RequestFailedException(400, "Service request failed.\r\nStatus: 400\r\n\r\nContent:\r\n{\"odata.error\":{\"code\":\"TableBeingDeleted\",\"message\":{\"lang\":\"en-US\",\"value\":\"The specified table is being deleted. Try operation later.\nRequestId:a20c0f16-a002-0008-4cba-202e1b000000\nTime:2021-03-24T14:31:38.8327083Z\"}}}");
        private static Exception MissingOdata = new RequestFailedException(400, "Service request failed.\r\nStatus: 400\r\n\r\nContent:\r\n{\"odata.foo\":{\"code\":\"TableBeingDeleted\",\"message\":{\"lang\":\"en-US\",\"value\":\"The specified table is being deleted. Try operation later.\nRequestId:a20c0f16-a002-0008-4cba-202e1b000000\nTime:2021-03-24T14:31:38.8327083Z\"}}}");
        private static Exception MissingCode = new RequestFailedException(400, "Service request failed.\r\nStatus: 400\r\n\r\nContent:\r\n{\"odata.error\":{\"foo\":\"TableBeingDeleted\",\"message\":{\"lang\":\"en-US\",\"value\":\"The specified table is being deleted. Try operation later.\nRequestId:a20c0f16-a002-0008-4cba-202e1b000000\nTime:2021-03-24T14:31:38.8327083Z\"}}}");

        // Incoming Exception, Expected Exception, Expected TableErrorCode
        public static IEnumerable<object[]> OdataErrorTestInputs()
        {
            yield return new object[] { TableBeingDeleted, TableErrorCode.TableBeingDeleted };
            yield return new object[] { MissingOdata, null };
            yield return new object[] { MissingCode, null };
        }

        [OneTimeSetUp]
        public void Setup()
        {
            TableBeingDeleted.Data.Add("foo", "bar");
        }

        [Test]
        [TestCaseSource(nameof(OdataErrorTestInputs))]
        public void TryParseOdataError(RequestFailedException originalException, TableErrorCode? expectedErrorCode)
        {
            var actualException = TablesExceptionParser.Parse(originalException);

            Assert.That(actualException.Status, Is.EqualTo(originalException.Status));
            Assert.That(actualException.Message, Is.EqualTo(originalException.Message));
            Assert.That(actualException.Data.Keys, Is.EquivalentTo(originalException.Data.Keys));
            Assert.That(actualException.Data.Values, Is.EquivalentTo(originalException.Data.Values));
            Assert.That(actualException.ErrorCode, Is.EqualTo(expectedErrorCode?.ToString()));
            if (expectedErrorCode != null)
            {
                Assert.That(actualException.InnerException, Is.EqualTo(originalException));
            }
        }
    }
}
