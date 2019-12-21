# Using Azure Standard Libraries

Azure Standard Libraries expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you will know how to use them in other client libraries.

The main shared concepts include:

- Configuring service clients, e.g. configuring retries, logging.
- Accessing HTTP response details.
- Calling long-running operations (LROs).
- Paging and asynchronous streams (AsyncPageable<T>)
- Exceptions for reporting errors from service requests in a consistent fashion.
- Abstractions for representing Azure SDK credentials.