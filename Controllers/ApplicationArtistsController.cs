﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hello.Data;
using Hello.Data.Models;

namespace Hello.Controllers
{
    [Produces("application/json")]
    [Route("api/Artists")]
    public class ApplicationArtistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationArtistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationArtists
        [HttpGet]
        public IEnumerable<ApplicationArtist> GetApplicationArtist()
        {
            return _context.ApplicationArtist;
        }

        // GET: api/ApplicationArtists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationArtist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationArtist = await _context.ApplicationArtist.SingleOrDefaultAsync(m => m.Id == id);

            if (applicationArtist == null)
            {
                return NotFound();
            }

            return Ok(applicationArtist);
        }

        // PUT: api/ApplicationArtists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationArtist([FromRoute] int id, [FromBody] ApplicationArtist applicationArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationArtist.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationArtist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApplicationArtists
        [HttpPost]
        public async Task<IActionResult> PostApplicationArtist([FromBody] ApplicationArtist applicationArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ApplicationArtist.Add(applicationArtist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationArtist", new { id = applicationArtist.Id }, applicationArtist);
        }

        // DELETE: api/ApplicationArtists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationArtist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationArtist = await _context.ApplicationArtist.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationArtist == null)
            {
                return NotFound();
            }

            _context.ApplicationArtist.Remove(applicationArtist);
            await _context.SaveChangesAsync();

            return Ok(applicationArtist);
        }

        private bool ApplicationArtistExists(int id)
        {
            return _context.ApplicationArtist.Any(e => e.Id == id);
        }
    }
}