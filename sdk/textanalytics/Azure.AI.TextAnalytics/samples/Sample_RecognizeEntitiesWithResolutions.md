# Resolve entities to standard formats with NER resolutions

This sample demonstrates how to resolve entities in a document by using the named entity recognition (NER) feature of the Azure Cognitive Service for Language. NER resolutions provide standard, predictable formats for common types and concepts (such as dates, quantities, and dimensions) to help you retrieve and process information from documents more efficiently. To learn more about NER resolutions, see [here][NER_Resolutions].

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Use NER resolutions

In this sample, we will use the following documents to try to illustrate several different types of resolutions.

```C# Snippet:Sample4_RecognizeEntitiesBatchWithResolutionsAsync_GetDocuments
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
```

NER resolutions is a new preview feature that is currently only supported starting with model version `2022-10-01-preview`. When using the `TextAnalyticsClient`, you can specify the model version that you want to use via a `TextAnalyticsRequestOptions` object.

```C# Snippet:Sample4_RecognizeEntitiesBatchWithResolutionsAsync_SetModelVersion
TextAnalyticsRequestOptions options = new() { ModelVersion = "2022-10-01-preview" };
```

To recognize and resolve entities in one or more documents, call `RecognizeEntities` or `RecognizeEntitiesBatch` on the `TextAnalyticsClient`, passing the documents and the `TextAnalyticsRequestOptions` object as parameters.

```C# Snippet:Sample4_RecognizeEntitiesBatchWithResolutionsAsync_PerformOperation
Response<RecognizeEntitiesResultCollection> response = await client.RecognizeEntitiesBatchAsync(batchedDocuments, options);
RecognizeEntitiesResultCollection results = response.Value;
```

You can then inspect each of the entities that were recognized and their corresponding resolutions, if any.

```C# Snippet:Sample4_RecognizeEntitiesBatchWithResolutionsAsync_ViewResults
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
```

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

[NER_Resolutions]: https://aka.ms/azsdk/language/ner-resolutions
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
