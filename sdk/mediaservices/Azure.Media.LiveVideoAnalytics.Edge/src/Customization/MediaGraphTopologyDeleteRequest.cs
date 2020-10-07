// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphTopologyDeleteRequest")]
    public partial class MediaGraphTopologyDeleteRequest
    {
        /// <summary> Initializes a new instance of MediaGraphTopologyDeleteRequest. </summary>
        public MediaGraphTopologyDeleteRequest(string name) : this(null, new ItemOperationBase(name))
        {
        }
    }
}
