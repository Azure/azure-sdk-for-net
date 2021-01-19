// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
#pragma warning disable CA1200 // Avoid using cref tags with a prefix
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Queue message, causing the function to run when a
    /// message is enqueued.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description><see cref="QueueMessage"/></description></item>
    /// <item><description><see cref="string"/></description></item>
    /// <item><description><see cref="T:byte[]"/></description></item>
    /// <item><description><see cref="BinaryData"/></description></item>
    /// <item><description>A user-defined type (serialized as JSON)</description></item>
    /// </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
    [DebuggerDisplay("{QueueName,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public sealed class QueueTriggerAttribute : Attribute, IConnectionProvider
    {
        private readonly string _queueName;

        /// <summary>Initializes a new instance of the <see cref="QueueTriggerAttribute"/> class.</summary>
        /// <param name="queueName">The name of the queue to which to bind.</param>
        public QueueTriggerAttribute(string queueName)
        {
            _queueName = queueName;
        }

        /// <summary>Gets the name of the queue to which to bind.</summary>
        public string QueueName
        {
            get { return _queueName; }
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Azure Storage connection string.
        /// </summary>
        public string Connection { get; set; }
    }
}
