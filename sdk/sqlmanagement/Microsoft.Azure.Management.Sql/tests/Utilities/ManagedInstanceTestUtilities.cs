// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql.Models;

namespace Sql.Tests
{
    public class ManagedInstanceTestUtilities
    {
        public static readonly string SubscriptionName = "WASD-TEST-R&D-SQLMI-CustomerExperience-Infra";
        public static readonly string SubscriptionId = "8313371e-0879-428e-b1da-6353575a9192";
        public static readonly string ResourceGroupName = "CustomerExperienceTeam_RG";
        public static readonly string SubnetResourceId = "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG/providers/Microsoft.Network/virtualNetworks/vnet-mi-tooling/subnets/ManagedInstance";
        public static readonly string VNetName = "vnet-mi-tooling";
        public static readonly string Username = "dummylogin";
        public static readonly string Password = Guid.NewGuid().ToString();
        public static readonly string Region = "westcentralus";
        public static readonly string DEFAULT_MC = "SQL_Default";
        public static readonly Dictionary<string, string> Tags = new Dictionary<string, string>
        {
            { "test", "azure-sdk-for-net" }
        };
        public static ResourceIdentity Identity = new ResourceIdentity()
        {
            Type = ResourceIdentityType.SystemAssigned.ToString()
        };

        public static readonly string UAMI = "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourcegroups/customerexperienceteam_rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/wasd-wcus-identity";

        public static string getManagedInstanceFullMaintenanceResourceid()
        {
            return string.Format(
                "/subscriptions/{0}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{1}",
                SubscriptionId,
                DEFAULT_MC);
        }

        public static IDictionary<string, UserIdentity> UserIdentity
        {
            get
            {
                var i = new Dictionary<string, UserIdentity>();
                i.Add(UAMI, new UserIdentity());
                return i;
            }
        }
    }
}
