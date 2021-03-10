// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
        public ApiVersions()
        {
            BuildApiTable();
        }

        private Dictionary<string, string> _resourceToApiVersions = new Dictionary<string, string>();

        private void BuildApiTable()
        {
            var methods = GetExtensionMethods();
            foreach (var method in methods)
            {
                if (method.Name.EndsWith("RestApiVersions"))
                {
                    var apiObject = method.Invoke(null, new object[] { this });
                    var properties = apiObject.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        if (typeof(ApiVersionsBase).IsAssignableFrom(prop.PropertyType))
                        {
                            var propVal = (ApiVersionsBase)prop.GetValue(apiObject);
                            Console.WriteLine(prop.GetType());
                            var key = propVal.ResourceType;
                            _resourceToApiVersions.Add(key.ToString(), propVal);
                        }
                    }
                }
            }
        }

        private static IEnumerable<MethodInfo> GetExtensionMethods()
        {
            var results =
                        from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == typeof(ApiVersions)
                        select method;
            return results;
        }

        internal string LoadApiVersion(ProvidersOperations providers, ResourceIdentifier id)
        {
            var results = providers.Get(id.Type.Namespace);
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(id.Type.Type))
                {
                    _resourceToApiVersions.Add(id.Type.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return string.Empty;
        }

        internal async Task<string> LoadApiVersionAsync(ProvidersOperations providers, ResourceIdentifier id)
        {
            var results = await providers.GetAsync(id.Type.Namespace).ConfigureAwait(false);
            foreach (var type in results.Value.ResourceTypes)
            {
                if (type.ResourceType.Equals(id.Type.Type))
                {
                    _resourceToApiVersions.Add(id.Type.ToString(), type.ApiVersions[0]);
                    return type.ApiVersions[0];
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the API version give a resource ID if it exist, else will return null.
        /// </summary>
        /// <returns> API version string. </returns>
        public string GetApiVersion(string resourceId)
        {
            string val;
            _resourceToApiVersions.TryGetValue(resourceId, out val);
            return val;
        }

        /// <summary>
        /// Set the API version give a resource ID
        /// </summary>
        public void SetApiVersion(string resourceId, string apiVersion)
        {
            _resourceToApiVersions.Add(resourceId, apiVersion);
        }
    }
}
