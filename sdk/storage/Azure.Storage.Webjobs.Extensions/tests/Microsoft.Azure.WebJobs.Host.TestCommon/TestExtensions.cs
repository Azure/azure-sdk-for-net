// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    // $$$
    public static class TestExtensions
    {
        // Internal Ctor
        public static CloudBlobDirectory NewCloudBlobDirectory(StorageUri uri, string prefix, CloudBlobContainer container)
        {
            var ctor = typeof(CloudBlobDirectory).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                new Type[] { typeof(StorageUri), typeof(string), typeof(CloudBlobContainer) },
                null);

            var result = ctor.Invoke(new object[] { uri, prefix, container });
            return (CloudBlobDirectory)result;
        }

        public static T SetInternalProperty<T>(this T instance, string name, object value)
        {
            var t = instance.GetType();

            var prop = t.GetProperty(name,
              BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            // Reflection has a quirk.  While a property is inherited, the setter may not be.
            // Need to request the property on the type it was declared.
            while (!prop.CanWrite)
            {
                t = t.BaseType;
                prop = t.GetProperty(name,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            }

            prop.SetValue(instance, value);
            return instance;
        }

        public static BlobProperties SetEtag(this BlobProperties props, string etag)
        {
            props.SetInternalProperty(nameof(BlobProperties.ETag), etag);
            return props;
        }

        public static BlobProperties SetLastModified(this BlobProperties props, DateTimeOffset? modified)
        {
            props.SetInternalProperty(nameof(BlobProperties.LastModified), modified);

            return props;
        }

        public static BlobProperties SetLeaseState(this BlobProperties props, LeaseState state)
        {
            props.SetInternalProperty(nameof(BlobProperties.LeaseState), state);

            return props;
        }

        public static BlobProperties SetLeaseStatus(this BlobProperties props, LeaseStatus status)
        {
            props.SetInternalProperty(nameof(BlobProperties.LeaseStatus), status);

            return props;
        }

        public static BlobResultSegment NewBlobResultSegment(
            BlobContinuationToken continuationToken,
            IEnumerable<ICloudBlob> results)
        {
            IEnumerable<IListBlobItem> l = results;
            var result = new BlobResultSegment(results, continuationToken);
            return result;
        }

        // TODO (kasobol-msft) is this dead code ??
        public static QueueMessage SetDequeueCount(this QueueMessage msg, int value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.DequeueCount), value);
            return msg;
        }

        // TODO (kasobol-msft) is this dead code ??
        public static QueueMessage SetExpirationTime(this QueueMessage msg, DateTimeOffset? value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.ExpiresOn), value);
            return msg;
        }

        // TODO (kasobol-msft) is this dead code ??
        public static QueueMessage SetId(this QueueMessage msg, string value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.MessageId), value);
            return msg;
        }

        public static QueueMessage SetInsertionTime(this QueueMessage msg, DateTimeOffset? value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.InsertedOn), value);
            return msg;
        }

        // TODO (kasobol-msft) is this dead code ??
        public static QueueMessage SetNextVisibleTime(this QueueMessage msg, DateTimeOffset? value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.NextVisibleOn), value);
            return msg;
        }

        // TODO (kasobol-msft) is this dead code ??
        public static QueueMessage SetPopReceipt(this QueueMessage msg, string value)
        {
            msg.SetInternalProperty(nameof(QueueMessage.PopReceipt), value);
            return msg;
        }
    }
}
