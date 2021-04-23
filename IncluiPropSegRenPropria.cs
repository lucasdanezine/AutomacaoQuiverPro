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
    public class IncluiPropSegRenPropria
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
        public void IncluirSegRenPropria()
        {
            #region Classes utilizadas para login e navegação ate o modulo.
            //Classe que faz login no sistema.
            DadosLogin login = new DadosLogin();
            //Classe instanciada para os metodos de navegação.
            NavegaMenu navega = new NavegaMenu();
            //Classe instanciada para cadastro do item tipo controle auto.
            CadastroItemAuto cadItem = new CadastroItemAuto();
            //Classe instanciada para cadastro de premio.
            CadastroPremio premioCadastro = new CadastroPremio();
            //Classe instanciada para validar valores e calculo comissão e repasse.
            CadastroComissao comissaoCadastro = new CadastroComissao();
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

            //gerando o número de apólice, ROB+DATA DO CADASTRO+AT (Apolice Tipo) e o número 2 de renovação da propria corretora. 

            string apolice = "";
            int n = 2;

            DateTime numeroApolice = DateTime.Today;
            apolice = "ROB" + numeroApolice.ToString("dd/MM/yyyy") + "AT" + n;

            //IWebElement selecionaConsultaDoc = driver.FindElement(By.Id("TipoConsulta2"));
            // SelectElement comboConsultaDoc = new SelectElement(selecionaConsultaDoc);
            //comboConsultaDoc.SelectByValue("2");
            // driver.FindElement(By.Id("NoApolice")).SendKeys(apolice);
            //driver.FindElement(By.XPath("//*[@id=\"SpanToolBarRightB\"]/button")).Click();


            driver.FindElement(By.Id("BtIncluir")).Click();

            System.Threading.Thread.Sleep(5000);

            //Driver entrando no iframe para acesso ao form de cadastro.
            driver.SwitchTo().Frame("ZonaInterna");
            #region Cadastro capa do doc
            {//processo para clicar e selecionar em combos dinamicos.
                driver.FindElement(By.XPath("//*[@id=\"DIVDocumento_Cliente\"]/div/span/span[1]/span")).Click();

                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys("CADASTRO ROBO PARA INCLUIR SEGUROS");
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Down);
                driver.FindElement(By.XPath("/html/body/span[2]/span/span[1]/input")).SendKeys(Keys.Enter);
            }


            driver.FindElement(By.Id("Documento_Apolice")).SendKeys(apolice);
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
                driver.FindElement(By.Id("Documento_TipoNegocio2")).Click();
                System.Threading.Thread.Sleep(1000);

                //driver.FindElement(By.Id("BtGravar")).Click();
                driver = navega.BtnGravar(driver);
            }
            #endregion

            #region Dados renovação propria
            System.Threading.Thread.Sleep(4000);
            driver.SwitchTo().Frame("ZonaInterna");
            driver = navega.NavegaScroll(driver, "TitDocsRenovados");
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Id("BtIncluirDocsRenovados")).Click();
            System.Threading.Thread.Sleep(4000);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[3]/button[1]")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.SwitchTo().Frame("ZonaInterna");
            driver.SwitchTo().Frame("ZonaInterna");
            driver.SwitchTo().Frame("ZonaInterna");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("DocumentoRenovado_DocumentoRenov_Bt")).Click();
            System.Threading.Thread.Sleep(4000);
            driver.SwitchTo().Frame("SearchApolice3");
            System.Threading.Thread.Sleep(2500);
            driver.FindElement(By.XPath("/html/body/form/div[5]/div[2]/div[2]/div/div[3]/div[3]/div/table/tbody/tr[2]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(4000);


            for (int i = 0; i < 2; i++)
            {
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("ZonaInterna");
                driver.SwitchTo().Frame("ZonaInterna");
                if (i == 0)
                {
                    driver.FindElement(By.Id("BtGravar")).Click();

                    System.Threading.Thread.Sleep(5000);
                    driver.SwitchTo().DefaultContent();
                        driver.FindElement(By.Id("swalbtn1")).Click();
                        System.Threading.Thread.Sleep(5000);
                   

                }
                else
                {
                    driver.FindElement(By.Id("Button1")).Click();
                }

            }

            #endregion
            System.Threading.Thread.Sleep(10000);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("ZonaInterna");
            #region Cadastro Item.
            driver = cadItem.CadItemAuto(driver);
            #endregion

            #region cadastro de prêmio.
            // Cadastro de premio em proposta/seguros
             driver = premioCadastro.CadastraPremio(driver, navega, 20, 5, 10000);
            #endregion

            //validação de comissão e repasse.
            #region validação do cálculo de prêmios, comissão e repasse.
            driver = comissaoCadastro.ValidaComRepNormalParc(driver, navega);
            #endregion

             driver.Quit();
        }
    }
}
