// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// Although relationships have a user-defined schema, these properties should exist on every instance. This is
    /// useful to use as a base class to ensure your custom relationships have the necessary properties.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    /// <example>
    /// Here's an example of  how to use the BasicRelationship helper class to serialize and create a relationship.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleCreateBasicRelationship">
    /// var basicRelationshipPayload = new BasicRelationship
    /// {
    ///     Id = &quot;sampleRelationship1Id&quot;,
    ///     SourceId = &quot;sampleTwin1Id&quot;,
    ///     TargetId = &quot;sampleTwin2Id&quot;,
    ///     Name = &quot;related&quot;,
    ///     CustomProperties =
    ///     {
    ///         { &quot;Prop1&quot;, &quot;Prop1 value&quot; },
    ///         { &quot;Prop2&quot;, 6 }
    ///     }
    /// };
    ///
    /// string serializedRelationship = JsonSerializer.Serialize(basicRelationshipPayload);
    /// Response&lt;string&gt; createRelationshipResponse = await client.CreateRelationshipAsync(&quot;sampleTwin1Id&quot;, &quot;sampleRelationship1Id&quot;, serializedRelationship);
    /// Console.WriteLine($&quot;Created a digital twin relationship with Id sampleRelationship1Id from digital twin with Id sampleTwin1Id to digital twin with Id sampleTwin2Id. &quot; +
    ///     $&quot;Response status: {createRelationshipResponse.GetRawResponse().Status}.&quot;);
    /// </code>
    ///
    /// Here's an example of  how to use the BasicRelationship helper class to get and deserialize a relationship.
    ///
    /// <code snippet="Snippet:DigitalTwinsSampleGetBasicRelationship">
    /// Response&lt;string&gt; getBasicRelationshipResponse = await client.GetRelationshipAsync(&quot;sampleTwin1Id&quot;, &quot;sampleRelationship1Id&quot;);
    /// if (getBasicRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
    /// {
    ///     BasicRelationship basicRelationship = JsonSerializer.Deserialize&lt;BasicRelationship&gt;(getBasicRelationshipResponse.Value);
    ///     Console.WriteLine($&quot;Retrieved relationship with Id {basicRelationship.Id} from digital twin with Id {basicRelationship.SourceId}. &quot; +
    ///         $&quot;Response status: {getBasicRelationshipResponse.GetRawResponse().Status}.\n\t&quot; +
    ///         $&quot;Prop1: {basicRelationship.CustomProperties[&quot;Prop1&quot;]}\n\t&quot; +
    ///         $&quot;Prop2: {basicRelationship.CustomProperties[&quot;Prop2&quot;]}&quot;);
    /// }
    /// </code>
    /// </example>
    public class BasicRelationship
    {
        /// <summary>
        /// The unique Id of the relationship. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$relationshipId")]
        public string Id { get; set; }

        /// <summary>
        /// The unique Id of the target digital twin. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$targetId")]
        public string TargetId { get; set; }

        /// <summary>
        /// The unique Id of the source digital twin. This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$sourceId")]
        public string SourceId { get; set; }

        /// <summary>
        /// The name of the relationship, which defines the type of link (e.g. Contains). This field is present on every relationship.
        /// </summary>
        [JsonPropertyName("$relationshipName")]
        public string Name { get; set; }

        /// <summary>
        /// Additional properties defined in the model. This field will contain any properties of the relationship that are not already defined by the other strong types of this class.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> CustomProperties { get; set; } = new Dictionary<string, object>();
    }
}
