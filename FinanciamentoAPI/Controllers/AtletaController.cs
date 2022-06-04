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

        #region Dados pessoais atleta
        [HttpGet]
        [Route("listar-todos-dados-pessoais-atleta")]
        public async Task<ActionResult<List<AtletaDadosPessoaisModel>>> Get([FromServices] DataContext context)
        {
            var dadosPessoaiss = await context.DadosPessoais.ToListAsync();
            return dadosPessoaiss;
        }

        [HttpPost]
        [Route("adicionar-dados-pessoais-atleta")]
        public async Task<ActionResult<AtletaDadosPessoaisModel>> Post([FromServices] DataContext context, [FromBody] AtletaDadosPessoaisModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = (context.DadosPessoais.Select(x => x.Id).Any() ? context.DadosPessoais.Select(x => x.Id).First() : 0) + 1;

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
        [Route("excluir-atleta")]
        public async Task<ActionResult<AtletaDadosPessoaisModel>> Delete([FromServices] DataContext context, int id)
        {
            AtletaDadosPessoaisModel dadosPessoais =
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
        [Route("alterar-dados-pessoais-atleta")]
        public async Task<ActionResult<AtletaDadosPessoaisModel>> Put([FromServices] DataContext context, [FromBody] AtletaDadosPessoaisModel dadosPessoais)
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
        [Route("obter-por-id-dados-pessoais-atleta")]
        public async Task<ActionResult<AtletaDadosPessoaisModel>> GetById([FromServices] DataContext context, int id)
        {
            AtletaDadosPessoaisModel dadosPessoais =
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

        #endregion

        #region Medidas Antropométricas Atleta

        [HttpPost]
        [Route("adicionar-medidas-antopometricas-atleta")]
        public async Task<ActionResult<AtletaMedidasAntropometricasModel>> PostMedidasAntropometricas([FromServices] DataContext context, [FromBody] AtletaMedidasAntropometricasModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = (context.DadosPessoais.Select(x => x.Id).Any() ? context.DadosPessoais.Select(x => x.Id).First() : 0) + 1;

                context.MedidasAntropometricas.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("excluir-medidas-antopometricas-atleta")]
        public async Task<ActionResult<AtletaMedidasAntropometricasModel>> DeleteMedidasAntropometricas([FromServices] DataContext context, int id)
        {
            AtletaMedidasAntropometricasModel medidasAntropometricas =
                await context.MedidasAntropometricas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ModelState.IsValid)
            {
                context.MedidasAntropometricas.Remove(medidasAntropometricas);
                await context.SaveChangesAsync();
                return medidasAntropometricas;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("alterar-medidas-antopometricas")]
        public async Task<ActionResult<AtletaMedidasAntropometricasModel>> PutMedidasantropometricas([FromServices] DataContext context, [FromBody] AtletaMedidasAntropometricasModel medidasAntropometricas)
        {
            if (ModelState.IsValid)
            {
                context.MedidasAntropometricas.Update(medidasAntropometricas);
                await context.SaveChangesAsync();
                return medidasAntropometricas;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("obter-por-id--medidas-antopometricas")]
        public async Task<ActionResult<AtletaMedidasAntropometricasModel>> GetByIdMedidasantropometricas([FromServices] DataContext context, int id)
        {
            AtletaMedidasAntropometricasModel medidasAntropometricas =
                await context.MedidasAntropometricas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return medidasAntropometricas;
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

        #endregion
    }
}
