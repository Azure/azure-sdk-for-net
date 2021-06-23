// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Azure.Core
{
    /// <summary>
    /// Low level library for building JWT
    /// </summary>
    internal class JwtBuilder : IDisposable
    {
        // this is the standrd JWT header. { "alg": "HS256", "typ": "JWT" }
        private static readonly byte[] headerSha256 = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.");
        //private static readonly byte[] headerSha256 = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsImtpZCI6IjgyMTcyMDE3Njk5YzRkNWRhMzhkZTg3NWFiYjEwZDc5IiwidHlwIjoiSldUIn0");

        private Utf8JsonWriter _writer;
        private MemoryStream _memoryStream;
        private byte[] _key;
        private bool isDisposed;

        private byte[] _jwt;
        private int _jwtLength;

        public JwtBuilder(byte[] key, int size = 512)
        { // typical JWT is ~300B UTF8
            _jwt = null;
            _memoryStream = new MemoryStream(size);
            _memoryStream.Write(headerSha256, 0, headerSha256.Length);
            _writer = new Utf8JsonWriter(_memoryStream);
            _writer.WriteStartObject();
            _key = key;
        }

        public void AddClaim(ReadOnlySpan<byte> utf8Name, string value) => _writer.WriteString(utf8Name, value);
        public void AddClaim(ReadOnlySpan<byte> utf8Name, bool value) => _writer.WriteBoolean(utf8Name, value);
        public void AddClaim(ReadOnlySpan<byte> utf8Name, long value) => _writer.WriteNumber(utf8Name, value);
        public void AddClaim(ReadOnlySpan<byte> utf8Name, double value) => _writer.WriteNumber(utf8Name, value);

        public void AddClaim(ReadOnlySpan<byte> utf8Name, DateTimeOffset value)
        {
            AddClaim(utf8Name, value.ToUnixTimeSeconds());
        }

        public void AddClaim(string name, string value) => _writer.WriteString(name, value);
        public void AddClaim(string name, bool value) => _writer.WriteBoolean(name, value);
        public void AddClaim(string name, long value) => _writer.WriteNumber(name, value);
        public void AddClaim(string name, double value) => _writer.WriteNumber(name, value);

        public void AddClaim(string name, DateTimeOffset value)
        {
            AddClaim(name, value.ToUnixTimeSeconds());
        }

        /// <summary>
        /// Returns number of ASCII characters of the JTW. The actual token can be retrieved using Build or WriteTo
        /// </summary>
        /// <returns></returns>
        public int End()
        {
            if (_writer == null)
            {
                return _jwtLength;
            }
            if (isDisposed)
                throw new ObjectDisposedException(nameof(JwtBuilder));

            _writer.WriteEndObject();
            _writer.Flush();

            // this should never happen. If there are too many claims, MmoryStream.Write would fail first
            // And so this is more like a RELEASE assert.
            // TODO: change to assert?
            if (_writer.BytesCommitted > int.MaxValue)
                throw new InvalidOperationException("too many claims");

            int payloadLength = (int)_writer.BytesCommitted;
            int payloadIndex = headerSha256.Length;
            int maxBufferLength =
                Base64.GetMaxEncodedToUtf8Length(headerSha256.Length + payloadLength)
                + 1 // dot
                + Base64.GetMaxEncodedToUtf8Length(32); // signature SHA256 hash size
            _memoryStream.Capacity = maxBufferLength; // make room for in-place Base64 conversion

            _jwt = _memoryStream.GetBuffer();
            _writer = null; // this will prevent subsequent addition of claims.

            Span<byte> toEncode = _jwt.AsSpan(payloadIndex);
            OperationStatus status = NS2Bridge.Base64UrlEncodeInPlace(toEncode, payloadLength, out int payloadWritten);
            if (status != OperationStatus.Done)
                throw new NotImplementedException("this should not happen as buffer was adjusted above"); // TODO: change to assert?

            // Add signature
            int headerAndPayloadLength = payloadWritten + headerSha256.Length;
            _jwt[headerAndPayloadLength] = (byte)'.';
            int headerAndPayloadAndSeparatorLength = headerAndPayloadLength + 1;
            using (HMACSHA256 hash = new HMACSHA256(_key))
            {
                var hashed = hash.ComputeHash(_jwt, 0, headerAndPayloadLength);
                status = NS2Bridge.Base64UrlEncode(hashed, _jwt.AsSpan(headerAndPayloadAndSeparatorLength), out int consumend, out int signatureLength);
                if (status != OperationStatus.Done)
                    throw new NotImplementedException();
                _jwtLength = headerAndPayloadAndSeparatorLength + signatureLength;
            }

            return _jwtLength;
        }

        public bool TryWriteTo(Span<char> destination, out int charsWritten)
        {
            End();
            if (destination.Length < _jwtLength)
            {
                charsWritten = 0;
                return false;
            }
            NS2Bridge.Latin1ToUtf16(_jwt.AsSpan(0, _jwtLength), destination);
            charsWritten = _jwtLength;
            return true;
        }

        public string Build()
        {
            End();
            var result = NS2Bridge.CreateString(_jwtLength, _jwt, (destination, state) => {
                NS2Bridge.Latin1ToUtf16(state.AsSpan(0, _jwtLength), destination);
            });
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (_memoryStream != null)
                        _memoryStream.Dispose();
                    if (_writer != null)
                        _writer.Dispose();
                }

                _memoryStream = null;
                _writer = null;
                _key = null;
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}
