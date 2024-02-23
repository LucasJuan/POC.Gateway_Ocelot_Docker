# POC.Gateway

This API serves as an example of how to use OCELOT as a gateway for microservices and publish.

## Setting Up the Project

1. Install Docker Desktop on your machine to facilitate the visualization of containers and images.

2. Create the API that will be used as the gateway.

3. Configure the `Program.cs` file to fetch the OCELOT file according to the environment:

    ```csharp
    using POC.Gateway;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services);

    builder.Logging.AddJsonConsole();
    builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);

    var app = builder.Build();

    startup.Configure(app, app.Environment);
    ```

4. Create three OCELOT configuration files: one for development, one for local, and another for production. In the development file, add configurations and the port. Don't forget to specify the container name used in the host.

5. Use "localhost" in the local file, and you can use the port that suits you best (e.g., 8001) for each API that will be configured for access.

6. Add the DockerFile with the inclusion of the Composer by right-clicking on the API and selecting "Add > Container Orchestrator..." Do this for all APIs.

7. Configure the DockerFile according to the example provided.

8. Configure the Docker-compose.override.yml file as indicated in the example, specifying the port and informing the gateway that it depends on the other API images created. If there is a database that needs to be provisioned, do the same.

9. Execute the command to create the images.

    ```bash
    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
    ```

## Useful Docker Commands

- `docker images`: Verify the images.
- `docker ps` or `docker container ls -a`: List the containers.
- `docker container rm [container name]`: Remove the container.
- `docker run -it -d -p 8080:80 [image name]`: Create the container from the image on the desired port.
