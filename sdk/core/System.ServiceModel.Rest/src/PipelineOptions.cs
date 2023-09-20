// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class PipelineOptions
    {
        /// <summary>
        /// TBD.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        public ResultErrorOptions ErrorOptions { get; set; } = ResultErrorOptions.Default;

        /// <summary>
        /// TBD
        /// </summary>
        public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;
    }
}
