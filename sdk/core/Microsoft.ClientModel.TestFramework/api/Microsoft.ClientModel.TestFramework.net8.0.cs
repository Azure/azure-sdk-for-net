public partial class ProxyTransport : System.ClientModel.Primitives.PipelineTransport
{
    public ProxyTransport() { }
    protected override System.ClientModel.Primitives.PipelineMessage CreateMessageCore() { throw null; }
    protected override void ProcessCore(System.ClientModel.Primitives.PipelineMessage message) { }
    protected override System.Threading.Tasks.ValueTask ProcessCoreAsync(System.ClientModel.Primitives.PipelineMessage message) { throw null; }
}
namespace Microsoft.ClientModel.TestFramework
{
    public enum EntryRecordModel
    {
        Record = 0,
        DoNotRecord = 1,
        RecordWithoutRequestBody = 2,
    }
    public partial class MicrosoftClientModelTestFrameworkContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal MicrosoftClientModelTestFrameworkContext() { }
        public static Microsoft.ClientModel.TestFramework.MicrosoftClientModelTestFrameworkContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public enum RecordedTestMode
    {
        Live = 0,
        Record = 1,
        Playback = 2,
    }
    public enum SanitizedValue
    {
        Default = 0,
        Base64 = 1,
    }
    public abstract partial class TestEnvironment
    {
        protected TestEnvironment() { }
    }
    public partial class TestRandom : System.Random
    {
        public TestRandom(Microsoft.ClientModel.TestFramework.RecordedTestMode mode) { }
        public TestRandom(Microsoft.ClientModel.TestFramework.RecordedTestMode mode, int seed) { }
        public System.Guid NewGuid() { throw null; }
    }
    public partial class TestRecording
    {
        public TestRecording() { }
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
    public partial class TestProxy
    {
        public TestProxy() { }
    }
    public partial class TestProxyClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public TestProxyClientOptions() { }
    }
    public partial class TestRecordingMismatchException : System.Exception
    {
        public TestRecordingMismatchException() { }
        public TestRecordingMismatchException(string message) { }
        public TestRecordingMismatchException(string message, System.Exception innerException) { }
    }
}
