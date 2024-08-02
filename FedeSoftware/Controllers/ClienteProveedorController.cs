using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaseDeDatos.Contexto;
using BaseDeDatos.Entidades;
using BaseDeDatos.Repository;
using FedeSoftware.Services;
using FedeSoftware.Models;
using System.Security.Policy;
using System.Text.Json;
using System.ComponentModel;

namespace FedeSoftware.Controllers
{
    public class ClienteProveedorController : Controller
    {
        private readonly FedeBaseContext _context;
        private readonly IClienteProveedorService Service;
        public ClienteProveedorController(FedeBaseContext context, IClienteProveedorService _service)
        {
            _context = context;
            Service = _service;
        }

        // GET: ClienteProveedor
        public async Task<IActionResult> Index()
        {
            var list = Service.Index();

            return View(list);
        }

        // GET: ClienteProveedor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clienteProveedor = Service.GetClienteProveedor(id);

            if (clienteProveedor == null)
            {
                return NotFound();
            }

            return View(clienteProveedor);
        }

        // GET: ClienteProveedor/Create
        public IActionResult Create()
        {
            ViewData["ResponsabilidadFiscalId"] = new SelectList(_context.ResponsabilidadFiscales, "ResponsabilidadFiscalId", "Descripcion");

            // CONSUMIMOS API DEL GOBIERNO PARA OBTENER LAS PROVINCIAS
            var provincias = ObtenerProvincias();
                       

            ViewData["Provincias"] = new SelectList(provincias.Result.ToList(), "id", "nombre");

            return View();
        }

        // POST: ClienteProveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteProveedorViewModel clienteProveedor)
        {
            if (ModelState.IsValid)
            {
                var clienteProveedorEntity = clienteProveedor.ToEntity();

                Service.Create(clienteProveedorEntity);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponsabilidadFiscalId"] = new SelectList(_context.ResponsabilidadFiscales, "ResponsabilidadFiscalId", "ResponsabilidadFiscalId", clienteProveedor.ResponsabilidadFiscalId);
            return View(clienteProveedor);
        }
        
        // GET: ClienteProveedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteProveedor = await _context.ClienteProveedores.FindAsync(id);
            if (clienteProveedor == null)
            {
                return NotFound();
            }
            ViewData["ResponsabilidadFiscalId"] = new SelectList(_context.ResponsabilidadFiscales, "ResponsabilidadFiscalId", "ResponsabilidadFiscalId", clienteProveedor.ResponsabilidadFiscalId);
            return View(clienteProveedor);
        }

        // POST: ClienteProveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteProveedorId,RazonSocial,Nombre,Apellido,Direccion,Localidad,Whatsapp,Cuit,EsCliente,EsProveedor,ResponsabilidadFiscalId")] ClienteProveedor clienteProveedor)
        {
            if (id != clienteProveedor.ClienteProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteProveedorExists(clienteProveedor.ClienteProveedorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponsabilidadFiscalId"] = new SelectList(_context.ResponsabilidadFiscales, "ResponsabilidadFiscalId", "ResponsabilidadFiscalId", clienteProveedor.ResponsabilidadFiscalId);
            return View(clienteProveedor);
        }

        // GET: ClienteProveedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteProveedor = await _context.ClienteProveedores
                .Include(c => c.ResponsabilidadFiscal)
                .FirstOrDefaultAsync(m => m.ClienteProveedorId == id);
            if (clienteProveedor == null)
            {
                return NotFound();
            }

            return View(clienteProveedor);
        }

        // POST: ClienteProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteProveedor = await _context.ClienteProveedores.FindAsync(id);
            if (clienteProveedor != null)
            {
                _context.ClienteProveedores.Remove(clienteProveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteProveedorExists(int id)
        {
            return _context.ClienteProveedores.Any(e => e.ClienteProveedorId == id);
        }

        private async Task<List<ProvinciaViewModel>> ObtenerProvincias()
        {
            List<ProvinciaViewModel> provincias = new List<ProvinciaViewModel>();

            string url = "https://apis.datos.gob.ar/georef/api/provincias";

            // Crear una instancia de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Enviar una solicitud GET a la API
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Asegurarse de que la respuesta es exitosa
                    response.EnsureSuccessStatusCode();

                    // Leer la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();

                    ProvinciaResponseViewModel result = JsonSerializer.Deserialize<ProvinciaResponseViewModel>(responseBody)!;

                    provincias = result.provincias;

                    // Imprimir la respuesta
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Excepción al realizar la solicitud: {e.Message}");
                }
            }
            return provincias;
        }
    }
}
