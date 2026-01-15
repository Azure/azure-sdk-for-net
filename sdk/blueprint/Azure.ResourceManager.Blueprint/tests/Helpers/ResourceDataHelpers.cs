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
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        #region ArtifactData
        //TemplateData
        public static void AssertArtifactData(ArtifactData data1, ArtifactData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
        }
        public static ArtifactData GetTemplateArtifactData()
        {
            ArtifactData data = new TemplateArtifact(BinaryData.FromObjectAsJson(new Dictionary<string, object>()
            {
                ["$schema"] = "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
                ["contentVersion"] = "1.0.0.0",
                ["outputs"] = new Dictionary<string, object>()
                {
                    ["storageAccountName"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string",
                        ["value"] = "[variables('storageAccountName')]"
                    }
                },
                ["parameters"] = new Dictionary<string, object>()
                {
                    ["storageAccountType"] = new Dictionary<string, object>()
                    {
                        ["type"] = "string",
                        ["allowedValues"] = new object[] { "Standard_LRS", "Standard_GRS", "Standard_ZRS", "Premium_LRS" },
                        ["defaultValue"] = "Standard_LRS",
                        ["metadata"] = new Dictionary<string, object>()
                        {
                            ["description"] = "Storage Account type"
                        }
                    }
                },
                ["resources"] = new object[] { new Dictionary<string, object>()
                {
                    ["name"] = "[variables('storageAccountName')]",
                    ["type"] = "Microsoft.Storage/storageAccounts",
                    ["apiVersion"] = "2016-01-01",
                    ["kind"] = "Storage",
                    ["location"] = "[resourceGroup().location]",
                    ["properties"] = new Dictionary<string, object>()
                        {
                        },
                    ["sku"] = new Dictionary<string, object>()
                    {
                    ["name"] = "[parameters('storageAccountType')]"}} },
                    ["variables"] = new Dictionary<string, object>()
                {
                    ["storageAccountName"] = "[concat(uniquestring(resourceGroup().id), 'standardsa')]"
                }
            }), new Dictionary<string, ParameterValue>()
            {
                ["storageAccountType"] = new ParameterValue()
                {
                    Value = BinaryData.FromString("\"Standard_LRS\""),
                },
            })
            {
                ResourceGroup = "storageRG",
            };
            return data;
        }
        public static void AssertTemplateArtifactData(TemplateArtifact data1, TemplateArtifact data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.DisplayName, Is.EqualTo(data1.DisplayName));
            Assert.That(data2.Template, Is.EqualTo(data1.Template));
        }
        //PolicyAssignmentArtifact
        public static ArtifactData GetPolicyAssignmentArtifactData()
        {
            ArtifactData data = new PolicyAssignmentArtifact("/providers/Microsoft.Authorization/policyDefinitions/1e30110a-5ceb-460c-a204-c1c3969c6d62", new Dictionary<string, ParameterValue>()
            {
                ["tagName"] = new ParameterValue()
                {
                    Value = BinaryData.FromString("\"costCenter\""),
                },
                ["tagValue"] = new ParameterValue()
                {
                    Value = BinaryData.FromString("\"Standard_LRS\""),
                },
            })
            {
                DisplayName = "force costCenter tag on all resources",
            };
            return data;
        }
        public static void AssertPolicyArtifactData(PolicyAssignmentArtifact data1, PolicyAssignmentArtifact data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.DisplayName, Is.EqualTo(data1.DisplayName));
            Assert.That(data2.PolicyDefinitionId, Is.EqualTo(data1.PolicyDefinitionId));
        }
        //RoleAssignmentArtifact
        public static ArtifactData GetRoleAssignmentData()
        {
            ArtifactData data = new RoleAssignmentArtifact("/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7", BinaryData.FromString("\"[parameters('owners')]\""))
            {
                DisplayName = "enforce owners of given subscription",
            };
            return data;
        }
        public static void AssertRoleAssignmentArtifactData(RoleAssignmentArtifact data1, RoleAssignmentArtifact data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.DisplayName, Is.EqualTo(data1.DisplayName));
            Assert.That(data2.RoleDefinitionId, Is.EqualTo(data1.RoleDefinitionId));
        }
        #endregion

        #region Assignment
        // Assignment Data
        public static AssignmentData GetAssignmentData(string blueprintId)
        {
            ParameterValue[] owners =
            {
                new ParameterValue()
                {
                    Value = BinaryData.FromString("\"johnDoe@contoso.com\"")
                },
                new ParameterValue()
                {
                    Value = BinaryData.FromString("\"johnsteam@contoso.com\"")
                },
            };
            IDictionary<string, ParameterValue> parameter = new Dictionary<string, ParameterValue>()
            {
                ["storageAccountType"] = new ParameterValue()
                {
                    Value = BinaryData.FromString("\"Standard_LRS\"")
                },
                ["costCenter"] = new ParameterValue()
                {
                    Value = BinaryData.FromString("\"Contoso/Online/Shopping/Production\"")
                },
                ["owners"] = new ParameterValue()
                {
                    Value = BinaryData.FromObjectAsJson(new ParameterValue[]
                    {
                        new ParameterValue()
                {
                    Value = BinaryData.FromString("\"johnDoe@contoso.com\"")
                },
                new ParameterValue()
                {
                    Value = BinaryData.FromString("\"johnsteam@contoso.com\"")
                },
                    })
                }
            };
            IDictionary<string, ResourceGroupValue> resourceGroup = new Dictionary<string, ResourceGroupValue>()
            {
                ["storageRG"] = new ResourceGroupValue()
                {
                    Name = "defaultRG",
                    Location = AzureLocation.EastUS
                }
            };
            AssignmentData data = new AssignmentData(new Models.ManagedServiceIdentity(Models.ManagedServiceIdentityType.SystemAssigned), parameter, resourceGroup, AzureLocation.EastUS)
            {
                Description = "sdk test assignment",
                BlueprintId = blueprintId
            };
            return data;
        }

        public static void AssertAssignmentData(AssignmentData data1, AssignmentData data2)
        {
            AssertResource(data1, data2);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            Assert.That(data2.Location, Is.EqualTo(data1.Location));
        }
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
            //Assert.AreEqual(data1.Status , data2.Status);
            Assert.That(data2.Description, Is.EqualTo(data1.Description));
            //Assert.AreEqual(data1.Parameters., data2.Parameters.ElementAt(0).Value);
            //Assert.AreEqual(data1.Parameters.ElementAt(1), data2.Parameters.ElementAt(1));
        }
        #endregion

        #region publishedBlueprint
        public static PublishedBlueprintData GetPublishedBlueprintData(string printName)
        {
            return new PublishedBlueprintData()
            {
                Description = "published for Assignment",
                BlueprintName = printName,
            };
        }
        public static void AssertPublishedBlueprintData(PublishedBlueprintData data1, PublishedBlueprintData data2)
        {
            AssertResource(data1 , data2);
        }
        #endregion
    }
}
