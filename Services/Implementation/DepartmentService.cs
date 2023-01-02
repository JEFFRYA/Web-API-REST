using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD.Models;
using WebAPI_CRUD.Services.Contract;

namespace WebAPI_CRUD.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        // instancia del contexto de la base de datos

        private DbEmployeeContext _dbContext;

        // constructor

        public DepartmentService(DbEmployeeContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<List<TDepartment>> GetList()
        {
            try
            {
                List<TDepartment> departments = new List<TDepartment>();
                departments = await _dbContext.TDepartments.ToListAsync();

                return departments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
