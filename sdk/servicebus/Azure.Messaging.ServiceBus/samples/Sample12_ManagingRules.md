# Managing rules

As shown in the article on [Topic filters and actions](https://learn.microsoft.com/azure/service-bus-messaging/topic-filters), rules can be managed using the `ServiceBusAdministrationClient`. In order to perform these operations, you need to have `Manage` rights to the Service Bus namespace. When using Azure Identity, this translates to requiring the [Service Bus Data Owner role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#azure-service-bus-data-owner) be granted to your identity.

It is also possible to perform these rule management operations using the `ServiceBusRuleManager` type. The major benefit to using this type is that you only need `Listen` rights for the subscription you wish to manage rules for, which corresponds to the [Service Bus Data Receiver role](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#azure-service-bus-data-receiver). The following snippet provides an example of how to use this type.

```C# Snippet:ServiceBusManageRules
string connectionString = "<connection_string>";
string topicName = "<topic_name>";
string subscriptionName = "<subscription_name>";

await using var client = new ServiceBusClient(connectionString);

await using ServiceBusRuleManager ruleManager = client.CreateRuleManager(topicName, subscriptionName);

// By default, subscriptions are created with a default rule that always evaluates to True. In order to filter, we need
// to delete the default rule. You can skip this step if you create the subscription with the ServiceBusAdministrationClient,
// and specify a the FalseRuleFilter in the create rule options.
await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);
await ruleManager.CreateRuleAsync("brand-filter", new CorrelationRuleFilter { Subject = "Toyota" });

// create the sender
ServiceBusSender sender = client.CreateSender(topicName);

ServiceBusMessage[] messages =
{
    new ServiceBusMessage { Subject = "Ford", ApplicationProperties = { { "Price", 25000 } } },
    new ServiceBusMessage { Subject = "Toyota", ApplicationProperties = { { "Price", 28000 } } },
    new ServiceBusMessage { Subject = "Honda", ApplicationProperties = { { "Price", 35000 } } }
};

// send the messages
await sender.SendMessagesAsync(messages);

// create a receiver for our subscription that we can use to receive and settle the message
ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

// receive the message - we only get back the Toyota message
while (true)
{
    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
    if (receivedMessage == null)
    {
        break;
    }
    Console.WriteLine($"Brand: {receivedMessage.Subject}, Price: {receivedMessage.ApplicationProperties["Price"]}");
    await receiver.CompleteMessageAsync(receivedMessage);
}

await ruleManager.CreateRuleAsync("price-filter", new SqlRuleFilter("Price < 30000"));
await ruleManager.DeleteRuleAsync("brand-filter");

// we can also use the rule manager to iterate over the rules on the subscription.
await foreach (RuleProperties rule in ruleManager.GetRulesAsync())
{
    // we should only have 1 rule at this point - "price-filter"
    Console.WriteLine(rule.Name);
}

// send the messages again - because the subscription rules are evaluated when the messages are first enqueued, adding rules
// for messages that are already in a subscription would have no effect.
await sender.SendMessagesAsync(messages);

// receive the messages - we get back both the Ford and the Toyota
while (true)
{
    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
    if (receivedMessage == null)
    {
        break;
    }
    Console.WriteLine($"Brand: {receivedMessage.Subject}, Price: {receivedMessage.ApplicationProperties["Price"]}");
}
```
