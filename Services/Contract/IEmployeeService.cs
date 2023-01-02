using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Services.Contract
{
    public interface IEmployeeService
    {
        Task<List<TEmployee>> GetList();
        Task<TEmployee> Get(int IdEmployee);
        Task<TEmployee> Add(TEmployee employee);
        Task<bool> Update(TEmployee employee);
        Task<bool> Delete(TEmployee employee);
    }
}
