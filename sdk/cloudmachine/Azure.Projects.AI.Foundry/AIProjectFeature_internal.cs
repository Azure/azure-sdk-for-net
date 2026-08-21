// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

namespace Azure.Provisioning.AIFoundry;

internal class AIFoundryCognitiveServiceCdk : NamedProvisionableConstruct
{
    public AIFoundryCognitiveServiceCdk(string bicepIdentifier, string name)
        : base(bicepIdentifier)
    {
        Name = name;
    }

    public string Name { get; set; }
    protected override IEnumerable<BicepStatement> Compile()
    {
        ResourceStatement cs = new(
            BicepIdentifier,
            new StringLiteralExpression("Microsoft.CognitiveServices/accounts@2021-10-01"),
                new ObjectExpression(
                new PropertyExpression("name", Name),
                new PropertyExpression("location", new IdentifierExpression("location")),
                new PropertyExpression("sku",
                    new ObjectExpression(
                        new PropertyExpression("name", "S0")
                    )
                ),
                new PropertyExpression("kind", "AIServices"),
                new PropertyExpression("identity",
                    new ObjectExpression(
                        new PropertyExpression("type", "UserAssigned"),
                        new PropertyExpression("userAssignedIdentities",
                            new ObjectExpression(
                                new PropertyExpression("${cm_identity.id}", new ObjectExpression())
                            )
                        )
                    )
                ),
                new PropertyExpression("properties",
                    new ObjectExpression(
                        new PropertyExpression("customSubDomainName", Name),
                        new PropertyExpression("disableLocalAuth", true)
                    )
                )
            )
        );
        return [cs];
    }
}

internal class AIFoundryHubCdk : NamedProvisionableConstruct
{
    public AIFoundryHubCdk(string bicepIdentifier, string name)
        : base(bicepIdentifier)
    {
        Name = name;
        FriendlyName = name;
    }

    public string Name { get; set; }

    public string FriendlyName { get; set; }

    public UserAssignedIdentity Identity { get; set; }

    protected override IEnumerable<BicepStatement> Compile()
    {
        ResourceStatement hub = new(
            BicepIdentifier,
            new StringLiteralExpression("Microsoft.MachineLearningServices/workspaces@2023-08-01-preview"),
                new ObjectExpression(
                new PropertyExpression("name", Name),
                new PropertyExpression("location", new IdentifierExpression("location")),
                new PropertyExpression("kind", "hub"),
                new PropertyExpression("identity",
                    new ObjectExpression(
                        new PropertyExpression("type", "SystemAssigned")
                    )
                ),
                new PropertyExpression("properties",
                    new ObjectExpression(
                        new PropertyExpression("friendlyName", FriendlyName),
                        new PropertyExpression("publicNetworkAccess", "Enabled")
                    )
                )
            )
        );
        return [hub];
    }
}

internal class AIFoundryProjectCdk : ProvisionableResource
{
    public AIFoundryProjectCdk(string bicepIdentifier, string name, AIFoundryHubCdk hub)
        : base(bicepIdentifier, new Core.ResourceType("Microsoft.MachineLearningServices/workspaces"), "2023-08-01-preview")
    {
        Name = name;
        Hub = hub;
        FriendlyName = name;
    }

    public string Name { get; set; }
    public AIFoundryHubCdk Hub { get; set; }

    public string FriendlyName { get; set; }

    public List<AIFoundryConnectionCdk> Connections { get; } = new List<AIFoundryConnectionCdk>();
    protected override IEnumerable<BicepStatement> Compile()
    {
        List<ResourceStatement> resources = new();

        var hubId = new MemberExpression(new IdentifierExpression(Hub.BicepIdentifier), "id");

        ResourceStatement project = new(
            BicepIdentifier,
            new StringLiteralExpression($"{base.ResourceType}@{base.ResourceVersion}"),
                new ObjectExpression(
                new PropertyExpression("name", Name),
                new PropertyExpression("location", new IdentifierExpression("location")),
                new PropertyExpression("kind", "Project"),
                new PropertyExpression("identity",
                    new ObjectExpression(
                        new PropertyExpression("type", "SystemAssigned")
                    )
                ),
                new PropertyExpression("properties",
                    new ObjectExpression(
                        new PropertyExpression("friendlyName", FriendlyName),
                        new PropertyExpression("hubResourceId", hubId),
                        new PropertyExpression("publicNetworkAccess", "Enabled")
                    )
                )
            )
        );
        resources.Add(project);

        return resources;
    }
}

// https://learn.microsoft.com/en-us/azure/templates/microsoft.machinelearningservices/workspaces/connections?pivots=deployment-language-bicep
internal class AIFoundryConnectionCdk : NamedProvisionableConstruct
{
    public AIFoundryConnectionCdk(string bicepIdentifier, string name, string target, AIFoundryProjectCdk parent)
        : base(bicepIdentifier)
    {
        Name = name;
        Target = target;
        Parent = parent;
    }

    public string Name { get; set; }
    public string Category { get; set; } = "AzureOpenAI";
    public string Target { get; set; }

    public AIFoundryProjectCdk Parent { get; set; }

    protected override IEnumerable<BicepStatement> Compile()
    {
        ResourceStatement c = new(
            BicepIdentifier,
            new StringLiteralExpression("Microsoft.MachineLearningServices/workspaces/connections@2024-01-01-preview"),
                new ObjectExpression(
                new PropertyExpression("name", Name),
                new PropertyExpression("parent", new IdentifierExpression(Parent.BicepIdentifier)),
                new PropertyExpression("properties",
                    new ObjectExpression(
                        new PropertyExpression("category", Category),
                        new PropertyExpression("target", Target),
                        new PropertyExpression("authType", "AAD"),
                        new PropertyExpression("isSharedToAll", true),
                        new PropertyExpression("metadata",
                            new ObjectExpression(
                                new PropertyExpression("ApiType", "Azure"),
                                new PropertyExpression("ResourceId", new MemberExpression(new IdentifierExpression(Parent.BicepIdentifier), "id"))
                            )
                        )
                    )
                )
            )
        );
        return [c];
    }
}
