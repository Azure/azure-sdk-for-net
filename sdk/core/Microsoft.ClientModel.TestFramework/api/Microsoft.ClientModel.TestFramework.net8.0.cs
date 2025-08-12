namespace Microsoft.ClientModel.TestFramework
{
    public static partial class AsyncAssert
    {
        public static System.Threading.Tasks.Task<T> ThrowsAsync<T>(System.Func<System.Threading.Tasks.Task> action) where T : System.Exception { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public partial class AsyncOnlyAttribute : NUnit.Framework.NUnitAttribute
    {
        public AsyncOnlyAttribute() { }
    }
    [Microsoft.ClientModel.TestFramework.ClientTestFixtureAttribute(new object[]{ })]
    public abstract partial class ClientTestBase
    {
        protected static readonly Castle.DynamicProxy.ProxyGenerator ProxyGenerator;
        public ClientTestBase(bool isAsync) { }
        protected System.Collections.Generic.IReadOnlyCollection<Castle.DynamicProxy.IInterceptor>? AdditionalInterceptors { get { throw null; } set { } }
        public bool IsAsync { get { throw null; } }
        protected virtual System.DateTime TestStartTime { get { throw null; } }
        public int TestTimeoutInSeconds { get { throw null; } set { } }
        protected TClient CreateProxiedClient<TClient>(params object[] args) where TClient : class { throw null; }
        protected internal virtual object CreateProxyFromClient(System.Type clientType, object client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor>? preInterceptors) { throw null; }
        public TClient CreateProxyFromClient<TClient>(TClient client) where TClient : class { throw null; }
        protected TClient CreateProxyFromClient<TClient>(TClient client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor> preInterceptors) where TClient : class { throw null; }
        protected internal virtual object CreateProxyFromOperationResult(System.Type operationType, object operation) { throw null; }
        protected internal T CreateProxyFromOperationResult<T>(T operation) where T : System.ClientModel.Primitives.OperationResult { throw null; }
        protected T GetOriginal<T>(T proxied) { throw null; }
        [NUnit.Framework.TearDownAttribute]
        public virtual void GlobalTimeoutTearDown() { }
    }
    public partial class ClientTestFixtureAttribute : NUnit.Framework.NUnitAttribute, NUnit.Framework.Interfaces.IFixtureBuilder, NUnit.Framework.Interfaces.IFixtureBuilder2, NUnit.Framework.Interfaces.IPreFilter
    {
        public static readonly string RecordingDirectorySuffixKey;
        public static readonly string SyncOnlyKey;
        public ClientTestFixtureAttribute(params object[] additionalParameters) { }
        public System.Collections.Generic.IEnumerable<NUnit.Framework.Internal.TestSuite> BuildFrom(NUnit.Framework.Interfaces.ITypeInfo typeInfo) { throw null; }
        public System.Collections.Generic.IEnumerable<NUnit.Framework.Internal.TestSuite> BuildFrom(NUnit.Framework.Interfaces.ITypeInfo typeInfo, NUnit.Framework.Interfaces.IPreFilter filter) { throw null; }
        bool NUnit.Framework.Interfaces.IPreFilter.IsMatch(System.Type type) { throw null; }
        bool NUnit.Framework.Interfaces.IPreFilter.IsMatch(System.Type type, System.Reflection.MethodInfo method) { throw null; }
    }
    public abstract partial class DisposableConfig : System.IDisposable
    {
        protected readonly System.Collections.Generic.Dictionary<string, string> OriginalValues;
        public DisposableConfig(System.Collections.Generic.Dictionary<string, string> values, System.Threading.SemaphoreSlim sem) { }
        public DisposableConfig(string name, string value, System.Threading.SemaphoreSlim sem) { }
        internal abstract void Cleanup();
        public void Dispose() { }
        internal abstract void InitValues();
        internal abstract void SetValue(string name, string value);
        internal abstract void SetValues(System.Collections.Generic.Dictionary<string, string> values);
    }
    public enum EntryRecordModel
    {
        Record = 0,
        DoNotRecord = 1,
        RecordWithoutRequestBody = 2,
    }
    public partial interface IProxiedClient
    {
        object Original { get; }
    }
    public partial interface IProxiedOperationResult
    {
        object Original { get; }
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
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition HeaderCondition(string key = null, string valueRegex = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer HeaderRegexSanitizer(string key = null, string value = null, string regex = null, string groupForReplace = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform HeaderTransform(string key = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions ProxyOptions(Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport transport = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransport ProxyOptionsTransport(bool allowAutoRedirect = false, string tlsValidationCert = null, System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem> certificates = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptionsTransportCertificationsItem ProxyOptionsTransportCertificationsItem(string pemValue = null, string pemKey = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.SanitizerCondition SanitizerCondition(string uriRegex = null, Microsoft.ClientModel.TestFramework.TestProxy.HeaderCondition responseHeader = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove SanitizersToRemove(System.Collections.Generic.IEnumerable<string> sanitizers = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation TestProxyStartInformation(string xRecordingFile = null, string xRecordingAssetsFiles = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer UriRegexSanitizer(string regex = null, string value = null, string groupForReplace = null) { throw null; }
    }
    public partial class MockCredential : System.ClientModel.AuthenticationTokenProvider
    {
        public MockCredential() { }
        public MockCredential(string token, System.DateTimeOffset expiresOn) { }
        public override System.ClientModel.Primitives.GetTokenOptions? CreateTokenOptions(System.Collections.Generic.IReadOnlyDictionary<string, object> properties) { throw null; }
        public override System.ClientModel.Primitives.AuthenticationToken GetToken(System.ClientModel.Primitives.GetTokenOptions options, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<System.ClientModel.Primitives.AuthenticationToken> GetTokenAsync(System.ClientModel.Primitives.GetTokenOptions options, System.Threading.CancellationToken cancellationToken) { throw null; }
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
    public abstract partial class RecordedTestBase : Microsoft.ClientModel.TestFramework.ClientTestBase
    {
        public const string AssetsJson = "assets.json";
        public System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform> HeaderTransforms;
        public System.Collections.Generic.HashSet<string> IgnoredHeaders;
        public System.Collections.Generic.HashSet<string> IgnoredQueryParameters;
        public const string SanitizeValue = "Sanitized";
        protected RecordedTestBase(bool isAsync, Microsoft.ClientModel.TestFramework.RecordedTestMode? mode = default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) : base (default(bool)) { }
        public virtual string? AssetsJsonPath { get { throw null; } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer> BodyKeySanitizers { get { throw null; } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer> BodyRegexSanitizers { get { throw null; } }
        public bool CompareBodies { get { throw null; } set { } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer> HeaderRegexSanitizers { get { throw null; } }
        public virtual System.Collections.Generic.List<string> JsonPathSanitizers { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.RecordedTestMode Mode { get { throw null; } set { } }
        public virtual Microsoft.ClientModel.TestFramework.TestRecording? Recording { get { throw null; } }
        public virtual System.Collections.Generic.List<string> SanitizedHeaders { get { throw null; } }
        public virtual System.Collections.Generic.List<string> SanitizedQueryParameters { get { throw null; } }
        public virtual System.Collections.Generic.List<(string Header, string QueryParameter)> SanitizedQueryParametersInHeaders { get { throw null; } }
        public virtual System.Collections.Generic.List<string> SanitizersToRemove { get { throw null; } }
        public bool SaveDebugRecordingsOnFailure { get { throw null; } set { } }
        protected Microsoft.ClientModel.TestFramework.TestRetryHelper TestRetryHelper { get { throw null; } }
        protected override System.DateTime TestStartTime { get { throw null; } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer> UriRegexSanitizers { get { throw null; } }
        protected bool UseLocalDebugProxy { get { throw null; } set { } }
        protected bool ValidateClientInstrumentation { get { throw null; } set { } }
        protected internal override object CreateProxyFromClient(System.Type clientType, object client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor>? preInterceptors) { throw null; }
        protected internal override object CreateProxyFromOperationResult(System.Type operationType, object operation) { throw null; }
        protected System.Threading.Tasks.Task<Microsoft.ClientModel.TestFramework.TestRecording> CreateTestRecordingAsync(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, string sessionFile) { throw null; }
        public static System.Threading.Tasks.Task Delay(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        public System.Threading.Tasks.Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        protected internal string GetSessionFilePath() { throw null; }
        public override void GlobalTimeoutTearDown() { }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public void InitializeRecordedTestClass() { }
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
        protected RecordedTestBase(bool isAsync, Microsoft.ClientModel.TestFramework.RecordedTestMode? mode = default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) : base (default(bool), default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) { }
        public TEnvironment TestEnvironment { get { throw null; } }
        public override System.Threading.Tasks.Task StartTestRecordingAsync() { throw null; }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.ValueTask WaitForEnvironment() { throw null; }
    }
    public enum RecordedTestMode
    {
        Live = 0,
        Record = 1,
        Playback = 2,
    }
    public partial class RecordedVariableOptions
    {
        public RecordedVariableOptions() { }
        public string Apply(string value) { throw null; }
        public Microsoft.ClientModel.TestFramework.RecordedVariableOptions IsSecret(Microsoft.ClientModel.TestFramework.SanitizedValue sanitizedValue = Microsoft.ClientModel.TestFramework.SanitizedValue.Default) { throw null; }
        public Microsoft.ClientModel.TestFramework.RecordedVariableOptions IsSecret(string sanitizedValue) { throw null; }
    }
    public partial class RecordEntryMessage
    {
        public RecordEntryMessage() { }
        public byte[]? Body { get { throw null; } set { } }
        public System.Collections.Generic.SortedDictionary<string, string[]> Headers { get { throw null; } set { } }
        public bool IsTextContentType(out System.Text.Encoding? encoding) { throw null; }
        public bool TryGetBodyAsText(out string? text) { throw null; }
        public bool TryGetContentType(out string? contentType) { throw null; }
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
    [NUnit.Framework.TestFixtureAttribute(new object[]{ false})]
    [NUnit.Framework.TestFixtureAttribute(new object[]{ true})]
    public partial class SyncAsyncPolicyTestBase : Microsoft.ClientModel.TestFramework.SyncAsyncTestBase
    {
        public SyncAsyncPolicyTestBase(bool isAsync) : base (default(bool)) { }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineResponse> SendGetRequest(System.ClientModel.Primitives.HttpClientPipelineTransport transport, System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, System.Uri? uri = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineMessage> SendMessageGetRequest(System.ClientModel.Primitives.ClientPipeline pipeline, System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, System.Uri? uri = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineMessage> SendMessageRequestAsync(System.ClientModel.Primitives.ClientPipeline pipeline, System.Action<System.ClientModel.Primitives.PipelineMessage> messageAction, bool bufferResponse = true, System.ClientModel.Primitives.PipelineMessage? message = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineResponse> SendRequestAsync(System.ClientModel.Primitives.ClientPipeline pipeline, System.Action<System.ClientModel.Primitives.PipelineMessage> messageAction, bool bufferResponse = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineResponse> SendRequestAsync(System.ClientModel.Primitives.ClientPipeline pipeline, System.Action<System.ClientModel.Primitives.PipelineRequest> requestAction, bool bufferResponse = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineResponse> SendRequestAsync(System.ClientModel.Primitives.HttpClientPipelineTransport transport, System.Action<System.ClientModel.Primitives.PipelineMessage> messageAction, System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.ClientModel.Primitives.PipelineResponse> SendRequestAsync(System.ClientModel.Primitives.HttpClientPipelineTransport transport, System.Action<System.ClientModel.Primitives.PipelineRequest> requestAction, System.ClientModel.Primitives.PipelinePolicy policy, System.ClientModel.Primitives.PipelineMessageClassifier? responseClassifier = null, bool bufferResponse = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public const string DevCertPassword = "password";
        protected TestEnvironment() { }
        public virtual System.ClientModel.AuthenticationTokenProvider Credential { get { throw null; } }
        public static string? DevCertPath { get { throw null; } protected set { } }
        public static bool IsWindows { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.RecordedTestMode? Mode { get { throw null; } set { } }
        public string? PathToTestResourceBootstrappingScript { get { throw null; } set { } }
        public static string? RepositoryRoot { get { throw null; } }
        public void BootStrapTestResources() { }
        protected string? GetOptionalVariable(string name) { throw null; }
        protected string? GetRecordedOptionalVariable(string name) { throw null; }
        protected string? GetRecordedOptionalVariable(string name, System.Action<Microsoft.ClientModel.TestFramework.RecordedVariableOptions>? options) { throw null; }
        protected string GetRecordedVariable(string name) { throw null; }
        protected string GetRecordedVariable(string name, System.Action<Microsoft.ClientModel.TestFramework.RecordedVariableOptions>? options) { throw null; }
        public static string GetSourcePath(System.Reflection.Assembly assembly) { throw null; }
        protected string GetVariable(string name) { throw null; }
        public abstract System.Collections.Generic.Dictionary<string, string> ParseEnvironmentFile();
        public virtual void SetRecording(Microsoft.ClientModel.TestFramework.TestRecording recording) { }
        public abstract System.Threading.Tasks.Task WaitForEnvironmentAsync();
    }
    public partial class TestEnvVar : Microsoft.ClientModel.TestFramework.DisposableConfig
    {
        public TestEnvVar(System.Collections.Generic.Dictionary<string, string> values) : base (default(string), default(string), default(System.Threading.SemaphoreSlim)) { }
        public TestEnvVar(string name, string value) : base (default(string), default(string), default(System.Threading.SemaphoreSlim)) { }
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
        public virtual System.Threading.Tasks.Task CheckProxyOutputAsync() { throw null; }
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
        public Microsoft.ClientModel.TestFramework.RecordedTestMode Mode { get { throw null; } }
        public System.DateTimeOffset Now { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.TestRandom Random { get { throw null; } }
        public string? RecordingId { get { throw null; } }
        public System.DateTimeOffset UtcNow { get { throw null; } }
        public System.Collections.Generic.SortedDictionary<string, string> Variables { get { throw null; } }
        public static System.Threading.Tasks.Task<Microsoft.ClientModel.TestFramework.TestRecording> CreateAsync(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, string sessionFile, Microsoft.ClientModel.TestFramework.TestProxyProcess? proxy, Microsoft.ClientModel.TestFramework.RecordedTestBase recordedTestBase, System.Threading.CancellationToken? cancellationToken = default(System.Threading.CancellationToken?)) { throw null; }
        public virtual System.ClientModel.Primitives.PipelineTransport? CreateTransport(System.ClientModel.Primitives.PipelineTransport? currentTransport) { throw null; }
        public virtual Microsoft.ClientModel.TestFramework.TestRecording.DisableRecordingScope DisableRecording() { throw null; }
        public virtual Microsoft.ClientModel.TestFramework.TestRecording.DisableRecordingScope DisableRequestBodyRecording() { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync(bool save) { throw null; }
        public virtual string GenerateAlphaNumericId(string prefix, int? maxLength = default(int?), bool useOnlyLowercase = false) { throw null; }
        public virtual string GenerateAssetName(string prefix, [System.Runtime.CompilerServices.CallerMemberNameAttribute] string callerMethodName = "testframework_failed") { throw null; }
        public virtual string GenerateId() { throw null; }
        public virtual string GenerateId(string prefix, int maxLength) { throw null; }
        public virtual string? GetVariable(string variableName, string defaultValue, System.Func<string, string>? sanitizer = null) { throw null; }
        public virtual void SetVariable(string variableName, string? value, System.Func<string, string>? sanitizer = null) { }
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
    public partial class TestRetryHelper
    {
        public TestRetryHelper(bool noWait) { }
        public System.Threading.Tasks.Task<T> RetryAsync<T>(System.Func<System.Threading.Tasks.Task<T>> operation, int maxIterations = 20, System.TimeSpan delay = default(System.TimeSpan)) { throw null; }
    }
    public partial class TestTimeoutException : System.Exception
    {
        public TestTimeoutException() { }
        public TestTimeoutException(string message) { }
        public TestTimeoutException(string message, System.Exception innerException) { }
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
        public bool IsDisposed { get { throw null; } }
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
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.BodyKeySanitizer bodyKeySanitizer) { throw null; }
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
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer bodyRegexSanitizer) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.BodyRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public HeaderRegexSanitizer(string key) { }
        public string GroupForReplace { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.HeaderRegexSanitizer headerRegexSanitizer) { throw null; }
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
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.HeaderTransform headerTransform) { throw null; }
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
    public partial class TestProxyClient
    {
        protected TestProxyClient() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult AddTransform(string transformType, System.BinaryData transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult AddTransform(string transformType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddTransformAsync(string transformType, System.BinaryData transform, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddTransformAsync(string transformType, System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult RemoveSanitizers(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove sanitizers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult RemoveSanitizers(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> RemoveSanitizersAsync(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.SanitizersToRemove sanitizers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> RemoveSanitizersAsync(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingTransportOptions(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions proxyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingTransportOptions(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingTransportOptionsAsync(string recordingId, Microsoft.ClientModel.TestFramework.TestProxy.ProxyOptions proxyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingTransportOptionsAsync(string recordingId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.Generic.IReadOnlyDictionary<string, string>> StartPlayback(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartPlayback(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.Generic.IReadOnlyDictionary<string, string>>> StartPlaybackAsync(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartPlaybackAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult StartRecord(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartRecord(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartRecordAsync(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartRecordAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult StopPlayback(string recordingId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult StopPlayback(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopPlaybackAsync(string recordingId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopPlaybackAsync(string recordingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StopRecord(string recordingId, System.ClientModel.BinaryContent content, string recordingSkip = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult StopRecord(string recordingId, System.Collections.Generic.IDictionary<string, string> variables, string recordingSkip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopRecordAsync(string recordingId, System.ClientModel.BinaryContent content, string recordingSkip = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopRecordAsync(string recordingId, System.Collections.Generic.IDictionary<string, string> variables, string recordingSkip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TestProxyClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public TestProxyClientOptions() { }
    }
    public partial class TestProxyStartInformation : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>
    {
        public TestProxyStartInformation(string xRecordingFile) { }
        public string XRecordingAssetsFiles { get { throw null; } set { } }
        public string XRecordingFile { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation testProxyStartInformation) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriRegexSanitizer : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>
    {
        public UriRegexSanitizer(string regex) { }
        public string GroupForReplace { get { throw null; } set { } }
        public string Regex { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer uriRegexSanitizer) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.UriRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
