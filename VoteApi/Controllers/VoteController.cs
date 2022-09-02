using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VoteApi.Data;
using VoteApi.Models;

namespace VoteApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VoteController : ControllerBase
    {
        private ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Vote data)
        {
            if (data == null)
                return BadRequest();

            DateTime thisDay = DateTime.Now;

            if (thisDay.Hour < 9)
                return BadRequest("Esta muito cedo para votar");
            if (thisDay.Hour >= 12 || (thisDay.Hour == 11 && thisDay.Minute > 50))
                return BadRequest("Votação já encerrou");

            if (String.IsNullOrEmpty(data.User))
                return BadRequest("É obrigatório enviar o nome do colaborador que esta votando");
            var user = _context.Users.FirstOrDefault(u => u.Name == data.User);
            if (user == null)
                return BadRequest("Colaborador não encontrado");

            if (String.IsNullOrEmpty(data.Restaurant))
                return BadRequest("É obrigatório enviar o nome do restaurante que esta recebendo o voto");
            var restaurant = _context.Restaurants.FirstOrDefault(u => u.Name == data.Restaurant);
            if (restaurant == null)
                return BadRequest("Restaurante não encontrado");

            data.User = user.Id.ToString();
            data.Restaurant = restaurant.Id.ToString();

            var vote = _context.Votes.FirstOrDefault(v => v.User == data.User && v.CreatedDate.Date == thisDay.Date);
            if (vote != null)
                return BadRequest("Este colaborador já votou hoje");

            _context.Votes.Add(data);
            _context.SaveChanges();
            return Ok("Voto registrado!");
        }

        [HttpGet]
        public IEnumerable<Vote> GetVoteDay()
        {
            DateTime thisDay = DateTime.Now;
            return _context.Votes.Where(v => v.CreatedDate.Date == thisDay.Date);
        }
    }
}
