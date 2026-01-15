// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="StreamExtensions"/> class.
    /// </summary>
    public class StreamExtensionsTests
    {
        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsPdf()
        {
            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoicePdf);

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Pdf));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsPng()
        {
            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptPng);

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Png));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsJpeg()
        {
            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Jpeg));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsBmp()
        {
            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.BusinessCardtBmp);

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Bmp));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsLittleEndianTiff()
        {
            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.InvoiceLeTiff);

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Tiff));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDetectsBigEndianTiff()
        {
            // Currently there are no big-endian TIFF files available in the test assets, so
            // we'll simulate one in a MemoryStream. These files start with the "MM\0*" header
            // in ASCII encoding.

            using var stream = new MemoryStream(Encoding.ASCII.GetBytes("MM\0*I am a completely normal TIFF file. Trust me."));

            Assert.That(stream.TryGetContentType(out var contentType), Is.True);
            Assert.That(contentType, Is.EqualTo(FormContentType.Tiff));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeCannotDetectUnknownType()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("I am probably unknown."));

            Assert.That(stream.TryGetContentType(out var contentType), Is.False);
            Assert.That(contentType, Is.EqualTo(default(FormContentType)));
        }

        /// <summary>
        /// Verifies functionality of the <see cref="StreamExtensions.TryGetContentType"/> method.
        /// </summary>
        [Test]
        public void TryGetContentTypeDoesNotThrowForEmptyStream()
        {
            using var stream = new MemoryStream(Array.Empty<byte>());

            Assert.That(stream.TryGetContentType(out var contentType), Is.False);
            Assert.That(contentType, Is.EqualTo(default(FormContentType)));
        }
    }
}
