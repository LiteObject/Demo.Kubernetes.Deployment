## Demo.Kubernetes.Deployment

### To build docker image:
- $`docker build -f Demo.Kubernetes.Deployment/Dockerfile -t liteobject/demokubernetesdeployment:latest . --label "created-by=mhoque"`

### To view images details:
- $`docker inspect [NAME|ID]

### To run docker image:
- $`docker run -it --rm --name demo-kubernetes-deployment liteobject/demokubernetesdeployment:latest`

### To push to dockerhub:
- $`docker push liteobject/demokubernetesdeployment:latest`

### To run using kubernetes deployment file:
- $`kubectl apply -f k8s/deployment.yaml`

### To delete a deployment:
- $`kubectl delete -f k8s/deployment.yaml`

###  To watch logs using label:
- $`kubectl logs -l app=weather-forecast-webapi -f --since=10m`

### To fix "Unable to start Kestrel. Interop+Crypto+OpenSslCryptographicException: error:2006D080:BIO routines:BIO_new_file:no such file"
- Remove your existing dev certificate(s):
  - $`dotnet dev-certs https --clean`
- To generate a new self-signed certificate, trust it and also export it to a password-protected .pfx file, all in a single step, otherwise it won't work properly:
  - $`dotnet dev-certs https --trust -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p SECRETPASSWORD`