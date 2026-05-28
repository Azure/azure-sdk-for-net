// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_StorageAccounts_AuthClient_Namespaces
using Azure.Identity;
using Azure.ResourceManager;
#endregion
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Samples
{
    public class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ClientAuth()
        {
#region Snippet:Managing_StorageAccounts_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
#endregion
        }
    }
}
