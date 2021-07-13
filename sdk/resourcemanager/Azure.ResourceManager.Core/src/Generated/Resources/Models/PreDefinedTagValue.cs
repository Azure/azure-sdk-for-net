// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary> Tag information. </summary>
    public partial class PreDefinedTagValue
    {
        /// <summary> Initializes a new instance of TagValue. </summary>
        internal PreDefinedTagValue()
        {
        }

        /// <summary> Initializes a new instance of TagValue. </summary>
        /// <param name="id"> The tag value ID. </param>
        /// <param name="tagValueValue"> The tag value. </param>
        /// <param name="count"> The tag value count. </param>
        internal PreDefinedTagValue(string id, string tagValueValue, PreDefinedTagCount count)
        {
            Id = id;
            TagValueValue = tagValueValue;
            Count = count;
        }

        /// <summary> The tag value ID. </summary>
        public string Id { get; }
        /// <summary> The tag value. </summary>
        public string TagValueValue { get; }
        /// <summary> The tag value count. </summary>
        public PreDefinedTagCount Count { get; }
    }
}
