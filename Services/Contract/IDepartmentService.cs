using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Services.Contract
{
    public interface IDepartmentService
    {
        Task<List<TDepartment>> GetList();
    }
}
