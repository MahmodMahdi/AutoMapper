using AutoMapper.Demo.Dtos;
using AutoMapper.Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Demo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly IMapper _mapper;
        public CoursesController(IMapper mapper)
        {
			_mapper = mapper;
        }
        List<Course> courses = new()
			{
			 new Course { BookId = 1,Name= "Math",Description="Be Strong",Price=1000},
			 new Course { BookId = 2,Name= "Physics",Description="Enjoyment",Price=1000},
			 new Course { BookId = 3,Name= "English",Description="Travelling around the world",Price=1000},
			 new Course { BookId = 4,Name= "History",Description="The Past",Price=0}
			};
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			//var Courses = courses.Select(x => new CourseDto { Id = x.Id, Name = x.Name, Description = x.Description, Price = x.Price }); // old way without mapper
			return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
		}
		[HttpGet("Details",Name ="CourseDetailsRoute")]
		public IActionResult GetDetails(int id)
		{
			var course = courses.SingleOrDefault(c => c.BookId==id);
			return Ok(_mapper.Map<CourseDto>(course));
		}
		[HttpPost]
		public IActionResult Create(CourseDto courseDto)
		{
			if (ModelState.IsValid)
			{
				string url = Url.Link("EmployeeDetailsRoute", new { id = courseDto.Id })!;
				return Created(url, _mapper.Map<Course>(courseDto));
			}
			return BadRequest(ModelState);
		}
	}
}
