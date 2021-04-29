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

        /// <summary>The set of bytes expected to be present at the start of BMP files.</summary>
        private static byte[] BmpHeader = new byte[] { 0x42, 0x4D };

        /// <summary>
        /// Attemps to detect the <see cref="FormContentType"/> of a stream of bytes. The algorithm searches through
        /// the first set of bytes in the stream and compares it to well-known file signatures.
        /// </summary>
        /// <param name="stream">The stream to which the content type detection attempt will be performed.</param>
        /// <param name="contentType">If the detection is successful, outputs the detected content type. Otherwise, <c>default</c>.</param>
        /// <returns><c>true</c> if the detection was successful. Otherwise, <c>false</c>.</returns>
        /// <exception cref="NotSupportedException">Thrown when <paramref name="stream"/> is not seekable or readable.</exception>
        public static bool TryGetContentType(this Stream stream, out FormContentType contentType)
        {
            if (stream.BeginsWithHeader(PdfHeader))
            {
                contentType = FormContentType.Pdf;
            }
            else if (stream.BeginsWithHeader(PngHeader))
            {
                contentType = FormContentType.Png;
            }
            else if (stream.BeginsWithHeader(JpegHeader))
            {
                contentType = FormContentType.Jpeg;
            }
            else if (stream.BeginsWithHeader(TiffLeHeader) || stream.BeginsWithHeader(TiffBeHeader))
            {
                contentType = FormContentType.Tiff;
            }
            else if (stream.BeginsWithHeader(BmpHeader))
            {
                contentType = FormContentType.Bmp;
            }
            else
            {
                contentType = default;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether a stream begins with a specified sequence of bytes.
        /// </summary>
        /// <param name="stream">The stream to be verified.</param>
        /// <param name="header">The sequence of bytes expected to be at the start of <paramref name="stream"/>.</param>
        /// <returns><c>true</c> if the <paramref name="stream"/> begins with the specified <paramref name="header"/>. Otherwise, <c>false</c>.</returns>
        private static bool BeginsWithHeader(this Stream stream, byte[] header)
        {
            var originalPosition = stream.Position;

            if (stream.Length - originalPosition < header.Length)
            {
                return false;
            }

            foreach (var headerByte in header)
            {
                var streamByte = (byte)stream.ReadByte();

                if (streamByte != headerByte)
                {
                    stream.Position = originalPosition;
                    return false;
                }
            }

            stream.Position = originalPosition;
            return true;
        }
    }
}
