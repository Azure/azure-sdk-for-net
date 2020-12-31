// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    ///
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class AzureClientAttribute: Attribute, IConnectionProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        public AzureClientAttribute(string connection)
        {
            Connection = connection;
        }

        /// <inheritdoc />
        public string Connection { get; set; }
    }
}
