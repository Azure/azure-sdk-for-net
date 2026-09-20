// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    internal sealed class ComputeVirtualMachineImagesOperationGroupListVersionsAsyncCollectionResultOfT : AsyncPageable<VirtualMachineImageBase>
    {
        private readonly VirtualMachineImagesOperationGroup _client;
        private readonly string _subscriptionId;
        private readonly AzureLocation _location;
        private readonly string _publisherName;
        private readonly string _offer;
        private readonly string _skus;
        private readonly string _expand;
        private readonly int? _top;
        private readonly string _orderby;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public ComputeVirtualMachineImagesOperationGroupListVersionsAsyncCollectionResultOfT(VirtualMachineImagesOperationGroup client, string subscriptionId, AzureLocation location, string publisherName, string offer, string skus, string expand, int? top, string orderby, RequestContext context, string diagnosticScope)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _location = location;
            _publisherName = publisherName;
            _offer = offer;
            _skus = skus;
            _expand = expand;
            _top = top;
            _orderby = orderby;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override async IAsyncEnumerable<Page<VirtualMachineImageBase>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = await GetResponseAsync(pageSizeHint).ConfigureAwait(false);
            yield return Page<VirtualMachineImageBase>.FromValues(ParseResponse(response), null, response);
        }

        private async Task<Response> GetResponseAsync(int? pageSizeHint)
        {
            HttpMessage message = _client.CreateGetVirtualMachineImagesRequest(_subscriptionId, _location, _publisherName, _offer, _skus, _expand, _top, _orderby, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static IReadOnlyList<VirtualMachineImageBase> ParseResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            List<VirtualMachineImageBase> result = new List<VirtualMachineImageBase>();
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                result.Add(ModelReaderWriter.Read<VirtualMachineImageBase>(new BinaryData(Encoding.UTF8.GetBytes(element.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeContext.Default));
            }
            return result;
        }
    }
}
