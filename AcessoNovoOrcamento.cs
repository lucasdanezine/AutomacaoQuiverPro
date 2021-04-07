using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;

namespace QuiverPro
{
    /// <summary>
    /// Descrição resumida para UnitTest2
    /// </summary>
    [TestClass]
    public class AcessoNovoOrcamento
    {
        public AcessoNovoOrcamento()
        {
            //
            // TODO: Adicionar lógica de construtor aqui
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Esse teste faz acesso a tela de novo orçamento.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public IJavaScriptExecutor Driver { get; private set; }

        #region Atributos de teste adicionais
        //
        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:
        //
        // Use ClassInitialize para executar código antes de executar o primeiro teste na classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para executar código após a execução de todos os testes em uma classe
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize para executar código antes de executar cada teste 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para executar código após execução de cada teste
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

            #region classes utilizadas para navegação.
            DadosLogin login = new DadosLogin();
            NavegaMenu navega = new NavegaMenu();
            #endregion

            IWebDriver driver = login.LogarNoSistema();
            System.Threading.Thread.Sleep(8000);
            // driver = navega.NavegaOperacional(driver);
            driver = navega.NavegaOperacional(driver);
            driver = navega.NavegaRenovacao(driver);
            driver = navega.NavegaVendas(driver);
            driver = navega.NavegaInicio(driver);
            driver = navega.NavegaPortal(driver);
            driver = navega.NavegaPosVendas(driver);
            driver = navega.NavegaVendas(driver);
            System.Threading.Thread.Sleep(4000);
            
            //comando para acesso ao iframe 
            driver.SwitchTo().Frame("ZonaInterna");
            driver.FindElement(By.ClassName("submenunovotitulo"));

            //escolhendo o menu por javascript executando função diretamente.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("SelecionaModuloJQuery('','NOVOORCAMENTO','AcompanhamentoVendas|Professional','NOVOORCAMENTO','Novo orçamento');");

            System.Threading.Thread.Sleep(5000);
            

        }
    }
}
