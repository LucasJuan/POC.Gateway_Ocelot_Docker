POC.Gateway
Esta API é apenas um exemplo de como utilizar o OCELOT como gateway para Microserviços e publicar
Para a criação das imagens após baixado o projeto 
- Instale o Docker Desktop em sua maquina para facilitar  a visualização dos containers e imagens
1 Crie a API que será utilizada como Gateway
2 Configure o Program.cs para pegar o arquivo OCELOT de acordo com o ambiente
using POC.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Logging.AddJsonConsole();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);

var app = builder.Build();

startup.Configure(app, app.Environment);

3 Crie 3 arquivos ocelot.json um será o development e outro Local no Development adicione as configurações e a porta em, não se esqueça de colocar o nome do container que será usado no HOST

4 na Local utilize Localhost, vc pode utilizar a porta que te parece melhor exemplo 8001... para cada api que será configurada a porta de acesso.

5 adicione o DockerFile com a inclusão do Composer, clicando com o botão direito do mouse na API em seguida adicionar > Orquestrador de Container... Faça isso apra todas as API'S

6 Configure o Arquivo DcokerFile conforme o exemplo aqui disposto..

7 Configure o arquivo Docker-compose.override.yml conforme disposto no exemplo indicando a porta e informando ao gateway que ele depende das demais imagens da API criada, caso tenha um banco de dados que precisa ser disposto deverá fazer o mesmo.

8 Execute o comando para criar as imagens.
Docker-compose -f docker-compose.yml .\docker-compose.override.yml up -d

__________________
Alguns comandos que podem te ajudar:
docker images = verifica as imagens
docker ps
docker container ls -a = lista os container
docker container rm [nome do container] = remove o container
docker run -it -d -p 8080:80 [nome da imagem] = Cria o container da imagem na porta que eu quero

