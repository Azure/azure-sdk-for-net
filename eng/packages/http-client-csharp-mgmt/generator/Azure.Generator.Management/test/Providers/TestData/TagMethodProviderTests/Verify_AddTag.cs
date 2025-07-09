global::Samples.Argument.AssertNotNull(key, nameof(key));
global::Samples.Argument.AssertNotNull(value, nameof(value));

using global::Azure.Core.Pipeline.DiagnosticScope scope = _responsetypeClientDiagnostics.CreateScope("ResponseTypeResource.AddTag");
scope.Start();
try
{
    if (this.CanUseTagResource(cancellationToken))
    {
        global::Azure.Response<global::Azure.ResourceManager.Resources.TagResource> originalTags = this.GetTagResource().Get(cancellationToken);
        originalTags.Value.Data.TagValues[key] = value;
        this.GetTagResource().CreateOrUpdate(global::Azure.WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
        global::Azure.RequestContext context = new global::Azure.RequestContext
        {
            CancellationToken = cancellationToken
        }
        ;
        global::Azure.Core.HttpMessage message = _responsetypeRestClient.CreateGetRequest(this.Id.Name, global::System.Guid.Parse(this.Id.SubscriptionId), context);
        global::Azure.Response result = this.Pipeline.ProcessMessage(message, context);
        global::Azure.Response<global::Samples.Models.ResponseTypeData> response = global::Azure.Response.FromValue(global::Samples.Models.ResponseTypeData.FromResponse(result), result);
        return global::Azure.Response.FromValue(new global::Samples.ResponseTypeResource(this.Client, response.Value), response.GetRawResponse());
    }
    else
    {
        global::Samples.Models.ResponseTypeData current = (this.Get(cancellationToken)).Value.Data;
        current.Tags[key] = value;
        global::Azure.ResourceManager.ArmOperation<global::Samples.ResponseTypeResource> result = this.Update(global::Azure.WaitUntil.Completed, current, cancellationToken);
        return global::Azure.Response.FromValue(result.Value, result.GetRawResponse());
    }
}
catch (global::System.Exception e)
{
    scope.Failed(e);
    throw;
}
