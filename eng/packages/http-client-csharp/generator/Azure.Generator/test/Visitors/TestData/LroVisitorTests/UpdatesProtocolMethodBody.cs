using global::Azure.Core.HttpMessage message = this.CreateFooRequest(content, context);
message.BufferResponse = false;
return global::Azure.Core.ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "TestClient.Foo", global::Azure.Core.OperationFinalStateVia.Location, context, waitUntil);
