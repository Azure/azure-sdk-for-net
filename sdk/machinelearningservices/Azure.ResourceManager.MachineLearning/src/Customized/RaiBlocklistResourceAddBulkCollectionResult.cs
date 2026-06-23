// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve the legacy pageable add-bulk surface. The TypeSpec operation is an LRO
    // action with an array final result, which the generator models as ArmOperation<IReadOnlyList<T>>
    // rather than a pageable operation.
    internal partial class RaiBlocklistResourceAddBulkCollectionResult : Pageable<RaiBlocklistItemData>
    {
        private readonly ConnectionRaiBlocklistItem _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _workspaceName;
        private readonly string _connectionName;
        private readonly string _raiBlocklistName;
        private readonly IEnumerable<RaiBlocklistItemBulkContent> _body;
        private readonly RequestContext _context;

        public RaiBlocklistResourceAddBulkCollectionResult(ConnectionRaiBlocklistItem client, Guid subscriptionId, string resourceGroupName, string workspaceName, string connectionName, string raiBlocklistName, IEnumerable<RaiBlocklistItemBulkContent> body, RequestContext context)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _workspaceName = workspaceName;
            _connectionName = connectionName;
            _raiBlocklistName = raiBlocklistName;
            _body = body;
            _context = context;
        }

        public override IEnumerable<Page<RaiBlocklistItemData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            if (continuationToken != null)
            {
                yield break;
            }

            Response response = GetResponse();
            RaiBlocklistItemArmPaginatedResult result = RaiBlocklistItemArmPaginatedResult.FromResponse(response);
            yield return Page<RaiBlocklistItemData>.FromValues((IReadOnlyList<RaiBlocklistItemData>)result.Value, result.NextLink?.OriginalString, response);
        }

        private Response GetResponse()
        {
            RequestContent content = MachineLearningSerializationHelpers.CreateEnumerableContent(_body);
            HttpMessage message = _client.CreateAddBulkRequest(_subscriptionId, _resourceGroupName, _workspaceName, _connectionName, _raiBlocklistName, content, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("RaiBlocklistResource.AddBulk");
            scope.Start();
            try
            {
                return _client.Pipeline.ProcessMessage(message, _context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
