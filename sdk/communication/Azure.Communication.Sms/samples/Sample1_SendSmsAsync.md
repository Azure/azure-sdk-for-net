# Send SMS Message

This sample demonstrates how to send an SMS message to an individual or a group of recipients.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `SmsClient`

SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
```

## Send SMS to a single recipient

To send a SMS message, call the `Send` or `SendAsync` function from the SmsClient. The returned value is `SmsSendResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Sms_Tests_SendAsync
SmsSendResult sendResult = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: "<to-phone-number>", // E.164 formatted recipient phone number
    message: "Hi");
Console.WriteLine($"Sms id: {sendResult.MessageId}");
```

## Send SMS to multiple recipients with options

To send a SMS message to a list of recipients, call the `Send` or `SendAsync` function from the SmsClient with a list of recipient's phone numbers. You may also add pass in an options object to specify whether the delivery report should be enabled and set custom tags. The returned value is a collection of `SmsSendResult` objects -- one for each of the receipients.

```C# Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptionsAsync
var response = await smsClient.SendAsync(
    from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
    to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
    message: "Weekly Promotion!",
    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
    {
        Tag = "marketing", // custom tags
        DeliveryReportTimeoutInSeconds = 90
    });
foreach (SmsSendResult result in response.Value)
{
    Console.WriteLine($"Sms id: {result.MessageId}");
    Console.WriteLine($"Send Result Successful: {result.Successful}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Sms/README.md#getting-started
