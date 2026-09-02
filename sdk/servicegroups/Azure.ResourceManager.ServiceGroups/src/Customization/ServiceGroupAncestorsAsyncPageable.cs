// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ServiceGroups
{
    internal sealed class ServiceGroupAncestorsAsyncPageable : AsyncPageable<ServiceGroupResource>
    {
        private readonly ArmClient _armClient;
        private readonly ServiceGroupsOperationGroup _client;
        private readonly string _serviceGroupName;
        private readonly RequestContext _context;

        internal ServiceGroupAncestorsAsyncPageable(
            ArmClient armClient,
            ServiceGroupsOperationGroup client,
            string serviceGroupName,
            RequestContext context)
            : base(context.CancellationToken)
        {
            _armClient = armClient;
            _client = client;
            _serviceGroupName = serviceGroupName;
            _context = context;
        }

        public override async IAsyncEnumerable<Page<ServiceGroupResource>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = await GetResponseAsync().ConfigureAwait(false);
            yield return Page<ServiceGroupResource>.FromValues(
                DeserializeResources(response),
                continuationToken: null,
                response);
        }

        private async Task<Response> GetResponseAsync()
        {
            HttpMessage message = _client.CreateGetAncestorsRequest(_serviceGroupName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("ServiceGroupResource.GetAncestors");
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                scope.Failed(exception);
                throw;
            }
        }

        private IReadOnlyList<ServiceGroupResource> DeserializeResources(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            List<ServiceGroupResource> resources = new List<ServiceGroupResource>();
            foreach (JsonElement item in document.RootElement.GetProperty("value").EnumerateArray())
            {
                ServiceGroupData data = ServiceGroupData.DeserializeServiceGroupData(item, ModelSerializationExtensions.WireOptions);
                resources.Add(new ServiceGroupResource(_armClient, data));
            }
            return resources;
        }
    }
}
