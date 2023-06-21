using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/hospital")]

    public class HospitalController : ControllerBase
    {
        private readonly IHospitalDbService _context;

        public HospitalController(IHospitalDbService context)
        {
            _context = context;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> getDoctors()
        {
            var result = await _context.GetDoctorsAsync();
            return Ok(result);
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> postDoctor([FromBody] DoctorDTO dto)
        {
            var result = await _context.AddDoctorAsync(dto);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("doctors/{id}")]
        public async Task<IActionResult> updateDoctor([FromRoute] int id, [FromBody] DoctorDTO dto)
        {
            var result = await _context.UpdateDoctorAsync(id, dto);
            if(result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("doctors/{id}")]
        public async Task<IActionResult> deleteDoctor([FromRoute] int id)
        {
            var result = await _context.DeleteDoctorAsync(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("prescriptions/{id}")]
        public async Task<IActionResult> getPrescriptions([FromRoute] int id)
        {
            var result = await _context.getPrescriptionAsync(id);
            if(result == null)
                return BadRequest();
            return Ok(result);
        }
        
    }
}
