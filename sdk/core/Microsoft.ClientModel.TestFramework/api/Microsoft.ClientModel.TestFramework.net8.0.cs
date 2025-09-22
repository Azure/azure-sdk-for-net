namespace Microsoft.ClientModel.TestFramework
{
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
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition ApplyCondition(string uriRegex = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer BodyKeySanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody BodyKeySanitizerBody(string jsonPath = null, string value = null, string regex = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer BodyRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody BodyRegexSanitizerBody(string value = null, string regex = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer BodyStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody BodyStringSanitizerBody(string target = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher CustomDefaultMatcher(bool? compareBodies = default(bool?), string excludedHeaders = null, string ignoredHeaders = null, bool? ignoreQueryOrdering = default(bool?), string ignoredQueryParameters = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer GeneralRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody GeneralRegexSanitizerBody(string value = null, string regex = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer GeneralStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody GeneralStringSanitizerBody(string target = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer HeaderRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody HeaderRegexSanitizerBody(string key = null, string value = null, string regex = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer HeaderStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody HeaderStringSanitizerBody(string key = null, string target = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer OAuthResponseSanitizer() { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions RecordingOptions(bool? handleRedirects = default(bool?), string contextDirectory = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.StoreType? assetsStore = default(Microsoft.ClientModel.TestFramework.TestProxy.Admin.StoreType?), Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations transport = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer RegexEntrySanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody RegexEntrySanitizerBody(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntryValues target = Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntryValues.Body, string regex = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers RemovedSanitizers(System.Collections.Generic.IEnumerable<string> removed = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer RemoveHeaderSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody RemoveHeaderSanitizerBody(string headersForRemoval = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition SanitizerAddition(string name = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList SanitizerList(System.Collections.Generic.IEnumerable<string> sanitizers = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate TestProxyCertificate(string pemValue = null, string pemKey = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation TestProxyStartInformation(string xRecordingFile = null, string xRecordingAssetsFile = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations TransportCustomizations(bool? allowAutoRedirect = default(bool?), string tlsValidationCert = null, string tlsValidationCertHost = null, System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate> certificates = null, int? playbackResponseTime = default(int?)) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer UriRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody UriRegexSanitizerBody(string value = null, string regex = null, string groupForReplace = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer UriStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody UriStringSanitizerBody(string target = null, string value = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer UriSubscriptionIdSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody body = null) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody UriSubscriptionIdSanitizerBody(string value = null, Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition condition = null) { throw null; }
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
        public System.Collections.Generic.HashSet<string> IgnoredHeaders;
        public System.Collections.Generic.HashSet<string> IgnoredQueryParameters;
        public const string SanitizeValue = "Sanitized";
        protected RecordedTestBase(bool isAsync, Microsoft.ClientModel.TestFramework.RecordedTestMode? mode = default(Microsoft.ClientModel.TestFramework.RecordedTestMode?)) : base (default(bool)) { }
        public virtual string? AssetsJsonPath { get { throw null; } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer> BodyKeySanitizers { get { throw null; } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer> BodyRegexSanitizers { get { throw null; } }
        public bool CompareBodies { get { throw null; } set { } }
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer> HeaderRegexSanitizers { get { throw null; } }
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
        public virtual System.Collections.Generic.List<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer> UriRegexSanitizers { get { throw null; } }
        protected bool UseLocalDebugProxy { get { throw null; } set { } }
        protected bool ValidateClientInstrumentation { get { throw null; } set { } }
        protected internal override object CreateProxyFromClient(System.Type clientType, object client, System.Collections.Generic.IEnumerable<Castle.DynamicProxy.IInterceptor>? preInterceptors) { throw null; }
        protected System.Threading.Tasks.Task<Microsoft.ClientModel.TestFramework.TestRecording> CreateTestRecordingAsync(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, string sessionFile) { throw null; }
        public static System.Threading.Tasks.Task Delay(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        public System.Threading.Tasks.Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = default(int?)) { throw null; }
        protected internal string GetSessionFilePath() { throw null; }
        public override void GlobalTimeoutTearDown() { }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public void InitializeRecordedTestClass() { }
        public T InstrumentClientOptions<T>(T clientOptions, Microsoft.ClientModel.TestFramework.TestRecording? recording = null) where T : System.ClientModel.Primitives.ClientPipelineOptions { throw null; }
        protected System.Threading.Tasks.Task SetProxyOptionsAsync(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions options) { throw null; }
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
    public static partial class TaskExtensions
    {
        public static System.TimeSpan DefaultTimeout { get { throw null; } }
        public static Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationTaskAwaitable AwaitWithCancellation(this System.Threading.Tasks.Task task, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationTaskAwaitable<T> AwaitWithCancellation<T>(this System.Threading.Tasks.Task<T> task, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationValueTaskAwaitable<T> AwaitWithCancellation<T>(this System.Threading.Tasks.ValueTask<T> task, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable EnsureCompleted(this System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable awaitable, bool async) { throw null; }
        public static void EnsureCompleted(this System.Threading.Tasks.Task task) { }
        public static void EnsureCompleted(this System.Threading.Tasks.ValueTask task) { }
        public static System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<T> EnsureCompleted<T>(this System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<T> awaitable, bool async) { throw null; }
        public static T EnsureCompleted<T>(this System.Threading.Tasks.Task<T> task) { throw null; }
        public static T EnsureCompleted<T>(this System.Threading.Tasks.ValueTask<T> task) { throw null; }
        public static Microsoft.ClientModel.TestFramework.TaskExtensions.Enumerable<T> EnsureSyncEnumerable<T>(this System.Collections.Generic.IAsyncEnumerable<T> asyncEnumerable) { throw null; }
        public static object? GetResultFromTask(object returnValue) { throw null; }
        public static object? GetValueFromTask(System.Type taskResultType, object instrumentedResult) { throw null; }
        public static bool? IsTaskFaulted(object taskObj) { throw null; }
        public static bool IsTaskType(System.Type type) { throw null; }
        public static System.Threading.Tasks.Task TimeoutAfter(this System.Threading.Tasks.Task task, System.TimeSpan timeout, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.ValueTask TimeoutAfter(this System.Threading.Tasks.ValueTask task, System.TimeSpan timeout, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.Task TimeoutAfterDefault(this System.Threading.Tasks.Task task, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.ValueTask TimeoutAfterDefault(this System.Threading.Tasks.ValueTask task, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.Task<T> TimeoutAfterDefault<T>(this System.Threading.Tasks.Task<T> task, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.ValueTask<T> TimeoutAfterDefault<T>(this System.Threading.Tasks.ValueTask<T> task, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.Task<T> TimeoutAfter<T>(this System.Threading.Tasks.Task<T> task, System.TimeSpan timeout, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        public static System.Threading.Tasks.ValueTask<T> TimeoutAfter<T>(this System.Threading.Tasks.ValueTask<T> task, System.TimeSpan timeout, [System.Runtime.CompilerServices.CallerFilePathAttribute] string? filePath = null, [System.Runtime.CompilerServices.CallerLineNumberAttribute] int lineNumber = 0) { throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct Enumerable<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public Enumerable(System.Collections.Generic.IAsyncEnumerable<T> asyncEnumerable) { throw null; }
            public Microsoft.ClientModel.TestFramework.TaskExtensions.Enumerator<T> GetEnumerator() { throw null; }
            System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct Enumerator<T> : System.Collections.Generic.IEnumerator<T>, System.Collections.IEnumerator, System.IDisposable
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public Enumerator(System.Collections.Generic.IAsyncEnumerator<T> asyncEnumerator) { throw null; }
            public T Current { get { throw null; } }
            object? System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public bool MoveNext() { throw null; }
            public void Reset() { }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationTaskAwaitable
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationTaskAwaitable(System.Threading.Tasks.Task task, System.Threading.CancellationToken cancellationToken) { throw null; }
            public Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationTaskAwaiter GetAwaiter() { throw null; }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationTaskAwaitable<T>
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationTaskAwaitable(System.Threading.Tasks.Task<T> task, System.Threading.CancellationToken cancellationToken) { throw null; }
            public Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationTaskAwaiter<T> GetAwaiter() { throw null; }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationTaskAwaiter : System.Runtime.CompilerServices.ICriticalNotifyCompletion, System.Runtime.CompilerServices.INotifyCompletion
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationTaskAwaiter(System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter, System.Threading.CancellationToken cancellationToken) { throw null; }
            public bool IsCompleted { get { throw null; } }
            public void GetResult() { }
            public void OnCompleted(System.Action continuation) { }
            public void UnsafeOnCompleted(System.Action continuation) { }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationTaskAwaiter<T> : System.Runtime.CompilerServices.ICriticalNotifyCompletion, System.Runtime.CompilerServices.INotifyCompletion
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationTaskAwaiter(System.Runtime.CompilerServices.ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter awaiter, System.Threading.CancellationToken cancellationToken) { throw null; }
            public bool IsCompleted { get { throw null; } }
            public T GetResult() { throw null; }
            public void OnCompleted(System.Action continuation) { }
            public void UnsafeOnCompleted(System.Action continuation) { }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationValueTaskAwaitable<T>
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationValueTaskAwaitable(System.Threading.Tasks.ValueTask<T> task, System.Threading.CancellationToken cancellationToken) { throw null; }
            public Microsoft.ClientModel.TestFramework.TaskExtensions.WithCancellationValueTaskAwaiter<T> GetAwaiter() { throw null; }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public readonly partial struct WithCancellationValueTaskAwaiter<T> : System.Runtime.CompilerServices.ICriticalNotifyCompletion, System.Runtime.CompilerServices.INotifyCompletion
        {
            private readonly object _dummy;
            private readonly int _dummyPrimitive;
            public WithCancellationValueTaskAwaiter(System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<T>.ConfiguredValueTaskAwaiter awaiter, System.Threading.CancellationToken cancellationToken) { throw null; }
            public bool IsCompleted { get { throw null; } }
            public T GetResult() { throw null; }
            public void OnCompleted(System.Action continuation) { }
            public void UnsafeOnCompleted(System.Action continuation) { }
        }
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
        public Microsoft.ClientModel.TestFramework.Mocks.MockPipelineResponse WithContent(System.ClientModel.BinaryContent content) { throw null; }
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
    public partial class TestProxyClient
    {
        public TestProxyClient() { }
        public TestProxyClient(System.Uri endpoint, Microsoft.ClientModel.TestFramework.TestProxy.TestProxyClientOptions options) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyAdminClient GetTestProxyAdminClient() { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.Generic.IReadOnlyDictionary<string, string>> StartPlayback(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartPlayback(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.Generic.IReadOnlyDictionary<string, string>>> StartPlaybackAsync(Microsoft.ClientModel.TestFramework.TestProxy.TestProxyStartInformation body, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartPlaybackAsync(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
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
        public string XRecordingAssetsFile { get { throw null; } set { } }
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
}
namespace Microsoft.ClientModel.TestFramework.TestProxy.Admin
{
    public partial class ApplyCondition : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>
    {
        public ApplyCondition(string uriRegex) { }
        public string UriRegex { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyKeySanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>
    {
        public BodyKeySanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyKeySanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>
    {
        public BodyKeySanitizerBody(string jsonPath) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string JsonPath { get { throw null; } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyKeySanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyRegexSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>
    {
        public BodyRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyRegexSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>
    {
        public BodyRegexSanitizerBody() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyRegexSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyStringSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>
    {
        public BodyStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BodyStringSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>
    {
        public BodyStringSanitizerBody(string target) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string Target { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.BodyStringSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomDefaultMatcher : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>
    {
        public CustomDefaultMatcher() { }
        public bool? CompareBodies { get { throw null; } set { } }
        public string ExcludedHeaders { get { throw null; } set { } }
        public string IgnoredHeaders { get { throw null; } set { } }
        public string IgnoredQueryParameters { get { throw null; } set { } }
        public bool? IgnoreQueryOrdering { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher customDefaultMatcher) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralRegexSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>
    {
        public GeneralRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralRegexSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>
    {
        public GeneralRegexSanitizerBody() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralRegexSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralStringSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>
    {
        public GeneralStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralStringSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>
    {
        public GeneralStringSanitizerBody(string target) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string Target { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.GeneralStringSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderRegexSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>
    {
        public HeaderRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody Body { get { throw null; } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer CreateWithQueryParameter(string headerKey, string queryParameter, string sanitizedValue) { throw null; }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderRegexSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>
    {
        public HeaderRegexSanitizerBody(string key) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderRegexSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderStringSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>
    {
        public HeaderStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderStringSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>
    {
        public HeaderStringSanitizerBody(string key, string target) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Target { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.HeaderStringSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MatcherType
    {
        BodilessMatcher = 0,
        CustomDefaultMatcher = 1,
        HeaderlessMatcher = 2,
    }
    public partial class OAuthResponseSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>
    {
        public OAuthResponseSanitizer() { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.OAuthResponseSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecordingOptions : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>
    {
        public RecordingOptions() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.StoreType? AssetsStore { get { throw null; } set { } }
        public string ContextDirectory { get { throw null; } set { } }
        public bool? HandleRedirects { get { throw null; } set { } }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations Transport { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions recordingOptions) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegexEntrySanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>
    {
        public RegexEntrySanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegexEntrySanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>
    {
        public RegexEntrySanitizerBody(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntryValues target, string regex) { }
        public string Regex { get { throw null; } }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntryValues Target { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RegexEntrySanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RegexEntryValues
    {
        Body = 0,
        Header = 1,
        Uri = 2,
    }
    public partial class RemovedSanitizers : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>
    {
        internal RemovedSanitizers() { }
        public System.Collections.Generic.IList<string> Removed { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoveHeaderSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>
    {
        public RemoveHeaderSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoveHeaderSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>
    {
        public RemoveHeaderSanitizerBody(string headersForRemoval) { }
        public string HeadersForRemoval { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemoveHeaderSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SanitizerAddition : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>
    {
        internal SanitizerAddition() { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SanitizerList : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>
    {
        public SanitizerList(System.Collections.Generic.IEnumerable<string> sanitizers) { }
        public System.Collections.Generic.IList<string> Sanitizers { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList sanitizerList) { throw null; }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StoreType
    {
        GitStore = 0,
    }
    public partial class TestProxyAdminClient
    {
        protected TestProxyAdminClient() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult AddSanitizers(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult AddSanitizers(System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition> sanitizers, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddSanitizersAsync(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> AddSanitizersAsync(System.Collections.Generic.IEnumerable<Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition> sanitizers, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers> RemoveSanitizers(Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList sanitizers, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult RemoveSanitizers(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Microsoft.ClientModel.TestFramework.TestProxy.Admin.RemovedSanitizers>> RemoveSanitizersAsync(Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerList sanitizers, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> RemoveSanitizersAsync(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult SetMatcher(Microsoft.ClientModel.TestFramework.TestProxy.Admin.MatcherType matcherType, Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher matcher = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SetMatcher(string matcherType, System.ClientModel.BinaryContent content = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetMatcherAsync(Microsoft.ClientModel.TestFramework.TestProxy.Admin.MatcherType matcherType, Microsoft.ClientModel.TestFramework.TestProxy.Admin.CustomDefaultMatcher matcher = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetMatcherAsync(string matcherType, System.ClientModel.BinaryContent content = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingOptions(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions body, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SetRecordingOptions(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingOptionsAsync(Microsoft.ClientModel.TestFramework.TestProxy.Admin.RecordingOptions body, string recordingId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SetRecordingOptionsAsync(System.ClientModel.BinaryContent content, string recordingId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class TestProxyCertificate : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>
    {
        public TestProxyCertificate(string pemValue, string pemKey) { }
        public string PemKey { get { throw null; } }
        public string PemValue { get { throw null; } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportCustomizations : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>
    {
        public TransportCustomizations() { }
        public bool? AllowAutoRedirect { get { throw null; } set { } }
        public System.Collections.Generic.IList<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TestProxyCertificate> Certificates { get { throw null; } }
        public int? PlaybackResponseTime { get { throw null; } set { } }
        public string TLSValidationCert { get { throw null; } set { } }
        public string TLSValidationCertHost { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.TransportCustomizations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriRegexSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>
    {
        public UriRegexSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody Body { get { throw null; } }
        public static Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer CreateWithQueryParameter(string queryParameter, string sanitizedValue) { throw null; }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriRegexSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>
    {
        public UriRegexSanitizerBody() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string GroupForReplace { get { throw null; } set { } }
        public string Regex { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriRegexSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriStringSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>
    {
        public UriStringSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriStringSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>
    {
        public UriStringSanitizerBody(string target) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string Target { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriStringSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriSubscriptionIdSanitizer : Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition, System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>
    {
        public UriSubscriptionIdSanitizer(Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody body) { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody Body { get { throw null; } }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Microsoft.ClientModel.TestFramework.TestProxy.Admin.SanitizerAddition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriSubscriptionIdSanitizerBody : System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>, System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>
    {
        public UriSubscriptionIdSanitizerBody() { }
        public Microsoft.ClientModel.TestFramework.TestProxy.Admin.ApplyCondition Condition { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Microsoft.ClientModel.TestFramework.TestProxy.Admin.UriSubscriptionIdSanitizerBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
