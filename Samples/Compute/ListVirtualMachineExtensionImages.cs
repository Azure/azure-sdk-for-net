// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ListVirtualMachineExtensionImages
{
    public class Program
    {
        /**
         * List all virtual machine extension image publishers and
         * list all virtual machine extension images published by Microsoft.OSTCExtensions, Microsoft.Azure.Extensions
         * by browsing through extension image publishers, types, and versions.
         */
        public static void RunSample(IAzure azure)
        {
            //=================================================================
            // List all virtual machine extension image publishers and
            // list all virtual machine extension images
            // published by Microsoft.OSTCExtensions and Microsoft.Azure.Extensions
            // y browsing through extension image publishers, types, and versions

            var publishers = azure
                    .VirtualMachineImages
                    .Publishers
                    .ListByRegion(Region.USEast);

            Utilities.Log("US East data center: printing list of \n"
                    + "a) Publishers and\n"
                    + "b) virtual machine images published by Microsoft.OSTCExtensions and Microsoft.Azure.Extensions");
            Utilities.Log("=======================================================");
            Utilities.Log("\n");

            foreach (var publisher in publishers)
            {
                Utilities.Log("Publisher - " + publisher.Name);

                if (StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Microsoft.OSTCExtensions") || 
                    StringComparer.OrdinalIgnoreCase.Equals(publisher.Name, "Microsoft.Azure.Extensions"))
                {
                    Utilities.Log("\n\n");
                    Utilities.Log("=======================================================");
                    Utilities.Log("Located " + publisher.Name);
                    Utilities.Log("=======================================================");
                    Utilities.Log("Printing entries as publisher/type/version");

                    foreach (var imageType in publisher.ExtensionTypes.List())
                    {
                        foreach (var version in imageType.Versions.List())
                        {
                            var image = version.GetImage();
                            Utilities.Log($"Image - {publisher.Name}/{image.TypeName}/{image.VersionName}");
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