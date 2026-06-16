// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid.Models
{
    // Preserve the pre-migration model factory overloads for abstract compat models.
    [CodeGenSuppress("StaticRoutingEnrichment", typeof(string), typeof(StaticRoutingEnrichmentType))]
    [CodeGenSuppress("EventGridInputSchemaMapping", typeof(InputSchemaMappingType))]
    [CodeGenSuppress("EventSubscriptionDestination", typeof(EndpointType))]
    [CodeGenSuppress("DeliveryAttributeMapping", typeof(string), typeof(DeliveryAttributeMappingType))]
    [CodeGenSuppress("AdvancedFilter", typeof(AdvancedFilterOperatorType), typeof(string))]
    [CodeGenSuppress("DeadLetterDestination", typeof(DeadLetterEndPointType))]
    [CodeGenSuppress("EventGridFilter", typeof(FilterOperatorType), typeof(string))]
    public static partial class ArmEventGridModelFactory
    {
        public static StaticRoutingEnrichment StaticRoutingEnrichment(string key = default, string valueType = default)
            => new UnknownStaticRoutingEnrichment(
                key,
                valueType is null ? default : new StaticRoutingEnrichmentType(valueType),
                default);

        public static EventGridInputSchemaMapping EventGridInputSchemaMapping(string inputSchemaMappingType = default)
            => new UnknownInputSchemaMapping(
                inputSchemaMappingType is null ? default : new InputSchemaMappingType(inputSchemaMappingType),
                default);

        public static EventSubscriptionDestination EventSubscriptionDestination(string endpointType = default)
            => new UnknownEventSubscriptionDestination(
                endpointType is null ? default : new EndpointType(endpointType),
                default);

        public static DeliveryAttributeMapping DeliveryAttributeMapping(string name = default, string type = default)
            => new UnknownDeliveryAttributeMapping(
                name,
                type is null ? default : new DeliveryAttributeMappingType(type),
                default);

        public static AdvancedFilter AdvancedFilter(string operatorType = default, string key = default)
            => new UnknownAdvancedFilter(
                operatorType is null ? default : new AdvancedFilterOperatorType(operatorType),
                key,
                default);

        public static DeadLetterDestination DeadLetterDestination(string endpointType = default)
            => new UnknownDeadLetterDestination(
                endpointType is null ? default : new DeadLetterEndPointType(endpointType),
                default);

        public static EventGridFilter EventGridFilter(string operatorType = default, string key = default)
            => new UnknownFilter(
                operatorType is null ? default : new FilterOperatorType(operatorType),
                key,
                default);
    }
}
