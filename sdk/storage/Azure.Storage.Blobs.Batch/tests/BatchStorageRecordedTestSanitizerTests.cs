// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
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
            var expectedSanitizedBody = "DELETE /test-container/blob3?sv=2020-06-12&ss=b&srt=sco&st=2021-02-18T19%3A39%3A42Z&se=2021-02-18T21%3A39%3A42Z&sp=rwdxlacuptf&sig=Sanitized HTTP/1.1\r\n"
                + "DELETE /test-container/blob3?sv=2020-06-12&ss=b&srt=sco&st=2021-02-18T19%3A39%3A42Z&se=2021-02-18T21%3A39%3A42Z&sp=rwdxlacuptf&sig=Sanitized HTTP/1.1\r\n";
            // Act
            var sanitizedBody = new BatchStorageRecordedTestSanitizer().SanitizeBody("multipart/mixed", Encoding.UTF8.GetBytes(sampleBody));

            // Assert
            Assert.AreEqual(expectedSanitizedBody, Encoding.UTF8.GetString(sanitizedBody));
        }
    }
}
