// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
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
        // Registered claims
        private static byte[] s_nbf = Encoding.UTF8.GetBytes("nbf");
        private static byte[] s_exp = Encoding.UTF8.GetBytes("exp");
        private static byte[] s_iat = Encoding.UTF8.GetBytes("iat");
        private static byte[] s_aud = Encoding.UTF8.GetBytes("aud");
        private static byte[] s_sub = Encoding.UTF8.GetBytes("sub");
        private static byte[] s_iss = Encoding.UTF8.GetBytes("iss");
        private static byte[] s_jti = Encoding.UTF8.GetBytes("jti");

        public static ReadOnlySpan<byte> Nbf => s_nbf;
        public static ReadOnlySpan<byte> Exp => s_exp;
        public static ReadOnlySpan<byte> Iat => s_iat;
        public static ReadOnlySpan<byte> Aud => s_aud;
        public static ReadOnlySpan<byte> Sub => s_sub;
        public static ReadOnlySpan<byte> Iss => s_iss;
        public static ReadOnlySpan<byte> Jti => s_jti;

        // this is Base64 encoding of the standard JWT header. { "alg": "HS256", "typ": "JWT" }
        private static readonly byte[] headerSha256 = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.");

        private Utf8JsonWriter _writer;
        private MemoryStream _memoryStream;
        private byte[] _key;
        private bool _isDisposed;

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

        public void AddClaim(ReadOnlySpan<byte> utf8Name, string value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteString(utf8Name, value);
        }
        public void AddClaim(ReadOnlySpan<byte> utf8Name, bool value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteBoolean(utf8Name, value);
        }
        public void AddClaim(ReadOnlySpan<byte> utf8Name, long value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteNumber(utf8Name, value);
        }
        public void AddClaim(ReadOnlySpan<byte> utf8Name, double value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteNumber(utf8Name, value);
        }
        public void AddClaim(ReadOnlySpan<byte> utf8Name, DateTimeOffset value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            AddClaim(utf8Name, value.ToUnixTimeSeconds());
        }
        public void AddClaim(ReadOnlySpan<byte> utf8Name, IEnumerable<string> value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteStartArray(utf8Name);
            foreach (var item in value)
            {
                _writer.WriteStringValue(item);
            }
            _writer.WriteEndArray();
        }

        public void AddClaim(string name, string value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteString(name, value);
        }
        public void AddClaim(string name, bool value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteBoolean(name, value);
        }
        public void AddClaim(string name, long value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteNumber(name, value);
        }
        public void AddClaim(string name, double value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteNumber(name, value);
        }
        public void AddClaim(string name, DateTimeOffset value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            AddClaim(name, value.ToUnixTimeSeconds());
        }
        public void AddClaim(string name, string[] value)
        {
            if (_writer == null)
                throw new InvalidOperationException("Cannot change claims after building. Create a new JwtBuilder instead");
            _writer.WriteStartArray(name);
            foreach (var item in value)
            {
                _writer.WriteStringValue(item);
            }
            _writer.WriteEndArray();
        }

        /// <summary>
        /// Returns number of ASCII characters of the JTW. The actual token can be retrieved using Build or WriteTo
        /// </summary>
        /// <returns></returns>
        public int End()
        {
            if (_writer == null) return _jwtLength; // writer is set to null after token is formatted.
            if (_isDisposed) throw new ObjectDisposedException(nameof(JwtBuilder));

            _writer.WriteEndObject();
            _writer.Flush();

            Debug.Assert(_memoryStream.GetType() == typeof(MemoryStream));
            int payloadLength = (int)_writer.BytesCommitted; // writer is wrrapping MemoryStream, and so the length will never overflow int.

            int payloadIndex = headerSha256.Length;

            int maxBufferLength;
            checked {
                maxBufferLength =
                    Base64.GetMaxEncodedToUtf8Length(headerSha256.Length + payloadLength)
                    + 1 // dot
                    + Base64.GetMaxEncodedToUtf8Length(32); // signature SHA256 hash size
            }
            _memoryStream.Capacity = maxBufferLength; // make room for in-place Base64 conversion

            _jwt = _memoryStream.GetBuffer();
            _writer = null; // this will prevent subsequent additions of claims.

            Span<byte> toEncode = _jwt.AsSpan(payloadIndex);
            OperationStatus status = NS2Bridge.Base64UrlEncodeInPlace(toEncode, payloadLength, out int payloadWritten);
            Debug.Assert(status == OperationStatus.Done); // Buffer is adjusted above, and so encoding should always fit

            // Add signature
            int headerAndPayloadLength = payloadWritten + headerSha256.Length;
            _jwt[headerAndPayloadLength] = (byte)'.';
            int headerAndPayloadAndSeparatorLength = headerAndPayloadLength + 1;
            using (HMACSHA256 hash = new HMACSHA256(_key))
            {
                var hashed = hash.ComputeHash(_jwt, 0, headerAndPayloadLength);
                status = NS2Bridge.Base64UrlEncode(hashed, _jwt.AsSpan(headerAndPayloadAndSeparatorLength), out int consumend, out int signatureLength);
                Debug.Assert(status == OperationStatus.Done); // Buffer is adjusted above, and so encoding should always fit
                _jwtLength = headerAndPayloadAndSeparatorLength + signatureLength;
            }

            return _jwtLength;
        }

        public bool TryBuildTo(Span<char> destination, out int charsWritten)
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

        public string BuildString()
        {
            End();
            var result = NS2Bridge.CreateString(_jwtLength, _jwt, (destination, state) => {
                NS2Bridge.Latin1ToUtf16(state.AsSpan(0, _jwtLength), destination);
            });
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
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
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}
