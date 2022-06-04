using BikeFit.Data;
using BikeFit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeFit.Controllers
{
    [ApiController]
    [Route("v1/bikeFit")]
    public class AtletaController : ControllerBase
    {
        [HttpGet]
        [Route("listar-todos")]
        public async Task<ActionResult<List<AtletaDadosPessoais>>> Get([FromServices] DataContext context)
        {
            var dadosPessoaiss = await context.DadosPessoais.ToListAsync();
            return dadosPessoaiss;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<AtletaDadosPessoais>> Post([FromServices] DataContext context, [FromBody] AtletaDadosPessoais model)
        {
            if (ModelState.IsValid)
            {
                model.Id = (context.DadosPessoais.Select(x => x.Id).Any() ? context.DadosPessoais.Select(x => x.Id).First() : 0) + 1 ;

                context.DadosPessoais.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public async Task<ActionResult<AtletaDadosPessoais>> Delete([FromServices] DataContext context, int id)
        {
            AtletaDadosPessoais dadosPessoais =
                await context.DadosPessoais
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ModelState.IsValid)
            {
                context.DadosPessoais.Remove(dadosPessoais);
                await context.SaveChangesAsync();
                return dadosPessoais;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult<AtletaDadosPessoais>> Put([FromServices] DataContext context, [FromBody]AtletaDadosPessoais dadosPessoais)
        {
            if (ModelState.IsValid)
            {
                context.DadosPessoais.Update(dadosPessoais);
                await context.SaveChangesAsync();
                return dadosPessoais;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("obter-por-id")]
        public async Task<ActionResult<AtletaDadosPessoais>> GetById([FromServices] DataContext context, int id)
        {
            AtletaDadosPessoais dadosPessoais = 
                await context.DadosPessoais
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return dadosPessoais;
        }

        //[HttpGet]
        //[Route("calculos")]
        //public async Task<ActionResult<string>> GetCalcular([FromServices] DataContext context, int id)
        //{
        //    AtletaDadosPessoais dadosPessoais =
        //        await context.DadosPessoais
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    int nMeses = dadosPessoais.QtdAnos * 12;
        //    double txJuros = dadosPessoais.TaxaJuros / 100;

        //    double montante = (dadosPessoais.ValorParcela * ((Math.Pow((1 + txJuros), nMeses) - 1) / txJuros)) + dadosPessoais.ValorEntrada;

        //    return montante.ToString("C");
        //}
    }
}
