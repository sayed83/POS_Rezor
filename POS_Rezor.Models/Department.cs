using System;

namespace POS_Rezor.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string ComId { get; set; }
        public string UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string AddedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }

    }
}
