// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary> Check access response details. </summary>
    public partial class CheckPrincipalAccessResponse
    {
        /// <summary> Initializes a new instance of CheckPrincipalAccessResponse. </summary>
        internal CheckPrincipalAccessResponse()
        {
            AccessDecisions = new ChangeTrackingList<CheckAccessDecision>();
        }

        /// <summary> Initializes a new instance of CheckPrincipalAccessResponse. </summary>
        /// <param name="accessDecisions"> To check if the current user, group, or service principal has permission to read artifacts in the specified workspace. </param>
        internal CheckPrincipalAccessResponse(IReadOnlyList<CheckAccessDecision> accessDecisions)
        {
            AccessDecisions = accessDecisions;
        }

        /// <summary> To check if the current user, group, or service principal has permission to read artifacts in the specified workspace. </summary>
        public IReadOnlyList<CheckAccessDecision> AccessDecisions { get; }

        public static implicit operator CheckPrincipalAccessResponse(Response response)
        {
            if (response.IsError)
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new RequestFailedException(response);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
            }

            using var doc = JsonDocument.Parse(response.Content.ToMemory());
            return DeserializeCheckPrincipalAccessResponse(doc.RootElement);
        }
    }
}
