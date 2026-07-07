// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore the legacy setter on the flattened request logging headers collection.
    [CodeGenSuppress("RequestLoggingCaptureHeaders")]
    public partial class DataCollector
    {
        /// <summary> For payload logging, specifies headers to collect along with payload. </summary>
        [WirePath("requestLogging.captureHeaders")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> RequestLoggingCaptureHeaders
        {
            get
            {
                if (RequestLogging is null)
                {
                    RequestLogging = new RequestLogging();
                }

                return RequestLogging.CaptureHeaders;
            }
            set
            {
                if (RequestLogging is null)
                {
                    RequestLogging = new RequestLogging();
                }

                RequestLogging.CaptureHeaders = value;
            }
        }
    }
}
