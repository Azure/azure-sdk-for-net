// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Language.Text
{
    /// <summary> Supported parameters for a Dynamic Classification task. </summary>
    public partial class DynamicClassificationActionContent
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DynamicClassificationActionContent"/>. </summary>
        /// <param name="categories"> a list of categories to which input is classified to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="categories"/> is null. </exception>
        public DynamicClassificationActionContent(IEnumerable<string> categories)
        {
            Argument.AssertNotNull(categories, nameof(categories));

            Categories = categories.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="DynamicClassificationActionContent"/>. </summary>
        /// <param name="loggingOptOut"> logging opt out. </param>
        /// <param name="modelVersion"> model version. </param>
        /// <param name="classificationType"> Specifies either one or multiple categories per document. Defaults to multi classification which may return more than one class for each document. </param>
        /// <param name="categories"> a list of categories to which input is classified to. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DynamicClassificationActionContent(bool? loggingOptOut, string modelVersion, ClassificationType? classificationType, IList<string> categories, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            LoggingOptOut = loggingOptOut;
            ModelVersion = modelVersion;
            ClassificationType = classificationType;
            Categories = categories;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DynamicClassificationActionContent"/> for deserialization. </summary>
        internal DynamicClassificationActionContent()
        {
        }

        /// <summary> logging opt out. </summary>
        public bool? LoggingOptOut { get; set; }
        /// <summary> model version. </summary>
        public string ModelVersion { get; set; }
        /// <summary> Specifies either one or multiple categories per document. Defaults to multi classification which may return more than one class for each document. </summary>
        public ClassificationType? ClassificationType { get; set; }
        /// <summary> a list of categories to which input is classified to. </summary>
        public IList<string> Categories { get; }
    }
}
