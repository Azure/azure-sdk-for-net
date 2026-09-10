// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    [MemoryDiagnoser]
    public class FileBinaryContentVeryLargeFileBenchmarks
    {
        private const long FileSizeBytes = 1L * 1024 * 1024 * 1024; // 1 GB

        private string _filePath = null!;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _filePath = Path.Combine(Path.GetTempPath(), $"scm-perf-1gb-{Guid.NewGuid():N}.bin");

            // Write the file in chunks rather than allocating a single 1 GB array.
            byte[] chunk = new byte[1024 * 1024];
            new Random(42).NextBytes(chunk);
            using FileStream fs = File.Create(_filePath);
            long remaining = FileSizeBytes;
            while (remaining > 0)
            {
                int toWrite = (int)Math.Min(remaining, chunk.Length);
                fs.Write(chunk, 0, toWrite);
                remaining -= toWrite;
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            if (_filePath is not null && File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        [Benchmark]
        public void WriteTo_FromPath_1GB()
        {
            using FileBinaryContent content = new(_filePath);
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FromPath_1GB()
        {
            using FileBinaryContent content = new(_filePath);
            await content.WriteToAsync(Stream.Null);
        }
    }
#pragma warning restore SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
