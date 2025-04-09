_responsetypeClientDiagnostics = new global::Azure.Core.Pipeline.ClientDiagnostics("Samples", ResourceType.Namespace, this.Diagnostics);
this.TryGetApiVersion(ResourceType, out string responsetypeApiVersion);
_responsetypeRestClient = new global::Samples.TestClient(this.Pipeline, this.Endpoint, responsetypeApiVersion);
global::Samples.ResponseTypeResource.ValidateResourceId(id);
