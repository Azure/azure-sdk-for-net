// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline.Policies
{
    public class TelemetryPolicy : SynchronousHttpPipelinePolicy
    {
        private readonly string _componentName;

        private readonly string _componentVersion;

        private string _header;

        private string _applicationId;

        private readonly bool _disable = EnvironmentVariableToBool(Environment.GetEnvironmentVariable("AZURE_TELEMETRY_DISABLED")) ?? false;

        public static string DefaultApplicationId { get; set; }

        public string ApplicationId
        {
            get => _applicationId;
            set
            {
                _applicationId = value;
                InitializeHeader();
            }
        }

        public TelemetryPolicy(string componentName, string componentVersion)
        {
            _componentName = componentName;
            _componentVersion = componentVersion;
            _applicationId = DefaultApplicationId;
            InitializeHeader();
        }

        private void InitializeHeader()
        {
            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            if (_applicationId != null)
            {
                _header = $"{_applicationId} azsdk-net-{_componentName}/{_componentVersion} {platformInformation}";
            }
            else
            {
                _header = $"azsdk-net-{_componentName}/{_componentVersion} {platformInformation}";
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
