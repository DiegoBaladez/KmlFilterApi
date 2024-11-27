using KmlFilterApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KmlFilterApi.Controllers
{
    [ApiController]
    [Route("api/placemarks")]
    public class PlaceMarksController : ControllerBase
    {
        private readonly IKmlFileService _kmlFilterService;

        public PlaceMarksController(IKmlFileService kmlFilterService)
        {
            _kmlFilterService= kmlFilterService;
        }
        [HttpPost("export")]
        public async Task<IActionResult> ExportFile(string parameter, string  value, IFormFile kmlFile)
        {
            try
            {
                var result = await _kmlFilterService.Export(parameter.ToUpper(), value.ToUpper(), kmlFile);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ListElementsInJsonFormat(string parameter, string value)
        {
            try
            {
                var result = await _kmlFilterService.GetJson(parameter.ToUpper(), value.ToUpper());
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("filter")]
        public async Task<IActionResult> ListUniqValues(string parameter)
        {
            try
            {
                var result = await _kmlFilterService.GetUniqueElements(parameter.ToUpper());
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}