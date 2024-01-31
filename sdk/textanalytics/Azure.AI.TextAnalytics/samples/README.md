---
page_type: sample
languages:
- csharp
products:
- azure-cognitive-services
- azure-text-analytics
- language-service
name: Azure Text Analytics samples for .NET
description: Samples for the Azure.AI.TextAnalytics client library
---

# Azure Cognitive Services Text Analytics client library for .NET

Text Analytics is part of the Azure Cognitive Service for Language, a cloud-based service that provides Natural Language Processing (NLP) features for understanding and analyzing text. This client library offers the following features:

* Language detection
* Sentiment analysis
* Key phrase extraction
* Named entity recognition (NER)
* Personally identifiable information (PII) entity recognition
* Entity linking
* Text analytics for health
* Custom named entity recognition (Custom NER)
* Custom text classification
* Extractive text summarization
* Abstractive text summarization

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

## Common scenarios samples

* [Detect Language](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample1_DetectLanguage.md)
* [Analyze Sentiment](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample2_AnalyzeSentiment.md)
* [Extract Key Phrases](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample3_ExtractKeyPhrases.md)
* [Recognize Named Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample4_RecognizeEntities.md)
* [Recognize PII Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample5_RecognizePiiEntities.md)
* [Recognize Linked Entities](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample6_RecognizeLinkedEntities.md)
* [Analyze Healthcare Entities](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample7_AnalyzeHealthcareEntities.md)
* [Custom Named Entity Recognition](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample8_RecognizeCustomEntities.md)
* [Custom Single Label Classification](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample9_SingleLabelClassify.md)
* [Custom Multi Label Classification](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample10_MultiLabelClassify.md)
* [Extractive Summarization](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample11_ExtractiveSummarize.md)
* [Abstractive Summarization](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample12_AbstractiveSummarize.md)

## Advanced samples

* [Understand how to work with long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_LROPolling.md)
* [Perform multiple text analysis actions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_AnalyzeActions.md)
* [Analyze Sentiment with Opinion Mining](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample2.1_AnalyzeSentimentWithOpinionMining.md)
* [Recognize PII Entities with specific categories](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesWithCategoriesFilter.cs)
* [Mock a client for testing](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/textanalytics/Azure.AI.TextAnalytics/samples/Sample_MockClient.md) using the [Moq](https://github.com/Moq/moq4/) library

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md