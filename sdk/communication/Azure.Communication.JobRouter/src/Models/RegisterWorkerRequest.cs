// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class RegisterWorkerRequest
    {
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

        /// <summary> A set of key/value pairs used to match the worker according to specific rules. </summary>
        public LabelCollection Labels { get; set; }

        /// <summary> A collection of channel configurations that define how the worker can do concurrent work per channel. </summary>
        public IEnumerable<ChannelConfiguration> ChannelConfigurations { get; set; }
    }
}
