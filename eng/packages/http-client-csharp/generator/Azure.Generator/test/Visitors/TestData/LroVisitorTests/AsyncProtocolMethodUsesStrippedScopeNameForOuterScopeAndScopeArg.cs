using global::Azure.Core.Pipeline.DiagnosticScope scope = ClientDiagnostics.CreateScope("TestClient.Foo");
scope.Start();
try
{
    using global::Azure.Core.HttpMessage message = this.CreateFooRequest(content, context);
    return await global::Azure.Core.ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "TestClient.Foo", global::Azure.Core.OperationFinalStateVia.Location, context, waitUntil).ConfigureAwait(false);
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
