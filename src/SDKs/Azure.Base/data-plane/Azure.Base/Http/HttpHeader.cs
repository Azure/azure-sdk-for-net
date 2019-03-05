// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Buffers;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Azure.Base.Http
{
    public readonly struct HttpHeader : IEquatable<HttpHeader>
    {
        readonly byte[] _utf8;

        public HttpHeader(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value)
        {
            int length = name.Length + value.Length + 3;
            _utf8 = new byte[length];
            var span = _utf8.AsSpan();
            name.CopyTo(_utf8);
            _utf8[name.Length] = (byte)':';
            value.CopyTo(span.Slice(name.Length + 1));
            _utf8[length - 2] = (byte)'\r';
            _utf8[length - 1] = (byte)'\n';
        }

        public HttpHeader(ReadOnlySpan<byte> name, string value)
        {
            int length = name.Length + value.Length + 3;
            _utf8 = new byte[length];
            var utf8 = _utf8.AsSpan();

            name.CopyTo(_utf8);
            _utf8[name.Length] = (byte)':';

            utf8 = utf8.Slice(name.Length + 1);
            if (!Transcoder.TryUtf16ToAscii(value.AsSpan(), utf8, out _))
            {
                throw new Exception("value is not ASCII");
            }
            _utf8[length - 2] = (byte)'\r';
            _utf8[length - 1] = (byte)'\n';
        }

        public HttpHeader(string name, string value)
        {
            int length = name.Length + value.Length + 3;
            _utf8 = new byte[length];
            var utf8 = _utf8.AsSpan();

            if (!Transcoder.TryUtf16ToAscii(name.AsSpan(), utf8, out int written))
            {
                throw new Exception("name is not ASCII");
            }
            _utf8[written] = (byte)':';
            utf8 = utf8.Slice(written + 1);
            if (!Transcoder.TryUtf16ToAscii(value.AsSpan(), utf8, out written))
            {
                throw new Exception("name or value is not ASCII");
            }
            _utf8[length - 2] = (byte)'\r';
            _utf8[length - 1] = (byte)'\n';
        }

        internal HttpHeader(byte[] full) => _utf8 = full;

        public ReadOnlySpan<byte> Value
        {
            get
            {
                var span = _utf8.AsSpan();
                var index = span.IndexOf((byte)':');
                while (span[index] == ' ') index++;
                return span.Slice(index + 1, span.Length - index - 3);
            }
        }

        public ReadOnlySpan<byte> Name
        {
            get
            {
                var span = _utf8.AsSpan();
                var index = span.IndexOf((byte)':');
                while (span[index] == ' ') index--;
                return span.Slice(0, index);
            }
        }

        public override string ToString() => Transcoder.AsciiToString(_utf8.AsSpan(0, _utf8.Length - 2));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TryWrite(Span<byte> buffer, out int written, StandardFormat format = default)
        {
            if (!format.IsDefault) throw new NotSupportedException("format not supported");
            written = 0;
            var utf8 = _utf8.AsSpan();
            if (!utf8.TryCopyTo(buffer)) return false;
            written += utf8.Length;
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is HttpHeader header)
            {
                return Equals(header);
            }
            return false;
        }

        public bool Equals(HttpHeader other)
            => _utf8.AsSpan().SequenceEqual(other._utf8);

        public static class Constants
        {
            static readonly byte[] s_host = Encoding.ASCII.GetBytes("Host");
            public static ReadOnlySpan<byte> Host => s_host;

            static readonly byte[] s_transferEncoding = Encoding.ASCII.GetBytes("Transfer-Encoding");
            public static ReadOnlySpan<byte> TransferEncoding => s_transferEncoding;

            static readonly byte[] s_contentLength = Encoding.ASCII.GetBytes("Content-Length");
            public static ReadOnlySpan<byte> ContentLength => s_contentLength;

            static readonly byte[] s_contentType = Encoding.ASCII.GetBytes("Content-Type");
            public static ReadOnlySpan<byte> ContentType => s_contentType;

            static readonly byte[] s_applicationJson = Encoding.ASCII.GetBytes("application/json");
            public static ReadOnlySpan<byte> ApplicationJson => s_applicationJson;

            static readonly byte[] s_applicationOctetStream = Encoding.ASCII.GetBytes("application/octet-stream");
            public static ReadOnlySpan<byte> ApplicationOctetStream => s_applicationOctetStream;

            static readonly byte[] s_userAgent = Encoding.ASCII.GetBytes("User-Agent");
            public static ReadOnlySpan<byte> UserAgent => s_userAgent;

            static readonly byte[] s_accept = Encoding.ASCII.GetBytes("Accept");
            public static ReadOnlySpan<byte> Accept => s_accept;

        }

        public static class Common
        {
            public static readonly HttpHeader JsonContentType = new HttpHeader(Constants.ContentType, Constants.ApplicationJson);
            public static readonly HttpHeader OctetStreamContentType = new HttpHeader(Constants.ContentType, Constants.ApplicationOctetStream);

            static readonly string PlatfromInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";

            public static HttpHeader CreateUserAgent(string sdkName, string sdkVersion, string applicationId = default)
            {
                byte[] utf8 = null;
                if (applicationId == default) utf8 = Encoding.ASCII.GetBytes($"User-Agent:{sdkName}/{sdkVersion} {PlatfromInformation}\r\n");
                else utf8 = Encoding.ASCII.GetBytes($"User-Agent:{applicationId} {sdkName}/{sdkVersion} {PlatfromInformation}\r\n");
                return new HttpHeader(utf8);
            }

            public static HttpHeader CreateContentLength(long length)
            {
                byte[] utf8 = Encoding.ASCII.GetBytes($"Content-Length:{length}\r\n");
                return new HttpHeader(utf8);
            }

            public static HttpHeader CreateHost(ReadOnlySpan<byte> hostName)
            {
                var buffer = new byte[Constants.Host.Length + hostName.Length + 3];
                Constants.Host.CopyTo(buffer);
                buffer[Constants.Host.Length] = (byte)':';
                hostName.CopyTo(buffer.AsSpan(Constants.Host.Length + 1));
                buffer[buffer.Length - 1] = (byte)'\n';
                buffer[buffer.Length - 2] = (byte)'\r';
                return new HttpHeader(buffer);
            }
        }
    }
}
