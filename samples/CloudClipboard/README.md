# Azure SDK for .NET Samples

## CloudClipboard

This sample app illustrates using the Azure Storage and Application Insights services. It allows users to upload to a newly created blob. This sample app is featured in the following YouTube videos:

- [Exploring the new Azure .NET SDKs](https://www.youtube.com/watch?v=Hxne-iM1CtI)
- [Understanding the Azure.Core library](https://www.youtube.com/watch?v=0tKXe1wOqI8)
- [Securing your Azure apps with Azure.Identity](https://www.youtube.com/watch?v=1VRx_Xpvlro)

### To run the sample.
1. Replaced "cloudclips" with your Storage Account's Name in appsettings.json
```
{
    ...
    "BlobServiceUri": "https://cloudclips.blob.core.windows.net/"
}
```
2. To light up App Insights, add the [InstrumentationKey value](https://learn.microsoft.com/azure/bot-service/bot-service-resources-app-insights-keys?view=azure-bot-service-4.0#instrumentation-key) in appsettings.json
```
{
    ...
    "AZURE_INSTRUMENTATION_KEY": "Your App Insights Instrumentation Key"
}
```

## GarbageCollector
This is created for helping clean the Blob service in CloudClipBoard sample.
### To run the sample.
1. Replaced "cloudclips" with your Storage Account's Name in GarbageCollector.Program.cs
```
private static readonly Uri BlobServiceUri = new Uri("https://cloudclips.blob.core.windows.net/");
```

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

