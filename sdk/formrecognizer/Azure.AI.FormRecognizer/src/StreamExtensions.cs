// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    internal static class StreamExtensions
    {
        /// <summary></summary>
        private static byte[] PdfHeader = new byte[] { 0x25, 0x50, 0x44, 0x46 };

        /// <summary></summary>
        private static byte[] PngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47 };

        /// <summary></summary>
        private static byte[] JpegHeader = new byte[] { 0xff, 0xd8 };

        /// <summary></summary>
        private static byte[] TiffLeHeader = new byte[] { 0x49, 0x49, 0x2A, 0x00 };

        /// <summary></summary>
        private static byte[] TiffBeHeader = new byte[] { 0x4D, 0x4D, 0x00, 0x2A };

        public static bool TryGetContentType(this Stream stream, out ContentType contentType)
        {
            var originalPosition = stream.Position;
            var bytesCount = Math.Min(stream.Length, PdfHeader.Length);

            bool hasFoundType = false;
            contentType = default;

            bool couldBePdf = true;
            bool couldBePng = true;
            bool couldBeJpeg = true;
            bool couldBeTiffLe = true;
            bool couldBeTiffBe = true;

            Func<byte[], int, bool> isAtEnd = (array, index) => index == array.Length - 1;
            Func<byte[], int, byte, bool> hasByteAt = (array, index, expected) => index < array.Length && array[index] == expected;

            for (int i = 0; i < bytesCount; i++)
            {
                byte currentByte = (byte)stream.ReadByte();

                couldBePdf = couldBePdf && hasByteAt(PdfHeader, i, currentByte);
                if (couldBePdf && isAtEnd(PdfHeader, i))
                {
                    contentType = ContentType.Pdf;
                    hasFoundType = true;
                    break;
                }

                couldBePng = couldBePng && hasByteAt(PngHeader, i, currentByte);
                if (couldBePng && isAtEnd(PngHeader, i))
                {
                    contentType = ContentType.Png;
                    hasFoundType = true;
                    break;
                }

                couldBeJpeg = couldBeJpeg && hasByteAt(JpegHeader, i, currentByte);
                if (couldBeJpeg && isAtEnd(JpegHeader, i))
                {
                    contentType = ContentType.Jpeg;
                    hasFoundType = true;
                    break;
                }

                couldBeTiffLe = couldBeTiffLe && hasByteAt(TiffLeHeader, i, currentByte);
                if (couldBeTiffLe && isAtEnd(TiffLeHeader, i))
                {
                    contentType = ContentType.Tiff;
                    hasFoundType = true;
                    break;
                }

                couldBeTiffBe = couldBeTiffBe && hasByteAt(TiffBeHeader, i, currentByte);
                if (couldBeTiffBe && isAtEnd(TiffBeHeader, i))
                {
                    contentType = ContentType.Tiff;
                    hasFoundType = true;
                    break;
                }
            }

            stream.Position = originalPosition;

            return hasFoundType;
        }
    }
}
