if ((requestConditions?.IfMatch != null))
{
    throw new global::System.ArgumentException("Service does not support the If-Match header for this operation.");
}
if ((requestConditions?.IfUnmodifiedSince != null))
{
    throw new global::System.ArgumentException("Service does not support the If-Unmodified-Since header for this operation.");
}

using global::Azure.Core.HttpMessage message = this.CreateFooRequest(requestConditions, context);
message.BufferResponse = false;
return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
