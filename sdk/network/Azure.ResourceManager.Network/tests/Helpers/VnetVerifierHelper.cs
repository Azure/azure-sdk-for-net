// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using Azure.ResourceManager.Models;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class VnetVerifierHelperExtensions
    {
        private const int DelayMilliseconds = 10000;

        public static async Task DeleteAnalysisIntentAsync(
            this VerifierWorkspaceResource vnetVerifier,
            ReachabilityAnalysisIntentResource analysisIntent)
        {
            if (await vnetVerifier.GetReachabilityAnalysisIntents().ExistsAsync(analysisIntent.Data.Name))
            {
                ReachabilityAnalysisIntentResource analysisIntentResponse = await vnetVerifier.GetReachabilityAnalysisIntents().GetAsync(analysisIntent.Data.Name);
                await analysisIntentResponse.DeleteAsync(WaitUntil.Completed);
            }
        }
        public static async Task DeleteAnalysisRunAsync(
            this VerifierWorkspaceResource vnetVerifier,
            ReachabilityAnalysisRunResource analysisRun)
        {
            try
            {
                if (await vnetVerifier.GetReachabilityAnalysisRuns().ExistsAsync(analysisRun.Data.Name))
                {
                    ReachabilityAnalysisRunResource analysisRunResponse = await vnetVerifier.GetReachabilityAnalysisRuns().GetAsync(analysisRun.Data.Name);
                    await analysisRunResponse.DeleteAsync(WaitUntil.Completed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting analysis run: {ex.Message}");
            }
        }

        public static async Task DeleteVnetVerifierAsync(
            this VerifierWorkspaceResource vnetVerifier,
            NetworkManagerResource networkManager)
        {
            if (await networkManager.GetVerifierWorkspaces().ExistsAsync(vnetVerifier.Data.Name))
            {
                VerifierWorkspaceResource vnetVerifierResponse = await networkManager.GetVerifierWorkspaces().GetAsync(vnetVerifier.Data.Name);
                await vnetVerifierResponse.DeleteAsync(WaitUntil.Completed);
            }
        }

        public static async Task<VerifierWorkspaceResource> CreateVerifierWorkspaceAsync(
            this ResourceGroupResource resourceGroup,
            NetworkManagerResource networkManager,
            string vnetVerifierName,
            AzureLocation location)
        {
            var vnetVerifierData = new VerifierWorkspaceData(location);

            var vnv = await networkManager.GetVerifierWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, vnetVerifierName, vnetVerifierData);
            await Task.Delay(10000);
            return await vnv.WaitForCompletionAsync();
        }

        public static async Task<ReachabilityAnalysisRunResource> CreateAnalysisRunAsync(this VerifierWorkspaceResource vnetVerifier, string analysisRunName, string intentId)
        {
            ReachabilityAnalysisRunCollection analysisRun = vnetVerifier.GetReachabilityAnalysisRuns();

            var reachabilityAnalysisRunData = new ReachabilityAnalysisRunData
            {
                Properties = new ReachabilityAnalysisRunProperties { IntentId = intentId }
            };
            ArmOperation<ReachabilityAnalysisRunResource> analysisIntentResource = await analysisRun.CreateOrUpdateAsync(WaitUntil.Completed, analysisRunName, reachabilityAnalysisRunData).ConfigureAwait(false);
            return analysisIntentResource.Value;
        }

        public static async Task<ReachabilityAnalysisIntentResource> CreateAnalysisIntentAsync(this VerifierWorkspaceResource vnetVerifier, string analysisIntentName, ResourceIdentifier sourceResourceId, ResourceIdentifier destinationResourceId, List<string> sourceIps, List<string> destinationIps, List<string> sourcePorts, List<string> destinationPorts, List<NetworkProtocol> protocols)
        {
            ReachabilityAnalysisIntentCollection analysisIntent = vnetVerifier.GetReachabilityAnalysisIntents();
            var ipTraffic = new IPTraffic(sourceIPs: sourceIps, destinationIPs: destinationIps, sourcePorts: sourcePorts, destinationPorts: destinationPorts, protocols: protocols);

            var reachabilityAnalysisIntentData = new ReachabilityAnalysisIntentData
            {
                Properties = new ReachabilityAnalysisIntentProperties
                {
                    SourceResourceId = sourceResourceId,
                    DestinationResourceId = destinationResourceId,
                    IPTraffic = ipTraffic
                }
            };
            ArmOperation<ReachabilityAnalysisIntentResource> analysisIntentResource = await analysisIntent.CreateOrUpdateAsync(WaitUntil.Completed, analysisIntentName, reachabilityAnalysisIntentData).ConfigureAwait(false);

            return analysisIntentResource.Value;
        }
    }
}
