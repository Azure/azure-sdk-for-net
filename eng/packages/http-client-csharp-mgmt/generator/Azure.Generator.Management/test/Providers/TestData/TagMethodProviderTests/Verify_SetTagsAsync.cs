global::Samples.Argument.AssertNotNull(tags, nameof(tags));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _responsetypeClientDiagnostics.CreateScope("ResponseTypeResource.SetTags");
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
        }
        ;
        global::Azure.Core.HttpMessage message = _responsetypeRestClient.CreateGetRequest(this.Id.Name, global::System.Guid.Parse(this.Id.SubscriptionId), context);
        global::Azure.Response result = await this.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
        global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
        return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
    }
    else
    {
        global::Samples.Models.ResponseTypeData current = (await this.GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
        current.Tags.ReplaceWith(tags);
        global::Azure.ResourceManager.ArmOperation<global::Samples.ResponseTypeResource> result = await this.UpdateAsync(global::Azure.WaitUntil.Completed, current, cancellationToken).ConfigureAwait(false);
        return global::Azure.Response.FromValue(result.Value, result.GetRawResponse());
    }
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
