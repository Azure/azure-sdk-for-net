# Service Bus Extension for Azure Functions guide to running integration tests locally
Integration tests are implemented in the `EndToEndTests` and `SessionsEndToEndTests` classes and require special configuration to execute locally in Visual Studio or via dotnet test.  

All configuration is done via a json file called `appsettings.tests.json` which on windows should be located in the `%USERPROFILE%\.azurefunctions` folder (e.g. `C:\Users\user123\.azurefunctions`)

**Note:** *The specifics of the configuration will change when the validation code is modified so check the code for the latest configuration if the tests do not pass as this readme file may not have been updated with each code change.*

Create the appropriate Azure resources if needed as explained below and create or update the `appsettings.tests.json` file in the location specified above by copying the configuration below and replacing all the `PLACEHOLDER` values

appsettings.tests.json contents
```
{
    "ConnectionStrings": {
        "ServiceBus": "PLACEHOLDER",
        "ServiceBusSecondary": "PLACEHOLDER"
    },
    "AzureWebJobsStorage": "PLACEHOLDER"
}
```
Create a storage account and configure its connection string into `AzureWebJobsStorage`.  This will be used by the webjobs hosts created by the tests.

Create two service bus namespaces and configure their connection strings in `ConnectionStrings:ServiceBus` and `ConnectionStrings:ServiceBusSecondary`.  
1. In the namespace configured into `ConnectionStrings:ServiceBus`, create queues with the following names:
    1. `core-test-queue1`
    2. `core-test-queue2`
    3. `core-test-queue3`
    4. `core-test-queue1-sessions` (enable sessions when creating)
2. In the namespace configured into `ConnectionStrings:ServiceBus`, create topics and subscriptions with the following names:
    1. `core-test-topic1` with two subscriptions: `sub1` and `sub2`
    2. `core-test-topic1-sessions` with one subscription: `sub1-sessions` (enable sessions in the subscription when creating)
2. In the namespace configured into `ConnectionStrings:ServiceBusSecondary`, create queues with the following names:
    1. `core-test-queue1`

  Change the message lock duration setting on all queues and subscriptions to 5 minutes to all for delays associated with stepping through code in debug mode.