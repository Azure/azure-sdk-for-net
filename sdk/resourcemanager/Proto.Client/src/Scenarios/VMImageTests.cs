// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;

namespace Proto.Client
{
    class VMImageTests : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.DefaultSubscription;

            var defaultLocation = "westus2";
            var publisher = "TrendMicro.DeepSecurity";

            foreach (var t in subscription.GetVMImagines().ListTypes(defaultLocation, publisher))
            {
                Console.WriteLine(t.Data.Name);

                foreach (var v in subscription.GetVMImagines().ListVersions(defaultLocation, publisher, t.Data.Name))
                {
                    Console.WriteLine(v.Data.Name);
                }
            }
        }
    }
}
