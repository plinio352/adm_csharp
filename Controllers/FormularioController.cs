using adm_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Controllers
{
    public class FormularioController : Controller
    {
        private readonly Conexao con;

        public FormularioController(Conexao conexao)
        {
            this.con = conexao;
        }

        public IActionResult Index()
        {
            try
            {
                return View(con.Formularios.ToList());
            }
            catch(Exception e)
            {
                return View(NotFound(e.Message));
            }
        }

        [HttpGet]
        public IActionResult Novo()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }

        [HttpPost]
        public IActionResult SaveNovo(Formulario formulario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Formularios.Add(formulario);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                if (id != null)
                {
                    Formulario formulario = con.Formularios.Find(id);
                    return View(formulario);
                }
                else
                {
                    return View(NotFound());
                }
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }

        [HttpPost] 
        public IActionResult SaveEdit(int? id, Formulario formulario)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        con.Formularios.Update(formulario);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(formulario);
                    }
                }
                else
                {
                    return View(NotFound());
                }
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                if(id != null)
                {
                    Formulario formulario = con.Formularios.Find(id);
                    return View(formulario);
                }
                else
                {
                    return View(NotFound());
                }
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }

        [HttpPost]
        public IActionResult SaveDelete(int? id, Formulario formulario)
        {
            try
            {
                if (id != null)
                {
                    con.Formularios.Remove(formulario);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(NotFound());
                }
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }

        }
    }
}
