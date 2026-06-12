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
            => new UnknownStaticRoutingEnrichment(key, valueType, default);

        public static EventGridInputSchemaMapping EventGridInputSchemaMapping(string inputSchemaMappingType = default)
            => new UnknownInputSchemaMapping(inputSchemaMappingType, default);

        public static EventSubscriptionDestination EventSubscriptionDestination(string endpointType = default)
            => new UnknownEventSubscriptionDestination(endpointType, default);

        public static DeliveryAttributeMapping DeliveryAttributeMapping(string name = default, string type = default)
            => new UnknownDeliveryAttributeMapping(name, type, default);

        public static AdvancedFilter AdvancedFilter(string operatorType = default, string key = default)
            => new UnknownAdvancedFilter(operatorType, key, default);

        public static DeadLetterDestination DeadLetterDestination(string endpointType = default)
            => new UnknownDeadLetterDestination(endpointType, default);

        public static EventGridFilter EventGridFilter(string operatorType = default, string key = default)
            => new UnknownFilter(operatorType, key, default);
    }
}
