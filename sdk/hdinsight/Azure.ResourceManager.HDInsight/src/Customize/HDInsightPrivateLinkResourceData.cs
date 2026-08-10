// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.HDInsight
{
    // The TypeSpec-generated HDInsightPrivateLinkResourceData only has an internal constructor,
    // but the old AutoRest-generated version exposed a public parameterless constructor.
    // This custom partial class re-adds the public constructor for backward compatibility (ApiCompat).
    public partial class HDInsightPrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="HDInsightPrivateLinkResourceData"/>. </summary>
        public HDInsightPrivateLinkResourceData()
        { }
    }
}
