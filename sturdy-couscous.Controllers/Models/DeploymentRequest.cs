using System;
namespace sturdy_couscous.Controllers.Models
{
    public class DeploymentRequest
    {
        public string Application { get; set; }
        public string DeploymentLocation { get; set; }
        public DateTime DeploymentDate { get; set; }
    }
}

