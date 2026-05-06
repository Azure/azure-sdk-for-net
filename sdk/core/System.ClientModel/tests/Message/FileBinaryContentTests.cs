// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Message;

#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates.

internal class FileBinaryContentTests : SyncAsyncTestBase
{
    private string _testDirectory = null!;

    public FileBinaryContentTests(bool isAsync) : base(isAsync)
    {
    }

    [SetUp]
    public void CreateTestDirectory()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"scm-fbc-{Guid.NewGuid():N}");
        Directory.CreateDirectory(_testDirectory);
    }

    [TearDown]
    public void DeleteTestDirectory()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, recursive: true);
        }
    }

    private static byte[] CreateBytes(int size, int seed = 100)
    {
        byte[] bytes = new byte[size];
        new Random(seed).NextBytes(bytes);
        return bytes;
    }

    private string CreateTempFile(byte[]? bytes = null)
    {
        string path = Path.Combine(_testDirectory, $"{Guid.NewGuid():N}.bin");
        if (bytes is not null)
        {
            File.WriteAllBytes(path, bytes);
        }
        return path;
    }

    [Test]
    public void Ctor_BinaryData_Throws_WhenDataIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new FileBinaryContent((BinaryData)null!));
    }

    [Test]
    public void Ctor_BinaryData_DefaultsMediaTypeToOctetStream()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        using FileBinaryContent content = new(data);

        Assert.AreEqual("application/octet-stream", content.MediaType);
    }

    [Test]
    public void Ctor_BinaryData_UsesExplicitMediaTypeWhenDataHasNone()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        using FileBinaryContent content = new(data, "image/png");

        Assert.AreEqual("image/png", content.MediaType);
    }

    [Test]
    public void Ctor_BinaryData_PrefersDataMediaTypeOverArgument()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 }).WithMediaType("text/plain");
        using FileBinaryContent content = new(data, "image/png");

        Assert.AreEqual("text/plain", content.MediaType);
    }

    [Test]
    public void Ctor_BinaryData_DoesNotSetFilename()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        using FileBinaryContent content = new(data);

        Assert.IsNull(content.Filename);
    }

    [Test]
    public void TryComputeLength_BinaryData_ReturnsByteCount()
    {
        byte[] bytes = CreateBytes(64);
        using FileBinaryContent content = new(BinaryData.FromBytes(bytes));

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(bytes.Length, length);
    }

    [Test]
    public void TryComputeLength_BinaryData_Empty_ReturnsZero()
    {
        using FileBinaryContent content = new(BinaryData.FromBytes(Array.Empty<byte>()));

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public async Task WriteTo_BinaryData_WritesAllBytes()
    {
        byte[] bytes = CreateBytes(128);
        using FileBinaryContent content = new(BinaryData.FromBytes(bytes));

        using MemoryStream destination = new();
        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes, destination.ToArray());
    }

    [Test]
    public void Ctor_Stream_Throws_WhenStreamIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new FileBinaryContent((Stream)null!));
    }

    [Test]
    public void Ctor_Stream_Throws_WhenStreamIsNotSeekable()
    {
        NonSeekableMemoryStream stream = new();

        Assert.Throws<ArgumentException>(() => new FileBinaryContent(stream));
    }

    [Test]
    public void Ctor_Stream_DefaultsMediaTypeToOctetStream()
    {
        using MemoryStream stream = new(CreateBytes(8));
        using FileBinaryContent content = new(stream);

        Assert.AreEqual("application/octet-stream", content.MediaType);
    }

    [Test]
    public void Ctor_Stream_UsesProvidedMediaType()
    {
        using MemoryStream stream = new(CreateBytes(8));
        using FileBinaryContent content = new(stream, "image/jpeg");

        Assert.AreEqual("image/jpeg", content.MediaType);
    }

    [Test]
    public void Ctor_Stream_DoesNotSetFilename()
    {
        using MemoryStream stream = new(CreateBytes(8));
        using FileBinaryContent content = new(stream);

        Assert.IsNull(content.Filename);
    }

    [Test]
    public void TryComputeLength_Stream_ReturnsRemainingByteCount()
    {
        byte[] bytes = CreateBytes(256);
        using MemoryStream stream = new(bytes);
        using FileBinaryContent content = new(stream);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(bytes.Length, length);
    }

    [Test]
    public void TryComputeLength_Stream_RespectsConstructionPosition()
    {
        byte[] bytes = CreateBytes(256);
        MemoryStream stream = new(bytes);
        stream.Seek(64, SeekOrigin.Begin);
        using FileBinaryContent content = new(stream);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(bytes.Length - 64, length);
    }

    [Test]
    public void TryComputeLength_Stream_Empty_ReturnsZero()
    {
        using MemoryStream stream = new(Array.Empty<byte>());
        using FileBinaryContent content = new(stream);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public async Task WriteTo_Stream_WritesAllBytes()
    {
        byte[] bytes = CreateBytes(256);
        MemoryStream source = new(bytes);
        using FileBinaryContent content = new(source);

        using MemoryStream destination = new();
        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes, destination.ToArray());
    }

    [Test]
    public async Task WriteTo_Stream_CanBeCalledMultipleTimes()
    {
        byte[] bytes = CreateBytes(64);
        MemoryStream source = new(bytes);
        using FileBinaryContent content = new(source);

        using MemoryStream first = new();
        await content.WriteToSyncOrAsync(first, CancellationToken.None, IsAsync);

        using MemoryStream second = new();
        await content.WriteToSyncOrAsync(second, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes, first.ToArray());
        Assert.AreEqual(bytes, second.ToArray());
    }

    [Test]
    public void Dispose_Stream_DisposesUnderlyingStream()
    {
        MemoryStream source = new(CreateBytes(8));
        FileBinaryContent content = new(source);

        content.Dispose();

        Assert.Throws<ObjectDisposedException>(() => _ = source.Length);
    }

    [Test]
    public void WriteTo_Throws_WhenDestinationIsNull()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        using FileBinaryContent content = new(data);

        Assert.Throws<ArgumentNullException>(() => content.WriteTo(null!));
    }

    [Test]
    public void WriteToAsync_Throws_WhenDestinationIsNull()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        using FileBinaryContent content = new(data);

        Assert.ThrowsAsync<ArgumentNullException>(() => content.WriteToAsync(null!));
    }

    [Test]
    public void WriteTo_NullCheckOccursBeforeDisposedCheck()
    {
        BinaryData data = BinaryData.FromBytes(new byte[] { 1, 2, 3 });
        FileBinaryContent content = new(data);
        content.Dispose();

        Assert.Throws<ArgumentNullException>(() => content.WriteTo(null!));
        Assert.ThrowsAsync<ArgumentNullException>(() => content.WriteToAsync(null!));
    }

    [Test]
    public void Ctor_Path_Throws_WhenPathIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new FileBinaryContent((string)null!));
    }

    [Test]
    public void Ctor_Path_Throws_WhenPathIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new FileBinaryContent(string.Empty));
    }

    [Test]
    public void Ctor_Path_DoesNotOpenFileEagerly()
    {
        // A path that does not exist should not throw at construction time.
        string path = CreateTempFile();
        Assert.IsFalse(File.Exists(path));

        using FileBinaryContent content = new(path);

        // Constructor succeeds even though the file does not exist.
        Assert.AreEqual(Path.GetFileName(path), content.Filename);
        Assert.AreEqual("application/octet-stream", content.MediaType);
    }

    [Test]
    public void Ctor_Path_InitializesFilenameFromPath()
    {
        byte[] bytes = CreateBytes(8);
        string path = CreateTempFile(bytes);

        using FileBinaryContent content = new(path, "text/plain");

        Assert.AreEqual(Path.GetFileName(path), content.Filename);
        Assert.AreEqual("text/plain", content.MediaType);
    }

    [Test]
    public void Ctor_Path_Filename_IsNull_WhenPathHasNoFileNameComponent()
    {
        string rootLikePath = Path.DirectorySeparatorChar.ToString();

        using FileBinaryContent content = new(rootLikePath);

        Assert.IsNull(content.Filename);
    }

    [Test]
    public void Filename_Setter_OverridesPathDerivedValue()
    {
        string path = CreateTempFile(CreateBytes(8));

        using FileBinaryContent content = new(path);
        Assert.AreEqual(Path.GetFileName(path), content.Filename);

        content.Filename = "override.txt";
        Assert.AreEqual("override.txt", content.Filename);

        content.Filename = null;
        Assert.IsNull(content.Filename);
    }

    [Test]
    public void TryComputeLength_Path_ReturnsFileSize()
    {
        byte[] bytes = CreateBytes(1024);
        string path = CreateTempFile(bytes);

        using FileBinaryContent content = new(path);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(bytes.Length, length);
    }

    [Test]
    public void TryComputeLength_Path_Empty_ReturnsZero()
    {
        string path = CreateTempFile(Array.Empty<byte>());

        using FileBinaryContent content = new(path);

        Assert.IsTrue(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public async Task WriteTo_Path_WritesFileBytes()
    {
        byte[] bytes = CreateBytes(2048);
        string path = CreateTempFile(bytes);

        using FileBinaryContent content = new(path);

        using MemoryStream destination = new();
        await content.WriteToSyncOrAsync(destination, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes, destination.ToArray());
    }

    [Test]
    public void TryComputeLength_Path_ReturnsFalse_WhenFileMissing()
    {
        string path = CreateTempFile();
        using FileBinaryContent content = new(path);

        Assert.IsFalse(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public void WriteTo_Path_PropagatesIOException_WhenFileMissing()
    {
        string path = CreateTempFile();
        using FileBinaryContent content = new(path);

        using MemoryStream destination = new();
        Assert.Throws<FileNotFoundException>(() => content.WriteTo(destination));
    }

    [Test]
    public void WriteToAsync_Path_PropagatesIOException_WhenFileMissing()
    {
        string path = CreateTempFile();
        using FileBinaryContent content = new(path);

        using MemoryStream destination = new();
        Assert.ThrowsAsync<FileNotFoundException>(() => content.WriteToAsync(destination));
    }

    [Test]
    public async Task WriteTo_Path_CanBeCalledMultipleTimes()
    {
        byte[] bytes = Encoding.UTF8.GetBytes("hello, world!");
        string path = CreateTempFile(bytes);

        using FileBinaryContent content = new(path);

        using MemoryStream first = new();
        await content.WriteToSyncOrAsync(first, CancellationToken.None, IsAsync);

        using MemoryStream second = new();
        await content.WriteToSyncOrAsync(second, CancellationToken.None, IsAsync);

        Assert.AreEqual(bytes, first.ToArray());
        Assert.AreEqual(bytes, second.ToArray());
    }

    [Test]
    public void Dispose_Path_NeverOpened_DoesNotThrow()
    {
        string path = CreateTempFile();
        FileBinaryContent content = new(path);

        Assert.DoesNotThrow(() => content.Dispose());
        Assert.DoesNotThrow(() => content.Dispose());
    }

    [Test]
    public void Dispose_Path_AfterUse_ReleasesFileHandle()
    {
        byte[] bytes = CreateBytes(16);
        string path = CreateTempFile(bytes);

        FileBinaryContent content = new(path);
        using (MemoryStream destination = new())
        {
            content.WriteTo(destination);
        }

        content.Dispose();

        // After dispose, the file handle is released and exclusive access succeeds.
        Assert.DoesNotThrow(
            () => File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None).Dispose());
    }

    [Test]
    public void Operations_AfterDispose_Throw()
    {
        MemoryStream stream = new(CreateBytes(8));
        FileBinaryContent content = new(stream);
        content.Dispose();

        // Underlying source is disposed.
        Assert.Throws<ObjectDisposedException>(() => _ = stream.Length);

        using MemoryStream destination = new();

        ObjectDisposedException writeEx = Assert.Throws<ObjectDisposedException>(() => content.WriteTo(destination))!;
        Assert.AreEqual(nameof(FileBinaryContent), writeEx.ObjectName);

        ObjectDisposedException writeAsyncEx = Assert.ThrowsAsync<ObjectDisposedException>(() => content.WriteToAsync(destination))!;
        Assert.AreEqual(nameof(FileBinaryContent), writeAsyncEx.ObjectName);

        Assert.IsFalse(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public void Operations_AfterDispose_Throw_FromPath()
    {
        byte[] bytes = CreateBytes(8);
        string path = CreateTempFile(bytes);

        FileBinaryContent content = new(path);

        // Force the lazy file open so we exercise the disposed-after-open path.
        using (MemoryStream warmup = new())
        {
            content.WriteTo(warmup);
        }

        content.Dispose();

        using MemoryStream destination = new();

        ObjectDisposedException writeEx = Assert.Throws<ObjectDisposedException>(() => content.WriteTo(destination))!;
        Assert.AreEqual(nameof(FileBinaryContent), writeEx.ObjectName);

        ObjectDisposedException writeAsyncEx = Assert.ThrowsAsync<ObjectDisposedException>(() => content.WriteToAsync(destination))!;
        Assert.AreEqual(nameof(FileBinaryContent), writeAsyncEx.ObjectName);

        Assert.IsFalse(content.TryComputeLength(out long length));
        Assert.AreEqual(0, length);
    }

    [Test]
    public void Dispose_IsIdempotent()
    {
        MemoryStream stream = new(CreateBytes(8));
        FileBinaryContent content = new(stream);

        content.Dispose();
        Assert.Throws<ObjectDisposedException>(() => _ = stream.Length);

        Assert.DoesNotThrow(() => content.Dispose());
        Assert.Throws<ObjectDisposedException>(() => _ = stream.Length);
    }

    [Test]
    public void Dispose_IsIdempotent_FromPath()
    {
        byte[] bytes = CreateBytes(8);
        string path = CreateTempFile(bytes);

        FileBinaryContent content = new(path);
        using (MemoryStream destination = new())
        {
            content.WriteTo(destination);
        }

        Assert.DoesNotThrow(() => content.Dispose());
        Assert.DoesNotThrow(() => content.Dispose());
    }

    [Test]
    public void FileBinaryContentWriteToCanBeCancelled()
    {
        byte[] bytes = CreateBytes(8);
        string path = CreateTempFile(bytes);
        using FileBinaryContent content = new(path);

        using MemoryStream destination = new();
        CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.Throws<OperationCanceledException>(() => content.WriteTo(destination, cts.Token));

        // Destination must not have been written to.
        Assert.AreEqual(0, destination.Length);
    }

    [Test]
    public void FileBinaryContentWriteToAsyncCanBeCancelled()
    {
        byte[] bytes = CreateBytes(8);
        string path = CreateTempFile(bytes);
        using FileBinaryContent content = new(path);

        using MemoryStream destination = new();
        CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(() => content.WriteToAsync(destination, cts.Token));

        // Destination must not have been written to.
        Assert.AreEqual(0, destination.Length);
    }
}

#pragma warning restore SCME0004
