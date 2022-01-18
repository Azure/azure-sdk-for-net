// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Tag information. </summary>
    public partial class PredefinedTagValue
    {
        /// <summary> Initializes a new instance of TagValue. </summary>
        internal PredefinedTagValue()
        {
        }

        /// <summary> Initializes a new instance of TagValue. </summary>
        /// <param name="id"> The tag value ID. </param>
        /// <param name="tagValueValue"> The tag value. </param>
        /// <param name="count"> The tag value count. </param>
        internal PredefinedTagValue(string id, string tagValueValue, PredefinedTagCount count)
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
        public PredefinedTagCount Count { get; }
    }
}
