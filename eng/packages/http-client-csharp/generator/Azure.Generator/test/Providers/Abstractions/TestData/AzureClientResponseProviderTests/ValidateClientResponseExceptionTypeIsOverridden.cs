(global::System.Threading.CancellationToken userCancellationToken, global::Azure.ErrorOptions errorOptions) = context.Parse();
pipeline.Send(message, userCancellationToken);

if ((message.Response.IsError && ((errorOptions & global::Azure.ErrorOptions.NoThrow) != global::Azure.ErrorOptions.NoThrow)))
{
    throw new global::Azure.RequestFailedException(message.Response);
}

return message.Response;
