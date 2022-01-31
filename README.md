# Demo.Kubernetes.Deployment

## To build docker image:
$`docker build -f Demo.Kubernetes.Deployment/Dockerfile -t liteobject/demokubernetesdeployment:latest . --label "created-by=mhoque"

## To view images details:
$`docker inspect [NAME|ID]

## To push to dockerhub
$`docker push liteobject/demokubernetesdeployment:latest

## To run using kubernetes deployment file:
$`kubectl apply -f k8s/deployment.yaml

## To delete a deployment:
$`kubectl delete -f k8s/deployment.yaml

##  To watch logs using label:
$`kubectl logs -l app=weather-forecast-webapi -f --since=10m