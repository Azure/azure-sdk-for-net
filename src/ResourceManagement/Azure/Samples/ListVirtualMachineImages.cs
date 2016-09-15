using Microsoft.Azure.Management;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;

namespace Samples
{
    /**
     * List all virtual machine image publishers and
     * list all virtual machine images published by Canonical, Red Hat and
     * SUSE by browsing through locations, publishers, offers, SKUs and images.
     */

    public class ListVirtualMachineImages
    {
        public static void TestListVirtualMachineImages()
        {
            try
            {
                //=================================================================
                // Authenticate

                var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

                //=================================================================
                // List all virtual machine image publishers and
                // list all virtual machine images
                // published by Canonical, Red Hat and SUSE
                // by browsing through locations, publishers, offers, SKUs and images

                var publishers = azure
                        .VirtualMachineImages
                        .Publishers()
                        .ListByRegion(Region.US_EAST);

                Console.WriteLine("US East data center: printing list of \n"
                        + "a) Publishers and\n"
                        + "b) Images published by Canonical, Red Hat and Suse");
                Console.WriteLine("=======================================================");
                Console.WriteLine("\n");

                foreach (var publisher in publishers)
                {
                    Console.WriteLine("Publisher - " + publisher.Name);

                    if (StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Canonical")
                            || StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Suse")
                            || StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "RedHat"))
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Located " + publisher.Name);
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Printing entries as publisher/offer/sku/image/version");

                        foreach (var offer in publisher.Offers().List())
                        {
                            foreach (var sku in offer.Skus().List())
                            {
                                foreach (var image in sku.Images().List())
                                {
                                    Console.WriteLine($"Image - {publisher.Name}/{offer.Name}/{sku.Name}/{image.Version}");
                                }
                            }
                        }

                        Console.WriteLine("\n\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}