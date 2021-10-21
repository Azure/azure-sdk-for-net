# Useful commands

Warning. These commands contain hardocoded container versions, namespace and job names (look for numbers and kasobol alias). You may want to adjust them to your needs.

These commands were run from powershell. One should navigate to the same directory this readme and Dockerfile resides.

To use test resource subscription.
```
az login
az account set -s "Azure SDK Test Resources"
```

To build docker image (29 is a version and should be changed on demand).
```
docker build . -t stresstestregistry.azurecr.io/kasobol/net-chaos:29
```

To publish docker image (29 is a version and should be changed on demand).
```
az acr login -n stresstestregistry.azurecr.io
docker push stresstestregistry.azurecr.io/kasobol/net-chaos:29
```

To start (install) a test job (remember to update container version in the `testjob.yaml` file).
```
helm install kasobol-net-chaos -n kasobol-test . --set stress-test-addons.env=test
```

To stop (delete) a test job.
```
helm uninstall kasobol-net-chaos -n kasobol-test
```

To check job status (few options that provide various pieces of information).
```
helm list -n kasobol-test
kubectl get jobs -n kasobol-test
kubectl get pods -n kasobol-test
kubectl describe pods -n kasobol-test $(kubectl get pods  -n kasobol-test)[1].Split()[0]
```

To observe job logs.
```
kubectl logs -n kasobol-test -l job-name=stress-kasobol-net-chaos-1
kubectl logs -n kasobol-test -l job-name=stress-kasobol-net-chaos-1 -f
```

To get console access to pod that runs job.
```
kubectl exec -n kasobol-test -it $(kubectl get pods  -n kasobol-test)[1].Split()[0] -- /bin/bash
```
