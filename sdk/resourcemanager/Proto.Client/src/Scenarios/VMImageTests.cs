// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            var defaultPublisher = "redhat";

            foreach (var p in subscription.GetVmImages().ListPublishers(defaultLocation))
            {
                Console.WriteLine(p.Name);
            }

            foreach (var o in subscription.GetVmImages().ListOffers(defaultLocation, defaultPublisher))
            {
                Console.WriteLine($"offer:\t{o.Name}");

                foreach (var s in subscription.GetVmImages().ListSkus(defaultLocation, defaultPublisher, o.Name))
                {
                    Console.WriteLine($"sku:\t{s.Name}");

                    foreach (var v in subscription.GetVmImages().ListVersions(defaultLocation, defaultPublisher, o.Name, s.Name).Where(v => v.Name == "7.8.20210222"))
                    {
                        Console.WriteLine($"version:\t{v.Name}");

                        var vmImage = subscription.GetVmImages().Get(
                            defaultLocation,
                            defaultPublisher,
                            o.Name,
                            s.Name,
                            v.Name);
                        Console.WriteLine($"vmImage:\t{vmImage.Value.Id}");
                    }
                }
            }

            foreach (var t in subscription.GetVmExtensionImages().ListTypes(defaultLocation, defaultPublisher))
            {
                Console.WriteLine(t.Name);

                foreach (var v in subscription.GetVmExtensionImages().ListVersions(defaultLocation, defaultPublisher, t.Name))
                {
                    Console.WriteLine(v.Name);
                }
            }
        }
    }
}
