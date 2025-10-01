global::Samples.Argument.AssertNotNullOrEmpty(testName, nameof(testName));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeCollection.Exists");
scope.Start();
try
{
    global::Azure.RequestContext context = new global::Azure.RequestContext
    {
        CancellationToken = cancellationToken
    };
    global::Azure.Core.HttpMessage message = _testClientRestClient.CreateGetRequest(global::System.Guid.Parse(this.Id.SubscriptionId), this.Id.ResourceGroupName, testName, context);
    await this.Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
    global::Azure.Response result = message.Response;
    global::Azure.Response<global::Samples.Models.ResponseTypeData> response = default;
    switch (result.Status)
    {
        case 200:
            response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
            break;
        case 404:
            response = global::Azure.Response.FromValue(((global::Samples.Models.ResponseTypeData)null), result);
            break;
        default:
            throw new global::Azure.RequestFailedException(result);
    }
    return global::Azure.Response.FromValue((response.Value != null), response.GetRawResponse());
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
