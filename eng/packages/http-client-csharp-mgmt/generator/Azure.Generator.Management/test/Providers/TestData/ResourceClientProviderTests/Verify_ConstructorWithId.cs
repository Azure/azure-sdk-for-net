this.TryGetApiVersion(ResourceType, out string responseTypeApiVersion);
_testClientClientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics("Samples", ResourceType.Namespace, this.Diagnostics);
_testClientRestClient = new global::Samples.TestClient(_testClientClientDiagnostics, this.Pipeline, this.Endpoint, (responseTypeApiVersion ?? "2023-01-01"));
global::Samples.ResponseTypeResource.ValidateResourceId(id);
