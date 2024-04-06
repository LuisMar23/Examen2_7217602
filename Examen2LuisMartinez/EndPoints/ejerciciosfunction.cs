using Azure;
using Examen2LuisMartinez.Contexto;
using Examen2LuisMartinez.Contratos;
using Examen2LuisMartinez.dto;
using Examen2LuisMartinez.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Examen2LuisMartinez.EndPoints
{
    public class ejerciciosfunction
    {
        private readonly ILogger<ejerciciosfunction> _logger;
        private readonly ApplicationDbContext contexto;
        private readonly IEjerciciosLogic clienteLogic;

        public ejerciciosfunction(ApplicationDbContext context, IEjerciciosLogic clienteLogic, ILogger<ejerciciosfunction> logger)
        {
            this.contexto = context;
            this.clienteLogic = clienteLogic;
            _logger = logger;
        }


    
        [Function("ejercicio1")]
        public async Task<HttpResponseData> InsertarPedidoDetalle([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "insertarpedidodetalle")] HttpRequestData req)
        {
            _logger.LogInformation("ejecutando para insertar afiliados");
            try
            {
                var a = await req.ReadFromJsonAsync<Pedido>() ?? throw new Exception("Debe ingresar un pedido con todos sus datos");
                var b=await req.ReadFromJsonAsync<Detalle>() ?? throw new Exception("Debe ingresar un detalle con todos sus datos");
                bool r = await clienteLogic.InsertarPedidoDetalle(a, b);
                if (r)
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;
                }
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                var error = req.CreateResponse(HttpStatusCode.BadRequest);
                await error.WriteAsJsonAsync(ex.Message);
                return error;
            }
        }

        [Function("ejercicio2")]
        public async Task<HttpResponseData> ejercicio2([HttpTrigger(AuthorizationLevel.Function, "get",Route ="listardetalles")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var consulta = from c in this.contexto.Cliente
                           join p in this.contexto.Pedido on c.idcliente equals p.idcliente
                           join d in this.contexto.Detalle on p.idPedido equals d.idpedido
                           join pr in this.contexto.Producto
                           on d.idproducto equals pr.idproducto
                           select new reporte2dto
                           {
                               nombreCliente = c.nombre,
                               fechapedido = p.fecha,
                               nombreproducto = pr.nombre,
                               subtotal = d.subtotal
                           };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            var json = JsonSerializer.Serialize(consulta);
            await response.WriteStringAsync(json);

            return response;



        }
        [Function("ejercicio3")]
        public async Task<HttpResponseData> ejercicio3([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            //3.realizar el siguiente reporte identificar los 3 productos mas pedidos o solicitados
          
            //var consulta = await this.contexto.Detalle.OrderByDescending()
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            var json = JsonSerializer.Serialize(consulta);
            await response.WriteStringAsync(json);

            return response;
        }

        [Function("ejercicio5")]
        public async Task<HttpResponseData> eliminarcliente(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "eliminarcliente/{id}")] HttpRequestData req,
            int id)
        {
            HttpResponseData respuesta;
            try
            {
                bool eliminado = await clienteLogic.EliminarCliente(id);
                if (eliminado)
                {
                    respuesta = req.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return respuesta;
        }
        [Function("ejercicio6")]
        public async Task<HttpResponseData> ejercicio6(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "productosvendidos/{fechainicial}/{fechafinal}")] HttpRequestData req,
            DateTime fechainicial, DateTime fechafinal)
        {
            var consulta = from p in this.contexto.Pedido
                           join d in this.contexto.Detalle on p.idPedido equals d.idpedido
                           join pr in this.contexto.Producto on d.idproducto equals pr.idproducto
                           where p.fecha >= fechainicial && p.fecha <= fechafinal
                           select (new Producto
                           {
                               idproducto = pr.idproducto,
                               nombre = pr.nombre
                           });
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            var json = JsonSerializer.Serialize(consulta);
            await response.WriteStringAsync(json);

            return response;
        }
    }
}
