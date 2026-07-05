global::Samples.Argument.AssertNotNull(body, nameof(body));

using global::System.ClientModel.MultiPartFormContent content = body.ToMultipartFormContent();
using global::Azure.Core.RequestContent requestContent = global::Azure.Core.RequestContent.Create(content);
global::Azure.Response result = this.Upload(requestContent, content.MediaType, cancellationToken.ToRequestContext());
return global::Azure.Response.FromValue(((global::Samples.Models.UploadResult)result), result);
