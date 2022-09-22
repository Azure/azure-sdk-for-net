// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary>
    /// A class representing a collection of <see cref="ContainerServiceManagedClusterResource" /> and their operations.
    /// Each <see cref="ContainerServiceManagedClusterResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ContainerServiceManagedClusterCollection" /> instance call the GetContainerServiceManagedClusters method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ContainerServiceManagedClusterCollection : ArmCollection, IEnumerable<ContainerServiceManagedClusterResource>, IAsyncEnumerable<ContainerServiceManagedClusterResource>
    {
        /// <summary> Initializes a new instance of the <see cref="ContainerServiceManagedClusterCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ContainerServiceManagedClusterCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            // Hack the HttpPipelinePolicies
            HttpPipelinePolicy[] originalPolicies = GetPrivateFieldValue<ReadOnlyMemory<HttpPipelinePolicy>>(Pipeline, "_pipeline").ToArray();
            var all = new HttpPipelinePolicy[originalPolicies.Length + 1];
            all[0] = new OperationQueryApiVersionPolicy();
            originalPolicies.CopyTo(all, 1);
            SetPrivateFieldValue<ReadOnlyMemory<HttpPipelinePolicy>>(Pipeline, "_pipeline", all);
            // End of hack
            _containerServiceManagedClusterManagedClustersClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ContainerService", ContainerServiceManagedClusterResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ContainerServiceManagedClusterResource.ResourceType, out string containerServiceManagedClusterManagedClustersApiVersion);
            _containerServiceManagedClusterManagedClustersRestClient = new ManagedClustersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, containerServiceManagedClusterManagedClustersApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal class OperationQueryApiVersionPolicy : HttpPipelineSynchronousPolicy
        {
            // "https://management.azure.com/subscriptions/8ecadfc9-d1a3-4ea4-b844-0d9f87e4d7c8/providers/Microsoft.ContainerService/locations/westus2/operations/6112cdd3-47cb-4b46-9d7c-7531b9fe64b5?api-version=2022-04-01"
            private Regex _operationQueryPattern = new Regex(@"/subscriptions/[^/]+/providers/Microsoft.ContainerService/locations/([^?/]+)/operations/[^?/]+\?api-version=2022-04-01");

            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Method == RequestMethod.Get)
                {
                    var match = _operationQueryPattern.Match(message.Request.Uri.ToString());
                    if (match.Success)
                    {
                        message.Request.Uri.Query = message.Request.Uri.Query.Replace("api-version=2022-04-01", "api-version=2017-08-31");
                    }
                }
            }
        }

        /// <summary>
        /// Returns a private Property Value from a given Object. Uses Reflection.
        /// Throws a ArgumentOutOfRangeException if the Property is not found.
        /// </summary>
        /// <typeparam name="T">Type of the Property</typeparam>
        /// <param name="obj">Object from where the Property Value is returned</param>
        /// <param name="propName">Propertyname as string.</param>
        /// <returns>PropertyValue</returns>
        private static T GetPrivateFieldValue<T>(object obj, string propName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            Type t = obj.GetType();
            FieldInfo fi = null;
            while (fi == null && t != null)
            {
                fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                t = t.BaseType;
            }
            if (fi == null) throw new ArgumentOutOfRangeException(nameof(propName), "Field {propName} was not found in Type {obj.GetType().FullName}");
            return (T)fi.GetValue(obj);
        }

        /// <summary>
        /// Set a private Property Value on a given Object. Uses Reflection.
        /// </summary>
        /// <typeparam name="T">Type of the Property</typeparam>
        /// <param name="obj">Object from where the Property Value is returned</param>
        /// <param name="propName">Propertyname as string.</param>
        /// <param name="val">the value to set</param>
        /// <exception cref="ArgumentOutOfRangeException">if the Property is not found</exception>
        private static void SetPrivateFieldValue<T>(object obj, string propName, T val)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            Type t = obj.GetType();
            FieldInfo fi = null;
            while (fi == null && t != null)
            {
                fi = t.GetField(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                t = t.BaseType;
            }
            if (fi == null) throw new ArgumentOutOfRangeException(nameof(propName), "Field {propName} was not found in Type {obj.GetType().FullName}");
            fi.SetValue(obj, val);
        }
    }
}
