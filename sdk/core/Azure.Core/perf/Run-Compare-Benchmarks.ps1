# Run-And-Compare-Benchmarks.ps1

# Set the path to your main benchmark project (update if needed)
$benchmarkProject = "perf/Azure.Core.Perf.csproj"
$framework = "net8.0"

# Define the benchmark filters
$benchmarkFilters = @(
    "Azure.Core.Perf.PipelineDefaultBenchmark*",
    "Azure.Core.Perf.PipelineBenchmark*",
    "Azure.Core.Perf.EventSourceBenchmark*",
    "Azure.Core.Perf.DynamicObjectBenchmark*"
)

# First run: Local Azure.Core project (no AzureCoreVersion set)
Write-Host "Running benchmarks with local Azure.Core project..."
foreach ($filter in $benchmarkFilters) {
    Write-Host "Running filter: $filter"
    dotnet run -c Release --framework $framework --bm --filter $filter
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Benchmark run failed for filter: $filter. Exiting."
        exit 1
    }
}

# Second run: Azure.Core NuGet package version from Packages.Data.props
Write-Host "Running benchmarks with Azure.Core NuGet package..."
foreach ($filter in $benchmarkFilters) {
    Write-Host "Running filter: $filter"
    dotnet run -c Release --framework $framework --bm --filter $filter -p AzureCoreVersion=nuget
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Benchmark run failed for filter: $filter. Exiting."
        exit 1
    }
}

# Run the comparison script
Write-Host "Comparing benchmark results..."
$compareScript = "./Compare-Benchmarks.ps1"
& pwsh $compareScript

if ($LASTEXITCODE -ne 0) {
    Write-Host "Comparison failed: Local is more than 10 percent slower than Nuget in at least one benchmark."
    exit 1
} else {
    Write-Host "All benchmarks passed comparison."
}
