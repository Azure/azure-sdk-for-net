# Azure Provisioning RedisEnterprise client library for .NET

Azure.Provisioning.RedisEnterprise simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.RedisEnterprise
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create A Redis Enterprise Cluster With Vector Database

This example demonstrates how to create a Redis Enterprise cluster with RediSearch and RedisJSON modules for vector database capabilities, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cache/redis-enterprise-vectordb/main.bicep).

```C# Snippet:RedisEnterpriseBasic
Infrastructure infra = new();
ProvisioningParameter principalId = new ProvisioningParameter("principalId", typeof(string))
{
    Description = "The principal ID of the user assigned identity to use for the Redis Enterprise cluster."
};
infra.Add(principalId);
RedisEnterpriseCluster redisEnterprise =
    new("redisEnterprise", "2022-01-01")
    {
        Sku = new RedisEnterpriseSku
        {
            Name = RedisEnterpriseSkuName.EnterpriseE10,
            Capacity = 2
        }
    };
infra.Add(redisEnterprise);
RedisEnterpriseDatabase database =
    new("redisDatabase", "2022-01-01")
    {
        Name = "default",
        Parent = redisEnterprise,
        EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
        ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
        Modules =
        [
            new RedisEnterpriseModule { Name = "RediSearch" },
            new RedisEnterpriseModule { Name = "RedisJSON" }
        ],
        Port = 10000
    };
infra.Add(database);
AccessPolicyAssignment accessPolicyAssignment =
    new("accessPolicyAssignment", "2022-01-01")
    {
        Parent = database,
        AccessPolicyName = "default",
        UserObjectId = principalId
    };
infra.Add(accessPolicyAssignment);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/