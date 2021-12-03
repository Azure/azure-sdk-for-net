// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_Namespaces_AuthClient
using Azure.Identity;
#if !SNIPPET
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests.Samples
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
