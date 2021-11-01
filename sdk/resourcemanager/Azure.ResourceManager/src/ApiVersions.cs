// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
    public class ApiVersions
    {
        private ArmClient _armClient;
        private ArmClientOptions _clientOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersions"/> class.
        /// </summary>
        internal ApiVersions(ArmClientOptions clientOptions)
        {
            BuildApiTable(clientOptions);
            _clientOptions = clientOptions;
            _armClient = null;
        }

        /// <summary>
        /// Make a provider resource client class.
        /// </summary>
        internal void SetProviderClient(ArmClient armClient)
        {
            _armClient = armClient;            ;
        }

        private ConcurrentDictionary<string, PropertyWrapper> _loadedResourceToApiVersions = new ConcurrentDictionary<string, PropertyWrapper>();
        private ConcurrentDictionary<string, string> _nonLoadedResourceToApiVersion = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, string> _apiForNamespaceCache = new ConcurrentDictionary<string, string>();

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
                            _loadedResourceToApiVersions.TryAdd(key.ToString(), new PropertyWrapper(prop, apiObject));
                        }
                    }
                }
            }
        }

        internal string GetApiVersionForNamespace(string nameSpace)
        {
            string version;
            if (!_apiForNamespaceCache.TryGetValue(nameSpace, out version))
            {
                DateTime maxVersion = new DateTime(1, 1, 1);
                Provider results = _armClient.GetDefaultSubscription().GetProviders().Get(nameSpace, null);
                foreach (var type in results.Data.ResourceTypes)
                {
                    string[] parts = type.ApiVersions[0].Split('-');
                    DateTime current = new DateTime(
                        Convert.ToInt32(parts[0], CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToInt32(parts[1], CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToInt32(parts[2], CultureInfo.InvariantCulture.NumberFormat));
                    maxVersion = current > maxVersion ? current : maxVersion;
                }
                string month = maxVersion.Month < 10 ? "0" : string.Empty;
                month += maxVersion.Month;
                string day = maxVersion.Day < 10 ? "0" : string.Empty;
                day += maxVersion.Day;
                version = $"{maxVersion.Year}-{month}-{day}";
                _apiForNamespaceCache[nameSpace] = version;
            }
            return version;
        }

        private static IEnumerable<MethodInfo> GetExtensionMethods()
        {
            var results =
                        from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        where assembly.GetName().ToString().StartsWith("Azure.", StringComparison.Ordinal)
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
                results = _armClient.GetDefaultSubscription(cancellationToken).GetProviders().Get(resourceType.Namespace, null, cancellationToken);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
            foreach (var type in results.Value.Data.ResourceTypes)
            {
                if (type.ResourceType.Equals(resourceType.Type))
                {
                    _nonLoadedResourceToApiVersion.TryAdd(resourceType.ToString(), type.ApiVersions[0]);
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
                Subscription subscription = await _armClient.GetDefaultSubscriptionAsync(cancellationToken).ConfigureAwait(false);
                results = await subscription.GetProviders().GetAsync(resourceType.Namespace, null, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
            foreach (var type in results.Value.Data.ResourceTypes)
            {
                if (type.ResourceType.Equals(resourceType.Type))
                {
                    _nonLoadedResourceToApiVersion.TryAdd(resourceType.ToString(), type.ApiVersions[0]);
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
            return _armClient == null ? null : LoadApiVersion(resourceType.ToString(), cancellationToken);
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
            return _armClient == null ? null : await LoadApiVersionAsync(resourceType.ToString(), cancellationToken).ConfigureAwait(false);
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
            copy._armClient = _armClient;
            copy._loadedResourceToApiVersions = new ConcurrentDictionary<string, PropertyWrapper>(_loadedResourceToApiVersions);
            copy._nonLoadedResourceToApiVersion = new ConcurrentDictionary<string, string>(_nonLoadedResourceToApiVersion);
            return copy;
        }
    }
}
