// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Consumption
{
    // Workaround for generator bug: https://github.com/Azure/azure-sdk-for-net/issues/58484
    // The generator's ParameterContextRegistry.FindParameter crashes when a TypeSpec operation
    // has @query("scope") on an extension-scoped non-resource method, because the auto-created
    // scopeParameter (ResourceIdentifier) also has WireInfo.SerializedName="scope".
    // To avoid the crash, the spec uses @query("reservationScope"), but the Azure API expects
    // the query parameter name to be "scope". This custom code overrides CreateGetRequest to
    // send the correct wire name "scope" instead of "reservationScope".
    // The generated CreateGetRequest method was removed from the Generated file because
    // CodeGenSuppress cannot take effect without regeneration (which crashes).
    internal partial class ReservationRecommendationDetails
    {
        internal HttpMessage CreateGetRequest(string resourceScope, string reservationScope, string region, string term, string lookBackPeriod, string product, string filter, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceScope, false);
            uri.AppendPath("/providers/Microsoft.Consumption/reservationRecommendationDetails", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            uri.AppendQuery("scope", reservationScope, true);
            uri.AppendQuery("region", region, true);
            uri.AppendQuery("term", term, true);
            uri.AppendQuery("lookBackPeriod", lookBackPeriod, true);
            uri.AppendQuery("product", product, true);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
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
