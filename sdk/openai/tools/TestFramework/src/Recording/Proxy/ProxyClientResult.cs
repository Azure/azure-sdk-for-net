// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.RecordingProxy
{
    /// <summary>
    /// Represents the result of a proxy client operation.
    /// </summary>
    public class ProxyClientResult : ClientResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyClientResult"/> class.
        /// </summary>
        /// <param name="response">The pipeline response.</param>
        public ProxyClientResult(PipelineResponse response) : base(response)
        { }

        /// <summary>
        /// Gets the recording ID from the response headers.
        /// </summary>
        public string? RecordingId => GetRawResponse().Headers.GetFirstOrDefault(ProxyClient.X_RECORDING_ID_HEADER);
    }

    /// <summary>
    /// Represents the result of a proxy client operation.
    /// </summary>
    /// <typeparam name="TResult">The type of the result value.</typeparam>
    public class ProxyClientResult<TResult> : ProxyClientResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyClientResult{TResult}"/> class.
        /// </summary>
        /// <param name="value">The result value.</param>
        /// <param name="response">The pipeline response.</param>
        public ProxyClientResult(TResult value, PipelineResponse response) : base(response)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the result value.
        /// </summary>
        public virtual TResult Value { get; }

        /// <summary>
        /// Implicitly converts the <see cref="ProxyClientResult{TResult}"/> to the result value.
        /// </summary>
        /// <param name="result">The <see cref="ProxyClientResult{TResult}"/> instance.</param>
        /// <returns>The result value.</returns>
        public static implicit operator TResult(ProxyClientResult<TResult> result) => result.Value;
    }
}
