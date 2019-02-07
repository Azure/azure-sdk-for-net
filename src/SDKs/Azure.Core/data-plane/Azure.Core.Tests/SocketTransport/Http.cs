// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Buffers;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Net.Http;
using System.Text;

namespace Azure.Core.Http
{
    // TODO (pri 3): use real HTTP Parser (but it's in corfxlab)
    internal static class Http
    {
        #region string table
        static readonly byte[] s_http11 = Encoding.ASCII.GetBytes("HTTP/1.1 ");
        static readonly byte[] s_http11CrLf = Encoding.ASCII.GetBytes(" HTTP/1.1 \r\n");
        static readonly byte[] s_crlf = new byte[] { 13, 10 };
        static readonly byte[] s_endOfHeaders = new byte[] { 13, 10, 13, 10 };

        static readonly byte[] s_get = Encoding.ASCII.GetBytes("GET ");
        static readonly byte[] s_post = Encoding.ASCII.GetBytes("POST ");

        static readonly byte s_headerSeparator = (byte)':';
        #endregion

        public static ReadOnlySpan<byte> CRLF => s_crlf;

        public static OperationStatus ParseResponse(Sequence<byte> bytes, out int statusCode, out int headersStart, out int contentStart)
        {
            if (!bytes.IsSingleSegment) throw new NotImplementedException();
            var ros = bytes.AsReadOnly();

            statusCode = default;
            headersStart = default;
            contentStart = default;

            var first = ros.First.Span;
            int eoh = first.IndexOf(s_endOfHeaders);
            if(eoh == -1) return OperationStatus.NeedMoreData;

            if (!first.StartsWith(s_http11)) return OperationStatus.InvalidData;

            var statusBuffer = first.Slice(s_http11.Length);
            if (!Utf8Parser.TryParse(statusBuffer, out statusCode, out int consumed)) return OperationStatus.InvalidData;

            headersStart = first.IndexOf(s_crlf) + s_crlf.Length;
            if (headersStart == -1) return OperationStatus.InvalidData;

            contentStart = eoh + s_endOfHeaders.Length;

            return OperationStatus.Done;
        }

        internal static void WriteRequestLine(ref Sequence<byte> buffer, string protocol, PipelineMethod method, ReadOnlySpan<byte> path)
        {
            if (protocol != "https") throw new NotImplementedException();

            var segment = buffer.GetMemory().Span;
            int written = 0;
            if (method == PipelineMethod.Get)
            {
                s_get.CopyTo(segment);
                written = s_get.Length;
            }
            else if (method == PipelineMethod.Post)
            {
                s_post.CopyTo(segment);
                written = s_post.Length;
            }

            path.CopyTo(segment.Slice(written));
            written += path.Length;

            s_http11CrLf.CopyTo(segment.Slice(written));
            written += s_http11CrLf.Length;

            buffer.Advance(written);
        }

        public static void WriteHeader(ref Sequence<byte> buffer, ReadOnlySpan<byte> headerName, ReadOnlySpan<byte> headerValue)
        {
            var segment = buffer.GetMemory().Span;
            int written = 0;

            headerName.CopyTo(segment);
            written += headerName.Length;

            segment.Slice(written)[0] = s_headerSeparator;
            written += 1;

            headerValue.CopyTo(segment.Slice(written));
            written += headerValue.Length;

            s_crlf.CopyTo(segment.Slice(written));
            written += s_crlf.Length;

            buffer.Advance(written);
        }

        public static void WriteHeader(ref Sequence<byte> buffer, ReadOnlySpan<byte> headerName, long headerValue)
        {
            var segment = buffer.GetMemory().Span;
            int written = 0;

            headerName.CopyTo(segment);
            written += headerName.Length;

            segment.Slice(written)[0] = s_headerSeparator;
            written += 1;

            if (!Utf8Formatter.TryFormat(headerValue, segment.Slice(written), out int formatted))
            {
                throw new NotImplementedException("resise buffer");
            }
            written += formatted;

            s_crlf.CopyTo(segment.Slice(written));
            written += s_crlf.Length;
        }
    }
}
