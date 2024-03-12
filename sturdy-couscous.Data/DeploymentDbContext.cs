using System;
using sturdy_couscous.Models.Entities;

namespace sturdy_couscous.Data
{
	public class DeploymentDbContext
	{
		public DeploymentDbContext()
		{
		}

		public List<DeploymentRule> DeploymentRules;

		public void SaveChanges()
		{

		}
    }
}

