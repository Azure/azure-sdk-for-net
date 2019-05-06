# Azure Rest API Review Board Core feedback for Microsoft Cognitive Services Personalizer SDK for .NET

We received the following feedback from the Azure Rest API Review Board meeting

1. Expose Rank can be exposed at the base path.
2. Limit the length of all string Ids.
3. TimeSpan types should use format : 'duration'.
4. Use enum for rewardAggregation.
5. Use structured error objects for error responses.
6. Use an application Id to scope all API paths to future protect when Apim key auth is replaced by AD auth.
7. Flatten LogProperties model to use StartTime and EndTime.

All the above feedback has been addressed in our Personalizer.json update PR - https://github.com/Azure/azure-rest-api-specs/pull/5827
azure-sdk-for-net PR - https://github.com/Azure/azure-sdk-for-net/pull/6033
The above PRs will be merged once we get the final sign-off from Azure Rest API Review Board Core team.