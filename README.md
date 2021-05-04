# Demo.Kubernetes.Deployment

# To fix 443 issue
Please run the following commands on a PowerShell prompt

    $ dotnet dev-certs https --clean
    $ dotnet dev-certs https --trust -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p SECRETPASSWORD

Please add the following lines in the docker-compose file and make sure the "docker-compose.override.yml"
is not overriding any values.

    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=SECRETPASSWORD
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
    volumes:
      - ~/.aspnet/https:/https:ro