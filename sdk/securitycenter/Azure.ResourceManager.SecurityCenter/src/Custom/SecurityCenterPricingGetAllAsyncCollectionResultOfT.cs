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
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    internal partial class SecurityCenterPricingGetAllAsyncCollectionResultOfT : AsyncPageable<SecurityCenterPricingData>
    {
        private readonly Pricings _client;
        private readonly string _scopeId;
        private readonly string _filter;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public SecurityCenterPricingGetAllAsyncCollectionResultOfT(Pricings client, string scopeId, string filter, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _scopeId = scopeId;
            _filter = filter;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public async override IAsyncEnumerable<Page<SecurityCenterPricingData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            if (continuationToken != null)
            {
                throw new NotSupportedException("The SecurityCenter pricing list operation does not return continuation tokens.");
            }

            Response response = await GetNextResponseAsync().ConfigureAwait(false);
            yield return Page<SecurityCenterPricingData>.FromValues(ReadValues(response), null, response);
        }

        private async Task<Response> GetNextResponseAsync()
        {
            HttpMessage message = _client.CreateGetAllRequest(_scopeId, _filter, _context);
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

        private static IReadOnlyList<SecurityCenterPricingData> ReadValues(Response response)
        {
            List<SecurityCenterPricingData> values = new List<SecurityCenterPricingData>();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            if (document.RootElement.TryGetProperty("value", out JsonElement valueElement))
            {
                foreach (JsonElement item in valueElement.EnumerateArray())
                {
                    values.Add(SecurityCenterPricingData.DeserializeSecurityCenterPricingData(item, ModelSerializationExtensions.WireOptions));
                }
            }
            return values;
        }
    }
}
