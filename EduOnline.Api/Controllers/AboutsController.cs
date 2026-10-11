using AutoMapper;
using EduOnline.Api.Mapping;
using EduOnline.Business.Abstract;
using EduOnline.DTO.DTOs.AboutDtos;
using EduOnline.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAbouts()
        {
            var abouts =  _aboutService.TGetAll();
            return Ok(abouts);
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(about);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateDto about)
        {
           
             var aboutEntity = mapper.Map<CreateDto, About>(about);
            _aboutService.TCreate(aboutEntity); 
            return NoContent();
        }
    }
}
