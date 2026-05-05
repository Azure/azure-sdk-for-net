// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Message;

internal class MultiPartFormContentTests
{
    private static string CreateTempFile(byte[] bytes)
    {
        string path = Path.Combine(Path.GetTempPath(), $"scm-mp-{Guid.NewGuid():N}.bin");
        File.WriteAllBytes(path, bytes);
        return path;
    }

    [Test]
    public async Task Dispose_ReleasesFileHandlesOfFileParts()
    {
        // After WriteToAsync forces the lazy file open, disposing the multipart
        // content must dispose every part — including the underlying FileStream
        // owned by FileBinaryContent — so the file can be deleted.
        byte[] bytes = new byte[] { 1, 2, 3, 4, 5 };
        string path1 = CreateTempFile(bytes);
        string path2 = CreateTempFile(bytes);

        try
        {
            var multipart = new MultiPartFormContent();
            multipart.Add("file1", new FileBinaryContent(path1));
            multipart.Add("file2", new FileBinaryContent(path2));

            await multipart.WriteToAsync(Stream.Null);
            multipart.Dispose();

            // Both files must be deletable — would throw IOException on Windows
            // if a handle were leaked.
            File.Delete(path1);
            File.Delete(path2);
            Assert.IsFalse(File.Exists(path1));
            Assert.IsFalse(File.Exists(path2));
        }
        finally
        {
            if (File.Exists(path1)) File.Delete(path1);
            if (File.Exists(path2)) File.Delete(path2);
        }
    }

    [Test]
    public void Dispose_WithoutWrite_DoesNotOpenFiles()
    {
        // A multipart content built but never written should not have opened
        // any of the file parts' underlying files.
        string path = Path.Combine(Path.GetTempPath(), $"scm-mp-missing-{Guid.NewGuid():N}.bin");

        var multipart = new MultiPartFormContent();
        multipart.Add("file", new FileBinaryContent(path));

        Assert.DoesNotThrow(() => multipart.Dispose());
        Assert.IsFalse(File.Exists(path));
    }

    [Test]
    public void Dispose_IsIdempotent()
    {
        var multipart = new MultiPartFormContent();
        multipart.Add("name", "value");

        Assert.DoesNotThrow(() => multipart.Dispose());
        Assert.DoesNotThrow(() => multipart.Dispose());
    }

    [Test]
    public async Task Dispose_DisposesStreamBackedFileParts()
    {
        // FileBinaryContent(Stream) takes ownership; MultiPartFormContent.Dispose
        // must propagate disposal so the stream is released.
        var stream = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
        var multipart = new MultiPartFormContent();
        multipart.Add("file", new FileBinaryContent(stream));

        await multipart.WriteToAsync(Stream.Null);
        multipart.Dispose();

        Assert.Throws<ObjectDisposedException>(() => _ = stream.Length);
    }

    [Test]
    public void Add_AfterDispose_DoesNotLeak()
    {
        // Sanity: disposing then no further usage must not throw or leak,
        // even with multiple primitive part types in the multipart.
        var multipart = new MultiPartFormContent();
        multipart.Add("s", "hello");
        multipart.Add("i", 42);
        multipart.Add("d", 3.14);
        multipart.Add("b", new byte[] { 1, 2, 3 });
        multipart.Add("data", BinaryData.FromBytes(new byte[] { 4, 5, 6 }));

        Assert.DoesNotThrow(() => multipart.Dispose());
    }
}
