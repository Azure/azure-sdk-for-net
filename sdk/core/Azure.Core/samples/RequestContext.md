# Azure client `RequestContext` samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`.

## Customize Error Handling

You can suppress the exception a service method throws when an error response is returned.

```C# Snippet:ErrorOptionsNoThrow
RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };
```

## Add Policy For Request

You can add various types of policies for one request.

### Add Policy Per Call

Add a policy to set the request header once per pipeline invocation (service call).

```C# Snippet:AddPolicyPerCall
var context = new RequestContext();
context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);
```

### Add Policy Per Retry

Add a policy to set the request header every time request is retried.

```C# Snippet:AddPolicyPerRetry
var context = new RequestContext();
context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "Value"), HttpPipelinePosition.PerRetry);
```

### Add Policy Before Transport

Add a policy to set the request header before the request is sent by the transport.

```C# Snippet:AddPolicyBeforeTransport
var context = new RequestContext();
context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "Value"), HttpPipelinePosition.BeforeTransport);
```

## Customize Category Of Response By Status Code

You can change the category of response by the returned status code. This can be used to treat error responses as success responses in logging and distributed tracing.

```C# Snippet:Change404Category
var context = new RequestContext();
context.AddClassifier(404, isError: false);
```
