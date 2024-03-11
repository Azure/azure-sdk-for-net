// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Net.Http;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf;

[SimpleJob(RuntimeMoniker.Net60)]
[MemoryDiagnoser]
public class MultipartContentBenchmark
{
    [Benchmark(Baseline = true)]
    public void SerializeWithOptimizedMultipart()
    {
        System.ClientModel.Primitives.MultipartContent mpc = new(boundary: "f8c75cdd-b0a1-4b5d-9807-bff78e26d083"u8);
        mpc.Add(BinaryContent.FromBinaryData(BinaryData.FromString("Hello World!\r\n")), ("Content-Type", "text/plain"));
        mpc.Add(BinaryContent.FromStream(new FileStream(@"C:\Users\mredding\source\repos\MultipartPerfAnalysis\MultipartPerfAnalysis\testcontent.txt", FileMode.Open, FileAccess.Read)), ("Content-Type", "application/octet-stream"));
    }

    [Benchmark]
    public void SerializeWithBCL()
    {
        System.Net.Http.MultipartFormDataContent content = new();
        content.Add(new StringContent("Hello World!\r\n"), "text/plain");
        content.Add(new StreamContent(new FileStream(@"C:\Users\mredding\source\repos\MultipartPerfAnalysis\MultipartPerfAnalysis\testcontent.txt", FileMode.Open, FileAccess.Read)), "application/octet-stream");

        // TODO: if we want to perf test earlier frameworks, add that.
#if NET6_0_OR_GREATER
        Stream contentAsStream = content.ReadAsStream();
        BinaryContent binaryContent = BinaryContent.FromStream(contentAsStream);
#endif
    }
}
