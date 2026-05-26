// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ResourceGraph.Models;

namespace Azure.ResourceManager.ResourceGraph.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MockableResourceGraphTenantResource : ArmResource
    {
        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.ResourceGraph/resourcesHistory. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ResourceHistory_ResourcesHistory. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2021-06-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// TODO: Fix the AOT incompatibility build error with custom code now. Tracked issue: https://github.com/Azure/azure-sdk-for-net/issues/59433
        public virtual async Task<Response<IDictionary<string, BinaryData>>> GetResourcesHistoryAsync(ResourcesHistoryRequest content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = ResourceHistoryOperationsClientDiagnostics.CreateScope("MockableResourceGraphTenantResource.GetResourcesHistory");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = ResourceHistoryOperationsRestClient.CreateGetResourcesHistoryRequest(ResourcesHistoryRequest.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<IDictionary<string, BinaryData>> response = Response.FromValue(DeserializeResourcesHistory(result.Content), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.ResourceGraph/resourcesHistory. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ResourceHistory_ResourcesHistory. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2021-06-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// TODO: Fix the AOT incompatibility build error with custom code now. Tracked issue: https://github.com/Azure/azure-sdk-for-net/issues/59433
        public virtual Response<IDictionary<string, BinaryData>> GetResourcesHistory(ResourcesHistoryRequest content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = ResourceHistoryOperationsClientDiagnostics.CreateScope("MockableResourceGraphTenantResource.GetResourcesHistory");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = ResourceHistoryOperationsRestClient.CreateGetResourcesHistoryRequest(ResourcesHistoryRequest.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<IDictionary<string, BinaryData>> response = Response.FromValue(DeserializeResourcesHistory(result.Content), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static IDictionary<string, BinaryData> DeserializeResourcesHistory(BinaryData content)
        {
            using JsonDocument document = JsonDocument.Parse(content, ModelSerializationExtensions.JsonDocumentOptions);
            if (document.RootElement.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            Dictionary<string, BinaryData> result = new Dictionary<string, BinaryData>();
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                result.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }

            return result;
        }

        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<BinaryData>> GetResourceHistoryAsync(ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.");
        }

        /// <summary>
        /// List all snapshots of a resource for a given time interval.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.ResourceGraph/resourcesHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourcesHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Request specifying the query and its options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BinaryData> GetResourceHistory(ResourcesHistoryContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.");
        }
    }
}
