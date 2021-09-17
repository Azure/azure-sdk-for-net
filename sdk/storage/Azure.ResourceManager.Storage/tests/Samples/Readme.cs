// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_StorageAccounts_AuthClient
using Azure.Identity;
using Azure.ResourceManager;
#if !SNIPPET
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
#endif

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            #endregion
        }
    }
}
