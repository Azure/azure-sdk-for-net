// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Base.Attributes;

namespace Azure.Base.Pipeline.Policies
{
    public class TelemetryPolicy : HttpPipelinePolicy
    {
        private readonly HttpHeader _header;

        public TelemetryPolicy(Assembly clientAssembly, string applicationId)
        {
            var componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            var assemblyVersion = clientAssembly.GetName().Version.ToString();
            _header = HttpHeader.Common.CreateUserAgent(componentAttribute.ComponentName, assemblyVersion, applicationId);
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.AddHeader(_header);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}
