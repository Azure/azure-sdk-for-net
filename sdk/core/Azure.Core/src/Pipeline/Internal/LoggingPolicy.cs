// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    internal class LoggingPolicy : HttpPipelinePolicy
    {
        public LoggingPolicy(bool logContent, int maxLength, HttpMessageSanitizer sanitizer, string? assemblyName)
        {
            _clientModelPolicy = new LoggingPolicyAdapter();
            _logContent = logContent;
            _maxLength = maxLength;
            _assemblyName = assemblyName;
        }

        private const double RequestTooLongTime = 3.0; // sec

        private readonly bool _logContent;
        private readonly int _maxLength;
        private readonly string? _assemblyName;
        private readonly LoggingPolicyAdapter _clientModelPolicy;

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!s_eventSource.IsEnabled())
            {
                ProcessNext(message, pipeline);
                return;
            }

            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {

        }

        private sealed class LoggingPolicyAdapter : ClientLoggingPolicy
        {
            private readonly LoggingPolicy _azureCorePolicy;

            public LoggingPolicyAdapter(string logName, string[] logTraits, LoggingOptions options, LoggingPolicy policy) : base(logName, logTraits, options)
            {
                _azureCorePolicy = policy;
            }
        }
    }
}
