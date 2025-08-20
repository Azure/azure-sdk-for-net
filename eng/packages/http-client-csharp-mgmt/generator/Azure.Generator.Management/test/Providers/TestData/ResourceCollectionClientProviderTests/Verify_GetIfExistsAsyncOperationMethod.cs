using global::Azure.Core.Pipeline.DiagnosticScope scope = _responsetypeClientDiagnostics.CreateScope("ResponseTypeCollection.GetIfExistsAsync");
scope.Start();
try
{
    global::Azure.RequestContext context = new global::Azure.RequestContext
    {
        CancellationToken = cancellationToken
    }
    ;
    global::Azure.Core.HttpMessage message = _responsetypeRestClient.CreateGetRequest(this.Id.Name, context);
    global::Azure.Response result = await this.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(((global::Samples.Models.ResponseTypeData)result), result);
    if ((response.Value == null))
    {
        return new global::Azure.NoValueResponse<global::Samples.ResponseTypeResource>(response.GetRawResponse());
    }
    return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
