using global::Azure.Core.RequestContent content = global::Azure.Core.RequestContent.Create(global::System.BinaryData.FromString(p1));
return this.Foo(waitUntil, content, cancellationToken.CanBeCanceled ? new global::Azure.RequestContext { CancellationToken = cancellationToken } : null);
