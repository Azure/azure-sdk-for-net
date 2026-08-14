// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore URI constructor overloads whose legacy parameter shapes differ from the discriminator-first constructors emitted by TypeSpec.
    public partial class StaticInputData
    {
        /// <summary> Initializes a new instance of <see cref="StaticInputData"/>. </summary>
        // TODO: Remove these compatibility constructors after https://github.com/microsoft/typespec/issues/11588 is fixed.
        public StaticInputData(JobInputType jobInputType, Uri uri, DateTimeOffset windowStart, DateTimeOffset windowEnd) : base(MonitoringInputDataType.Static, jobInputType, uri)
        {
            WindowEnd = windowEnd;
            WindowStart = windowStart;
        }

        /// <summary> Initializes a new instance of <see cref="StaticInputData"/>. </summary>
        public StaticInputData(JobInputType jobInputType, string uri, DateTimeOffset windowStart, DateTimeOffset windowEnd) : this(jobInputType, uri is null ? null : new Uri(uri), windowStart, windowEnd)
        {
        }
    }
}
