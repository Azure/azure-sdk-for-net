global::Samples.Argument.AssertNotNull(tags, nameof(tags));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeResource.SetTags");
scope.Start();
try
{
    if (this.CanUseTagResource(cancellationToken))
    {
        global::Azure.ResourceManager.Resources.TagResourceData tagData = new global::Azure.ResourceManager.Resources.TagResourceData(new global::Azure.ResourceManager.Resources.Models.Tag());
        tagData.TagValues.ReplaceWith(tags);
        this.GetTagResource().CreateOrUpdate(global::Azure.WaitUntil.Completed, tagData, cancellationToken);
        global::Azure.RequestContext context = new global::Azure.RequestContext
        {
            CancellationToken = cancellationToken
        };
        global::Azure.Core.HttpMessage message = _testClientRestClient.CreateGetRequest(global::System.Guid.Parse(this.Id.SubscriptionId), this.Id.ResourceGroupName, this.Id.Name, context);
        global::Azure.Response result = this.Pipeline.ProcessMessage(message, context);
        global::Azure.Response<global::Samples.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.ResponseTypeData.FromResponse(result), result);
        return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
    }
    else
    {
        global::Samples.ResponseTypeData current = (this.Get(cancellationToken: cancellationToken)).Value.Data;
        global::Samples.ResponseTypeData patch = new global::Samples.ResponseTypeData();
        patch.Tags.ReplaceWith(tags);
        global::Azure.Response<global::Samples.ResponseTypeResource> result = this.Update(patch, cancellationToken: cancellationToken);
        return global::Azure.Response.FromValue(result.Value, result.GetRawResponse());
    }
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
