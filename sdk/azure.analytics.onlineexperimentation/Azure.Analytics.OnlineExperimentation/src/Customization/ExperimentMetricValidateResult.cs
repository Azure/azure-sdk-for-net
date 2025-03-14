// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class ExperimentMetricValidateResult
    {
        /// <summary>
        /// Determines if the experiment metric validation succeeded.
        /// </summary>
        /// <returns><see langword="true"/> when the <see cref="Result"/> indicates a valid metric, otherwise <see langword="false"/>. </returns>
        public bool IsValid()
        {
            return Result.IsValid();
        }
    }
}
