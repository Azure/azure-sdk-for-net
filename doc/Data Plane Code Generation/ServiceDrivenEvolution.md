# Service driven evolution

As a service evolves with non-breaking changes in the REST API, it may or may not cause breaking changes in the generated SDK. For instance, adding a new method in an existing path or in a new path won't cause breaking changes in the new SDK. But some changes like adding an optional query parameter could cause breaking changes in the generated SDK. In order to make the SDK backward compatible, we can add customized code such as overload methods. The following sections will show some examples of such scenarios and how to handle them.

## A method gets a new optional parameter

Generated code in a V1 client with a required query parameter and an optional query parameter:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, RequestContext context = null)
{
    Argument.AssertNotNull(requiredParam, nameof(requiredParam));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PutRequiredOptional");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

Generated code in a V2 client with a new optional query parameter:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, string newParameter = null, RequestContext context = null)
{
    Argument.AssertNotNull(requiredParam, nameof(requiredParam));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PutRequiredOptional");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, newParameter, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

Since `context` is always the last parameter, V2 inserts the new optional parameter before `context` parameter and this could break code that works with V1 such as `client.PutRequiredOptionalAsync("requiredParam", "optionalParam", ErrorOptions.NoThrow)` (`ErrorOptions.NoThrow` was passed in as `context` parameter but now it's treated as `newParameter`). We can manually add an overload method in V2 which transforms the optional parameters in V1 to required parameters to make V2 backward compatible with V1:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam, RequestContext context)
{
    Argument.AssertNotNull(requiredParam, nameof(requiredParam));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PutRequiredOptional");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, null, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

Now calling `client.PutRequiredOptionalAsync("requiredParam", "optionalParam", ErrorOptions.NoThrow)` with V2 will invoke the manual method we added.

## A new body type is added

Generated code in a V1 client with only `application/json` as the content type:

``` C#
public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
{
    Argument.AssertNotNull(content, nameof(content));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

internal HttpMessage CreatePostParametersRequest(RequestContent content, RequestContext context)
{
    var message = _pipeline.CreateMessage(context, ResponseClassifier200);
    var request = message.Request;
    request.Method = RequestMethod.Post;
    var uri = new RawRequestUriBuilder();
    uri.Reset(_endpoint);
    uri.AppendPath("/serviceDriven/parameters", false);
    request.Uri = uri;
    request.Headers.Add("Accept", "application/json");
    request.Headers.Add("Content-Type", "application/json");
    request.Content = content;
    return message;
}
```

Generated code in a V2 client with `image/jpeg` as a new content type in addition to `application/json`:

``` C#
...
/// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
...
public virtual async Task<Response> PostParametersAsync(RequestContent content, ContentType contentType, RequestContext context = null)
{
    Argument.AssertNotNull(content, nameof(content));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}

internal HttpMessage CreatePostParametersRequest(RequestContent content, ContentType contentType, RequestContext context)
{
    var message = _pipeline.CreateMessage(context, ResponseClassifier200);
    var request = message.Request;
    request.Method = RequestMethod.Post;
    var uri = new RawRequestUriBuilder();
    uri.Reset(_endpoint);
    uri.AppendPath("/serviceDriven/parameters", false);
    request.Uri = uri;
    request.Headers.Add("Accept", "application/json");
    request.Headers.Add("Content-Type", contentType.ToString());
    request.Content = content;
    return message;
}
```

Since the V2 client added a required parameter, it breaks the code that is written for V1. We can manually add an overload method that has the same signature as V1 to make it backward compatible:

``` C#
[EditorBrowsable(EditorBrowsableState.Never)]
public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
{
    Argument.AssertNotNull(content, nameof(content));

    using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
    scope.Start();
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, ContentType.ApplicationJson, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    catch (Exception e)
    {
        scope.Failed(e);
        throw;
    }
}
```

Notice that we leverage the `CreatePostParametersRequest` method in V2 but always pass in the `ContentType.ApplicationJson` as the `contentType` parameter in the manual method to make the behavior align with V1. We can add `[EditorBrowsable(EditorBrowsableState.Never)]` to the manual method to make it invisible in IDE if we don't want to confuse new customers that never used V1 with this overload method that uses a hard-coded content type in addition to the generated method that uses a `contentType` parameter.
