using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using QuiverPro.ClassesNavega;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

namespace QuiverPro
{
    /// <summary>
    /// Descrição resumida para IncluiPropSegNovo
    /// </summary>
    [TestClass]
    public class IncluiPropSegNovo
    {

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
        public void IncluirSegNovo()
        {
            #region Classes utilizadas para login e navegação ate o modulo.
            //Classe que faz login no sistema.
            DadosLogin login = new DadosLogin();
            //Classe instanciada para os metodos de navegação.
            NavegaMenu navega = new NavegaMenu();
            #endregion

            //login no sistema.
            IWebDriver driver = login.LogarNoSistema();
            //Esperando tela de inicio carregar.
            System.Threading.Thread.Sleep(8000);

            //navega ao menu operacional.
            driver = navega.NavegaOperacional(driver);

            //comando para acesso ao iframe 
            driver.SwitchTo().Frame("ZonaInterna");
            //escolhendo o menu por javascript executando função diretamente.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("SelecionaModuloJQuery('ConsultaEmissaoERecusa;Fast/FrmCadastroNovo.aspx?pagina=Documento','EMISSOESRECUSAS','Professional','EMISSOESRECUSAS','Propostas/Apólices'); ");
            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.Id("BtIncluir")).Click();

            System.Threading.Thread.Sleep(5000);

            //Driver entrando no iframe para acesso ao form de cadastro.
            driver.SwitchTo().Frame("ZonaInterna");
            {//processo para clicar e selecionar em combos dinamicos.
                driver.FindElement(By.XPath("//*[@id=\"DIVDocumento_Cliente\"]/div/span/span[1]/span")).Click();

                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("CADASTRO ROBO PARA INCLUIR SEGUROS");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            }


            driver.FindElement(By.Id("Documento_Apolice")).SendKeys("TESTE123");


            //Selecionando seguradora.
            IWebElement seguradora = driver.FindElement(By.Id("Documento_Seguradora"));
            SelectElement comboSeguradora = new SelectElement(seguradora);
            comboSeguradora.SelectByValue("10126");
            System.Threading.Thread.Sleep(2000);
            //
            IWebElement produto = driver.FindElement(By.Id("Documento_Produto"));
            SelectElement comboProduto = new SelectElement(produto);
            comboProduto.SelectByValue("553");



            {//para clicar e selecionar grupo de produção
                driver.FindElement(By.XPath("//*[@id=\"DIVDocumento_GrupoHierarquico\"]/div/span/span[1]/span")).Click();
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("quiver");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            }
            {// Executa a inclusão do inicio de vigência. 
             // Pega o dia da execução e usa como vigencia.
                DateTime iniVigencia = DateTime.Today;
                driver.FindElement(By.Id("Documento_InicioVigencia")).SendKeys(iniVigencia.ToString());
                driver.FindElement(By.Id("Documento_InicioVigencia")).SendKeys(Keys.Tab);
                driver.FindElement(By.Id("Documento_DataEmissao")).SendKeys(iniVigencia.ToString());
                driver.FindElement(By.Id("Documento_TipoNegocio1")).Click();
                driver.FindElement(By.Id("BtGravar")).Click();

            }

        }
    }
}
