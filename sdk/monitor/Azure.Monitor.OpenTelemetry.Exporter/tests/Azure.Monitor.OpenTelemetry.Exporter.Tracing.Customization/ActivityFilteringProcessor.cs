// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tracing.Customization
{
    internal class ActivityFilteringProcessor : BaseProcessor<Activity>
    {
        private readonly string name;
        public ActivityFilteringProcessor(string name = "ActivityFilteringProcessor")
        {
            this.name = name;
        }

        public override void OnStart(Activity activity)
        {
            // prevents all exporters from exporting this activity
            activity.IsAllDataRequested = false;
        }
    }
}
