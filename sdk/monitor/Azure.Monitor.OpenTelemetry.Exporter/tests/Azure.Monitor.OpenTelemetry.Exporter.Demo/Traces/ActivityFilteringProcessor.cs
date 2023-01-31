// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tracing.Customization
{
    internal class ActivityFilteringProcessor : BaseProcessor<Activity>
    {
        public override void OnStart(Activity activity)
        {
            // prevents all exporters from exporting activities with activity.Kind == ActivityKind.Producer
            if (activity.Kind == ActivityKind.Producer)
            {
                activity.IsAllDataRequested = false;
            }
        }
    }
}
