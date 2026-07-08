// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Customization to restore properties/ctors dropped by MPG generator due to
    // @@alternateType identity-aliasing on LinkedServiceReference (issue #59298).
    public partial class RedshiftUnloadSettings
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryLinkedServiceReference S3LinkedServiceName { get; set; }

        /// <summary> Initializes a new instance restored as workaround for issue #59298. </summary>
        public RedshiftUnloadSettings(DataFactoryLinkedServiceReference s3LinkedServiceName, DataFactoryElement<string> bucketName)
            : this()
        {
            S3LinkedServiceName = s3LinkedServiceName;
            BucketName = bucketName;
        }
    }
}
