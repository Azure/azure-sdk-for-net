// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Moq;

namespace Azure.Storage.Tests;

public static class TestStreams
{
    public static void MakeUnseekable<TStream>(this Mock<TStream> mock) where TStream : Stream
        => mock.HideStreamFunctionality(true, true, true);

    public static void HideStreamFunctionality<TStream>(
        this Mock<TStream> mock,
        bool hideCanSeek = false,
        bool hideLength = false,
        bool hidePosition = false)
        where TStream : Stream
    {
        if (hideCanSeek)
        {
            mock.SetupGet(s => s.CanSeek).Returns(false);
            mock.Setup(s => s.Seek(It.IsAny<long>(), It.IsAny<SeekOrigin>())).Throws(new NotSupportedException());
            mock.SetupSet(s => s.Position = It.IsAny<long>()).Throws(new NotSupportedException());
        }
        if (hideLength)
        {
            mock.SetupGet(s => s.Length).Throws(new NotSupportedException());
            mock.Setup(s => s.SetLength(It.IsAny<long>())).Throws(new NotSupportedException());
        }
        if (hidePosition)
        {
            mock.SetupGet(s => s.Position).Throws(new NotSupportedException());
        }
    }
}
