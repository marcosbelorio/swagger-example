# ExemploSwaggerCustomizado

## Customizações contempladas

-   Informações básicas do projeto no topo da documentação
-   Descrição de cada requisição através do Xml Summary
-   Informaçãoes complementares da requisição com Xml Remarks
-   Exemplos de entrada e saída de dados com Xml Example nas classes de Dto
-   Informações de resposta da requisição com SwaggerResponse
-   Listando todos os possíveis retornos de uma requisição, separando alguns de forma genérica
-   Adicionando parâmetros de cabeçalho na requisição
-   Autenticação das requisições via Token

(Mais exemplos em https://mattfrear.com/tag/swagger/)

## Como Implementar

### Adicionar os pacotes no projeto

```csharp
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Annotations
```

### Configurar o arquivo Startup

```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Teste para Exemplo",
        Version = "v1",
        Description = "Esta API serve para mostrar as possíveis customizações que podemos fazer nos documentos do Swagger.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Marcos Belorio",
            Email = "marcosbelorio@gmail.com",
            Url = new Uri("https://github.com/marcosbelorio"),
        },
        License = new OpenApiLicense
        {
            Name = "Licença de uso da API",
            Url = new Uri("https://example.com/license"),
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization Header.<br />
            Preencha: 'Bearer' [espaço] seu token.<br />
            Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.OperationFilter<OperationFilter>();
    c.EnableAnnotations();
});

...

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação da Api Teste");
});
```

### Configurar o arquivo .csproj

```csharp
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

## Exemplo Gerado

<img src="https://i.ibb.co/Ld1R6Pn/swagger-exemplo.png" alt="swagger-exemplo" border="0">
