# Developer driven evolution
To add a convenience API that returns raw JSON to a model, steps are:

**Get convenience method signiture from protocol method signiture.** Replace the optional `RequestContext` parameter with an optional `CancellationToken`. If there is an input `RequestContent`, replace it with a model type `T`. Replace the return value `Response` with `Response<T>`.
```C#
- public virtual async Task<Response> CreateMetricFeedbackAsync(RequestContent content, RequestContext context = null);
+ public virtual async Task<Response<MetricFeedback>> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default);
```
**Pick the best convenience method name fitting your scenario.** You could use the same method name as the initial protocol method only when your convenience method has different **required** parameter list. E.g.,
- ```(string feedId, RequestContext requestContext = null)``` and ```(string feedId, CancellationToken cancellationToken = default)``` have the same required parameter list. You cannot add the convenience method as an overload method by leveraging the initial method name, because it will cause an ambiguous compile error when you call it without `RequestContext`/`CancellationToken`.
- ```(RequestContent content, RequestContext requestContext = null)``` and ```(string feedId, CancellationToken cancellationToken = default)``` have different required parameter list. You are safe to use same method name with the initial protocol name.

If your convenience method has the same parameter list as that of the protocol method, we suggest 
- Adding a suffix `Value` to the initial method name as the convenience method name, if the initial method is singular (e.g., `GetMetricFeedbackAsync`).
- Adding a suffix `Values` to the initial method name as the convenience method name, if the initial method is plural (e.g., `GetMetricFeedbacksAsync`).

**Create the models for the convenience APIs you've added.** Currently it can be generated manually. We will support generate it automatically.

**Add helper method mapping between raw response and model in generated or handcrafted model.** Examples for model `MetricFeedback` (Models/MetricFeedback/MetricFeedback.cs) are:
```C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricFeedback
    {
        // Mapping raw response to model
        internal static MetricFeedback FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            // Add your deserialization logic in DeserializeMetricFeedback
            return DeserializeMetricFeedback(document.RootElement);
        }

        // Mapping model to raw response
        internal static RequestContent ToRequestContent(MetricFeedback metricFeedback)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(metricFeedback);
            return content;
        }
    }
}
```
**Call the protocol method and map returned raw response to model.** You could call the protocol method inside your convenience method and map the returned raw response to model. See different scenarios and corresponding examples below. 


## Improve a GET method that returns raw JSON to return a model

**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual async Task<Response> GetMetricFeedbackAsync(Guid feedbackId, RequestContext context = null)
        {
        }
    }
}
```
**Improve the GET method (MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Suggest appending value to method name
        public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackValueAsync(Guid feedbackId, CancellationToken cancellationToken = default)
        {
            // Call protocol method
            Response response = await GetMetricFeedbackAsync(feedbackId, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            MetricFeedback value = MetricFeedback.FromResponse(response);
        }
    }
}
```

## Improve a GET paging method that returns raw JSON to return a model

**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual AsyncPageable<BinaryData> GetMetricFeedbacksAsync(Guid feedbackId, RequestContext context = null)
        {
        }
    }
}
```
**Improve the GET paging method (MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Suggest appending values to a plural method name
        public virtual AsyncPageable<MetricFeedback> GetMetricFeedbacksValuesAsync(Guid feedbackId, CancellationToken cancellationToken = default)
        {
            // Call protocol method
            AsyncPageable<BinaryData> pageableBindaryData = GetMetricFeedbacksAsync(feedbackId, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            return PageableHelpers.Select(pageableBindaryData, response => ConvertToDataFeeds(DataFeedList.FromResponse(response).Value));
        }
    }
}
```

## Improve a POST method that reads a raw JSON to accept a model
**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual async Task<Response> CreateMetricFeedbackAsync(RequestContent content, RequestContext context = null)
        {
        }
    }
}
```
**Improve the POST method (MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Can use same method name here
        public virtual async Task<Response<MetricFeedback>> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            // Convert model to binary content
            RequestContent requestContent = MetricFeedback.ToRequestContent(feedback);

            // Call protocol method
            Response response = await CreateMetricFeedbackAsync(requestContent, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            MetricFeedback value = MetricFeedback.FromResponse(response);
        }
    }
}
```
