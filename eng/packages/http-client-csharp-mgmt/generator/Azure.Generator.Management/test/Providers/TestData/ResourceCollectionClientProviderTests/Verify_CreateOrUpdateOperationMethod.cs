using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeCollection.CreateOrUpdate");
scope.Start();
try
{
    global::Azure.RequestContext context = new global::Azure.RequestContext
    {
        CancellationToken = cancellationToken
    }
    ;
    global::Azure.Core.HttpMessage message = _testClientRestClient.CreateCreateTestRequest(testName, global::System.Guid.Parse(this.Id.SubscriptionId), global::Samples.Models.ResponseTypeData.ToRequestContent(data), context);
    global::Azure.Response result = this.Pipeline.ProcessMessage(message, context);
    global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
    if ((response.Value == null))
    {
        throw new global::Azure.RequestFailedException(response.GetRawResponse());
    }
    return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
