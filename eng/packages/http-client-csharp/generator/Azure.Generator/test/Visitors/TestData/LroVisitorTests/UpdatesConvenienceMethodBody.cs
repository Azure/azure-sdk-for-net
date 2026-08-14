using global::Azure.Core.RequestContent content = global::Azure.Core.RequestContent.Create(global::System.BinaryData.FromString(p1));
return global::Azure.Core.ProtocolOperationHelpers.Convert(this.Foo(waitUntil, content, cancellationToken.ToRequestContext()), response => ((global::Samples.Models.Foo)response), ClientDiagnostics, "TestClient.Foo");
