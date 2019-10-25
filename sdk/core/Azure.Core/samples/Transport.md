# Azure.Core transport samples

## Providing own HttpClientInstance

```C# Snippet:SettingHttpClient
using HttpClient client = new HttpClient();

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```

## Setting up a proxy

##

```C# Snippet:HttpClientProxyConfiguration
using HttpClient client = new HttpClient(
    new HttpClientHandler()
    {
        Proxy = new WebProxy(new Uri("http://example.com"))
    });

SecretClientOptions options = new SecretClientOptions
{
    Transport = new HttpClientTransport(client)
};
```
