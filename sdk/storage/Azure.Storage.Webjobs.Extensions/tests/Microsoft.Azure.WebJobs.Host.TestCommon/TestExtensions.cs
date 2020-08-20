// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    // $$$
    public static class TestExtensions
    {
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
    }
}
