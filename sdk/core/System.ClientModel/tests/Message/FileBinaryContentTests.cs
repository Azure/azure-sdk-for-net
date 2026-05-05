// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Message;

internal class FileBinaryContentTests
{
    private static string CreateTempFile(byte[] bytes)
    {
        string path = Path.Combine(Path.GetTempPath(), $"scm-fbc-{Guid.NewGuid():N}.bin");
        File.WriteAllBytes(path, bytes);
        return path;
    }

    [Test]
    public void Construct_FromPath_DoesNotOpenFile()
    {
        // The file does not exist yet — construction must not touch the file system.
        string path = Path.Combine(Path.GetTempPath(), $"scm-fbc-missing-{Guid.NewGuid():N}.bin");

        using var content = new FileBinaryContent(path);

        Assert.AreEqual(Path.GetFileName(path), content.Filename);
        Assert.AreEqual("application/octet-stream", content.MediaType);
        Assert.IsFalse(File.Exists(path));
    }

    [Test]
    public void Dispose_BeforeAnyUse_DoesNotOpenFile()
    {
        // Constructing then disposing without ever writing must never have
        // opened a file handle.
        string path = Path.Combine(Path.GetTempPath(), $"scm-fbc-missing-{Guid.NewGuid():N}.bin");

        var content = new FileBinaryContent(path);
        content.Dispose();

        Assert.IsFalse(File.Exists(path));
    }

    [Test]
    public void Dispose_AfterWrite_ReleasesFileHandle()
    {
        // After WriteTo + Dispose, we must be able to delete the file on Windows,
        // which requires no outstanding handle.
        byte[] bytes = new byte[] { 1, 2, 3, 4, 5 };
        string path = CreateTempFile(bytes);

        try
        {
            var content = new FileBinaryContent(path);
            using (var ms = new MemoryStream())
            {
                content.WriteTo(ms);
                CollectionAssert.AreEqual(bytes, ms.ToArray());
            }
            content.Dispose();

            // Should not throw IOException("file in use").
            File.Delete(path);
            Assert.IsFalse(File.Exists(path));
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    [Test]
    public async Task DisposeAsync_AfterWriteAsync_ReleasesFileHandle()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4, 5 };
        string path = CreateTempFile(bytes);

        try
        {
            var content = new FileBinaryContent(path);
            using (var ms = new MemoryStream())
            {
                await content.WriteToAsync(ms);
                CollectionAssert.AreEqual(bytes, ms.ToArray());
            }
            content.Dispose();

            File.Delete(path);
            Assert.IsFalse(File.Exists(path));
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    [Test]
    public void Dispose_FromStream_DisposesOwnedStream()
    {
        var stream = new MemoryStream(new byte[] { 1, 2, 3 });
        var content = new FileBinaryContent(stream);

        content.Dispose();

        // MemoryStream throws ObjectDisposedException on access after dispose.
        Assert.Throws<ObjectDisposedException>(() => _ = stream.Length);
    }

    [Test]
    public void Dispose_FromBinaryData_DoesNotThrow()
    {
        // BinaryData ctor wraps data.ToStream() (a non-owning view). Dispose
        // must be safe and idempotent.
        var content = new FileBinaryContent(BinaryData.FromBytes(new byte[] { 1, 2, 3 }));

        Assert.DoesNotThrow(() => content.Dispose());
        Assert.DoesNotThrow(() => content.Dispose());
    }

    [Test]
    public void Dispose_IsIdempotent_FromPath()
    {
        byte[] bytes = new byte[] { 1, 2, 3 };
        string path = CreateTempFile(bytes);

        try
        {
            var content = new FileBinaryContent(path);
            using (var ms = new MemoryStream())
            {
                content.WriteTo(ms);
            }

            Assert.DoesNotThrow(() => content.Dispose());
            Assert.DoesNotThrow(() => content.Dispose());

            // Still no leaked handle.
            File.Delete(path);
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    [Test]
    public void TryComputeLength_FromPath_OpensFile_AndDisposeReleasesIt()
    {
        byte[] bytes = new byte[] { 1, 2, 3, 4, 5 };
        string path = CreateTempFile(bytes);

        try
        {
            var content = new FileBinaryContent(path);
            Assert.IsTrue(content.TryComputeLength(out long length));
            Assert.AreEqual(bytes.Length, length);

            content.Dispose();

            // No outstanding handle.
            File.Delete(path);
            Assert.IsFalse(File.Exists(path));
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
