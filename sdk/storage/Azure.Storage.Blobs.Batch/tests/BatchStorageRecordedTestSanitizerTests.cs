// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchStorageRecordedTestSanitizerTests
    {
        [Test]
        public void ShouldStripSignatureFromBody()
        {
            // Arrange
            var sampleBody = "DELETE /test-container/blob3?sv=2020-06-12&ss=b&srt=sco&st=2021-02-18T19%3A39%3A42Z&se=2021-02-18T21%3A39%3A42Z&sp=rwdxlacuptf&sig=abcde HTTP/1.1\r\n"
                + "DELETE /test-container/blob3?sv=2020-06-12&ss=b&srt=sco&st=2021-02-18T19%3A39%3A42Z&se=2021-02-18T21%3A39%3A42Z&sp=rwdxlacuptf&sig=abcd HTTP/1.1\r\n";

            // Act
            var bodyRegexSanitizer = new BatchStorageRecordedTestSanitizer().BodyRegexSanitizers.Last();
            var regex = new Regex(bodyRegexSanitizer.Regex);

            // Assert
            Assert.AreEqual("Sanitized", bodyRegexSanitizer.Value);
            var match = regex.Match(sampleBody);
            Assert.AreEqual("sig=abcde", match.Groups[0].ToString());
            Assert.AreEqual("abcde", match.Groups[1].ToString());
        }
    }
}
