// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
namespace Azure.ResourceManager.Oracle.Tests.Helpers
{
public class OracleDatabaseTestUtilities
    {
    public const string DefaultResourceGroupName = "rg-oracledatabase-sdktests";
    public const string DefaultResourceLocation = "eastus";
    public const string OrderingServiceRpNamespace = "Oracle.Database";
    // public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection
    // resourceGroupsOperations, string location, string resourceGroupName)
    //     {
    //         await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed,
    //         resourceGroupName, new ResourceGroupData(location));
    //     }
    }
}
