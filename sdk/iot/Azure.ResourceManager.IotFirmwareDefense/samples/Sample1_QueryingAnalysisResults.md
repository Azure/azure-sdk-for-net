# Example: Querying firmware analysis results

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

The list operations for analysis results (CVEs, latest CVEs, binary hardening, crypto certificates, crypto keys, password hashes, SBOM components and unsafe function calls) accept optional `filter`, `orderby`, `search` and `maxCount` parameters. They are sent to the service as `$filter`, `$orderby`, `$search` and `$top` and require API version `2027-01-01`. Existing calls without these parameters keep working.

Namespaces for this example:

```C# Snippet:Query_AnalysisResults_Namespaces
using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.IotFirmwareDefense;
using Azure.ResourceManager.IotFirmwareDefense.Models;
using NUnit.Framework;
```

Get the firmware to query:

```C# Snippet:Query_AnalysisResults_GetFirmware
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier firmwareId = IotFirmwareResource.CreateResourceIdentifier(
    "00000000-0000-0000-0000-000000000000", "myResourceGroup", "myWorkspace", "myFirmwareId");
IotFirmwareResource firmware = client.GetIotFirmwareResource(firmwareId);
```

## Filter, sort and search

The service evaluates the expressions, so the supported filter fields are defined by the service.

```C# Snippet:Query_AnalysisResults_FilterSortAndSearch
// The service evaluates the filter, sort and search expressions, not the client.
AsyncPageable<CveResult> cves = firmware.GetCvesAsync(
    filter: "severity eq 'High'",
    orderby: "cveName desc",
    search: "openssl");

await foreach (CveResult cve in cves)
{
    Console.WriteLine($"{cve.Properties.CveName}: {cve.Properties.Severity}");
}
```

## Page size and total limit

`maxCount` sets the page size, not the total number of results. Limit the total on the client.

```C# Snippet:Query_AnalysisResults_PageSizeAndTotalLimit
// maxCount is the page size sent to the service as $top. It does not cap the total number of results,
// so the enumeration keeps following continuation until the results run out.
AsyncPageable<CveResult> allCves = firmware.GetCvesAsync(maxCount: 50);

// To stop after a fixed number of results, limit the enumeration on the client.
int total = 0;
await foreach (CveResult cve in allCves)
{
    Console.WriteLine(cve.Properties.CveName);
    if (++total == 200)
    {
        break;
    }
}
```

## Continue from a previous page

Use `AsPages` to read page by page and resume from a saved continuation token.

```C# Snippet:Query_AnalysisResults_ContinueFromPreviousPage
AsyncPageable<CveResult> cves = firmware.GetCvesAsync(filter: "severity eq 'High'", maxCount: 50);

// Read one page and keep its continuation token.
string continuationToken = null;
await foreach (Page<CveResult> page in cves.AsPages(pageSizeHint: 50))
{
    Console.WriteLine($"Read {page.Values.Count} results.");
    continuationToken = page.ContinuationToken;
    break;
}

// Resume from the saved token, using the same query, to read the remaining pages.
if (continuationToken != null)
{
    await foreach (Page<CveResult> page in cves.AsPages(continuationToken))
    {
        Console.WriteLine($"Read {page.Values.Count} more results.");
    }
}
```

## Synchronous listing

```C# Snippet:Query_AnalysisResults_ListSynchronously
Pageable<CveResult> cves = firmware.GetCves(orderby: "cveName asc", maxCount: 25);
foreach (CveResult cve in cves.Take(100))
{
    Console.WriteLine(cve.Properties.CveName);
}
```
