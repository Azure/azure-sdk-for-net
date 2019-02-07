// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Http;
using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.IO;
using System.Text;
using static System.Buffers.Text.Encodings;

namespace Azure.Core
{
    public readonly struct Response
    {
        readonly HttpMessage _message;

        public Response(HttpMessage message)
            => _message = message;

        public int Status => _message.Status;

        public Stream ContentStream => _message.ResponseContentStream;

        public bool TryGetHeader(ReadOnlySpan<byte> name, out long value)
        {
            value = default;
            if (!TryGetHeader(name, out ReadOnlySpan<byte> bytes)) return false;
            if (!Utf8Parser.TryParse(bytes, out value, out int consumed) || consumed != bytes.Length)
                throw new Exception("bad content-length value");
            return true;
        }

        public bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            => _message.TryGetHeader(name, out value);

        public bool TryGetHeader(ReadOnlySpan<byte> name, out string value)
        {
            if (TryGetHeader(name, out ReadOnlySpan<byte> span)) {
                value = Utf8.ToString(span);
                return true;
            }
            value = default;
            return false;
        }

        public bool TryGetHeader(string name, out long value)
        {
            value = default;
            if (!TryGetHeader(name, out string valueString)) return false;
            if (!long.TryParse(valueString, out value))
                throw new Exception("bad content-length value");
            return true;
        }

        public bool TryGetHeader(string name, out string value)
        {
            var utf8Name = Encoding.ASCII.GetBytes(name);
            return TryGetHeader(utf8Name, out value);
        }

        public void Dispose() => _message.Dispose();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            var responseStream = _message.ResponseContentStream;
            if (responseStream.CanSeek) {
                var position = responseStream.Position;
                var reader = new StreamReader(responseStream);
                var result = $"{Status} {reader.ReadToEnd()}";
                responseStream.Seek(position, SeekOrigin.Begin);
                return result;
            }

            return $"Status : {Status.ToString()}";
        }
    }

    public struct Response<T> : IDisposable
    {
        Response _response;
        Func<Response, T> _contentParser;
        T _parsedContent;

        public Response(Response response)
        {
            _response = response;
            _contentParser = null;
            _parsedContent = default;
        }

        public Response(Response response, Func<Response, T> parser)
        {
            _response = response;
            _contentParser = parser;
            _parsedContent = default;
        }

        public Response(Response response, T parsed)
        {
            _response = response;
            _contentParser = null;
            _parsedContent = parsed;
        }

        public void Deconstruct(out T result, out Response response)
        {
            result = Result;
            response = _response;
        }

        public static implicit operator T(Response<T> response)
            => response.Result;


        public T Result
        {
            get {
                if (_contentParser != null) {
                    _parsedContent = _contentParser(_response);
                    _contentParser = null;
                }
                return _parsedContent;
            }
        }

        public int Status => _response.Status;

        public void Dispose()
        {
            _response.Dispose();
            _contentParser = default;
        }

        public bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            => _response.TryGetHeader(name, out value);

        public bool TryGetHeader(ReadOnlySpan<byte> name, out long value)
            => _response.TryGetHeader(name, out value);

        public bool TryGetHeader(string name, out string value)
        {
            if (_response.TryGetHeader(Encoding.ASCII.GetBytes(name), out ReadOnlySpan<byte> valueUtf8))
            {
                value = Encoding.ASCII.GetString(valueUtf8.ToArray());
                return true;
            }
            value = default;
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
