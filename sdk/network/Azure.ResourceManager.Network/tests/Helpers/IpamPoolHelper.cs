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
    public static partial class IpamPoolHelperExtensions
    {
        private const int DelayMilliseconds = 10000;

        public static async Task<List<PoolAssociation>> PostListAssociatedResourcesAsync(
            this IpamPoolResource ipamPool)
        {
            List<PoolAssociation> poolAssociations = new List<PoolAssociation>();
            var associatedResourcesPages = ipamPool.GetAssociatedResourcesAsync();
            await foreach (var associatedResource in associatedResourcesPages)
            {
                poolAssociations.Add(associatedResource);
            }
            return poolAssociations;
        }

        public static async Task<PoolUsage> PostGetPoolUsageAsync(
            this IpamPoolResource ipamPool)
        {
            return await ipamPool.GetPoolUsageAsync();
        }

        public static async Task DeleteStaticCidrAsync(
            this IpamPoolResource ipamPool,
            StaticCidrResource staticCidr)
        {
            if (await ipamPool.GetStaticCidrs().ExistsAsync(staticCidr.Data.Name))
            {
                StaticCidrResource staticCidrResponse = await ipamPool.GetStaticCidrs().GetAsync(staticCidr.Data.Name);
                await staticCidrResponse.DeleteAsync(WaitUntil.Completed);
            }
        }

        public static async Task DeleteIpamPoolAsync(
            this IpamPoolResource ipamPool,
            NetworkManagerResource networkManager)
        {
            if (await networkManager.GetIpamPools().ExistsAsync(ipamPool.Data.Name))
            {
                IpamPoolResource ipamPoolResponse = await networkManager.GetIpamPools().GetAsync(ipamPool.Data.Name);
                await ipamPoolResponse.DeleteAsync(WaitUntil.Completed);
            }
        }

        public static async Task<IpamPoolResource> CreateIpamPoolAsync(
            this ResourceGroupResource resourceGroup,
            NetworkManagerResource networkManager,
            string ipamPoolName,
            AzureLocation location,
            List<string> addressPrefixes)
        {
            IpamPoolData ipamPoolData = new IpamPoolData(location, new IpamPoolProperties(new List<string>() { }));

            foreach (var addressPrefix in addressPrefixes)
            {
                ipamPoolData.Properties.AddressPrefixes.Add(addressPrefix);
            }

            var ipamPoolLro = await (await networkManager.GetIpamPools().CreateOrUpdateAsync(WaitUntil.Completed, ipamPoolName, ipamPoolData)).WaitForCompletionAsync();
            return ipamPoolLro.Value;
        }

        public static async Task<StaticCidrResource> CreateStaticCidrAsync(this IpamPoolResource ipamPool, string staticCidrName, List<string> addressPrefixes)
        {
            StaticCidrCollection staticCidrs = ipamPool.GetStaticCidrs();

            var staticCidrData = new StaticCidrData();
            staticCidrData.Properties = new StaticCidrProperties();

            foreach (var addressPrefix in addressPrefixes)
            {
                staticCidrData.Properties.AddressPrefixes.Add(addressPrefix);
            }

            ArmOperation<StaticCidrResource> staticCidrResource = await staticCidrs.CreateOrUpdateAsync(WaitUntil.Completed, staticCidrName, staticCidrData).ConfigureAwait(false);
            return staticCidrResource.Value;
        }
    }
}
