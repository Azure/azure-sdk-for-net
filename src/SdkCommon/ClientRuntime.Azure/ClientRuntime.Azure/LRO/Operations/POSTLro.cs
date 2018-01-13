// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.LRO
{
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    internal class POSTLro<TResourceBody, TRequestHeaders> : AzureLRO<TResourceBody, TRequestHeaders>
            where TResourceBody : class
            where TRequestHeaders : class
    {
        public override string RESTOperationVerb { get => "POST"; }

        public POSTLro(IAzureClient client, AzureOperationResponse<TResourceBody, TRequestHeaders> response,
            Dictionary<string, List<string>> customHeaders,
            CancellationToken cancellationToken) : base(client, response, customHeaders, cancellationToken)
        { }

        protected override void InitializeAsyncHeadersToUse()
        {
            base.InitializeAsyncHeadersToUse();

            // 201
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Created)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }
                else
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended pattern POST-201-LocationHeader");
                }
            }

            // For 202, we prefer AzureAsyncOperation header, else we fallback on LocationHeader
            if (CurrentPollingState.CurrentStatusCode == System.Net.HttpStatusCode.Accepted)
            {
                if (!string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    CurrentPollingState.PollingUrlToUse = CurrentPollingState.AzureAsyncOperationHeaderLink;
                }

                if (!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink))
                {
                    if (string.IsNullOrEmpty(CurrentPollingState.AzureAsyncOperationHeaderLink))
                    {
                        CurrentPollingState.PollingUrlToUse = CurrentPollingState.LocationHeaderLink;
                    }
                    else
                    {
                        // During polling if we get location header, that needs to be used to get result for the final GET
                        CurrentPollingState.FinalGETUrlToUser = CurrentPollingState.LocationHeaderLink;
                    }
                }

                if (string.IsNullOrEmpty(CurrentPollingState.PollingUrlToUse))
                {
                    throw new ValidationException(ValidationRules.CannotBeNull, "Recommended patterns: POST-202-LocationHeder(Prefered)/AzureAsyncOperationHeader");
                }
            }
        }

        protected override bool IsCheckingProvisioningStateApplicable()
        {
            // For POST check Provisioning for 200 and 204
            return ((CurrentPollingState.CurrentStatusCode == HttpStatusCode.OK) ||
                     (CurrentPollingState.CurrentStatusCode == HttpStatusCode.NoContent));
        }

        protected override async Task PostPollingAsync()
        {
            //We do an additional Get to get the resource for PUT requests
            if (AzureAsyncOperation.SuccessStatus.Equals(CurrentPollingState.Status, StringComparison.OrdinalIgnoreCase))
            {
                if (CurrentPollingState.PollingUrlToUse.Equals(CurrentPollingState.AzureAsyncOperationHeaderLink))
                {
                    if ((!string.IsNullOrEmpty(CurrentPollingState.LocationHeaderLink)))
                    {
                        // We want to call the one last time the original URI that will give you the required resource
                        if (!string.IsNullOrEmpty(CurrentPollingState.FinalGETUrlToUser))
                        {
                            CurrentPollingState.PollingUrlToUse = GetValidAbsoluteUri(CurrentPollingState.FinalGETUrlToUser, throwForInvalidUri: true);
                        }

                        await CurrentPollingState.UpdateResourceFromPollingUri(CustomHeaders, CancelToken);
                    }
                }
            }
        }
    }
}
