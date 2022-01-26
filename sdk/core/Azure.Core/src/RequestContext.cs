// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options which can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext
    {
        private int[]? _customErrors;
        private int[]? _customNonErrors;

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

        /// <summary>
        /// Indicates whether ConfigureResponse has been called.
        /// </summary>
        public bool HasCustomClassifier => _customErrors != null || _customNonErrors != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        public RequestContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class using the given <see cref="ErrorOptions"/>.
        /// </summary>
        /// <param name="options"></param>
        public static implicit operator RequestContext(ErrorOptions options) => new RequestContext { ErrorOptions = options };

        /// <summary>
        /// The token to check for cancellation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public ErrorOptions ErrorOptions { get; set; } = ErrorOptions.Default;

        /// <summary>
        /// Adds an <see cref="HttpPipelinePolicy"/> into the pipeline for the duration of this request.
        /// The position of policy in the pipeline is controlled by <paramref name="position"/> parameter.
        /// If you want the policy to execute once per client request use <see cref="HttpPipelinePosition.PerCall"/>
        /// otherwise use <see cref="HttpPipelinePosition.PerRetry"/> to run the policy for every retry.
        /// </summary>
        /// <param name="policy">The <see cref="HttpPipelinePolicy"/> instance to be added to the pipeline.</param>
        /// <param name="position">The position of the policy in the pipeline.</param>
        public void AddPolicy(HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            Policies ??= new();
            Policies.Add((position, policy));
        }

        /// <summary>
        /// </summary>
        /// <param name="statusCodes">Status codes that will not be considered to be error status codes for the scope of the service method call.</param>
        /// <param name="isError">Whether the passed-in status codes will be considered to be error codes for the duration of this request.</param>
        public void ConfigureResponse(int[] statusCodes, bool isError)
        {
            CopyOrMerge(statusCodes, ref isError ? ref _customErrors : ref _customNonErrors);
        }

        private static void CopyOrMerge(int[] source, ref int[]? target)
        {
            if (target == null)
            {
                target = new int[source.Length];
                Array.Copy(source, target, source.Length);
            }
            else // merge arrays
            {
                var origLength = target.Length;
                Array.Resize(ref target, source.Length + target.Length);
                Array.Copy(source, 0, target, origLength, source.Length);
            }
        }

        internal void CustomizeClassifier(ResponseClassifier classifier)
        {
            classifier.CustomizeErrors(_customErrors, _customNonErrors);
        }
    }
}
