// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsRouterJobReceivedEventData
    {
        /// <summary> Router Job Received Job Status. </summary>
        [CodeGenMember("JobStatus")]
        public AcsRouterJobStatus? Status { get; }

        /// <summary> Router Job Received Job Status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Models.AcsRouterJobStatus? JobStatus
        {
            get
            {
                if (Status.HasValue)
                {
                    return new Azure.Messaging.EventGrid.Models.AcsRouterJobStatus(Status.Value.ToString());
                }

                return null;
            }
        }
    }
}
