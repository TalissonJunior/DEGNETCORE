## DEGNETCORE

An library to export all the data from your database

### INSTALL

``` C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc()
        .AddApplicationPart(Assembly.Load(new AssemblyName("DEGNETCORE")));
}
```

Add The connection string configuration to your AppSettings.json
``` JSON
{
    "ConnectionStrings": {
        "DefaultConnection": "YOUR CONNECTION STRING GOES HERE"
    },
} 
```

Add to your .gitignore
```.gitignore
wwwroot/libraries/**
```