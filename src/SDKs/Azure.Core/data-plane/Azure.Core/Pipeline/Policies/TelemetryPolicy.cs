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
        private readonly Assembly _clientAssembly;

        private HttpHeader _header;

        private string _applicationId;

        public string ApplicationId
        {
            get => _applicationId;
            set
            {
                _applicationId = value;
                InitializeHeader();
            }
        }

        public TelemetryPolicy(Assembly clientAssembly)
        {
            _clientAssembly = clientAssembly;
            InitializeHeader();
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.AddHeader(_header);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }

        private void InitializeHeader()
        {
            var componentAttribute = _clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{_clientAssembly.FullName}'.");
            }

            var componentName = componentAttribute.ComponentName;
            var componentVersion = _clientAssembly.GetName().Version.ToString();

            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            if (_applicationId != null)
            {
                _header = new HttpHeader(HttpHeader.Names.UserAgent, $"{_applicationId} azsdk-net-{componentName}/{componentVersion} {platformInformation}");
            }
            else
            {
                _header = new HttpHeader(HttpHeader.Names.UserAgent, $"azsdk-net-{componentName}/{componentVersion} {platformInformation}");
            }
        }

    }
}
