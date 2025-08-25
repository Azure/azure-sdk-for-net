global::Samples.Argument.AssertNotNullOrEmpty(testName, nameof(testName));
global::Samples.Argument.AssertNotNull(data, nameof(data));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeCollection.CreateOrUpdate");
scope.Start();
try
{
    global::Azure.RequestContext context = new global::Azure.RequestContext
    {
        CancellationToken = cancellationToken
    };
    global::Azure.Core.HttpMessage message = _testClientRestClient.CreateCreateTestRequest(global::System.Guid.Parse(this.Id.SubscriptionId), this.Id.ResourceGroupName, testName, global::Samples.Models.ResponseTypeData.ToRequestContent(data), context);
    global::Azure.Response result = await this.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
    global::Azure.Core.RequestUriBuilder uri = message.Request.Uri;
    global::Azure.Core.RehydrationToken rehydrationToken = global::Azure.Core.NextLinkOperationImplementation.GetRehydrationToken(global::Azure.Core.RequestMethod.Get, uri.ToUri(), uri.ToString(), "None", null, global::Azure.Core.OperationFinalStateVia.OriginalUri.ToString());
    global::Samples.SamplesArmOperation<global::Samples.ResponseTypeResource> operation = new global::Samples.SamplesArmOperation<global::Samples.ResponseTypeResource>(global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse()), rehydrationToken);
    if ((waitUntil == global::Azure.WaitUntil.Completed))
    {
        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
    }
    return operation;
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
