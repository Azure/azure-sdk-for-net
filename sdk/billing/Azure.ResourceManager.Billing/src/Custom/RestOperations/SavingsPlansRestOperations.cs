// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Billing
{
    internal partial class SavingsPlans
    {
        internal HttpMessage CreateListByBillingAccountRequest(string billingAccountName, string filter, string orderBy, float? skiptoken, float? take, string selectedState, string refreshSummary, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Billing/billingAccounts/", false);
            uri.AppendPath(billingAccountName, true);
            uri.AppendPath("/savingsPlans", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            if (filter != null)
            {
                uri.AppendQuery("filter", filter, true);
            }
            if (orderBy != null)
            {
                uri.AppendQuery("orderBy", orderBy, true);
            }
            if (skiptoken != null)
            {
                uri.AppendQuery("skiptoken", TypeFormatters.ConvertToString(skiptoken), true);
            }
            if (take != null)
            {
                uri.AppendQuery("take", TypeFormatters.ConvertToString(take), true);
            }
            if (selectedState != null)
            {
                uri.AppendQuery("selectedState", selectedState, true);
            }
            if (refreshSummary != null)
            {
                uri.AppendQuery("refreshSummary", refreshSummary, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextListByBillingAccountRequest(Uri nextPage, string billingAccountName, string filter, string orderBy, float? skiptoken, float? take, string selectedState, string refreshSummary, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            if (nextPage.IsAbsoluteUri)
            {
                uri.Reset(nextPage);
            }
            else
            {
                uri.Reset(new Uri(_endpoint, nextPage));
            }
            if (_apiVersion != null)
            {
                uri.UpdateQuery("api-version", _apiVersion);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
