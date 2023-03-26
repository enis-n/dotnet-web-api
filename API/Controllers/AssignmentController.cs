using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Assignments;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AssignmentController : BaseApiController
    {

        [HttpGet] // assignments (all assignments)
        public async Task<IActionResult> GetAssignments()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")] //assignment/id
        public async Task<IActionResult> GetAssignment(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost] //create assignment
        public async Task<IActionResult> CreateAssignment(Assignment assignment)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Assignment = assignment }));
        }

        [HttpPut("{id}")] //update assignment
        public async Task<IActionResult> EditAssignment(Guid id, Assignment assignment)
        {
            assignment.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Assignment = assignment }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}