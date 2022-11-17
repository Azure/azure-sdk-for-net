// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Contains details of errors encountered during a job execution. </summary>
    public partial class InputError
    {
        /// <summary> Initializes a new instance of InputError. </summary>
        /// <param name="id"> The ID of the input. </param>
        /// <param name="error"> Error encountered. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="error"/> is null. </exception>
        public InputError(string id, Error error)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(error, nameof(error));

            Id = id;
            Error = error;
        }

        /// <summary> The ID of the input. </summary>
        public string Id { get; set; }
        /// <summary> Error encountered. </summary>
        public Error Error { get; set; }
    }
}
