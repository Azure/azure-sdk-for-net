(global::System.Threading.CancellationToken userCancellationToken, global::Azure.ErrorOptions statusOption) = context.Parse();
pipeline.Send(message, userCancellationToken);

if ((message.Response.IsError && ((context?.ErrorOptions & global::Azure.ErrorOptions.NoThrow) != global::Azure.ErrorOptions.NoThrow)))
{
    throw new global::Azure.RequestFailedException(message.Response);
}

return message.Response;
