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
    public class UsuarioController : Controller
    {
        private readonly Conexao con;

        public UsuarioController(Conexao con)
        {
            this.con = con;
        }

        public IActionResult Index()
        {
            try
            {
                var us = con.Usuarios.Include(u => u.GrupoPessoa);
                
                return View(us.ToList());
            }
            catch (Exception e)
            {
                return View(NotFound(e.Message));
            }
        }

        [HttpGet]
        public IActionResult Novo()
        {
            try
            {
                ViewData["GrupoPessoaID"] = new SelectList(con.GrupoPessoas, "ID", "Grupo");
                return View();
            }
            catch(Exception e)
            {
                return View(NotFound(e.Message));
            }
        }

        [HttpPost]
        public IActionResult SaveNovo(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Add(usuario);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuario);
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
                    Usuario usuario = con.Usuarios.Find(id);

                    ViewData["GrupoPessoaID"] = new SelectList(con.GrupoPessoas, "ID", "Grupo", usuario.GrupoPessoaID);

                    return View(usuario);
                }
                else
                {
                    return NotFound();
                }

            }
            catch(Exception e)
            {
                return View(NotFound(e.Message));
            }
        }

        [HttpPost]
        public IActionResult SaveEdit(int? id, Usuario usuario)
        {
            try
            {
                if (id != null){
                    if (ModelState.IsValid)
                    {
                        con.Usuarios.Update(usuario);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(usuario);
                    }
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception e)
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
                    Usuario usuario = con.Usuarios
                        .Include(u => u.GrupoPessoa)
                        .SingleOrDefault(u => u.id == id);                  

                    return View(usuario);
                }
                else
                {
                    return View(NotFound());
                }

            }
            catch(Exception e)
            {
                return View(NotFound(e.Message));
            }
        }

        [HttpPost]
        public IActionResult SaveDelete(int? id, Usuario usuario)
        {
            try
            {
                if(id != null)
                {
                    con.Usuarios.Remove(usuario);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(NotFound());
                }
            }
            catch(Exception e)
            {
                return View(NotFound(e.Message));
            }

        }
    }
    
}
