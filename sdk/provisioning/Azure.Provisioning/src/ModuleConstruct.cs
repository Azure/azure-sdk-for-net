// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning
{
    internal class ModuleConstruct : Construct
    {
        public ModuleConstruct(ModuleResource resource)
            : base(
                resource.Scope,
                GetScopeName(resource.Resource),
                ResourceToConstructScope(resource.Resource),
                tenant: GetTenant(resource.Resource),
                subscription: GetSubscription(resource.Resource),
                resourceGroup: resource.Resource as ResourceGroup)
        {
        }

        private static string GetScopeName(Resource resource)
        {
            // for subscriptions we cannot use the Id.Name as 
            var prefix = resource is Subscription ? resource.Name : resource.Id.Name.Replace('-', '_');
            return $"{prefix}_module";
        }

        public bool IsRoot { get; set; }

        private static Tenant? GetTenant(Resource resource)
        {
            return resource switch
            {
                Tenant tenant => tenant,
                Subscription sub => (Tenant) sub.Parent!,
                ResourceGroup rg => (Tenant) rg.Parent!.Parent!,
                _ => null,
            };
        }

        private static Subscription? GetSubscription(Resource resource)
        {
            return resource switch
            {
                Subscription subscription => subscription,
                ResourceGroup rg => (Subscription) rg.Parent!,
                _ => null,
            };
        }

        private static ConstructScope ResourceToConstructScope(Resource resource)
        {
            return resource switch
            {
                Tenant => ConstructScope.Tenant,
                ResourceManager.Subscription => ConstructScope.Subscription,
                //TODO managementgroup support
                ResourceManager.ResourceGroup => ConstructScope.ResourceGroup,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
