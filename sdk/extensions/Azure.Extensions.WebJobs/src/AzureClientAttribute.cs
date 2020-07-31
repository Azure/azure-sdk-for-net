// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;

namespace Azure.Extensions.WebJobs
{
    /// <summary>
    ///
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class AzureClientAttribute: Attribute, IConnectionProvider
    {
        /// <inheritdoc />
        public string Connection { get; set; }
    }
}