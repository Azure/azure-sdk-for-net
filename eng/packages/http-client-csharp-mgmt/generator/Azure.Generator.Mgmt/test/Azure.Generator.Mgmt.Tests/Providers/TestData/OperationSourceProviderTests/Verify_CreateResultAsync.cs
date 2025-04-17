﻿using global::System.Text.Json.JsonDocument document = await global::System.Text.Json.JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
global::Samples.Models.ResponseTypeData data = global::Samples.Models.ResponseTypeData.DeserializeResponseTypeData(document.RootElement, global::Samples.ModelSerializationExtensions.WireOptions);
return new global::Samples.ResponseTypeResource(_client, data);
