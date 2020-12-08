using adm_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private readonly Conexao con;

        public ConfiguracaoController(Conexao con)
        {
            this.con = con;
        }

        public IActionResult Index()
        {
            try
            {
                return View(con.Configuracaos.ToList());
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Novo()
        {
            try
            {
                ViewData["UnidadeImgBD"] = new SelectList(con.Opcaos.Where(x => x.Tipo == "02"), "Value", "Value");
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveNovo(Configuracao configuracao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Configuracaos.Add(configuracao);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(configuracao);
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                if(id != null)
                {
                    Configuracao configuracao = con.Configuracaos.Find(id);

                    ViewData["UnidadeImgBD"] = new SelectList(con.Opcaos.Where(x => x.Tipo == "02"), "Value", "Value", configuracao.UnidadeImgBD);

                    return View(configuracao);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveEdit(int? id, Configuracao configuracao)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        con.Configuracaos.Update(configuracao);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(configuracao);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                ViewBag.pergunta = "Tem certeza que deseja deletar o registro?";

                if (id != null)
                {
                    
                    Configuracao configuracao = con.Configuracaos.Find(id);
                    return View(configuracao);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveDelete(int? id, Configuracao configuracao)
        {
            try
            {
                if (id != null)
                {
                    con.Configuracaos.Remove(configuracao);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

    }
}
