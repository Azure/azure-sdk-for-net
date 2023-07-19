# Add Protocol Methods In Generated SDK of (Gen 1) Convenience Client

In this tutorial, we will show how to add protocol methods to Data Plane Generation 1 Convenience Clients built on internal generated RestClients.  This is accomplished by adding generated protocol methods to the inner RestClient, and then manually adding them to the outer Convenience Client API.

## Prerequisites

You should have a service RestClient generated in `azure-sdk-for-net/sdk/<service name>/<package name>/src/Generated` folder.

## Add protocol methods to RestClient

In order to generate protocol methods in the generated RestClient of (Gen 1) convenience client, you'd have to define a `protocol-method-list` config in your `autorest.md` file. You can find `autorest.md` file path in `azure-sdk-for-net/sdk/<service name>/<package name>/src/autorest.md`. This config takes a list of `operationId` defined in it's swagger definition.

For this tutorial we are going to use `Azure.Data.Tables` SDK. You can find swagger definition for Table service [here](https://github.com/Azure/azure-rest-api-specs/blob/2df8b07bf9af7c96066ca4dda21b79297307d108/specification/cosmos-db/data-plane/Microsoft.Tables/preview/2019-02-02/table.json), `autorest.md` file [here](https://github.com/azure-sdk/azure-sdk-for-net/blob/17debdffe16df01ae196579c91ea22e77eddc96a/sdk/tables/Azure.Data.Tables/src/autorest.md) and `Generated` folder [here](https://github.com/azure-sdk/azure-sdk-for-net/tree/17debdffe16df01ae196579c91ea22e77eddc96a/sdk/tables/Azure.Data.Tables/src/Generated).

* ### Generated code before:

In Generated folder, you will find `TableRestClient.Delete` and `ServiceRestClient.SetProperties` methods are already generated as per default configuration of (Gen 1) convenience client.

**(Generated/TableRestClient.cs)**:

``` C#
internal partial class TableRestClient
{
    // ...
    public async Task<ResponseWithHeaders<TableDeleteHeaders>> DeleteAsync(string table, CancellationToken cancellationToken = default);
    public ResponseWithHeaders<TableDeleteHeaders> Delete(string table, CancellationToken cancellationToken = default);
    // ...
}
```

<details>

``` C#
internal partial class TableRestClient
{
    // ...
    public async Task<ResponseWithHeaders<TableDeleteHeaders>> DeleteAsync(string table, CancellationToken cancellationToken = default)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        using var message = CreateDeleteRequest(table);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        var headers = new TableDeleteHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 204:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }

    public ResponseWithHeaders<TableDeleteHeaders> Delete(string table, CancellationToken cancellationToken = default)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        using var message = CreateDeleteRequest(table);
        _pipeline.Send(message, cancellationToken);
        var headers = new TableDeleteHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 204:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }
    // ...
}
```

</details>

**(Generated/ServiceRestClient.cs)**:

``` C#
internal partial class ServiceRestClient
{
    // ...
    public async Task<ResponseWithHeaders<ServiceSetPropertiesHeaders>> SetPropertiesAsync(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default);
    public ResponseWithHeaders<ServiceSetPropertiesHeaders> SetProperties(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default);
    // ...
}
```

<details>

``` C#
internal partial class ServiceRestClient
{
    // ...
    public async Task<ResponseWithHeaders<ServiceSetPropertiesHeaders>> SetPropertiesAsync(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
    {
        if (tableServiceProperties == null)
        {
            throw new ArgumentNullException(nameof(tableServiceProperties));
        }

        using var message = CreateSetPropertiesRequest(tableServiceProperties, timeout);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        var headers = new ServiceSetPropertiesHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 202:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }

    public ResponseWithHeaders<ServiceSetPropertiesHeaders> SetProperties(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
    {
        if (tableServiceProperties == null)
        {
            throw new ArgumentNullException(nameof(tableServiceProperties));
        }

        using var message = CreateSetPropertiesRequest(tableServiceProperties, timeout);
        _pipeline.Send(message, cancellationToken);
        var headers = new ServiceSetPropertiesHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 202:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }
    // ...
}
```

</details>

* ### Add Config:

Add `protocol-method-list` config in `autorest.md` and pass a list of swagger operationId for which you'd like to generate protocol methods. For example, in order to generate protocol methods for `TableRestClient.Delete` and `ServiceRestClient.SetProperties`, you'd add a config as shown below. 

An example of this configuration is:
```yaml
protocol-method-list:
  - OperationGroup1_OperationName1
  - OperationGroup2_OperationName1
```

**(autorest.md)**

<details>

```` md
### Generate DPG methods
```yaml
protocol-method-list:
  - Table_Delete
  - Service_SetProperties
```
````

</details>

* ### Generated code after:

Re-generate code by running `dotnet build /t:GenerateCode` command which will generate protocol methods for `TableRestClient.Delete` and `ServiceRestClient.SetProperties`.

**(Generated/TableRestClient.cs)**:

``` diff
internal partial class TableRestClient
{
    // ...
    public async Task<ResponseWithHeaders<TableDeleteHeaders>> DeleteAsync(string table, CancellationToken cancellationToken = default);
    public ResponseWithHeaders<TableDeleteHeaders> Delete(string table, CancellationToken cancellationToken = default);
+   public virtual async Task<Response> DeleteAsync(string table, RequestContext context = null);
+   public virtual Response Delete(string table, RequestContext context = null);
    // ...
}
```

<details>

``` diff

internal partial class TableRestClient
{
    // ...
    public async Task<ResponseWithHeaders<TableDeleteHeaders>> DeleteAsync(string table, CancellationToken cancellationToken = default)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        using var message = CreateDeleteRequest(table);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        var headers = new TableDeleteHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 204:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }

    public ResponseWithHeaders<TableDeleteHeaders> Delete(string table, CancellationToken cancellationToken = default)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        using var message = CreateDeleteRequest(table);
        _pipeline.Send(message, cancellationToken);
        var headers = new TableDeleteHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 204:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }
+
+   public virtual async Task<Response> DeleteAsync(string table, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(table, nameof(table));
+
+        using var scope = ClientDiagnostics.CreateScope("TableClient.Delete");
+        scope.Start();
+        try
+            using HttpMessage message = CreateDeleteRequest(table, context);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
+
+    public virtual Response Delete(string table, RequestContext context = null)
+    {
+        Argument.AssertNotNullOrEmpty(table, nameof(table));
+
+        using var scope = ClientDiagnostics.CreateScope("TableClient.Delete");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateDeleteRequest(table, context);
+            return _pipeline.ProcessMessage(message, context);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
    // ...
}
```

</details>

**(Generated/ServiceRestClient.cs)**:

``` diff
internal partial class ServiceRestClient
{
    // ...
    public async Task<ResponseWithHeaders<ServiceSetPropertiesHeaders>> SetPropertiesAsync(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default);
    public ResponseWithHeaders<ServiceSetPropertiesHeaders> SetProperties(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default);
+   public virtual async Task<Response> SetPropertiesAsync(RequestContent content, int? timeout = null, RequestContext context = null);
+   public virtual Response SetProperties(RequestContent content, int? timeout = null, RequestContext context = null);
    // ...
}
```

<details>

``` diff
internal partial class ServiceRestClient
{
    // ...
    public async Task<ResponseWithHeaders<ServiceSetPropertiesHeaders>> SetPropertiesAsync(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
    {
        if (tableServiceProperties == null)
        {
            throw new ArgumentNullException(nameof(tableServiceProperties));
        }

        using var message = CreateSetPropertiesRequest(tableServiceProperties, timeout);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        var headers = new ServiceSetPropertiesHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 202:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }

    public ResponseWithHeaders<ServiceSetPropertiesHeaders> SetProperties(TableServiceProperties tableServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
    {
        if (tableServiceProperties == null)
        {
            throw new ArgumentNullException(nameof(tableServiceProperties));
        }

        using var message = CreateSetPropertiesRequest(tableServiceProperties, timeout);
        _pipeline.Send(message, cancellationToken);
        var headers = new ServiceSetPropertiesHeaders(message.Response);
        switch (message.Response.Status)
        {
            case 202:
                return ResponseWithHeaders.FromValue(headers, message.Response);
            default:
                throw new RequestFailedException(message.Response);
        }
    }
+
+   public virtual async Task<Response> SetPropertiesAsync(RequestContent content, int? timeout = null, RequestContext context = null)
+   {
+        Argument.AssertNotNull(content, nameof(content));
+
+        using var scope = ClientDiagnostics.CreateScope("ServiceClient.SetProperties");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateSetPropertiesRequest(content, timeout, context);
+            return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
+
+    public virtual Response SetProperties(RequestContent content, int? timeout = null, RequestContext context = null)
+    {
+        Argument.AssertNotNull(content, nameof(content));
+
+        using var scope = ClientDiagnostics.CreateScope("ServiceClient.SetProperties");
+        scope.Start();
+        try
+        {
+            using HttpMessage message = CreateSetPropertiesRequest(content, timeout, context);
+            return _pipeline.ProcessMessage(message, context);
+        }
+        catch (Exception e)
+        {
+            scope.Failed(e);
+            throw;
+        }
+    }
    // ...
}
```

</details>

## Add protocol methods to ConvenienceClient

Protocol methods will be generated only in internal RestClient even if the `public-client` is set to true in the config. In order to add a public protocol method, you'd have to manually add it in ConvenienceClient and call the corresponding internal protocol method generated in RestClient.

**(TableClient.cs)**:

``` C#
public class TableClient
{
    // ...
    public virtual async Task<Response> DeleteAsync(string table, RequestContext context = null) => await _tableRestClient.DeleteAsync(table, context).ConfigureAwait(false);
    public virtual Response Delete(string table, RequestContext context = null) => _tableRestClient.Delete(table, context);
    // ...
}
```

**(TableServiceClient.cs)**:

``` C#
public class TableServiceClient
{
    // ...
    public virtual async Task<Response> SetPropertiesAsync(RequestContent content, int? timeout = null, RequestContext context = null) => await _serviceRestClient.SetPropertiesAsync(content, timeout, context).ConfigureAwait(false);
    public virtual Response SetProperties(RequestContent content, int? timeout = null, RequestContext context = null) => _serviceRestClient.SetProperties(content, timeout, context);
    // ...
}
```