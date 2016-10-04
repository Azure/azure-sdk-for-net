// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;

namespace ListVirtualMachineImages
{
    /**
     * List all virtual machine image publishers and
     * list all virtual machine images published by Canonical, Red Hat and
     * SUSE by browsing through locations, publishers, offers, SKUs and images.
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                //=================================================================
                // List all virtual machine image publishers and
                // list all virtual machine images
                // published by Canonical, Red Hat and SUSE
                // by browsing through locations, publishers, offers, SKUs and images

                var publishers = azure
                        .VirtualMachineImages
                        .Publishers
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

                        foreach (var offer in publisher.Offers.List())
                        {
                            foreach (var sku in offer.Skus.List())
                            {
                                foreach (var image in sku.Images.List())
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