using FinanciamentoAPI.Data;
using FinanciamentoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanciamentoAPI.Controllers
{
    [ApiController]
    [Route("v1/finaciamento")]
    public class FinanciamentoController : ControllerBase
    {
        [HttpGet]
        [Route("listar-todos")]
        public async Task<ActionResult<List<Empresa>>> Get([FromServices] DataContext context)
        {
            var empresas = await context.Empresa.ToListAsync();
            return empresas;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Empresa>> Post([FromServices] DataContext context, [FromBody] Empresa model)
        {
            if (ModelState.IsValid)
            {
                model.Id = (context.Empresa.Select(x => x.Id).Any() ? context.Empresa.Select(x => x.Id).First() : 0) + 1 ;

                context.Empresa.Add(model);
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
        public async Task<ActionResult<Empresa>> Delete([FromServices] DataContext context, int id)
        {
            Empresa empresa =
                await context.Empresa
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ModelState.IsValid)
            {
                context.Empresa.Remove(empresa);
                await context.SaveChangesAsync();
                return empresa;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult<Empresa>> Put([FromServices] DataContext context, [FromBody]Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                context.Empresa.Update(empresa);
                await context.SaveChangesAsync();
                return empresa;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("obter-por-id")]
        public async Task<ActionResult<Empresa>> GetById([FromServices] DataContext context, int id)
        {
            Empresa empresa = 
                await context.Empresa
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return empresa;
        }

        [HttpGet]
        [Route("calcular-valor-total-financiamento")]
        public async Task<ActionResult<string>> GetCalcular([FromServices] DataContext context, int id)
        {
            Empresa empresa =
                await context.Empresa
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            int nMeses = empresa.QtdAnos * 12;
            double txJuros = empresa.TaxaJuros / 100;

            double montante = (empresa.ValorParcela * ((Math.Pow((1 + txJuros), nMeses) - 1) / txJuros)) + empresa.ValorEntrada;

            return montante.ToString("C");
        }
    }
}
