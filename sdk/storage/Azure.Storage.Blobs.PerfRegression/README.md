# Azure.Storage.Blobs Upload Performance Regression Benchmark

Reproduces the scenario from the customer issue: concurrent `BlobClient.UploadAsync` calls
with `MaxDegreeOfParallelism = 10` and small XML payloads.

## Setup

1. Ensure you have access to an Azure Storage account.
2. Set one of these environment variables:
   - `AZURE_STORAGE_CONNECTION_STRING` (connection string auth), OR
   - `AZURE_STORAGE_BLOB_ENDPOINT` (e.g., `https://youraccount.blob.core.windows.net`) + `az login`

## Running

### Test with 12.29.2 (current)

```powershell
cd sdk/storage/Azure.Storage.Blobs.PerfRegression
dotnet run -c Release
```

### Test with 12.29.1

Edit the `.csproj` to change the package version:
```xml
<PackageReference Include="Azure.Storage.Blobs" Version="12.29.1" />
```

Then:
```powershell
dotnet run -c Release
```

### Compare

Run each version 2-3 times and compare the summary output.
The key metrics to watch are:
- **Wall-clock time**: should be ~1-2 minutes equivalent (scaled to 100 uploads)
- **Per-upload p95/max**: should be a few seconds, not 60-100s

## Expected Results

If the regression is real, 12.29.2 should show significantly higher per-upload latencies
and total wall-clock times compared to 12.29.1.

## Using local .nupkg files

If you have local .nupkg files (in `C:\Users\amnguye\Downloads`), add a local source:

```powershell
dotnet nuget add source C:\Users\amnguye\Downloads --name local-packages
```

Then the package restore will find them there.
