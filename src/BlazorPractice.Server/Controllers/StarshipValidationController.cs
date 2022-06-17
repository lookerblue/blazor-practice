﻿using Microsoft.AspNetCore.Mvc;
using BlazorPractice.Shared;

namespace BlazorPractice.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarshipValidationController : ControllerBase
    {
        private readonly ILogger<StarshipValidationController> logger;

        public StarshipValidationController(
            ILogger<StarshipValidationController> logger)
        {
            this.logger = logger;
        }

        static readonly string[] scopeRequiredByApi = new[] { "API.Access" };

        [HttpPost]
        public async Task<IActionResult> Post(Starship starship)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            try
            {
                if (starship.Classification == "Defense" &&
                    string.IsNullOrEmpty(starship.Description))
                {
                    ModelState.AddModelError(nameof(starship.Description),
                        "For a 'Defense' ship " +
                        "classification, 'Description' is required.");
                }
                else
                {
                    logger.LogInformation("Processing the form asynchronously");

                    // Process the valid form
                    // async ...

                    return Ok(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Validation Error: {Message}", ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}
