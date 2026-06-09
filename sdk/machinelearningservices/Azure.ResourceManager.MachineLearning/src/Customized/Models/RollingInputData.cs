// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class RollingInputData
    {
        /// <summary> Initializes a new instance of <see cref="RollingInputData"/>. </summary>
        public RollingInputData(JobInputType jobInputType, Uri uri, TimeSpan windowOffset, TimeSpan windowSize) : base(MonitoringInputDataType.Rolling, jobInputType, uri)
        {
            WindowOffset = windowOffset;
            WindowSize = windowSize;
        }

        /// <summary> Initializes a new instance of <see cref="RollingInputData"/>. </summary>
        public RollingInputData(JobInputType jobInputType, string uri, TimeSpan windowOffset, TimeSpan windowSize) : this(jobInputType, uri is null ? null : new Uri(uri), windowOffset, windowSize)
        {
        }
    }
}
