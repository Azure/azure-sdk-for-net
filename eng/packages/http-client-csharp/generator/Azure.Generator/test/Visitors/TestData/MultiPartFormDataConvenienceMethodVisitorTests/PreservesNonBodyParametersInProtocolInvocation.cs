global::Samples.Argument.AssertNotNullOrEmpty(collectionId, nameof(collectionId));
global::Samples.Argument.AssertNotNull(body, nameof(body));

using global::System.ClientModel.MultiPartFormContent content = body.ToMultipartFormContent();
using global::Azure.Core.RequestContent requestContent = global::Azure.Core.RequestContent.Create(content);
return this.CreateCollectionAsset(collectionId, requestContent, content.MediaType, cancellationToken.ToRequestContext());
