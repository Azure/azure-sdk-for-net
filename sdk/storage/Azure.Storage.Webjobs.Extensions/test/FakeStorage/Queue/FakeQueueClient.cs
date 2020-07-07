// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Storage.Queue.Protocol;
using Microsoft.Azure.Storage.Shared.Protocol;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FakeStorage
{
    public class FakeQueueClient : CloudQueueClient
    {
        public static Uri FakeUri = new Uri("http://localhost:10000/fakeaccount/");

        internal FakeAccount _account;

        public FakeQueueClient(FakeAccount account) :            
            base(FakeUri, account._creds)
        {
            _account = account;
        }

        public override bool Equals(object obj)
        {
            if (obj is FakeQueueClient other)
            {
                return this.BaseUri == other.BaseUri;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override CloudQueue GetQueueReference(string queueName)
        {
            return new FakeQueue(this, queueName);
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync()
        {
            throw new NotImplementedException();
            // return base.GetServicePropertiesAsync();
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.GetServicePropertiesAsync(options, operationContext);
        }

        public override Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.GetServicePropertiesAsync(options, operationContext, cancellationToken);
        }

        public override Task<ServiceStats> GetServiceStatsAsync()
        {
            throw new NotImplementedException();
            // return base.GetServiceStatsAsync();
        }

        public override Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.GetServiceStatsAsync(options, operationContext);
        }

        public override Task<ServiceStats> GetServiceStatsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.GetServiceStatsAsync(options, operationContext, cancellationToken);
        }

        public override Task<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken)
        {
            throw new NotImplementedException();
            // return base.ListQueuesSegmentedAsync(currentToken);
        }

        public override Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken)
        {
            throw new NotImplementedException();
            // return base.ListQueuesSegmentedAsync(prefix, currentToken);
        }

        public override Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.ListQueuesSegmentedAsync(prefix, detailsIncluded, maxResults, currentToken, options, operationContext);
        }

        public override Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails detailsIncluded, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.ListQueuesSegmentedAsync(prefix, detailsIncluded, maxResults, currentToken, options, operationContext, cancellationToken);
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            throw new NotImplementedException();
            // return base.SetServicePropertiesAsync(properties);
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            throw new NotImplementedException();
            // return base.SetServicePropertiesAsync(properties, requestOptions, operationContext);
        }

        public override Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // return base.SetServicePropertiesAsync(properties, requestOptions, operationContext, cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
