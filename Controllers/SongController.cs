using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.AspNetCore.StaticFiles;
using Slider5.Models;
using Slider5.Models.Dto;
using Slider5.Repository;

namespace Slider5.Controllers
{
    public class SongController : Controller
    {
        private readonly DbService _service;
        public SongController(DbService serv)
        {
            _service = serv;
        }

        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult<DtoSong>> AddSong(DtoSong dtoSong)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\SliderSongs",
                    dtoSong.File.FileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dtoSong.File.CopyToAsync(stream);
                    stream.Close();
                }

                _service.Add(new Song() { Address = Path.Combine("wwwroot\\SliderSongs", dtoSong.File.FileName), Name = dtoSong.Name });
                return Created("song", dtoSong);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public ActionResult<ICollection<DtoSong>> Search(string searchPhrase)
        {
            try
            {
                var res = _service.FindAll(s => s.Name.Contains(searchPhrase)).ToList();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            string path = _service.Get(id).Address;
            byte[] buff = await System.IO.File.ReadAllBytesAsync(path);
            
            var fileProvider = new FileExtensionContentTypeProvider();
            if (!fileProvider.TryGetContentType(path, out string contentType))
            {
                return File(buff, "application/octet-stream");
            }

            return File(buff, contentType);
        }
    }
}
