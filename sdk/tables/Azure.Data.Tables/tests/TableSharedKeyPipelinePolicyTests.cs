// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableSharedKeyPipelinePolicyTests
    {
        public static Uri hasQuery = new Uri("https://foo.table.core.windows.net/?restype=service&comp=properties&sv=2019-02-02&ss=t&srt=s&se=2040-01-01T01%3A01%3A00Z&sp=rwdlau&sig=Sanitized");
        public static Uri hasQueryNoComp = new Uri("https://foo.table.core.windows.net/?sv=2019-02-02&ss=t&srt=s&se=2040-01-01T01%3A01%3A00Z&sp=rwdlau&sig=Sanitized");
        public static Uri hasNoQuery = new Uri("https://foo.table.core.windows.net/test");

        public static IEnumerable<object[]> inputUris()
        {
            yield return new object[] { hasQuery, "properties" };
            yield return new object[] { hasQueryNoComp, null };
            yield return new object[] { hasNoQuery, null };
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(inputUris))]
        public void ConstructorValidatesArguments(Uri uri, string expectedValue)
        {
            TableSharedKeyPipelinePolicy.TryGetCompQueryParameterValue(uri, out var actualValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
