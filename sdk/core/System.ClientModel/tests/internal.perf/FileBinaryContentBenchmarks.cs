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
    public class FileBinaryContentBenchmarks
    {
        // 4 KB (small), 1 MB (medium), and 100 MB (large)
        private const int SmallFileSize = 4 * 1024;
        private const int MediumFileSize = 1024 * 1024;
        private const int LargeFileSize = 100 * 1024 * 1024;

        [Params(SmallFileSize, MediumFileSize, LargeFileSize)]
        public int FileSize;

        private string _filePath = null!;
        private BinaryData _data = null!;
        private FileBinaryContent _persistentPathContent = null!;
        private CancellationToken _cancelledToken;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _filePath = Path.Combine(Path.GetTempPath(), $"scm-perf-{Guid.NewGuid():N}.bin");

            byte[] bytes = new byte[FileSize];
            new Random(42).NextBytes(bytes);
            File.WriteAllBytes(_filePath, bytes);

            _data = BinaryData.FromBytes(bytes);

            _persistentPathContent = new FileBinaryContent(_filePath);
            // Force lazy FileStream initialization so the first measurement isn't biased by the open cost.
            _persistentPathContent.TryComputeLength(out _);

            CancellationTokenSource cts = new();
            cts.Cancel();
            _cancelledToken = cts.Token;
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _persistentPathContent?.Dispose();

            if (_filePath is not null && File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        [Benchmark]
        public void Construct_FromPath()
        {
            using FileBinaryContent content = new(_filePath);
        }

        [Benchmark]
        public void Construct_FromBinaryData()
        {
            using FileBinaryContent content = new(_data);
        }

        [Benchmark]
        public void TryComputeLength_FromPath()
        {
            using FileBinaryContent content = new(_filePath);
            content.TryComputeLength(out _);
        }

        [Benchmark]
        public void WriteTo_FromPath()
        {
            using FileBinaryContent content = new(_filePath);
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FromPath()
        {
            using FileBinaryContent content = new(_filePath);
            await content.WriteToAsync(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FromStream()
        {
            using FileStream fileStream = File.OpenRead(_filePath);
            using FileBinaryContent content = new(fileStream);
            await content.WriteToAsync(Stream.Null);
        }

        // Baseline contrast for the streaming benchmarks: BinaryData holds the full payload in memory.
        [Benchmark]
        public void WriteTo_FromBinaryData()
        {
            using FileBinaryContent content = new(_data);
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public void WriteTo_FromPath_Reused()
        {
            _persistentPathContent.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FromPath_Reused()
        {
            await _persistentPathContent.WriteToAsync(Stream.Null);
        }

        [Benchmark]
        public void WriteTo_PrecancelledToken()
        {
            using FileBinaryContent content = new(_filePath);
            try
            {
                content.WriteTo(Stream.Null, _cancelledToken);
            }
            catch (OperationCanceledException)
            {
            }
        }

        [Benchmark]
        public async Task WriteToAsync_PrecancelledToken()
        {
            using FileBinaryContent content = new(_filePath);
            try
            {
                await content.WriteToAsync(Stream.Null, _cancelledToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
#pragma warning restore SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
