// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ContainerApps.Sandbox
{
    public partial class SandboxGroup
    {
        /// <summary> Gets the total count of sandboxes. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns> The total count of sandboxes and the HTTP response. </returns>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <exception cref="FormatException"> The response body does not contain a valid integer. </exception>
        /// <exception cref="OverflowException"> The count is outside the range of an <see cref="Int32"/>. </exception>
        public virtual Response<int> GetSandboxesCount(CancellationToken cancellationToken = default)
        {
            Response result = GetSandboxesCount(cancellationToken.ToRequestContext());
            using Stream stream = result.Content.ToStream();
            using StreamReader reader = new StreamReader(stream);

            return Response.FromValue(
                int.Parse(reader.ReadToEnd(), CultureInfo.InvariantCulture),
                result);
        }

        /// <summary> Gets the total count of sandboxes. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <returns> The total count of sandboxes and the HTTP response. </returns>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <exception cref="FormatException"> The response body does not contain a valid integer. </exception>
        /// <exception cref="OverflowException"> The count is outside the range of an <see cref="Int32"/>. </exception>
        public virtual async Task<Response<int>> GetSandboxesCountAsync(CancellationToken cancellationToken = default)
        {
            Response result = await GetSandboxesCountAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
            using Stream stream = result.Content.ToStream();
            using StreamReader reader = new StreamReader(stream);

            return Response.FromValue(
                int.Parse(reader.ReadToEnd(), CultureInfo.InvariantCulture),
                result);
        }
    }
}
