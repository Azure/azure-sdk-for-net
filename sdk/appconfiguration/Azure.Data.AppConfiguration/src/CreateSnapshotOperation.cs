// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// TODO
    /// </summary>
    public class CreateSnapshotOperation : Operation<ConfigurationSettingsSnapshot>
    {
        //private HttpPipeline _httpPipeline;

        /// <summary>
        /// TODO
        /// </summary>
        public override ConfigurationSettingsSnapshot Value { get; }

        /// <summary>
        /// TODO
        /// </summary>
        public override bool HasValue { get; }

        /// <summary>
        /// TODO
        /// </summary>
        public override string Id { get; }

        /// <summary>
        /// TODO
        /// </summary>
        public override bool HasCompleted { get; }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
