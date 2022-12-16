using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SITELUMY.Models;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace SITELUMY.Controllers
{
public class faleconoscoController : Controller
{
  private readonly ILogger<faleconoscoController> _logger;

    public faleconoscoController(ILogger<faleconoscoController> logger)  
    {
        _logger = logger;
    }

public IActionResult faleconosco()
       {
        return View();
       }

    [HttpPost]
        public IActionResult faleconosco(faleconosco f)
        {
            faleconoscoRepository fr = new faleconoscoRepository();
             fr.inserir(f);
             ViewBag.Mensagem = "Mensagem cadastrada com sucesso";
            return View ();
        }

        }

        }