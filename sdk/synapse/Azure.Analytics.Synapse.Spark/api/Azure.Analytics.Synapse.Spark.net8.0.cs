namespace Azure.Analytics.Synapse.Spark
{
    public partial class SparkBatchClient
    {
        protected SparkBatchClient() { }
        public SparkBatchClient(System.Uri endpoint, string livyApiVersion, string sparkPoolName, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Spark.SparkClientOptions options = null) { }
        public virtual Azure.Response CancelSparkBatchJob(int batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSparkBatchJobAsync(int batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob> GetSparkBatchJob(int batchId, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob>> GetSparkBatchJobAsync(int batchId, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJobCollection> GetSparkBatchJobs(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJobCollection>> GetSparkBatchJobsAsync(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Spark.SparkBatchOperation StartCreateSparkBatchJob(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Spark.SparkBatchOperation> StartCreateSparkBatchJobAsync(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkBatchOperation : Azure.Operation<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob>
    {
        protected SparkBatchOperation() { }
        public SparkBatchOperation(int batchId, Azure.Analytics.Synapse.Spark.SparkBatchClient client, Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType completionType = Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType.JobSubmission) { }
        public Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType CompletionType { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Spark.Models.SparkBatchJob Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SparkClientOptions : Azure.Core.ClientOptions
    {
        public SparkClientOptions(Azure.Analytics.Synapse.Spark.SparkClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Spark.SparkClientOptions.ServiceVersion.V2020_12_01) { }
        public enum ServiceVersion
        {
            V2020_12_01 = 1,
        }
    }
    public partial class SparkSessionClient
    {
        protected SparkSessionClient() { }
        public SparkSessionClient(System.Uri endpoint, string livyApiVersion, string sparkPoolName, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Spark.SparkClientOptions options = null) { }
        public virtual Azure.Response CancelSparkSession(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSparkSessionAsync(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatementCancellationResult> CancelSparkStatement(int sessionId, int statementId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatementCancellationResult>> CancelSparkStatementAsync(int sessionId, int statementId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSession> GetSparkSession(int sessionId, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSession>> GetSparkSessionAsync(int sessionId, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSessionCollection> GetSparkSessions(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSessionCollection>> GetSparkSessionsAsync(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatement> GetSparkStatement(int sessionId, int statementId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatement>> GetSparkStatementAsync(int sessionId, int statementId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatementCollection> GetSparkStatements(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatementCollection>> GetSparkStatementsAsync(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetSparkSessionTimeout(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetSparkSessionTimeoutAsync(int sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Spark.SparkSessionOperation StartCreateSparkSession(Azure.Analytics.Synapse.Spark.Models.SparkSessionOptions sparkSessionOptions, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Spark.SparkSessionOperation> StartCreateSparkSessionAsync(Azure.Analytics.Synapse.Spark.Models.SparkSessionOptions sparkSessionOptions, bool? detailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Analytics.Synapse.Spark.SparkStatementOperation StartCreateSparkStatement(int sessionId, Azure.Analytics.Synapse.Spark.Models.SparkStatementOptions sparkStatementOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Analytics.Synapse.Spark.SparkStatementOperation> StartCreateSparkStatementAsync(int sessionId, Azure.Analytics.Synapse.Spark.Models.SparkStatementOptions sparkStatementOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkSessionOperation : Azure.Operation<Azure.Analytics.Synapse.Spark.Models.SparkSession>
    {
        protected SparkSessionOperation() { }
        public SparkSessionOperation(int sessionId, Azure.Analytics.Synapse.Spark.SparkSessionClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Spark.Models.SparkSession Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSession>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkSession>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SparkStatementOperation : Azure.Operation<Azure.Analytics.Synapse.Spark.Models.SparkStatement>
    {
        protected SparkStatementOperation() { }
        public SparkStatementOperation(int sessionId, int statementId, Azure.Analytics.Synapse.Spark.SparkSessionClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Analytics.Synapse.Spark.Models.SparkStatement Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatement>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Analytics.Synapse.Spark.Models.SparkStatement>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.Analytics.Synapse.Spark.Models
{
    public static partial class AnalyticsSynapseSparkModelFactory
    {
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJob SparkBatchJob(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobState livyInfo = null, string name = null, string workspaceName = null, string sparkPoolName = null, string submitterName = null, string submitterId = null, string artifactId = null, Azure.Analytics.Synapse.Spark.Models.SparkJobType? jobType = default(Azure.Analytics.Synapse.Spark.Models.SparkJobType?), Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType? result = default(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType?), Azure.Analytics.Synapse.Spark.Models.SparkScheduler scheduler = null, Azure.Analytics.Synapse.Spark.Models.SparkServicePlugin plugin = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Spark.Models.SparkServiceError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int id = 0, string appId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> appInfo = null, Azure.Analytics.Synapse.Spark.Models.LivyStates? state = default(Azure.Analytics.Synapse.Spark.Models.LivyStates?), System.Collections.Generic.IEnumerable<string> logLines = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobCollection SparkBatchJobCollection(int from = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob> sessions = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobState SparkBatchJobState(System.DateTimeOffset? notStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? startingAt = default(System.DateTimeOffset?), System.DateTimeOffset? runningAt = default(System.DateTimeOffset?), System.DateTimeOffset? deadAt = default(System.DateTimeOffset?), System.DateTimeOffset? successAt = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedAt = default(System.DateTimeOffset?), System.DateTimeOffset? recoveringAt = default(System.DateTimeOffset?), string currentState = null, Azure.Analytics.Synapse.Spark.Models.SparkRequest jobCreationRequest = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkRequest SparkRequest(string name = null, string file = null, string className = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IEnumerable<string> jars = null, System.Collections.Generic.IEnumerable<string> pythonFiles = null, System.Collections.Generic.IEnumerable<string> files = null, System.Collections.Generic.IEnumerable<string> archives = null, System.Collections.Generic.IReadOnlyDictionary<string, string> configuration = null, string driverMemory = null, int? driverCores = default(int?), string executorMemory = null, int? executorCores = default(int?), int? executorCount = default(int?)) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkScheduler SparkScheduler(System.DateTimeOffset? submittedAt = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAt = default(System.DateTimeOffset?), System.DateTimeOffset? endedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancellationRequestedAt = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState? currentState = default(Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState?)) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkServiceError SparkServiceError(string message = null, string errorCode = null, Azure.Analytics.Synapse.Spark.Models.SparkErrorSource? source = default(Azure.Analytics.Synapse.Spark.Models.SparkErrorSource?)) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkServicePlugin SparkServicePlugin(System.DateTimeOffset? preparationStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? resourceAcquisitionStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? submissionStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? monitoringStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cleanupStartedAt = default(System.DateTimeOffset?), Azure.Analytics.Synapse.Spark.Models.PluginCurrentState? currentState = default(Azure.Analytics.Synapse.Spark.Models.PluginCurrentState?)) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSession SparkSession(Azure.Analytics.Synapse.Spark.Models.SparkSessionState livyInfo = null, string name = null, string workspaceName = null, string sparkPoolName = null, string submitterName = null, string submitterId = null, string artifactId = null, Azure.Analytics.Synapse.Spark.Models.SparkJobType? jobType = default(Azure.Analytics.Synapse.Spark.Models.SparkJobType?), Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType? result = default(Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType?), Azure.Analytics.Synapse.Spark.Models.SparkScheduler scheduler = null, Azure.Analytics.Synapse.Spark.Models.SparkServicePlugin plugin = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Spark.Models.SparkServiceError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, int id = 0, string appId = null, System.Collections.Generic.IReadOnlyDictionary<string, string> appInfo = null, Azure.Analytics.Synapse.Spark.Models.LivyStates? state = default(Azure.Analytics.Synapse.Spark.Models.LivyStates?), System.Collections.Generic.IEnumerable<string> logLines = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionCollection SparkSessionCollection(int from = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Spark.Models.SparkSession> sessions = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionState SparkSessionState(System.DateTimeOffset? notStartedAt = default(System.DateTimeOffset?), System.DateTimeOffset? startingAt = default(System.DateTimeOffset?), System.DateTimeOffset? idleAt = default(System.DateTimeOffset?), System.DateTimeOffset? deadAt = default(System.DateTimeOffset?), System.DateTimeOffset? shuttingDownAt = default(System.DateTimeOffset?), System.DateTimeOffset? terminatedAt = default(System.DateTimeOffset?), System.DateTimeOffset? recoveringAt = default(System.DateTimeOffset?), System.DateTimeOffset? busyAt = default(System.DateTimeOffset?), System.DateTimeOffset? errorAt = default(System.DateTimeOffset?), string currentState = null, Azure.Analytics.Synapse.Spark.Models.SparkRequest jobCreationRequest = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatement SparkStatement(int id = 0, string code = null, Azure.Analytics.Synapse.Spark.Models.LivyStatementStates? state = default(Azure.Analytics.Synapse.Spark.Models.LivyStatementStates?), Azure.Analytics.Synapse.Spark.Models.SparkStatementOutput output = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementCancellationResult SparkStatementCancellationResult(string message = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementCollection SparkStatementCollection(int total = 0, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Spark.Models.SparkStatement> statements = null) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementOutput SparkStatementOutput(string status = null, int executionCount = 0, object data = null, string errorName = null, string errorValue = null, System.Collections.Generic.IEnumerable<string> traceback = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivyStatementStates : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.LivyStatementStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivyStatementStates(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Available { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Cancelled { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Cancelling { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Error { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Running { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStatementStates Waiting { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.LivyStatementStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.LivyStatementStates left, Azure.Analytics.Synapse.Spark.Models.LivyStatementStates right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.LivyStatementStates (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.LivyStatementStates left, Azure.Analytics.Synapse.Spark.Models.LivyStatementStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivyStates : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.LivyStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivyStates(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Busy { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Dead { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Error { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Idle { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Killed { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates NotStarted { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Recovering { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Running { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates ShuttingDown { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Starting { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.LivyStates Success { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.LivyStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.LivyStates left, Azure.Analytics.Synapse.Spark.Models.LivyStates right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.LivyStates (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.LivyStates left, Azure.Analytics.Synapse.Spark.Models.LivyStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PluginCurrentState : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.PluginCurrentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PluginCurrentState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Cleanup { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Ended { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Monitoring { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Preparation { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Queued { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState ResourceAcquisition { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.PluginCurrentState Submission { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.PluginCurrentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.PluginCurrentState left, Azure.Analytics.Synapse.Spark.Models.PluginCurrentState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.PluginCurrentState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.PluginCurrentState left, Azure.Analytics.Synapse.Spark.Models.PluginCurrentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchedulerCurrentState : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchedulerCurrentState(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState Ended { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState Queued { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState Scheduled { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState left, Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState left, Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkBatchJob
    {
        internal SparkBatchJob() { }
        public string AppId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AppInfo { get { throw null; } }
        public string ArtifactId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Spark.Models.SparkServiceError> Errors { get { throw null; } }
        public int Id { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkJobType? JobType { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkBatchJobState LivyInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LogLines { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkServicePlugin Plugin { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType? Result { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkScheduler Scheduler { get { throw null; } }
        public string SparkPoolName { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.LivyStates? State { get { throw null; } }
        public string SubmitterId { get { throw null; } }
        public string SubmitterName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
    }
    public partial class SparkBatchJobCollection
    {
        internal SparkBatchJobCollection() { }
        public int From { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Spark.Models.SparkBatchJob> Sessions { get { throw null; } }
        public int Total { get { throw null; } }
    }
    public partial class SparkBatchJobOptions
    {
        public SparkBatchJobOptions(string name, string file) { }
        public SparkBatchJobOptions(string name, string file, Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType creationCompletionType = Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType.JobSubmission) { }
        public System.Collections.Generic.IList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string ArtifactId { get { throw null; } set { } }
        public string ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Configuration { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkBatchOperationCompletionType CreationCompletionType { get { throw null; } set { } }
        public int? DriverCores { get { throw null; } set { } }
        public string DriverMemory { get { throw null; } set { } }
        public int? ExecutorCores { get { throw null; } set { } }
        public int? ExecutorCount { get { throw null; } set { } }
        public string ExecutorMemory { get { throw null; } set { } }
        public string File { get { throw null; } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<string> Jars { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> PythonFiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkBatchJobResultType : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkBatchJobResultType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType Cancelled { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType Succeeded { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType Uncertain { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType left, Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType left, Azure.Analytics.Synapse.Spark.Models.SparkBatchJobResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkBatchJobState
    {
        internal SparkBatchJobState() { }
        public string CurrentState { get { throw null; } }
        public System.DateTimeOffset? DeadAt { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkRequest JobCreationRequest { get { throw null; } }
        public System.DateTimeOffset? NotStartedAt { get { throw null; } }
        public System.DateTimeOffset? RecoveringAt { get { throw null; } }
        public System.DateTimeOffset? RunningAt { get { throw null; } }
        public System.DateTimeOffset? StartingAt { get { throw null; } }
        public System.DateTimeOffset? SuccessAt { get { throw null; } }
        public System.DateTimeOffset? TerminatedAt { get { throw null; } }
    }
    public enum SparkBatchOperationCompletionType
    {
        JobSubmission = 0,
        JobExecution = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkErrorSource : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SparkErrorSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkErrorSource(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkErrorSource DependencyError { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkErrorSource SystemError { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkErrorSource UnknownError { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkErrorSource UserError { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SparkErrorSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SparkErrorSource left, Azure.Analytics.Synapse.Spark.Models.SparkErrorSource right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SparkErrorSource (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SparkErrorSource left, Azure.Analytics.Synapse.Spark.Models.SparkErrorSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkJobType : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SparkJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkJobType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkJobType SparkBatch { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkJobType SparkSession { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SparkJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SparkJobType left, Azure.Analytics.Synapse.Spark.Models.SparkJobType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SparkJobType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SparkJobType left, Azure.Analytics.Synapse.Spark.Models.SparkJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkRequest
    {
        internal SparkRequest() { }
        public System.Collections.Generic.IReadOnlyList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Arguments { get { throw null; } }
        public string ClassName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Configuration { get { throw null; } }
        public int? DriverCores { get { throw null; } }
        public string DriverMemory { get { throw null; } }
        public int? ExecutorCores { get { throw null; } }
        public int? ExecutorCount { get { throw null; } }
        public string ExecutorMemory { get { throw null; } }
        public string File { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Files { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Jars { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PythonFiles { get { throw null; } }
    }
    public partial class SparkScheduler
    {
        internal SparkScheduler() { }
        public System.DateTimeOffset? CancellationRequestedAt { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SchedulerCurrentState? CurrentState { get { throw null; } }
        public System.DateTimeOffset? EndedAt { get { throw null; } }
        public System.DateTimeOffset? ScheduledAt { get { throw null; } }
        public System.DateTimeOffset? SubmittedAt { get { throw null; } }
    }
    public partial class SparkServiceError
    {
        internal SparkServiceError() { }
        public string ErrorCode { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkErrorSource? Source { get { throw null; } }
    }
    public partial class SparkServicePlugin
    {
        internal SparkServicePlugin() { }
        public System.DateTimeOffset? CleanupStartedAt { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.PluginCurrentState? CurrentState { get { throw null; } }
        public System.DateTimeOffset? MonitoringStartedAt { get { throw null; } }
        public System.DateTimeOffset? PreparationStartedAt { get { throw null; } }
        public System.DateTimeOffset? ResourceAcquisitionStartedAt { get { throw null; } }
        public System.DateTimeOffset? SubmissionStartedAt { get { throw null; } }
    }
    public partial class SparkSession
    {
        internal SparkSession() { }
        public string AppId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AppInfo { get { throw null; } }
        public string ArtifactId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Spark.Models.SparkServiceError> Errors { get { throw null; } }
        public int Id { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkJobType? JobType { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkSessionState LivyInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LogLines { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkServicePlugin Plugin { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType? Result { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkScheduler Scheduler { get { throw null; } }
        public string SparkPoolName { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.LivyStates? State { get { throw null; } }
        public string SubmitterId { get { throw null; } }
        public string SubmitterName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string WorkspaceName { get { throw null; } }
    }
    public partial class SparkSessionCollection
    {
        internal SparkSessionCollection() { }
        public int From { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Spark.Models.SparkSession> Sessions { get { throw null; } }
        public int Total { get { throw null; } }
    }
    public partial class SparkSessionOptions
    {
        public SparkSessionOptions(string name) { }
        public System.Collections.Generic.IList<string> Archives { get { throw null; } }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string ArtifactId { get { throw null; } set { } }
        public string ClassName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Configuration { get { throw null; } }
        public int? DriverCores { get { throw null; } set { } }
        public string DriverMemory { get { throw null; } set { } }
        public int? ExecutorCores { get { throw null; } set { } }
        public int? ExecutorCount { get { throw null; } set { } }
        public string ExecutorMemory { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<string> Jars { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> PythonFiles { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkSessionResultType : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkSessionResultType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType Cancelled { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType Failed { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType Succeeded { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType Uncertain { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType left, Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType left, Azure.Analytics.Synapse.Spark.Models.SparkSessionResultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkSessionState
    {
        internal SparkSessionState() { }
        public System.DateTimeOffset? BusyAt { get { throw null; } }
        public string CurrentState { get { throw null; } }
        public System.DateTimeOffset? DeadAt { get { throw null; } }
        public System.DateTimeOffset? ErrorAt { get { throw null; } }
        public System.DateTimeOffset? IdleAt { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkRequest JobCreationRequest { get { throw null; } }
        public System.DateTimeOffset? NotStartedAt { get { throw null; } }
        public System.DateTimeOffset? RecoveringAt { get { throw null; } }
        public System.DateTimeOffset? ShuttingDownAt { get { throw null; } }
        public System.DateTimeOffset? StartingAt { get { throw null; } }
        public System.DateTimeOffset? TerminatedAt { get { throw null; } }
    }
    public partial class SparkStatement
    {
        internal SparkStatement() { }
        public string Code { get { throw null; } }
        public int Id { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.SparkStatementOutput Output { get { throw null; } }
        public Azure.Analytics.Synapse.Spark.Models.LivyStatementStates? State { get { throw null; } }
    }
    public partial class SparkStatementCancellationResult
    {
        internal SparkStatementCancellationResult() { }
        public string Message { get { throw null; } }
    }
    public partial class SparkStatementCollection
    {
        internal SparkStatementCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Spark.Models.SparkStatement> Statements { get { throw null; } }
        public int Total { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SparkStatementLanguageType : System.IEquatable<Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SparkStatementLanguageType(string value) { throw null; }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType DotNetSpark { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType PySpark { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType Spark { get { throw null; } }
        public static Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType Sql { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType left, Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType right) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType left, Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkStatementOptions
    {
        public SparkStatementOptions() { }
        public string Code { get { throw null; } set { } }
        public Azure.Analytics.Synapse.Spark.Models.SparkStatementLanguageType? Kind { get { throw null; } set { } }
    }
    public partial class SparkStatementOutput
    {
        internal SparkStatementOutput() { }
        public object Data { get { throw null; } }
        public string ErrorName { get { throw null; } }
        public string ErrorValue { get { throw null; } }
        public int ExecutionCount { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Traceback { get { throw null; } }
    }
}
