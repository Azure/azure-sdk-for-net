// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphInstanceListRequest")]
    public partial class MediaGraphInstanceListRequest
    {
        /// <summary> Initializes a new instance of MediaGraphTopologyGetRequest. </summary>
        public MediaGraphInstanceListRequest() : this(null, new ItemOperationBase(""))
        {
        }
    }
}
