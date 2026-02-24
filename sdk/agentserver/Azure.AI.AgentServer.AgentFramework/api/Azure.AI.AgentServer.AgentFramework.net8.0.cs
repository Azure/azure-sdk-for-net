namespace Azure.AI.AgentServer.AgentFramework
{
    public partial class AIAgentInvocation : Azure.AI.AgentServer.Responses.Invocation.AgentInvocationBase
    {
        public AIAgentInvocation(Microsoft.Agents.AI.AIAgent agent, Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { }
        protected override System.Threading.Tasks.Task<(Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> Generator, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task> PostInvoke)> DoInvokeStreamAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public delegate System.Threading.Tasks.Task<Microsoft.Agents.AI.AIAgent> WorkflowAgentFactory();
    public partial class WorkflowAgentInvocation : Azure.AI.AgentServer.Responses.Invocation.AgentInvocationBase
    {
        public WorkflowAgentInvocation(Azure.AI.AgentServer.AgentFramework.WorkflowAgentFactory workflowAgentFactory, Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { }
        protected override System.Threading.Tasks.Task<(Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> Generator, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task> PostInvoke)> DoInvokeStreamAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.AgentServer.AgentFramework.Converters
{
    public static partial class HumanInTheLoopExtentions
    {
        public static System.Collections.Generic.Dictionary<string, Microsoft.Extensions.AI.UserInputRequestContent> GetPendingUserInputRequestContents(Microsoft.Agents.AI.AIAgent agent, Microsoft.Agents.AI.AgentSession? session) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource ToHumanInTheLoopFunctionCallItemResource(this Microsoft.Extensions.AI.FunctionApprovalRequestContent content, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy? createdBy = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource ToHumanInTheLoopFunctionCallItemResource(this Microsoft.Extensions.AI.McpServerToolApprovalRequestContent content, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy? createdBy = null) { throw null; }
        public static bool TryParseApprovalResponse(string? input, out bool isApproved) { throw null; }
        public static System.Collections.Generic.List<Microsoft.Extensions.AI.ChatMessage>? ValidateAndConvertResponse(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, System.Collections.Generic.Dictionary<string, Microsoft.Extensions.AI.UserInputRequestContent>? pendingRequests) { throw null; }
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public partial class ItemResourceGenerator : Azure.AI.AgentServer.Responses.Invocation.Stream.NestedChunkedUpdatingGeneratorBase<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>, Microsoft.Agents.AI.AgentResponseUpdate>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        public ItemResourceGenerator() { }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.AgentRunContext Context { get { throw null; } set { } }
        public System.Action<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>? NotifyOnUsageUpdate { get { throw null; } set { } }
        protected override bool Changed(Microsoft.Agents.AI.AgentResponseUpdate previous, Microsoft.Agents.AI.AgentResponseUpdate current) { throw null; }
        protected override Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>> CreateGroup(System.Collections.Generic.IAsyncEnumerable<Microsoft.Agents.AI.AgentResponseUpdate> updateGroup) { throw null; }
    }
    public static partial class RequestConverterExtensions
    {
        public static System.Collections.Generic.IReadOnlyCollection<Microsoft.Extensions.AI.ChatMessage> GetInputMessages(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request) { throw null; }
    }
    public static partial class ResponseConverterExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource ToFunctionToolCallItemResource(this Microsoft.Extensions.AI.FunctionCallContent functionCallContent, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy? createdBy = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource ToFunctionToolCallOutputItemResource(this Microsoft.Extensions.AI.FunctionResultContent functionResultContent, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy? createdBy = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent? ToItemContent(this Microsoft.Extensions.AI.AIContent content) { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> ToItemResource(this Microsoft.Extensions.AI.ChatMessage message, Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator, string responseId) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response ToResponse(this Microsoft.Agents.AI.AgentResponse agentResponse, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError ToResponseError(this Microsoft.Extensions.AI.ErrorContent errorContent) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage? ToResponseUsage(this Microsoft.Extensions.AI.UsageDetails? usage) { throw null; }
    }
}
namespace Azure.AI.AgentServer.AgentFramework.Extensions
{
    public static partial class AIAgentExtensions
    {
        public static System.Threading.Tasks.Task RunAIAgentAsync(this Microsoft.Agents.AI.AIAgent agent, Azure.Core.TokenCredential credential, System.Uri? projectEndpoint = null, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunAIAgentAsync(this Microsoft.Agents.AI.AIAgent agent, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunAIAgentAsync(this Microsoft.Agents.AI.AIAgent agent, System.IServiceProvider sp, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunAIAgentAsync(this System.IServiceProvider sp, Microsoft.Agents.AI.AIAgent? agent = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
    }
    public static partial class ChatClientBuilderExtensions
    {
        public static Microsoft.Extensions.AI.ChatClientBuilder UseFoundryTools(this Microsoft.Extensions.AI.ChatClientBuilder builder, params Azure.AI.AgentServer.Core.Tools.Models.FoundryTool[] foundryTools) { throw null; }
        public static Microsoft.Extensions.AI.ChatClientBuilder UseFoundryTools(this Microsoft.Extensions.AI.ChatClientBuilder builder, params object[] foundryTools) { throw null; }
    }
    public static partial class WorkflowAgentExtensions
    {
        public static System.Threading.Tasks.Task RunWorkflowAgentAsync(this Azure.AI.AgentServer.AgentFramework.WorkflowAgentFactory workflowAgentFactory, Azure.Core.TokenCredential credential, System.Uri? projectEndpoint = null, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunWorkflowAgentAsync(this Azure.AI.AgentServer.AgentFramework.WorkflowAgentFactory workflowAgentFactory, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunWorkflowAgentAsync(this Azure.AI.AgentServer.AgentFramework.WorkflowAgentFactory workflowAgentFactory, System.IServiceProvider sp, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
        public static System.Threading.Tasks.Task RunWorkflowAgentAsync(this System.IServiceProvider sp, Azure.AI.AgentServer.AgentFramework.WorkflowAgentFactory? workflowAgentFactory = null, string telemetrySourceName = "Agents", Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository? threadRepository = null) { throw null; }
    }
}
namespace Azure.AI.AgentServer.AgentFramework.Persistence
{
    public partial class FoundryConversationThreadRepository : Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository
    {
        public FoundryConversationThreadRepository(System.Uri projectEndpoint, Azure.Core.TokenCredential credential) { }
        public System.Threading.Tasks.Task<Microsoft.Agents.AI.AgentSession> Get(string? conversationId, Microsoft.Agents.AI.AIAgent? agent = null) { throw null; }
        public System.Threading.Tasks.Task Set(string? conversationId, Microsoft.Agents.AI.AgentSession session) { throw null; }
    }
    public partial interface IAgentThreadRepository
    {
        System.Threading.Tasks.Task<Microsoft.Agents.AI.AgentSession> Get(string? conversationId, Microsoft.Agents.AI.AIAgent? agent = null);
        System.Threading.Tasks.Task Set(string? conversationId, Microsoft.Agents.AI.AgentSession session);
    }
    public partial class InMemoryAgentThreadRepository : Azure.AI.AgentServer.AgentFramework.Persistence.IAgentThreadRepository
    {
        public InMemoryAgentThreadRepository(Microsoft.Agents.AI.AIAgent? agent = null) { }
        public System.Threading.Tasks.Task<Microsoft.Agents.AI.AgentSession> Get(string? conversationId, Microsoft.Agents.AI.AIAgent? agent = null) { throw null; }
        public System.Threading.Tasks.Task Set(string? conversationId, Microsoft.Agents.AI.AgentSession session) { throw null; }
    }
}
