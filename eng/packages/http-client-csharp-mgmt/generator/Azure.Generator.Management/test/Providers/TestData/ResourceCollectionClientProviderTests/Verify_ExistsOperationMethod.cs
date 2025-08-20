using global::Azure.Core.Pipeline.DiagnosticScope scope = _responsetypeClientDiagnostics.CreateScope("ResponseTypeCollection.Exists");
scope.Start();
try
{
    global::Azure.RequestContext context = new global::Azure.RequestContext
    {
        CancellationToken = cancellationToken
    }
    ;
    global::Azure.Core.HttpMessage message = _responsetypeRestClient.CreateGetRequest(this.Id.Name, context);
    global::Azure.Response result = this.Pipeline.ProcessMessage(message, context);
    global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(((global::Samples.Models.ResponseTypeData)result), result);
    return global::Azure.Response.FromValue((response.Value != null), response.GetRawResponse());
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
