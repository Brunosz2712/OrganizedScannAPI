using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;   // <== Adicionado para [Authorize]
using Microsoft.EntityFrameworkCore;
using OrganizedScannApi.Data;
using OrganizedScannApi.DTOs;
using OrganizedScannApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizedScannApi.Controllers
{
    [ApiController]
    [Route("api/portals")]
    [Authorize]
    public class PortalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<List<PortalSummaryDTO>>> ListSummary()
        {
            var portals = await _context.Portals.ToListAsync();
            var motorcycles = await _context.Motorcycles.Include(m => m.Portal).ToListAsync();

            var result = portals.Select(portal => new PortalSummaryDTO
            {
                PortalName = portal.Name,
                MotorcycleCount = motorcycles.Count(m => m.PortalId == portal.Id),
                MotorcyclePlates = motorcycles
                    .Where(m => m.PortalId == portal.Id)
                    .Select(m => m.LicensePlate)
                    .ToList()
            }).ToList();

            return result;
        }
    }
}
