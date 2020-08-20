// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable warnings

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MultipartTests
    {
        private const string Boundary = "batchresponse_6040fee7-a2b8-4e78-a674-02086369606a";
        private const string ContentType = "multipart/mixed; boundary=" + Boundary;
        private const string Body = "{}";

        // Note that CRLF (\r\n) is required. You can't use multi-line C# strings here because the line breaks on Linux are just LF.
        private const string TablesOdataBatchResponse =
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a\r\n" +
"Content-Type: multipart/mixed; boundary=changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"Content-Type: application/http\r\n" +
"Content-Transfer-Encoding: binary\r\n" +
"\r\n" +
"HTTP/1.1 201 Created\r\n" +
"DataServiceVersion: 3.0;\r\n" +
"Content-Type: application/json;odata=fullmetadata;streaming=true;charset=utf-8\r\n" +
"X-Content-Type-Options: nosniff\r\n" +
"Cache-Control: no-cache\r\n" +
"Location: https://mytable.table.core.windows.net/tablename(PartitionKey='somPartition',RowKey='01')\r\n" +
"ETag: W/\"datetime'2020-08-14T22%3A58%3A57.8328323Z'\"\r\n" +
"\r\n" +
"{}\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"Content-Type: application/http\r\n" +
"Content-Transfer-Encoding: binary\r\n" +
"\r\n" +
"HTTP/1.1 201 Created\r\n" +
"DataServiceVersion: 3.0;\r\n" +
"Content-Type: application/json;odata=fullmetadata;streaming=true;charset=utf-8\r\n" +
"X-Content-Type-Options: nosniff\r\n" +
"Cache-Control: no-cache\r\n" +
"Location: https://mytable.table.core.windows.net/tablename(PartitionKey='somPartition',RowKey='02')\r\n" +
"ETag: W/\"datetime'2020-08-14T22%3A58%3A57.8328323Z'\"\r\n" +
"\r\n" +
"{}\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"Content-Type: application/http\r\n" +
"Content-Transfer-Encoding: binary\r\n" +
"\r\n" +
"HTTP/1.1 201 Created\r\n" +
"DataServiceVersion: 3.0;\r\n" +
"Content-Type: application/json;odata=fullmetadata;streaming=true;charset=utf-8\r\n" +
"X-Content-Type-Options: nosniff\r\n" +
"Cache-Control: no-cache\r\n" +
"Location: https://mytable.table.core.windows.net/tablename(PartitionKey='somPartition',RowKey='03')\r\n" +
"ETag: W/\"datetime'2020-08-14T22%3A58%3A57.8328323Z'\"\r\n" +
"\r\n" +
"{}\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92--\r\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a--\r\n" +
"";

        private const string BlobBatchResponse =
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a \r\n" +
"Content-Type: application/http \r\n" +
"Content-ID: 0 \r\n" +
"\r\n" +
"HTTP/1.1 202 Accepted \r\n" +
"x-ms-request-id: 778fdc83-801e-0000-62ff-0334671e284f \r\n" +
"x-ms-version: 2018-11-09 \r\n" +
"\r\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a \r\n" +
"Content-Type: application/http \r\n" +
"Content-ID: 1 \r\n" +
"\r\n" +
"HTTP/1.1 202 Accepted \r\n" +
"x-ms-request-id: 778fdc83-801e-0000-62ff-0334671e2851 \r\n" +
"x-ms-version: 2018-11-09 \r\n" +
"\r\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a \r\n" +
"Content-Type: application/http \r\n" +
"Content-ID: 2 \r\n" +
"\r\n" +
"HTTP/1.1 404 The specified blob does not exist. \r\n" +
"x-ms-error-code: BlobNotFound \r\n" +
"x-ms-request-id: 778fdc83-801e-0000-62ff-0334671e2852 \r\n" +
"x-ms-version: 2018-11-09 \r\n" +
"Content-Length: 216 \r\n" +
"Content-Type: application/xml \r\n" +
"\r\n" +
"<?xml version=\"1.0\" encoding=\"utf-8\"?> \r\n" +
"<Error><Code>BlobNotFound</Code><Message>The specified blob does not exist. \r\n" +
"RequestId:778fdc83-801e-0000-62ff-0334671e2852 \r\n" +
"Time:2018-06-14T16:46:54.6040685Z</Message></Error> \r\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a-- \r\n" +
"0";


        [Test]
        public async Task ParseBatchChangesetResponse()
        {
            var stream = MakeStream(TablesOdataBatchResponse);
            var responses = await Multipart.ParseAsync(stream, ContentType, true, default);

            Assert.That(responses, Is.Not.Null);
            Assert.That(responses.Length, Is.EqualTo(3));
            Assert.That(responses.All(r => r.Status == (int)HttpStatusCode.Created));

            foreach (var response in responses)
            {
                Assert.That(response.TryGetHeader("DataServiceVersion", out var version));
                Assert.That(version, Is.EqualTo("3.0;"));

                Assert.That(response.TryGetHeader("Content-Type", out var contentType));
                Assert.That(contentType, Is.EqualTo("application/json;odata=fullmetadata;streaming=true;charset=utf-8"));

                var bytes = new byte[response.ContentStream.Length];
                await response.ContentStream.ReadAsync(bytes, 0, bytes.Length);
                var content = GetString(bytes, bytes.Length);

                Assert.That(content, Is.EqualTo(Body));

            }
        }

        [Test]
        public async Task ParseBatchResponse()
        {
            var stream = MakeStream(BlobBatchResponse);
            var responses = await Multipart.ParseAsync(stream, ContentType, true, default);

            Assert.That(responses, Is.Not.Null);
            Assert.That(responses.Length, Is.EqualTo(3));

            var response = responses[0];
            Assert.That(response.Status, Is.EqualTo( (int)HttpStatusCode.Accepted));
            Assert.That(response.TryGetHeader("x-ms-version", out var version));
            Assert.That(version, Is.EqualTo("2018-11-09"));
            Assert.That(response.TryGetHeader("x-ms-request-id", out _));

            response = responses[1];
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            Assert.That(response.TryGetHeader("x-ms-version", out version));
            Assert.That(version, Is.EqualTo("2018-11-09"));
            Assert.That(response.TryGetHeader("x-ms-request-id", out _));

            response = responses[2];
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NotFound));
            Assert.That(response.TryGetHeader("x-ms-version", out version));
            Assert.That(version, Is.EqualTo("2018-11-09"));
            Assert.That(response.TryGetHeader("x-ms-request-id", out _));
            var bytes = new byte[response.ContentStream.Length];
            await response.ContentStream.ReadAsync(bytes, 0, bytes.Length);
            var content = GetString(bytes, bytes.Length);
            Assert.That(content.Contains("<Error><Code>BlobNotFound</Code><Message>The specified blob does not exist."));
        }

        private static MemoryStream MakeStream(string text)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(text));
        }

        private static string GetString(byte[] buffer, int count)
        {
            return Encoding.ASCII.GetString(buffer, 0, count);
        }
    }
}
