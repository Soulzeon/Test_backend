﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MixerBL;
using MixerModels;

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MixerController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;
        //UploadedMusic
        //Users
        //SavedProjects
        //Sample
        //Tracks
        //Paterns
        public MixerController(IMixerBL mixerBL)
        {
            _mixerBL =  mixerBL;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> GetUploadedMusicAsync()
        {
            return Ok(await _mixerBL.GetUploadedMusicAsync());
        }
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _mixerBL.GetUsersAsync());
        }
        public async Task<IActionResult> GetSavedProjectsAsync()
        {
            return Ok(await _mixerBL.GetSavedProjectsAsync());
        }
        public async Task<IActionResult> GetSamplesAsync()
        {
            return Ok(await _mixerBL.GetSamplesAsync());
        }
        public async Task<IActionResult> GetTracksAsync()
        {
            return Ok(await _mixerBL.GetTracksAsync());
        }
        public async Task<IActionResult> GetPatternsAsync()
        {
            return Ok(await _mixerBL.GetPatternsAsync());
        }
        // GET api/<HeroController>/Spiderman
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByNameAsync(string name)
        {
            var uploadedMusic = await _mixerBL.GetUploadeMusicByNameAsync(name);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }
        public async Task<IActionResult> GetUserByNameAsync(string name)
        {
            var user = await _mixerBL.GetUserByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        public async Task<IActionResult> GetSavedProjectByNameAsync(string name)
        {
            var user = await _mixerBL.GetSavedProjectByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        public async Task<IActionResult> GetSampleByNameAsync(string name)
        {
            var user = await _mixerBL.GetSampleByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        public async Task<IActionResult> GetTrackByNameAsync(string name)
        {
            var user = await _mixerBL.GetTrackByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        public async Task<IActionResult> GetPatternByNameAsync(string name)
        {
            var user = await _mixerBL.GetPatternByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<HeroController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUploadedMusicAsync([FromBody] UploadedMusic uploadedMusic)
        {
            try
            {
                await _mixerBL.AddUploadedMusicAsync(uploadedMusic);
                return CreatedAtAction("AddUploadedMusic", uploadedMusic);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        public async Task<IActionResult> AddUserAsync([FromBody] User User)
        {
            try
            {
                await _mixerBL.AddUserAsync(user);
                return CreatedAtAction("AddUser", user);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        public async Task<IActionResult> AddSavedProjectAsync([FromBody] SavedProject savedProject)
        {
            try
            {
                await _mixerBL.AddSavedProjectAsync(savedProject);
                return CreatedAtAction("AddSavedProject", savedProject);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        public async Task<IActionResult> AddSampleAsync([FromBody] Sample sample)
        {
            try
            {
                await _mixerBL.AddSampleAsync(sample);
                return CreatedAtAction("AddSample", sample);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        public async Task<IActionResult> AddTrackAsync([FromBody] Track track)
        {
            try
            {
                await _mixerBL.AddTrackAsync(track);
                return CreatedAtAction("AddTrack", track);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        public async Task<IActionResult> AddPatternAsync([FromBody] Pattern pattern)
        {
            try
            {
                await _mixerBL.AddPatternAsync(pattern);
                return CreatedAtAction("AddPattern", pattern);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUploadedMusicAsync(int id, [FromBody] UploadedMusic uploadedMusic)
        {
            try
            {
                await _mixerBL.UpdateUploadedMusicAsync(uploadedMusic);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
        {
            try
            {
                await _mixerBL.UpdateUserAsync(user);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> UpdateSavedProjectAsynch(int id, [FromBody] SavedProject savedProject)
        {
            try
            {
                await _mixerBL.UpdateSavedProjectAsync(savedProject);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> UpdateSampleAsynch(int id, [FromBody] Sample sample)
        {
            try
            {
                await _mixerBL.UpdateSampleAsync(sample);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> UpdateTrackAsynch(int id, [FromBody] Track track)
        {
            try
            {
                await _mixerBL.UpdateTrackAsync(track);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> UpdatePatternAsynch(int id, [FromBody] Pattern pattern)
        {
            try
            {
                await _mixerBL.UpdatePatternAsync(pattern);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<HeroController>/Thanos
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteUploadedMusicAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteUploadedMusicAsync(await _mixerBL.GetUploadedMusicByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> DeleteUserAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteUserAsync(await _mixerBL.GetUserByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> DeleteSavedProjectAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteSavedProjectAsync(await _mixerBL.GetSavedProjectByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> DeleteSampleAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteSampleAsync(await _mixerBL.GetSampleByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> DeleteTrackAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteTrackAsync(await _mixerBL.GetTrackByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> DeletePatternAsync(string name)
        {
            try
            {
                await _mixerBL.DeletePatternAsync(await _mixerBL.GetPatternByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}