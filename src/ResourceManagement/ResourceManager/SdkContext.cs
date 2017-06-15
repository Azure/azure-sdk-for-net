// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    public static class SdkContext
    {
        public delegate IResourceNamer ResourceNamerCreator(string name);

        public static AzureCredentialsFactory AzureCredentialsFactory { get; set; } = new AzureCredentialsFactory();

        public static ResourceNamerCreator CreateResourceNamer { get; set; } = new ResourceNamerCreator((name) => new ResourceNamer(name));

        public static DelayProvider DelayProvider { get; set; } = new DelayProvider();

        public static string RandomResourceName(string prefix, int maxLen)
        {
            var namer = CreateResourceNamer("");
            return namer.RandomName(prefix, maxLen);
        }
        public static string RandomGuid()
        {
            var namer = CreateResourceNamer("");
            return namer.RandomGuid();
        }
    }
}
