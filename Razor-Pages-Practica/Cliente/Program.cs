using BaseLibrary.Entities;
using Cliente;
using Blazored.LocalStorage;
using Cliente.ApplicationStates;
using ClienteLibreria.Helpers;
using ClienteLibreria.Services.Contracts;
using ClienteLibreria.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServerLibrary.Repositories.Implementations;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7050");
}).AddHttpMessageHandler<CustomHttpHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7050")});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

// General Department / Department / Branch
builder.Services.AddScoped<IGenericServiceInterface<GeneralDepartment>, GenericServiceImp<GeneralDepartment>>();
builder.Services.AddScoped<IGenericServiceInterface<Department>, GenericServiceImp<Department>>();
builder.Services.AddScoped<IGenericServiceInterface<Branch>, GenericServiceImp<Branch>>();

// Country / City / Town
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImp<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImp<City>>();
builder.Services.AddScoped<IGenericServiceInterface<Town>, GenericServiceImp<Town>>();

// Employee
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImp<Employee>>();

builder.Services.AddScoped<DepartmentState>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();
await builder.Build().RunAsync();
