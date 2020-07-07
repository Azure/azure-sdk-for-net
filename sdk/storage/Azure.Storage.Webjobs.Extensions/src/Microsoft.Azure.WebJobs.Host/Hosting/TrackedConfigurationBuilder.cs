// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Hosting
{
    internal class TrackedConfigurationBuilder : IConfigurationBuilder, ITrackedConfigurationBuilder
    {
        private List<IConfigurationSource> _trackedChanges { get; set; }

        public TrackedConfigurationBuilder(IConfigurationBuilder configBuilder)
        {
            ConfigurationBuilder = configBuilder ?? new ConfigurationBuilder();
            _trackedChanges = new List<IConfigurationSource>();
        }

        public IConfigurationBuilder ConfigurationBuilder { get; set; }

        public IEnumerable<IConfigurationSource> TrackedConfigurationSources => _trackedChanges;

        public IDictionary<string, object> Properties => ConfigurationBuilder.Properties;

        public IList<IConfigurationSource> Sources => ConfigurationBuilder.Sources;

        public IConfigurationBuilder Add(IConfigurationSource source)
        {
            _trackedChanges.Add(source);
            return ConfigurationBuilder.Add(source);
        }

        public IConfigurationRoot Build()
        {
            return ConfigurationBuilder.Build();
        }

        public void ResetTracking()
        {
            _trackedChanges.Clear();
        }
    }
}
