// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable warnings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MultipartTests
    {
        private const string Boundary = "batchresponse_6040fee7-a2b8-4e78-a674-02086369606a";
        private const string ContentType = "multipart/mixed; boundary=" + Boundary;
        private const string Body = "{}";

        // Note that CRLF (\r\n) is required. You can't use multi-line C# strings here because the line breaks on Linux are just LF.

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

        private const string TablesOdataBatchResponse =
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a\r\n" +
"Content-Type: multipart/mixed; boundary=changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"Content-Type: application/http\r\n" +
"Content-Transfer-Encoding: binary\r\n" +
"\r\n" +
"HTTP/1.1 204 No Content\r\n" +
"DataServiceVersion: 3.0;\r\n" +
"Content-Type: application/json;odata=fullmetadata;streaming=true;charset=utf-8\r\n" +
"X-Content-Type-Options: nosniff\r\n" +
"Cache-Control: no-cache\r\n" +
"Location: https://mytable.table.core.windows.net/tablename(PartitionKey='somPartition',RowKey='01')\r\n" +
"ETag: W/\"datetime'2020-08-14T22%3A58%3A57.8328323Z'\"\r\n" +
"\r\n" +
"\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92--\r\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a--\r\n" +
"";
        private const string CosmosTableBatchOdataResponse =
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a\n" +
"Content-Type: multipart/mixed; boundary=changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\r\n" +
"\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92\n" +
"Content-Type: application/http\n" +
"Content-Transfer-Encoding: binary\r\n" +
"\r\n" +
"HTTP/1.1 204 No Content\r\n" +
"ETag: W/\"datetime'2020-09-23T00%3A57%3A45.1446280Z'\"\r\n" +
"Preference-Applied: return-no-content\r\n" +
"Location: https://chrissprim.table.cosmos.azure.com/testtableo6uc2ude(PartitionKey='somPartition',RowKey='01')\r\n" +
"Content-Type: application/json;odata=fullmetadata;streaming=true;charset=utf-8\r\n" +
"Content-ID: 1\r\n" +
"\r\n" +
"\r\n" +
"--changesetresponse_e52cbca8-7e7f-4d91-a719-f99c69686a92--\n" +
"--batchresponse_6040fee7-a2b8-4e78-a674-02086369606a--\n" +
"";

        [Test]
        [TestCase(TablesOdataBatchResponse)]
        [TestCase(CosmosTableBatchOdataResponse)]
        public async Task ParseBatchChangesetResponse(string batchResponse)
        {
            var stream = MakeStream(batchResponse);
            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;
            mockResponse.AddHeader("Content-Type", ContentType);
            var responses = await MultipartResponse.ParseAsync(mockResponse, false, true, default);

            Assert.That(responses, Is.Not.Null);
            Assert.That(responses.Length, Is.EqualTo(1));
            Assert.That(responses.All(r => r.Status == (int)HttpStatusCode.NoContent));

            foreach (var response in responses)
            {
                Assert.That(response.TryGetHeader("Location", out var location));
                Assert.That(location.Contains("RowKey='01'"));

                Assert.That(response.TryGetHeader("Content-Type", out var contentType));
                Assert.That(contentType, Is.EqualTo("application/json;odata=fullmetadata;streaming=true;charset=utf-8"));

                var bytes = new byte[response.ContentStream.Length];
#if NET6_0_OR_GREATER
                await response.ContentStream.ReadExactlyAsync(bytes, 0, bytes.Length);
#else
                await response.ContentStream.ReadAsync(bytes, 0, bytes.Length);
#endif
                var content = GetString(bytes, bytes.Length);

                Assert.That(content, Is.EqualTo(string.Empty));
            }
        }

        [Test]
        public async Task ParseBatchResponse()
        {
            var stream = MakeStream(BlobBatchResponse);
            var mockResponse = new MockResponse(200);
            mockResponse.ContentStream = stream;
            mockResponse.AddHeader("Content-Type", ContentType);

            var responses = await MultipartResponse.ParseAsync(mockResponse, true, true, default);

            Assert.That(responses, Is.Not.Null);
            Assert.That(responses.Length, Is.EqualTo(3));

            var response = responses[0];
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.Accepted));
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
#if NET6_0_OR_GREATER
            await response.ContentStream.ReadExactlyAsync(bytes, 0, bytes.Length);
#else
            await response.ContentStream.ReadAsync(bytes, 0, bytes.Length);
