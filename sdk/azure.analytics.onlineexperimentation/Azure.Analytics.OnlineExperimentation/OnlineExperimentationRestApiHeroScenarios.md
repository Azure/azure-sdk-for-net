# Azure ExP Metric Hero Scenarios

This file contains "Hero Scenarios" which are top scenarios on how service is consumed.

## Introduction

Azure ExP team aims to provide a platform where Teams can improve their product through experimentation.

## Hero Scenarios

Users can define a “Metric” to aggregate their logs in a specific way. To effectively define a metric, we support a predefined list of metric functions. These metric functions are:

- **EventCount** - Count the observations of an event
- **UserCount** - Count the users who encounter an event.
- **EventRate** - Count the percentage of events that satisfy a condition
- **UserRate** - Count the percentage of users with the start event that then encounter the end event
- **Sum** - The sum of an event property
- **Average** - The average of an event property
- **Percentile** - The percentile of an event property

## Examples

### Example 1 (EventCount)

Let's say, User created a chatbot and wants to compute the number of Prompts sent on that chatbot by their customers. They can define the metric as below:

```json
{
  "id": "PromptSentCount",
  "lifecycle": "Active",
  "displayName": "Total number of prompts sent",
  "description": "Placeholder description",
  "categories": ["Usage"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "EventCount",
    "event": {
      "eventName": "PromptSent"
    }
  }
}
```

In this definition above, the compute will count the eventCount where eventName is "PromptSent".

### Example 2 (UserCount)

Let's say, the user wants to know how many unique users use the chatbot present on the checkout.html page. The metric can be defined as:

```json
{
  "id": "UsersPromptSent",
  "lifecycle": "Active",
  "displayName": "Users with at least one prompt sent on checkout page",
  "description": "Placeholder description",
  "categories": ["Usage"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "UserCount",
    "event": {
      "eventName": "PromptSent",
      "filter": "Page eq 'checkout.html'"
    }
  }
}
```

Note: The filter is an OData expression. In this version of the API, we would just be supporting a subset of OData filter syntax v4.01:

- Properties (string, float, boolean)
- Literals (string, integer, float, boolean, null)
- Comparison operations - eq, ne, lt, le, gt, ge
- Boolean operations - and, or, not
- Grouping operations (parentheses)

### Example 3 (EventRate)

User wants to check the percentage of LLM responses that are good (Responses are evaluated via a second LLM):

```json
{
  "id": "MoMo_PctRelevanceGood",
  "lifecycle": "Active",
  "displayName": "% evaluated conversations with good relevance",
  "description": "Placeholder description",
  "categories": ["Quality"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "EventRate",
    "event": {
      "eventName": "EvaluateLLM",
      "filter": ""
    },
    "rateCondition": "Relevance ge 4"
  }
}
```

### Example 4 (UserRate)

Let's say, the team wants to know how many users coming from a chat AI assistance are purchasing items worth more than $100. They can define the metric like this:

```json
{
  "id": "PctChatToHighValuePurchaseConversion",
  "lifecycle": "Active",
  "displayName": "% users with LLM interaction who made a high-value purchase",
  "description": "Placeholder description",
  "categories": ["Business"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "UserRate",
    "startEvent": {
      "eventName": "ResponseReceived"
    },
    "endEvent": {
      "eventName": "Purchase",
      "filter": "Revenue ge 100"
    }
  }
}
```

### Example 5 (Sum)

Let's say a team wants to know the total revenue generated from their website:

```json
{
  "id": "TotalRevenue",
  "lifecycle": "Active",
  "displayName": "Total revenue",
  "description": "Placeholder description",
  "categories": ["Business"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "Sum",
    "value": {
      "eventName": "Purchase",
      "eventProperty": "Revenue"
    }
  }
}
```

### Example 6 (Average)

Let's say, a team wants to create a metric to track the average revenue per purchase, then the following metric is needed:

```json
{
  "id": "AvgRevenuePerPurchase",
  "lifecycle": "Active",
  "displayName": "Average revenue per purchase",
  "description": "Placeholder description",
  "categories": ["Business"],
  "desiredDirection": "Increase",
  "definition": {
    "type": "Average",
    "value": {
      "eventName": "Purchase",
      "eventProperty": "Revenue"
    }
  }
}
```

### Example 7 (Percentile)

Say a team wants a metric to measure its LLM response latency, they can use this metric definition:

```json
{
  "id": "P95ResponseTimeSeconds",
  "lifecycle": "Active",
  "displayName": "P95 LLM response time [seconds]",
  "description": "Placeholder description",
  "categories": ["Performance"],
  "desiredDirection": "Decrease",
  "definition": {
    "type": "Percentile",
    "value": {
      "eventName": "ResponseReceived",
      "eventProperty": "ResponseTimeSeconds"
    },
    "percentile": 95
  }
}
