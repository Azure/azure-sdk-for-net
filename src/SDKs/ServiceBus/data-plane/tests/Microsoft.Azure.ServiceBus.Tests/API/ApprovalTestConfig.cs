using ApprovalTests.Reporters;

#if FullNetFx
[assembly: UseReporter(typeof(XUnit2Reporter), typeof(AllFailingTestsClipboardReporter))]
#else
[assembly: UseReporter(typeof(XUnit2Reporter))]
#endif
