// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphTopologyListRequest")]
    public partial class MediaGraphTopologyListRequest
    {
        /// <summary> Initializes a new instance of MediaGraphTopologyGetRequest. </summary>
        public MediaGraphTopologyListRequest() : this(null, new ItemOperationBase(""))
        {
        }
    }
}