#endif
            var content = GetString(bytes, bytes.Length);
            Assert.That(content.Contains("<Error><Code>BlobNotFound</Code><Message>The specified blob does not exist."));
        }

        [Test]
        public async Task SendMultipartData()
        {
            const string ApplicationJson = "application/json";
            const string cteHeaderName = "Content-Transfer-Encoding";
            const string Binary = "binary";
            const string Mixed = "mixed";
            const string ApplicationJsonOdata = "application/json; odata=nometadata";
            const string DataServiceVersion = "DataServiceVersion";
            const string Three0 = "3.0";
            // cspell:ignore myaccount
            const string Host = "myaccount.table.core.windows.net";

            using Request request = new MockRequest
            {
                Method = RequestMethod.Put
            };
            request.Uri.Reset(new Uri("https://foo"));

            Guid batchGuid = Guid.NewGuid();
            var content = new MultipartContent(Mixed, $"batch_{batchGuid}");

            Guid changesetGuid = Guid.NewGuid();
            var changeset = new MultipartContent(Mixed, $"changeset_{changesetGuid}");
            content.Add(changeset, changeset._headers);

            var postReq1 = new MockRequest
            {
                Method = RequestMethod.Post
            };
            string postUri = $"https://{Host}/Blogs";
            postReq1.Uri.Reset(new Uri(postUri));
            postReq1.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            postReq1.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            postReq1.Headers.Add(DataServiceVersion, Three0);
            const string post1Body = "{ \"PartitionKey\":\"Channel_19\", \"RowKey\":\"1\", \"Rating\":9, \"Text\":\"Azure...\"}";
            postReq1.Content = RequestContent.Create(Encoding.UTF8.GetBytes(post1Body));
            changeset.Add(new RequestRequestContent(postReq1), new Dictionary<string, string> { { HttpHeader.Names.ContentType, "application/http" }, { cteHeaderName, Binary } });

            var postReq2 = new MockRequest
            {
                Method = RequestMethod.Post
            };
            postReq2.Uri.Reset(new Uri(postUri));
            postReq2.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            postReq2.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            postReq2.Headers.Add(DataServiceVersion, Three0);
            const string post2Body = "{ \"PartitionKey\":\"Channel_17\", \"RowKey\":\"2\", \"Rating\":9, \"Text\":\"Azure...\"}";
            postReq2.Content = RequestContent.Create(Encoding.UTF8.GetBytes(post2Body));
            changeset.Add(new RequestRequestContent(postReq2), new Dictionary<string, string> { { HttpHeader.Names.ContentType, "application/http" }, { cteHeaderName, Binary } });

            var patchReq = new MockRequest
            {
                Method = RequestMethod.Patch
            };
            string mergeUri = $"https://{Host}/Blogs(PartitionKey='Channel_17',%20RowKey='3')";
            patchReq.Uri.Reset(new Uri(mergeUri));
            patchReq.Headers.Add(HttpHeader.Names.ContentType, ApplicationJsonOdata);
            patchReq.Headers.Add(HttpHeader.Names.Accept, ApplicationJson);
            patchReq.Headers.Add(DataServiceVersion, Three0);
            const string patchBody = "{ \"PartitionKey\":\"Channel_19\", \"RowKey\":\"3\", \"Rating\":9, \"Text\":\"Azure Tables...\"}";
            patchReq.Content = RequestContent.Create(Encoding.UTF8.GetBytes(patchBody));
            changeset.Add(new RequestRequestContent(patchReq), new Dictionary<string, string> { { HttpHeader.Names.ContentType, "application/http" }, { cteHeaderName, Binary } });

            content.ApplyToRequest(request);
            var memStream = new MemoryStream();
            await content.WriteToAsync(memStream, default);
            memStream.Position = 0;
            using var sr = new StreamReader(memStream, Encoding.UTF8);
            string requestBody = sr.ReadToEnd();
            Console.WriteLine(requestBody);

            Assert.That(requestBody, Is.EqualTo($"--batch_{batchGuid}\r\n" +
                $"{HttpHeader.Names.ContentType}: multipart/mixed; boundary=changeset_{changesetGuid}\r\n" +
                $"\r\n" +
                $"--changeset_{changesetGuid}\r\n" +
                $"{HttpHeader.Names.ContentType}: application/http\r\n" +
                $"{cteHeaderName}: {Binary}\r\n" +
                $"\r\n" +
                $"POST {postUri} HTTP/1.1\r\n" +
                $"{HttpHeader.Names.Host}: {Host}\r\n" +
                $"{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}\r\n" +
                $"{HttpHeader.Names.Accept}: {ApplicationJson}\r\n" +
                $"{DataServiceVersion}: {Three0}\r\n" +
                $"\r\n" +
                $"{post1Body}\r\n" +
                $"--changeset_{changesetGuid}\r\n" +
                $"{HttpHeader.Names.ContentType}: application/http\r\n" +
                $"{cteHeaderName}: {Binary}\r\n" +
                $"\r\n" +
                $"POST {postUri} HTTP/1.1\r\n" +
                $"{HttpHeader.Names.Host}: {Host}\r\n" +
                $"{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}\r\n" +
                $"{HttpHeader.Names.Accept}: {ApplicationJson}\r\n" +
                $"{DataServiceVersion}: {Three0}\r\n" +
                $"\r\n" +
                $"{post2Body}\r\n" +
                $"--changeset_{changesetGuid}\r\n" +
                $"{HttpHeader.Names.ContentType}: application/http\r\n" +
                $"{cteHeaderName}: {Binary}\r\n" +
                $"\r\n" +
                $"PATCH {mergeUri} HTTP/1.1\r\n" +
                $"{HttpHeader.Names.Host}: {Host}\r\n" +
                $"{HttpHeader.Names.ContentType}: {ApplicationJsonOdata}\r\n" +
                $"{HttpHeader.Names.Accept}: {ApplicationJson}\r\n" +
                $"{DataServiceVersion}: {Three0}\r\n" +
                $"\r\n" +
                $"{patchBody}\r\n" +
                $"--changeset_{changesetGuid}--\r\n" +
                $"\r\n" +
                $"--batch_{batchGuid}--\r\n" +
                $""));
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
