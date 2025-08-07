# Opt Out Management
This sample demonstrates how to check if customers phone numbers are in the Opt Out list, and add or remove entries to it.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `SmsClient`
SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
```

## Check if a list of recipients is in the Opt Out list
To check if the recipients are in the Opt Out list, call the function from the `SmsClient.OptOuts.Check` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Check
var optOutCheckResults = smsClient.OptOuts.Check(
   from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
   to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutCheckResults.Value)
{
    Console.WriteLine($"{result.To}: {result.IsOptedOut}");
}
```
## Add a list of recipients to Opt Out list
To add the list of recipients to Opt Out list, call the function from the `SmsClient.OptOuts.Add` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Add
var optOutAddResults = smsClient.OptOuts.Add(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
foreach (var result in optOutAddResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```

## Remove a list of recipients from Opt Out list
To remove the list of recipients to Opt Out list, call the function from the `SmsClient.OptOuts.Remove` with a list of recipient phone numbers.
```C# Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Remove
var optOutRemoveResults = smsClient.OptOuts.Remove(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers

foreach (var result in optOutRemoveResults.Value)
{
    Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Sms/README.md#getting-started
