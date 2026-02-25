namespace TestCore;

public class RetryOptions
{
    public int MaxRetries { get; set; }
    public string? Delay { get; set; }
    public string? Mode { get; set; }
}

public class DiagnosticsOptions
{
    public bool IsLoggingEnabled { get; set; }
    public string? ApplicationId { get; set; }
}
