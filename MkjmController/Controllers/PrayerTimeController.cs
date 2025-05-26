using Microsoft.AspNetCore.Mvc;
using MkjmCommon.ApiModels;
using MkjmService;

namespace MkjmController.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrayerTimeController(IPrayerTimeService prayerTimeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PrayerTimeResponse>> GetPrayerTimes([FromQuery] PrayerTimeQuery query)
    {
        var result = await prayerTimeService.GetPrayerTimesAsync(query);

        if (result == null)
        {
            return NotFound("Prayer times not found for the provided query.");
        }

        return Ok(result);
    }
}