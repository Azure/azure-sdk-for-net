// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Query_AnalysisResults_Namespaces
using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.IotFirmwareDefense;
using Azure.ResourceManager.IotFirmwareDefense.Models;
using NUnit.Framework;
#endregion Snippet:Query_AnalysisResults_Namespaces

namespace Azure.ResourceManager.IotFirmwareDefense.Tests.Samples
{
    public class Sample1_QueryingAnalysisResults
    {
        private IotFirmwareResource firmware = null;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GetFirmware()
        {
            #region Snippet:Query_AnalysisResults_GetFirmware
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceIdentifier firmwareId = IotFirmwareResource.CreateResourceIdentifier(
                "00000000-0000-0000-0000-000000000000", "myResourceGroup", "myWorkspace", "myFirmwareId");
            IotFirmwareResource firmware = client.GetIotFirmwareResource(firmwareId);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task FilterSortAndSearch()
        {
            #region Snippet:Query_AnalysisResults_FilterSortAndSearch
            // The service evaluates the filter, sort and search expressions, not the client.
            AsyncPageable<CveResult> cves = firmware.GetCvesAsync(
                filter: "severity eq 'High'",
                orderby: "cveName desc",
                search: "openssl");

            await foreach (CveResult cve in cves)
            {
                Console.WriteLine($"{cve.Properties.CveName}: {cve.Properties.Severity}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task PageSizeAndTotalLimit()
        {
            #region Snippet:Query_AnalysisResults_PageSizeAndTotalLimit
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
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ContinueFromPreviousPage()
        {
            #region Snippet:Query_AnalysisResults_ContinueFromPreviousPage
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
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ListSynchronously()
        {
            #region Snippet:Query_AnalysisResults_ListSynchronously
            Pageable<CveResult> cves = firmware.GetCves(orderby: "cveName asc", maxCount: 25);
            foreach (CveResult cve in cves.Take(100))
            {
                Console.WriteLine(cve.Properties.CveName);
            }
            #endregion
        }
    }
}
