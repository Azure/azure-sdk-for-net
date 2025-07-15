// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary> Linked service reference type. </summary>
    [PropertyReferenceType]
    public partial class DataFactoryLinkedServiceReference
    {
        /// <summary> Initializes a new instance of DataFactoryLinkedServiceReference. </summary>
        internal DataFactoryLinkedServiceReference()
        {
            Parameters = new ChangeTrackingDictionary<string, BinaryData?>();
        }
        /// <summary> Initializes a new instance of DataFactoryLinkedServiceReference. </summary>
        /// <param name="referenceKind"> Linked service reference type. </param>
        /// <param name="referenceName"> Reference LinkedService name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="referenceName"/> is null. </exception>
        [InitializationConstructor]
        public DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind referenceKind, string referenceName)
        {
            Argument.AssertNotNull(referenceName, nameof(referenceName));

            ReferenceKind = referenceKind;
            ReferenceName = referenceName;
            Parameters = new ChangeTrackingDictionary<string, BinaryData?>();
        }

        /// <summary> Initializes a new instance of DataFactoryLinkedServiceReference. </summary>
        /// <param name="referenceKind"> Linked service reference type. </param>
        /// <param name="referenceName"> Reference LinkedService name. </param>
        /// <param name="parameters"> Arguments for LinkedService. </param>
        [SerializationConstructor]
        internal DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind referenceKind, string? referenceName, IDictionary<string, BinaryData?> parameters)
        {
            ReferenceKind = referenceKind;
            ReferenceName = referenceName;
            Parameters = parameters;
        }

        /// <summary> Linked service reference type. </summary>
        public DataFactoryLinkedServiceReferenceKind ReferenceKind { get; set; }
        /// <summary> Reference LinkedService name. </summary>
        public string? ReferenceName { get; set; }
        /// <summary>
        /// Arguments for LinkedService.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public IDictionary<string, BinaryData?> Parameters { get; }
    }
}
