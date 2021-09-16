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
    internal class MyFilteringProcessor : BaseProcessor<Activity>
    {
        private readonly Func<Activity, bool> filter;
        private readonly BaseProcessor<Activity> processor;

        public MyFilteringProcessor(BaseProcessor<Activity> processor, Func<Activity, bool> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (processor == null)
            {
                throw new ArgumentNullException(nameof(processor));
            }

            this.filter = filter;
            this.processor = processor;
        }

        public override void OnEnd(Activity activity)
        {
            // Call the underlying processor
            // only if the Filter returns true.
            if (this.filter(activity))
            {
                this.processor.OnEnd(activity);
            }
        }
    }
}
