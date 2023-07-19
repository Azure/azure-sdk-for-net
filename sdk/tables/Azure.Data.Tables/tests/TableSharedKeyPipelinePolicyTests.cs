// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableSharedKeyPipelinePolicyTests
    {
        private const string AccountName = "account";
        private const string CompValue = "comp=properties";
        public static Uri hasQuery = new Uri($"https://foo.table.core.windows.net/foopath?restype=service&{CompValue}&sv=2019-02-02&ss=t&srt=s&se=2040-01-01T01%3A01%3A00Z&sp=rwdlau&sig=Sanitized");
        public static Uri hasQueryNoComp = new Uri("https://foo.table.core.windows.net/?sv=2019-02-02&ss=t&srt=s&se=2040-01-01T01%3A01%3A00Z&sp=rwdlau&sig=Sanitized");
        public static Uri hasNoQuery = new Uri($"https://foo.table.core.windows.net/test");

        public static IEnumerable<object[]> inputUris()
        {
            yield return new object[] { hasQuery, $"/{AccountName}{hasQuery.AbsolutePath}?{CompValue}" };
            yield return new object[] { hasQueryNoComp,  $"/{AccountName}{hasQueryNoComp.AbsolutePath}"};
            yield return new object[] { hasNoQuery, $"/{AccountName}{hasNoQuery.AbsolutePath}" };
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(inputUris))]
        public void BuildCanonicalizedResource(Uri uri, string expectedValue)
        {
            var policy = new TableSharedKeyPipelinePolicy(new TableSharedKeyCredential(AccountName, "Kg=="));
            var actualValue = policy.BuildCanonicalizedResource(uri);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
