using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MinimalAPI_Register.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints => {

    app.MapGet("/register", (Register regEmp) =>
    {
        return $"User: {regEmp.EmployeeEmailAddress} has been registered successfully.";
    }).WithParameterValidation();

    app.MapPost("/register", ([FromBody]Register regEmp) =>
    {
        return $"User: {regEmp.EmployeeEmailAddress} has been registered successfully.";
    }).WithParameterValidation();
});
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.Run();
