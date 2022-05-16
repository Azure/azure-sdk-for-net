// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestBase.Tests
{
    public static class Helpers
    {
        public static string GetAvailabilitySetRef(string subId, string resourceGrpName, string availabilitySetName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.AvailabilitySets, availabilitySetName);
        }

        public static string GetProximityPlacementGroupRef(string subId, string resourceGrpName, string proximityPlacementGroupName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.ProximityPlacementGroups, proximityPlacementGroupName);
        }

        public static string GetDedicatedHostGroupRef(string subId, string resourceGrpName, string dedicatedHostGroupName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.HostGroups, dedicatedHostGroupName);
        }

        public static string GetDedicatedHostRef(string subId, string resourceGrpName, string dedicatedHostGroupName, string dedicatedHostName)
        {
            return GetSubEntityReferenceId(subId, resourceGrpName, ApiConstants.HostGroups, dedicatedHostGroupName, ApiConstants.Hosts, dedicatedHostName);
        }

        public static string GetVMReferenceId(string subId, string resourceGrpName, string vmName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VirtualMachines, vmName);
        }

        public static string GetVMScaleSetReferenceId(string subId, string resourceGrpName, string vmssName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VMScaleSets, vmssName);
        }

        public static string GetCloudServiceReferenceId(string subId, string resourceGrpName, string cloudServiceName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.CloudServices, cloudServiceName);
        }

        private static string GetEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName);
        }

        private static string GetSubEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName, string subEntityType, string subEntityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}/{9}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName, subEntityType, subEntityName);
        }

        public static void DeleteIfExists(this IResourceGroupsOperations rgOps, string rgName)
        {
            try
            {
                rgOps.Delete(rgName);
            }
            catch (CloudException)
            {
                // Ignore
            }
        }

        
    }
}
