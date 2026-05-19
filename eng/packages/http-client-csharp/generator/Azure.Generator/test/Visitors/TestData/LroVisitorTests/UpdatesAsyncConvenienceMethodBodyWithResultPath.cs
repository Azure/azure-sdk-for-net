using global::Azure.Core.RequestContent content = global::Azure.Core.RequestContent.Create(global::System.BinaryData.FromString(p1));
global::Azure.Operation<global::System.BinaryData> result = await this.FooAsync(waitUntil, content, cancellationToken.ToRequestContext()).ConfigureAwait(false);
return global::Azure.Core.ProtocolOperationHelpers.Convert(result, response => global::Samples.Models.Foo.FromLroResponse(response), ClientDiagnostics, "TestClient.FooAsync");
