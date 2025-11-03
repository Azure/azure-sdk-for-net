# Get SMS Delivery Report

This sample demonstrates how to get a delivery report for a specific outgoing SMS message.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating an `SmsClient`

SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, SMS clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
```

## Get delivery report for a sent message

After sending an SMS message, you can retrieve its delivery report using the message ID returned from the Send operation.

```C# Snippet:Azure_Communication_Sms_Tests_Samples_GetDeliveryReport
var deliveryReport = smsClient.GetDeliveryReport(outgoingMessageId: "<message-id>");
Console.WriteLine($"Delivery Status: {deliveryReport.Value.DeliveryStatus}");
Console.WriteLine($"From: {deliveryReport.Value.From}, To: {deliveryReport.Value.To}");
Console.WriteLine($"Message Id: {deliveryReport.Value.MessageId}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Sms/README.md#getting-started

