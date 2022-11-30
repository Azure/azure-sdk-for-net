// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("JobQueue")]
    public partial class JobQueue
    {
        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key, x => x.Value.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                Labels = value != null && value.Count != 0
                    ? value.ToDictionary(x => x.Key, x => new LabelValue(x.Value))
                    : new Dictionary<string, LabelValue>();
            }
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, LabelValue> Labels { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary> Initializes a new instance of JobQueue. </summary>
        internal JobQueue()
        {
        }
    }
}
