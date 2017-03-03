setlocal

..\..\..\tools\autorest.gen.cmd %1 Microsoft.Azure.Batch.Protocol 1.0.0-Nightly20170209 .\src\Azure.Batch\GeneratedProtocol MICROSOFT_APACHE_NO_VERSION "-ft 1 -disablesimplifier"

endlocal