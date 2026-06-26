// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // These seven types are abstract, polymorphic base models whose discriminator enum
    // (StaticRoutingEnrichmentType, EndpointType, FilterOperatorType, etc.) is internal.
    // For each one the generator emits a public ArmEventGridModelFactory overload that takes
    // the internal discriminator type as a parameter. Because that type is not public, the
    // generated signature is malformed (it renders as "global::.<Type>") and fails to compile
    // (CS1001). The CodeGenSuppress attributes below remove those broken generated overloads,
    // and the replacement methods expose valid public factories that accept a string
    // discriminator and return the Unknown* fallback subtype instead of leaking the internal enum.
    [CodeGenSuppress("StaticRoutingEnrichment", typeof(string), typeof(StaticRoutingEnrichmentType))]
    [CodeGenSuppress("EventGridInputSchemaMapping", typeof(InputSchemaMappingType))]
    [CodeGenSuppress("EventSubscriptionDestination", typeof(EndpointType))]
    [CodeGenSuppress("DeliveryAttributeMapping", typeof(string), typeof(DeliveryAttributeMappingType))]
    [CodeGenSuppress("AdvancedFilter", typeof(AdvancedFilterOperatorType), typeof(string))]
    [CodeGenSuppress("DeadLetterDestination", typeof(DeadLetterEndPointType))]
    [CodeGenSuppress("EventGridFilter", typeof(FilterOperatorType), typeof(string))]
    public static partial class ArmEventGridModelFactory
    {
        /// <summary> Creates a Static Routing Enrichment model. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="valueType"> The value type. </param>
        /// <returns> The operation result. </returns>
        public static StaticRoutingEnrichment StaticRoutingEnrichment(string key = default, string valueType = default)
            => new UnknownStaticRoutingEnrichment(
                key,
                valueType is null ? default : new StaticRoutingEnrichmentType(valueType),
                default);

        /// <summary> Creates a Event Grid Input Schema Mapping model. </summary>
        /// <param name="inputSchemaMappingType"> The input schema mapping type. </param>
        /// <returns> The operation result. </returns>
        public static EventGridInputSchemaMapping EventGridInputSchemaMapping(string inputSchemaMappingType = default)
            => new UnknownInputSchemaMapping(
                inputSchemaMappingType is null ? default : new InputSchemaMappingType(inputSchemaMappingType),
                default);

        /// <summary> Creates a Event Subscription Destination model. </summary>
        /// <param name="endpointType"> The endpoint type. </param>
        /// <returns> The operation result. </returns>
        public static EventSubscriptionDestination EventSubscriptionDestination(string endpointType = default)
            => new UnknownEventSubscriptionDestination(
                endpointType is null ? default : new EndpointType(endpointType),
                default);

        /// <summary> Creates a Delivery Attribute Mapping model. </summary>
        /// <param name="name"> The resource name. </param>
        /// <param name="type"> The delivery attribute mapping type. </param>
        /// <returns> The operation result. </returns>
        public static DeliveryAttributeMapping DeliveryAttributeMapping(string name = default, string type = default)
            => new UnknownDeliveryAttributeMapping(
                name,
                type is null ? default : new DeliveryAttributeMappingType(type),
                default);

        /// <summary> Creates a Advanced Filter model. </summary>
        /// <param name="operatorType"> The operator type. </param>
        /// <param name="key"> The tag key. </param>
        /// <returns> The operation result. </returns>
        public static AdvancedFilter AdvancedFilter(string operatorType = default, string key = default)
            => new UnknownAdvancedFilter(
                operatorType is null ? default : new AdvancedFilterOperatorType(operatorType),
                key,
                default);

        /// <summary> Creates a Dead Letter Destination model. </summary>
        /// <param name="endpointType"> The endpoint type. </param>
        /// <returns> The operation result. </returns>
        public static DeadLetterDestination DeadLetterDestination(string endpointType = default)
            => new UnknownDeadLetterDestination(
                endpointType is null ? default : new DeadLetterEndPointType(endpointType),
                default);

        /// <summary> Creates a Event Grid Filter model. </summary>
        /// <param name="operatorType"> The operator type. </param>
        /// <param name="key"> The tag key. </param>
        /// <returns> The operation result. </returns>
        public static EventGridFilter EventGridFilter(string operatorType = default, string key = default)
            => new UnknownFilter(
                operatorType is null ? default : new FilterOperatorType(operatorType),
                key,
                default);
    }
}
