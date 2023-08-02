using Application.Features.Commands.Courses;
using Application.Features.Commands.Courses.CreateCourse;
using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;
using Application.Features.Queries.Courses;
using Application.Features.Commands.Courses.UpdateCourse;
using Application.Features.Commands.Courses.DeleteCourse;

namespace KUSYS_Demo.UI.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ISender _sender;

        public CoursesController(ISender sender)
        {
            _sender = sender;
        }

       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync (CreateCourseCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(command, cancellationToken);
            return View ("Create");
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new CourseViewModel(), cancellationToken);
            return View(response);
        }       

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateCourseCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(command, cancellationToken);
            return View(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {

            var request = new DeleteCourseCommand(id);

            var response = await _sender.Send(request, cancellationToken);

            return View(response);
        }


    }
}
