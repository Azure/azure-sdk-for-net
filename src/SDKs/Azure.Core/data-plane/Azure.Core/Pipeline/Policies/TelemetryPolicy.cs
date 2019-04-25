// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core.Attributes;

namespace Azure.Core.Pipeline.Policies
{
    public class TelemetryPolicy : HttpPipelinePolicy
    {
        private readonly string _header;

        public TelemetryPolicy(Assembly clientAssembly, string applicationId)
        {
            var componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            var componentName = componentAttribute.ComponentName;
            var componentVersion = clientAssembly.GetName().Version.ToString();

            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            if (applicationId != null)
            {
                _header = $"{applicationId} azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
            else
            {
                _header = $"azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.AddHeader(HttpHeader.Names.UserAgent, _header);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}
