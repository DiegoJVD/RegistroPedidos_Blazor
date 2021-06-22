using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPedidos_Blazor.BLL;
using RegistroPedidos_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPedidos_Blazor.BLL.Tests
{

    [TestClass()]
    public class OrdenesBLLTests
    {
        Ordenes Orden = new Ordenes();

        [TestMethod()]
        public void GuardarTest()
        {
            

            Orden.Fecha = DateTime.Now;
            Orden.SuplidorId = 1;
            Orden.Monto = 1;
            Orden.Detalle.Add(new OrdenesDetalle { Cantidad = 1, ProductoId = 1, Costo = 1, OrdenId = 1 }) ;

            var paso = OrdenesBLL.Guardar(Orden);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Orden.Monto = 1 ;

            var paso = OrdenesBLL.Modificar(Orden);

            Assert.IsTrue(paso);
        }
        

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = OrdenesBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = OrdenesBLL.Existe(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var paso = OrdenesBLL.GetList();
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = OrdenesBLL.Eliminar(1);
            Assert.IsTrue(paso);
        }
    }
}