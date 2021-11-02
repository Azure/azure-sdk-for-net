// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    public partial class UpdateJobLabelsRequest
    {
        /// <summary> Initializes a new instance of UpdateJobLabelsRequest. </summary>
        /// <param name="labels"> A set of key/value pairs used as metadata for a job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="labels"/> is null. </exception>
        internal UpdateJobLabelsRequest(IDictionary<string, object> labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException(nameof(labels));
            }

            _labels = labels;
        }

        /// <summary> Initializes a new instance of UpdateJobLabelsRequest. </summary>
        /// <param name="labels"> A LabelCollection containing key/value pairs used as metadata for a job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="labels"/> is null. </exception>
        public UpdateJobLabelsRequest(LabelCollection labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException(nameof(labels));
            }

            Labels = labels;
        }

        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels?.ToDictionary(x => x.Key, x => x.Value);
            }
            set
            {
                Labels = LabelCollection.BuildFromRawValues(value);
            }
        }

        public LabelCollection Labels { get; set; }
    }
}
