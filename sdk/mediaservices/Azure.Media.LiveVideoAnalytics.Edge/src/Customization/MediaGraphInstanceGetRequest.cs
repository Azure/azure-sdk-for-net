// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphInstanceGetRequest")]
    public partial class MediaGraphInstanceGetRequest
    {
        /// <summary> Initializes a new instance of MediaGraphTopologyGetRequest. </summary>
        public MediaGraphInstanceGetRequest(string name) : this(null, new ItemOperationBase(name))
        {
        }
    }
}
