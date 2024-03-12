using System;
using Microsoft.AspNetCore.Mvc;
using sturdy_couscous.Controllers.Models;
using sturdy_couscous.Services;

namespace sturdy_couscous.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeploymentController : ControllerBase
    {
        private readonly DeploymentRuleService _ruleService;

        public DeploymentController(DeploymentRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        [HttpPost("check-date-validity")]
        public IActionResult CheckDateValidity(DeploymentRequest request)
        {
            // Vérifier si la date est valide en fonction du contexte de déploiement
            bool isDateValid = _ruleService.IsDateValid(request.Application, request.DeploymentLocation, request.DeploymentDate);

            if (isDateValid)
            {
                return Ok("La date de déploiement est valide.");
            }
            else
            {
                return BadRequest("La date de déploiement n'est pas autorisée en fonction des règles de déploiement.");
            }
        }
    }
}
