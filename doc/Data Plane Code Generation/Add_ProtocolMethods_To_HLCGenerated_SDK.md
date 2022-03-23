# Add Protocol Methods To HLC Generated SDK

In this tutorial, we will step through the process of generating protocol methods to HLC generated SDK. Protocol methods will be generated in internal RestClient based on the `protocol-method-list` config.

## Prerequisites

You should have HLC SDK generated in `azure-sdk-for-net/sdk/<service name>/<package name>/src/Generated` folder.

## Add protocol methods in generated RestClient

In order to generate protocol methods in RestClient, you would have to define `protocol-method-list` config in your `autorest.md` file. You can find `autorest.md` file path in `azure-sdk-for-net/sdk/<service name>/<package name>/src/autorest.md`. This config takes a list of full operationIds defined in the swagger. 

For this example I'm going to use `Azure.DigitalTwins.Core` SDK. You can find swagger definition for DigitalTwins service [here](https://github.com/Azure/azure-rest-api-specs/blob/14fb40342c19f8b483e132038f8424ee62b745d9/specification/digitaltwins/data-plane/Microsoft.DigitalTwins/stable/2020-10-31/digitaltwins.json) and autorest.md path [here](https://github.com/azure-sdk/azure-sdk-for-net/blob/17debdffe16df01ae196579c91ea22e77eddc96a/sdk/digitaltwins/Azure.DigitalTwins.Core/src/autorest.md).

* ### Generated code before:

In your Generated code you will find `DigitalTwinsRestClient.Delete` and `EventRoutesRestClient.GetById` methods are generated as HLC before adding `protocol-method-list` config.

**(Generated/DigitalTwinsRestClient.cs)**:

<details>

``` C#
internal partial class DigitalTwinsRestClient
{
    public async Task<Response> DeleteAsync(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateDeleteRequest(id, digitalTwinsDeleteOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 204:
                return message.Response;
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }

    public async Task<Response> DeleteAsync(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateDeleteRequest(id, digitalTwinsDeleteOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 204:
                return message.Response;
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }
}
```

</details>

**(Generated/EventRoutesRestClient.cs)**:

<details>

``` C#
internal partial class EventRoutesRestClient
{
    public async Task<Response<DigitalTwinsEventRoute>> GetByIdAsync(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 200:
                {
                    DigitalTwinsEventRoute value = default;
                    using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                    value = DigitalTwinsEventRoute.DeserializeDigitalTwinsEventRoute(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }

    public Response<DigitalTwinsEventRoute> GetById(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions);
        _pipeline.Send(message, cancellationToken);
        switch (message.Response.Status)
        {
            case 200:
                {
                    DigitalTwinsEventRoute value = default;
                    using var document = JsonDocument.Parse(message.Response.ContentStream);
                    value = DigitalTwinsEventRoute.DeserializeDigitalTwinsEventRoute(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
            default:
                throw ClientDiagnostics.CreateRequestFailedException(message.Response);
        }
    }
}
```

</details>

* ### Add Config:

Add `protocol-method-list` config in autorest.md and pass a list of full swagger operationId for the methods that would like to generate as protocol methods.

**(autorest.md)**

<details>

```` md
### Generate DPG methods
```yaml
protocol-method-list:
  - DigitalTwins_Delete
  - EventRoutes_GetById
``` 
````

</details>

* ### Generated code after:

Re-generate code by running `dotnet build /t:GenerateCode` command will add protocol methods for `DigitalTwinsRestClient.Delete` and `EventRoutesRestClient.GetById`.

**(Generated/DigitalTwinsRestClient.cs)**:

<details>

``` diff

internal partial class DigitalTwinsRestClient
{
    public async Task<Response> DeleteAsync(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateDeleteRequest(id, digitalTwinsDeleteOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 204:
                return message.Response;
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }

    public async Task<Response> DeleteAsync(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateDeleteRequest(id, digitalTwinsDeleteOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 204:
                return message.Response;
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }
+
+    public virtual async Task<Response> DeleteAsync(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(id, nameof(id));
+
+        using var scope = ClientDiagnostics.CreateScope("DigitalTwinsClient.Delete");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateDeleteRequest(id, digitalTwinsDeleteOptions, context);
+            return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
+
+    public virtual Response Delete(string id, DeleteDigitalTwinOptions digitalTwinsDeleteOptions = null, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(id, nameof(id));
+
+        using var scope = ClientDiagnostics.CreateScope("DigitalTwinsClient.Delete");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateDeleteRequest(id, digitalTwinsDeleteOptions, context);
+            return _pipeline.ProcessMessage(message, context);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
}
```

</details>

**(Generated/EventRoutesRestClient.cs)**:

<details>

``` diff
internal partial class EventRoutesRestClient
{
    public async Task<Response<DigitalTwinsEventRoute>> GetByIdAsync(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        switch (message.Response.Status)
        {
            case 200:
                {
                    DigitalTwinsEventRoute value = default;
                    using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                    value = DigitalTwinsEventRoute.DeserializeDigitalTwinsEventRoute(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
            default:
                throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }
    }

    public Response<DigitalTwinsEventRoute> GetById(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, CancellationToken cancellationToken = default)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        using var message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions);
        _pipeline.Send(message, cancellationToken);
        switch (message.Response.Status)
        {
            case 200:
                {
                    DigitalTwinsEventRoute value = default;
                    using var document = JsonDocument.Parse(message.Response.ContentStream);
                    value = DigitalTwinsEventRoute.DeserializeDigitalTwinsEventRoute(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
            default:
                throw ClientDiagnostics.CreateRequestFailedException(message.Response);
        }
    }
+
+    public virtual async Task<Response> GetByIdAsync(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(id, nameof(id));
+
+        using var scope = ClientDiagnostics.CreateScope("EventRoutesClient.GetById");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions, context);
+            return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
+
+    public virtual Response GetById(string id, GetDigitalTwinsEventRouteOptions eventRoutesGetByIdOptions = null, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(id, nameof(id));
+
+        using var scope = ClientDiagnostics.CreateScope("EventRoutesClient.GetById");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateGetByIdRequest(id, eventRoutesGetByIdOptions, context);
+            return _pipeline.ProcessMessage(message, context);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
}
```

</details>
&nbsp;

**Note:** Protocol methods will be generated only in internal RestClient even if the `public-client` is set to true in the config. In order to add public protocol methods, you would have to manually add those methods in public client and call the internal protcol methods generated in RestClient.