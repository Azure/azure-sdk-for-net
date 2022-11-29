// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tracing.Customization
{
    public class ActivityEnrichingProcessor : BaseProcessor<Activity>
    {
        public override void OnEnd(Activity activity)
        {
            // The updated activity will be available to all processors which are called after this processor.
            activity.DisplayName = "Enriched-" + activity.DisplayName;
            activity.SetTag("CustomDimension1", "Value1");
            activity.SetTag("CustomDimension2", "Value2");
            activity.SetTag("ActivityKind", activity.Kind);
        }
    }
}
