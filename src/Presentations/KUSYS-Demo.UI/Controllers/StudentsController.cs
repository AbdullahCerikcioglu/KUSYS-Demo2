using Application.Features.Commands.Courses.CreateCourse;
using Application.Features.Commands.Courses.DeleteCourse;
using Application.Features.Commands.Courses.UpdateCourse;
using Application.Features.Commands.Students.CreateStudent;
using Application.Features.Commands.Students.DeleteStudent;
using Application.Features.Commands.Students.UpdateStudent;
using Application.Features.Queries.Courses;
using Application.Features.Queries.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ISender _sender;

        public StudentsController(ISender sender)
        {
            _sender = sender;
        }
        //ssss
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStudentCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(command, cancellationToken);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] StudentViewModel command, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(command, cancellationToken);
            return View(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateStudentCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(command, cancellationToken);
            return View(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {

            var request = new DeleteStudentCommand(id);

            var response = await _sender.Send(request, cancellationToken);

            return View(response);
        }


    }
}
