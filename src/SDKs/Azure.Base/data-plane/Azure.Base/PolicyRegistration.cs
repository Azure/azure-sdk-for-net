// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Base.Http.Pipeline;

namespace Azure
{
    public struct PolicyRegistration
    {
        public HttpPipelineSection Section { get; }
        public Func<HttpPipelinePolicy, HttpPipelinePolicy> PolicyFactory { get; }

        public PolicyRegistration(HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            Section = section;
            PolicyFactory = policyFactory;
        }
    }
}