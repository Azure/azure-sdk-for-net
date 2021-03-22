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

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing Azure resource manager client options.
    /// </summary>
    public class ApiVersions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersions"/> class.
        /// </summary>
        internal ApiVersions(AzureResourceManagerClientOptions clientOptions)
        {
            BuildApiTable(clientOptions);
        }

        private Dictionary<string, PropertyWrapper> _loadedResourceToApiVersions = new Dictionary<string, PropertyWrapper>();
        private Dictionary<string, string> _nonLoadedResourceToApiVersion = new Dictionary<string, string>();

        private void BuildApiTable(AzureResourceManagerClientOptions clientOptions)
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
                        where assembly.GetName().ToString().StartsWith("Azure.", StringComparison.Ordinal ) || assembly.GetName().ToString().StartsWith("Proto.", StringComparison.Ordinal)
                        from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested && type.Name.Equals("AzureResourceManagerClientOptionsExtensions", StringComparison.Ordinal)
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == typeof(AzureResourceManagerClientOptions)
                        select method;
            return results;
        }

        private string LoadApiVersion(ProvidersOperations providers, ResourceIdentifier id, CancellationToken cancellationToken)
        {
            var results = providers.Get(id.Type.Namespace, null, cancellationToken);
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(id.Type.Type))
                {
                    _nonLoadedResourceToApiVersion.Add(id.Type.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return null;
        }

        private async Task<string> LoadApiVersionAsync(ProvidersOperations providers, ResourceIdentifier id, CancellationToken cancellationToken)
        {
            var results = await providers.GetAsync(id.Type.Namespace, null, cancellationToken).ConfigureAwait(false);
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(id.Type.Type))
                {
                    _nonLoadedResourceToApiVersion.Add(id.Type.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return null;
        }

        internal string TyrGetApiVersion(ProvidersOperations providers, ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            string val;
            if (TryGetApiVersion(resourceId, out val))
            {
                return val;
            }
            return LoadApiVersion(providers, resourceId, cancellationToken);
        }

        internal async Task<string> TyrGetApiVersionAsync(ProvidersOperations providers, ResourceIdentifier resourceId, CancellationToken cancellationToken)
        {
            string val;
            if (TryGetApiVersion(resourceId, out val))
            {
                return val;
            }
            return await LoadApiVersionAsync(providers, resourceId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the API version give a resource ID if it exist, else will return null.
        /// </summary>
        /// <returns> API version string. </returns>
        public bool TryGetApiVersion(string resourceId, out string val)
        {
            PropertyWrapper propertyWrapper;
            if (_loadedResourceToApiVersions.TryGetValue(resourceId, out propertyWrapper))
            {
                val = propertyWrapper.Info.GetValue(propertyWrapper.PropertyObject).ToString();
                return true;
            }

            if (_nonLoadedResourceToApiVersion.TryGetValue(resourceId, out val))
            {
                return true;
            }
            val = null;
            return false;
        }

        /// <summary>
        /// Set the API version given a resource ID
        /// </summary>
        public void SetApiVersion(string resourceId, string apiVersion)
        {
            PropertyWrapper propertyWrapper;
            if (_loadedResourceToApiVersions.TryGetValue(resourceId, out propertyWrapper))
            {
                Type type = propertyWrapper.Info.PropertyType;
                ConstructorInfo ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
                propertyWrapper.Info.SetValue(propertyWrapper.PropertyObject, ctor.Invoke(new object[] { apiVersion }));
            }
            else
            {
                _nonLoadedResourceToApiVersion[resourceId] = apiVersion;
            }
        }
    }
}
