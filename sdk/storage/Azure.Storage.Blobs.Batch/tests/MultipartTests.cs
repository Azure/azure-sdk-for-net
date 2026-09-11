// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class MultipartTests
    {
        [TestCase("tag\r\nx-ms-delete-snapshots: include")]
        [TestCase("tag\nx-ms-delete-snapshots: include")]
        public void CreateAsync_RejectsHeaderValuesContainingNewLines(string ifTags)
        {
            using HttpMessage message = new HttpMessage(new MockRequest(), new ResponseClassifier());
            message.Request.Method = RequestMethod.Delete;
            message.Request.Uri.Reset(new Uri("https://account.blob.core.windows.net/container/blob"));
            message.Request.Headers.SetValue("x-ms-if-tags", ifTags);

            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(async () =>
                await Multipart.CreateAsync(new[] { message }, "batch", async: true, CancellationToken.None));

            StringAssert.Contains("x-ms-if-tags", exception.Message);
        }
    }
}
