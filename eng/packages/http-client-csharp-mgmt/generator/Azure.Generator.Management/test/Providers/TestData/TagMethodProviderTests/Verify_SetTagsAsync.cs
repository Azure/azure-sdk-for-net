global::Samples.Argument.AssertNotNull(tags, nameof(tags));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeResource.SetTags");
scope.Start();
try
{
    if (await this.CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
    {
        await this.GetTagResource().DeleteAsync(global::Azure.WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
        global::Azure.Response<global::Azure.ResourceManager.Resources.TagResource> originalTags = await this.GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
        originalTags.Value.Data.TagValues.ReplaceWith(tags);
        await this.GetTagResource().CreateOrUpdateAsync(global::Azure.WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
        global::Azure.RequestContext context = new global::Azure.RequestContext
        {
            CancellationToken = cancellationToken
        };
        global::Azure.Core.HttpMessage message = _testClientRestClient.CreateGetRequest(global::System.Guid.Parse(this.Id.SubscriptionId), this.Id.ResourceGroupName, this.Id.Name, context);
        global::Azure.Response result = await this.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
        global::Azure.Response<global::Samples.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.ResponseTypeData.FromResponse(result), result);
        return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
    }
    else
    {
        global::Samples.ResponseTypeData current = (await this.GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
        global::Samples.ResponseTypeData patch = new global::Samples.ResponseTypeData();
        patch.Tags.ReplaceWith(tags);
        global::Azure.Response<global::Samples.ResponseTypeResource> result = await this.UpdateAsync(patch, cancellationToken).ConfigureAwait(false);
        return global::Azure.Response.FromValue(result.Value, result.GetRawResponse());
    }
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
