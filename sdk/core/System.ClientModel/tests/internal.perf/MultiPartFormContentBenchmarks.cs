// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    /// <summary>
    /// Benchmarks for <see cref="MultiPartFormContent"/> ensuring that adding
    /// file and primitive parts does not buffer payloads in memory and that
    /// writing the full multipart payload streams efficiently.
    /// </summary>
    [MemoryDiagnoser]
    public class MultiPartFormContentBenchmarks
    {
        [Params(64 * 1024, 4 * 1024 * 1024)]
        public int FileSize;

        [Params(1, 4, 16)]
        public int FileParts;

        private string _filePath = null!;
        private string[] _filePaths = null!;
        private byte[] _bytes = null!;
        private BinaryData _binaryData = null!;

        [GlobalSetup]
        public void Setup()
        {
            _bytes = new byte[FileSize];
            new Random(42).NextBytes(_bytes);
            _binaryData = BinaryData.FromBytes(_bytes);

            _filePath = Path.Combine(Path.GetTempPath(), $"scm-mp-perf-{Guid.NewGuid():N}.bin");
            File.WriteAllBytes(_filePath, _bytes);

            // Distinct files exercise the "list of files" scenario where each
            // part references its own file on disk.
            _filePaths = new string[FileParts];
            for (int i = 0; i < FileParts; i++)
            {
                string p = Path.Combine(Path.GetTempPath(), $"scm-mp-perf-{Guid.NewGuid():N}-{i}.bin");
                File.WriteAllBytes(p, _bytes);
                _filePaths[i] = p;
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            TryDelete(_filePath);
            if (_filePaths is not null)
            {
                foreach (var p in _filePaths)
                {
                    TryDelete(p);
                }
            }
        }

        private static void TryDelete(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch
            {
                // best-effort cleanup
            }
        }

        /// <summary>
        /// Adding file parts (path-backed) should not read the file. This
        /// measures the overhead of adding N file parts.
        /// </summary>
        [Benchmark]
        public void Add_FileParts_FromPath()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_filePath));
            }
        }

        [Benchmark]
        public void Add_FileParts_FromBinaryData()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_binaryData));
            }
        }

        [Benchmark]
        public void Add_PrimitiveParts()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"s{i}", "hello world");
                multipart.Add($"i{i}", 1234);
                multipart.Add($"d{i}", 3.14159d);
            }
        }

        [Benchmark]
        public void Add_BinaryDataParts()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"b{i}", _binaryData);
            }
        }

        /// <summary>
        /// "List of files" scenario: each part is backed by a distinct file on
        /// disk. Verifies that adding many file parts does not pre-read any
        /// file contents.
        /// </summary>
        [Benchmark]
        public void Add_ListOfFiles()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_filePaths[i]));
            }
        }

        [Benchmark]
        public async Task WriteToAsync_ListOfFiles()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_filePaths[i]));
            }
            await multipart.WriteToAsync(Stream.Null).ConfigureAwait(false);
        }

        [Benchmark]
        public void WriteTo_FilePartsFromPath()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_filePath));
            }
            multipart.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FilePartsFromPath()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_filePath));
            }
            await multipart.WriteToAsync(Stream.Null).ConfigureAwait(false);
        }

        [Benchmark]
        public async Task WriteToAsync_FilePartsFromBinaryData()
        {
            using var multipart = new MultiPartFormContent();
            for (int i = 0; i < FileParts; i++)
            {
                multipart.Add($"file{i}", new FileBinaryContent(_binaryData));
            }
            await multipart.WriteToAsync(Stream.Null).ConfigureAwait(false);
        }
    }
}
