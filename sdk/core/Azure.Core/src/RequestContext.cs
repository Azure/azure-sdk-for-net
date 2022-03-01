﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure
{
    /// <summary>
    /// Options that can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext : RequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        public RequestContext() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class from
        /// a <see cref="RequestOptions"/> instance.
        /// </summary>
        public RequestContext(RequestOptions options) : base(options)
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
    }
}
