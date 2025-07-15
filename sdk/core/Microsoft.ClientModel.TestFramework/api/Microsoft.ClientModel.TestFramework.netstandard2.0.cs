namespace Microsoft.ClientModel.TestFramework
{
    public static partial class AsyncAssert
    {
        public static System.Threading.Tasks.Task<T> ThrowsAsync<T>(System.Func<System.Threading.Tasks.Task> action) where T : System.Exception { throw null; }
    }
    public delegate System.Threading.Tasks.ValueTask<T> AsyncCallInterceptor<T>(Castle.DynamicProxy.IInvocation invocation, System.Func<System.Threading.Tasks.ValueTask<T>> innerTask);
    public partial class AsyncCollectionResultInterceptor<T> : System.Collections.Generic.IAsyncEnumerator<T>, System.IAsyncDisposable where T : class
    {
        public AsyncCollectionResultInterceptor(Microsoft.ClientModel.TestFramework.ClientTestBase testBase, System.Collections.Generic.IAsyncEnumerator<T> inner) { }
        public T Current { get { throw null; } }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public System.Threading.Tasks.ValueTask<bool> MoveNextAsync() { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public partial class AsyncOnlyAttribute : NUnit.Framework.NUnitAttribute
    {
        public AsyncOnlyAttribute() { }
    }
    public abstract partial class ClientTestBase
    {
        protected static readonly Castle.DynamicProxy.ProxyGenerator ProxyGenerator;
        public ClientTestBase(bool isAsync) { }
        protected System.Collections.Generic.IReadOnlyCollection<Castle.DynamicProxy.IInterceptor>? AdditionalInterceptors { get { throw null; } set { } }
        public bool IsAsync { get { throw null; } }
        public bool TestDiagnostics { get { throw null; } set { } }
        protected virtual System.DateTime TestStartTime { get { throw null; } }
        public int TestTimeoutInSeconds { get { throw null; } set { } }
        protected TClient CreateClient<TClient>(params object[] args) where TClient : class { throw null; }
        [NUnit.Framework.TearDownAttribute]
        public virtual void GlobalTimeoutTearDown() { }
        protected internal virtual object InstrumentClient(System.Type clientType, object client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor>? preInterceptors) { throw null; }
        public TClient InstrumentClient<TClient>(TClient client) where TClient : class { throw null; }
        protected TClient InstrumentClient<TClient>(TClient client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor> preInterceptors) where TClient : class { throw null; }
    }
    public enum EntryRecordModel
    {
        Record = 0,
        DoNotRecord = 1,
        RecordWithoutRequestBody = 2,
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public partial class LiveOnlyAttribute : NUnit.Framework.NUnitAttribute, NUnit.Framework.Interfaces.IApplyToTest
    {
        public LiveOnlyAttribute(bool alwaysRunLocally = false) { }
        public string? Reason { get { throw null; } set { } }
        public void ApplyToTest(NUnit.Framework.Internal.Test test) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public partial class LiveParallelizableAttribute : NUnit.Framework.ParallelizableAttribute
    {
        public LiveParallelizableAttribute(NUnit.Framework.ParallelScope scope) { }
    }
    [Microsoft.ClientModel.TestFramework.LiveOnlyAttribute(false)]
    public partial class LiveTestBase<TEnvironment> where TEnvironment : Microsoft.ClientModel.TestFramework.TestEnvironment, new()
    {
        protected LiveTestBase() { }
        protected TEnvironment TestEnvironment { get { throw null; } }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.ValueTask WaitForEnvironment() { throw null; }
    }
    public partial class MicrosoftClientModelTestFrameworkContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal MicrosoftClientModelTestFrameworkContext() { }
        public static Microsoft.ClientModel.TestFramework.MicrosoftClientModelTestFrameworkContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MicrosoftClientModelTestFrameworkModelFactory
    {
        public static Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer BodyKeySanitizer(string jsonPath = null, string value = null, string regex = null, string groupForReplace = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer BodyRegexSanitizer(string regex = null, string value = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher CustomDefaultMatcher(string excludedHeaders = null, bool? compareBodies = default(bool?), string ignoredHeaders = null, string ignoredQueryParameters = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition HeaderCondition(string key = null, string valueRegex = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer HeaderRegexSanitizer(string key = null, string value = null, string regex = null, string groupForReplace = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform HeaderTransform(string key = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions ProxyOptions(Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport transport = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport ProxyOptionsTransport(bool allowAutoRedirect = false, string tlsValidationCert = null, System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem> certificates = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem ProxyOptionsTransportCertificationsItem(string pemValue = null, string pemKey = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition SanitizerCondition(string uriRegex = null, Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition responseHeader = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove SanitizersToRemove(System.Collections.Generic.IEnumerable<string> sanitizers = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.StartInformation StartInformation(string xRecordingFile = null, string xRecodingAssetsFiles = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse StartPlaybackResponse() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse StartRecordResponse() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse StopPlaybackResponse() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest StopRecordRequest() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer UriRegexSanitizer(string regex = null, string value = null, string groupForReplace = null) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=true, Inherited=true)]
    public partial class PlaybackOnlyAttribute : NUnit.Framework.NUnitAttribute, NUnit.Framework.Interfaces.IApplyToTest
    {
        public PlaybackOnlyAttribute(string reason) { }
        public void ApplyToTest(NUnit.Framework.Internal.Test test) { }
    }
    public partial class ProxyTransport : System.ClientModel.Primitives.PipelineTransport
    {
        public ProxyTransport(Microsoft.ClientModel.TestFramework.TestProxyProcess proxyProcess, System.ClientModel.Primitives.PipelineTransport innerTransport, Microsoft.ClientModel.TestFramework.TestRecording recording, System.Func<Microsoft.ClientModel.TestFramework.EntryRecordModel> getRecordingMode) { }
        protected override System.ClientModel.Primitives.PipelineMessage CreateMessageCore() { throw null; }
        protected override void ProcessCore(System.ClientModel.Primitives.PipelineMessage message) { }
        protected override System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
    public static partial class RandomExtensions
    {
        public static System.Guid NewGuid(this System.Random random) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method)]
    public partial class RecordedTestAttribute : NUnit.Framework.TestAttribute, NUnit.Framework.Interfaces.ICommandWrapper, NUnit.Framework.Interfaces.IWrapSetUpTearDown
    {
        public RecordedTestAttribute() { }
        public NUnit.Framework.Internal.Commands.TestCommand Wrap(NUnit.Framework.Internal.Commands.TestCommand command) { throw null; }
    }
    [NUnit.Framework.NonParallelizableAttribute]
    public partial class RecordedTestBase : Microsoft.ClientModel.TestFramework.ClientTestBase
    {
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform> HeaderTransforms;
        public System.Collections.Generic.HashSet<string> IgnoredHeaders;
        public System.Collections.Generic.HashSet<string> IgnoredQueryParameters;
        public RecordedTestBase(bool isAsync) : base (default(bool)) { }
        protected RecordedTestBase(bool isAsync, Microsoft.ClientModel.TestFramework.RecordedTestMode? mode = default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) : base (default(bool)) { }
        public virtual string? AssetsJsonPath { get { throw null; } }
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer> BodyKeySanitizers { get { throw null; } }
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer> BodyRegexSanitizers { get { throw null; } }
        public bool CompareBodies { get { throw null; } set { } }
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer> HeaderRegexSanitizers { get { throw null; } }
        public System.Collections.Generic.List<string> JsonPathSanitizers { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.RecordedTestMode Mode { get { throw null; } set { } }
        public Microsoft.ClientModel.TestFramework.TestRecording? Recording { get { throw null; } }
        public System.Collections.Generic.List<string> SanitizedHeaders { get { throw null; } }
        public System.Collections.Generic.List<string> SanitizedQueryParameters { get { throw null; } }
        public System.Collections.Generic.List<(string Header, string QueryParameter)> SanitizedQueryParametersInHeaders { get { throw null; } }
        public System.Collections.Generic.List<string> SanitizersToRemove { get { throw null; } }
        protected override System.DateTime TestStartTime { get { throw null; } }
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer> UriRegexSanitizers { get { throw null; } }
        protected bool UseLocalDebugProxy { get { throw null; } set { } }
        protected bool ValidateClientInstrumentation { get { throw null; } set { } }
        protected System.Threading.Tasks.Task<Microsoft.ClientModel.TestFramework.TestRecording> CreateTestRecordingAsync(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, string sessionFile) { throw null; }
        public static System.Threading.Tasks.Task Delay(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        public System.Threading.Tasks.Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        protected internal string GetSessionFilePath() { throw null; }
        public override void GlobalTimeoutTearDown() { }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public void InitializeRecordedTestClass() { }
        protected internal override object InstrumentClient(System.Type clientType, object client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor>? preInterceptors) { throw null; }
        public T InstrumentClientOptions<T>(T clientOptions, Microsoft.ClientModel.TestFramework.TestRecording? recording = null) where T : System.ClientModel.Primitives.ClientPipelineOptions { throw null; }
        protected System.Threading.Tasks.Task SetProxyOptionsAsync(Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions options) { throw null; }
        [NUnit.Framework.SetUpAttribute]
        public virtual System.Threading.Tasks.Task StartTestRecordingAsync() { throw null; }
        [NUnit.Framework.TearDownAttribute]
        public virtual System.Threading.Tasks.Task StopTestRecordingAsync() { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public void TearDownRecordedTestClass() { }
    }
    public abstract partial class RecordedTestBase<TEnvironment> : Microsoft.ClientModel.TestFramework.RecordedTestBase where TEnvironment : Microsoft.ClientModel.TestFramework.TestEnvironment, new()
    {
        protected RecordedTestBase(bool isAsync, Microsoft.ClientModel.TestFramework.RecordedTestMode? mode = default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) : base (default(bool)) { }
        public TEnvironment TestEnvironment { get { throw null; } }
    }
    public enum RecordedTestMode
    {
        Live = 0,
        Record = 1,
        Playback = 2,
    }
    public partial class RecordEntryMessage
    {
        public RecordEntryMessage() { }
        public byte[]? Body { get { throw null; } set { } }
        public System.Collections.Generic.SortedDictionary<string, string[]> Headers { get { throw null; } set { } }
        public bool IsTextContentType(out System.Text.Encoding encoding) { throw null; }
        public bool TryGetBodyAsText(out string text) { throw null; }
        public bool TryGetContentType(out string contentType) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public abstract partial class RetryOnErrorAttribute : NUnit.Framework.NUnitAttribute, NUnit.Framework.Interfaces.ICommandWrapper, NUnit.Framework.Interfaces.IRepeatTest
    {
        protected RetryOnErrorAttribute(int tryCount, System.Func<NUnit.Framework.Internal.TestExecutionContext, bool> shouldRetry) { }
        public NUnit.Framework.Internal.Commands.TestCommand Wrap(NUnit.Framework.Internal.Commands.TestCommand command) { throw null; }
        public partial class RetryOnErrorCommand : NUnit.Framework.Internal.Commands.DelegatingTestCommand
        {
            public RetryOnErrorCommand(NUnit.Framework.Internal.Commands.TestCommand innerCommand, int tryCount, System.Func<NUnit.Framework.Internal.TestExecutionContext, bool> shouldRetry) : base (default(NUnit.Framework.Internal.Commands.TestCommand)) { }
            public override NUnit.Framework.Internal.TestResult Execute(NUnit.Framework.Internal.TestExecutionContext context) { throw null; }
        }
    }
    public enum SanitizedValue
    {
        Default = 0,
        Base64 = 1,
    }
    public partial class SyncAsyncPolicyTestBase
    {
        public SyncAsyncPolicyTestBase() { }
    }
    public partial class SyncAsyncTestBase
    {
        public SyncAsyncTestBase(bool isAsync) { }
        public bool IsAsync { get { throw null; } }
        protected Microsoft.ClientModel.TestFramework.Mocks.MockPipelineTransport CreateMockTransport() { throw null; }
        protected Microsoft.ClientModel.TestFramework.Mocks.MockPipelineTransport CreateMockTransport(System.Func<Microsoft.ClientModel.TestFramework.Mocks.MockPipelineMessage, Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse> responseFactory) { throw null; }
        protected System.IO.Stream WrapStream(System.IO.Stream stream) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public partial class SyncOnlyAttribute : NUnit.Framework.NUnitAttribute
    {
        public SyncOnlyAttribute() { }
    }
    public static partial class TestAsyncEnumerableExtensions
    {
        public static System.Threading.Tasks.Task<System.Collections.Generic.List<T>> ToEnumerableAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T> asyncEnumerable) { throw null; }
    }
    public abstract partial class TestEnvironment
    {
        protected TestEnvironment(string serviceName, string[] pathsToEnvironmentFiles) { }
        public static string? DevCertPassword { get { throw null; } set { } }
        public static string? DevCertPath { get { throw null; } set { } }
        public bool LocalRun { get { throw null; } set { } }
        public Microsoft.ClientModel.TestFramework.RecordedTestMode? Mode { get { throw null; } set { } }
        public static string? RepositoryRoot { get { throw null; } }
        public string ServiceName { get { throw null; } }
        public virtual System.ClientModel.AuthenticationTokenProvider TokenProvider { get { throw null; } }
        protected string GetRecordedOptionalVariable(string name) { throw null; }
        public abstract System.Threading.Tasks.Task InitializeEnvironmentAsync();
        public System.Threading.Tasks.ValueTask WaitForEnvironmentAsync() { throw null; }
    }
    public partial class TestFrameworkClient
    {
        protected TestFrameworkClient() { }
        public TestFrameworkClient(System.Uri endpoint) { }
        public TestFrameworkClient(System.Uri endpoint, Microsoft.ClientModel.TestFramework.TestFrameworkClientOptions options) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Microsoft.ClientModel.TestFramework.TestProxy.TestProxyClient GetTestProxyClient() { throw null; }
    }
    public partial class TestFrameworkClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public TestFrameworkClientOptions() { }
    }
    public partial class TestProxyProcess
    {
        internal TestProxyProcess() { }
        public const string IpAddress = "127.0.0.1";
        public int? ProxyPortHttp { get { throw null; } }
        public int? ProxyPortHttps { get { throw null; } }
        public System.Threading.Tasks.Task CheckProxyOutputAsync() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxyProcess Start(bool debugMode = false) { throw null; }
    }
    public partial class TestRandom : System.Random
    {
        public TestRandom(Microsoft.ClientModel.TestFramework.RecordedTestMode mode) { }
        public TestRandom(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, int seed) { }
        public System.Guid NewGuid() { throw null; }
    }
    public partial class TestRecording : System.IAsyncDisposable
    {
        internal TestRecording() { }
        public bool HasRequests { get { throw null; } }
        public System.DateTimeOffset Now { get { throw null; } }
        public string? RecordingId { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.RecordedTestMode TestMode { get { throw null; } }
        public System.DateTimeOffset UtcNow { get { throw null; } }
        public System.Collections.Generic.SortedDictionary<string, string> Variables { get { throw null; } }
        public static System.Threading.Tasks.Task<Microsoft.ClientModel.TestFramework.TestRecording> CreateAsync(Microsoft.ClientModel.TestFramework.TestProxyProcess proxy, Microsoft.ClientModel.TestFramework.RecordedTestMode mode, Microsoft.ClientModel.TestFramework.TestProxy.StartInformation startInformation, Microsoft.ClientModel.TestFramework.TestRecordingOptions? options = null) { throw null; }
        public System.ClientModel.Primitives.HttpClientPipelineTransport CreateTransport() { throw null; }
        public Microsoft.ClientModel.TestFramework.TestRecording.DisableRecordingScope DisableRecording() { throw null; }
        public Microsoft.ClientModel.TestFramework.TestRecording.DisableRecordingScope DisableRequestBodyRecording() { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync(bool save) { throw null; }
        public string GenerateAlphaNumericId() { throw null; }
        public string GenerateAssetName() { throw null; }
        public string GenerateId() { throw null; }
        public string GetVariable() { throw null; }
        public void SetVariable() { }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct DisableRecordingScope : System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public DisableRecordingScope(Microsoft.ClientModel.TestFramework.TestRecording testRecording, Microsoft.ClientModel.TestFramework.EntryRecordModel entryRecordModel) { throw null; }
            public void Dispose() { }
        }
    }
    public partial class TestRecordingMismatchException : System.Exception
    {
        public TestRecordingMismatchException() { }
        public TestRecordingMismatchException(string message) { }
        public TestRecordingMismatchException(string message, System.Exception innerException) { }
    }
    public partial class TestRecordingOptions
    {
        public TestRecordingOptions() { }
        public bool CompareBodies { get { throw null; } set { } }
        public System.Collections.Generic.List<string> IgnoredHeaders { get { throw null; } set { } }
        public System.Collections.Generic.List<string> IgnoredQueryParameters { get { throw null; } set { } }
        public System.Collections.Generic.List<string> JsonPathSanitizers { get { throw null; } set { } }
        public System.Collections.Generic.List<string> SanitizedHeaders { get { throw null; } set { } }
        public System.Collections.Generic.List<string> SanitizedQueryParameters { get { throw null; } set { } }
    }
    public partial class TestTimeoutException : System.Exception
    {
        public TestTimeoutException() { }
        public TestTimeoutException(string message) { }
        public TestTimeoutException(string message, System.Exception innerException) { }
    }
    public partial class UseSyncMethodsInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public UseSyncMethodsInterceptor(bool forceSync) { }
        [System.Diagnostics.DebuggerStepThroughAttribute]
        public void Intercept(Castle.DynamicProxy.IInvocation invocation) { }
        public partial class SyncPageableWrapper<T> : System.ClientModel.AsyncCollectionResult<T>
        {
            protected SyncPageableWrapper() { }
            public SyncPageableWrapper(System.ClientModel.CollectionResult<T> enumerable) { }
            public override System.ClientModel.ContinuationToken? GetContinuationToken(System.ClientModel.ClientResult page) { throw null; }
            public override System.Collections.Generic.IAsyncEnumerable<System.ClientModel.ClientResult> GetRawPagesAsync() { throw null; }
            protected override System.Collections.Generic.IAsyncEnumerable<T> GetValuesFromPageAsync(System.ClientModel.ClientResult page) { throw null; }
        }
    }
}
namespace Microsoft.ClientModel.TestFramework.Mocks
{
    public partial class MockPipelineMessage : System.ClientModel.Primitives.PipelineMessage
    {
        public MockPipelineMessage() : base (default(System.ClientModel.Primitives.PipelineRequest)) { }
        public MockPipelineMessage(System.ClientModel.Primitives.PipelineRequest request) : base (default(System.ClientModel.Primitives.PipelineRequest)) { }
        public void SetResponse(System.ClientModel.Primitives.PipelineResponse response) { }
    }
    public partial class MockPipelineRequest : System.ClientModel.Primitives.PipelineRequest
    {
        public MockPipelineRequest() { }
        protected override System.ClientModel.BinaryContent? ContentCore { get { throw null; } set { } }
        protected override System.ClientModel.Primitives.PipelineRequestHeaders HeadersCore { get { throw null; } }
        protected override string MethodCore { get { throw null; } set { } }
        protected override System.Uri? UriCore { get { throw null; } set { } }
        public sealed override void Dispose() { }
    }
    public partial class MockPipelineResponse : System.ClientModel.Primitives.PipelineResponse
    {
        public MockPipelineResponse(int status = 0, string reasonPhrase = "") { }
        public override System.BinaryData Content { get { throw null; } }
        public override System.IO.Stream? ContentStream { get { throw null; } set { } }
        protected override System.ClientModel.Primitives.PipelineResponseHeaders HeadersCore { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        public override System.BinaryData BufferContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<System.BinaryData> BufferContentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public sealed override void Dispose() { }
        protected void Dispose(bool disposing) { }
        public void SetIsError(bool value) { }
        public Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse WithContent(byte[] content) { throw null; }
        public Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse WithContent(string content) { throw null; }
        public Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse WithHeader(string name, string value) { throw null; }
    }
    public partial class MockPipelineTransport : System.ClientModel.Primitives.PipelineTransport
    {
        public MockPipelineTransport() { }
        public MockPipelineTransport(System.Func<Microsoft.ClientModel.TestFramework.Mocks.MockPipelineMessage, Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse> responseFactory, bool addDelay = false, bool enableLogging = false, Microsoft.Extensions.Logging.ILoggerFactory? loggerFactory = null) { }
        public bool? ExpectSyncPipeline { get { throw null; } set { } }
        public System.Action<Microsoft.ClientModel.TestFramework.Mocks.MockPipelineMessage>? OnReceivedResponse { get { throw null; } set { } }
        public System.Action<Microsoft.ClientModel.TestFramework.Mocks.MockPipelineMessage>? OnSendingRequest { get { throw null; } set { } }
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.Mocks.MockPipelineRequest> Requests { get { throw null; } }
        protected override System.ClientModel.Primitives.PipelineMessage CreateMessageCore() { throw null; }
        protected override void ProcessCore(System.ClientModel.Primitives.PipelineMessage message) { }
        protected override System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
    }
}
namespace Microsoft.ClientModel.TestFramework.TestProxy
{
    public partial class BodyKeySanitizer : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>
    {
        public BodyKeySanitizer(string jsonPath) { }
        public string GroupForReplace { get { throw null; } set { } }
        public string JsonPath { get { throw null; } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyRegexSanitizer : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>
    {
        public BodyRegexSanitizer(string regex) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string Regex { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomDefaultMatcher : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>
    {
        public CustomDefaultMatcher() { }
        public bool? CompareBodies { get { throw null; } set { } }
        public string ExcludedHeaders { get { throw null; } set { } }
        public string IgnoredHeaders { get { throw null; } set { } }
        public string IgnoredQueryParameters { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderCondition : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>
    {
        public HeaderCondition(string key, string valueRegex) { }
        public string Key { get { throw null; } }
        public string ValueRegex { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderRegexSanitizer : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>
    {
        public HeaderRegexSanitizer(string key, string value, string regex, string groupForReplace) { }
        public string GroupForReplace { get { throw null; } }
        public string Key { get { throw null; } }
        public string Regex { get { throw null; } }
        public string Value { get { throw null; } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderTransform : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>
    {
        public HeaderTransform(string key, string value) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition Condition { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProxyOptions : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>
    {
        public ProxyOptions(Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport transport) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport Transport { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions proxyOptions) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProxyOptionsTransport : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>
    {
        public ProxyOptionsTransport(bool allowAutoRedirect, string tlsValidationCert, System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem> certificates) { }
        public bool AllowAutoRedirect { get { throw null; } }
        public System.Collections.Generic.IList<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem> Certificates { get { throw null; } }
        public string TlsValidationCert { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProxyOptionsTransportCertificationsItem : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>
    {
        public ProxyOptionsTransportCertificationsItem(string pemValue, string pemKey) { }
        public string PemKey { get { throw null; } }
        public string PemValue { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SanitizerCondition : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>
    {
        public SanitizerCondition() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition ResponseHeader { get { throw null; } set { } }
        public string UriRegex { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SanitizersToRemove : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>
    {
        public SanitizersToRemove(System.Collections.Generic.IEnumerable<string> sanitizers) { }
        public System.Collections.Generic.IList<string> Sanitizers { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove sanitizersToRemove) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartInformation : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>
    {
        public StartInformation(string xRecordingFile, string xRecodingAssetsFiles) { }
        public string XRecodingAssetsFiles { get { throw null; } }
        public string XRecordingFile { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.StartInformation startInformation) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.StartInformation System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.StartInformation System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartPlaybackResponse : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>
    {
        internal StartPlaybackResponse() { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartRecordResponse : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>
    {
        internal StartRecordResponse() { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopPlaybackResponse : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>
    {
        internal StopPlaybackResponse() { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopRecordRequest : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>
    {
        public StopRecordRequest() { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest stopRecordRequest) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestProxyClient
    {
        protected TestProxyClient() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult AddBodilessMatcher(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddBodilessMatcher(string matcherType, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodilessMatcherAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodilessMatcherAsync(string matcherType, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddBodyKeySanitizer(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddBodyKeySanitizer(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodyKeySanitizerAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodyKeySanitizerAsync(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddBodyRegexSanitizer(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddBodyRegexSanitizer(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodyRegexSanitizerAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddBodyRegexSanitizerAsync(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddCustomMatcher(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddCustomMatcher(string matcherType, Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher matcher, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddCustomMatcherAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddCustomMatcherAsync(string matcherType, Microsoft.ClientModel.TestFramework.TestProxy.CustomDefaultMatcher matcher, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddHeaderSanitizer(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddHeaderSanitizer(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddHeaderSanitizerAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddHeaderSanitizerAsync(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddHeaderTransform(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddHeaderTransform(string transformType, Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddHeaderTransformAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddHeaderTransformAsync(string transformType, Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddSanitizer(string sanitizerType, System.BinaryData sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddSanitizer(string sanitizerType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddSanitizerAsync(string sanitizerType, System.BinaryData sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddSanitizerAsync(string sanitizerType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddTransform(string transformType, System.BinaryData transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddTransform(string transformType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddTransformAsync(string transformType, System.BinaryData transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddTransformAsync(string transformType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddUriSanitizer(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddUriSanitizer(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddUriSanitizerAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddUriSanitizerAsync(string sanitizerType, Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer sanitizer, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult RemoveSanitizers(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove sanitizers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult RemoveSanitizers(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> RemoveSanitizersAsync(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove sanitizers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> RemoveSanitizersAsync(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult SetMatcher(string matcherType, System.BinaryData matcher = null, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SetMatcher(string matcherType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetMatcherAsync(string matcherType, System.BinaryData matcher = null, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetMatcherAsync(string matcherType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingTransportOptions(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions proxyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingTransportOptions(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingTransportOptionsAsync(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions proxyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingTransportOptionsAsync(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse> StartPlayback(Microsoft.ClientModel.TestFramework.TestProxy.StartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartPlayback(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StartPlaybackResponse>> StartPlaybackAsync(Microsoft.ClientModel.TestFramework.TestProxy.StartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartPlaybackAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse> StartRecord(Microsoft.ClientModel.TestFramework.TestProxy.StartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartRecord(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StartRecordResponse>> StartRecordAsync(Microsoft.ClientModel.TestFramework.TestProxy.StartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartRecordAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult StopPlayback(string recordingId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse> StopPlayback(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopPlaybackAsync(string recordingId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.StopPlaybackResponse>> StopPlaybackAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StopRecord(string recordingId, string recordingSkip, Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest variables, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StopRecord(string recordingId, string recordingSkip, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopRecordAsync(string recordingId, string recordingSkip, Microsoft.ClientModel.TestFramework.TestProxy.StopRecordRequest variables, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopRecordAsync(string recordingId, string recordingSkip, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class TestProxyClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public TestProxyClientOptions() { }
    }
    public partial class UriRegexSanitizer : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>
    {
        public UriRegexSanitizer(string regex, string value, string groupForReplace) { }
        public string GroupForReplace { get { throw null; } }
        public string Regex { get { throw null; } }
        public string Value { get { throw null; } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
