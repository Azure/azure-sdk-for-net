// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.Language.Conversations
{
    public partial class BaseResolution
    {
        internal static BaseResolution DeserializeBaseResolution(JsonElement element)
        {
            if (element.TryGetProperty("resolutionKind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AgeResolution": return AgeResolution.DeserializeAgeResolution(element);
                    case "AreaResolution": return AreaResolution.DeserializeAreaResolution(element);
                    case "BooleanResolution": return BooleanResolution.DeserializeBooleanResolution(element);
                    case "CurrencyResolution": return CurrencyResolution.DeserializeCurrencyResolution(element);
                    case "DateTimeResolution": return DateTimeResolution.DeserializeDateTimeResolution(element);
                    case "InformationResolution": return InformationResolution.DeserializeInformationResolution(element);
                    case "LengthResolution": return LengthResolution.DeserializeLengthResolution(element);
                    case "NumberResolution": return NumberResolution.DeserializeNumberResolution(element);
                    case "NumericRangeResolution": return NumericRangeResolution.DeserializeNumericRangeResolution(element);
                    case "OrdinalResolution": return OrdinalResolution.DeserializeOrdinalResolution(element);
                    case "SpeedResolution": return SpeedResolution.DeserializeSpeedResolution(element);
                    case "TemperatureResolution": return TemperatureResolution.DeserializeTemperatureResolution(element);
                    case "TemporalSpanResolution": return TemporalSpanResolution.DeserializeTemporalSpanResolution(element);
                    case "VolumeResolution": return VolumeResolution.DeserializeVolumeResolution(element);
                    case "WeightResolution": return WeightResolution.DeserializeWeightResolution(element);
                }
            }
            return UnknownBaseResolution.DeserializeUnknownBaseResolution(element);
        }
    }
}
