## DEGNETCORE

Backend service that works with DEGJS

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