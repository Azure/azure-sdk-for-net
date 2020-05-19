Quickstart Tutorial - Resource Management (Preview Libraries)
=============================================================

We are excited to announce that a new set of management libraries are
now in Public Preview. Those packages share a number of new features
such as Azure Identity support, HTTP pipeline, error-handling.,etc, and
they also follow the new Azure SDK guidelines which create easy-to-use
APIs that are idiomatic, compatible, and dependable.

You can find the details of those new libraries
[here](https://azure.github.io/azure-sdk/releases/latest/#dotnet)

In this basic quickstart guide, we will walk you through how to
authenticate to Azure using the preview libraries and start interacting
with Azure resources. There are several possible approaches to
authentication. This document illustrates the most common scenario

Prerequisites
-------------

You will need the following values to authenticate to Azure

-   **Subscription ID**
-   **Client ID**
-   **Client Secret**
-   **Tenant ID**

These values can be obtained from the portal, here's the instructions:

### Get Subscription ID

1.  Login into your Azure account
2.  Select Subscriptions in the left sidebar
3.  Select whichever subscription is needed
4.  Click on Overview
5.  Copy the Subscription ID

### Get Client ID / Client Secret / Tenant ID

For information on how to get Client ID, Client Secret, and Tenant ID,
please refer to [this
document](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal)

### Setting Environment Variables

After you obtained the values, you need to set the following values as
your environment variables

-   `AZURE_CLIENT_ID`
-   `AZURE_CLIENT_SECRET`
-   `AZURE_TENANT_ID`
-   `AZURE_SUBSCRIPTION_ID`

To set the following environment variables on your development system:

Windows (Note: Administrator access is required)

1.  Open the Control Panel
2.  Click System Security, then System
3.  Click Advanced system settings on the left
4.  Inside the System Properties window, click the Environment
    Variables… button.
5.  Click on the property you would like to change, then click the Edit…
    button. If the property name is not listed, then click the New…
    button.

Linux-based OS :

    export AZURE_CLIENT_ID="__CLIENT_ID__"
    export AZURE_CLIENT_SECRET="__CLIENT_SECRET__"
    export AZURE_TENANT_ID="__TENANT_ID__"
    export AZURE_SUBSCRIPTION_ID="__SUBSCRIPTION_ID__"

Authentication and Creating Resource Management Client
------------------------------------------------------

Now that the environment is setup, all you need to do is to create an
authenticated client. Our default option is to use
**DefaultAzureCredential** and in this guide we have picked
**Resources** as our target service, but you can set it up similarly for
any other service that you are using.

To authenticate to Azure and create a management client, simply do the
following:

    using Azure.Identity;
    using Azure.Management.Resource;
    using Azure.Management.Resource.Models;
    using System;
    ...
    var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
    var resourceClient = new ResourceClient(subscriptionId, new DefaultAzureCredential(true));

More information and different authentication approaches using Azure
Identity can be found in [this
document](https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

Managing Resources
------------------

Now that we are authenticated, we can use our management client to make
API calls. Let's create a resource group and demonstrate management
client's usage

**Create a resource group**

    location = "myLocation";
    groupName = "myResourceGroupName";
    var result = await resourceClient.ResourceGroups.CreateOrUpdateAsync(groupName, new ResourceGroup(location));

**Update a resource group**

    ...
    var tags = new Dictionary<string,string>();
    tags.Add("environment","test");
    tags.Add("department","tech");
    resourceGroup.Tags = tags;

    var updated = await resourceClient.ResourceGroups.CreateOrUpdateAsync(groupName, resourceGroup);

**List all resource groups**

    var rgs = await resourceClient.ResourceGroups.ListAsync();
    foreach (ResourceGroup rg in rgs) {
        Console.WriteLine(rg.Name);
    }

**Delete a resource group**

    await resourceClient.ResourceGroups.DeleteAsync(groupName);

Need help?
----------

-   File an issue via [Github
    Issues](https://github.com/Azure/azure-sdk-for-net/issues) and
    make sure you add the "Preview" label to the issue
-   Check [previous
    questions](https://stackoverflow.com/questions/tagged/azure+.net)
    or ask new ones on StackOverflow using azure and .NET tags.

Contributing
------------

For details on contributing to this repository, see the contributing
guide.

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the Microsoft Open Source Code of Conduct. For
more information see the Code of Conduct FAQ or contact
<opencode@microsoft.com> with any additional questions or comments.
