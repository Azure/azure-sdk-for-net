# Service driven evolution

As a service evolves with non-breaking changes in the REST API, it may or may not cause breaking changes in the generated SDK. For instance, adding a new method in an existing path or in a new path won't cause breaking changes in the new SDK. See details [here](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#api-versioning). 

However, even no breaking changes exist from the REST API perspective, some changes like adding an optional query parameter could still cause breaking changes in the generated SDK. In order to make the SDK backward compatible, we can add customized code such as overload methods for now. We will make it automatically in the near future. The following sections will show some examples of such scenarios and how to handle them.

## A method gets a new optional parameter

Generated code in a V1 client with a required query parameter and an optional query parameter:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}

internal HttpMessage CreatePutRequiredOptionalRequest(string requiredParam, string optionalParam, RequestContext context)
{
    ...
    if (optionalParam != null)
    {
        uri.AppendQuery("optionalParam", optionalParam, true);
    }
    ...
    return message;
}
```

Generated code in a V2 client with a new optional query parameter:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, string newParameter = null, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, newParameter, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}

internal HttpMessage CreatePutRequiredOptionalRequest(string requiredParam, string optionalParam, string newParameter, RequestContext context)
{
    ...
    if (optionalParam != null)
    {
        uri.AppendQuery("optionalParam", optionalParam, true);
    }
    if (newParameter != null)
    {
        uri.AppendQuery("new_parameter", newParameter, true);
    }
    ...
    return message;
}
```

Since `context` is always the last parameter, V2 inserts the new optional parameter before `context` parameter and this could break code that works with V1 such as `client.PutRequiredOptionalAsync("requiredParam", "optionalParam", ErrorOptions.NoThrow)` (`ErrorOptions.NoThrow` was passed in as `context` parameter but now it's treated as `newParameter`). We can manually add an overload method in V2 which transforms the optional parameters in V1 to required parameters to make V2 backward compatible with V1:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam, RequestContext context)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, null, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}
```
In summary of what this evolution looks like now:
```C#
// Generated in V2
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, string newParameter = null, RequestContext context = null)
{
}

// Generated in V2
internal HttpMessage CreatePutRequiredOptionalRequest(string requiredParam, string optionalParam, string newParameter, RequestContext context)
{
}

// Customization method in V2 to be compatible with V1 calls
public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam, RequestContext context)
{
}
```

**Notice:**
Now calling `client.PutRequiredOptionalAsync("requiredParam", "optionalParam", ErrorOptions.NoThrow)` with V2 will invoke the `PutRequiredOptionalAsync` method we added. But the `CreatePutRequiredOptionalRequest` method has one more parameter, so we should call it with `newParameter` `null` as `CreatePutRequiredOptionalRequest(requiredParam, optionalParam, null, context);`.

## A method changes a required parameter to optional

Generated code in a V1 client with two required parameters:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string param1, string param2, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(param1, param2, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}
```

**Required input is changed to an optional input when it is in the last position (i.e., `param2`).**

This case is safe to generate as:

``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string param1, string param2 = null, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(param1, param2, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}
```

**Required input is changed to an optional input when it is not in the last position (e.g., `param1`).**

In this case, below generated code is not safe to go. The result of this would be that any existing code calling the v1 method as `PutRequiredOptionalAsync(param1, param2);` would end up passing the wrong values to the method parameters, without any warnings from the compiler.
``` C#
public virtual async Task<Response> PutRequiredOptionalAsync(string param2, string param1 = null, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePutRequiredOptionalRequest(param2, param1, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}
```
In this case, you might need to 
1. Change the V2 method name to another name (e.g., `PutRequiredOptionalV1Async`).
2. Put back the V1 method implementation.

## A new body type is added

Generated code in a V1 client with only `application/json` as the content type:

``` C#
public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}

internal HttpMessage CreatePostParametersRequest(RequestContent content, RequestContext context)
{
    ...
    request.Headers.Add("Content-Type", "application/json");
    request.Content = content;
    return message;
}
```

Generated code in a V2 client with `image/jpeg` as a new content type in addition to `application/json`:

``` C#
/// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
public virtual async Task<Response> PostParametersAsync(RequestContent content, ContentType contentType, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}

internal HttpMessage CreatePostParametersRequest(RequestContent content, ContentType contentType, RequestContext context)
{
    ...
    request.Headers.Add("Content-Type", contentType.ToString());
    request.Content = content;
    return message;
}
```

Since the V2 client added a required parameter to an existing client method, it breaks the code that is written for the V1 client. We can manually add an overload method that has the same signature as V1 to make it backward compatible:

``` C#
[EditorBrowsable(EditorBrowsableState.Never)]
public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
{
    ...
    try
    {
        using HttpMessage message = CreatePostParametersRequest(content, ContentType.ApplicationJson, context);
        return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    }
    ...
}
```

**Notice:**
1. We leverage the `CreatePostParametersRequest` method in V2 but always pass in the `ContentType.ApplicationJson` as the `contentType` parameter in the manual method to make the behavior align with V1.
2. Whether to add the attribute `[EditorBrowsable(EditorBrowsableState.Never)]` depends on whether you want to discourage callers from using this. E.g., if service add a new ContentType value to improve performance, you should add this attribute so new users wouldn't discover it, while if service has default preference of old ContentType value, you should not add this attribute to make it easy for users to discover the default.
