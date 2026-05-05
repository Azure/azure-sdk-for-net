// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    /// <summary>
    /// Benchmarks for <see cref="FileBinaryContent"/> verifying that the type
    /// streams data from disk without buffering the entire payload in memory and
    /// that construction does not incur up-front I/O.
    /// </summary>
    [MemoryDiagnoser]
    public class FileBinaryContentBenchmarks
    {
        // Exercise small, medium, and large payloads to verify that allocations
        // remain (approximately) flat with respect to file size when streaming
        // from a path.
        [Params(4 * 1024, 256 * 1024, 8 * 1024 * 1024)]
        public int FileSize;

        private string _filePath = null!;
        private byte[] _bytes = null!;
        private BinaryData _binaryData = null!;

        [GlobalSetup]
        public void Setup()
        {
            _bytes = new byte[FileSize];
            new Random(42).NextBytes(_bytes);
            _binaryData = BinaryData.FromBytes(_bytes);

            _filePath = Path.Combine(Path.GetTempPath(), $"scm-perf-{Guid.NewGuid():N}.bin");
            File.WriteAllBytes(_filePath, _bytes);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            try
            {
                if (_filePath is not null && File.Exists(_filePath))
                {
                    File.Delete(_filePath);
                }
            }
            catch
            {
                // best-effort cleanup
            }
        }

        /// <summary>
        /// Construction from a path must be cheap: no file handle, no read.
        /// </summary>
        [Benchmark]
        public void Construct_FromPath()
        {
            using var content = new FileBinaryContent(_filePath);
        }

        [Benchmark]
        public void Construct_FromBinaryData()
        {
            using var content = new FileBinaryContent(_binaryData);
        }

        [Benchmark]
        public void WriteTo_FromPath()
        {
            using var content = new FileBinaryContent(_filePath);
            using var sink = Stream.Null;
            content.WriteTo(sink);
        }

        [Benchmark]
        public async Task WriteToAsync_FromPath()
        {
            using var content = new FileBinaryContent(_filePath);
            await content.WriteToAsync(Stream.Null).ConfigureAwait(false);
        }

        [Benchmark]
        public void WriteTo_FromBinaryData()
        {
            using var content = new FileBinaryContent(_binaryData);
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FromStream()
        {
            // Re-open each iteration since FileBinaryContent takes ownership.
            using var fs = File.OpenRead(_filePath);
            using var content = new FileBinaryContent(fs);
            await content.WriteToAsync(Stream.Null).ConfigureAwait(false);
        }

        [Benchmark]
        public bool TryComputeLength_FromPath()
        {
            using var content = new FileBinaryContent(_filePath);
            return content.TryComputeLength(out _);
        }
    }
}
