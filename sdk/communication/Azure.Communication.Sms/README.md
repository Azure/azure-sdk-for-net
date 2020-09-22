# Azure Communication SMS client library for .NET
> Server Version: 
Chat client: 2020-07-20-preview1

This package contains a C# SDK for Azure Communication Services for SMS and Telephony.

## Getting started

### Install the package
Install the Azure Communication SMS client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Sms --version 1.0.0-beta.1
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a Communication Service resource to use this package.

### Key concepts
`SmsClient` provides the functionality to send messages between phone numbers.

### Using statements
```C# Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using Azure.Communication.Sms;
```

### Authenticate the client
SMS clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
SmsClient client = new SmsClient(connectionString);
```

## Examples
### Send a SMS Message
To send a SMS message, call the `Send` or `SendAsync` function from the `SmsClient`.
```C# Snippet:Azure_Communication_Sms_Tests_SendAsync
SendSmsResponse result = await client.SendAsync(
   from: new PhoneNumber("+18001230000"), // Phone number acquired on your Azure Communication resource
   to: new PhoneNumber("+18005670000"),
   message: "Hi");
Console.WriteLine($"Sms id: {result.MessageId}");
```

## Troubleshooting
All SMS operations will throw a RequestFailedException on failure.

```C# Snippet:Azure_Communication_Sms_Tests_Troubleshooting
try
{
    SendSmsResponse result = await client.SendAsync(
       from: new PhoneNumber("+18001230000"), // Phone number acquired on your Azure Communication resource
       to: new PhoneNumber("+18005670000"),
       message: "Hi");
    Console.WriteLine($"Sms id: {result.MessageId}");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[nuget]: https://www.nuget.org/
