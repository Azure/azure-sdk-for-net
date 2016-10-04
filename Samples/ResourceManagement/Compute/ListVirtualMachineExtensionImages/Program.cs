// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;

namespace ListVirtualMachineExtensionImages
{
    /**
     * List all virtual machine extension image publishers and
     * list all virtual machine extension images published by Microsoft.OSTCExtensions, Microsoft.Azure.Extensions
     * by browsing through extension image publishers, types, and versions.
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
                // List all virtual machine extension image publishers and
                // list all virtual machine extension images
                // published by Microsoft.OSTCExtensions and Microsoft.Azure.Extensions
                // y browsing through extension image publishers, types, and versions

                var publishers = azure
                        .VirtualMachineImages
                        .Publishers
                        .ListByRegion(Region.US_EAST);

                Console.WriteLine("US East data center: printing list of \n"
                        + "a) Publishers and\n"
                        + "b) virtual machine images published by Microsoft.OSTCExtensions and Microsoft.Azure.Extensions");
                Console.WriteLine("=======================================================");
                Console.WriteLine("\n");

                foreach (var publisher in publishers)
                {
                    Console.WriteLine("Publisher - " + publisher.Name);

                    if (StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Microsoft.OSTCExtensions")
                            || StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Microsoft.Azure.Extensions"))
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Located " + publisher.Name);
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Printing entries as publisher/type/version");

                        foreach (var imageType in publisher.ExtensionTypes.List())
                        {
                            foreach (var version in imageType.Versions.List())
                            {
                                var image = version.GetImage();
                                Console.WriteLine($"Image - {publisher.Name}/{image.TypeName}/{image.VersionName}");
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