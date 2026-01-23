namespace Azure.AI.AgentServer.AgentFramework
{
    public partial class AIAgentInvocation : Azure.AI.AgentServer.Responses.Invocation.AgentInvocationBase
    {
        public AIAgentInvocation(Microsoft.Agents.AI.AIAgent agent) { }
        protected override System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> DoInvokeAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> DoInvokeStreamAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.AI.AgentServer.AgentFramework.Converters
{
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public partial class ItemResourceGenerator : Azure.AI.AgentServer.Responses.Invocation.Stream.NestedChunkedUpdatingGeneratorBase<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>, Microsoft.Agents.AI.AgentRunResponseUpdate>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        public ItemResourceGenerator() { }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext Context { get { throw null; } set { } }
        public System.Action<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>? NotifyOnUsageUpdate { get { throw null; } set { } }
        protected override bool Changed(Microsoft.Agents.AI.AgentRunResponseUpdate previous, Microsoft.Agents.AI.AgentRunResponseUpdate current) { throw null; }
        protected override Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>> CreateGroup(System.Collections.Generic.IAsyncEnumerable<Microsoft.Agents.AI.AgentRunResponseUpdate> updateGroup) { throw null; }
    }
    public static partial class RequestConverterExtensions
    {
        public static System.Collections.Generic.IReadOnlyCollection<Microsoft.Extensions.AI.ChatMessage> GetInputMessages(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request) { throw null; }
    }
    public static partial class ResponseConverterExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource ToFunctionToolCallItemResource(this Microsoft.Extensions.AI.FunctionCallContent functionCallContent, string id) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource ToFunctionToolCallOutputItemResource(this Microsoft.Extensions.AI.FunctionResultContent functionResultContent, string id) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent? ToItemContent(this Microsoft.Extensions.AI.AIContent content) { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> ToItemResource(this Microsoft.Extensions.AI.ChatMessage message, Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response ToResponse(this Microsoft.Agents.AI.AgentRunResponse agentRunResponse, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage? ToResponseUsage(this Microsoft.Extensions.AI.UsageDetails? usage) { throw null; }
    }
}
namespace Azure.AI.AgentServer.AgentFramework.Extensions
{
    public static partial class AIAgentExtensions
    {
        public static System.Threading.Tasks.Task RunAIAgentAsync(this Microsoft.Agents.AI.AIAgent agent, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null, string telemetrySourceName = "Agents") { throw null; }
        public static System.Threading.Tasks.Task RunAIAgentAsync(this Microsoft.Agents.AI.AIAgent agent, System.IServiceProvider sp, string telemetrySourceName = "Agents") { throw null; }
        public static System.Threading.Tasks.Task RunAIAgentAsync(this System.IServiceProvider sp, Microsoft.Agents.AI.AIAgent? agent = null, string telemetrySourceName = "Agents") { throw null; }
    }
}
