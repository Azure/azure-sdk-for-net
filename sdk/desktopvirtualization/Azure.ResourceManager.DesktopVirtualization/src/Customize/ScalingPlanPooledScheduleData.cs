// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The new generated code removed the parameterless constructor
// (the model now requires parameters). This restores the public parameterless constructor
// so existing callers that create ScalingPlanPooledScheduleData via `new ScalingPlanPooledScheduleData()` are not broken.

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class ScalingPlanPooledScheduleData
    {
        /// <summary> Initializes a new instance of <see cref="ScalingPlanPooledScheduleData"/>. </summary>
        public ScalingPlanPooledScheduleData()
        {
        }
    }
}
