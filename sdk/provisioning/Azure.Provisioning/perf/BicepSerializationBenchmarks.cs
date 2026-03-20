// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Storage;

namespace Azure.Provisioning.Perf;

[MemoryDiagnoser]
public class BicepSerializationBenchmarks
{
    private List<BicepStatement> _smallStatements = null!;
    private List<BicepStatement> _mediumStatements = null!;
    private List<BicepStatement> _largeStatements = null!;
    private static readonly ModelReaderWriterOptions BicepFormat = new("bicep");

    [GlobalSetup]
    public void Setup()
    {
        _smallStatements = CompileToStatements(CreateInfrastructure(1));
        _mediumStatements = CompileToStatements(CreateInfrastructure(5));
        _largeStatements = CompileToStatements(CreateInfrastructure(15));
    }

    // --- Small (1 resource) ---

    [Benchmark(Baseline = true)]
    public string Small_BicepWriter()
    {
        return RenderWithToString(_smallStatements);
    }

    [Benchmark]
    public string Small_IPersistableModel()
    {
        return RenderWithIPersistableModel(_smallStatements);
    }

    // --- Medium (5 resources) ---

    [Benchmark]
    public string Medium_BicepWriter()
    {
        return RenderWithToString(_mediumStatements);
    }

    [Benchmark]
    public string Medium_IPersistableModel()
    {
        return RenderWithIPersistableModel(_mediumStatements);
    }

    // --- Large (15 resources) ---

    [Benchmark]
    public string Large_BicepWriter()
    {
        return RenderWithToString(_largeStatements);
    }

    [Benchmark]
    public string Large_IPersistableModel()
    {
        return RenderWithIPersistableModel(_largeStatements);
    }

    // Baseline: BicepStatement.ToString() calls new BicepWriter().Append(this).ToString() internally
    private static string RenderWithToString(List<BicepStatement> statements)
    {
        StringBuilder sb = new();
        foreach (BicepStatement stmt in statements)
        {
            if (sb.Length > 0) sb.Append('\n');
            sb.Append(stmt.ToString());
        }
        return sb.ToString();
    }

    // New path: IPersistableModel<BicepStatement>.Write("bicep") → BinaryData → string
    private static string RenderWithIPersistableModel(List<BicepStatement> statements)
    {
        StringBuilder sb = new();
        foreach (BicepStatement stmt in statements)
        {
            BinaryData data = ((IPersistableModel<BicepStatement>)stmt).Write(BicepFormat);
            if (sb.Length > 0) sb.Append('\n');
            sb.Append(data.ToString());
        }
        return sb.ToString();
    }

    private static BenchmarkableInfrastructure CreateInfrastructure(int resourceCount)
    {
        BenchmarkableInfrastructure infra = new();
        for (int i = 0; i < resourceCount; i++)
        {
            StorageAccount storage = new($"storage{i}", StorageAccount.ResourceVersions.V2024_01_01)
            {
                Kind = StorageKind.StorageV2,
                Sku = new StorageSku { Name = StorageSkuName.StandardGrs },
                IsHnsEnabled = true,
                AllowBlobPublicAccess = false,
                Tags = { ["env"] = "production", ["index"] = i.ToString() },
            };
            infra.Add(storage);

            BlobService blobs = new($"blobs{i}", BlobService.ResourceVersions.V2024_01_01)
            {
                Parent = storage,
            };
            infra.Add(blobs);
        }
        return infra;
    }

    private static List<BicepStatement> CompileToStatements(BenchmarkableInfrastructure infra)
    {
        ProvisioningBuildOptions options = new();
        infra.Build(options);
        var modules = infra.ExposeCompileModules(options);
        return modules.Values.SelectMany(s => s).ToList();
    }
}

/// <summary>
/// Exposes the protected internal CompileModules method for benchmarking.
/// </summary>
internal class BenchmarkableInfrastructure : Infrastructure
{
    public IDictionary<string, IEnumerable<BicepStatement>> ExposeCompileModules(ProvisioningBuildOptions? options = null)
    {
        return CompileModules(options);
    }
}
