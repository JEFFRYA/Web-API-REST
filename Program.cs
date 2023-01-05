using WebAPI_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD.Services.Contract;
using WebAPI_CRUD.Services.Implementation;
using AutoMapper;
using WebAPI_CRUD.DTOs;
using WebAPI_CRUD.Util;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Agregamos la cadena de conexion
builder.Services.AddDbContext<DbEmployeeContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("conection"));
});

// Agregamos los servicios
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// agregamos el servicio de automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// agregamos CORS
builder.Services.AddCors(options => {
    options.AddPolicy("NewPolitic", app => {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region /department/list

app.MapGet("/department/list", async (
    IDepartmentService departmentService,
    IMapper mapper) =>
{

    var departmentsList = await departmentService.GetList();
    var departmentsListDTO = mapper.Map<List<DepartmentDTO>>(departmentsList);

    if (departmentsListDTO.Count > 0)
        return Results.Ok(departmentsListDTO);
    else
        return Results.NotFound();

});

#endregion


#region /employee/list

app.MapGet("/employee/list", async (
    IEmployeeService employeeService,
    IMapper mapper) =>
{

    var employeesList = await employeeService.GetList();
    var employeesListDTO = mapper.Map<List<EmployeeDTO>>(employeesList);

    if (employeesListDTO.Count > 0)
        return Results.Ok(employeesListDTO);
    else
        return Results.NotFound();

});

#endregion


#region /employee/save

app.MapPost("/employee/save", async (
    EmployeeDTO employee,
    IEmployeeService employeeService,
    IMapper mapper) =>
{

    var _employee = mapper.Map<TEmployee>(employee);
    var _employeeCreated = await employeeService.Add(_employee);

    if (_employeeCreated.IdTEmployee != 0)
        return Results.Ok(mapper.Map<EmployeeDTO>(_employeeCreated));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);

});

#endregion

#region /employee/update

app.MapPut("/employee/update/{IdT_Employee}", async (
    int IdTEmployee,
    EmployeeDTO employee,
    IEmployeeService employeeService,
    IMapper mapper) =>
{

    var _employeeFound = await employeeService.Get(IdTEmployee);

    if (_employeeFound is null)
        return Results.NotFound();

    var _employee = mapper.Map<TEmployee>(employee);

    _employeeFound.FullName = employee.FullName;
    _employeeFound.Salary = employee.Salary;
    _employeeFound.IdFDepartment = employee.IdFDepartment;

    var response = await employeeService.Update(_employeeFound);

    if (response)
        return Results.Ok(mapper.Map<EmployeeDTO>(_employeeFound));
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);

});

#endregion

#region /employee/delete

app.MapDelete("/employee/delete/{IdT_Employee}", async (
    int IdTEmployee,
    IEmployeeService employeeService 
    ) =>
{

    var _employeeFound = await employeeService.Get(IdTEmployee);

    if (_employeeFound is null)
        return Results.NotFound();

    var response = await employeeService.Delete(_employeeFound);

    if (response)
        return Results.Ok();
    else
        return Results.StatusCode(StatusCodes.Status500InternalServerError);

});

#endregion

// Indicamos la politica que se estara ejecutando.
app.UseCors("NewPolitic");

app.Run();
