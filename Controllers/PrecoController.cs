using AppMvcBasica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Controllers
{
    public class PrecoController : Controller
    {
        private readonly ILogger<PrecoController> _logger;

        public PrecoController(ILogger<PrecoController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index(PrecoModel precoModel)
        {
            if (!string.IsNullOrEmpty(precoModel.NomeProduto))
            {
                CalculaButton(precoModel);
            }            

            return View();
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult CalculaButton(PrecoModel precoModel) 
        {
            var preco = FormulaMagica(precoModel);
            ViewBag.preco = "R$:" + String.Format("{0:.##}", preco);
            @ViewBag.nomeProduto = precoModel.NomeProduto.ToString();

            return View();
        }
       
        public double FormulaMagica(PrecoModel precoModel)
        {
            var dthoje = DateTime.Now;
            var dtValidade = precoModel.Validade;            
            int totaldia = (dtValidade.Date - dthoje.Date).Days;

         
            if(precoModel.Refrigeracao == true && totaldia >= 30) // Caso esteja na validade e é um produto refrigerado
            {
                var porcentagem = precoModel.Custo * 20 / 100;
                return precoModel.Custo + porcentagem;
            }
            else if (precoModel.Refrigeracao == false && totaldia >= 30)// Caso não estja na validade e não é um produto refrigerado
            {
                var porcentagem = precoModel.Custo * 20 / 100;
                return precoModel.Custo + porcentagem;
            }
            else if (precoModel.Refrigeracao == true && totaldia <= 29) // Caso não estja na validade e é um produto refrigerado
            {
                var porcentagem = precoModel.Custo * 50 / 100;
                return precoModel.Custo - porcentagem;
            }
            else if (precoModel.Refrigeracao == false && totaldia <= 29) // Caso não estja na validade e não é um produto refrigerado
            {
                var porcentagem = precoModel.Custo * 50 / 100;
                return precoModel.Custo - porcentagem;
            }           
            else 
            {
                return 0;            
            }
        }
    
    }
}
