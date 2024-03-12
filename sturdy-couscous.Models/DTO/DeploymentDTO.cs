using System;
namespace sturdy_couscous.Models.DTO
{
    public class DeploymentDTO
    {
        public string Application { get; set; }
        public string Location { get; set; }
        public DateTime DeploymentDate { get; set; }
    }
}

