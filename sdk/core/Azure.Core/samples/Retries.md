## Azure.Core retry configuration

Be default clients are setup to retry 3 times with exponential retry kind and initial delay of 0.8 sec.

# Configuring retry options

To modify the retry options use the `Retry` property of client options class.

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