// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    internal partial class SavingsPlansGetByBillingAccountCollectionResultOfT : Pageable<BillingSavingsPlanModelData>
    {
        private readonly SavingsPlans _client;
        private readonly string _billingAccountName;
        private readonly string _filter;
        private readonly string _orderBy;
        private readonly float? _skiptoken;
        private readonly float? _take;
        private readonly string _selectedState;
        private readonly string _refreshSummary;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public SavingsPlansGetByBillingAccountCollectionResultOfT(SavingsPlans client, string billingAccountName, string filter, string orderBy, float? skiptoken, float? take, string selectedState, string refreshSummary, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _billingAccountName = billingAccountName;
            _filter = filter;
            _orderBy = orderBy;
            _skiptoken = skiptoken;
            _take = take;
            _selectedState = selectedState;
            _refreshSummary = refreshSummary;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<BillingSavingsPlanModelData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                SavingsPlanModelList result = SavingsPlanModelList.FromResponse(response);
                yield return Page<BillingSavingsPlanModelData>.FromValues((IReadOnlyList<BillingSavingsPlanModelData>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextListByBillingAccountRequest(nextLink, _billingAccountName, _filter, _orderBy, _skiptoken, _take, _selectedState, _refreshSummary, _context) : _client.CreateListByBillingAccountRequest(_billingAccountName, _filter, _orderBy, _skiptoken, _take, _selectedState, _refreshSummary, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
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
