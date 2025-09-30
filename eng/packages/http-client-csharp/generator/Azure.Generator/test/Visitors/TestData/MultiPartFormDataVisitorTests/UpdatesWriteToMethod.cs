#if NET6_0_OR_GREATER
_multipartContent.CopyTo(stream, default, cancellationToken);
#else
_multipartContent.CopyToAsync(stream).EnsureCompleted();
#endif
