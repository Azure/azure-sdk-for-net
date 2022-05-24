# Developer driven evolution
Convenience API is an additive layer on top of protocol method so it could produce improved user experience.

To add a convenience API that takes and returns strongly-typed input and output models instead of raw JSON, steps are:
1. [Create the models](#create-the-models)
2. [Create the convenience method with new signature](#create-the-convenience-method-with-new-signature)
- [Replace input parameters](#replace-input-parameters)
- [Replace output value](#replace-output-value)
- [Rename method if needed](#rename-method-if-needed)
3. [Implement the method](#implement-the-method)
- [Implement GET method](#implement-get-method)
- [Implement POST method](#implement-post-method)
- [Implement GET paging method](#implement-get-paging-method)

## Create the models
Currently the models should be created manually. We will support generate it automatically. So, to avoid the models overwritten, we suggest putting the models under folder {sdk folder}/Models which is the same layer as folder {sdk folder}/Generated.

After you create the models you want, you also need to add the helper methods mapping between raw response and model. Examples for model `MetricFeedback` (Models/MetricFeedback/MetricFeedback.cs) are:
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

        // Mapping model to raw request
        internal static RequestContent ToRequestContent(MetricFeedback metricFeedback)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(metricFeedback);
            return content;
        }
    }
}
```

## Create the convenience method with new signature
To create a convenience method on top of the protocol method, you should not modify generated code. The convenience methods should be added in a separate file as partial class of the class containing protocol methods. You could check out the full examples in [Implement the method](#implement-the-method).

Below is how you could create the convenience signature from protocol method. Here is an example of your generated protocol method.
```C#
public virtual async Task<Response> CreateMetricFeedbackAsync(RequestContent content, RequestContext context = null);
```
You should do the following steps to create the convenience method signature:
### Replace input parameters
- Replace the parameter `RequestContext` with an optional `CancellationToken` with default value.
- If there is an input parameter `RequestContent`, replace it with a wanted input type (e.g., `MetricFeedback`).

After these steps, your convenience method signature will be like:
```C#
public virtual async Task<Response> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default);
```
### Replace output value
- Replace the return value `Response` with `Response<T>` (`T` is your wanted output type, e.g., `MetricFeedback`).

After these steps, your convenience method signature will be like:
```C#
public virtual async Task<Response<MetricFeedback>> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default);
```
### Rename method if needed
Renaming method should follow the rules:

**It is needed if ambiguous call exists**

This situation happens when your protocol method and convenience method have the same required paramater list. E.g.,
```C#
// protocol method
public virtual async Task<Response> GetMetricFeedbackAsync(string feedId, RequestContext context = null);
// Convenience method
public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackAsync(string feedId, CancellationToken cancellationToken = default);
```
Ambiguous call exists when you call
```C#
GetMetricFeedbackAsync(feedId);
```
In this situation, you have to change the convenience name.

**Suggested rename for most cases**

If your convenience method has the same parameter list as that of the protocol method, we suggest 
- Adding a suffix `Value` to the initial method name as the convenience method name, if the initial method is singular (e.g., change `GetMetricFeedbackAsync` to `GetMetricFeedbackValueAsync`).
```C#
public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackValueAsync(string feedId, CancellationToken cancellationToken = default);
```
- Adding a suffix `Values` to the initial method name as the convenience method name, if the initial method is plural (e.g., change `GetMetricFeedbacksAsync` to `GetMetricFeedbackValuesAsync`).
```C#
public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackValuesAsync(string feedId, CancellationToken cancellationToken = default);
```
**If this name doesn't make sense, pick the best name**

If the suggested rename does not apply to your scenario, you could pick the best name fitting your API.

## Implement the method
You could call the protocol method inside your convenience method and map the returned raw response to model.

In the implementation, you should only have one `DiagnosticScope` inside instead of creating `DiagnosticScope` for both protocol method and convenience method. Reasons are:
- We want to reduce the telemetry costs.
- Trace should correspond to logical operations and not implementations

To achieve this, our guidance is:
- Don't open a scope in the grow-up method if it is just a simple wrapper (i.e. if the only thing in the convenience API is serialization and deserialization and the protocol method and convenience API have the same name). Logging will help developers debug any exceptions thrown from the convenience method.
- If the grow-up method diverges much from the protocol method (i.e. if they have different names or code in the convenience method could take much time), do open a scope in the convenience API and turn on suppression of inner scopes.
- If you want to add attributes or otherwise modify scopes, do that in the convenience method.

To turn on the suppression, pass `ture` to `ClientDiagnostics` in the client constructor.
```C#
public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientsOptions options)
{
    ...
    ClientDiagnostics = new ClientDiagnostics(options, true);
    ...
}
```

Below are different scenarios and corresponding examples how to implement the method. 

### Implement GET method

**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual async Task<Response> GetMetricFeedbackAsync(Guid feedbackId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MetricsAdvisorClient.GetMetricFeedback");
        }
    }
}
```
**Improve the GET method ({Other manual folder}/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Suggest appending value to method name
        public virtual async Task<Response<MetricFeedback>> GetMetricFeedbackValueAsync(Guid feedbackId, CancellationToken cancellationToken = default)
        {
            // Open a new scope here and the inner scope will be suppressed
            using var scope = ClientDiagnostics.CreateScope("MetricsAdvisorClient.GetMetricFeedbackValue");
            
            // Call protocol method
            Response response = await GetMetricFeedbackAsync(feedbackId, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            MetricFeedback value = MetricFeedback.FromResponse(response);

            // return the response
            return Response.FromValue(value, response);
        }
    }
}
```

### Implement POST method
**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual async Task<Response> CreateMetricFeedbackAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("MetricsAdvisorClient.CreateMetricFeedback");
        }
    }
}
```
**Improve the POST method ({Other manual folder}/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Can use same method name here
        public virtual async Task<Response<MetricFeedback>> CreateMetricFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            // We don't open a new scope here because it is just a wrapper
            // Convert model to binary content
            RequestContent requestContent = MetricFeedback.ToRequestContent(feedback);

            // Call protocol method
            Response response = await CreateMetricFeedbackAsync(requestContent, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            MetricFeedback value = MetricFeedback.FromResponse(response);

            // return the response
            return Response.FromValue(value, response);
        }
    }
}
```

## Implement GET paging method

**Generated code before (Generated/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        public virtual AsyncPageable<BinaryData> GetMetricFeedbacksAsync(Guid feedbackId, RequestContext context = null)
        {
            return GetMetricFeedbacksImplementationAsync("MetricsAdvisorClient.GetMetricFeedbacks", feedbackId, context);
        }
    }
}
```
**Improve the GET paging method ({Other manual folder}/MetricsAdvisorClient.cs):**
``` C#
namespace Azure.AI.MetricsAdvisor
{
    public partial class MetricsAdvisorClient
    {
        // Suggest appending values to a plural method name
        public virtual AsyncPageable<MetricFeedback> GetMetricFeedbacksValuesAsync(Guid feedbackId, CancellationToken cancellationToken = default)
        {
            // Call internal paging implementation by passing the new scope name, the inner scope will be suppressed
            AsyncPageable<BinaryData> pageableBinaryData = GetMetricFeedbacksImplementationAsync("MetricsAdvisorClient.GetMetricFeedbacksValues", feedbackId, new RequestContext() { CancellationToken = cancellationToken });

            // Calling deserialization helper
            return PageableHelpers.Select(pageableBinaryData, response => ConvertToDataFeeds(DataFeedList.FromResponse(response).Value));
        }
    }
}
```
