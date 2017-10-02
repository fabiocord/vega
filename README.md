# vega
Criado com Angular 2, ASP.NET Core e Entity Framework Core. 

# Para rodar o projeto
```
$ npm install
$ dotnet restore
$ dotnet user-secrets set ConnectionStrings:Default "<YOUR CONNETION STRING>"
$ webpack --config webpack.config.vendor.js
$ webpack 
$ dotnet ef database update
$ dotnet watch run 
```
