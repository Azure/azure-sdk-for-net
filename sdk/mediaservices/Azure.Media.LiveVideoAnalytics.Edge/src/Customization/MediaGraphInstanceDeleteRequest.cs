// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphInstanceDeleteRequest")]
    public partial class MediaGraphInstanceDeleteRequest
    {
        /// <summary> Initializes a new instance of MediaGraphInstanceActivateRequest. </summary>
        public MediaGraphInstanceDeleteRequest(string name) : this(null, new ItemOperationBase(name))
        {
        }
    }
}
