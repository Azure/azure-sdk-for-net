// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionPolicyItem")]
    public partial class ExceptionPolicyItem
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
