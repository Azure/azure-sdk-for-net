// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline.Policies
{
    public class TelemetryPolicy : SynchronousHttpPipelinePolicy
    {
        private readonly Assembly _clientAssembly;

        private string _header;

        private string _applicationId;

        private readonly bool _disable = EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TELEMETRY_DISABLED")) ?? false;

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
                _header = $"{_applicationId} azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
            else
            {
                _header = $"azsdk-net-{componentName}/{componentVersion} {platformInformation}";
            }
        }

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            if (!_disable)
            {
                message.Request.Headers.Add(HttpHeader.Names.UserAgent, _header);
            }
        }

        private static bool? EnvironmentVariableToBool(string value)
        {
            if (string.Equals("true", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("1", value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals("false", value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals("0", value, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return null;
        }

    }
}
