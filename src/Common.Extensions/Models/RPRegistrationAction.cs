// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Management;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Common.Extensions.Models
{
    public class RPRegistrationAction : IClientAction
    {
        /// <summary>
        /// Registers resource providers for Sparta.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        private void RegisterResourceManagerProviders<T>(AzureContext context) where T : ServiceClient<T>
        {
            var providersToRegister = RequiredResourceLookup.RequiredProvidersForResourceManager<T>();
            var registeredProviders = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders);
            var unregisteredProviders = providersToRegister.Where(p => !registeredProviders.Contains(p)).ToList();
            var successfullyRegisteredProvider = new List<string>();
            SubscriptionCloudCredentials creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);

            if (unregisteredProviders.Count > 0)
            {
                using (var client = ClientFactory.CreateCustomClient<ResourceManagementClient>(creds, context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
                {
                    foreach (string provider in unregisteredProviders)
                    {
                        try
                        {
                            client.Providers.Register(provider);
                            successfullyRegisteredProvider.Add(provider);
                        }
                        catch
                        {
                            // Ignore this as the user may not have access to service management endpoint or the provider is already registered
                        }
                    }
                }

                UpdateSubscriptionRegisteredProviders(context.Subscription, successfullyRegisteredProvider);
            }
        }

        /// <summary>
        /// Registers resource providers for RDFE.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        private void RegisterServiceManagementProviders<T>(AzureContext context) where T : ServiceClient<T>
        {
            var credentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            var providersToRegister = RequiredResourceLookup.RequiredProvidersForServiceManagement<T>();
            var registeredProviders = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders);
            var unregisteredProviders = providersToRegister.Where(p => !registeredProviders.Contains(p)).ToList();
            var successfullyRegisteredProvider = new List<string>();

            if (unregisteredProviders.Count > 0)
            {
                using (var client = new ManagementClient(credentials, context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
                {
                    foreach (var provider in unregisteredProviders)
                    {
                        try
                        {
                            client.Subscriptions.RegisterResource(provider);
                        }
                        catch (CloudException ex)
                        {
                            if (ex.Response.StatusCode != HttpStatusCode.Conflict && ex.Response.StatusCode != HttpStatusCode.NotFound)
                            {
                                // Conflict means already registered, that's OK.
                                // NotFound means there is no registration support, like Windows Azure Pack.
                                // Otherwise it's a failure.
                                throw;
                            }
                        }
                        successfullyRegisteredProvider.Add(provider);
                    }
                }

                UpdateSubscriptionRegisteredProviders(context.Subscription, successfullyRegisteredProvider);
            }
        }

        private void UpdateSubscriptionRegisteredProviders(AzureSubscription subscription, List<string> providers)
        {
            if (providers != null && providers.Count > 0)
            {
                subscription.SetOrAppendProperty(AzureSubscription.Property.RegisteredResourceProviders,
                    providers.ToArray());
                try
                {
                    ProfileClient profileClient = new ProfileClient();
                    profileClient.AddOrSetSubscription(subscription);
                    profileClient.Profile.Save();
                }
                catch (KeyNotFoundException)
                {
                    // if using a subscription data file, do not write registration to disk
                    // long term solution is using -Profile parameter
                }
            }
        }

        public void Apply<TClient>(TClient client, AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            Debug.Assert(ClientFactory != null);

            if (endpoint == AzureEnvironment.Endpoint.ServiceManagement)
            {
                RegisterServiceManagementProviders<TClient>(context);
            }
            else if (endpoint == AzureEnvironment.Endpoint.ResourceManager)
            {
                RegisterResourceManagerProviders<TClient>(context);
            }
        }

        public IClientFactory ClientFactory { get; set; }
    }
}
