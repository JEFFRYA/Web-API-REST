namespace WebAPI_CRUD.DTOs
{
    public class EmployeeDTO
    {
        public long IdTEmployee { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? FullName { get; set; }
        public long IdTDepartment { get; set; }
        public string? NameDepartment { get; set; }
        public decimal? Salary { get; set; }
    }
}
