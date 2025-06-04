﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System;
using Azure.Core;
using Azure.Developer.Playwright.Interface;
using Azure.Developer.Playwright.Implementation;
using Azure.Developer.Playwright.Utility;
using Microsoft.Extensions.Logging;

namespace Azure.Developer.Playwright
{
    /// <summary>
    /// Options to configure the requests to the Playwright service browser client.
    /// </summary>
    public class PlaywrightServiceBrowserClientOptions : ClientOptions
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger? Logger { get; set; } = null;

        private OSPlatform? _os;
        /// <summary>
        /// Gets or sets the operating system for Playwright service.
        /// </summary>
        public OSPlatform OS
        {
            get
            {
                if (_os != null)
                    return (OSPlatform)_os!;
                // Get the OS from the environment variable if not set
                var os = _environment.GetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable);
                if (os != null)
                {
                    return ClientUtilities.GetOSPlatform(os) ?? OSPlatform.Linux;
                }
                _environment.SetEnvironmentVariable(Constants.s_playwright_service_os_environment_variable, OSConstants.s_lINUX);
                return OSPlatform.Linux;
            }
            set
            {
                if (value != OSPlatform.Linux && value != OSPlatform.Windows)
                {
                    throw new ArgumentException($"Invalid value for OS. Supported values are {OSPlatform.Linux}, {OSPlatform.Windows}");
                }
                _os = value;
            }
        }

        private string? _runId;

        /// <summary>
        /// Gets or sets the run ID.
        /// </summary>
        public string RunId
        {
            get => _runId ?? _environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable) ?? _clientUtility.GetDefaultRunId();
            set
            {
                _runId = value;
                // Set run id if not already set in the environment
                if (string.IsNullOrEmpty(_environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable)))
                {
                    _environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, value);
                }
            }
        }

        private string? _exposeNetwork;
        /// <summary>
        /// Gets or sets the expose network field for remote browsers.
        /// </summary>
        public string ExposeNetwork
        {
            get
            {
                if (_exposeNetwork != null)
                    return _exposeNetwork!;
                var exposeNetwork = _environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable);
                if (exposeNetwork != null)
                {
                    return exposeNetwork;
                }
                _environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable, Constants.s_default_expose_network);
                return Constants.s_default_expose_network;
            }
            set
            {
                _exposeNetwork = value;
                // Set expose network if not already set in the environment. Empty strings are allowed here
                if (_environment.GetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable) == null)
                {
                    _environment.SetEnvironmentVariable(Constants.s_playwright_service_expose_network_environment_variable, value);
                }
            }
        }

        private ServiceAuthType? _serviceAuth;
        /// <summary>
        /// Gets or sets the default authentication mechanism.
        /// </summary>
        public ServiceAuthType ServiceAuth
        {
            get
            {
                if (_serviceAuth != null)
                    return (ServiceAuthType)_serviceAuth!;
                var serviceAuth = _environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable);
                if (serviceAuth != null)
                {
                    if (serviceAuth.Equals(ServiceAuthType.AccessToken.ToString(), StringComparison.OrdinalIgnoreCase))
                        return ServiceAuthType.AccessToken;
                    if (serviceAuth.Equals(ServiceAuthType.EntraId.ToString(), StringComparison.OrdinalIgnoreCase))
                        return ServiceAuthType.EntraId;
                    throw new ArgumentException($"Invalid value for ServiceAuth. Supported values are {ServiceAuthType.EntraId}, {ServiceAuthType.AccessToken}");
                }
                _environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, ServiceAuthType.EntraId.ToString());
                return ServiceAuthType.EntraId;
            }
            set
            {
                if (value != ServiceAuthType.EntraId && value != ServiceAuthType.AccessToken)
                {
                    throw new ArgumentException($"Invalid value for ServiceAuth. Supported values are {ServiceAuthType.EntraId}, {ServiceAuthType.AccessToken}");
                }
                _serviceAuth = value;
                // Set service auth if not already set in the environment
                if (_environment.GetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable) == null)
                {
                    _environment.SetEnvironmentVariable(Constants.s_playwright_service_auth_type_environment_variable, value.ToString());
                }
            }
        }

        private bool? _useCloudHostedBrowsers;
        /// <summary>
        /// Gets or sets a flag indicating whether to use cloud-hosted browsers.
        /// </summary>
        public bool UseCloudHostedBrowsers
        {
            get
            {
                if (_useCloudHostedBrowsers != null)
                    return (bool)_useCloudHostedBrowsers!;
                var envValue = _environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable);
                if (envValue != null)
                {
                    if (bool.TryParse(envValue, out var result))
                        return result;
                    throw new ArgumentException($"Invalid value for UseCloudHostedBrowsers. Supported values are true or false");
                }
                _environment.SetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable, true.ToString());
                return true;
            }
            set
            {
                _useCloudHostedBrowsers = value;
                // Set use cloud hosted browsers if not already set in the environment
                if (_environment.GetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable) == null)
                {
                    _environment.SetEnvironmentVariable(Constants.s_playwright_service_use_cloud_hosted_browsers_environment_variable, value.ToString());
                }
            }
        }

        /// <summary>
        /// Gets the service endpoint for Playwright service.
        /// </summary>
        public string? ServiceEndpoint
        {
            get => _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString());
            set => _environment.SetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString(), value);
        }

        private const ServiceVersion Latest = ServiceVersion.V2025_07_01_Preview;

        internal string VersionString { get; }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The Playwright service browser client API version 2025-07-01-preview.
            /// </summary>
            V2025_07_01_Preview = 1,
        }

        internal string? AuthToken
        {
            get => _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken.ToString());
        }

        internal IEnvironment _environment;
        internal ClientUtilities _clientUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserClientOptions"/> class.
        /// </summary>
        /// <param name="serviceVersion "></param>
        public PlaywrightServiceBrowserClientOptions(ServiceVersion serviceVersion = Latest) : this(
            environment: new EnvironmentHandler(),
            clientUtility: new ClientUtilities(),
            serviceVersion: serviceVersion
        )
        {
            // no-op
        }

        internal PlaywrightServiceBrowserClientOptions(ServiceVersion serviceVersion, IEnvironment? environment = null, ClientUtilities? clientUtility = null)
        {
            _environment = environment ?? new EnvironmentHandler();
            _clientUtility = clientUtility ?? new ClientUtilities(_environment);
            VersionString = serviceVersion switch
            {
                ServiceVersion.V2025_07_01_Preview => "2025-07-01-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }
    }
}
