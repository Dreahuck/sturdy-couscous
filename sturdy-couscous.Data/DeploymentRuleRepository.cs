using sturdy_couscous.Models.Entities;

namespace sturdy_couscous.Data;


public class DeploymentRuleRepository : IDeploymentRuleRepository
{
    private readonly DeploymentDbContext _context;

    public DeploymentRuleRepository(DeploymentDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DeploymentRule> GetAllRules()
    {
        return _context.DeploymentRules.ToList();
    }

    public DeploymentRule GetRuleById(int id)
    {
        return _context.DeploymentRules.Find( d => d.Id == id);
    }

    public void AddRule(DeploymentRule rule)
    {
        _context.DeploymentRules.Add(rule);
        _context.SaveChanges();
    }
}

