using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingFeatureFlagsInMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        public EchoController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        //[HttpGet("{input}")]        
        //public async Task<IActionResult> Get(string input)
        //{
        //    if (await _featureManager.IsEnabledAsync("ReverseEcho"))
        //    {
        //        return Ok(new string(input.Reverse().ToArray()));
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpGet("{input}")]
        [FeatureGate("ReverseEcho")]
        public async Task<IActionResult> Get(string input)
        {
            return Ok(new string(input.Reverse().ToArray()));
        }
    }
}
