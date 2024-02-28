// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Shared;
using static Azure.Storage.Shared.StructuredMessage;

namespace Azure.Storage.Blobs.Tests
{
    internal class StructuredMessageHelper
    {
        public static byte[] MakeEncodedData(ReadOnlySpan<byte> data, long segmentContentLength, Flags flags)
        {
            int segmentCount = (int) Math.Ceiling(data.Length / (double)segmentContentLength);
            int segmentFooterLen = flags.HasFlag(Flags.StorageCrc64) ? 8 : 0;
            int streamFooterLen = flags.HasFlag(Flags.StorageCrc64) ? 8 : 0;

            byte[] encodedData = new byte[
                V1_0.StreamHeaderLength +
                segmentCount*(V1_0.SegmentHeaderLength + segmentFooterLen) +
                streamFooterLen +
                data.Length];
            V1_0.WriteStreamHeader(
                new Span<byte>(encodedData, 0, V1_0.StreamHeaderLength),
                encodedData.Length,
                flags,
                segmentCount);

            int i = V1_0.StreamHeaderLength;
            int j = 0;
            foreach (int seg in Enumerable.Range(1, segmentCount))
            {
                int segContentLen = Math.Min((int)segmentContentLength, data.Length - j);
                V1_0.WriteSegmentHeader(
                    new Span<byte>(encodedData, i, V1_0.SegmentHeaderLength),
                    seg,
                    segContentLen);
                i += V1_0.SegmentHeaderLength;

                data.Slice(j, segContentLen)
                    .CopyTo(new Span<byte>(encodedData).Slice(i));
                i += segContentLen;

                if (flags.HasFlag(Flags.StorageCrc64))
                {
                    var crc = StorageCrc64HashAlgorithm.Create();
                    crc.Append(data.Slice(j, segContentLen));
                    crc.GetCurrentHash(new Span<byte>(encodedData, i, Crc64Length));
                    i += Crc64Length;
                }
                j += segContentLen;
            }

            if (flags.HasFlag(Flags.StorageCrc64))
            {
                var crc = StorageCrc64HashAlgorithm.Create();
                crc.Append(data);
                crc.GetCurrentHash(new Span<byte>(encodedData, i, Crc64Length));
            }

            return encodedData;
        }
    }
}
