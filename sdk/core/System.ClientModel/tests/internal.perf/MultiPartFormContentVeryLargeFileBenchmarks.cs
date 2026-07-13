// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    [MemoryDiagnoser]
    public class MultiPartFormContentVeryLargeFileBenchmarks
    {
        private const long FileSizeBytes = 1L * 1024 * 1024 * 1024; // 1 GB

        private string _filePath = null!;
        private MultiPartFormContent _persistentContent = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _filePath = Path.Combine(Path.GetTempPath(), $"scm-mpfd-perf-1gb-{Guid.NewGuid():N}.bin");

            byte[] chunk = new byte[1024 * 1024];
            new Random(42).NextBytes(chunk);
            using (FileStream fs = File.Create(_filePath))
            {
                long remaining = FileSizeBytes;
                while (remaining > 0)
                {
                    int toWrite = (int)Math.Min(remaining, chunk.Length);
                    fs.Write(chunk, 0, toWrite);
                    remaining -= toWrite;
                }
                fs.Flush(flushToDisk: true);
            }

            for (int attempt = 0; attempt < 100; attempt++)
            {
                try
                {
                    using FileStream probe = File.OpenRead(_filePath);
                    break;
                }
                catch (IOException) when (attempt < 99)
                {
                    Thread.Sleep(100);
                }
            }

            _persistentContent = new MultiPartFormContent();
            _persistentContent.Add("purpose", "fine-tune");
            _persistentContent.Add("file", new FileBinaryContent(_filePath));

            // Warm up so the underlying file handle is open before measurement begins.
            _persistentContent.WriteToAsync(Stream.Null).GetAwaiter().GetResult();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _persistentContent?.Dispose();

            if (_filePath is not null && File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        [Benchmark]
        public void WriteTo_1GBFilePart()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_1GBFilePart()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
            await content.WriteToAsync(Stream.Null);
        }

        // Realistic upload shape with a 1 GB file part.
        [Benchmark]
        public async Task WriteToAsync_1GBFilePart_Mixed()
        {
            using MultiPartFormContent content = new();
            content.Add("purpose", "fine-tune");
            content.Add("model", "gpt-4");
            content.Add("file", new FileBinaryContent(_filePath));
            await content.WriteToAsync(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_1GBFilePart_Reused()
        {
            await _persistentContent.WriteToAsync(Stream.Null);
        }

        // Cancellation triggered after ~1 MB has been written to the destination.
        [Benchmark]
        public async Task WriteToAsync_1GBFilePart_MidStreamCancellation()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));

            using CancellationTokenSource cts = new();
            using CancelAfterStream destination = new(cts, cancelAfterBytes: 1 * 1024 * 1024);

            try
            {
                await content.WriteToAsync(destination, cts.Token);
            }
            catch (OperationCanceledException)
            {
            }
        }

        // Stream that cancels its CancellationTokenSource after a configured number of bytes.
        private sealed class CancelAfterStream : Stream
        {
            private readonly CancellationTokenSource _cts;
            private readonly long _cancelAfterBytes;
            private long _written;

            public CancelAfterStream(CancellationTokenSource cts, long cancelAfterBytes)
            {
                _cts = cts;
                _cancelAfterBytes = cancelAfterBytes;
            }

            public override bool CanRead => false;
            public override bool CanSeek => false;
            public override bool CanWrite => true;
            public override long Length => throw new NotSupportedException();
            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override void Flush() { }

            public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();

            public override void Write(byte[] buffer, int offset, int count)
            {
                _cts.Token.ThrowIfCancellationRequested();
                _written += count;
                if (_written >= _cancelAfterBytes && !_cts.IsCancellationRequested)
                {
                    _cts.Cancel();
                }
            }

            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                _written += count;
                if (_written >= _cancelAfterBytes && !_cts.IsCancellationRequested)
                {
                    _cts.Cancel();
                }
                return Task.CompletedTask;
            }
        }
    }
#pragma warning restore SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
