// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Allows binding to an Azure SDK client using connection settings defined in the <see cref="Connection"/> configuration section.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class AzureClientAttribute: Attribute, IConnectionProvider
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="AzureClientAttribute"/>.
        /// </summary>
        /// <param name="connection">The app setting name that contains the connection string.</param>
        public AzureClientAttribute(string connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the connection string.
        /// </summary>
        public string Connection { get; set; }
    }
}
