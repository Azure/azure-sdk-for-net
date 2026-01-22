// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Azure.Storage.Blobs.Test;
using Azure.Storage.Test.Shared;
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
            // service version doesn't matter here - just need to construct an instance of the recorded test class
            var bodyRegexSanitizer = new BlobBatchClientTests(false, BlobClientOptions.ServiceVersion.V2021_04_10).BodyRegexSanitizers.Last();
            var regex = new Regex(bodyRegexSanitizer.Regex);

            // Assert
            Assert.That(bodyRegexSanitizer.Value, Is.EqualTo("Sanitized"));
            var match = regex.Match(sampleBody);
            Assert.That(match.Groups[0].ToString(), Is.EqualTo("sig=abcde"));
            Assert.That(match.Groups[1].ToString(), Is.EqualTo("abcde"));
        }
    }
}
