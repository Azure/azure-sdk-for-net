using ApprovalTests.Reporters;

#if NET461
[assembly: UseReporter(typeof(XUnit2Reporter), typeof(AllFailingTestsClipboardReporter))]
#else
[assembly: UseReporter(typeof(XUnit2Reporter))]
#endif
