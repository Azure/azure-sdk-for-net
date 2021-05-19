## Using the administration client

This sample aims to demonstrate how to create a subscription on an existing topic.

### Create the subscription

```C# Snippet:CreateAdministrationClient
string connectionString = "<connection_string>";

string topicName = "<topic_name>";
string subscriptionName = "<subscription_name>";

// create a client from a connection string
ServiceBusAdministrationClient client = new ServiceBusAdministrationClient(connectionString);

// check if the topic exists before creating the subscription


bool topicExists = await client.TopicExistsAsync();

if (!topicExists) {
    // handle errors
    return;
}

bool subscriptionExists = await client.SubscriptionExistsAsync(topicName, subscriptionName);

if (!subscriptionExists) {
    await client.CreateSubscriptionAsync(new CreateSubscriptionOptions(topicName, subscriptionName)
    {
        // subscription options such as:
        // Max delivery count
        // Retry policy
        // Batching options
        // Forwarding options
    });
}

return;
```