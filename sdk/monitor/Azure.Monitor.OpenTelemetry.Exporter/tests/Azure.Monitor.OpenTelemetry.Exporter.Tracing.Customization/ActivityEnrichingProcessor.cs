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
    public class ActivityEnrichingProcessor : BaseProcessor<Activity>
    {
        private readonly string name;

        public ActivityEnrichingProcessor(string name = "ActivityEnrichingProcessor")
        {
            this.name = name;
        }

        public override void OnEnd(Activity activity)
        {
            // The updated activity will be available to all processors which are called after this processor.
            activity.DisplayName = "Updated-" + activity.DisplayName;
            activity.SetTag("CustomDimension1", "Value1");
            activity.SetTag("CustomDimension2", "Value2");
        }
    }
}
