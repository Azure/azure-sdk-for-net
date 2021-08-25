// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ExtendedLocation.Models;

namespace ExtendedLocation.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using ExtendedLocation.Tests.Helpers;
    using Microsoft.Azure.Management.ExtendedLocation;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    // using Microsoft.Azure.Management.ExtendedLocation.Models;

    /// <summary>
    /// Base class for tests ExtendedLocation type
    /// </summary>
    public class CustomLocationsOperationsTestBase : TestBase, IDisposable
    {
        public CustomLocationsClient CustomLocationsClient { get; set; }

        public CustomLocationOperation CustomLocationOperation { get; set; }

        public CustomLocationsOperationsTestBase(MockContext context)
        {
            var handler = new RecordedDelegatingHandler();
            CustomLocationsClient = context.GetServiceClient<CustomLocationsClient>(false, handler);
        }

        /// <summary>
        /// Creates or Updates a CustomLocation Resource
        /// </summary>
        /// <returns>The CustomLocation Resource that was created or updated.</returns>
        public CustomLocation CreateCustomLocations()
        {
            Console.WriteLine("Creating a Custom Location...");
            Microsoft.Azure.Management.ExtendedLocation.Models.CustomLocation parameters ;
            parameters = new Microsoft.Azure.Management.ExtendedLocation.Models.CustomLocation(location : CustomLocationTestData.Location);
            parameters.HostResourceId = CustomLocationTestData.HostResourceIdTest;
            List<string> clusterextids = new List<string>(new string[] { CustomLocationTestData.CassandraTest });
            parameters.ClusterExtensionIds = clusterextids;
            parameters.HostType = "Kubernetes";
            parameters.NamespaceProperty = CustomLocationTestData.NamespaceTest;
            parameters.DisplayName = CustomLocationTestData.ResourceName;
            parameters.Authentication = null;
            // this ICustomLocationsOperations operations, string resourceGroupName, string resourceName, CustomLocation parameters
            return CustomLocationsClient.CustomLocations.CreateOrUpdate(resourceGroupName : CustomLocationTestData.ResourceGroup, resourceName : CustomLocationTestData.ResourceName, parameters : parameters);
        }

        /// <summary>
        /// Patch a CustomLocation Resource
        /// </summary>
        /// <returns>The CustomLocation Resource that was created or updated.</returns>
        public CustomLocation PatchCustomLocation()
        {
            Console.WriteLine("Patching a Custom Location...");
            List<string> clusterextids = new List<string>(new string[] { CustomLocationTestData.CassandraTest , CustomLocationTestData.AnsibleTest });
            return CustomLocationsClient.CustomLocations.Update(resourceGroupName : CustomLocationTestData.ResourceGroup, 
            resourceName : CustomLocationTestData.ResourceName, 
            authentication : null, 
            clusterExtensionIds : clusterextids, 
            displayName : CustomLocationTestData.ResourceName,
            hostResourceId : CustomLocationTestData.HostResourceIdTest, 
            hostType : "Kubernetes", 
            namespaceParameter : CustomLocationTestData.NamespaceTest);
        }

        /// <summary>
        /// Delete a CustomLocation
        /// </summary>
        public void DeleteCustomLocation()
        {
            Console.WriteLine("Deleting CustomLocation... ");
            CustomLocationsClient.CustomLocations.Delete(
                resourceGroupName: CustomLocationTestData.ResourceGroup,
                resourceName: CustomLocationTestData.ResourceName
            );
        }

        /// <summary>
        /// Get CustomLocations Resources
        /// </summary>
        /// <returns>The CustomLocation resource with given resource group and resource name</returns>
        public CustomLocation GetCustomLocation()
        {
            Console.WriteLine("Getting CustomLocation...");
            return CustomLocationsClient.CustomLocations.Get(CustomLocationTestData.ResourceGroup, CustomLocationTestData.ResourceName);
        }

        /// <summary>
        /// List CustomLocations Resources under resource group
        /// </summary>
        /// <returns></returns>
        public IPage<CustomLocation> ListCustomLocationsByResourceGroup()
        {
            Console.WriteLine("Listing CustomLocations by RG...");
            return CustomLocationsClient.CustomLocations.ListByResourceGroup(CustomLocationTestData.ResourceGroup);
        }

        /// <summary>
        /// List CustomLocations Resources under resource group passing nextLink to move Page
        /// </summary>
        /// <returns></returns>
        public IPage<CustomLocation> ListCustomLocationsByResourceGroupNext(string nextLink)
        {
            return CustomLocationsClient.CustomLocations.ListByResourceGroupNext(nextLink);
        }

        /// <summary>
        /// List CustomLocations Resources under subscription
        /// </summary>
        /// <returns></returns>
        public IPage<CustomLocation> ListCustomLocationsBySubscription()
        {
            Console.WriteLine("Listing CustomLocations by Subscription...");
            return CustomLocationsClient.CustomLocations.ListBySubscription();
        }

        /// <summary>
        /// List CustomLocations Resources under subscription passing nextLink to move Page
        /// </summary>
        /// <returns></returns>
        public IPage<CustomLocation> ListCustomLocationsBySubscriptionNext(string nextLink)
        {
            return CustomLocationsClient.CustomLocations.ListBySubscriptionNext(nextLink);
        }

        #region Common Methods

        public void Dispose()
        {
            CustomLocationsClient.Dispose();
        }

        #endregion
    }
}