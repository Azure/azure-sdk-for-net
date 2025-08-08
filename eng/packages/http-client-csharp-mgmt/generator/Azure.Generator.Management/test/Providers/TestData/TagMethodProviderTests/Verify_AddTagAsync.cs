global::Samples.Argument.AssertNotNull(key, nameof(key));
global::Samples.Argument.AssertNotNull(value, nameof(value));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _testClientClientDiagnostics.CreateScope("ResponseTypeResource.AddTag");
scope.Start();
try
{
    if (await this.CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
    {
        global::Azure.Response<global::Azure.ResourceManager.Resources.TagResource> originalTags = await this.GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
        originalTags.Value.Data.TagValues[key] = value;
        await this.GetTagResource().CreateOrUpdateAsync(global::Azure.WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
        global::Azure.RequestContext context = new global::Azure.RequestContext
        {
            CancellationToken = cancellationToken
        };
        global::Azure.Core.HttpMessage message = _testClientRestClient.CreateGetRequest(this.Id.Name, global::System.Guid.Parse(this.Id.SubscriptionId), context);
        global::Azure.Response result = await this.Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
        global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
        return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
    }
    else
    {
        global::Samples.Models.ResponseTypeData current = (await this.GetAsync(cancellationToken).ConfigureAwait(false)).Value.Data;
        global::System.Threading.CancellationToken patch = new global::System.Threading.CancellationToken();
        foreach (global::System.Collections.Generic.KeyValuePair<string, string> tag in current.Tags)
        {
            patch.Tags.Add(tag);
        }
        patch.Tags[key] = value;
        global::Azure.ResourceManager.ArmOperation<global::Samples.ResponseTypeResource> result = await this.UpdateAsync(global::Azure.WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
        return global::Azure.Response.FromValue(result.Value, result.GetRawResponse());
    }
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
