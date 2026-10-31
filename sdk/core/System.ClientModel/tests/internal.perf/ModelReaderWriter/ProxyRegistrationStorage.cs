// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace System.ClientModel.Tests.Internal.Perf;

internal static class ProxyRegistrationStorage
{
    private const int BatchSize = 10000;
    private const int Repetitions = 5;

    public static void Run()
    {
#if NETFRAMEWORK
        throw new PlatformNotSupportedException("Proxy registration storage diagnostics are not supported on .NET Framework.");
#else
        ProxyResolutionBenchmark.Scenario[] scenarios =
        [
            ProxyResolutionBenchmark.Scenario.Direct,
            ProxyResolutionBenchmark.Scenario.LookupMiss,
            ProxyResolutionBenchmark.Scenario.AllDecline
        ];
        foreach (var scenario in scenarios)
            GC.KeepAlive(ProxyResolutionBenchmark.CreateOptions(scenario, 10));

        var results = new List<object>();
        foreach (var scenario in scenarios)
        {
            foreach (int count in new[] { 0, 1, 10 })
            {
                var retained = new double[Repetitions];
                var allocated = new double[Repetitions];
                for (int i = 0; i < Repetitions; i++)
                    (retained[i], allocated[i]) = Measure(scenario, count);
                results.Add(new
                {
                    Scenario = scenario.ToString(),
                    Registrations = count,
                    DistinctKeys = scenario == ProxyResolutionBenchmark.Scenario.AllDecline ? Math.Min(count, 1) : count,
                    RetainedBytesPerOptionsSamples = retained,
                    AllocatedBytesPerOptionsSamples = allocated
                });
            }
        }
        Console.WriteLine(JsonSerializer.Serialize(new
        {
            BatchSize,
            Repetitions,
            Scope = "Options and registration containers/entries only; proxy implementations and model keys are precreated/shared. Array of roots excluded. No serialization invoked.",
            Method = "GC.GetTotalMemory(true) before/after a strongly rooted batch; GC.GetAllocatedBytesForCurrentThread around batch construction. Report samples, not exact individual object sizes.",
            Results = results
        }, new JsonSerializerOptions { WriteIndented = true }));
#endif
    }

#if !NETFRAMEWORK
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static (double Retained, double Allocated) Measure(ProxyResolutionBenchmark.Scenario scenario, int count)
    {
        var roots = new ModelReaderWriterOptions[BatchSize];
        long beforeRetained = GC.GetTotalMemory(true);
        long beforeAllocated = GC.GetAllocatedBytesForCurrentThread();
        for (int i = 0; i < roots.Length; i++)
            roots[i] = ProxyResolutionBenchmark.CreateOptions(scenario, count);
        long allocated = GC.GetAllocatedBytesForCurrentThread() - beforeAllocated;
        long retained = GC.GetTotalMemory(true) - beforeRetained;
        GC.KeepAlive(roots);
        return ((double)retained / BatchSize, (double)allocated / BatchSize);
    }
#endif
}
