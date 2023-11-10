// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Blueprint.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Blueprint.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Assignment

        #endregion

        #region Blueprint
        public static BlueprintData GetBlueprintData()
        {
            BlueprintData data = new BlueprintData()
            {
                Description = "blueprint contains all artifact kinds {'template', 'rbac', 'policy'}",
                TargetScope = BlueprintTargetScope.Subscription,
                Parameters =
                {
                    ["costCenter"] = new ParameterDefinition(TemplateParameterType.String)
                    {
                        DisplayName = "force cost center tag for all resources under given subscription.",
                    },
                    ["owners"] = new ParameterDefinition(TemplateParameterType.Array)
                    {
                        DisplayName = "assign owners to subscription along with blueprint assignment.",
                    },
                    ["storageAccountType"] = new ParameterDefinition(TemplateParameterType.String)
                    {
                        DisplayName = "storage account type.",
                    },
                },
                ResourceGroups =
                {
                    ["storageRG"] = new ResourceGroupDefinition()
                    {
                    DisplayName = "storage resource group",
                    Description = "Contains storageAccounts that collect all shoebox logs.",
                    },
                },
            };
            return data;
        }

        public static void AssertBlueprint(BlueprintData data1, BlueprintData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Status , data2.Status);
            Assert.AreEqual (data1.Description , data2.Description);
            Assert.AreEqual(data1.Parameters.ElementAt(0), data2.Parameters.ElementAt(0));
            Assert.AreEqual(data1.Parameters.ElementAt(1), data2.Parameters.ElementAt(1));
        }
        #endregion

        #region publishedBlueprint
        public static PublishedBlueprintData GetPublishedBlueprintData()
        {
            return new PublishedBlueprintData()
            {
            };
        }
        public static void AssertPublishedBlueprintData(PublishedBlueprintData data1, PublishedBlueprintData data2)
        {
            AssertResource(data1 , data2);
        }
        #endregion
    }
}
