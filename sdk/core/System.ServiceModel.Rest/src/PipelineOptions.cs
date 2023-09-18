// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest.Core
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract class PipelineOptions
    {
        // TODO: Why does this need a CancellationToken?  I think this is what
        // prevents ClientOptions from inheriting from this.

        ///// <summary>
        ///// TBD.
        ///// </summary>
        //public CancellationToken CancellationToken { get; set; }
    }
}
