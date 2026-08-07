using global::Azure.Core.HttpMessage message = this.CreateFooRequest(context);
message.BufferResponse = false;
return Pipeline.ProcessMessage(message, context);
