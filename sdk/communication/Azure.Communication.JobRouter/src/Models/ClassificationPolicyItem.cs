// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("ClassificationPolicyItem")]
    public partial class ClassificationPolicyItem
    {
        [CodeGenMember("Etag")]
        internal string _etag
        {
            get
            {
                return ETag.ToString();
            }
            set
            {
                ETag = new ETag(value);
            }
        }

        /// <summary> (Optional) The Concurrency Token. </summary>
        public ETag ETag { get; internal set; }
    }
}
