using System;
namespace sturdy_couscous.Models.ViewModels
{
    public class DeploymentSearchRequest
    {
        public string Application { get; set; }
        public string Location { get; set; }
        public DateTime? DeploymentDate { get; set; }
        // Autres critères de recherche
    }
}

