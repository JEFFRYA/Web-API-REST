using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD.Models;
using WebAPI_CRUD.Services.Contract;

namespace WebAPI_CRUD.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        // instancia del contexto de la base de datos

        private DbEmployeeContext _dbContext;

        // constructor

        public EmployeeService(DbEmployeeContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<List<TEmployee>> GetList()
        {
            try
            {
                List<TEmployee> employees = new List<TEmployee>();
                employees = await _dbContext.TEmployees.Include(dpt => dpt.IdFDepartment).ToListAsync();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEmployee> Get(int IdEmployee)
        {
            try
            {
                TEmployee? employee = new TEmployee();
                employee = await _dbContext.TEmployees.Include(dpt => dpt.IdFDepartment)
                    .Where(emp => emp.IdTEmployee == IdEmployee ).FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEmployee> Add(TEmployee employee)
        {
            try
            {
                _dbContext.TEmployees.Add(employee);
                await _dbContext.SaveChangesAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(TEmployee employee)
        {
            try
            {
                _dbContext.TEmployees.Update(employee);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(TEmployee employee)
        {
            try
            {
                _dbContext.TEmployees.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
