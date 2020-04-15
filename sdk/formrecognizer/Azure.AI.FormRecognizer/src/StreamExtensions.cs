// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    internal static class StreamExtensions
    {
        /// <summary>The set of bytes expected to be present at the start of PDF files.</summary>
        private static byte[] PdfHeader = new byte[] { 0x25, 0x50, 0x44, 0x46 };

        /// <summary>The set of bytes expected to be present at the start of PNG files.</summary>
        private static byte[] PngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47 };

        /// <summary>The set of bytes expected to be present at the start of JPEG files.</summary>
        private static byte[] JpegHeader = new byte[] { 0xFF, 0xD8 };

        /// <summary>The set of bytes expected to be present at the start of TIFF (little-endian) files.</summary>
        private static byte[] TiffLeHeader = new byte[] { 0x49, 0x49, 0x2A, 0x00 };

        /// <summary>The set of bytes expected to be present at the start of TIFF (big-endian) files.</summary>
        private static byte[] TiffBeHeader = new byte[] { 0x4D, 0x4D, 0x00, 0x2A };

        /// <summary>
        /// Attemps to detect the <see cref="ContentType"/> of a stream of bytes. The algorithm searches through
        /// the first set of bytes in the stream and compares it to well-known file signatures.
        /// </summary>
        /// <param name="stream">The stream to which the content type detection attempt will be performed.</param>
        /// <param name="contentType">If the detection is successful, outputs the detected content type. Otherwise, <c>default</c>.</param>
        /// <returns><c>true</c> if the detection was successful. Otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">Happens when <paramref name="stream"/> is not seekable or readable.</exception>
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
