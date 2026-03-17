using System.Diagnostics;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// DI-friendly wrapper around <see cref="ActivitySource"/> that supports
/// extensible activity creation for distributed tracing.
/// <para>
/// The default implementation sets GenAI semantic convention tags and baggage items.
/// Subclass to customize tracing — you do <strong>not</strong> need to replicate the
/// entire method. Because <see cref="Activity.SetTag"/> replaces existing values
/// and <see cref="Activity.AddBaggage"/> prepends (so
/// <see cref="Activity.GetBaggageItem"/> returns the most recently added value),
/// you can call <c>base</c> first and then selectively override:
/// </para>
/// <code>
/// class MyActivitySource : ResponsesActivitySource
/// {
///     public override Activity? StartCreateResponseActivity(
///         CreateResponse request, string responseId, IHeaderDictionary headers)
///     {
///         var activity = base.StartCreateResponseActivity(request, responseId, headers);
///         activity?.SetTag("gen_ai.provider.name", "my-service");   // replaces default
///         activity?.SetTag("service.namespace", "my.ns");           // adds new tag
///         return activity;
///     }
/// }
///
/// // Register before AddResponsesServer so TryAddSingleton skips the default:
/// services.AddSingleton&lt;ResponsesActivitySource, MyActivitySource&gt;();
/// services.AddResponsesServer();
/// </code>
/// </summary>
public class ResponsesActivitySource
{
    /// <summary>
    /// The default <see cref="ActivitySource"/> name: <c>"Azure.AI.AgentServer.Responses"</c>.
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Responses";

    /// <summary>
    /// The default service name used for the <c>gen_ai.provider.name</c>,
    /// <c>gen_ai.system</c>, <c>service.name</c> tags and the
    /// <c>provider.name</c> baggage item: <c>"azure.ai.responses"</c>.
    /// </summary>
    public const string DefaultServiceName = "azure.ai.responses";

    private readonly ActivitySource _source;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/>
    /// using <see cref="DefaultName"/> as the <see cref="ActivitySource"/> name.
    /// </summary>
    public ResponsesActivitySource() : this(null) { }

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/>.
    /// </summary>
    /// <param name="name">
    /// The name for the underlying <see cref="ActivitySource"/>.
    /// Falls back to <see cref="DefaultName"/> if null, empty, or whitespace.
    /// </param>
    protected ResponsesActivitySource(string? name)
    {
        var resolvedName = string.IsNullOrWhiteSpace(name) ? DefaultName : name;
        _source = new ActivitySource(resolvedName);
    }

    /// <summary>
    /// Gets the underlying <see cref="ActivitySource"/> instance.
    /// Subclasses may use this to call <see cref="ActivitySource.StartActivity(string)"/>.
    /// </summary>
    protected ActivitySource Source => _source;

    /// <summary>
    /// Gets the name of the underlying <see cref="ActivitySource"/>.
    /// Useful for configuring <c>AddSource</c> on an OpenTelemetry tracing builder.
    /// </summary>
    public string Name => _source.Name;

