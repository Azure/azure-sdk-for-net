#if NET6_0_OR_GREATER
_multipartContent.CopyTo(stream, default, cancellationToken);
#else
#pragma warning disable AZC0107 // Public asynchronous method shouldn't be called in synchronous scope. Use synchronous version of the method if it is available.
_multipartContent.CopyToAsync(stream).EnsureCompleted();
#pragma warning restore AZC0107 // Public asynchronous method shouldn't be called in synchronous scope. Use synchronous version of the method if it is available.
#endif
