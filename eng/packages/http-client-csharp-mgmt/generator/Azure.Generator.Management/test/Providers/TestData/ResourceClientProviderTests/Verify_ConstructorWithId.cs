_responseTypeClientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics("Samples", ResourceType.Namespace, this.Diagnostics);
this.TryGetApiVersion(ResourceType, out string responseTypeApiVersion);
_testClientRestClient = new global::Samples.TestClient(_responseTypeClientDiagnostics, this.Pipeline, this.Endpoint, responseTypeApiVersion);
global::Samples.ResponseTypeResource.ValidateResourceId(id);
