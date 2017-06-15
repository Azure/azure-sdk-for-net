// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ListVirtualMachineImages
{
    public class Program
    {
        /**
         * List all virtual machine image publishers and
         * list all virtual machine images published by Canonical, Red Hat and
         * SUSE by browsing through locations, publishers, offers, SKUs and images.
         */
        public static void RunSample(IAzure azure)
        {
            //=================================================================
            // List all virtual machine image publishers and
            // list all virtual machine images
            // published by Canonical, Red Hat and SUSE
            // by browsing through locations, publishers, offers, SKUs and images

            var publishers = azure
                    .VirtualMachineImages
                    .Publishers
                    .ListByRegion(Region.USEast);

            Utilities.Log("US East data center: printing list of \n" + 
                            "a) Publishers and\n" + 
                            "b) Images published by Canonical, Red Hat and Suse");
            Utilities.Log("=======================================================");
            Utilities.Log("\n");

            foreach (var publisher in publishers)
            {
                Utilities.Log("Publisher - " + publisher.Name);

                if (StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Canonical") || 
                    StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Suse") || 
                    StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "RedHat"))
                {
                    Utilities.Log("\n\n");
                    Utilities.Log("=======================================================");
                    Utilities.Log("Located " + publisher.Name);
                    Utilities.Log("=======================================================");
                    Utilities.Log("Printing entries as publisher/offer/sku/image/version");

                    foreach (var offer in publisher.Offers.List())
                    {
                        foreach (var sku in offer.Skus.List())
                        {
                            foreach (var image in sku.Images.List())
                            {
                                Utilities.Log($"Image - {publisher.Name}/{offer.Name}/{sku.Name}/{image.Version}");
                            }
                        }
                    }

                    Utilities.Log("\n\n");
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}