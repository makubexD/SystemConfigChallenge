using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Common;
using System;
using Microsoft.AspNetCore.Cors;
using PremiumCalculator.ServicesCore;

namespace PremiumCalculator.WebAPI.Controllers
{
    [Route("api/calculator")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {        
        private readonly CalculatorServices _calculatorService;

        public CalculatorController(CalculatorServices calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("query")]
        public IActionResult Get(DateTime dateOfBirth, string state, int age)
        {
            var response = _calculatorService.GetPremium(dateOfBirth, state, age);
            if (response == null)
                return BadRequest(Constants.MessageGeneral);
            return Ok(response);
        }
    }
}