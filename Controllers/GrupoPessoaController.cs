using adm_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Controllers
{
    public class GrupoPessoaController : Controller
    {
        private readonly Conexao con;

        public GrupoPessoaController(Conexao con)
        {
            this.con = con;
        }

        public IActionResult Index()
        {
            try
            {
                return View(con.GrupoPessoas.ToList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
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
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveNovo(GrupoPessoa grupoPessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Add(grupoPessoa);
                    con.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(grupoPessoa);
                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            try
            {
                if (id != null)
                {
                    GrupoPessoa grupoPessoa = con.GrupoPessoas.Find(id);
                    return View(grupoPessoa);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveEditar(int? id, GrupoPessoa grupoPessoa)
        {
            try
            {
                if (id != null)
                {
                    if (ModelState.IsValid)
                    {
                        con.Update(grupoPessoa);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(grupoPessoa);
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            try
            {
                if (id != null)
                {
                    GrupoPessoa grupoPessoa = con.GrupoPessoas.Find(id);
                    return View(grupoPessoa);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveExcluir(int? id, GrupoPessoa grupoPessoa)
        {
            try
            {
                if (id != null)
                {
                    con.Remove(grupoPessoa);
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
                return NotFound(e.Message);
            }

        }
    }
}
