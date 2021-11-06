using DotnetDocsShow.Structured.Mediator;
using DotnetDocsShow.Structured.Mediator.Handlers;
using DotnetDocsShow.Structured.Mediator.Models;
using DotnetDocsShow.Structured.Mediator.Services;
using MediatR;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddMediatR(typeof(Customer));

var app = builder.Build();

app.MapGet("customers", (IMediator mediator) => mediator.Send(new GetAllCustomersRequest()));
app.MapGet("/customers/{id}", (IMediator mediator, Guid id) => mediator.Send(new GetCustomerByIdRequest(id)));
app.MapPost("/customers", (IMediator mediator, CreateCustomerRequest request) => mediator.Send(request));
app.MapDelete("/customers/{id}", (IMediator mediator, Guid id) => mediator.Send(new DeleteCustomerByIdRequest(id)));

app.Run();
