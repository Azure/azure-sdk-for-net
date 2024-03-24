// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class FailedResponseExceptionTests
    {
        private static readonly string s_nl = Environment.NewLine;
        private static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestClientOption());
        private static HttpMessageSanitizer Sanitizer = new TestClientOption().Sanitizer;

        [Test]
        public void FormatsResponse()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);

            Response rawResponse = exception.GetRawResponse();
            Assert.IsTrue(rawResponse.Headers.TryGetValue("Custom-Header", out var value));
            Assert.AreEqual("Value", value);
            Assert.IsTrue(rawResponse.Headers.TryGetValue("x-ms-requestId", out var requestId));
            Assert.AreEqual("123", requestId);
            Assert.IsNull(rawResponse.ContentStream);
        }

        [Test]
        public void FormatsResponse_ResponseCtor()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);

            Response rawResponse = exception.GetRawResponse();
            Assert.IsTrue(rawResponse.Headers.TryGetValue("Custom-Header", out var value));
            Assert.AreEqual("Value", value);
            Assert.IsTrue(rawResponse.Headers.TryGetValue("x-ms-requestId", out var requestId));
            Assert.AreEqual("123", requestId);
            Assert.IsNull(rawResponse.ContentStream);
        }

        [Test]
        public void FormatsResponseWithoutSanitizer_ResponseCtor()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: REDACTED" + s_nl +
                "x-ms-requestId: REDACTED" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);

            Response rawResponse = exception.GetRawResponse();
            Assert.IsTrue(rawResponse.Headers.TryGetValue("Custom-Header", out var value));
            Assert.AreEqual("Value", value);
            Assert.IsTrue(rawResponse.Headers.TryGetValue("x-ms-requestId", out var requestId));
            Assert.AreEqual("123", requestId);
            Assert.IsNull(rawResponse.ContentStream);
        }

        [Test]
        public void HeadersAreSanitized()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header-2: REDACTED" + s_nl +
                "x-ms-requestId-2: REDACTED" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header-2", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId-2", "123"));

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public void HeadersAreSanitized_ResponseCtor()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header-2: REDACTED" + s_nl +
                "x-ms-requestId-2: REDACTED" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header-2", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId-2", "123"));

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public void FormatsResponseContentForTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Content:" + s_nl +
                "{\"errorCode\": 1}" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{\"errorCode\": 1}");
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);

            Response rawResponse = exception.GetRawResponse();
            Assert.IsTrue(rawResponse.Headers.TryGetValue("Content-Type", out var value));
            Assert.AreEqual("text/json", value);
            Assert.IsTrue(rawResponse.Headers.TryGetValue("x-ms-requestId", out var requestId));
            Assert.AreEqual("123", requestId);
            Assert.IsInstanceOf<MemoryStream>(rawResponse.ContentStream);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);
            Assert.AreEqual("{\"errorCode\": 1}", rawResponse.Content.ToString());
        }

        [Test]
        public void DoesntFormatsResponseContentForNonTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: binary" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "binary"));
            response.SetContent("{\"errorCode\": 1}");
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
            Response rawResponse = exception.GetRawResponse();

            Assert.IsInstanceOf<MemoryStream>(rawResponse.ContentStream);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);
            Assert.AreEqual("{\"errorCode\": 1}", rawResponse.Content.ToString());
        }

        [Test]
        public void IncludesErrorCodeInMessageIfAvailable()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: CUSTOM CODE" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{ \"error\": { \"code\":\"CUSTOM CODE\" }}");
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public void IncludesAdditionalInformationIfAvailable()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Additional Information:" + s_nl +
                "a: a-value" + s_nl +
                "b: b-value" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{ \"a\": \"a-value\", \"b\": \"b-value\" }");
            response.Sanitizer = Sanitizer;
            response.RequestFailedDetailsParser = new CustomParser();

            RequestFailedException exception = new RequestFailedException(response);

            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("a-value", exception.Data["a"]);
            Assert.AreEqual("b-value", exception.Data["b"]);
        }

        [Test]
        public void IncludesInnerException()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.Sanitizer = Sanitizer;

            var innerException = new Exception();
            RequestFailedException exception = new RequestFailedException(response, innerException: innerException);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual(innerException, exception.InnerException);
        }

        [Test]
        public void RequestFailedExceptionIsSerializeable()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(RequestFailedException));
            var exception = new RequestFailedException(201, "Message", "Error", null);
            RequestFailedException deserialized;
            using var memoryStream = new MemoryStream();
            dataContractSerializer.WriteObject(memoryStream, exception);
            memoryStream.Position = 0;
            deserialized = (RequestFailedException)dataContractSerializer.ReadObject(memoryStream);

            Assert.AreEqual(exception.Message, deserialized.Message);
            Assert.AreEqual(exception.Status, deserialized.Status);
            Assert.AreEqual(exception.ErrorCode, deserialized.ErrorCode);
        }

        [Test]
        public void ParsesJsonErrors(
            [Values(true, false)] bool hasErrorWrapper)
        {
            var formattedResponse =
                "Custom message" + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: StatusCode" + s_nl +
                s_nl +
                "Content:" + s_nl +
            (hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }") + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            var errorContent = hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }";
            response.SetContent(errorContent);
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("StatusCode", exception.ErrorCode);
        }

        [Test]
        public void ParsesJsonErrors_ResponseCtor(
            [Values(true, false)] bool hasErrorWrapper)
        {
            var formattedResponse =
                "Custom message" + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: StatusCode" + s_nl +
                s_nl +
                "Content:" + s_nl +
            (hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }") + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            var errorContent = hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }";
            response.SetContent(errorContent);
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("StatusCode", exception.ErrorCode);
        }

        [Test]
        public void ParsesJsonErrors_ResponseCtor_Stream(
            [Values(true, false)] bool canSeek,
            [Values(true, false)] bool hasErrorWrapper)
        {
            var formattedResponse =
                "Custom message" + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: StatusCode" + s_nl +
                s_nl +
                "Content:" + s_nl +
            (hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }") + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            var errorContent = hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }";
            response.ContentStream = GetStream(canSeek, errorContent);
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("StatusCode", exception.ErrorCode);
            Response rawResponse = exception.GetRawResponse();

            Assert.IsInstanceOf<MemoryStream>(rawResponse.ContentStream);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);
            Assert.AreEqual(errorContent, rawResponse.Content.ToString());
        }

        [Test]
        public async Task ParsesJsonErrors_ResponseCtor_StreamAsync(
            [Values(true, false)] bool canSeek,
            [Values(true, false)] bool hasErrorWrapper)
        {
            await Task.Yield();
            var formattedResponse =
                "Custom message" + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: StatusCode" + s_nl +
                s_nl +
                "Content:" + s_nl +
            (hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }") + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            var errorContent = hasErrorWrapper ? "{ \"error\": { \"code\":\"StatusCode\", \"message\":\"Custom message\" }}" :
                "{ \"code\":\"StatusCode\", \"message\":\"Custom message\" }";
            response.ContentStream = GetStream(canSeek, errorContent);
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("StatusCode", exception.ErrorCode);

            Response rawResponse = exception.GetRawResponse();
            Assert.IsInstanceOf<MemoryStream>(rawResponse.ContentStream);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);
            Assert.AreEqual(errorContent, rawResponse.Content.ToString());
        }

        [Test]
        public void IgnoresInvalidJsonErrors()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Content:" + s_nl +
                "{ \"error\": { \"code\":\"StatusCode\"" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.SetContent("{ \"error\": { \"code\":\"StatusCode\"");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public void IgnoresNonStandardJson()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Content:" + s_nl +
                "{ \"customCode\":\"StatusCode\" }" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.SetContent("{ \"customCode\":\"StatusCode\" }");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public void IgnoresUnexpectedNestedJson()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Content:" + s_nl +
                "{ \"error\": { \"error\": { \"code\":\"StatusCode\" }}}" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.SetContent("{ \"error\": { \"error\": { \"code\":\"StatusCode\" }}}");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.Sanitizer = Sanitizer;

            RequestFailedException exception = new RequestFailedException(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        private class TestClientOption : ClientOptions
        {
            public HttpMessageSanitizer Sanitizer => new HttpMessageSanitizer(Diagnostics.LoggedQueryParameters.ToArray(), Diagnostics.LoggedHeaderNames.ToArray());

            public TestClientOption()
            {
                Diagnostics.LoggedHeaderNames.Add("x-ms-requestId");
                Diagnostics.LoggedHeaderNames.Add("Content-Type");
                Diagnostics.LoggedHeaderNames.Add("Custom-Header");
                Diagnostics.LoggedHeaderNames.Add("x-ms-requestId");
                Diagnostics.LoggedHeaderNames.Add("Headers");
            }
        }

        private Stream GetStream(bool isSeekable, string content)
        {
            MemoryStream _stream = new();
            var bytes = Encoding.UTF8.GetBytes(content);
            _stream.Write(bytes, 0, bytes.Length);
            _stream.Position = 0;

            return isSeekable switch
            {
                true => _stream,
                false => new UnSeekableStream(_stream)
            };
        }
        private class UnSeekableStream : Stream
        {
            private readonly MemoryStream _stream;
            public UnSeekableStream(MemoryStream stream)
            {
                _stream = stream;
            }

            public override bool CanRead => _stream.CanRead;

            public override bool CanSeek => false;

            public override bool CanTimeout => _stream.CanTimeout;

            public override bool CanWrite => _stream.CanWrite;

            public override long Length => _stream.Length;

            public override long Position { get => _stream.Position; set => _stream.Position = value; }
            public override int ReadTimeout { get => _stream.ReadTimeout; set => _stream.ReadTimeout = value; }
            public override int WriteTimeout { get => _stream.WriteTimeout; set => _stream.WriteTimeout = value; }

            public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
            {
                return _stream.BeginRead(buffer, offset, count, callback, state);
            }

            public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
            {
                return _stream.BeginWrite(buffer, offset, count, callback, state);
            }

            public override void Close()
            {
                _stream.Close();
            }

            public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
            {
                return _stream.CopyToAsync(destination, bufferSize, cancellationToken);
            }

#if NETFRAMEWORK
            public override ObjRef CreateObjRef(Type requestedType)
            {
                return _stream.CreateObjRef(requestedType);
            }
#endif

            public override int EndRead(IAsyncResult asyncResult)
            {
                return _stream.EndRead(asyncResult);
            }

            public override void EndWrite(IAsyncResult asyncResult)
            {
                _stream.EndWrite(asyncResult);
            }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override bool Equals(object obj)
            {
                return _stream.Equals(obj);
            }

            public override Task FlushAsync(CancellationToken cancellationToken)
            {
                return _stream.FlushAsync(cancellationToken);
            }

            public override int GetHashCode()
            {
                return _stream.GetHashCode();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }

            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                return _stream.ReadAsync(buffer, offset, count, cancellationToken);
            }

            public override int ReadByte()
            {
                return _stream.ReadByte();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override string ToString()
            {
                return _stream.ToString();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                _stream.Write(buffer, offset, count);
            }

            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                return _stream.WriteAsync(buffer, offset, count, cancellationToken);
            }

            public override void WriteByte(byte value)
            {
                _stream.WriteByte(value);
            }
        }

        private class CustomParser : RequestFailedDetailsParser
        {
            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                DefaultRequestFailedDetailsParser.TryParseDetails(response, out error, out data);
                data = response.Content.ToObjectFromJson<IDictionary<string, string>>();
                return true;
            }
        }
    }
}
