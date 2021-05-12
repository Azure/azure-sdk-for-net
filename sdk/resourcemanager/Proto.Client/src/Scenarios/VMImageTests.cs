// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Proto.Compute;

namespace Proto.Client
{
    class VmImageTests : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            Execute(client);
            ExecuteAsync(client).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private void Execute(ArmClient client)
        {
            var subscription = client.DefaultSubscription;

            var defaultLocation = ((LocationData)Context.Loc).Name;
            var defaultPublisher = "redhat";

            Console.WriteLine($"--------Start listing all VMImage publishers at {defaultLocation}--------");
            foreach (var p in subscription.GetVmImages().ListPublishers(defaultLocation).Take(50))
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine($"--------Start listing all VMImage offers for Publisher {defaultPublisher}--------");
            foreach (var o in subscription.GetVmImages().ListOffers(defaultLocation, defaultPublisher).Take(3))
            {
                Console.WriteLine($"offer:\t{o.Name}");

                foreach (var s in subscription.GetVmImages().ListSkus(defaultLocation, defaultPublisher, o.Name).Take(3))
                {
                    Console.WriteLine($"\tsku:\t{s.Name}");

                    foreach (var v in subscription.GetVmImages().ListVersions(defaultLocation, defaultPublisher, o.Name, s.Name).Take(2))
                    {
                        Console.WriteLine($"\t\tversion:\t{v.Name}");

                        var vmImage = subscription.GetVmImages().Get(
                            defaultLocation,
                            defaultPublisher,
                            o.Name,
                            s.Name,
                            v.Name);
                        Console.WriteLine($"vmImage:\t\t\tVM Image:\t{vmImage.Value.Id}");
                    }
                }
            }

            Console.WriteLine($"--------Start listing all VMExtensionImage offers for Publisher {defaultPublisher}--------");
            foreach (var t in subscription.GetVmExtensionImages().ListTypes(defaultLocation, defaultPublisher).Take(5))
            {
                Console.WriteLine($"\tType:\t{t.Name}");

                foreach (var v in subscription.GetVmExtensionImages().ListVersions(defaultLocation, defaultPublisher, t.Name).Take(5))
                {
                    Console.WriteLine($"\t\tOffer:\t{v.Name}");
                }
            }

            if (!subscription.GetVmExtensionImages().DoesExist(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "1.2.0")
              || subscription.GetVmExtensionImages().DoesExist(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "0.0.0"))
            {
                Console.WriteLine("!!!!!!! DoesExist check failed!");
            }

            if (subscription.GetVmExtensionImages().TryGet(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "1.2.0") == null
                || subscription.GetVmExtensionImages().TryGet(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "0.0.0") != null)
            {
                Console.WriteLine("!!!!!!! DoesExist check failed!");
            }

            Console.WriteLine($"-------- All Sync VM image API test passed.--------");
        }

        private async Task ExecuteAsync (ArmClient client)
        {
            var subscription = client.DefaultSubscription;

            var defaultLocation = ((LocationData)Context.Loc).Name;
            var defaultPublisher = "redhat";

            Console.WriteLine($"--------Start listing all VMImage publishers at {defaultLocation}--------");
            foreach (var p in (await subscription.GetVmImages().ListPublishersAsync(defaultLocation)).Take(50))
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine($"--------Start listing all VMImage offers for Publisher {defaultPublisher}--------");
            foreach (var o in (await subscription.GetVmImages().ListOffersAsync(defaultLocation, defaultPublisher)).Take(3))
            {
                Console.WriteLine($"offer:\t{o.Name}");

                foreach (var s in (await subscription.GetVmImages().ListSkusAsync(defaultLocation, defaultPublisher, o.Name)).Take(3))
                {
                    Console.WriteLine($"\tsku:\t{s.Name}");

                    foreach (var v in (await subscription.GetVmImages().ListVersionsAsync(defaultLocation, defaultPublisher, o.Name, s.Name)).Take(2))
                    {
                        Console.WriteLine($"\t\tversion:\t{v.Name}");

                        var vmImage = await subscription.GetVmImages().GetAsync(
                            defaultLocation,
                            defaultPublisher,
                            o.Name,
                            s.Name,
                            v.Name);
                        Console.WriteLine($"vmImage:\t\t\tVM Image:\t{vmImage.Value.Id}");
                    }
                }
            }

            Console.WriteLine($"--------Start listing all VMExtensionImage offers for Publisher {defaultPublisher}--------");
            foreach (var t in (await subscription.GetVmExtensionImages().ListTypesAsync(defaultLocation, defaultPublisher)).Take(5))
            {
                Console.WriteLine($"\tType:\t{t.Name}");

                foreach (var v in (await subscription.GetVmExtensionImages().ListVersionsAsync(defaultLocation, defaultPublisher, t.Name)).Take(5))
                {
                    Console.WriteLine($"\t\tOffer:\t{v.Name}");
                }
            }

            if (!await subscription.GetVmExtensionImages().DoesExistAsync(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "1.2.0")
              || await subscription.GetVmExtensionImages().DoesExistAsync(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "0.0.0"))
            {
                Console.WriteLine("!!!!!!! DoesExist check failed!");
            }

            if (await subscription.GetVmExtensionImages().TryGetAsync(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "1.2.0") == null
                || await subscription.GetVmExtensionImages().TryGetAsync(defaultLocation, "Microsoft.Azure.Extensions", "DockerExtension", "0.0.0") != null)
            {
                Console.WriteLine("!!!!!!! DoesExist check failed!");
            }

            Console.WriteLine($"-------- All Async VM image API test passed.--------");
        }
    }
}
