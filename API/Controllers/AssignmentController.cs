using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class AssignmentController : BaseApiController
    {
        private readonly DataContext _context;
        public AssignmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // assignments (all assignments)
        public async Task<ActionResult<List<Assignment>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }

        [HttpGet("{id}")] //assignment/id
        public async Task<ActionResult<Assignment>> GetAssignment(Guid id)
        {
            return await _context.Assignments.FindAsync(id);
        }
    }
}