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
    public class PermissaoTelaController : Controller
    {
        private readonly Conexao con;

        public PermissaoTelaController(Conexao conexao)
        {
            this.con = conexao;
        }

        public IActionResult Index()
        {
            try
            {
                return View(con.PermissaoTelas
                    .Include(o => o.Formulario)
                    .Include(o => o.Usuario)
                    .ToList());
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
                ViewData["FormularioId"] = new SelectList(con.Formularios, "Id", "Form");
                ViewData["UsuarioId"] = new SelectList(con.Usuarios, "id", "Nome");
                ViewData["Leitura"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value");
                ViewData["Incluir"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value");
                ViewData["Alterar"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value");
                ViewData["Excluir"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value");
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }

        [HttpPost]
        public IActionResult SaveNovo(PermissaoTela permissaoTela)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.PermissaoTelas.Add(permissaoTela);
                    con.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(permissaoTela);
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
                if (id != null)
                {
                    PermissaoTela permissaoTela = con.PermissaoTelas.Find(id);

                    ViewData["FormularioId"] = new SelectList(con.Formularios, "Id", "Form", permissaoTela.FormularioId);
                    ViewData["UsuarioId"] = new SelectList(con.Usuarios, "id", "Nome", permissaoTela.UsuarioId);
                    ViewData["Leitura"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value", permissaoTela.Leitura);
                    ViewData["Incluir"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value", permissaoTela.Incluir);
                    ViewData["Alterar"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value", permissaoTela.Alterar);
                    ViewData["Excluir"] = new SelectList(con.Opcaos.Where(X => X.Tipo == "00"), "Value", "Value", permissaoTela.Excluir);

                    return View(permissaoTela);
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
        public IActionResult SaveEdit(int? id, PermissaoTela permissaoTela)
        {
            try
            {
                if(id != null)
                {
                    if (ModelState.IsValid)
                    {
                        con.PermissaoTelas.Update(permissaoTela);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(permissaoTela);
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
                if (id != null)
                {
                    PermissaoTela permissaoTela = con.PermissaoTelas
                        .Include(o => o.Formulario)
                        .Include(o => o.Usuario)
                        .SingleOrDefault(p => p.Id == id);

                    return View(permissaoTela);
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
        public IActionResult SaveDelete(int? id, PermissaoTela permissaoTela)
        {
            try
            {
                if(id != null)
                {
                    if (ModelState.IsValid)
                    {
                        con.PermissaoTelas.Remove(permissaoTela);
                        con.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(permissaoTela);
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
    }
}
