// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Sets up <see cref="ServiceManagerOptions"/> from <see cref="SignalROptions"/>.
    /// </summary>
    internal class OptionsSetupFromOptions : IConfigureOptions<ServiceManagerOptions>, IOptionsChangeTokenSource<ServiceManagerOptions>
    {
        private readonly SignalROptions _sourceOptions;

        public string Name => Options.DefaultName;

        public OptionsSetupFromOptions(SignalROptions sourceOptions)
        {
            _sourceOptions = sourceOptions;
        }

        public void Configure(ServiceManagerOptions options)
        {
            options.ServiceEndpoints = _sourceOptions.ServiceEndpoints;
            if (_sourceOptions.ServiceTransportType.HasValue)
            {
                options.ServiceTransportType = _sourceOptions.ServiceTransportType.Value;
            }
        }

        public IChangeToken GetChangeToken() => NullChangeToken.Singleton;
    }
}
