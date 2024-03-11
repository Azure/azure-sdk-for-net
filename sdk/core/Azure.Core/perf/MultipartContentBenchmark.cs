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
    public void /* Stream */ SerializeWithOptimizedMultipart()
    {
        System.ClientModel.Primitives.MultipartContent content = new(boundary: "f8c75cdd-b0a1-4b5d-9807-bff78e26d083"u8);
        content.Add(BinaryContent.FromBinaryData(BinaryData.FromString("Hello World!\r\n")), ("Content-Type", "text/plain"));
        content.Add(BinaryContent.FromStream(new FileStream(@"C:\Users\mredding\source\repos\MultipartPerfAnalysis\MultipartPerfAnalysis\testcontent.txt", FileMode.Open, FileAccess.Read)), ("Content-Type", "application/octet-stream"));

        //MemoryStream stream = new();
        //content.WriteTo(stream);
        //stream.Flush();
        //return stream;
    }

    [Benchmark]
    public void /* Stream */ SerializeWithBCL()
    {
        System.Net.Http.MultipartFormDataContent httpContent = new();
        httpContent.Add(new StringContent("Hello World!\r\n"), "text/plain");
        httpContent.Add(new StreamContent(new FileStream(@"C:\Users\mredding\source\repos\MultipartPerfAnalysis\MultipartPerfAnalysis\testcontent.txt", FileMode.Open, FileAccess.Read)), "application/octet-stream");

#if NET6_0_OR_GREATER
        Stream contentStream = httpContent.ReadAsStream();
        BinaryContent content = BinaryContent.FromStream(contentStream);

        //MemoryStream stream = new();
        //content.WriteTo(stream);
        //stream.Flush();
        //return stream;
#else
        // TODO: if we want to perf test earlier frameworks, add that.
        // Looks like HttpContent has this API available prior to .NET 5
        // https://learn.microsoft.com/dotnet/api/system.net.http.httpcontent.loadintobufferasync
        //return new MemoryStream();
#endif
    }
}
