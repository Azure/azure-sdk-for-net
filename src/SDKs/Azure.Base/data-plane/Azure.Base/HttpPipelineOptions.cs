// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Base.Http.Pipeline;

namespace Azure
{
    public class HttpPipelineOptions
    {
        private List<PolicyRegistration> _pipelinePolicies;

        public HttpPipelineOptions()
        {
            _pipelinePolicies = new List<PolicyRegistration>();
            TransportPolicy = () => new HttpClientTransport();
        }

        public ICollection<PolicyRegistration> PipelinePolicies => _pipelinePolicies;

        public Func<HttpPipelineTransport> TransportPolicy { get; set; }

        public bool DisableTelemetry { get; set; }

        public string ApplicationId { get; set; }

        public HttpPipelineOptions Clone()
        {
            return new HttpPipelineOptions()
            {
                TransportPolicy = TransportPolicy,
                _pipelinePolicies = new List<PolicyRegistration>(PipelinePolicies),
                ApplicationId = ApplicationId,
                DisableTelemetry =  DisableTelemetry
            };
        }


    }
}