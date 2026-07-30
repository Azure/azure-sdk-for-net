// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
#pragma warning disable SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    [MemoryDiagnoser]
    public class MultiPartFormContentBenchmarks
    {
        // 4 KB (small), 1 MB (medium), and 100 MB (large)
        private const int SmallFileSize = 4 * 1024;
        private const int MediumFileSize = 1024 * 1024;
        private const int LargeFileSize = 100 * 1024 * 1024;

        [Params(SmallFileSize, MediumFileSize, LargeFileSize)]
        public int FileSize;

        private string _filePath = null!;
        private byte[] _fileBytes = null!;
        private BinaryData _fileData = null!;
        private JsonModel _model = null!;
        private MultiPartFormContent _persistentContent = null!;
        private CancellationToken _cancelledToken;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _filePath = Path.Combine(Path.GetTempPath(), $"scm-mpfd-perf-{Guid.NewGuid():N}.bin");

            _fileBytes = new byte[FileSize];
            new Random(42).NextBytes(_fileBytes);
            File.WriteAllBytes(_filePath, _fileBytes);

            _fileData = BinaryData.FromBytes(_fileBytes);

            _model = new JsonModel();

            _persistentContent = new MultiPartFormContent();
            _persistentContent.Add("purpose", "fine-tune");
            _persistentContent.Add("model", "gpt-4");
            _persistentContent.Add("file", new FileBinaryContent(_filePath));
            // Force lazy header / boundary realization so the first measurement isn't biased.
            _persistentContent.TryComputeLength(out _);

            CancellationTokenSource cts = new();
            cts.Cancel();
            _cancelledToken = cts.Token;
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
        public void Construct_DefaultBoundary()
        {
            using MultiPartFormContent content = new();
        }

        [Benchmark]
        public void Add_ByteArray()
        {
            using MultiPartFormContent content = new();
            content.Add("data", _fileBytes);
        }

        [Benchmark]
        public void Add_BinaryData()
        {
            using MultiPartFormContent content = new();
            content.Add("data", _fileData);
        }

        [Benchmark]
        public void Add_FileBinaryContent_FromPath()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
        }

        // ---- JSON serialization paths ----

        [Benchmark]
        public void Add_String_Json()
        {
            using MultiPartFormContent content = new();
            content.Add("name", "value");
        }

        [Benchmark]
        public void Add_String_TextPlain()
        {
            using MultiPartFormContent content = new();
            content.Add("name", "value", mediaType: "text/plain");
        }

        [Benchmark]
        public void Add_PersistableModel()
        {
            using MultiPartFormContent content = new();
            content.Add("metadata", _model);
        }

        // ---- TryComputeLength (must NOT read the file) ----

        [Benchmark]
        public bool TryComputeLength_WithFilePart()
        {
            using MultiPartFormContent content = new();
            content.Add("purpose", "fine-tune");
            content.Add("file", new FileBinaryContent(_filePath));
            return content.TryComputeLength(out _);
        }

        // Validates TryComputeLength does not degrade with part count.
        [Benchmark]
        public bool TryComputeLength_50Parts()
        {
            using MultiPartFormContent content = new();
            for (int i = 0; i < 50; i++)
            {
                content.Add($"field{i}", "value");
            }
            return content.TryComputeLength(out _);
        }

        // ---- Many small parts (regular form post shape) ----

        [Benchmark]
        public void Add_50StringParts()
        {
            using MultiPartFormContent content = new();
            for (int i = 0; i < 50; i++)
            {
                content.Add($"field{i}", "value");
            }
        }

        [Benchmark]
        public async Task WriteToAsync_50StringParts()
        {
            using MultiPartFormContent content = new();
            for (int i = 0; i < 50; i++)
            {
                content.Add($"field{i}", "value");
            }
            await content.WriteToAsync(Stream.Null);
        }

        // ---- JSON model multipart write ----

        [Benchmark]
        public async Task WriteToAsync_JsonModelParts_PlusFile()
        {
            using MultiPartFormContent content = new();
            content.Add("metadata", _model);
            content.Add("config", _model);
            content.Add("file", new FileBinaryContent(_filePath));
            await content.WriteToAsync(Stream.Null);
        }

        // ---- Streaming a single file part ----

        [Benchmark]
        public void WriteTo_SingleFilePart()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
            content.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_SingleFilePart()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
            await content.WriteToAsync(Stream.Null);
        }

        // Realistic Azure / OpenAI upload shape: a few small text fields plus a single file part.
        [Benchmark]
        public async Task WriteToAsync_MixedContent()
        {
            using MultiPartFormContent content = new();
            content.Add("purpose", "fine-tune");
            content.Add("model", "gpt-4");
            content.Add("description", "training data");
            content.Add("file", new FileBinaryContent(_filePath));
            await content.WriteToAsync(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_FivefileParts()
        {
            using MultiPartFormContent content = new();
            for (int i = 0; i < 5; i++)
            {
                content.Add($"file{i}", new FileBinaryContent(_filePath));
            }
            await content.WriteToAsync(Stream.Null);
        }

        // Baseline contrast for the streaming benchmarks: BinaryData holds the full payload in memory.
        [Benchmark]
        public async Task WriteToAsync_BinaryDataPart()
        {
            using MultiPartFormContent content = new();
            content.Add("data", _fileData);
            await content.WriteToAsync(Stream.Null);
        }

        // ---- Reused instance (SDK retry scenario) ----

        [Benchmark]
        public void WriteTo_Reused()
        {
            _persistentContent.WriteTo(Stream.Null);
        }

        [Benchmark]
        public async Task WriteToAsync_Reused()
        {
            await _persistentContent.WriteToAsync(Stream.Null);
        }

        // ---- Pre-cancelled CancellationToken (entry-level fast-path) ----

        [Benchmark]
        public void WriteTo_PrecancelledToken()
        {
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
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
            using MultiPartFormContent content = new();
            content.Add("file", new FileBinaryContent(_filePath));
            try
            {
                await content.WriteToAsync(Stream.Null, _cancelledToken);
            }
            catch (OperationCanceledException)
            {
            }
        }

        // Minimal IPersistableModel<T> driving the Add<T>(IPersistableModel) overload.
        private sealed class JsonModel : IPersistableModel<JsonModel>
        {
            private static readonly BinaryData s_payload = BinaryData.FromString(
                "{\"name\":\"fine-tune\",\"version\":1,\"tags\":[\"a\",\"b\",\"c\"]}");

            BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options) => s_payload;

            JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => this;

            string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }
    }
#pragma warning restore SCME0004 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
}
