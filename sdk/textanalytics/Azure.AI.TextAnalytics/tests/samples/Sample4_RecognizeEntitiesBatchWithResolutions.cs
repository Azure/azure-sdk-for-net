// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples
    {
        [Test]
        public void RecognizeEntitiesBatchWithResolutions()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential apiKey = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, apiKey, CreateSampleOptions());

            string documentA = "The dog is 14 inches tall and weighs 20 lbs. It is 5 years old.";
            string documentB = "This is the first aircraft of its kind. It can fly at over 1,300 mph and carry 65-80 passengers.";
            string documentC = "The apartment (840 sqft with 2 bedrooms) costs 2,000 USD per month and will be available on 11/01/2022.";
            string documentD = "Mix 1 cup of sugar. Bake for 60 minutes in an oven preheated to 350 degrees F.";
            string documentE = "They retrieved 200 terabytes of data from 10/24/2022 to 10/28/2022.";

            List<TextDocumentInput> batchedDocuments = new() {
                new TextDocumentInput("1", documentA),
                new TextDocumentInput("2", documentB),
                new TextDocumentInput("3", documentC),
                new TextDocumentInput("4", documentD),
                new TextDocumentInput("5", documentE),
            };

            TextAnalyticsRequestOptions options = new() { ModelVersion = "2022-10-01-preview" };
            Response<RecognizeEntitiesResultCollection> response = client.RecognizeEntitiesBatch(batchedDocuments, options);
            RecognizeEntitiesResultCollection results = response.Value;

            Console.WriteLine($"Recognize Entities, model version: \"{results.ModelVersion}\"");
            Console.WriteLine();

            foreach (RecognizeEntitiesResult documentResult in results)
            {
                Console.WriteLine($"Result for document with Id = \"{documentResult.Id}\":");

                foreach (CategorizedEntity entity in documentResult.Entities)
                {
                    if (entity.Resolutions.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"  Text: \"{entity.Text}\"");

                    foreach (BaseResolution resolution in entity.Resolutions)
                    {
                        switch (resolution)
                        {
                            case AgeResolution age:
                                Console.WriteLine($"    AgeResolution:");
                                Console.WriteLine($"      Unit : {age.Unit}");
                                Console.WriteLine($"      Value: {age.Value}");
                                break;

                            case AreaResolution area:
                                Console.WriteLine($"    AreaResolution:");
                                Console.WriteLine($"      Unit : {area.Unit}");
                                Console.WriteLine($"      Value: {area.Value}");
                                break;

                            case CurrencyResolution currency:
                                Console.WriteLine($"    CurrencyResolution:");
                                Console.WriteLine($"      Iso4217: {currency.Iso4217}");
                                Console.WriteLine($"      Unit   : {currency.Unit}");
                                Console.WriteLine($"      Value  : {currency.Value}");
                                break;

                            case DateTimeResolution dateTime:
                                Console.WriteLine($"    DateTimeResolution:");
                                Console.WriteLine($"      DateTimeSubKind: {dateTime.DateTimeSubKind}");
                                Console.WriteLine($"      Modifier       : {dateTime.Modifier}");
                                Console.WriteLine($"      Timex          : {dateTime.Timex}");
                                Console.WriteLine($"      Value          : {dateTime.Value}");
                                break;

                            case InformationResolution information:
                                Console.WriteLine($"    InformationResolution:");
                                Console.WriteLine($"      Unit : {information.Unit}");
                                Console.WriteLine($"      Value: {information.Value}");
                                break;

                            case LengthResolution length:
                                Console.WriteLine($"    LengthResolution:");
                                Console.WriteLine($"      Unit : {length.Unit}");
                                Console.WriteLine($"      Value: {length.Value}");
                                break;

                            case NumberResolution number:
                                Console.WriteLine($"    NumberResolution:");
                                Console.WriteLine($"      NumberKind: {number.NumberKind}");
                                Console.WriteLine($"      Value     : {number.Value}");
                                break;

                            case NumericRangeResolution numericRange:
                                Console.WriteLine($"    NumericRangeResolution:");
                                Console.WriteLine($"      Maximum  : {numericRange.Maximum}");
                                Console.WriteLine($"      Minimum  : {numericRange.Minimum}");
                                Console.WriteLine($"      RangeKind: {numericRange.RangeKind}");
                                break;

                            case OrdinalResolution ordinal:
                                Console.WriteLine($"    OrdinalResolution:");
                                Console.WriteLine($"      Offset    : {ordinal.Offset}");
                                Console.WriteLine($"      RelativeTo: {ordinal.RelativeTo}");
                                Console.WriteLine($"      Value     : {ordinal.Value}");
                                break;

                            case TemperatureResolution temperature:
                                Console.WriteLine($"    TemperatureResolution:");
                                Console.WriteLine($"      Unit : {temperature.Unit}");
                                Console.WriteLine($"      Value: {temperature.Value}");
                                break;

                            case TemporalSpanResolution temporalSpan:
                                Console.WriteLine($"    TemporalSpanResolution:");
                                Console.WriteLine($"      Begin   : {temporalSpan.Begin}");
                                Console.WriteLine($"      Duration: {temporalSpan.Duration}");
                                Console.WriteLine($"      End     : {temporalSpan.End}");
                                Console.WriteLine($"      Modifier: {temporalSpan.Modifier}");
                                Console.WriteLine($"      Timex   : {temporalSpan.Timex}");
                                break;

                            case VolumeResolution volume:
                                Console.WriteLine($"    VolumeResolution:");
                                Console.WriteLine($"      Unit : {volume.Unit}");
                                Console.WriteLine($"      Value: {volume.Value}");
                                break;

                            case SpeedResolution speed:
                                Console.WriteLine($"    SpeedResolution:");
                                Console.WriteLine($"      Unit : {speed.Unit}");
                                Console.WriteLine($"      Value: {speed.Value}");
                                break;

                            case WeightResolution weight:
                                Console.WriteLine($"    WeightResolution:");
                                Console.WriteLine($"      Unit : {weight.Unit}");
                                Console.WriteLine($"      Value: {weight.Value}");
                                break;
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
