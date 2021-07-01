# Azure client configuration samples

**NOTE:** Samples in this file apply only to packages that follow [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html). Names of such packages usually start with `Azure`. 

## Configuring retry options

To modify the retry options use the `Retry` property of client options class.

Be default clients are setup to retry 3 times with exponential retry kind and initial delay of 0.8 sec.

```C# Snippet:RetryOptions
SecretClientOptions options = new SecretClientOptions()
{
    Retry =
    {
        Delay = TimeSpan.FromSeconds(2),
        MaxRetries = 10,
        Mode = RetryMode.Fixed
    }
};
```

## User provided HttpClient instance

```C# Snippet:SettingHttpClient
using HttpClient client = new HttpClient();

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```

## Configuring a proxy

```C# Snippet:HttpClientProxyConfiguration
using HttpClientHandler handler = new HttpClientHandler()
{
    Proxy = new WebProxy(new Uri("http://example.com"))
};

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(handler)
};
```
