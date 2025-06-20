# Run-And-Compare-Benchmarks.ps1

# Set the path to your main benchmark project (update if needed)
$benchmarkProject = "perf/Azure.Core.Perf.csproj"
$framework = "net8.0"

# Run the benchmarks (ensure JSON exporter is enabled in your config)
Write-Host "Running benchmarks..."
dotnet run -c Release --framework $framework --bm --filter Azure.Core.Perf.PipelineBenchmark*
dotnet run -c Release --framework $framework --bm --filter Azure.Core.Perf.EventSourceBenchmark*

if ($LASTEXITCODE -ne 0) {
    Write-Host "Benchmark run failed. Exiting."
    exit 1
}

# Run the comparison script
Write-Host "Comparing benchmark results..."
$compareScript = "./Compare-Benchmarks.ps1"
& pwsh $compareScript

if ($LASTEXITCODE -ne 0) {
    Write-Host "Comparison failed: Local is more than 1 second slower than Nuget in at least one benchmark."
    exit 1
} else {
    Write-Host "All benchmarks passed comparison."
}
