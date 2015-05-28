using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteAdministrador
    {
        [TestMethod]
        public void GetAdministrador()
        {
            // Arrange
            var adm = new Administrador { Login = "aluno" };

            // Act
            var obter = new AdministradorRepositorio();
            var admRepositorio = obter.ObterAdministrador(adm);

            // Assert
            Assert.IsNotNull(admRepositorio);
        }
    }
}
