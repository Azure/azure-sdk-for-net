# Release History

## 7.0.0-preview.3 (Unreleased)


## 7.0.0-preview.2 (2020-05-04)

### Acknowledgements
Thank you to our developer community members who helped to make the Service Bus client library better with their contributions and design input for this release:
- Daniel Marbach _([GitHub](https://github.com/danielmarbach))_
- Sean Feldman _([GitHub](https://github.com/SeanFeldman))_

### Added
- Allow specifying a list of named sessions when using ServiceBusSessionProcessor
- Transactions/Send via support
- Add SessionInitializingAsync/SessionClosingAsync events in ServiceBusSessionProcessor
- Do not attempt to autocomplete messages with the processor if the user settled the message in their callback
- Add SendAsync overload accepting an IEnumerable of ServiceBusMessage
- Various performance improvements  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Improve the way exception stack traces are captured  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
  
### Breaking Changes
- Change from using a static factory method for creating a sendable message from a received message to instead
  using a constructor  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- CreateSessionProcessor parameter sessionId renamed to sessionIds (also changed from string to params string array). 
- Remove cancellation token from CreateProcessor and CreateSessionProcessor  
  _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_
- Rename SendBatchAsync to SendAsync
- Add SenderOptions parameter to CreateSender method.

## 7.0.0-preview.1 (2020-04-07)
- Initial preview for new version of Service Bus library.
- Includes sending/receiving/settling messages from queues/topics and session support.
