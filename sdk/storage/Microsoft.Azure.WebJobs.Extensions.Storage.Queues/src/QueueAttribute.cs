// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
#pragma warning disable CA1200 // Avoid using cref tags with a prefix
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Queue.
    /// </summary>
    /// <remarks>
    /// The method parameter type can be one of the following:
    /// <list type="bullet">
    /// <item><description><see cref="QueueClient"/></description></item>
    /// <item><description><see cref="QueueMessage"/> (out parameter)</description></item>
    /// <item><description><see cref="string"/> (out parameter)</description></item>
    /// <item><description><see cref="T:byte[]"/> (out parameter)</description></item>
    /// <item><description><see cref="BinaryData"/> (out parameter)</description></item>
    /// <item><description>A user-defined type (out parameter, serialized as JSON)</description></item>
    /// <item><description><see cref="ICollector{T}"/> of these types (to enqueue multiple messages via <see cref="ICollector{T}.Add"/></description></item>
    /// <item><description><see cref="IAsyncCollector{T}"/> of these types (to enqueue multiple messages via <see cref="IAsyncCollector{T}.AddAsync(T, System.Threading.CancellationToken)"/></description></item>
    /// </list>
    /// </remarks>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [DebuggerDisplay("{QueueName,nq}")]
    [ConnectionProvider(typeof(StorageAccountAttribute))]
    [Binding]
    public class QueueAttribute : Attribute, IConnectionProvider
    {
        private readonly string _queueName;

        /// <summary>Initializes a new instance of the <see cref="QueueAttribute"/> class.</summary>
        /// <param name="queueName">The name of the queue to which to bind.</param>
        public QueueAttribute(string queueName)
        {
            _queueName = queueName;
        }

        /// <summary>
        /// Gets the name of the queue to which to bind.
        /// </summary>
        [AutoResolve]
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
