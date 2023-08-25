// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Communication.JobRouter.Models;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("PassThroughWorkerSelectorAttachment")]
    public partial class PassThroughWorkerSelectorAttachment
    {
        /// <summary> Initializes a new instance of PassThroughWorkerSelectorAttachment. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value pass through. </param>
        /// <param name="expiresAfter"> Describes how long the attached label selector is valid. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public PassThroughWorkerSelectorAttachment(string key, LabelOperator labelOperator, TimeSpan? expiresAfter = default)
            : this(null, key, labelOperator, expiresAfter?.TotalSeconds)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
        }

        /// <summary> Describes how long the attached label selector is valid in seconds. </summary>
        internal TimeSpan? ExpiresAfter { get; set; }

        [CodeGenMember("ExpiresAfterSeconds")]
        internal double? _expiresAfterSeconds {
            get
            {
                return ExpiresAfter?.TotalSeconds is null or 0 ? null : ExpiresAfter?.TotalSeconds;
            }
            set
            {
                ExpiresAfter = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
        }
    }
}
