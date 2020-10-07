// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    [CodeGenSuppress("MediaGraphInstanceDeActivateRequest")]
    public partial class MediaGraphInstanceDeActivateRequest
    {
        /// <summary> Initializes a new instance of MediaGraphInstanceActivateRequest. </summary>
        public MediaGraphInstanceDeActivateRequest(string name): this(null, new ItemOperationBase(name))
        {
        }
    }
}
