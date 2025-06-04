// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Moq;

using static Moq.It;

namespace Azure.Storage
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class MockExtensions
    {
        /// <summary>
        /// Sets up baseline behavior for mocking a stream. Includes basic descriptor properties
        /// as well as setting up appropriate throws based on those values.
        /// </summary>
        /// <param name="stream">Stream mock to setup.</param>
        /// <param name="canRead"></param>
        /// <param name="canWrite"></param>
        /// <param name="canSeek"></param>
        public static void BasicSetup(this Mock<Stream> stream, bool canRead, bool canWrite, bool canSeek)
        {
            stream.SetupGet(s => s.CanRead).Returns(canRead);
            stream.SetupGet(s => s.CanWrite).Returns(canWrite);
            stream.SetupGet(s => s.CanSeek).Returns(canSeek);

            if (!canRead)
            {
                stream.Setup(s => s.Read(IsAny<byte[]>(), IsAny<int>(), IsAny<int>()))
                    .Throws<NotSupportedException>();
                stream.Setup(s => s.ReadAsync(IsAny<byte[]>(), IsAny<int>(), IsAny<int>(), IsAny<CancellationToken>()))
                    .Throws<NotSupportedException>();
            }

            if (!canWrite)
            {
                stream.Setup(s => s.Write(IsAny<byte[]>(), IsAny<int>(), IsAny<int>()))
                    .Throws<NotSupportedException>();
                stream.Setup(s => s.WriteAsync(IsAny<byte[]>(), IsAny<int>(), IsAny<int>(), IsAny<CancellationToken>()))
                    .Throws<NotSupportedException>();
            }

            if (!canSeek)
            {
                stream.SetupGet(s => s.Length)
                    .Throws<NotSupportedException>();
                stream.SetupGet(s => s.Position)
                    .Throws<NotSupportedException>();
                stream.SetupSet<long>(s => s.Position = default)
                    .Throws<NotSupportedException>();
                stream.Setup(s => s.Seek(IsAny<long>(), IsAny<SeekOrigin>()))
                    .Throws<NotSupportedException>();
            }
        }

        public static void VerifyDisposal<T>(this Mock<T> mock)
            where T : class, IDisposable
        {
            mock.Verify(m => m.Dispose(), Times.Once);
        }

        public static void VerifyAsyncDisposal<T>(this Mock<T> mock)
            where T : class, IAsyncDisposable
        {
            mock.Verify(m => m.DisposeAsync(), Times.Once);
        }
    }
}
