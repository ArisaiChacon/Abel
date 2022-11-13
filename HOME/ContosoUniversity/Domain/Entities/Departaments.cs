namespace ContosoUniversity.Domain.Entities.Base
{
    public class Departaments : BaseEntity
    {
        public double Budget { get; set; }
        public int InstructorId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }   
    }
}
