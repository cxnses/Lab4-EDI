using Lab4_Grupo2.Models;
using Lab4_Grupo2.Models.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Lab4_Grupo2.Controllers
{
    public class PacienteController : Controller
    {
        // GET: PacienteController1
        public ActionResult Index()
        {
            return View(Singleton.Instance.Pacientes.GetList());
        }

        // GET: PacienteController1/Details/5
        public ActionResult Details(string id)
        {
            var viewPaciente = Singleton.Instance.Pacientes.GetList().FirstOrDefault(a => a.Nombres == id);
            return View(viewPaciente);
        }

        // GET: PacienteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int prioridad = 0; 
                int edad = 0;
                DateTime aux = new DateTime();
                var newPaciente = new Paciente
                {
                    Nombres = collection["Nombres"],
                    Apellidos = collection["Apellidos"],
                    FDNacimiento = Convert.ToDateTime(collection["FDNacimiento"]),
                    Sexo = Convert.ToString(collection["Sexo"]),
                    Especializacion = Convert.ToString(collection["Especializacion"]),
                    MIngreso = Convert.ToString(collection["MIngreso"])
                };
                aux =Convert.ToDateTime( newPaciente.FDNacimiento);
                edad = DateTime.Today.AddTicks(-aux.Ticks).Year-1;
                prioridad = newPaciente.Delegado(newPaciente.Sexo,edad,newPaciente.Especializacion,newPaciente.MIngreso);
                Singleton.Instance.Pacientes.Add(newPaciente, DateTime.Now, prioridad);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController1/Edit/5
        public ActionResult Edit(int id)
        {
            //  var viewPaciente = Singleton.Instance.Pacientes.GetList().FirstOrDefault(a => a. == id);
            return View();//viewPaciente);
        }

        // POST: PacienteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Id, IFormCollection collection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacienteController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacienteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               var NewHistorial = Singleton.Instance.Pacientes.Delete();
                Singleton.Instance.Historial.Add(NewHistorial);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
