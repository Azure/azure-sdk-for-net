// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
    public class ApiVersions
    {
        private ProvidersOperations ProviderOperations;
        private ArmClientOptions _clientOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersions"/> class.
        /// </summary>
        internal ApiVersions(ArmClientOptions clientOptions)
        {
            BuildApiTable(clientOptions);
            _clientOptions = clientOptions;
            ProviderOperations = null;
        }

        /// <summary>
        /// Make a provider resource client class.
        /// </summary>
        internal void SetProviderClient(TokenCredential credential, Uri baseUri, string subscription)
        {
            ProviderOperations = new ResourcesManagementClient(
            baseUri,
            subscription,
            credential,
            _clientOptions.Convert<ResourcesManagementClientOptions>()).Providers;
        }

        private Dictionary<string, PropertyWrapper> _loadedResourceToApiVersions = new Dictionary<string, PropertyWrapper>();
        private Dictionary<string, string> _nonLoadedResourceToApiVersion = new Dictionary<string, string>();

        private void BuildApiTable(ArmClientOptions clientOptions)
        {
            var methods = GetExtensionMethods();
            foreach (var method in methods)
            {
                if (method.Name.EndsWith("RestApiVersions", StringComparison.Ordinal))
                {
                    var apiObject = method.Invoke(null, new object[] { clientOptions });
                    var properties = apiObject.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        if (prop.GetValue(apiObject) is ApiVersionsBase propVal)
                        {
                            var key = propVal.ResourceType;
                            _loadedResourceToApiVersions.Add(key.ToString(), new PropertyWrapper(prop, apiObject));
                        }
                    }
                }
            }
        }

        private static IEnumerable<MethodInfo> GetExtensionMethods()
        {
            // See TODO ADO #5692
            var results =
                        from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        where assembly.GetName().ToString().StartsWith("Azure.", StringComparison.Ordinal) || assembly.GetName().ToString().StartsWith("Proto.", StringComparison.Ordinal)
                        from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested && type.Name.Equals("AzureResourceManagerClientOptionsExtensions", StringComparison.Ordinal)
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == typeof(ArmClientOptions)
                        select method;
            return results;
        }

        private string LoadApiVersion(ResourceType resourceType, CancellationToken cancellationToken)
        {
            Response<Provider> results;
            try
            {
                results = ProviderOperations.Get(resourceType.Namespace, null, cancellationToken);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(resourceType.Type))
                {
                    _nonLoadedResourceToApiVersion.Add(resourceType.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return null;
        }

        private async Task<string> LoadApiVersionAsync(ResourceType resourceType, CancellationToken cancellationToken)
        {
            Response<Provider> results;
            try
            {
                results = await ProviderOperations.GetAsync(resourceType.Namespace, null, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(resourceType.Type))
                {
                    _nonLoadedResourceToApiVersion.Add(resourceType.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Try to get api version for a give resource id, returns null if will use the latest API version for the given resources
        /// </summary>
        public string TryGetApiVersion(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            string val;
            if (TryGetApiVersion(resourceType.ToString(), out val))
            {
                return val;
            }
            return ProviderOperations == null ? null : LoadApiVersion(resourceType.ToString(), cancellationToken);
        }

        /// <summary>
        /// Try to get api version for a give resource id, returns null if will use the latest API version for the given resources
        /// </summary>
        public async Task<string> TryGetApiVersionAsync(ResourceType resourceType, CancellationToken cancellationToken = default)
        {
            string val;
            if (TryGetApiVersion(resourceType.ToString(), out val))
            {
                return val;
            }
            return ProviderOperations == null ? null : await LoadApiVersionAsync(resourceType.ToString(), cancellationToken).ConfigureAwait(false);
        }

        private bool TryGetApiVersion(string resourceType, out string val)
        {
            PropertyWrapper propertyWrapper;
            if (_loadedResourceToApiVersions.TryGetValue(resourceType, out propertyWrapper))
            {
                val = propertyWrapper.GetValue();
                return true;
            }

            if (_nonLoadedResourceToApiVersion.TryGetValue(resourceType, out val))
            {
                return true;
            }
            val = null;
            return false;
        }

        /// <summary>
        /// Set the API version given a resource ID
        /// </summary>
        public void SetApiVersion(ResourceType resourceType, string apiVersion)
        {
            PropertyWrapper propertyWrapper;
            if (_loadedResourceToApiVersions.TryGetValue(resourceType.ToString(), out propertyWrapper))
            {
                propertyWrapper.SetValue(apiVersion);
            }
            else
            {
                _nonLoadedResourceToApiVersion[resourceType.ToString()] = apiVersion;
            }
        }

        internal ApiVersions Clone()
        {
            ApiVersions copy = new ApiVersions(_clientOptions);
            copy.ProviderOperations = ProviderOperations;

            copy._loadedResourceToApiVersions = new Dictionary<string, PropertyWrapper>();
            foreach (var property in _loadedResourceToApiVersions)
            {
                copy._loadedResourceToApiVersions.Add(property.Key, property.Value);
            }

            copy._nonLoadedResourceToApiVersion = new Dictionary<string, string>();
            foreach (var property in _nonLoadedResourceToApiVersion)
            {
                copy._nonLoadedResourceToApiVersion.Add(property.Key, property.Value);
            }
            return copy;
        }
    }
}
