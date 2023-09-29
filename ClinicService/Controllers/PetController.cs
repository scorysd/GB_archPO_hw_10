using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;

        public PetController(PetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreatePetRequest createRequest)
        {
            int res = _petRepository.Create(new Pet
            {
                ClientId = createRequest.ClienId,
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdatePetRequest updateRequest)
        {
            int res = _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClienId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday
            });
            return Ok(res);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_petRepository.GetAll());
        }




    }
}

