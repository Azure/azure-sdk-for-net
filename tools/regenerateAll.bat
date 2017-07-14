@echo off
set repoUser=olydis
set repoBranch=6c4021caff0767cfa72fd25fe2bca0a378a0aa28
call ..\src\SDKs\StreamAnalytics\Management.StreamAnalytics\generate.cmd                              %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Storage\Management.Storage\generate.cmd                                              %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\SqlManagement\Management.Sql\generate.cmd                                            %repoUser% %repoBranch% noInstall
call ..\src\SDKs\ServiceFabric\Management.ServiceFabric\generate.cmd                                  %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\ServerManagement\Management.ServerManagement\generate.cmd                            %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\Resource\Management.ResourceManager\generate.cmd                                     %repoUser% %repoBranch% noInstall
call ..\src\SDKs\RedisCache\Management.Redis\generate.cmd                                             %repoUser% %repoBranch% noInstall
:: ?
call ..\src\SDKs\RecoveryServices\Management.RecoveryServices\generate.cmd                            %repoUser% %repoBranch% noInstall
:: renames, version, ?
call ..\src\SDKs\RecoveryServices.SiteRecovery\Management.RecoveryServices.SiteRecovery\generate.cmd  %repoUser% %repoBranch% noInstall
call ..\src\SDKs\RecoveryServices.Backup\Management.RecoveryServices.Backup\generate.cmd              %repoUser% %repoBranch% noInstall
:: ?
call ..\src\SDKs\PowerBIEmbedded\Management.PowerBIEmbedded\generate.cmd                              %repoUser% %repoBranch% noInstall
:: stuff missing
call ..\src\SDKs\OperationalInsights\Management.OperationalInsights\generate.cmd                      %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Network\Management.Network\generate.cmd                                              %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Monitor\Management.Monitor\generate.cmd                                              %repoUser% %repoBranch% noInstall
:: header, ?
call ..\src\SDKs\Media\Management.Media\generate.cmd                                                  %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Logic\Management.Logic\generate.cmd                                                  %repoUser% %repoBranch% noInstall
:: ?
call ..\src\SDKs\KeyVault\Management\Management.KeyVault\generate.cmd                                 %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\KeyVault\dataPlane\Microsoft.Azure.KeyVault\generate.cmd                             %repoUser% %repoBranch% noInstall
:: ?
call ..\src\SDKs\IotHub\Management.IotHub\generate.cmd                                                %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Intune\Intune\generate.cmd                                                           %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Graph.RBAC\Graph.RBAC\generate.cmd                                                   %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Dns\Management.Dns\generate.cmd                                                      %repoUser% %repoBranch% noInstall
:: ?
call ..\src\SDKs\DevTestLabs\Management.DevTestLabs\generate.cmd                                      %repoUser% %repoBranch% noInstall
call ..\src\SDKs\DataLake.Store\Management.DataLake.Store\generate.cmd                                %repoUser% %repoBranch% noInstall
call ..\src\SDKs\ContainerRegistry\Management.ContainerRegistry\generate.cmd                          %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Consumption\Management.Consumption\generate.cmd                                      %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Compute\Management.Compute\generate.cmd                                              %repoUser% %repoBranch% noInstall
call ..\src\SDKs\CognitiveServices\Management.CognitiveServices\generate.cmd                          %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Cdn\Management.Cdn\generate.cmd                                                      %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Billing\Management.Billing\generate.cmd                                              %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\Batch\Management\generate.cmd                                                        %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\Batch\DataPlane\generate.cmd                                                         %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Authorization\Management.Authorization\generate.cmd                                  %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\StorSimple8000Series\Management.StorSimple8000Series\generate.cmd                    %repoUser% %repoBranch% noInstall
:: header???
call ..\src\SDKs\Scheduler\Management.Scheduler\generate.cmd                                          %repoUser% %repoBranch% noInstall
call ..\src\SDKs\ServiceBus\Management.ServiceBus\generated.cmd                                       %repoUser% %repoBranch% noInstall
call ..\src\SDKs\NotificationHubs\Management.NotificationHubs\generated.cmd                           %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\Search\Management\Management.Search\generate.cmd                                     %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Search\DataPlane\Microsoft.Azure.Search\generate-searchserviceclient.cmd             %repoUser% %repoBranch% noInstall
call ..\src\SDKs\Search\DataPlane\Microsoft.Azure.Search\generate-searchindexclient.cmd               %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\Relay\Management.Relay\generate.cmd                                                  %repoUser% %repoBranch% noInstall
call ..\src\SDKs\CustomerInsights\Management.CustomerInsights\generated.cmd                           %repoUser% %repoBranch% noInstall
call ..\src\SDKs\EventHub\Management.EventHub\generated.cmd                                           %repoUser% %repoBranch% noInstall
call ..\src\SDKs\AnalysisServices\Management.Analysis\generate.cmd                                    %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\WebSites\Management.Websites\generate.cmd                                            %repoUser% %repoBranch% noInstall
:: header
call ..\src\SDKs\TrafficManager\Management.TrafficManager\generate.cmd                                %repoUser% %repoBranch% noInstall
:: ...
call ..\src\SDKs\MachineLearning\Management.MachineLearning\generate.cmd                              %repoUser% %repoBranch% noInstall
call ..\src\SDKs\DataLake.Analytics\Management.DataLake.Analytics\generate.cmd                        %repoUser% %repoBranch% noInstall