    /// <summary>
    /// Starts and configures a distributed tracing <see cref="Activity"/> for a
    /// <c>POST /responses</c> request.
    /// <para>
    /// The default implementation sets GenAI semantic convention tags
    /// (<c>gen_ai.response.id</c>, <c>gen_ai.provider.name</c>, <c>gen_ai.system</c>,
    /// <c>gen_ai.operation.name</c>, <c>gen_ai.request.model</c>,
    /// <c>gen_ai.conversation.id</c>, <c>gen_ai.agent.*</c>, <c>service.name</c>,
    /// <c>response.mode</c>, <c>request.id</c>) and baggage items
    /// (<c>response.id</c>, <c>streaming</c>, <c>provider.name</c>,
    /// <c>conversation.id</c>, <c>agent.name</c>, <c>agent.id</c>, <c>request.id</c>).
    /// </para>
    /// <para>
    /// Override to customize. Call <c>base</c> first, then use
    /// <see cref="Activity.SetTag"/> to replace or add tags — <c>SetTag</c>
    /// replaces the value when the key already exists.
    /// <see cref="Activity.AddBaggage"/> prepends, so
    /// <see cref="Activity.GetBaggageItem"/> returns the most recently added value.
    /// </para>
    /// </summary>
    /// <param name="request">The deserialized create-response request.</param>
    /// <param name="responseId">The generated response ID.</param>
    /// <param name="headers">
    /// The HTTP request headers. The default implementation reads
    /// <c>X-Request-Id</c>; subclasses can read any header they need.
    /// </param>
    /// <returns>
    /// A started <see cref="Activity"/>, or <c>null</c> if no listener is sampling.
    /// The caller wraps the returned value in a <c>using</c> block.
    /// </returns>
    public virtual Activity? StartCreateResponseActivity(
        CreateResponse request,
        string responseId,
        IHeaderDictionary headers)
    {
        // Derive mode from request
        var isStreaming = request.Stream == true;
        var isBackground = request.Background == true;

        var mode = (isStreaming, isBackground) switch
        {
            (true, true) => "streaming+background",
            (true, false) => "streaming",
            (false, true) => "background",
            _ => "default",
        };

        // Activity display name per OTEL GenAI convention
        var activityName = string.IsNullOrEmpty(request.Model)
            ? "create_response"
            : $"create_response {request.Model}";

        var activity = _source.StartActivity(activityName);
        if (activity is null)
        {
            return null;
        }

        // --- GenAI semantic convention tags ---
        activity.SetTag("gen_ai.response.id", responseId);
        activity.SetTag("gen_ai.provider.name", DefaultServiceName);
        activity.SetTag("service.name", DefaultServiceName);
        activity.SetTag("response.mode", mode);
        activity.SetTag("gen_ai.system", DefaultServiceName);
        activity.SetTag("gen_ai.operation.name", "create_response");

        if (!string.IsNullOrEmpty(request.Model))
        {
            activity.SetTag("gen_ai.request.model", request.Model);
        }

        var conversationId = request.GetConversationId();
        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetTag("gen_ai.conversation.id", conversationId);
        }

        // Agent tags: prefer AgentReference, fall back to Agent (deprecated)
        var agent = request.AgentReference ?? request.Agent;
        if (agent is not null && !string.IsNullOrEmpty(agent.Name))
        {
            activity.SetTag("gen_ai.agent.name", agent.Name);
            var agentId = string.IsNullOrEmpty(agent.Version)
                ? agent.Name
                : $"{agent.Name}:{agent.Version}";
            activity.SetTag("gen_ai.agent.id", agentId);
            if (!string.IsNullOrEmpty(agent.Version))
            {
                activity.SetTag("gen_ai.agent.version", agent.Version);
            }
        }

        // X-Request-Id header propagation (truncate to 256 chars)
        string? xRequestId = null;
        if (headers.TryGetValue("X-Request-Id", out var xRequestIdValues)
            && !string.IsNullOrEmpty(xRequestIdValues))
        {
            xRequestId = xRequestIdValues.ToString();
            if (xRequestId.Length > 256)
            {
                xRequestId = xRequestId[..256];
            }
            activity.SetTag("request.id", xRequestId);
        }

        // --- Baggage items ---
        activity.AddBaggage("response.id", responseId);
        activity.AddBaggage("streaming", isStreaming.ToString().ToLowerInvariant());
        activity.AddBaggage("provider.name", DefaultServiceName);

        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.AddBaggage("conversation.id", conversationId);
        }

        if (agent is not null && !string.IsNullOrEmpty(agent.Name))
        {
            activity.AddBaggage("agent.name", agent.Name);
            var agentIdBaggage = string.IsNullOrEmpty(agent.Version)
                ? agent.Name
                : $"{agent.Name}:{agent.Version}";
            activity.AddBaggage("agent.id", agentIdBaggage);
        }

        if (!string.IsNullOrEmpty(xRequestId))
        {
            activity.AddBaggage("request.id", xRequestId);
        }

        return activity;
    }
}
