// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Core
{
    internal class FormUrlEncodedContent : RequestContent
    {
        private List<KeyValuePair<string, string>> _values = new List<KeyValuePair<string, string>>();
        private Encoding Latin1 = Encoding.GetEncoding("iso-8859-1");
        private byte[] _bytes = Array.Empty<byte>();

        public void Add (string parameter, string value)
        {
            _values.Add(new KeyValuePair<string, string> (parameter, value));
        }

        private void BuildIfNeeded ()
        {
            if (_bytes.Length == 0)
            {
                _bytes = GetContentByteArray(_values);
                _values.Clear();
            }
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            BuildIfNeeded ();
#if NET6_0_OR_GREATER
            await stream.WriteAsync(_bytes.AsMemory(), cancellation).ConfigureAwait(false);
#else
            await stream.WriteAsync(_bytes, 0, _bytes.Length, cancellation).ConfigureAwait(false);
#endif
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            BuildIfNeeded ();
#if NET6_0_OR_GREATER
            stream.Write(_bytes.AsSpan());
#else
            stream.Write(_bytes, 0, _bytes.Length);
#endif
        }

        public override bool TryComputeLength(out long length)
        {
            BuildIfNeeded ();
            length = _bytes.Length;
            return true;
        }

        public override void Dispose()
        {
        }

        // Taken with love from https://github.com/dotnet/runtime/blob/master/src/libraries/System.Net.Http/src/System/Net/Http/FormUrlEncodedContent.cs#L21-L53
        private byte[] GetContentByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException(nameof(nameValueCollection));
            }

            // Encode and concatenate data
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in nameValueCollection)
            {
                if (builder.Length > 0)
                {
                    builder.Append('&');
                }

                builder.Append(Encode(pair.Key));
                builder.Append('=');
                builder.Append(Encode(pair.Value));
            }

            return Latin1.GetBytes(builder.ToString());
        }

        private static string Encode(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            // Escape spaces as '+'.
            return Uri.EscapeDataString(data).Replace("%20", "+");
        }
    }
}
